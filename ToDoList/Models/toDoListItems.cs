using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class ToDoListItems
    {
        public int Id { get; set; }
       // [Range(5,250)] come back later 
        public string Task { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
    }
}