using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using gregslist_api.Models;
using gregslist_api.db;

namespace gregslist_api.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class HousesController : ControllerBase
   {
      [HttpGet]
      public ActionResult<IEnumerable<HouseListing>> Get()
      {
         try
         {
            return Ok(FakeDB.Houses);
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
            FakeDB.Houses.Add(newHouse);
            return Ok(newHouse);
         }
         catch (System.Exception err)
         {
            return BadRequest(err.Message);
         }
      }

      [HttpGet("{houseId}")]
      public ActionResult<HouseListing> GetHouse(string houseId)
      {
         try
         {
            HouseListing houseFound = FakeDB.Houses.Find(c => c.Id == houseId);
            if (houseFound == null)
            {
               throw new System.Exception("House does not exist");
            }
            return Ok(houseFound);
            //NOTE can use exists to see if a list contains something, but it returns a bool so be cautious when returning.
            // bool houseFound = FakeDB.Houses.Exists(c => c.Id == houseId);
            // if (houseFound == false)
            // {
            //   throw new System.Exception("House does not exist");
            // }
         }
         catch (System.Exception err)
         {
            return BadRequest(err.Message);
         }
      }

      [HttpDelete("{id}")]
      public ActionResult<string> DeleteHouse(string id)
      {
         try
         {
            HouseListing houseToRemove = FakeDB.Houses.Find(c => c.Id == id);
            if (FakeDB.Houses.Remove(houseToRemove))
            {
               return Ok("House Delorted");
            }
            else
            {
               throw new System.Exception("This house does not exist.");
            }
         }
         catch (System.Exception err)
         {
            return BadRequest(err.Message);
         }
      }
   }
}