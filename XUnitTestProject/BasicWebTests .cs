//using System.Net.Http;
//using System.Threading.Tasks;
//using MainMVC;
//using Microsoft.AspNetCore.Mvc.Testing;
//using Xunit;

//namespace XUnitTestProject
//{
//    public class BasicWebTests : IClassFixture<WebApplicationFactory<Startup>>
//    {
//        public BasicWebTests(WebApplicationFactory<Startup> factory)
//        {
//            Client = factory.CreateClient();
//        }

//        private HttpClient Client { get; }

//        [Fact]
//        public async Task ReturnsHomePageWithProductListing()
//        {
//            // Arrange & Act
//            var response = await Client.GetAsync("/");
//            response.EnsureSuccessStatusCode();
//            var stringResponse = await response.Content.ReadAsStringAsync();

//            // Assert
//            Assert.Contains("New User", stringResponse);
//        }
//    }
//}
