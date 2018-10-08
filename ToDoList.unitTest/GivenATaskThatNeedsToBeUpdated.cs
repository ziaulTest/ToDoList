//using System;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Azure.Documents;
//using Microsoft.Azure.Documents.Client;
//using Moq;
//using NUnit.Framework;
//using ToDoList.Controllers;
//using ToDoList.Interface;
//using ToDoList.Models;

//namespace ToDoList.unitTest
//{
//    [TestFixture]
//    public class GivenATaskThatNeedsToBeUpdated
//    {
//        private IActionResult result;
//        private ToDoListController sut;

//        [SetUp]
//        public void SetUp()
//        {
//            var mockRepository = new Mock<IToDoRepository>();
//            var metricsMock = new  Mock<IMetricsTrackerRepository>();

//            //client.As<IDocumentClient>()
//            //    .Setup(foo => foo.CreateDocumentQuery<MyDocumentClass>(It.IsAny<Uri>(), It.IsAny<FeedOptions>()))
//            //    .Returns(data);

//            var old = new ToDoListItems
//            {
//                Id = "1",
//                Priority = "Priority",
//                Task = "Task"
//            };

//          //  mockRepository.Setup(x => x.GetById(It.Is<string>(i => i == "1"))).Returns(old);
//            mockRepository.Setup(x => x.UpdateToDoList(It.Is<string>(i => i == "1"), It.IsAny<PartialToDoItems>()));
//            sut = new ToDoListController(mockRepository.Object, metricsMock.Object);
//        }

//        [Test]
//        public void When_Updating_A_Task_Then_The_Item_Is_Updated()
//        {
//            result = sut.PartiallyUpdate("1", new PartialToDoItems()
//            {
//                Id = "1",
//                Priority = "updated Priority",
//                Task = "updated Task"
//            });

//            Assert.IsInstanceOf<OkResult>(result);
//        }

//        [Test]
//        public void When_Updating_A_Task_That_Does_Not_Exist_Then_No_Update_Is_Performed()
//        {
   
//            result = sut.PartiallyUpdate("10", new PartialToDoItems()
//            {
//                Id = "10",
//                Priority = "updated Priority",
//                Task = "updated Task"
//            });

//            Assert.IsNotEmpty(result.ToString());

//            Assert.IsInstanceOf<NotFoundResult>(result);
//        }
//    }
//}
