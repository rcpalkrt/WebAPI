using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebAPIProject1.WebUI.Models;

namespace WebAPIProject1.WebUI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<Employee> emp = new List<Employee>();
            string data = ListEmployees();
            emp = JsonConvert.DeserializeObject<List<Employee>>(data);
            return View(emp);
        }

        public string ListEmployees()
        {
            HttpClient httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri("http://localhost:52297/api/");
            //httpClient.BaseAddress = new Uri("http://servis.aydinlatmam.com/api/");
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage httpResponseMessage = httpClient.GetAsync("Home").Result;
            return httpResponseMessage.Content.ReadAsStringAsync().Result;
        }

        public ActionResult PostEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PostEmployee(Employee model)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:52297/api/");
            var JsonData = JsonConvert.SerializeObject(model);
            var stringContent = new StringContent(JsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = httpClient.PostAsync("Employees",stringContent).Result;

            return RedirectToAction("Index");
        }

        public ActionResult EditEmployee(int id)
        {
            List<Employee> emp = new List<Employee>();
            string data = ListEmployees();
            emp = JsonConvert.DeserializeObject<List<Employee>>(data);
            Employee employee = emp.FirstOrDefault(f => f.ID == id);
            return View(employee);
        }
        [HttpPost]
        public ActionResult EditEmployee(Employee model)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:52297/api/");
            var JsonData = JsonConvert.SerializeObject(model);
            var stringContent = new StringContent(JsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = httpClient.PutAsync("Employees/" + model.ID, stringContent).Result;

            return RedirectToAction("Index");
        }
        public ActionResult DeleteEmployee(int id)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:52297/api/");
            //var JsonData = JsonConvert.SerializeObject(model);
            //var stringContent = new StringContent(JsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = httpClient.DeleteAsync("Employees/" + id).Result;

            return RedirectToAction("Index");
        }

    }
}