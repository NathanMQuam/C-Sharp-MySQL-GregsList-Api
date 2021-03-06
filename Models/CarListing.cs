using System;
using System.ComponentModel.DataAnnotations;
namespace gregslist_api.Models
{
   public class CarListing
   {
      public CarListing()
      {
      }

      public CarListing(string make, string model, int year, string color, int mileage, int price)
      {
         Make = make;
         Model = model;
         Year = year;
         Color = color;
         Mileage = mileage;
         Price = price;
      }

      [Required]
      [MinLength(3)]
      public string Make { get; set; }
      [Required]
      [MinLength(3)]
      public string Model { get; set; }
      public string Color { get; set; }
      public int? Year { get; set; }
      [Required]
      public int Mileage { get; set; }
      [Required]
      public int Price { get; set; }
      public int Id { get; set; }
   }
}