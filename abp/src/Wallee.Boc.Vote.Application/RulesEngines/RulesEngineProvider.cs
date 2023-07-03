using Microsoft.Extensions.Caching.Distributed;
using RulesEngine.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.BlobStoring;
using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Json;
using Wallee.Boc.Vote.RulesEngines.Blobs;

namespace Wallee.Boc.Vote.RulesEngines
{
    public class RulesEngineProvider : IRulesEngineProvider, ITransientDependency
    {
        private readonly IBlobContainer<RulesEgineFileContainer> _rulesEngineFileContainer;
        private readonly IDistributedCache<string> _rulesEngineWorkflowCache;
        private readonly IJsonSerializer _jsonSerializer;

        public RulesEngineProvider(
            IBlobContainer<RulesEgineFileContainer> rulesEngineFileContainer,
            IDistributedCache<string> rulesEngineWorkflowCache,
            IJsonSerializer jsonSerializer)
        {
            _rulesEngineFileContainer = rulesEngineFileContainer;
            _rulesEngineWorkflowCache = rulesEngineWorkflowCache;
            _jsonSerializer = jsonSerializer;
        }
        public async Task<string> GetWorkflow(string workflowName)
        {
            return await _rulesEngineWorkflowCache.GetOrAddAsync(
                workflowName,
                GetWorkflowFromBlobAsync,
                () => new DistributedCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromHours(3)
                });

            async Task<string> GetWorkflowFromBlobAsync()
            {
                if (await _rulesEngineFileContainer.ExistsAsync(workflowName))
                {
                    using var stream = await _rulesEngineFileContainer.GetOrNullAsync(workflowName);
                    using var reader = new StreamReader(stream);
                    return await reader.ReadToEndAsync();
                }
                return string.Empty;
            }
        }

        public async Task UpdateWorkflow(string workflowName, string workflow)
        {
            if (!IsWorkflowValid(workflow, _jsonSerializer))
            {
                throw new UserFriendlyException("json格式不正确，请重新输入");
            }

            await _rulesEngineWorkflowCache.SetAsync(workflowName, workflow,
                new DistributedCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromHours(3)
                });

            var bytes = workflow.GetBytes();

            await _rulesEngineFileContainer.SaveAsync(workflowName, bytes, overrideExisting: true);
        }

        private static bool IsWorkflowValid(string stringValue, IJsonSerializer jsonSerializer)
        {
            try
            {
                jsonSerializer.Deserialize<List<Workflow>>(stringValue);
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
