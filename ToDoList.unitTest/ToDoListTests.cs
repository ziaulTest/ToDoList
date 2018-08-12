using System;
using Moq;
using NUnit.Framework;
using System.Web.Http.Results;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using toDoList.Api.Controllers;


namespace ToDoList.unitTest
{
    [TestFixture]
    public class ToDoListTests
    {
        [SetUp]
        public void Setup()
        {
            //private Mock<IToDoItemAdaptor> todoAdapter;
            //private ToDoController toDoController;
            //this.todoAdapter = new Mock<IToDoItemAdaptor>();
            //this.toDoController = new ToDoController(this.todoAdapter.Object);
        }
      //  private Mock<IToDoItemAdaptor> todoAdapter;
        //private ToDoListController toDoController;

        [Test]
        public void Be_able_to_return_all_items()
        {
        var Controller = new ToDoListController();
        var GetAll = Controller.GetToDoLists();

         // return Ok(ToDoListDataStore.Current.ToDoList);

        var OkResult = GetAll as OkObjectResult;
        
        Assert.IsNotNull(OkResult);
        Assert.AreEqual(200,OkResult.StatusCode);
        }
    }


}
