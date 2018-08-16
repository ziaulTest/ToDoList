using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Models;

namespace ToDoList.Interface
{
    public class ToDoRepository : IToDoRepository
    {
        public List<toDoListItems> GetListDataStores()
        {
            return ToDoListDataStore.Current.ToDoList;
        }

        public toDoListItems GetById(int id)
        {
            var toDoListItem = ToDoListDataStore.Current.ToDoList.FirstOrDefault(l => l.Id == id);
            return toDoListItem;
        }

        public void InsertToDoList(toDoListItems toDoListItems)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            var toDoListItem = ToDoListDataStore.Current.ToDoList.FirstOrDefault(l => l.Id == id);
            ToDoListDataStore.Current.ToDoList.Remove(toDoListItem);
        }

        public void UpdateToDoList(toDoListItems toDoListItems)
        {
            throw new NotImplementedException();
        }
    }
}
