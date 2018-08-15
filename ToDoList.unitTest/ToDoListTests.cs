using System;
using Moq;
using NUnit.Framework;
using System.Web.Http.Results;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using ToDoList.Controllers;
using ToDoList.Models;
using NotFoundResult = Microsoft.AspNetCore.Mvc.NotFoundResult;
using OkObjectResult = Microsoft.AspNetCore.Mvc.OkObjectResult;
using OkResult = System.Web.Http.Results.OkResult;


namespace ToDoList.unitTest
{

    [TestFixture]
    public class GivenTasksForAToDoList
    {
        IActionResult result;

        [SetUp]
        public void WhenGetToDoListsIsCalled()
        {
            //Arrange
            var Controller = new ToDoListController();

            //Act 
            result = Controller.GetToDoLists();
        }

        [Test]
        public void ThenAnOKResultIsReturned()
        {
            //assert
            Assert.IsNotNull(result as OkObjectResult);
        }

        [Test]
        public void Then3ItemsAreReturned()
        {
            var toDoListItemses = (result as OkObjectResult).Value as List<toDoListItems>;
            var count = toDoListItemses.Count;

            Assert.AreEqual(3, count);
        }

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

        [TestFixture]
        public class GivenATaskForAToDoListThatDoesNotExsist
        {
            IActionResult result;

            [SetUp]
            public void WhenTryingtoCallATask()
            {
                var Controller = new ToDoListController();

                result = Controller.GetToDoList(50);

            }

            [Test]
            public void ToDoList_Not_Found()
            {
                var Actual = typeof(NotFoundResult);

                Assert.IsInstanceOf<IActionResult>(result);
                Assert.IsInstanceOf(Actual, result);
            }

        }


        [TestFixture]
        public class GivenATaskWhichsNeedsToBeCreated
        {
            IActionResult result;

            [SetUp]
            public void WhenTheTaskDoesNotYetExsist()
            {
                var Controller = new ToDoListController();

                result = Controller.PostToDoList(new toDoListItems
                    {
                        Id = 4,
                        priority = "high",
                        status = "Done",
                        task = "do this test"
                    });
                    
            }

            [Test]
            public void Then_Post_an_Item()
            {
                Assert.IsInstanceOf<CreatedAtRouteResult>(result);
            }
        }

        [TestFixture]
        public class GivenATaskWhichNeedsToBeDeleted
        {
            IActionResult result;

            [SetUp]
            public void WhenTryingtoDeleteATask()
            {
                var Controller = new ToDoListController();

                result = Controller.DeleteList(1);

            }

            [Test]
            public void Then_The_Task_Is_Deleted()
            {
                var Controller = new ToDoListController();
                var Delete = Controller.DeleteList(1);
                Assert.IsInstanceOf<NoContentResult>(Delete);
            }
        }


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
