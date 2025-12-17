using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Course
    {
        [Key]
        public int CourseId {  get; set; }

        [Required]
        [StringLength(50)]
        public string CourseName {  get; set; }

        [Range(1, int.MaxValue)]
        public int MaxSeats {  get; set; }
        
        [Range(0, int.MaxValue)]
        public int EnrolledCount {  get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
        
    }
}
