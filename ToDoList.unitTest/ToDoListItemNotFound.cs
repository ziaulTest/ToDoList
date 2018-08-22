using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ToDoList.Controllers;
using ToDoList.Interface;

namespace ToDoList.unitTest
{
    public class ToDoListItemNotFound
    {
        [TestFixture]
        public class GivenATaskForAToDoListThatDoesNotExist
        {
            IActionResult result;

            [SetUp]
            public void WhenTryingtoCallATask()
            {
                var todoMock = new Mock<IToDoRepository>();
                todoMock.Setup(x => x.GetById(50));

                var Controller = new ToDoListController(todoMock.Object);
                result = Controller.GetToDoList(50);
            }

            [Test]
            public void Then_The_ToDoList_Is_Not_Found()
            {
                Assert.IsInstanceOf<NotFoundResult>(result);
            }

            [Test]
            public void Then_Check_If_Object_Is_Not_Found()
            {
                if (result is OkObjectResult okObjectResult) Assert.IsNull(okObjectResult.Value);
            }
        }
    }
}