using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using ToDoList.Controllers;

namespace ToDoList.unitTest
{
    class ToDoListDeleteItem
    {
        [TestFixture]
        public class GivenATaskWhichNeedsToBeDeleted
        {
            IActionResult result;

            [SetUp]
            public void WhenTryingtoDeleteATask()
            {
                var Controller = new ToDoListController();
                result = Controller.DeleteList(1);
            }

            [Test]
            public void Then_The_Task_Is_Deleted()
            {
                Assert.IsInstanceOf<NoContentResult>(result);
            }
        }
    }
}
