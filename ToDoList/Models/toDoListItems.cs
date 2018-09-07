using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class ToDoListItems
    {
        public int Id { get; set; }
       // [Range(5,250)]
        public string Task { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
    }
}