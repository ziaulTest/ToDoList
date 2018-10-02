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
                    id = "1",
                    Priority = "high",
                    Task = "Wake up at 9am",
                    Status = "In Progress",
                },
                new ToDoListItems()
                {
                    id = "2",
                    Priority = "low",
                    Task = "sleep at 8pm",
                    Status = "In Progress"
                },
                new ToDoListItems()
                {
                    id = "3",
                    Priority = "middle",
                    Task = "take the dog for a walk",
                    Status = "done"
               }
            };
        }
    }
}
