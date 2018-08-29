using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ToDoListServiceTests
{
    public class ToDoGetListServiceTest
    {
        [Test]
        public void Get_Request()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:49469")
            };

            var response = new Uri("api/ToDoLists", UriKind.Relative);
            Task<HttpResponseMessage> sut = httpClient.GetAsync(response);
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
            HttpResponseMessage sut = httpClient.GetAsync(response).GetAwaiter().GetResult();
            var typeofContentHeaders = sut.Content.Headers.ContentType.MediaType;

            Assert.AreEqual("application/json", typeofContentHeaders);
        }
    }
}
