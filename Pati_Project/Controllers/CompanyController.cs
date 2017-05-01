using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pati_Project.Models;
namespace Pati_Project.Controllers
{
    public class CompanyController : Controller
    {
        PatiEntities su = new PatiEntities();
        // GET: Employee
        public ActionResult Index()
        {

            ViewBag.Companies_list = su.companies.ToList();

            return View();
        }
    }
}