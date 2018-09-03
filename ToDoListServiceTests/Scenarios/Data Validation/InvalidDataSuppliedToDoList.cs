using NUnit.Framework;
using TestStack.BDDfy;
using ToDoListServiceTests.Scenarios.Steps;

namespace ToDoListServiceTests.Scenarios.Data_Validation
{
    [TestFixture]
    public class InvalidDataSuppliedToDoList : ApiSteps
    {
        [Test]
        public void Given_A_TodoList_Item_That_Needs_ToBe_Updated_When_A_User_Tries_To_Add_An_invalid_ToDoList_Task_And_Priority_Then_The_Response_is_BadRequest()
        {
            this.Given(_ => _.A_Request_To_View_A_ToDoList())
                .When(_=> _.Invalid_Update_A_ToDoList_Item())
                .Then(_ => _.Response_Is_returned_With_BadRequest())
                .BDDfy();
        }
    }
}

