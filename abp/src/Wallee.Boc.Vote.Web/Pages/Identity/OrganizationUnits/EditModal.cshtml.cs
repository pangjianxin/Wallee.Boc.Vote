using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.Identity;
using Volo.Abp.Validation;
using Wallee.Boc.Vote.OrganizationUnits;
using Wallee.Boc.Vote.OrganizationUnits.Dtos;

namespace Wallee.Boc.Vote.Web.Pages.Identity.OrganizationUnits
{
    public class EditModalModel : VotePageModel
    {
        private readonly IOrganizationUnitAppService _organizationUnitAppService;

        [BindProperty(SupportsGet = true)]
        [HiddenInput]
        public Guid OrganizationUnitId { get; set; }

        [BindProperty]
        public OrganizationUnitUpdateViewModel ViewModel { get; set; } = null!;

        public EditModalModel(
            IOrganizationUnitAppService organizationUnitAppService)
        {
            _organizationUnitAppService = organizationUnitAppService;
        }
        public async Task OnGetAsync()
        {
            var dto = await _organizationUnitAppService.GetAsync(OrganizationUnitId);
            ViewModel = new OrganizationUnitUpdateViewModel { DisplayName = dto?.DisplayName! };
        }

        public async Task OnPostAsync()
        {
            var dto = ObjectMapper.Map<OrganizationUnitUpdateViewModel, OrganizationUnitUpdateDto>(ViewModel);
            await _organizationUnitAppService.UpdateAsync(OrganizationUnitId, dto);
        }
    }
    public class OrganizationUnitUpdateViewModel
    {
        [Display(Name = "机构名称")]
        [Required]
        [DynamicStringLength(typeof(OrganizationUnitConsts), nameof(OrganizationUnitConsts.MaxDisplayNameLength))]
        public string DisplayName { get; set; } = null!;
    }
}
