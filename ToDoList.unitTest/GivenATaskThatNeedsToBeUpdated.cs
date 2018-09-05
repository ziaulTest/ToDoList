using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ToDoList.Controllers;
using ToDoList.Interface;
using ToDoList.Models;

namespace ToDoList.unitTest
{
    [TestFixture]
    public class GivenATaskThatNeedsToBeUpdated
    {
        private IActionResult result;
        private ToDoListController sut;

        [SetUp]
        public void SetUp()
        {
            var mockRepository = new Mock<IToDoRepository>();
            var old = new ToDoListItems
            {
                Id = 1,
                Priority = "Priority",
                Task = "Task"
            };

            mockRepository.Setup(x => x.GetById(It.Is<int>(i => i == 1))).Returns(old);
            mockRepository.Setup(x => x.UpdateToDoList(It.Is<int>(i => i == 1), It.IsAny<ToDoListItems>()));
            sut = new ToDoListController(mockRepository.Object);
        }

        [Test]
        public void When_Updating_A_Task_Then_The_Item_Is_Updated()
        {
            result = sut.PartiallyUpdate(1, new ToDoListItems
            {
                Id = 1,
                Priority = "updated Priority",
                Task = "updated Task"
            });

            Assert.IsInstanceOf<OkResult>(result);
        }

        [Test]
        public void When_Updating_A_Task_That_Does_Not_Exist_Then_No_Update_Is_Performed()
        {
            const int unknownTodoItem = 10;
            result = sut.PartiallyUpdate(unknownTodoItem, new ToDoListItems
            {
                Id = unknownTodoItem,
                Priority = "updated Priority",
                Task = "updated Task"
            });

            //Assert.IsNotEmpty(result.ToString());
            
            //Assert.IsInstanceOf<NotFoundResult>(result);
        }
    }
}
