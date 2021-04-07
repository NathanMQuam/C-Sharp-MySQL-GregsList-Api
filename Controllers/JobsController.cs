using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using gregslist_api.Models;
using gregslist_api.db;

namespace gregslist_api.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class JobsController : ControllerBase
   {
      [HttpGet]
      public ActionResult<IEnumerable<JobListing>> Get()
      {
         try
         {
            return Ok(FakeDB.Jobs);
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
            FakeDB.Jobs.Add(newJob);
            return Ok(newJob);
         }
         catch (System.Exception err)
         {
            return BadRequest(err.Message);
         }
      }

      [HttpGet("{jobId}")]
      public ActionResult<JobListing> GetJob(string jobId)
      {
         try
         {
            JobListing jobFound = FakeDB.Jobs.Find(c => c.Id == jobId);
            if (jobFound == null)
            {
               throw new System.Exception("Job does not exist");
            }
            return Ok(jobFound);
            //NOTE can use exists to see if a list contains something, but it returns a bool so be cautious when returning.
            // bool jobFound = FakeDB.Jobs.Exists(c => c.Id == jobId);
            // if (jobFound == false)
            // {
            //   throw new System.Exception("Job does not exist");
            // }
         }
         catch (System.Exception err)
         {
            return BadRequest(err.Message);
         }
      }

      [HttpDelete("{id}")]
      public ActionResult<string> DeleteJob(string id)
      {
         try
         {
            JobListing jobToRemove = FakeDB.Jobs.Find(c => c.Id == id);
            if (FakeDB.Jobs.Remove(jobToRemove))
            {
               return Ok("Job Delorted");
            }
            else
            {
               throw new System.Exception("This job does not exist.");
            }
         }
         catch (System.Exception err)
         {
            return BadRequest(err.Message);
         }
      }

   }
}