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
        private HttpClient httpClient;
        private Uri response;
        private Task<HttpResponseMessage> sut;
        private string content;

        [Test]
        public void GivenATodoListWhenGetIsCalledThenTheResponseIsOK()
        {
            this.Given(_ => _.ToDoList_Is_Available())
                .When(_ => _.The_List_Is_Called())
                .Then(_ => _.Response_Is_returned_With_Ok())
                .BDDfy();
        }

        public void ToDoList_Is_Available()
        {
            this.httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:49469")
            };
        }

        public void The_List_Is_Called()
        {
            using (this.httpClient)
            {
                var request_uri = new Uri("api/ToDoLists", UriKind.Relative);

                this.sut = httpClient.GetAsync(request_uri);
            }
            this.content = sut.Result.Content.ReadAsStringAsync().Result;
        }

        public void Response_Is_returned_With_Ok()
        {

            Assert.AreEqual(sut.Result.StatusCode, HttpStatusCode.OK, content);
        }
    }
}

