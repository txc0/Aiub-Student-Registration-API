using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.DTOs
{
    public class CourseDTO
    {
        public int CourseId { get; set; }
        [Required]
        public string CourseName { get; set; }
        public int MaxSeats { get; set; }
        public int EnrolledCount { get; set; }
    }
}
