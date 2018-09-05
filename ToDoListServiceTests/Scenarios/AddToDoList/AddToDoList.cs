using NUnit.Framework;
using TestStack.BDDfy;
using ToDoListServiceTests.Scenarios.Steps;
using ToDoListServiceTests.WebAppFactory;

namespace ToDoListServiceTests.Scenarios.AddToDoList
{
    [TestFixture]
    public class AddToDoList : ApiSteps
    {
        public AddToDoList(ConfigWebFactory inProcessFactory) : base(inProcessFactory)
        {
        }

        [Test]
        public void Given_A_TodoList_Is_Being_Viewed_When_A_User_Tries_To_Adds_A_ToDoList_Task_And_They_Can_Enter_A_Task_And_Priority_Then_The_Response_is_Created()
        {
            this.Given(_ => _.A_Request_To_Add_A_Single_ToDoList())
                .When(_ => _.Add_Item_To_A_List())
                .Then(_ => _.Response_Is_returned_With_Created())
                .BDDfy();
        }
    }
}

