using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Wallee.Boc.Vote.Settings
{
    public interface IVoteSettingsAppService : IApplicationService
    {
        Task<VoteSettingsDto> GetVoteSettingsAsync();
        Task UpdateVoteSettingsAsync(UpdateVoteSettingsDto input);
    }
}
