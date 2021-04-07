using System;
using System.Collections.Generic;
using gregslist_api.Models;
using gregslist_api.Repositories;

namespace gregslist_api.Services
{
   public class HousesService
   {
      private readonly HousesRepository _repo;

      public HousesService(HousesRepository repo)
      {
         _repo = repo;
      }

      internal IEnumerable<HouseListing> Get()
      {
         return _repo.Get();
      }

      internal HouseListing Get(int id)
      {
         HouseListing house = _repo.Get(id);
         if (house == null)
         {
            throw new Exception("invalid id");
         }
         return house;
      }

      internal HouseListing Create(HouseListing newHouse)
      {
         return _repo.Create(newHouse);
      }
      internal HouseListing Edit(HouseListing editHouse)
      {
         HouseListing original = Get(editHouse.Id);

         original.Bedrooms = editHouse.Bedrooms;
         original.Bathrooms = editHouse.Bathrooms;
         original.Price = editHouse.Price;

         original.Description = editHouse.Description != null ? editHouse.Description : original.Description;

         return _repo.Edit(original);
      }

      internal HouseListing Delete(int id)
      {
         HouseListing original = Get(id);
         _repo.Delete(id);
         return original;
      }
   }
}