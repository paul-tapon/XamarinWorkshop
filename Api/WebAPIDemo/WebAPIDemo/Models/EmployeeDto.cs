using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPIDemo.Models
{
    public class EmployeeDto
    {
        [Key]
        public int EmployeeId { get; set; }

        [MaxLength(30)]
        public string Firstname { get; set; }

        [MaxLength(30)]
        public string Lastname { get; set; }

        [MaxLength(30)]
        public string MiddleName { get; set; }

        [MaxLength(30)]
        public string SuffixName { get; set; }

        [MaxLength(30)]
        public string EmployeeNumber { get; set; }

        [MaxLength(30)]
        public string MobileNumber { get; set; }

        [MaxLength(30)]
        public string LandlineNumber { get; set; }

        [MaxLength(30)]
        public string Department { get; set; }

    }
}