using DAL.interfaces;
using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Course, int, bool> CourseData()
        {
            return new CourseRepo();
        }
        public static IRepo<Enrollment, int, bool> EnrollmentData()
        {
            return new EnrollmentRepo();
        }
        public static IRepo<Student, int, Student> StudentData()
        {
            return new StudentRepo();
        }
    }
}
