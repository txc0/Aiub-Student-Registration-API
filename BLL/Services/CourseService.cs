using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CourseService
    {
        public static List<CourseDTO> Get()
        {
            var data = DataAccessFactory.CourseData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Course, CourseDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<CourseDTO>>(data);
            return mapped;
        }
        public static CourseDTO Get(int id)
        {
            var data = DataAccessFactory.CourseData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Course, CourseDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<CourseDTO>(data);
            return mapped;
        }
        public static CourseDTO Create(CourseDTO dto)
        {
            var cfg = new MapperConfiguration(c => c.CreateMap<CourseDTO, Course>());
            var mapper = new Mapper(cfg);
            var course = mapper.Map<Course>(dto);
            var created = DataAccessFactory.CourseData().Create(course);
            if (!created) return null;
            return Get(course.CourseId);
        }

        public static bool Update(CourseDTO dto)
        {
            var cfg = new MapperConfiguration(c => c.CreateMap<CourseDTO, Course>());
            var mapper = new Mapper(cfg);
            var course = mapper.Map<Course>(dto);
            return DataAccessFactory.CourseData().Update(course);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.CourseData().Delete(id);
        }

    }
}
