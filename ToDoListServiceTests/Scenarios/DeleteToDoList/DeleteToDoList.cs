using NUnit.Framework;
using TestStack.BDDfy;
using ToDoListServiceTests.Scenarios.Steps;

namespace ToDoListServiceTests.Scenarios.DeleteToDoList
{
    [TestFixture]
    public class DeleteToDoList : ApiSteps
    {
        //public DeleteToDoList(ConfigWebFactory inProcessFactory) : base(inProcessFactory)
        //{
        //}

        [Test]
        public void Given_A_TodoList_Is_Being_Viewed_When_A_User_Tries_To_Delete_A_ToDoList_Then_The_Response_Returned_Is_NoContent()
        {
            this.Given(_ => _.A_Request_To_View_A_Single_ToDoList())
                .And(_ => _.Add_Item_To_A_List())
                .When(_ => _.The_List_Is_Called())
                .And(_=> _.Delete_An_Existing_List())
                .Then(_ => _.Response_Is_returned_With_NoContent())
                .BDDfy();
        }
    }
}

