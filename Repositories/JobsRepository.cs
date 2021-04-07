using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using gregslist_api.Models;

namespace gregslist_api.Repositories
{
   public class JobsRepository
   {
      public readonly IDbConnection _db;

      public JobsRepository(IDbConnection db)
      {
         _db = db;
      }

      internal IEnumerable<JobListing> Get()
      {
         string sql = "SELECT * FROM jobs;";
         return _db.Query<JobListing>(sql);
      }

      internal JobListing Get(int Id)
      {
         string sql = "SELECT * FROM jobs WHERE id = @Id;";
         return _db.QueryFirstOrDefault<JobListing>(sql, new { Id });
      }

      internal JobListing Create(JobListing newJob)
      {

         string sql = @"
         INSERT INTO jobs
         (title, company, description, rate)
         VALUES
         (@title, @company, @description, @rate);
         SELECT LAST_INSERT_ID();";
         int id = _db.ExecuteScalar<int>(sql, newJob);
         newJob.Id = id;
         return newJob;
      }

      internal JobListing Edit(JobListing jobToEdit)
      {
         //After you go an update it make sure to go and select it again
         string sql = @"
         UPDATE jobs
         SET
            title = @Title,
            company = @Company,
            rate = @Rate,
            description = @Description
         WHERE id = @Id;
         SELECT * FROM jobs WHERE id = @Id;";
         return _db.QueryFirstOrDefault<JobListing>(sql, jobToEdit);
      }

      internal void Delete(int id)
      {
         string sql = "DELETE FROM jobs WHERE id = @id;";
         _db.Execute(sql, new { id });
         return;
      }
   }
}