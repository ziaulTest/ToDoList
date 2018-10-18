using Moq;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;

using ToDoList.Controllers;
using ToDoList.Interface;

using OkObjectResult = Microsoft.AspNetCore.Mvc.OkObjectResult;

namespace ToDoList.unitTest
{
    [TestFixture]
    public class GivenATaskThatNeedsToBeAdded
    {
        private IActionResult result;
        private ToDoListController sut;

        [SetUp]
        public void SetUp()
        {
            var todoMock = new Mock<IToDoRepository>();
            var metricsMock = new Mock<IMetricsTrackerRepository>();

            todoMock.Setup(x => x.GetListDataStores());
            sut = new ToDoListController(todoMock.Object, metricsMock.Object);
        }

        [Test]
        public void When_Get_To_DoLists_Is_Called__Then_An_OK_Result_Is_Returned()
        {
            result = sut.GetToDoLists();
            Assert.IsNotNull(result as OkObjectResult);
        }
        // redundant test for now as i have external datastore, not in memory 

        //[Test]
        //public void When_Get_To_DoLists_Is_Called__Then_3_Items_Are_Returned()
        //{
        //    result = sut.GetToDoLists();
        //    var toDoListItemses = (result as OkObjectResult).Value as List<ToDoListItems>;
        //    var count = toDoListItemses.Count;

        //    Assert.AreEqual(3, count);
        //}
    }
}
