using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestStack.BDDfy;

namespace ToDoListServiceTests.Scenarios
{
    //[TestFixture]
    //public class ToDoAddList
    //{
    //    [Test]
    //    public void Given_A_Todo_List__When_Get_Is_Called__Then_The_Response_Is__OK()
    //    {
    //        this.Given(_ => _.User_Can_View_ToDoList())
    //            .When(_ => _.The_Task_Is_Added())
    //            .Then(_ => _.Response_Is_returned_With_Ok())
    //            .BDDfy();
    //    }

    //    private HttpClient httpClient;
    //    private Uri response;
    //    private Task<HttpResponseMessage> sut;

    //    public void User_Can_View_ToDoList()
    //    {
    //        this.httpClient = new HttpClient
    //        {
    //            BaseAddress = new Uri("http://localhost:49469")
    //        };
    //        this.response = new Uri("api/ToDoLists", UriKind.Relative);
    //    }

    //    public void The_Task_Is_Added()
    //    {

    //    }

    //    public void Response_Is_returned_With_Ok()
    //    {

    //    }
    //}
}
