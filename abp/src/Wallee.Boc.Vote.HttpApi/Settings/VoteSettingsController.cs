using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Wallee.Boc.Vote.Settings
{
    public class VoteSettingsController : VoteController, IVoteSettingsAppService
    {
        private readonly IVoteSettingsAppService _voteSettingsAppService;

        public VoteSettingsController(IVoteSettingsAppService voteSettingsAppService)
        {
            _voteSettingsAppService = voteSettingsAppService;
        }

        [HttpGet]
        public async Task<VoteSettingsDto> GetVoteSettingsAsync()
        {
            return await _voteSettingsAppService.GetVoteSettingsAsync();
        }

        [HttpPut]
        public async Task UpdateVoteSettingsAsync(UpdateVoteSettingsDto input)
        {
            await _voteSettingsAppService.UpdateVoteSettingsAsync(input);
        }
    }
}
