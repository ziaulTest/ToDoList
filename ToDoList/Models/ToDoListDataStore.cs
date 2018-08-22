using System.Collections.Generic;

namespace ToDoList.Models
{
    public class ToDoListDataStore
    {
        public static ToDoListDataStore Current { get; set; } = new ToDoListDataStore();

        public List<ToDoListItems> ToDoList { get; set; }

        public ToDoListDataStore()
        {
            ToDoList = new List<ToDoListItems>()
            {
                new ToDoListItems()
                {
                    Id = 1,
                    priority = "high",
                    task = "Wake up at 9am",
                    status = "In Progress",
                },
                new ToDoListItems()
                {
                    Id = 2,
                    priority = "low",
                    task = "sleep at 8pm",
                    status = "In Progress"
                },
                new ToDoListItems()
                {
                    Id = 3,
                    priority = "middle",
                    task = "take the dog for a walk",
                    status = "done"
               }
            };
        }
    }
}
