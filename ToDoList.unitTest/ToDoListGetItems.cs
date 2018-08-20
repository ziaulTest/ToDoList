using System;
using Moq;
using NUnit.Framework;
using System.Web.Http.Results;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using ToDoList.Controllers;
using ToDoList.Interface;
using ToDoList.Models;
using NotFoundResult = Microsoft.AspNetCore.Mvc.NotFoundResult;
using OkObjectResult = Microsoft.AspNetCore.Mvc.OkObjectResult;
using OkResult = System.Web.Http.Results.OkResult;


namespace ToDoList.unitTest
{
    [TestFixture]
    public class GivenTasksForAToDoList
    {
        IActionResult result;
      

        [SetUp]
        public void WhenGetToDoListsIsCalled()
        {
            //Arrange
            var todoMock = new Mock<IToDoRepository>();
           
            var fakeList = new List<toDoListItems>
            {
                new toDoListItems()
                {
                    Id = 1,
                    priority = "high",
                    status = "started",
                    task = "complete this test"
                },
                new toDoListItems()
                {
                    Id = 2,
                    priority = "high",
                    status = "started",
                    task = "complete this test2222"
                },
                new toDoListItems()
                {
                    Id = 3,
                    priority = "low",
                    status = "done",
                    task = "complete this test3333"
                }
            };

            todoMock.Setup(x => x.GetListDataStores()).Returns(fakeList);
            var fake = todoMock.Object;
            var controller = new ToDoListController(fake);
            //Act 
            result = controller.GetToDoLists();
        }

        [Test]
        public void ThenAnOKResultIsReturned()
        {
            //assert
            Assert.IsNotNull(result as OkObjectResult);
        }

        [Test]
        public void Then3ItemsAreReturned()
        {
            var toDoListItemses = (result as OkObjectResult).Value as List<toDoListItems>;
            var count = toDoListItemses.Count;

            Assert.AreEqual(3, count);
        }
    }
}
