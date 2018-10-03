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
    public class GivenATaskThatNeedsToBeAdded
    {
        private IActionResult result;
        private ToDoListController sut;

        [SetUp]
        public void SetUp()
        {
            var todoMock = new Mock<IToDoRepository>();
            var metricsMock = new Mock<IMetricsTrackerRepository>();

            var fakeList = new List<ToDoListItems>
            {
                new ToDoListItems()
                {
                    Id = "1",
                    Priority = "high",
                    Status = "started",
                    Task = "complete this test"
                },
                new ToDoListItems()
                {
                    Id = "2",
                    Priority = "high",
                    Status = "started",
                    Task = "complete this test2222"
                },
                new ToDoListItems()
                {
                    Id = "3",
                    Priority = "low",
                    Status = "done",
                    Task = "complete this test3333"
                }
            };

          //  todoMock.Setup(x => x.GetListDataStores(fakeList);
            sut = new ToDoListController(todoMock.Object, metricsMock.Object);
        }

        [Test]
        public void When_Get_To_DoLists_Is_Called__Then_An_OK_Result_Is_Returned()
        {
            result = sut.GetToDoLists();
            Assert.IsNotNull(result as OkObjectResult);
        }

        [Test]
        public void When_Get_To_DoLists_Is_Called__Then_3_Items_Are_Returned()
        {
            result = sut.GetToDoLists();
            var toDoListItemses = (result as OkObjectResult).Value as List<ToDoListItems>;
            var count = toDoListItemses.Count;

            Assert.AreEqual(3, count);
        }
    }
}
