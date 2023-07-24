using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Wallee.Boc.Vote.CandidateOrgUnits;

namespace Wallee.Boc.Vote.Web.Pages.RulesEngines.CandidateOrgUnits
{
    public class IndexModel : VotePageModel
    {
        private readonly ICandidateOrgUnitAppService _candidateOrgUnitAppService;

        [BindProperty]
        public UpdateCandidateOrgUnitRulesEngineViewModel ViewModel { get; set; }
        public IndexModel(ICandidateOrgUnitAppService candidateOrgUnitAppService)
        {
            _candidateOrgUnitAppService = candidateOrgUnitAppService;
            ViewModel = new UpdateCandidateOrgUnitRulesEngineViewModel();
        }
        public async Task<IActionResult> OnGetAsync()
        {
            ViewModel.RulesEngine = await _candidateOrgUnitAppService.GetRulesEngine();
            return Page();
        }

        public async Task OnPostAsync()
        {
            await _candidateOrgUnitAppService.UpdateRulesEngine(ViewModel.RulesEngine!);
            Alerts.Add(Volo.Abp.AspNetCore.Mvc.UI.Alerts.AlertType.Success, "更新成功");
        }
    }
    public class UpdateCandidateOrgUnitRulesEngineViewModel
    {
        [Display(Name = "请输入规则引擎")]
        [Required]
        [TextArea(Rows = 20)]
        public string? RulesEngine { get; set; }
    }
}
