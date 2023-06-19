using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Wallee.Boc.Vote.Pages;

public class Index_Tests : VoteWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
