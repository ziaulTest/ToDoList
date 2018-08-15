using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using ToDoList.Controllers;
using ToDoList.Models;

namespace ToDoList.unitTest
{
 public class ToDoListItemNotFound
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

            [TestFixture]
            public class GivenATaskForAToDoListThatDoesNotExsista
            {
                IActionResult result;

                [SetUp]
                public void WhenTryingtoCallanInvalidTask()
                {
                    var Controller = new ToDoListController();
                    result = Controller.GetToDoLists();
                }

                [Test]
                public void ToDoListNotFoundWithinDatastore()
                {
                    var toDoListItemses = (result as OkObjectResult).Value as List<toDoListItems>;
                    var count = toDoListItemses.Count;

                    Assert.AreNotEqual(50, count);
                }

            }
            
        }
    }
}