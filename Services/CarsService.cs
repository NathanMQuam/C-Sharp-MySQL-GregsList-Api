using System;
using System.Collections.Generic;
using gregslist_api.Models;
using gregslist_api.Repositories;

namespace gregslist_api.Services
{
   public class CarsService
   {
      private readonly CarsRepository _repo;

      public CarsService(CarsRepository repo)
      {
         _repo = repo;
      }

      internal IEnumerable<CarListing> Get()
      {
         return _repo.Get();
      }

      internal CarListing Get(int id)
      {
         CarListing car = _repo.Get(id);
         if (car == null)
         {
            throw new Exception("invalid id");
         }
         return car;
      }

      internal CarListing Create(CarListing newCar)
      {
         return _repo.Create(newCar);
      }
      internal CarListing Edit(CarListing editCar)
      {
         CarListing original = Get(editCar.Id);

         original.Make = editCar.Make;
         original.Model = editCar.Model;

         original.Color = editCar.Color != null ? editCar.Color : original.Color;

         original.Price = editCar.Price;
         original.Mileage = editCar.Mileage;

         // NOTE: if you need to null check a number, you can use the Elvis operator on the type in the class. 
         original.Year = editCar.Year != null ? editCar.Year : original.Year;

         return _repo.Edit(original);
      }

      internal CarListing Delete(int id)
      {
         CarListing original = Get(id);
         _repo.Delete(id);
         return original;
      }
   }
}