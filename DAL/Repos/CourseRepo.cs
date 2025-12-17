using DAL.interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    internal class CourseRepo : Repo, IRepo<Course, int, bool>
    {
        public bool Create(Course obj)
        {
            db.Courses.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var course = Read(id);
            if (course != null)
            {
                db.Courses.Remove(course);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public List<Course> Read()
        {
            return db.Courses.ToList();
        }

        public Course Read(int id)
        {
            return db.Courses.Find(id);
        }

        public bool Update(Course obj)
        {
            var ex = Read(obj.CourseId);
            if (ex != null)
            {
                db.Entry(ex).CurrentValues.SetValues(obj);
                return db.SaveChanges() > 0;
            }
            return false;
        }
    }
}
