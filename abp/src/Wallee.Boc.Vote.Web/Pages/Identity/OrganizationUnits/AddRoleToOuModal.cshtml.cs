using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Wallee.Boc.Vote.OrganizationUnits;
using Wallee.Boc.Vote.OrganizationUnits.Dtos;

namespace Wallee.Boc.Vote.Web.Pages.Identity.OrganizationUnits
{
    public class AddRoleToOuModalModel : VotePageModel
    {
        private readonly IOrganizationUnitAppService _organizationUnitAppService;

        [BindProperty(SupportsGet = true)]
        public Guid OrganizationUnitId { get; set; }

        [BindProperty]
        public OrganizationUnitDto? OrganizationUnit { get; set; }

        public AddRoleToOuModalModel(IOrganizationUnitAppService organizationUnitAppService)
        {
            _organizationUnitAppService = organizationUnitAppService;
        }

        public async Task OnGetAsync()
        {
            OrganizationUnit = await _organizationUnitAppService.GetAsync(OrganizationUnitId);
        }
    }
}
