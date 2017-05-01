using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pati_Project.Models;
namespace Pati_Project.Controllers
{
    public class Staff_Time_AllocationController : Controller
    {
        PatiEntities su = new PatiEntities();

        public string find_project_allocation_id(int employee_id, int year, int month)
        {
            try
            {
            string result = "";
            var query_where2 = from a in su.staff_project_allocation where a.employee_id == employee_id && a.year == year && a.month == month select a;
            foreach (var a in query_where2)
            {
                result = a.id.ToString();
            }
            return result;
            }
            catch
            {
                return "HE HASN'T GOT ATTACHED PROJECT";
            }

        }

        public string find_hours_per_week(int employee_id)
        {
            var x = su.employees.Find(employee_id);
            var hours_per_week = x.hours_per_week;
            return hours_per_week.ToString();
        }

        public string find_project1_name(int staff_project_allocation_id)
        {
            try
            {
                var x = su.staff_project_allocation.Find(staff_project_allocation_id);
                var project1 = x.project1_id;
                var y = su.projects.Find(project1);
                var project1_name = y.name;
                return project1_name;
            }
            catch
            {
                return "HE HASN'T GOT ATTACHED PROJECT 1";
            }

        }

        public string find_project2_name(int staff_project_allocation_id)
        {
            var x = su.staff_project_allocation.Find(staff_project_allocation_id);
            var project2 = x.project2_id;
            var y = su.projects.Find(project2);
            var project2_name = y.name;
            return project2_name;
        }

        public string find_project1_percentage(int staff_project_allocation_id)
        {
            var x = su.staff_project_allocation.Find(staff_project_allocation_id);
            var project1_percentage = x.project1_percentage;
            return project1_percentage.ToString();
        }
        public string find_project2_percentage(int staff_project_allocation_id)
        {
            var x = su.staff_project_allocation.Find(staff_project_allocation_id);
            var project1_percentage = x.project1_percentage;
            var project2_percentage = 100 - project1_percentage;
            return project2_percentage.ToString();
        }

        public decimal calculate_annual_gross_salary(decimal gross_salary,decimal insurance, decimal pension)
        {
            var annual = gross_salary*12+insurance*12+pension*12;
            
            return annual;
        }

        public decimal calculate_project1_hours(decimal gross_salary, int staff_project_allocation_id)
        {
            var x = su.staff_project_allocation.Find(staff_project_allocation_id);
            var employee_id = x.employee_id;
            var hours_per_week = find_hours_per_week(Convert.ToInt32(employee_id));
            var project1_percentage = find_project1_percentage(staff_project_allocation_id);
            float project1_hours = float.Parse(hours_per_week)* float.Parse(project1_percentage)/100;
            decimal result = Math.Round((Decimal)project1_hours, 2);
            //var project1_hours = (Convert.ToInt32(project1_percentage)) * (float)(Convert.ToInt32(hours_per_week));
            return result;            
        }
        public decimal calculate_project2_hours(decimal gross_salary, int staff_project_allocation_id)
        {
            var x = su.staff_project_allocation.Find(staff_project_allocation_id);
            var employee_id = x.employee_id;
            var hours_per_week = find_hours_per_week(Convert.ToInt32(employee_id));
            var project2_percentage = find_project2_percentage(staff_project_allocation_id);
            float project2_hours = float.Parse(hours_per_week) * float.Parse(project2_percentage) / 100;

            decimal result = Math.Round((Decimal)project2_hours, 2);
            return result;
        }

        public float calculate_project1_cost(decimal gross_salary, decimal insurance, decimal pension, int staff_project_allocation_id)
        {
            //$("#project1_cost").val(j * get_project1_percentage(project_allocation_id) / 100 / 12);
            decimal annual = calculate_annual_gross_salary(gross_salary, insurance, pension);
            float project1_percentage = float.Parse(find_project1_percentage(staff_project_allocation_id));
            float result = (float)annual * project1_percentage/100/12;
            return result;

        }
        public float calculate_project2_cost(decimal gross_salary, decimal insurance, decimal pension, int staff_project_allocation_id)
        {
            //$("#project1_cost").val(j * get_project1_percentage(project_allocation_id) / 100 / 12);
            decimal annual = calculate_annual_gross_salary(gross_salary, insurance, pension);
            float project2_percentage = float.Parse(find_project2_percentage(staff_project_allocation_id));
            float result = (float)annual * project2_percentage / 100 / 12;
            return result;

        }

        //public decimal calculate_project1_cost()
        //{

        //}

        //public decimal calculate_project2_cost()
        //{

        //}
        public string find_date(int staff_project_allocation_id)
        {
            var x = su.staff_project_allocation.Find(staff_project_allocation_id);
            var year = Convert.ToInt32(x.year);
            var month = Convert.ToInt32(x.month);
            return month.ToString()+"/"+year.ToString();
        }


        public string find_employee(int staff_project_allocation_id)
        {
            var y = su.staff_project_allocation.Find(staff_project_allocation_id);
            var employee_id = y.employee_id;
            var x = su.employees.Find(employee_id);
            var first_name = x.first_name;
            var surname = x.surname;
            return (first_name + " " + surname);
        }
        public ActionResult Index()
        {
            var employees = su.employees.ToList();
            List<object> newList = new List<object>();
            foreach (var employee in employees)
                newList.Add(new
                {
                    Id = employee.id,
                    Name = employee.first_name + " " + employee.surname
                });
            ViewBag.Employees_list = new SelectList(newList, "Id", "Name");


            ViewBag.Staff_Time_Allocation_list = su.staff_time_allocation.ToList();

            return View();
        }


        [HttpPost]
        public ActionResult Index(staff_time_allocation x)
        {

            if (ModelState.IsValid)
            {
                staff_time_allocation a = new staff_time_allocation();
                a.allocation_id = x.allocation_id;
                a.gross_salary = x.gross_salary;
                a.insurance = x.insurance;
                a.pension = x.pension;
         

                su.staff_time_allocation.Add(a);
                su.SaveChanges();

                return RedirectToAction("Index");
            }

            return View("Index");

        }

        public string find_company_project1(int staff_project_allocation_id)
        {
            var dupa = "";
            var x = su.staff_project_allocation.Find(staff_project_allocation_id);
            var project1 = x.project1_id;
            var query_where2 = from a in su.projects where a.id == project1 select a;
            foreach (var a in query_where2)
            {
                dupa = a.company_id.ToString();
            }

            return dupa;

        }
        public string find_company_project2(int staff_project_allocation_id)
        {
            var dupa = "";
            try
            {
                var x = su.staff_project_allocation.Find(staff_project_allocation_id);
                var project2 = x.project2_id;
                var query_where2 = from a in su.projects where a.id == project2 select a;
                foreach (var a in query_where2)
                {
                    dupa = a.company_id.ToString();
                }
            }
            catch
            {
                dupa = "0";
            }


            return dupa;

        }

    }
}