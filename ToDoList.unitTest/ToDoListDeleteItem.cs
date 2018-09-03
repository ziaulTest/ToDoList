using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ToDoList.Controllers;
using ToDoList.Interface;

namespace ToDoList.unitTest
{
    public class ToDoListDeleteItem
    {
        [TestFixture]
        public class GivenATaskWhichNeedsToBeDeleted
        {
            IActionResult result;
            Mock<IToDoRepository> todomock;

            [SetUp]
            public void WhenTryingToDeleteATask()
            {
                todomock = new Mock<IToDoRepository>();
                todomock.Setup(x => x.DeleteById(1));
              
                var controller = new ToDoListController(todomock.Object);
                result = controller.DeleteList(1);
             }

            [Test]
            public void Then_The_Task_Is_Deleted()
            {
                Assert.IsInstanceOf<NoContentResult>(result);
            }

            [Test]
            public void Then_The_Specified_List_Is_Checked_For_Deletion()
            {
                todomock.Verify(r => r.DeleteById(1));
            }
        }
    }
}
