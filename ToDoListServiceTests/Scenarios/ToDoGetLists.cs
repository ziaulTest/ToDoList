using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using TestStack.BDDfy;

namespace ToDoListServiceTests.Scenarios
{
    [TestFixture]
    public class ToDoGetLists
    {
        [Test]
        public void Given_A_Todo_List__When_Get_Is_Called__Then_The_Response_Is__OK()
        {
            this.Given(_ => _.ToDoList_Is_Available())
                .When(_ => _.The_List_Is_Called())
                .Then(_ => _.Response_Is_returned_With_Ok())
                .BDDfy();
        }

        private HttpClient httpClient;
        private Uri response;
        private Task<HttpResponseMessage> sut; 

        public void ToDoList_Is_Available()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:49469")
            };
            var response = new Uri("api/ToDoLists", UriKind.Relative);
        }

        public void The_List_Is_Called()
        {
            Task<HttpResponseMessage> sut = httpClient.GetAsync(response);
        }

        public void Response_Is_returned_With_Ok()
        {
            var content = sut.Result.Content.ReadAsStringAsync().Result;
            Assert.AreEqual(sut.Result.StatusCode, HttpStatusCode.OK,content);
        }
    }
}

