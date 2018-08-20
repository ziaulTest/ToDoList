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
 public class ToDoListItemNotFound
    {
        [TestFixture]
        public class GivenATaskForAToDoListThatDoesNotExsist
        {
            IActionResult result;


            [SetUp]
            public void WhenTryingtoCallATask()
            {
                var todoMock = new Mock<IToDoRepository>();

                todoMock.Setup(x => x.GetById(50));
                var fake = todoMock.Object;
                var Controller = new ToDoListController(fake);

                result = Controller.GetToDoList(50);
            }

            [Test]
            public void ToDoList_Not_Found()
            {
                Assert.IsInstanceOf<NotFoundResult>(result);
            }

            [Test]
            public void Then_Check_If_Object_IsNot_Found()
            {
                if (result is OkObjectResult okObjectResult) Assert.IsNull(okObjectResult.Value);
            }
        }
    }
}