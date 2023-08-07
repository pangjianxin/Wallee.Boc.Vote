using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Wallee.Boc.Vote.Blobs;
using Wallee.Boc.Vote.RulesEngines;

namespace Wallee.Boc.Vote.Web.Pages.RulesEngines.AppraisementResults.RuleWeight
{
    public class IndexModel : VotePageModel
    {
        [BindProperty]
        public UpdateAppraisementResultRuleWeightViewModel ViewModel { get; set; } = default!;

        private readonly IRulesEngineProvider _rulesEngineProvider;

        public IndexModel(IRulesEngineProvider rulesEngineProvider)
        {
            _rulesEngineProvider = rulesEngineProvider;
        }
        public async Task OnGetAsync()
        {
            ViewModel = new()
            {
                RulesEngine = await _rulesEngineProvider.GetWorkflow(BlobConsts.AppraisementResultRuleWeight)
            };
        }

        public async Task OnPostAsync()
        {
            await _rulesEngineProvider.UpdateWorkflow(BlobConsts.AppraisementResultRuleWeight, ViewModel.RulesEngine!);
            Alerts.Add(Volo.Abp.AspNetCore.Mvc.UI.Alerts.AlertType.Success, "更新成功");
        }
    }

    public class UpdateAppraisementResultRuleWeightViewModel
    {
        [Display(Name = "请输入规则引擎")]
        [Required]
        [TextArea(Rows = 20)]
        public string? RulesEngine { get; set; }
    }
}
