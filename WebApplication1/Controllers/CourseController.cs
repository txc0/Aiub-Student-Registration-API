using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class CourseController : ApiController
    {
        
        [HttpGet]
        [Route("api/Courses")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var data = CourseService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        
        [HttpGet]
        [Route("api/Courses/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = CourseService.Get(id);
                if (data == null) return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Course not found" });
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

       
        [HttpPost]
        [Route("api/Courses")]
        public HttpResponseMessage Create(CourseDTO course)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);

                var data = CourseService.Create(course);
                if (data == null) return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Creation failed" });
                return Request.CreateResponse(HttpStatusCode.Created, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        
        [HttpPut]
        [Route("api/Courses")]
        public HttpResponseMessage Update(CourseDTO course)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);

                var success = CourseService.Update(course);
                if (!success) return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Update failed" });
                return Request.CreateResponse(HttpStatusCode.OK, course);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

      
        [HttpDelete]
        [Route("api/Courses/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var success = CourseService.Delete(id);
                if (!success) return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Delete failed" });
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Deleted" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
