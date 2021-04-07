using System;
using System.ComponentModel.DataAnnotations;
namespace gregslist_api.Models
{
   public class JobListing
   {
      public JobListing(string title, string company, string description, int rate)
      {
         Title = title;
         Company = company;
         Description = description;
         Rate = rate;
      }
      public string Title { get; set; }
      public string Company { get; set; }
      public string Description { get; set; }
      public int Rate { get; set; }
      public string Id { get; private set; } = Guid.NewGuid().ToString();
   }
}