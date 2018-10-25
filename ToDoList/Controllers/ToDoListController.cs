using Microsoft.AspNetCore.Mvc;
using ToDoList.Interface;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    [Route("api/ToDoLists")]
    public class ToDoListController : Controller
    {
        private readonly IToDoRepository repository;
        private readonly IMetricsTrackerRepository metricsTracker;

        public ToDoListController(IToDoRepository repository, IMetricsTrackerRepository metricsTracker)
        {
            this.repository = repository;
            this.metricsTracker = metricsTracker;
        }

        [HttpGet]
        public IActionResult GetToDoLists()
        {
            return Ok(repository.GetListDataStores());
            
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult GetToDoList(string id)
        {
            var listToReturn = repository.GetById(id);

            if (listToReturn != null) return Ok(listToReturn);
            return NotFound();
        }

        [HttpPost("{id}", Name = "Post")]
        public IActionResult PostToDoList([FromBody] ToDoListItems listToPost)
        {
            if (listToPost == null)
            {           
                return BadRequest();
            }

            repository.InsertToDoList(listToPost);
            metricsTracker.EventTracker("Event post successful");
            return CreatedAtRoute("Get", listToPost);
        }

        [HttpPut("{id}", Name = "Put")]
        public IActionResult PartiallyUpdate(string id, [FromBody] PartialToDoItems partialUpdateList)
        {
            if (partialUpdateList == null)
            {
                return BadRequest();
            }

            repository.UpdateToDoList(id, partialUpdateList);
            return Ok();
        }

        [HttpDelete("{id}", Name = "Delete")]
        public IActionResult DeleteList(string id)
        {
            repository.DeleteById(id);
            return NoContent();
        }
    }
}