using Volo.Abp.Content;

namespace Wallee.Boc.Vote.Appraisements
{
    public class UploadQrcodeBgImgDto
    {
        public IRemoteStreamContent File { get; set; } = default!;
    }
}
