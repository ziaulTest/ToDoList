using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Interface
{
    public interface IToDoRepository
    {
        List<toDoListItems> GetListDataStores();

        toDoListItems GetById(int id);

        void InsertToDoList(toDoListItems toDoListItems);

        void DeleteById(int id);

        void UpdateToDoList(toDoListItems toDoListItems);
    }
}
