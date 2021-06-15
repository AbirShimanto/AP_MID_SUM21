using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LabTask.Models
{
    public class Student
    {
        
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime Dob { get; set; }

        [Required]
        public double Credit { get; set; }

        [Required]
        public double Cgpa { get; set; }

        [Required]
        public string Dept_id { get; set; }
    }
}