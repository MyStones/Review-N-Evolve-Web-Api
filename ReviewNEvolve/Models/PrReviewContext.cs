using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PrReview.Models
{
    public class PrReviewContext : DbContext
    {
        public PrReviewContext() : base("name=ReviewNEvolveConnectionString")
        {
            //Database.SetInitializer<PrReviewContext>(new CreateDatabaseIfNotExists<PrReviewContext>());
            Database.SetInitializer<PrReviewContext>(new PrReviewInitializer());

        }
      
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<TaskReview>  TaskReviews { get; set; }
    }
}