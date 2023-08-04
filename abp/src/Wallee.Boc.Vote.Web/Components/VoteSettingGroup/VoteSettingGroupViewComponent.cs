using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Wallee.Boc.Vote.Settings;

namespace Wallee.Boc.Vote.Web.Components.VoteSettingGroup
{
    public class VoteSettingGroupViewComponent : AbpViewComponent
    {
        private readonly IVoteSettingsAppService _voteSettingsAppService;

        public VoteSettingGroupViewComponent(IVoteSettingsAppService voteSettingsAppService)
        {
            _voteSettingsAppService = voteSettingsAppService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var voteSettings = await _voteSettingsAppService.GetVoteSettingsAsync();

            return View("~/Components/VoteSettingGroup/Default.cshtml", new UpdateVoteSettingsViewModel
            {
                AppraisementQrcodeUrl = voteSettings.AppraisementQrcodeUrl,
            });
        }
        public class UpdateVoteSettingsViewModel
        {
            [Required]
            [Display(Name = "评价活动二维码URL")]
            public string AppraisementQrcodeUrl { get; set; } = default!;
        }
    }


}
