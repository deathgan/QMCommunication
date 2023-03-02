using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace QMCommunication.Pages
{
    public class Index_Tests : QMCommunicationWebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }
    }
}
