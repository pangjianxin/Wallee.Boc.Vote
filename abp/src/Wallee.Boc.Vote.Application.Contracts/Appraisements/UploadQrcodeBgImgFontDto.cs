using Volo.Abp.Content;

namespace Wallee.Boc.Vote.Appraisements
{
    public class UploadQrcodeBgImgFontDto
    {
        public IRemoteStreamContent File { get; set; } = default!;
    }
}
