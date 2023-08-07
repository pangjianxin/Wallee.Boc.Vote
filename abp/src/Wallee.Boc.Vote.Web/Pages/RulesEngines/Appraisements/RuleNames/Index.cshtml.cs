using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Wallee.Boc.Vote.Blobs;
using Wallee.Boc.Vote.RulesEngines;

namespace Wallee.Boc.Vote.Web.Pages.RulesEngines.Appraisements.RuleNames
{
    public class IndexModel : VotePageModel
    {
        [BindProperty]
        public UpdateAppraisementQrcodeRuleNamesViewModel ViewModel { get; set; } = default!;

        private readonly IRulesEngineProvider _rulesEngineProvider;

        public IndexModel(IRulesEngineProvider rulesEngineProvider)
        {
            _rulesEngineProvider = rulesEngineProvider;
        }
        public async Task OnGetAsync()
        {
            ViewModel = new()
            {
                RulesEngine = await _rulesEngineProvider.GetWorkflow(BlobConsts.AppraisementRuleNames)
            };
        }

        public async Task OnPostAsync()
        {
            await _rulesEngineProvider.UpdateWorkflow(BlobConsts.AppraisementRuleNames, ViewModel.RulesEngine!);
            Alerts.Add(Volo.Abp.AspNetCore.Mvc.UI.Alerts.AlertType.Success, "���³ɹ�");
        }
    }

    public class UpdateAppraisementQrcodeRuleNamesViewModel
    {
        [Display(Name = "�������������")]
        [Required]
        [TextArea(Rows = 20)]
        public string? RulesEngine { get; set; }
    }
}
