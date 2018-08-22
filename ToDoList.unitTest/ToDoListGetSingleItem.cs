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
   public class ToDoListGetSingleItem
    {

        [TestFixture]
        public class GivenATaskForAToDoList
        {
            IActionResult result;
            Mock<IToDoRepository> todomock;

            [SetUp]
            public void WhenCallingAsingleToDoList()
            {
                var todoMock = new Mock<IToDoRepository>();
                todoMock.Setup(x => x.GetById(1)).Returns(new ToDoListItems
                {
                    Id = 1,
                    priority = "High",
                    status = "Complete",
                    task = "Test this Moq"
                });

                var controller = new ToDoListController(todoMock.Object);
                result = controller.GetToDoList(1);
            }
            
            [Test]
            public void Then_A_Sinlge_Item_Is_Returned()
            {
                var okObjectResult = result as OkObjectResult;
                Assert.IsNotNull(okObjectResult.Value);
            }

            [Test]
            public void Then_A_ToDoList_Item_Is_Checked_And_Is_Returned()
            {
                todomock.Verify(x=> x.GetById(1));
            }
        }
    }
}
