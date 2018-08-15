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
            
           Assert.AreEqual(3,count);
        }

        [Test]
        public void Be_able_to_Get_an_Item()
        {  
            var Controller = new ToDoListController();

            var Getone = Controller.GetToDoList(1);
            var okObjectResult = Getone as OkObjectResult;
           
            Assert.IsNotNull(okObjectResult.Value);
        }

        [Test]
        public void ToDoList_Not_Found()
        {
            var Controller = new ToDoListController();

            var actionResult = Controller.GetToDoList(50);
            var Actual = typeof(NotFoundResult);

            Assert.IsInstanceOf<IActionResult>(actionResult);
            Assert.IsInstanceOf(Actual,actionResult);
        }

        [Test]
        public void Be_able_to_Post_an_Item()
        {
            var Controller = new ToDoListController();
            var Post = Controller.PostToDoList(new toDoListItems
            {
                Id = 4,
                priority = "high",
                status = "Done",
                task = "do this test"
            });

           Assert.IsInstanceOf<CreatedAtRouteResult>(Post);
        }

        [Test]
        public void Be_able_to_Patch_an_Item()
        {
            var controller = new ToDoListController();

            var todolist = new toDoListItems
            {
                    Id = 1,
                    priority = "updated priority",
                    task =  "updated task"
            };
            var res = controller.PartiallyUpdate(todolist.Id, todolist);
          
            Assert.IsNotNull(res);

        }

        [Test]
        public void Be_able_to_Delete_an_Item()
        {
            var Controller = new ToDoListController();
            var Delete = Controller.DeleteList(1);
            Assert.IsInstanceOf<NoContentResult>(Delete);
        }
    }

}
