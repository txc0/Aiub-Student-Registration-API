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
    public class StudentService
    {
        
        public static List<StudentDTO> Get()
        {
            var data = DataAccessFactory.StudentData().Read();
            var cfg = new MapperConfiguration(c => c.CreateMap<Student, StudentDTO>());
            var mapper = new Mapper(cfg);
            return mapper.Map<List<StudentDTO>>(data);
        }

        // GET student by id
        public static StudentDTO Get(int id)
        {
            var data = DataAccessFactory.StudentData().Read(id);
            var cfg = new MapperConfiguration(c => c.CreateMap<Student, StudentDTO>());
            var mapper = new Mapper(cfg);
            return mapper.Map<StudentDTO>(data);
        }

        
        public static StudentDTO Create(StudentDTO dto)
        {
            var cfg = new MapperConfiguration(c => c.CreateMap<StudentDTO, Student>());
            var mapper = new Mapper(cfg);
            var student = mapper.Map<Student>(dto);
            var created = DataAccessFactory.StudentData().Create(student);
            if (created == null) return null;
            var cfg2 = new MapperConfiguration(c => c.CreateMap<Student, StudentDTO>());
            var mapper2 = new Mapper(cfg2);
            return mapper2.Map<StudentDTO>(created);
        }

        
        public static bool Update(StudentDTO dto)
        {
            var cfg = new MapperConfiguration(c => c.CreateMap<StudentDTO, Student>());
            var mapper = new Mapper(cfg);
            var student = mapper.Map<Student>(dto);
            var updated = DataAccessFactory.StudentData().Update(student);
            return updated != null;
        }

       
        public static bool Delete(int id)
        {
            return DataAccessFactory.StudentData().Delete(id);
        }
    }
}
