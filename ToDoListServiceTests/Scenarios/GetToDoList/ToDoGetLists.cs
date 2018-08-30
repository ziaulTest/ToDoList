using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using TestStack.BDDfy;

namespace ToDoListServiceTests.Scenarios.GetToDoList
{
    [TestFixture]
    public class ToDoGetLists
    {
        private HttpClient httpClient;
        private Uri requestUri;
        private HttpResponseMessage sut;

        [Test]
        public void Given_A_TodoList_When_Get_Is_Called_Then_The_Response_Is_Ok()
        {
            this.Given(_ => _.A_Request_To_View_A_ToDoList())
                .When(_ => _.The_List_Is_Called())
                .Then(_ => _.Response_Is_Returned_With_Status_Ok())
                .BDDfy();
        }

        public void A_Request_To_View_A_ToDoList()
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:49469")
            };

            requestUri = new Uri("api/ToDoLists", UriKind.Relative);
        }

        public async Task The_List_Is_Called()
        {
            sut = await httpClient.GetAsync(requestUri);
        }

        public void Response_Is_Returned_With_Status_Ok()
        {
            var content = sut.Content.ReadAsStringAsync().Result;
            Assert.AreEqual(sut.StatusCode, HttpStatusCode.OK, content);
        }
    }
}

