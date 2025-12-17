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
    public class EnrollmentController : ApiController
    {
        [HttpGet]
        [Route("api/Enrollments")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var data = EnrollmentService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/Enrollments/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = EnrollmentService.Get(id);
                if (data == null) return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Enrollment not found" });
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/Enrollments")]
        public HttpResponseMessage Create(EnrollmentDTO enrollment)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);

                var data = EnrollmentService.Create(enrollment);
                if (!data) return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Creation failed" });
                return Request.CreateResponse(HttpStatusCode.Created, new { Message = "Enrollment created" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/Enrollments")]
        public HttpResponseMessage Update(EnrollmentDTO enrollment)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);

                var success = EnrollmentService.Update(enrollment);
                if (!success) return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Update failed" });
                return Request.CreateResponse(HttpStatusCode.OK, enrollment);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("api/Enrollments/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var success = EnrollmentService.Delete(id);
                if (!success) return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Delete failed" });
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Deleted" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        
        [HttpPost]
        [Route("api/Enrollments/Enroll")]
        public HttpResponseMessage Enroll([FromBody] EnrollmentDTO enrollment)
        {
            try
            {
                var result = EnrollmentService.EnrollStudent(enrollment.StudentId, enrollment.CourseId);
                if (!result) return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Enrollment failed: course may be full, or student is already enrolled" });
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Enrolled successfully" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
