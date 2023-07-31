using Volo.Abp.Content;

namespace Wallee.Boc.Vote.Appraisements
{
    public class UploadQrcodeBackgroundDto
    {
        public IRemoteStreamContent File { get; set; } = default!;
    }
}
