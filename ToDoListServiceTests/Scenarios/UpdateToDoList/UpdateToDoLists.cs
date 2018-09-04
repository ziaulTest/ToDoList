using NUnit.Framework;
using TestStack.BDDfy;
using ToDoListServiceTests.Scenarios.Steps;

namespace ToDoListServiceTests.Scenarios.UpdateToDoList
{
    [TestFixture]
    public class UpdateToDoLists : ApiSteps
    {
        [Test]
        public void
            Given_A_TodoList_Item_That_Needs_ToBe_Updated_When_A_User_Tries_To_Adds_A_ToDoList_Task_And_Priority_Then_The_Response_is_Ok()
        {
            this.Given(_ => _.A_Request_To_View_A_Single_ToDoList())
                .When(_ => _.Update_A_ToDoList_Item())
                .And(_ => _.The_List_Is_Called())
                .Then(_ => _.Response_Is_returned_With_Ok())
                .BDDfy();
        }
    }
}

