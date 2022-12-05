using PrReview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Review.Controllers
{
    public class ToDoController : ApiController
    {
        DataAccess Da = new DataAccess();



        [HttpGet]
        public IHttpActionResult GetTaskList()
        {
            List<ToDo> ToDoList = Da.GetAllTasks();

            if (ToDoList.Count == 0)

            {
                return NotFound();
            }

            return Ok(ToDoList);
        }
     
    }
}
