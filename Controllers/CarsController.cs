using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using gregslist_api.Models;
using gregslist_api.Services;

namespace gregslist_api.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class CarsController : ControllerBase
   {
      private readonly CarsService _service;

      public CarsController(CarsService service)
      {
         _service = service;
      }

      [HttpGet]
      public ActionResult<IEnumerable<CarListing>> Get()
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
      public ActionResult<IEnumerable<CarListing>> Get(int id)
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
      public ActionResult<CarListing> Create([FromBody] CarListing newCar)
      {
         try
         {
            return Ok(_service.Create(newCar));
         }
         catch (System.Exception err)
         {
            return BadRequest(err.Message);
         }
      }

      [HttpDelete("{id}")]
      public ActionResult<int> DeleteCar(int id)
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