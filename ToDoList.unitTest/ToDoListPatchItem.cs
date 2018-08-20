using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Http.Results;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ToDoList.Controllers;
using ToDoList.Interface;
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
                var todolist = new toDoListItems
                {
                    Id = 1,
                    priority = "updated priority",
                    task = "updated task"
                };

                var todoMock = new Mock<IToDoRepository>();
                todoMock.Setup(x => x.UpdateToDoList(todolist.Id, todolist));
                var fake = todoMock.Object;

                var controller = new ToDoListController(fake);
                result = controller.PartiallyUpdate(todolist.Id, todolist);
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
