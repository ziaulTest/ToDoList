using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using TestStack.BDDfy;

namespace ToDoListServiceTests.Scenarios.DeleteToDoList
{
    [TestFixture]
    public class DeleteToDoList
    {
        private HttpClient httpClient;
        private Uri requestUri;
        private HttpResponseMessage sut;

        [Test]
        public void Given_A_TodoList_Is_Being_Viewed_When_A_User_Tries_To_Delete_A_ToDoList_Then_The_Response_Returned_Is_NoContent()
        {
            this.Given(_ => _.A_Request_To_View_A_ToDoList())
                .When(_ => _.The_List_Is_Then_Called())
                .And(_=> _.Delete_An_Existing_List())
                .Then(_ => _.Response_Is_returned_With_NoContent())
                .BDDfy();
        }

        public void A_Request_To_View_A_ToDoList()
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:49469")
            };

            requestUri = new Uri("api/ToDoLists/1", UriKind.Relative);
        }

        public async Task Delete_An_Existing_List()
        {
            sut = await httpClient.DeleteAsync(requestUri);
        }

        public async Task The_List_Is_Then_Called()
        {
            sut = await httpClient.GetAsync(requestUri);
        }

        public void Response_Is_returned_With_NoContent()
        {
            Assert.AreEqual(HttpStatusCode.NoContent, sut.StatusCode);
        }
    }
}

