using DAL.interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class StudentRepo : Repo, IRepo<Student, int, Student>

    {
        public Student Create(Student obj)
        {
            db.Students.Add(obj);  
            if (db.SaveChanges() > 0)  
                return obj; 
            return null;  
        }

        public bool Delete(int id)
        {
            var ex = Read(id); 
            if (ex != null)
            {
                db.Students.Remove(ex); 
                return db.SaveChanges() > 0; 
            }
            return false;  
        }

        public List<Student> Read()
        {
            return db.Students.ToList();  

        }

        public Student Read(int id)
        {
            return db.Students.Find(id);
        }

        public Student Update(Student obj)
        {
            var ex = Read(obj.StudentId);  
            if (ex != null)
            {
                db.Entry(ex).CurrentValues.SetValues(obj);  
                if (db.SaveChanges() > 0)  
                    return obj;  
            }
            return null;  
        }
    }
}
