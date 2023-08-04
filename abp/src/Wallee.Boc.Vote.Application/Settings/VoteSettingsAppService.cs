using System.Threading.Tasks;
using Volo.Abp.SettingManagement;

namespace Wallee.Boc.Vote.Settings
{
    public class VoteSettingsAppService : SettingManagementAppServiceBase, IVoteSettingsAppService
    {
        private readonly ISettingManager _settingManager;

        public VoteSettingsAppService(ISettingManager settingManager)
        {
            _settingManager = settingManager;
        }

        public async Task<VoteSettingsDto> GetVoteSettingsAsync()
        {
            return new VoteSettingsDto
            {
                AppraisementQrcodeUrl = await SettingProvider.GetOrNullAsync(VoteSettings.AppraisementQrcodeUrl)
            };
        }
        public async Task UpdateVoteSettingsAsync(UpdateVoteSettingsDto input)
        {
            await _settingManager.SetForTenantOrGlobalAsync(CurrentTenant.Id, VoteSettings.AppraisementQrcodeUrl, input.AppraisementQrcodeUrl);
        }
    }
}
