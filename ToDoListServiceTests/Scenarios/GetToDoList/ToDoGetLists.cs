using NUnit.Framework;
using TestStack.BDDfy;
using ToDoListServiceTests.Scenarios.Steps;

namespace ToDoListServiceTests.Scenarios.GetToDoList
{
    [TestFixture]
    public class ToDoGetLists : ApiSteps
    {
        [Test]
        public void Given_A_TodoList_When_Get_Is_Called_Then_The_Response_Is_Ok()
        {
            this.Given(_ => _.A_Request_To_View_ToDoLists())
                .When(_ => _.The_List_Is_Called())
                .Then(_ => _.Response_Is_Returned_With_Status_Ok())
                .BDDfy();
        }
    }
}

