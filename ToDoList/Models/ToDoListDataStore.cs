using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace toDoList.Api.Models
{
    public class ToDoListDataStore
    {
        public static ToDoListDataStore Current { get; set; } = new ToDoListDataStore();

        public List<toDoListDto> ToDoList { get; set; }

        public ToDoListDataStore()
        {
            ToDoList = new List<toDoListDto>()
            {
                new toDoListDto()
                {
                    Id = 1,
                    priority = "high",
                    task = "Wake up at 9am",
                    status = "In Progress",
                },
                new toDoListDto()
                {
                    Id = 2,
                    priority = "low",
                    task = "sleep at 8pm",
                    status = "In Progress"
                },
                new toDoListDto()
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
