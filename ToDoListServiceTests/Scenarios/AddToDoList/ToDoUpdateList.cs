using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using TestStack.BDDfy;
using ToDoList.Models;

namespace ToDoListServiceTests.Scenarios.AddToDoList
{
    [TestFixture]
    public class ToDoUpdateList
    {
        private HttpClient httpClient;
        private Uri requestUri;
        private HttpResponseMessage sut;

        [Test]
        public void Given_A_TodoList_Is_Being_Viewed_When_A_User_Tries_To_Adds_A_ToDoList_Task_And_They_Can_Enter_A_Task_And_Priority_Then_The_Response_is_Ok()
        {
            this.Given(_ => _.ToDoList_Is_Available())
                .When(_ => _.The_List_Is_Then_Called())
                .And(_ => _.Add_Task_And_Priority_To_An_existing_List())
                .Then(_ => _.Response_Is_returned_With_Created())
                .BDDfy();
        }

        public void ToDoList_Is_Available()
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:49469")
            };

            requestUri = new Uri("api/ToDoLists/1", UriKind.Relative);
        }

        public async Task Add_Task_And_Priority_To_An_existing_List()
        {
            var data = new ToDoListItems
            {
                task = "added Via service Test",
                priority = "High"
            };

            var convertToJson = JsonConvert.SerializeObject(data);
            var buffer = System.Text.Encoding.UTF8.GetBytes(convertToJson);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            sut = await httpClient.PostAsync(requestUri, byteContent);
        }

        public async Task The_List_Is_Then_Called()
        {
            sut = await httpClient.GetAsync(requestUri);
        }

        public void Response_Is_returned_With_Created()
        {
            // var content = sut.Content.LoadIntoBufferAsync().ToString();
            Assert.AreEqual(sut.StatusCode, HttpStatusCode.Created);
        }
    }
}

