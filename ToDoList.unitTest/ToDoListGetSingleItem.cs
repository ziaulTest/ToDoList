using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using ToDoList.Controllers;

namespace ToDoList.unitTest
{
    class ToDoListGetSingleItem
    {

        [TestFixture]
        public class GivenATaskForAToDoList
        {
            IActionResult result;

            [SetUp]
            public void WhenCallingAsingleToDoList()
            {
                var Controller = new ToDoListController();

                result = Controller.GetToDoList(1);
            }

            [Test]
            public void Then_A_Sinlge_Item_Is_Returned()
            {
                var okObjectResult = result as OkObjectResult;

                Assert.IsNotNull(okObjectResult.Value);
            }
        }

    }
}
