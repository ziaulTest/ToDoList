using NUnit.Framework;
using TestStack.BDDfy;
using ToDoListServiceTests.Scenarios.Steps;

namespace ToDoListServiceTests.Scenarios.AddToDoList
{
    [TestFixture]
    public class AddToDoList : ApiSteps
    {
        [Test]
        public void Given_A_TodoList_Is_Being_Viewed_When_A_User_Tries_To_Adds_A_ToDoList_Task_And_They_Can_Enter_A_Task_And_Priority_Then_The_Response_is_Created()
        {
            this.Given(_ => _.A_Request_To_View_A_ToDoList())
                .When(_ => _.The_List_Is_Called())
                .And(_ => _.Add_Item_To_An_existing_List())
                .Then(_ => _.Response_Is_Returned_With_Status_Ok())
                .BDDfy();
        }
    }
}

