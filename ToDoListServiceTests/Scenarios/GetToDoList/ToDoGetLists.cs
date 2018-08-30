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
        private HttpClient _httpClient;
        private Uri _requestUri;
        private HttpResponseMessage _sut;

        [Test]
        public void Given_A_TodoList_When_Get_Is_Called_Then_The_Response_Is_Ok()
        {
            this.Given(_ => _.ToDoList_Is_Available())
                .When(_ => _.The_List_Is_Then_Called())
                .Then(_ => _.Response_Is_returned_With_Ok())
                .BDDfy();
        }

        public void ToDoList_Is_Available()
        {
            this._httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:49469")
            };

            _requestUri = new Uri("api/ToDoLists", UriKind.Relative);
        }

        public async Task The_List_Is_Then_Called()
        {
            _sut =  await _httpClient.GetAsync(_requestUri);
        }

        public void Response_Is_returned_With_Ok()
        {
            var content =  _sut.Content.ReadAsStringAsync().Result;
            Assert.AreEqual(_sut.StatusCode, HttpStatusCode.OK, content);
        }
    }
}

