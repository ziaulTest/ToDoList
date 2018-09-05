using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;
using ToDoList;

namespace ToDoListServiceTests
{
    [TestFixture]
    public class ToDoGetListServiceTest : WebApplicationFactory<Startup>
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public ToDoGetListServiceTest()
        {
            _server = new TestServer(WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>()
                .UseEnvironment("Debug"));
            _client = _server.CreateClient();
        }

        [Test]
        public void Get_Request()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:49469")
            };

            var response = new Uri("api/ToDoLists", UriKind.Relative);
            var sut = httpClient.GetAsync(response);
            var content = sut.Result.Content.ReadAsStringAsync().Result;

            Assert.AreEqual(sut.Result.StatusCode, HttpStatusCode.OK, content);
        }

        [Test]
        public void Check_If_Application_Is_JSON()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:49469")
            };
            var response = new Uri("api/ToDoLists", UriKind.Relative);
            var sut = httpClient.GetAsync(response).GetAwaiter().GetResult();
            var typeofContentHeaders = sut.Content.Headers.ContentType.MediaType;

            Assert.AreEqual("application/json", typeofContentHeaders);
        }

        [Test]
        public async Task test_In_Store_Memory()
        {
       
            var resp = await _client.GetAsync("api/ToDoLists");
           
            Assert.AreEqual(HttpStatusCode.OK, resp.StatusCode);
        }
    }
}
