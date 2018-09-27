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
    public class ToDoListInvalid
    {
        [TestFixture]
        public class GivenATaskForAToDoListThatIsInvalid
        {
            IActionResult result;
            Mock<IToDoRepository> todomock;
            private Mock<IMetricsTrackerRepository> metricMock;
            private ToDoListController sut;


            [SetUp]
            public void When_Trying_to_Call_An_Invalid_Task()
            {
                todomock = new Mock<IToDoRepository>();
                todomock.Setup(repository => repository.GetById(50));

                sut = new ToDoListController(todomock.Object, metricMock.Object);

            }

            [Test]
            public void Then_ToDoList_Is_NotFound_Within_The_Data_Store()
            {
                result = sut.GetToDoLists();

                if ((result as OkObjectResult).Value is List<ToDoListItems> toDoListItemses)
                {
                    var count = toDoListItemses.Count;
                    Assert.AreNotEqual(50, count);
                }
            }
        }
    }
}

