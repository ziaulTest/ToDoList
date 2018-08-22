using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Models;

namespace ToDoList.Interface
{
    public class ToDoRepository : IToDoRepository
    {
        public List<ToDoListItems> GetListDataStores()
        {
            return ToDoListDataStore.Current.ToDoList;
        }

        public ToDoListItems GetById(int id)
        {
            var toDoListItem = ToDoListDataStore.Current.ToDoList.FirstOrDefault(l => l.Id == id);
            return toDoListItem;
        }

        public void InsertToDoList(ToDoListItems toDoListItems)
        {
            var final = new ToDoListItems()
            {
                Id = toDoListItems.Id,
                priority = toDoListItems.priority,
                status = toDoListItems.status,
                task = toDoListItems.task
            };

           ToDoListDataStore.Current.ToDoList.Add(final);
        }

        public void DeleteById(int id)
        {
            var toDoListItem = ToDoListDataStore.Current.ToDoList.FirstOrDefault(l => l.Id == id);
            ToDoListDataStore.Current.ToDoList.Remove(toDoListItem);
        }

        public void UpdateToDoList(int id,ToDoListItems toDoListItems)
        {
            var toDoListItem = ToDoListDataStore.Current.ToDoList.FirstOrDefault(l => l.Id == id);

                toDoListItem.priority = toDoListItems.priority;
                toDoListItem.task = toDoListItems.task;
        }
    }
}
