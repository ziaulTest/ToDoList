using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Interface
{
    public interface IToDoRepository
    {
        List<ToDoListItems> GetListDataStores();

        ToDoListItems GetById(int id);

        void InsertToDoList(ToDoListItems toDoListItems);

        void DeleteById(int id);

        void UpdateToDoList(int id,ToDoListItems toDoListItems);
    }
}
