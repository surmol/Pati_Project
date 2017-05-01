using Pati_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pati_Project.Controllers
{
    public class EmployeeController : Controller
    {
        PatiEntities su = new PatiEntities();
        // GET: Employee
        public ActionResult Index()
        {

            ViewBag.Employees_list = su.employees.ToList();

            return View();
        }

        [HttpPost]
        public ActionResult Index(employee x)
        {

            if (ModelState.IsValid)
            {
                employee a = new employee();
                a.first_name = x.first_name;
                a.surname = x.surname;
                a.age = x.age;
                a.street = x.street;
                a.house_name_number = x.house_name_number;
                a.region = x.region;
                a.post_code = x.post_code;
                a.hours_per_week = x.hours_per_week;
                su.employees.Add(a);
                su.SaveChanges();

                return RedirectToAction("Index");
            }

            return View("Index");

        }
    }
}