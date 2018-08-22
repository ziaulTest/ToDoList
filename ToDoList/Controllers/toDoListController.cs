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

            if (listToReturn == null)
            {
                return NotFound();
            }

            return Ok(listToReturn);
        }

        [HttpPost("{id}", Name = "Post")]
        public IActionResult PostToDoList([FromBody] ToDoListItems ReturnList)
        {
            if (ReturnList == null)
            {
                return BadRequest();
            }

            toDoLisToDoRepository.InsertToDoList(ReturnList);
            return CreatedAtRoute("Get", ReturnList);
        }

        [HttpPatch("{id}", Name = "Patch")]
        public IActionResult PartiallyUpdate(int id, [FromBody] ToDoListItems returnList)
        {
           toDoLisToDoRepository.UpdateToDoList( id,returnList);
            
            if (toDoLisToDoRepository == null)
            {
                return BadRequest();
            }

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