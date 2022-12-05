using PrReview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Review.Controllers
{
    public class ReviewController : ApiController
    {
        DataAccess Da = new DataAccess();

   
        [HttpGet]
        public IHttpActionResult GetTaskReviewList()
        {
            List<TaskReview> ReviewList = Da.GetAllTaskReview();

            if (ReviewList.Count == 0)

            {
                return NotFound();
            }

            return Ok(ReviewList);

            //return ReviewList;
        }


        [HttpGet]
        public IHttpActionResult GetTaskReviewbytheirID(int ToDoId)
        {
            List<TaskReview> ReviewList = Da.GetTasksbytheirID(ToDoId);
            if (ReviewList.Count == 0)

            {
                return NotFound();
            }

            return Ok(ReviewList);
        }

        [HttpGet]

        public IHttpActionResult GetReviewById(int ReviewID)
        {
            TaskReview T = new TaskReview();
            try
            {
                T = Da.GetReviewById(ReviewID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(T);
        }

  
        [HttpPost]

        public IHttpActionResult PostReview(TaskReview TR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }
            Da.AddReview(TR);
            return Ok();
        }

        public IHttpActionResult Put(TaskReview TR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }
           Da.UpdateReview(TR);
            return Ok();
        }

   

        [HttpDelete]

        public IHttpActionResult DeleteReview(int ReviewID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }
            Da.DeleteReview(ReviewID);
            return Ok();
        }


       
    }
}



































































//To get
//[HttpGet]
//        public List<TaskReview> GetReviewList()
//        {
//            //PopulateReviews();
//            List<TaskReview> ReviewList = Da.GetAllTaskReview();
//            return ReviewList;
//        }
//        public List<TaskReview> GetTasksbytheirID(int ToDoId)
//        {
//            //PopulateReviews();
//            List<TaskReview> ReviewList = Da.GetTasksbytheirID(ToDoId);
//            return ReviewList;
//        }
//        //public HttpResponseMessage GetReviewList()
//        //{
//        //    //PopulateReviews();
//        //    List<TaskReview> ReviewList = Da.GetAllTaskReview();

//        //    return Request.CreateResponse<List<TaskReview>>(HttpStatusCode.OK, ReviewList);

//        //}

//        //[HttpPost]

//        //public 




//        //***this method is to get particular task review table for particular ID***

//        //[HttpGet]
//        //public List<TaskReview> GetTaskReviewList(int id)
//        //{
//        //    TaskReview TR = Da.GetTasksbytheirID(id);
//        //    List<TaskReview> T = Da.GetReviewbyId(TR.ToDoId);
//        //    return T;
//        //}

//        //WEB API

//        //[HttpGet]
//        //public TaskReview EditReview(int id )
//        //{
//        //    TaskReview T1 = new TaskReview();
//        //    T1 = Da.GetTasksbytheirID(id);
//        //    return T1;
//        //}

//        [HttpPut]
//        public int EditReview(TaskReview Tr)
//        {
//            //TaskReview R = new TaskReview {};
//            int result = Da.EditReview(Tr);
//            return result;
//        }

//        //[HttpGet]
//        //public TaskReview DeleteReview(int id)
//        //{
//        //    TaskReview T = Da.GetReviewID(id);
//        //    return T;
//        //}

//        [HttpDelete]
//        public int DeleteStudent(int id)
//        {
//            int iResult = 0;
//            try
//            {
//                iResult = Da.DeleteReview(id);
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//            return iResult;
//        }




//    }
//}
