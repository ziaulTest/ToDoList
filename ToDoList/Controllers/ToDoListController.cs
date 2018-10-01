using Microsoft.AspNetCore.Mvc;
using ToDoList.Interface;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    [Route("api/ToDoLists")]
    public class ToDoListController : Controller
    {
        private readonly IToDoRepository toDoLisToDoRepository;
        private readonly IMetricsTrackerRepository metricsTracker;
        public ToDoListController(IToDoRepository toDoLisToDoRepository, IMetricsTrackerRepository metricsTracker)
        {
            this.toDoLisToDoRepository = toDoLisToDoRepository;
            this.metricsTracker = metricsTracker;
        }

        [HttpGet]
        public IActionResult GetToDoLists()
        {
            return Ok(toDoLisToDoRepository.GetListDataStores());
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult GetToDoList(int id)
        {

            var listToReturn = toDoLisToDoRepository.GetById(id);

            if (listToReturn != null) return Ok(listToReturn);
            return NotFound();
        }

        [HttpPost("{id}", Name = "Post")]
        public IActionResult PostToDoList([FromBody] ToDoListItems returnList)
        {
           // metricsTracker.TrackTrace("Post Successful");
            metricsTracker.EventTracker("Event post successful");
            
            if (returnList == null)
            {
                
                return BadRequest();
            }
            toDoLisToDoRepository.InsertToDoList(returnList);
            return CreatedAtRoute("Get", returnList);
        }

        [HttpPut("{id}", Name = "Put")]
        public IActionResult PartiallyUpdate(int id, [FromBody] PartialToDoItems returnList)
        {
            if (returnList == null)
            {
                return BadRequest();
            }

            toDoLisToDoRepository.UpdateToDoList(id, returnList);
            return Ok();
        }

        [HttpDelete("{id}", Name = "Delete")]
        public IActionResult DeleteList(int id)
        {
            toDoLisToDoRepository.DeleteById(id);
            return NoContent();
        }
    }
}