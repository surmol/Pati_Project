using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pati_Project.Models;
namespace Pati_Project.Controllers
{
    public class Staff_Project_AllocationController : Controller
    {
        PatiEntities su = new PatiEntities();

        public string find_company(int id)
        {
            string dupa="adrian";
            var query_where2 = from a in su.projects where a.id == id select a;
            foreach (var a in query_where2)
            {
                dupa = a.company_id.ToString();
            }

            return dupa;


        }
        public string find_project(int id)
        {
            var project = "";
            try
            {
                var x = su.projects.Find(id);
                project = x.name;
            }
            catch
            {
                project = "Not attached";
            }

            return project;
        }
        public string find_employee(int id)
        {
            var x = su.employees.Find(id);
            var first_name = x.first_name;
            var surname = x.surname;
            return (first_name + " " + surname);
        }

        public ActionResult Index()
        {
            ViewBag.Projects_list = su.projects.ToList();


            var employees = su.employees.ToList();
            List<object> newList = new List<object>();
            foreach (var employee in employees)
                newList.Add(new
                {
                    Id = employee.id,
                    Name = employee.first_name + " " + employee.surname
                });
            ViewBag.Employees_list = new SelectList(newList, "Id", "Name");






            ViewBag.Staff_Project_Allocation_list = su.staff_project_allocation.ToList();

            return View();
        }

        [HttpPost]
        public ActionResult Index(staff_project_allocation x)
        {

            if (ModelState.IsValid)
            {
                staff_project_allocation a = new staff_project_allocation();
                a.employee_id = x.employee_id;
                a.project1_id = x.project1_id;
                a.project2_id = x.project2_id;
                a.project1_percentage = x.project1_percentage;
                a.year = x.year;
                a.month = x.month;

                su.staff_project_allocation.Add(a);
                su.SaveChanges();

                return RedirectToAction("Index");
            }

            return View("Index");

        }
    }
}