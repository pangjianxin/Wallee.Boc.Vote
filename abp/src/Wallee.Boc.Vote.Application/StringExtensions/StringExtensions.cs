using RulesEngine.Models;
using System.Collections.Generic;
using Volo.Abp.Json;

namespace Wallee.Boc.Vote.StringExtensions
{
    public static class StringExtensions
    {
        public static bool IsWorkflowValid(this string stringValue, IJsonSerializer jsonSerializer)
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
