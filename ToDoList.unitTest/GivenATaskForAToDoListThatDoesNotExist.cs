using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ToDoList.Controllers;
using ToDoList.Interface;

namespace ToDoList.unitTest
{
    [TestFixture]
    public class GivenATaskForAToDoListThatDoesNotExist
    {
        IActionResult result;
        private ToDoListController sut;

        [SetUp]
        public void SetUp()
        {
            var todoMock = new Mock<IToDoRepository>();
            todoMock.Setup(x => x.GetById(50));

            sut = new ToDoListController(todoMock.Object);
        }

        [Test]
        public void Then_The_ToDoList_Is_Not_Found()
        {
            result = sut.GetToDoList(50);
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void Then_Check_If_Object_Is_Not_Found()
        {
            result = sut.GetToDoList(50);
            if (result is OkObjectResult okObjectResult) Assert.IsNull(okObjectResult.Value);
        }
    }
}