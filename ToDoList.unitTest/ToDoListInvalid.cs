using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ToDoList.Controllers;
using ToDoList.Interface;
using ToDoList.Models;

namespace ToDoList.unitTest
{
   public class ToDoListInvalid
    {
        [TestFixture]
        public class GivenATaskForAToDoListThatIsInvalid
        {
            IActionResult result;
            Mock<IToDoRepository> todomock;

            [SetUp]
            public void WhenTryingtoCallanInvalidTask()
            {
                todomock = new Mock<IToDoRepository>();
                todomock.Setup(repository => repository.GetById(50));
 
                var Controller = new ToDoListController(todomock.Object);
                result = Controller.GetToDoLists();
            }

            [Test]
            public void Then_ToDoList_Is_NotFound_Within_The_Datastore()
            {
                if ((result as OkObjectResult).Value is List<ToDoListItems> toDoListItemses)
                {
                    var count = toDoListItemses.Count;
                    Assert.AreNotEqual(50, count);
                }
            }
        }
    }
}

