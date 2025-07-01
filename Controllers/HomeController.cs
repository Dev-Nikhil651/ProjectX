using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication24.Models;
using WebApplication24.Services;

namespace WebApplication24.Controllers
{
    public class HomeController : Controller
    {
        private jobsEntities1 db = new jobsEntities1();
        private readonly JobPostService jobService = new JobPostService();
        public ActionResult Login()
        {
            return View("login");
        }
        public ActionResult Index()
        {
            
            var result = jobService.GetAllJobPosts();


            return View(result);
        }
        public ActionResult Adminjoblist()
        {
            var result = jobService.GetAllJobPosts();

            //ViewBag.Action = "jobs";
            //var jobs = db.JobPosts.ToList();
            return View("~/Views/Login/Login.cshtml", result);
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}