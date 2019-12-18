using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MainMVC;
using MainMVC.Models.Polls.Entities;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;

namespace XUnitTestProject
{
    public class BasicWebTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        public BasicWebTests(WebApplicationFactory<Startup> factory)
        {
            Client = factory.CreateClient();
        }

        private HttpClient Client { get; }

        [Fact]
        public async Task ReturnsHomePageWithProductListing()
        {
            // Arrange & Act
            var response = await Client.GetAsync("/");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Contains("<h5>First Poll</h5>", stringResponse);
            Assert.Contains("2019 - “ут был павлик", stringResponse);
            Assert.Contains("<h5>Second Poll</h5>", stringResponse);
        }

        [Fact]
        public async Task Create_SentWrongModel_ReturnsViewWithErrorMessages()
        {
            // Arrange
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/Home/CreatePoll");

            var formModel = Data.GetData()[0].ToDictionary<string>() ;
 
            postRequest.Content = new FormUrlEncodedContent(formModel);
 
            var response = await Client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();
 
            var responseString = await response.Content.ReadAsStringAsync();
 
            //Assert
            Assert.Contains("Question Id:4", responseString);
            Assert.Contains("First Poll", responseString);
        }
    }
}
