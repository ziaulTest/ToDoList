using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
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

                var Controller = new ToDoListController(new ToDoRepository());

                result = Controller.DeleteList(1);
            }

            [Test]
            public void Then_The_Task_Is_Deleted()
            {
                Assert.IsInstanceOf<NoContentResult>(result);
            }

            [Test]
            public void Then_The_Specified_List_Is_Checked_For_Deleation()
            {
                var toDoListItems = ToDoListDataStore.Current.ToDoList;
                var IdtoFind = toDoListItems.Find(x => x.Id == 1);

                Assert.IsNotNull(IdtoFind);
            }
        }
    }
}
