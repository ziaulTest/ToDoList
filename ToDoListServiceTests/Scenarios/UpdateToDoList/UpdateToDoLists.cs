using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using NUnit.Framework;
using TestStack.BDDfy;
using ToDoList.Models;
using MediaTypeHeaderValue = System.Net.Http.Headers.MediaTypeHeaderValue;

namespace ToDoListServiceTests.Scenarios.UpdateToDoList
{
    [TestFixture]
    public class UpdateToDoLists
    {
        private HttpClient httpClient;
        private Uri requestUri;
        private HttpResponseMessage sut;

        [Test]
        public void
            Given_A_TodoList_Item_That_Does_Not_Exist_When_A_User_Tries_To_Adds_A_ToDoList_Item_And_They_Can_Add_An_Item_Then_The_Response_is_Ok()
        {
            this.Given(_ => _.A_Request_To_View_A_ToDoList())
                .When(_ => _.The_List_Is_Then_Called())
                .And(_ => _.Update_A_ToDoList_Item())
                .Then(_ => _.Response_Is_returned_With_Ok())
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

        public async Task Update_A_ToDoList_Item()
        {
            var data = new ToDoListItems
            {
                Id = 1,
                task = "added Via service Test",
                priority = "High"
            };

            var convertToJson = JsonConvert.SerializeObject(data);
            var buffer = Encoding.UTF8.GetBytes(convertToJson);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

           
            sut = await httpClient.PutAsync(requestUri, byteContent);
        }

        public async Task The_List_Is_Then_Called()
        {
            sut = await httpClient.GetAsync(requestUri);
        }

        public void Response_Is_returned_With_Ok()
        {
  
            Assert.AreEqual(HttpStatusCode.OK, sut.StatusCode);
        }
    }

}

