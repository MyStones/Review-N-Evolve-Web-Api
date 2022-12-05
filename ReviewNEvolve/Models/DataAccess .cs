using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PrReview.Models
{
    [NotMapped]
    public class ToDoAndReview
    {
        public int ReviewId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public int ToDoId { get; set; }
        public string Title { get; set; }
        public string description { get; set; }
        public string Category { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime DueDate { get; set; }
    }
    public class DataAccess
    {     
        public List<ToDo> GetAllTasks()
        {
            List<ToDo> ToDoList = new List<ToDo>();
            try
            {
                using (var ctx = new PrReviewContext())
                {
                    ToDoList = ctx.ToDos.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ToDoList;

        }
        public List<TaskReview> GetAllTaskReview()
        {
            List<TaskReview> TRList = new List<TaskReview>();
            try
            {
                using (var ctx = new PrReviewContext())
                {
                    TRList = ctx.TaskReviews.ToList();

                    //lazy loading

                    foreach (TaskReview t in TRList)
                    {

                        ctx.Entry(t).Reference(s => s.TD).Load();
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return TRList;

        }
      
        public TaskReview GetReviewById(int ReviewID)
        {
            TaskReview T = new TaskReview();
            try
            {
                
                using (var ctx = new PrReviewContext())
                {
                    T = ctx.TaskReviews.Where(s => s.ReviewId == ReviewID).Single();
                    ctx.Entry(T).Reference(s => s.TD).Load();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return T;
        }

       

        public List<TaskReview> GetTasksbytheirID(int ToDoId)
        {
            List<TaskReview> T = new List<TaskReview>();
            try
            {
                using (var ctx = new PrReviewContext())
                {
                    T = ctx.TaskReviews.Where(s => s.ToDoId == ToDoId).ToList();
                    foreach (var t in T)
                    {
                        ctx.Entry(t).Reference(s => s.TD).Load();
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return T;
        }

        public int AddReview(TaskReview TR)
        {
            int ratingAdded = 0;
            try
            {
                using (var ctx = new PrReviewContext())
                {
                    TR.CreateDate = DateTime.Now;
                    TR.UpdatedDate = DateTime.Now;


                    ctx.TaskReviews.Add(TR);

                    ratingAdded = ctx.SaveChanges();

                    return ratingAdded;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        public int UpdateReview(TaskReview T)
        {
            int recordsUpdated = 0;
            if (T.ReviewId > 0)
            {
                try
                {
                    using (var ctx = new PrReviewContext())
                    {
                        TaskReview t1 = ctx.TaskReviews.Where(s => s.ReviewId == T.ReviewId).Single();
                        if (t1 != null)
                        {
                            t1.Rating = T.Rating;
                            t1.Comment = T.Comment;
                            t1.UpdatedDate = DateTime.Now;
                            ctx.Entry(t1).State = System.Data.Entity.EntityState.Modified;
                        }
                       
                        recordsUpdated = ctx.SaveChanges();
                    }
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return recordsUpdated;
        }

        public int DeleteReview(int ReviewId)

        {
            int recordsDeleted = 0;
            try
            {
                using (var ctx = new PrReviewContext())
                {
                    TaskReview r = ctx.TaskReviews.Where(s => s.ReviewId == ReviewId).Single();
                    if (r != null)
                    {
                        ctx.TaskReviews.Remove(r);
                        recordsDeleted = ctx.SaveChanges();
                    }


                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return recordsDeleted;
        }

        public int EditReview(TaskReview TR)
        {
            int ratingAdded = 0;

            try
            {


                using (var ctx = new PrReviewContext())
                {


                    TaskReview T = ctx.TaskReviews.Where(x => x.ReviewId == TR.ReviewId).Single();

                    if (T != null)
                    {
                        T.Rating = TR.Rating;
                        T.Comment = TR.Comment;

                        ctx.Entry(T).State = System.Data.Entity.EntityState.Modified;

                    }
                    ratingAdded = ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ratingAdded;

        }



    }
}

