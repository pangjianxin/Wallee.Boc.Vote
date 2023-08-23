using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using Volo.Abp.AspNetCore.WebClientInfo;
using Volo.Abp.DependencyInjection;

namespace Wallee.Boc.Vote.Web.Extensions
{
    [ExposeServices(typeof(IWebClientInfoProvider))]
    [Dependency(ReplaceServices = true)]
    public class VoteHttpContextWebClientInfoProvider : IWebClientInfoProvider, ITransientDependency
    {
        protected ILogger<HttpContextWebClientInfoProvider> Logger { get; }
        protected IHttpContextAccessor HttpContextAccessor { get; }

        public VoteHttpContextWebClientInfoProvider(
            ILogger<HttpContextWebClientInfoProvider> logger,
            IHttpContextAccessor httpContextAccessor)
        {
            Logger = logger;
            HttpContextAccessor = httpContextAccessor;
        }

        public string BrowserInfo => GetBrowserInfo();

        public string ClientIpAddress => GetClientIpAddress();

        protected virtual string GetBrowserInfo()
        {
            return HttpContextAccessor.HttpContext?.Request?.Headers?["User-Agent"]!;
        }

        protected virtual string GetClientIpAddress()
        {
            try
            {
                //X-Real-IP
                var clientIp = HttpContextAccessor.HttpContext?.Request.Headers["X-Forwarded-For"];

                if (clientIp.HasValue)
                {
                    return clientIp.Value.ToString();
                }

                return HttpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString()!;
            }
            catch (Exception ex)
            {
                Logger.LogException(ex, LogLevel.Warning);
                return null!;
            }
        }
    }
}
