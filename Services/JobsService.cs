using System;
using System.Collections.Generic;
using gregslist_api.Models;
using gregslist_api.Repositories;

namespace gregslist_api.Services
{
   public class JobsService
   {
      private readonly JobsRepository _repo;

      public JobsService(JobsRepository repo)
      {
         _repo = repo;
      }

      internal IEnumerable<JobListing> Get()
      {
         return _repo.Get();
      }

      internal JobListing Get(int id)
      {
         JobListing job = _repo.Get(id);
         if (job == null)
         {
            throw new Exception("invalid id");
         }
         return job;
      }

      internal JobListing Create(JobListing newJob)
      {
         return _repo.Create(newJob);
      }
      internal JobListing Edit(JobListing editJob)
      {
         JobListing original = Get(editJob.Id);

         original.Title = editJob.Title;
         original.Company = editJob.Company;

         original.Description = editJob.Description != null ? editJob.Description : original.Description;

         // NOTE: if you need to null check a number, you can use the Elvis operator on the type in the class. 
         original.Rate = editJob.Rate != null ? editJob.Rate : original.Rate;

         return _repo.Edit(original);
      }

      internal JobListing Delete(int id)
      {
         JobListing original = Get(id);
         _repo.Delete(id);
         return original;
      }
   }
}