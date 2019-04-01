using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAPIProject1.WebUI.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public decimal Salary { get; set; }
        public string Departman { get; set; }
    }
}