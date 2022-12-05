using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PrReview.Models
{
    public class PrReviewInitializer : DropCreateDatabaseIfModelChanges<PrReviewContext>
    {
        protected override void Seed(PrReviewContext context)
        {
            var ToDo = new List<ToDo>
            {
                new ToDo {Title="PPT",description="Create a PPT on dotNet",Category="One Week",AssignedDate=DateTime.Now,DueDate=DateTime.Parse("2022-11-03")},
                new ToDo {Title="Excel Sheet",description="Create a Excel Sheet of ongoing project",Category="3 days",AssignedDate=DateTime.Now,DueDate=DateTime.Parse("2022-11-15")},
                new ToDo {Title="PPT",description="Create a PPT on dotNet",Category="One Week",AssignedDate=DateTime.Now,DueDate=DateTime.Parse("2022-11-03")},
                 new ToDo {Title="unit test",description="write a unit test case ",Category="3 days",AssignedDate=DateTime.Now,DueDate=DateTime.Parse("2022-11-16")},
                  new ToDo {Title="functionality",description="Check the functionality",Category="One day",AssignedDate=DateTime.Now,DueDate=DateTime.Parse("2022-11-15")},
                   new ToDo {Title="Book meeting room",description="book meeting room for tommarow 4 p.m",Category="One day",AssignedDate=DateTime.Now,DueDate=DateTime.Parse("2022-11-14")},
            };         
        ToDo.ForEach(g => context.ToDos.Add(g));
        context.SaveChanges();


            var TaskReview = new List<TaskReview>
            {
                new TaskReview{ToDoId=1},
                new TaskReview{ToDoId=2},
                new TaskReview{ToDoId=3},
                new TaskReview{ToDoId=4},
                new TaskReview{ToDoId=4},
                new TaskReview{ToDoId=6}


            };
            TaskReview.ForEach(g => context.TaskReviews.Add(g));
            context.SaveChanges();
        }
    }
}