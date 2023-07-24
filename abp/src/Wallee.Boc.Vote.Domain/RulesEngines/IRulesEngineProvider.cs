using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Wallee.Boc.Vote.RulesEngines
{
    public interface IRulesEngineProvider : ITransientDependency
    {
        Task<string?> GetWorkflow(string workflowName);
        Task UpdateWorkflow(string workflowName, string workflow);
    }
}
