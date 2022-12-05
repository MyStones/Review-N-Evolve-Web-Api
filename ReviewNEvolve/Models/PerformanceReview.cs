using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrReview.Models
{
    public class TaskReview
    {
        [Key]
        public int ReviewId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdatedDate { get; set; }
        public int ToDoId { get; set; }
        public virtual ToDo TD { get; set; }

    }

    public class ToDo
    {
        public int ToDoId { get; set; }
        public string Title { get; set; }
        public string description { get; set; }
        public string Category { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime DueDate { get; set; }
    }

   
    

}