using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using gregslist_api.Models;
using gregslist_api.Services;

namespace gregslist_api.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class HousesController : ControllerBase
   {
      private readonly HousesService _service;

      public HousesController(HousesService service)
      {
         _service = service;
      }

      [HttpGet]
      public ActionResult<IEnumerable<HouseListing>> Get()
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
      public ActionResult<IEnumerable<HouseListing>> Get(int id)
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
      public ActionResult<HouseListing> Create([FromBody] HouseListing newHouse)
      {
         try
         {
            return Ok(_service.Create(newHouse));
         }
         catch (System.Exception err)
         {
            return BadRequest(err.Message);
         }
      }

      [HttpPut("{id}")]
      public ActionResult<HouseListing> Edit([FromBody] HouseListing editedHouse, int id)
      {
         try
         {
            editedHouse.Id = id;
            return Ok(_service.Edit(editedHouse));
         }
         catch (System.Exception err)
         {
            return BadRequest(err.Message);
         }
      }

      [HttpDelete("{id}")]
      public ActionResult<int> DeleteHouse(int id)
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