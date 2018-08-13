using System;
using Moq;
using NUnit.Framework;
using System.Web.Http.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using toDoList.Api.Controllers;


namespace ToDoList.unitTest
{
    [TestFixture]
    public class ToDoListTests
    {
        [Test]
        public void Be_able_to_return_all_items()
        {
        var Controller = new ToDoListController();
        var GetAll = Controller.GetToDoLists(); 
        
        var OkResult = GetAll as OkObjectResult;
      

        Assert.IsNotNull(OkResult);
        Assert.AreEqual(200,OkResult.StatusCode);
       
        }

        public void Be_able_to_Delete_an_Item()
        {
            var Controller = new ToDoListController();
 
        }

    }


}
