using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ToDoServiceTests
{
    public class ApiSteps
    {
        private HttpClient httpClient;

        public void ToDoList_Is_Available()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:49469")
            };
        }

        public void The_List_Is_Called()
        {
            var response = new Uri("api/ToDoLists", UriKind.Relative);
            Task<HttpResponseMessage> sut = httpClient.GetAsync(response);
        }

        public void Response_Is_returned_With_Ok()
        {

            //var content = sut.Result.Content.ReadAsStringAsync().Result;
        }
    }
}
