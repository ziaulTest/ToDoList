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
        private readonly IDocumentDbRepository documentDbRepository;
        // readonly DbRepository dbrepo;

        public ToDoListController(IToDoRepository toDoLisToDoRepository, IMetricsTrackerRepository metricsTracker, IDocumentDbRepository documentDbRepository)
        {
            this.toDoLisToDoRepository = toDoLisToDoRepository;
            this.metricsTracker = metricsTracker;
            this.documentDbRepository = documentDbRepository;
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
           metricsTracker.EventTracker("Event post successful");
            
            if (returnList == null)
            {
                
                return BadRequest();
            }

            var a = dbrepo.CreateItemAsync(returnList);
            a.Wait();
            var result = a.Result;

            //toDoLisToDoRepository.InsertToDoList(returnList);
            return CreatedAtRoute("Get", result);
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