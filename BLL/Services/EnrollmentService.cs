using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class EnrollmentService
    {
       
        public static List<EnrollmentDTO> Get()
        {
            var data = DataAccessFactory.EnrollmentData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Enrollment, EnrollmentDTO>();
            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<EnrollmentDTO>>(data);
        }

        public static EnrollmentDTO Get(int id)
        {
            var data = DataAccessFactory.EnrollmentData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Enrollment, EnrollmentDTO>();
            });
            var mapper = new Mapper(cfg);
            return mapper.Map<EnrollmentDTO>(data);
        }

        
        public static bool Create(EnrollmentDTO dto)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<EnrollmentDTO, Enrollment>();
            });
            var mapper = new Mapper(cfg);
            var enrollment = mapper.Map<Enrollment>(dto);
            return DataAccessFactory.EnrollmentData().Create(enrollment);
        }

       
        public static bool Update(EnrollmentDTO dto)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<EnrollmentDTO, Enrollment>();
            });
            var mapper = new Mapper(cfg);
            var enrollment = mapper.Map<Enrollment>(dto);
            return DataAccessFactory.EnrollmentData().Update(enrollment);
        }

    
        public static bool Delete(int id)
        {
            return DataAccessFactory.EnrollmentData().Delete(id);
        }

        
        public static bool EnrollStudent(int studentId, int courseId)
        {
            var courseRepo = DataAccessFactory.CourseData();
            var enrollmentRepo = DataAccessFactory.EnrollmentData();

            var course = courseRepo.Read(courseId);
            if (course == null) return false;

            if (course.EnrolledCount >= course.MaxSeats)
                return false;

            var alreadyEnrolled = enrollmentRepo.Read().Any(e => e.StudentId == studentId && e.CourseId == courseId);
            if (alreadyEnrolled)
                return false;

            var enrollment = new Enrollment
            {
                StudentId = studentId,
                CourseId = courseId
            };

            var created = enrollmentRepo.Create(enrollment);

            if (created)
            {
                course.EnrolledCount += 1;
                courseRepo.Update(course);
                return true;
            }
            return false;
        }

       
        public static bool UnenrollStudent(int studentId, int courseId)
        {
            var enrollmentRepo = DataAccessFactory.EnrollmentData();
            var courseRepo = DataAccessFactory.CourseData();

            var enrollment = enrollmentRepo.Read().FirstOrDefault(e => e.StudentId == studentId && e.CourseId == courseId);
            if (enrollment == null)
                return false;

            var deleted = enrollmentRepo.Delete(enrollment.EnrollmentId);

            if (deleted)
            {
                var course = courseRepo.Read(courseId);
                if (course != null && course.EnrolledCount > 0)
                {
                    course.EnrolledCount -= 1;
                    courseRepo.Update(course);
                }
                return true;
            }
            return false;
        }
    }
}
