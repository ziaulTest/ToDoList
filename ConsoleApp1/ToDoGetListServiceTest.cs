using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ToDoListServiceTest
{
    [TestFixture]
    public class ToDoGetListServiceTest
    {
        [Test]
        public void GetRequest()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("http://localhost:49469");
                var response = new Uri("api/ToDoLists", UriKind.Relative);
                Task<HttpResponseMessage> sut = httpClient.GetAsync(response);
                var content = sut.Result.Content.ReadAsStringAsync().Result;
    
              Assert.AreEqual(sut.Result.StatusCode, HttpStatusCode.OK, content);
            }
        }
    }
}

