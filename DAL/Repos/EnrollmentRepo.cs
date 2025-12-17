using DAL.interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace DAL.Repos
{
    internal class EnrollmentRepo : Repo, IRepo<Enrollment, int, bool> 
    {
        public bool Create(Enrollment obj)
        {
            db.Enrollments.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var enr = Read(id);
            if (enr != null)
            {
                db.Enrollments.Remove(enr);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public List<Enrollment> Read()
        {
            return db.Enrollments.ToList();
        }

        public Enrollment Read(int id)
        {
            return db.Enrollments.Find(id);
        }

        public bool Update(Enrollment obj)
        {
            var ex = Read(obj.EnrollmentId);
            if (ex != null)
            {
                db.Entry(ex).CurrentValues.SetValues(obj);
                return db.SaveChanges() > 0;
            }
            return false;
        }
    }
}
