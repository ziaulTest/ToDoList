using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Controllers;
using ToDoList.Interface;
using ToDoList.Models;
using OkObjectResult = Microsoft.AspNetCore.Mvc.OkObjectResult;

namespace ToDoList.unitTest
{
    [TestFixture]
    public class GivenTasksForAToDoList
    {
        private IActionResult result;

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
        public void ThenAnOkResultIsReturned()
        {
            Assert.IsNotNull(result as OkObjectResult);
        }

        [Test]
        public void Then3ItemsAreReturned()
        {
            if (!((result as OkObjectResult)?.Value is List<ToDoListItems> toDoListItems)) return;
            var count = toDoListItems.Count;

            Assert.AreEqual(3, count);
        }
    }
}
