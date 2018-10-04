using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ToDoList.Controllers;
using ToDoList.Interface;
using ToDoList.Models;

namespace ToDoList.unitTest
{
    [TestFixture]
    public class GivenATaskWhichNeedsToBeCreated
    {
        IActionResult result;

        [SetUp]
        public void WhenTheTaskDoesNotYetExist()
        {
            var todolist = new ToDoListItems
            {
                id = "4",
                Priority = "high",
                Status = "Done",
                Task = "do this test"
            };
            var todoMock = new Mock<IToDoRepository>();
             var metricsMock = new Mock<IMetricsTrackerRepository>();
            todoMock.Setup(x => x.InsertToDoList(todolist));

            var controller = new ToDoListController(todoMock.Object, metricsMock.Object);
            result = controller.PostToDoList(todolist);
        }

        [Test]
        public void Then_Post_an_Item()
        {
            Assert.IsInstanceOf<CreatedAtRouteResult>(result);
        }

        [Test]
        public void Then__Assert_The_Item()
        {
            var toDoListItemes = result as CreatedAtRouteResult;
            var value = toDoListItemes.Value;
            Assert.IsNotNull(value);
        }

        [Test]
        public void Then_Assert_RouteName_Within_Item()
        {
            var toDoListItemes = result as CreatedAtRouteResult;
            var routeName = toDoListItemes.RouteName;
            Assert.AreSame("Get", routeName);
        }
    }
}

