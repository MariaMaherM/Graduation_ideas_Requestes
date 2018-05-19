using IA_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace IA_Project.Controllers
{
    public class HomeController : Controller
    {
        ProjectContext db = new ProjectContext();
     //  [Authorize]
        public ActionResult Index()
        {
            return View(db.Professors.ToList());
        }



        public ActionResult Details(int id)
        {

            var num = db.Professors.ToList().SingleOrDefault(c => c.id == id);
            return View(num);

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


        [Authorize]
        [AllowAnonymous]
        
        public ActionResult Logout()
        {

            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");

        }



    }
}