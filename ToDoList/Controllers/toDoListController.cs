using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    [Route("api/ToDoLists")]
    public class ToDoListController : Controller
    {

        [HttpGet]
        public IActionResult GetToDoLists()
        {
            return Ok(ToDoListDataStore.Current.ToDoList);
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult GetToDoList(int id)
        {
            // find list 
            var listToReturn = ToDoListDataStore.Current.ToDoList.FirstOrDefault(l => l.Id == id);
            if (listToReturn == null)
            {
                return NotFound();
            }

            return Ok(listToReturn);
            
        }

        [HttpPost("{id}", Name = "Post")]
        public IActionResult PostToDoList([FromBody] toDoListItems ReturnList)
        {
            if (ReturnList == null)
            {
                return BadRequest();
            }

            var final = new toDoListItems()
            {
                Id = ReturnList.Id,
                priority = ReturnList.priority,
                status = ReturnList.status,
                task = ReturnList.task
            };

            ToDoListDataStore.Current.ToDoList.Add(final);
            return CreatedAtRoute("Get", final);
        }

        [HttpPatch("{id}", Name = "Patch")]
        public IActionResult PartiallyUpdate(int id, [FromBody] toDoListItems returnList)
        {
            var toDoListItem = ToDoListDataStore.Current.ToDoList.FirstOrDefault(l => l.Id == id);
            
            if (toDoListItem == null)
            {
                return BadRequest();
            }

            toDoListItem.task = returnList.task;
            toDoListItem.priority = returnList.priority;
            
            return Ok();
        }

        [HttpDelete("{id}" , Name = "Delete")]
        public IActionResult DeleteList(int id)
        {
            var toDoListItem = ToDoListDataStore.Current.ToDoList.FirstOrDefault(l => l.Id == id);

            if (toDoListItem == null)
            {
                return NotFound();
            }

            ToDoListDataStore.Current.ToDoList.Remove(toDoListItem);

            return NoContent();

        }
    }
}