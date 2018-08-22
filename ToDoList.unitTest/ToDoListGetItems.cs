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
            var todoMock = new Mock<IToDoRepository>();
           
            var fakeList = new List<ToDoListItems>
            {
                new ToDoListItems()
                {
                    Id = 1,
                    priority = "high",
                    status = "started",
                    task = "complete this test"
                },
                new ToDoListItems()
                {
                    Id = 2,
                    priority = "high",
                    status = "started",
                    task = "complete this test2222"
                },
                new ToDoListItems()
                {
                    Id = 3,
                    priority = "low",
                    status = "done",
                    task = "complete this test3333"
                }
            };

            todoMock.Setup(x => x.GetListDataStores()).Returns(fakeList);
           
            var controller = new ToDoListController(todoMock.Object);
            result = controller.GetToDoLists();
        }

        [Test]
        public void ThenAnOKResultIsReturned()
        {
            Assert.IsNotNull(result as OkObjectResult);
        }

        [Test]
        public void Then3ItemsAreReturned()
        {
            var toDoListItemses = (result as OkObjectResult).Value as List<ToDoListItems>;
            var count = toDoListItemses.Count;

            Assert.AreEqual(3, count);
        }
    }
}
