using System;
using System.ComponentModel.DataAnnotations;
namespace gregslist_api.Models
{
   public class HouseListing
   {
      public HouseListing(int bedrooms, int bathrooms, int price, string address, string description)
      {
         Bedrooms = bedrooms;
         Bathrooms = bathrooms;
         Price = price;
         Address = address;
         Description = description;
      }
      [Required]
      public int Bedrooms { get; set; }
      [Required]
      public int Bathrooms { get; set; }
      [Required]
      public int Price { get; set; }
      [Required]
      public string Address { get; set; }
      public string Description { get; set; }
      public string Id { get; private set; } = Guid.NewGuid().ToString();
   }
}