using AutoMapper;
using Wallee.Boc.Vote.OrganizationUnits.Dtos;
using Wallee.Boc.Vote.Web.Pages.Identity.OrganizationUnits;

namespace Wallee.Boc.Vote.Web;

public class VoteWebAutoMapperProfile : Profile
{
    public VoteWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.
        CreateMap<OrganizationUnitCreateViewModel, OrganizationUnitCreateDto>();
        CreateMap<OrganizationUnitUpdateViewModel, OrganizationUnitUpdateDto>();
    }
}
