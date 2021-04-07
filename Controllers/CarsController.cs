using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using gregslist_api.Models;
using gregslist_api.db;

namespace gregslist_api.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class CarsController : ControllerBase
   {
      [HttpGet]
      public ActionResult<IEnumerable<CarListing>> Get()
      {
         try
         {
            return Ok(FakeDB.Cars);
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
            FakeDB.Cars.Add(newCar);
            return Ok(newCar);
         }
         catch (System.Exception err)
         {
            return BadRequest(err.Message);
         }
      }

      [HttpGet("{carId}")]
      public ActionResult<CarListing> GetCar(int carId)
      {
         try
         {
            CarListing carFound = FakeDB.Cars.Find(c => c.Id == carId);
            if (carFound == null)
            {
               throw new System.Exception("Car does not exist");
            }
            return Ok(carFound);
            //NOTE can use exists to see if a list contains something, but it returns a bool so be cautious when returning.
            // bool carFound = FakeDB.Cars.Exists(c => c.Id == carId);
            // if (carFound == false)
            // {
            //   throw new System.Exception("Car does not exist");
            // }
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
            CarListing carToRemove = FakeDB.Cars.Find(c => c.Id == id);
            if (FakeDB.Cars.Remove(carToRemove))
            {
               return Ok("Car Delorted");
            }
            else
            {
               throw new System.Exception("This car does not exist.");
            }
         }
         catch (System.Exception err)
         {
            return BadRequest(err.Message);
         }
      }
   }
}