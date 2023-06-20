﻿using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.Security.Claims;

namespace Wallee.Boc.Vote.Identity
{
    public class OrganizationUnitClaimsPrincipalContributor : IAbpClaimsPrincipalContributor, ITransientDependency
    {
        // https://github.com/dotnet/aspnetcore/blob/main/src/Identity/Extensions.Core/src/UserClaimsPrincipalFactory.cs#L74
        private static string IdentityAuthenticationType => "Identity.Application";

        private readonly IIdentityUserRepository _identityUserRepository;

        public OrganizationUnitClaimsPrincipalContributor(
            IIdentityUserRepository identityUserRepository)
        {
            _identityUserRepository = identityUserRepository;
        }

        public async virtual Task ContributeAsync(AbpClaimsPrincipalContributorContext context)
        {
            var claimsIdentity = context.ClaimsPrincipal.Identities.First(x => x.AuthenticationType == IdentityAuthenticationType);

            var userId = claimsIdentity.FindUserId();

            if (!userId.HasValue)
            {
                return;
            }

            var userOus = await _identityUserRepository.GetOrganizationUnitsAsync(id: userId.Value);

            foreach (var userOu in userOus)
            {
                claimsIdentity.AddClaim(new Claim(AbpOrganizationUnitClaimTypes.OrganizationUnit, userOu.Id.ToString()));
            }

            context.ClaimsPrincipal.AddIdentityIfNotContains(claimsIdentity);
        }
    }
}
