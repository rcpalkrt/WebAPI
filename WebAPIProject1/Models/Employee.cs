using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAPIProject1.Models
{
    [Table("Employee")]
    public class Employee
    {
        public int ID { get; set; }

        [StringLength(30),Column(TypeName ="varchar")]
        public string Name { get; set; }

        [StringLength(30), Column(TypeName = "varchar")]
        public string SurName { get; set; }

        public decimal Salary { get; set; }

        [StringLength(50), Column(TypeName = "varchar")]
        public string Departman { get; set; }
    }
}