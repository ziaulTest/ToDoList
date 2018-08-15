using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using ToDoList.Controllers;

namespace ToDoList.unitTest
{
    class ToDoListItemNotFound
    {
        [TestFixture]
        public class GivenATaskForAToDoListThatDoesNotExsist
        {
            IActionResult result;

            [SetUp]
            public void WhenTryingtoCallATask()
            {
                var Controller = new ToDoListController();

                result = Controller.GetToDoList(50);
            }

            [Test]
            public void ToDoList_Not_Found()
            {
                Assert.IsInstanceOf<NotFoundResult>(result);
            }
        }

    }
}
