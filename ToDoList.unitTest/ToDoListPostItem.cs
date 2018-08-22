using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ToDoList.Controllers;
using ToDoList.Interface;
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
                var todolist = new ToDoListItems
                {
                    Id = 4,
                    priority = "high",
                    status = "Done",
                    task = "do this test"
                };
                var todoMock = new Mock<IToDoRepository>();
                todoMock.Setup(x => x.InsertToDoList(todolist));
                var fake = todoMock.Object;

                var controller = new ToDoListController(fake);

                result = controller.PostToDoList(todolist);
            }

            [Test]
            public void Then_Post_an_Item()
            {
                Assert.IsInstanceOf<CreatedAtRouteResult>(result);
            }

            [Test]
            public void Then__Assert_The_Item()
            {
                var toDoListItemses = result as CreatedAtRouteResult;
                var value = toDoListItemses.Value;
                Assert.IsNotNull(value);
            }

            [Test]
            public void Then_Assert_RouteName_Within_Item()
            {
                var toDoListItemses = result as CreatedAtRouteResult;
                var routeName = toDoListItemses.RouteName;

                Assert.AreSame("Get", routeName);
            }
        }
    }
}
