using System;
using System.ComponentModel.DataAnnotations;
namespace gregslist_api.Models
{
   public class JobListing
   {
      public JobListing()
      {
      }

      public JobListing(string title, string company, string description, int rate)
      {
         Title = title;
         Company = company;
         Description = description;
         Rate = rate;
      }
      [Required]
      public string Title { get; set; }
      [Required]
      public string Company { get; set; }
      public string Description { get; set; }
      public int? Rate { get; set; }
      public int Id { get; set; }
   }
}