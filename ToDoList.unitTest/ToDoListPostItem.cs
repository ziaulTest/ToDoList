using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using ToDoList.Controllers;
using ToDoList.Models;

namespace ToDoList.unitTest
{
    class ToDoListPostItem
    {
        [TestFixture]
        public class GivenATaskWhichsNeedsToBeCreated
        {
            IActionResult result;

            [SetUp]
            public void WhenTheTaskDoesNotYetExsist()
            {
                var Controller = new ToDoListController();

                result = Controller.PostToDoList(new toDoListItems
                {
                    Id = 4,
                    priority = "high",
                    status = "Done",
                    task = "do this test"
                });
            }

            [Test]

            public void Then_Post_an_Item()
            {
                Assert.IsInstanceOf<CreatedAtRouteResult>(result);
            }
        }
    }
}
