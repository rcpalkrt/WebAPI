using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIProject1.Contexts;
using WebAPIProject1.Models;

namespace WebAPIProject1.Controllers
{
    public class HomeController : ApiController
    {
        MyContext db = new MyContext();
        [HttpGet]
        public IEnumerable<Employee> Employees()
        {
            return db.Employee.ToList();
        }
    }
}

