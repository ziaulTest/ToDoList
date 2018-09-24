using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using NUnit.Framework;
using ToDoList;
using ToDoList.Models;

namespace ToDoListServiceTests.Scenarios.Steps
{
    public class ApiSteps : IDisposable
    {
        private Uri requestUri;
        private HttpResponseMessage sut;
        private  HttpClient client;

        
        [SetUp]
        public void TestServer()
        {
            var server = new TestServer(WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>()
                .UseEnvironment("Debug"));
            client = server.CreateClient();
        }

        [TearDown]
        public void Dispose()
        {
            sut.Dispose();
            client.Dispose();

            
        }

        public void A_Request_To_View_A_Single_ToDoList()
        {
            requestUri = new Uri("api/ToDoLists/1", UriKind.Relative);
        }

        public void A_Request_To_Add_A_Single_ToDoList()
        {
            requestUri = new Uri("api/ToDoLists/4", UriKind.Relative);
        }

        public void A_Request_To_View_ToDoLists()
        {
            requestUri = new Uri("api/ToDoLists", UriKind.Relative);
        }

        public async Task The_List_Is_Called()
        {
            sut = await client.GetAsync(requestUri);
        }

        public async Task Add_Item_To_An_existing_List()
        {
            var data = new ToDoListItems
            {
                Id = 4,
                Task = "added Via service Test",
                Priority = "High",
                Status = "Complete"
            };

            sut = await client.PutAsync(requestUri, new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"));
        }

        public async Task Update_A_ToDoList_Item()
        {
            var data = new ToDoListItems
            {
                Id = 1,
                Priority = "High",
                Task = "added Via service Test"

            };

            sut = await client.PutAsync(requestUri, new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"));

        }

        public async Task Add_Item_To_A_List()
        {
            var data = new ToDoListItems
            {
                Id = 4,
                Task = "The gym at 9pm",
                Priority = "High",
                Status = "Complete"
            };

            sut = await client.PostAsync(requestUri, new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"));
        }

        public async Task Invalid_Update_A_ToDoList_Item()
        {
            var data = new ToDoListItems
            {
                Id = 1,
                Task = "tass",
                Priority = "High"
            };

            sut = await client.PutAsync(requestUri, new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"));

        }

        public async Task Delete_An_Existing_List()
        {
            sut = await client.DeleteAsync(requestUri);
        }
        public void Response_Is_returned_With_Ok()
        {
            Assert.AreEqual(HttpStatusCode.OK, sut.StatusCode);
        }

        public void Response_Is_Returned_With_Status_Ok()
        {
            var content = sut.Content.ReadAsStringAsync().Result;
            Assert.AreEqual(sut.StatusCode, HttpStatusCode.OK, content);
        }

        public void Response_Is_returned_With_Created()
        {
            Assert.AreEqual(HttpStatusCode.Created, sut.StatusCode);
        }

        public void Response_Is_returned_With_NoContent()
        {
            Assert.AreEqual(HttpStatusCode.NoContent, sut.StatusCode);
        }

        public void Response_Is_returned_With_BadRequest()
        {
            Assert.AreEqual(HttpStatusCode.BadRequest, sut.StatusCode);
        }
        public void Response_Is_returned_With_NotFound()
        {
            Assert.AreEqual(HttpStatusCode.NotFound, sut.StatusCode);
        }

    }
}
