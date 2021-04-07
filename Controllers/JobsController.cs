using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using gregslist_api.Models;
using gregslist_api.Services;

namespace gregslist_api.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class JobsController : ControllerBase
   {
      private readonly JobsService _service;

      public JobsController(JobsService service)
      {
         _service = service;
      }

      [HttpGet]
      public ActionResult<IEnumerable<JobListing>> Get()
      {
         try
         {
            return Ok(_service.Get());
         }
         catch (System.Exception err)
         {
            return BadRequest(err.Message);
         }
      }

      [HttpGet("{id}")]
      public ActionResult<IEnumerable<JobListing>> Get(int id)
      {
         try
         {
            return Ok(_service.Get(id));
         }
         catch (System.Exception err)
         {
            return BadRequest(err.Message);
         }
      }

      //FROMBODY uses a parameterless class constructor to map data over from the request to the model.
      [HttpPost]
      public ActionResult<JobListing> Create([FromBody] JobListing newJob)
      {
         try
         {
            return Ok(_service.Create(newJob));
         }
         catch (System.Exception err)
         {
            return BadRequest(err.Message);
         }
      }

      [HttpPut("{id}")]
      public ActionResult<JobListing> Edit([FromBody] JobListing editedJob, int id)
      {
         try
         {
            editedJob.Id = id;
            return Ok(_service.Edit(editedJob));
         }
         catch (System.Exception err)
         {
            return BadRequest(err.Message);
         }
      }

      [HttpDelete("{id}")]
      public ActionResult<int> DeleteJob(int id)
      {
         try
         {
            return Ok(_service.Delete(id));
         }
         catch (System.Exception err)
         {
            return BadRequest(err.Message);
         }
      }
   }
}