using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web.Http.Results;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ToDoList.Controllers;
using ToDoList.Interface;
using ToDoList.Models;

namespace ToDoList.unitTest
{
    public class ToDoListPatchItem
    {
        [TestFixture]
        public class GivenATaskForAToDoListThatNeedsToBeUpdated
        {
            IActionResult result;
            Mock<IToDoRepository> todomock;

            [SetUp]
            public void WhenTryingtoUpdateATask()
            {
                todomock = new Mock<IToDoRepository>();
                var old = new toDoListItems
                {
                    Id = 1,
                    priority = "priority",
                    task = "task"
                };
          

                todomock.Setup(x => x.UpdateToDoList(old.Id, old));

                var controller = new ToDoListController(todomock.Object);
                result = controller.PartiallyUpdate(1, new toDoListItems
                {
                    Id = 1,
                    priority = "updated priority",
                    task = "updated task"
                });
            }

            [Test]
            public void Then_The_Item_Is_Updated()
            {
                Assert.IsNotNull(result);
            }

            [Test]
            public void Then_The_Saved_To_Do_List_Item_Contains_The_Expected_Values()
            {
                todomock.Verify(t => t.UpdateToDoList(1, It.Is<toDoListItems>(items => items.priority == "updated priority" && items.task == "updated task")), Times.Once());
            }
        }
    }
}
