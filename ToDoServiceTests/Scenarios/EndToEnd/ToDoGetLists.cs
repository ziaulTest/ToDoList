using NUnit.Framework;
using TestStack.BDDfy;

namespace ToDoServiceTests.Scenarios.EndToEnd
{
    [TestFixture]
    [Story(AsA = "ToDoList Owner",
        IWant = "To get the list of todo items",
        SoThat = "I  can view my todo list",
        Title = "x-x-x-x-x - GetToDoList - retrieve information from the todo list")]
    public class ToDoGetLists : ApiSteps
    {
        [Test]
        public void Given_A_Todo_List__When_Get_Is_Called__Then_The_Response_Is__OK()
        {
            this.Given(_ => _.ToDoList_Is_Available())
                .When(_ => _.The_List_Is_Called())
                .Then(_ => _.Response_Is_returned_With_Ok())
                .BDDfy();
        }

    }
}
