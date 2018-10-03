using System.Collections.Generic;

namespace ToDoList.Models
{
    public class ToDoListDataStore
    {
        public static ToDoListDataStore Current { get; set; } = new ToDoListDataStore();

        public List<ToDoListItems> ToDoList { get; set; }
    }
}

