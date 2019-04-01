using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAPIProject1.Models;

namespace WebAPIProject1.Contexts
{
    public class MyContext:DbContext
    {
        public DbSet<Employee> Employee { get; set; }
    }
}