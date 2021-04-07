using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using gregslist_api.Models;

namespace gregslist_api.Repositories
{
   public class HousesRepository
   {
      public readonly IDbConnection _db;

      public HousesRepository(IDbConnection db)
      {
         _db = db;
      }

      internal IEnumerable<HouseListing> Get()
      {
         string sql = "SELECT * FROM houses;";
         return _db.Query<HouseListing>(sql);
      }

      internal HouseListing Get(int Id)
      {
         string sql = "SELECT * FROM houses WHERE id = @Id;";
         return _db.QueryFirstOrDefault<HouseListing>(sql, new { Id });
      }

      internal HouseListing Create(HouseListing newHouse)
      {

         string sql = @"
         INSERT INTO houses
         (bedrooms, bathrooms, price, address, description)
         VALUES
         (@bedrooms, @bathrooms, @price, @address, @description);
         SELECT LAST_INSERT_ID();";
         int id = _db.ExecuteScalar<int>(sql, newHouse);
         newHouse.Id = id;
         return newHouse;
      }

      internal HouseListing Edit(HouseListing houseToEdit)
      {
         //After you go an update it make sure to go and select it again
         string sql = @"
         UPDATE houses
         SET
            bedrooms = @Bedrooms,
            bathrooms = @Bathrooms,
            price = @Price,
            description = @Description,
            address = @Address
         WHERE id = @Id;
         SELECT * FROM houses WHERE id = @Id;";
         return _db.QueryFirstOrDefault<HouseListing>(sql, houseToEdit);
      }

      internal void Delete(int id)
      {
         string sql = "DELETE FROM houses WHERE id = @id;";
         _db.Execute(sql, new { id });
         return;
      }
   }
}