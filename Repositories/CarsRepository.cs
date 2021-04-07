using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using gregslist_api.Models;

namespace gregslist_api.Repositories
{
   public class CarsRepository
   {
      public readonly IDbConnection _db;

      public CarsRepository(IDbConnection db)
      {
         _db = db;
      }

      internal IEnumerable<CarListing> Get()
      {
         string sql = "SELECT * FROM cars;";
         return _db.Query<CarListing>(sql);
      }

      internal CarListing Get(int Id)
      {
         string sql = "SELECT * FROM cars WHERE id = @Id;";
         return _db.QueryFirstOrDefault<CarListing>(sql, new { Id });
      }

      internal CarListing Create(CarListing newCar)
      {

         string sql = @"
         INSERT INTO cars
         (make, model, color, price, mileage, year)
         VALUES
         (@Make, @Model, @Color, @Price, @Mileage, @Year);
         SELECT LAST_INSERT_ID();";
         int id = _db.ExecuteScalar<int>(sql, newCar);
         newCar.Id = id;
         return newCar;
      }

      internal CarListing Edit(CarListing carToEdit)
      {
         //After you go an update it make sure to go and select it again
         string sql = @"
         UPDATE cars
         SET
            make = @Make,
            model = @Model,
            price = @Price,
            year = @Year,
            mileage = @Mileage
         WHERE id = @Id;
         SELECT * FROM cars WHERE id = @Id;";
         return _db.QueryFirstOrDefault<CarListing>(sql, carToEdit);
      }

      internal void Delete(int id)
      {
         string sql = "DELETE FROM cars WHERE id = @id;";
         _db.Execute(sql, new { id });
         return;
      }
   }
}