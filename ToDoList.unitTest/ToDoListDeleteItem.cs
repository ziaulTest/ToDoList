using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.Language;
using NUnit.Framework;
using ToDoList.Controllers;
using ToDoList.Interface;
using ToDoList.Models;

namespace ToDoList.unitTest
{
    public class ToDoListDeleteItem
    {
        [TestFixture]
        public class GivenATaskWhichNeedsToBeDeleted
        {
            IActionResult result;
           
           

            [SetUp]
            public void WhenTryingtoDeleteATask()
            {
                var todomock = new Mock<IToDoRepository>();
                
                todomock.Setup(x => x.DeleteById(1));

                var fake = todomock.Object;
                
                var Controller = new ToDoListController(fake);
                result = Controller.DeleteList(1);

              // todomock.Verify(r=>r.DeleteById(1));
             }

            [Test]
            public void Then_The_Task_Is_Deleted()
            {
                Assert.IsInstanceOf<NoContentResult>(result);
            }

            [Test]
            public void Then_The_Specified_List_Is_Checked_For_Deleation()
            {
                
            }
        }
    }
}
