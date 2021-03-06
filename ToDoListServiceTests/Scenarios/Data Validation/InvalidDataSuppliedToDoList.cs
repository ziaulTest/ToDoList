﻿using NUnit.Framework;
using TestStack.BDDfy;
using ToDoListServiceTests.Scenarios.Steps;

namespace ToDoListServiceTests.Scenarios.Data_Validation
{
    [TestFixture]
    public class InvalidDataSuppliedToDoList : ApiSteps
    {
        [Test]
        public void Given_A_TodoList_Item_That_Needs_To_Be_Updated_When_A_User_Tries_To_Add_An_invalid_ToDoList_Task_And_Priority_Then_The_Response_is_BadRequest()
        {
            this.Given(_ => _.A_Request_To_View_A_Single_ToDoList())
                .When(_ => _.Invalid_Update_A_ToDoList_Item())
                .Then(_ => _.Response_Is_returned_With_BadRequest())
                .BDDfy();
        }

        [Test]
        public void Given_A_ToDoList_Item_That_Needs_To_Be_Updated_When_A_User_Tries_To_Add_An_Invalid_Item_Task_That_Is_Empty_Then_The_Response_is_BadRequest()
        {
            this.Given(_ => _.A_Request_To_Add_A_Single_ToDoList())
                .When(_ => _.Update_A_ToDoList_Item_that_Is_Invalid())
                .Then(_ => _.Response_Is_returned_With_BadRequest())
                .BDDfy();
        }

        [Test]
        public void Given_A_ToDoList_Item_That_Needs_To_Be_Updated_When_A_User_Tries_To_Add_An_Invalid_Item_Task_That_Contains_One_Character_Then_Response_is_BadRequest()
        {
            this.Given(_ => _.A_Request_To_Add_A_Single_ToDoList())
                .When(_ => _.Update_A_ToDoList_Item_that_Contains_One_character())
                .Then(_ => _.Response_Is_returned_With_BadRequest())
                .BDDfy();
        }

        [Test]
        public void
            Given_A_ToDoList_Item_That_Needs_To_Be_Updated_When_A_User_Tries_To_Add_An_Invalid_Item_Task_That_Contains_250_Character_Then_Response_is_BadRequest()
        {
            this.Given(_ => _.A_Request_To_Add_A_Single_ToDoList())
                .When(_ => _.Update_A_ToDoList_Item_that_Contains_250_character())
                .Then(_ => _.Response_Is_returned_With_Ok())
                .BDDfy();
        }

        [Test]
        public void
            Given_A_ToDoList_Item_That_Needs_To_Be_Updated_When_A_User_Tries_To_Add_An_Invalid_Item_Task_That_Contains_251_Character_Then_Response_is_BadRequest()
        {
            this.Given(_ => _.A_Request_To_Add_A_Single_ToDoList())
                .When(_ => _.Update_A_ToDoList_Item_that_Contains_251_character())
                .Then(_ => _.Response_Is_returned_With_BadRequest())
                .BDDfy();
        }
    }
}

