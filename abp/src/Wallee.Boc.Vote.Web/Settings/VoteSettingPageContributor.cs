using System.Threading.Tasks;
using Volo.Abp.SettingManagement.Web.Pages.SettingManagement;
using Wallee.Boc.Vote.Web.Components.VoteSettingGroup;

namespace Wallee.Boc.Vote.Web.Settings
{
    public class VoteSettingPageContributor : ISettingPageContributor
    {
        public Task ConfigureAsync(SettingPageCreationContext context)
        {
            context.Groups.Add(
                new SettingPageGroup(
                    "Wallee.Boc.Vote.VoteSettingGroup",
                    "二维码设置",
                    typeof(VoteSettingGroupViewComponent)
                )
            );

            return Task.CompletedTask;
        }

        public Task<bool> CheckPermissionsAsync(SettingPageCreationContext context)
        {
            // You can check the permissions here
            return Task.FromResult(true);
        }
    }
}
