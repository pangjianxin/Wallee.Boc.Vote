using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace Wallee.Boc.Vote;

public class VoteWebTestStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication<VoteWebTestModule>();
    }

    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        app.InitializeApplication();
    }
}
