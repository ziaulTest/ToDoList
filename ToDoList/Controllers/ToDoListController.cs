﻿using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
            var telemetry = new Microsoft.ApplicationInsights.TelemetryClient
            {
                InstrumentationKey = "47b29c20-45be-4c08-a45d-e376bc9a05a9"
            };

            try
            {
                return Ok(toDoLisToDoRepository.GetListDataStores());
            }

            catch (Exception e)
            {
               telemetry.TrackEvent(e.Message); 
                throw;
            }
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult GetToDoList(int id)
        {
            var telemetry = new Microsoft.ApplicationInsights.TelemetryClient
            {
                InstrumentationKey = "47b29c20-45be-4c08-a45d-e376bc9a05a9"
            };

            var listToReturn = toDoLisToDoRepository.GetById(id);

            if (listToReturn != null) return Ok(listToReturn);

            telemetry.TrackEvent("GetByID");
            telemetry.TrackTrace("listToReturn is null");
            telemetry.Flush();
            
            return NotFound();
        }

        [HttpPost("{id}", Name = "Post")]
        public IActionResult PostToDoList([FromBody] ToDoListItems returnList)
        {
            var telemetry = new Microsoft.ApplicationInsights.TelemetryClient
            {
                InstrumentationKey = "47b29c20-45be-4c08-a45d-e376bc9a05a9"
            };

            if (returnList == null)
            {
                return BadRequest();
            }
            // model state change validation
            if (!ModelState.IsValid)
            {
                telemetry.TrackTrace(ModelState.Values.ToString());
                telemetry.Flush();
                return BadRequest();
            }

            toDoLisToDoRepository.InsertToDoList(returnList);
            return CreatedAtRoute("Get", returnList);
        }

        [HttpPut("{id}", Name = "Put")]
        public IActionResult PartiallyUpdate(int id, [FromBody] ToDoListItems returnList)
        {
            var telemetry = new Microsoft.ApplicationInsights.TelemetryClient
            {
                InstrumentationKey = "47b29c20-45be-4c08-a45d-e376bc9a05a9"
            };
            
            if (returnList == null) 
            {
                return BadRequest();
            }
           
            if (returnList.Task.Length < 5)
            {
                telemetry.TrackTrace("Validation failed");
                telemetry.Flush();

                return BadRequest();
            }
            toDoLisToDoRepository.UpdateToDoList(id, returnList);
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