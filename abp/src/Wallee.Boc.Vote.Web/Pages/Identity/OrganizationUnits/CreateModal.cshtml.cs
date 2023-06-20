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
    public class CreateModalModel : VotePageModel
    {
        private readonly IOrganizationUnitAppService _organizationUnitAppService;

        [BindProperty]
        public OrganizationUnitCreateViewModel ViewModel { get; set; } = null!;

        [BindProperty(SupportsGet = true)]
        public Guid? ParentId { get; set; }

        public CreateModalModel(IOrganizationUnitAppService organizationUnitAppService)
        {
            _organizationUnitAppService = organizationUnitAppService;
        }
        public void OnGet()
        {
            ViewModel = new OrganizationUnitCreateViewModel
            {
                ParentId = ParentId
            };
        }

        public async Task OnPostAsync()
        {
            var dto = ObjectMapper.Map<OrganizationUnitCreateViewModel, OrganizationUnitCreateDto>(ViewModel);
            await _organizationUnitAppService.CreateAsync(dto);
        }
    }

    public class OrganizationUnitCreateViewModel
    {
        [Required]
        [Display(Name = "»ú¹¹Ãû³Æ")]
        [DynamicStringLength(typeof(OrganizationUnitConsts), nameof(OrganizationUnitConsts.MaxDisplayNameLength))]
        public string DisplayName { get; set; } = null!;

        [HiddenInput]
        public Guid? ParentId { get; set; }
    }
}
