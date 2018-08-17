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
using ToDoList.Interface;
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
            var Controller = new ToDoListController(new ToDoRepository());
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
    }
}
