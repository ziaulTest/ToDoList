using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ToDoList.Controllers;
using ToDoList.Interface;
using ToDoList.Models;

namespace ToDoList.unitTest
{
    [TestFixture]
    public class GivenATaskWhichNeedsToBeDeleted
    {
        IActionResult _result;
        Mock<IToDoRepository> _todomock;
        private Mock<IMetricsTrackerRepository> metricsMock;
        private ToDoListController sut;
       
        //public GivenATaskWhichNeedsToBeDeleted(Mock<IToDoRepository> todomock, Mock<IMetricsTrackerRepository> metricsMock)
        //{
        //    this._todomock = todomock;
        //    this.metricsMock = metricsMock;
        //}

        [SetUp]
        public void SetUp()
        {
            _todomock = new Mock<IToDoRepository>();
            _todomock.Setup(x => x.InsertToDoList((new ToDoListItems
            {
                Id = 1,
                Priority = "haha",
                Status = "hahaha",
                Task = "hahaha"
            })));
            
            _todomock.Setup(x => x.DeleteById(1));
            
            sut = new ToDoListController(_todomock.Object,metricsMock.Object);
        }

        [Test]
        public void When_Trying_To_Delete_A_Task__Then_The_Task_Is_Deleted()
        {
            _result = sut.DeleteList(1);
            Assert.IsInstanceOf<NoContentResult>(_result);
        }


        [Test]
        public void Then_The_Specified_List_Is_Checked_For_Deletion()
        {
            _result = sut.DeleteList(1);
            _todomock.Verify(r => r.DeleteById(1));
        }
    }
}
