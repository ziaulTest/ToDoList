using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Http.Results;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using ToDoList.Controllers;
using ToDoList.Models;
using OkResult = Microsoft.AspNetCore.Mvc.OkResult;

namespace ToDoList.unitTest
{
  public class ToDoListPatchItem
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

            [Test]
            public void Then_The_Post_Conatins_The_Values()
            {
            }
        }
    }
}
