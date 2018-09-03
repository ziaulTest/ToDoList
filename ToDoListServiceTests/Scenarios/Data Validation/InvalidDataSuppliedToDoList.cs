using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using TestStack.BDDfy;
using ToDoList.Models;

namespace ToDoListServiceTests.Scenarios.Data_Validation
{
    [TestFixture]
    public class InvalidDataSuppliedToDoList
    {
        private HttpClient httpClient;
        private Uri requestUri;
        private HttpResponseMessage sut;

        [Test]
        public void Given_A_TodoList_Is_Being_Viewed_When_A_User_Tries_To_Delete_A_ToDoList_Then_The_Response_Returned_Is_NoContent()
        {
            this.Given(_ => _.A_Request_To_View_A_ToDoList())
                .And(_ => _.Add_Item_To_An_existing_List())
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

            requestUri = new Uri("api/ToDoLists/8", UriKind.Relative);

        }

        public async Task Add_Item_To_An_existing_List()
        {
            var data = new ToDoListItems
            {
                Id = 8,
                Task = "The gym",
                Priority = "High",
                Status = "Complete"
            };

            var convertToJson = JsonConvert.SerializeObject(data);
            var buffer = System.Text.Encoding.UTF8.GetBytes(convertToJson);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            sut = await httpClient.PostAsync(requestUri, byteContent);
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

