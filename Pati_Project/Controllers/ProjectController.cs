using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pati_Project.Models;

namespace Pati_Project.Controllers
{
    public class ProjectController : Controller
    {
        PatiEntities su = new PatiEntities();
        // GET: Project
        public ActionResult Index()
        {

            ViewBag.Projects_list = su.projects.ToList();
            
            ViewBag.Companies_list = su.companies.ToList();

            return View();
        }
        public string find_company(int id)
        {
            var x = su.companies.Find(id);
            return x.name.ToString();

        }


        [HttpPost]
       
        public ActionResult Index(project project_view)
        {

            if (ModelState.IsValid)
            {
                project pr = new project();
                pr.name = project_view.name;
                pr.company_id = project_view.company_id;
                su.projects.Add(pr);
                su.SaveChanges();
                
                return RedirectToAction("Index");
            }
       
            return View("Index");

        }
    }
}