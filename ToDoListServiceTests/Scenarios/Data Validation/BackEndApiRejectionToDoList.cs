using NUnit.Framework;
using TestStack.BDDfy;
using ToDoListServiceTests.Scenarios.Steps;
using ToDoListServiceTests.WebAppFactory;

namespace ToDoListServiceTests.Scenarios.Data_Validation
{
    [TestFixture]

    public class BackEndApiRejectionToDoList : ApiSteps
    {
        //public BackEndApiRejectionToDoList(ConfigWebFactory inProcessFactory) : base(inProcessFactory)
        //{
        //}

        [Test]
        public void Given_A_TodoList_Item_That_Needs_To_Be_Updated_When_A_User_Tries_To_Add_An_invalid_ToDoList_Item_Then_The_Response_is_NotFound()
        {
            this.Given(_ => _.A_Request_To_View_ToDoLists())
                .When(_ => _.Invalid_Update_A_ToDoList_Item())
                .Then(_ => _.Response_Is_returned_With_NotFound())
                .BDDfy();
        }


    }
}
