using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Documents;
using Moq;
using NUnit.Framework;
using ToDoList.Controllers;
using ToDoList.Interface;
using ToDoList.Models;

namespace ToDoList.unitTest
{
    public class GivenATaskThatNeedsASingleItem
    {

        [TestFixture]
        public class GivenATaskForAToDoList
        {
            IActionResult _result;
            Mock<IToDoRepository> _todoMock;
            private ToDoListController sut;

            [SetUp]
            public void SetUp()
            {
                var todoMock = new Mock<IToDoRepository>();
                Mock<IMetricsTrackerRepository> metricsMock = new Mock<IMetricsTrackerRepository>();

                todoMock.Setup(x => x.GetById("1")).Returns(Task.FromResult(new ToDoListItems
                {
                    Id = "1",
                    Priority = "High",
                    Status = "Complete",
                    Task = "Test this Moq"
                }));

                sut = new ToDoListController(todoMock.Object, metricsMock.Object);
                _result = sut.GetToDoList("1");
            }

            [Test]
            public void When_Calling_A_Single_ToDoList__Then_A_Single_Item_Is_Returned()
            {
                var okObjectResult = _result as OkObjectResult;
                Assert.IsNotNull(okObjectResult.Value);
            }

            [Test]
            public void When_Calling_A_Single_ToDoList__Then__The_Values_Are_Checked()
            {
                _result = sut.GetToDoList("1");
                Assert.IsInstanceOf<OkObjectResult>(_result);
            }
        }
    }
}
