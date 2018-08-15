using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using ToDoList.Controllers;
using ToDoList.Models;

namespace ToDoList.unitTest
{
    class ToDoListPatchItem
    {


        [TestFixture]
        public class GivenATaskForAToDoListThatNeedsToBeUpdated
        {
            IActionResult result;

            [SetUp]
            public void WhenTryingtoUpdateATask()
            {
                var Controller = new ToDoListController();
                var todolist = new toDoListItems
                {
                    Id = 1,
                    priority = "updated priority",
                    task = "updated task"
                };

                result = Controller.PartiallyUpdate(todolist.Id, todolist);
            }

            [Test]
            public void Then_The_Item_Is_updated()
            {
                Assert.IsNotNull(result);
            }
        }
    }
}
