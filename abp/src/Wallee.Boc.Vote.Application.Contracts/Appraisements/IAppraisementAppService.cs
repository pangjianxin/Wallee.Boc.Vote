using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Volo.Abp.DependencyInjection;

namespace Wallee.Boc.Vote.Appraisements
{
    public interface IAppraisementAppService :
        ICrudAppService<AppraisementDto, Guid, GetAppraisementsInputDto, AppraisementCreateDto, AppraisementUpdateDto>,
        ITransientDependency
    {
        Task<List<AppraisementDto>> GetAllAvailableAsync();
        Task<IRemoteStreamContent> GetDownloadAppraisementQrcode(GetAppraisementQrcodeDto input);
        Task UploadQrcodeBackgroundImageAsync(UploadQrcodeBackgroundDto input);
    }
}
