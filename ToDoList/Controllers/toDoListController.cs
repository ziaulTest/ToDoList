using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Interface;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    [Route("api/ToDoLists")]
    public class ToDoListController : Controller
    {
        private readonly IToDoRepository toDoLisToDoRepository;

        public ToDoListController(IToDoRepository toDoLisToDoRepository)
        {
            this.toDoLisToDoRepository = toDoLisToDoRepository;
        }

        [HttpGet]
        public IActionResult GetToDoLists()
        {
          return  Ok(toDoLisToDoRepository.GetListDataStores());
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult GetToDoList(int id)
        {
            var listToReturn = toDoLisToDoRepository.GetById(id);
            // find list 
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

            toDoLisToDoRepository.InsertToDoList(ReturnList);
            return CreatedAtRoute("Get", ReturnList);
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
            toDoLisToDoRepository.DeleteById(id);
            return NoContent();
        }
    }
}