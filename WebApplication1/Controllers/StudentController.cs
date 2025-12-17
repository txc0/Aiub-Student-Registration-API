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
    public class StudentController : ApiController
    {
        [HttpGet]
        [Route("api/Students")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var data = StudentService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/Students/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = StudentService.Get(id);
                if (data == null) return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Student not found" });
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/Students")]
        public HttpResponseMessage Create(StudentDTO student)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);

                var data = StudentService.Create(student);
                if (data == null) return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Creation failed" });
                return Request.CreateResponse(HttpStatusCode.Created, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/Students")]
        public HttpResponseMessage Update(StudentDTO student)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);

                var success = StudentService.Update(student);
                if (!success) return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Update failed" });
                return Request.CreateResponse(HttpStatusCode.OK, student);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("api/Students/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var success = StudentService.Delete(id);
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
