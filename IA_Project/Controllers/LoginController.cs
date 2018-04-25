using IA_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace IA_Project.Controllers
{
    public class LoginController : Controller
    {
    
        ProjectContext db = new ProjectContext();
        public ActionResult Index()
        {


            return View();

        }

        public ActionResult Login()
        {


            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Admin adm,Professor pro,TeamLeader tm)
        {
            if (ModelState.IsValid)
            {
                var details = (from userlist in db.Admins
                               where userlist.User_Name == adm.User_Name && userlist.password == adm.password
                               select new
                               {
                                   userlist.Phone_Number,
                                   userlist.Email,
                                   userlist.id,
                                   userlist.User_Name
                               }).ToList();


                var professor = (from userlist in db.Professors
                               where userlist.User_Name == pro.User_Name && userlist.User_Name == pro.password
                               select new
                               {
                                   userlist.phone_number,
                                   userlist.Email,
                                   userlist.id,
                                   userlist.User_Name
                               }).ToList();


                var teamleader = (from userlist in db.TeamLeaders
                                 where userlist.User_Name == tm.User_Name && userlist.User_Name == tm.Password
                                 select new
                                 {
                                     userlist.Phone_Number,
                                     userlist.Email,
                                     userlist.id,
                                     userlist.User_Name
                                 }).ToList();


                if (details.FirstOrDefault() != null)
                {
                    Session["id"] = details.FirstOrDefault().id;
                    Session["User_Name"] = details.FirstOrDefault().User_Name;
                    return RedirectToAction("Welcome", "Login");

                }
                if (professor.FirstOrDefault() != null)
                {
                    Session["id"] = professor.FirstOrDefault().id;
                    Session["User_Name"] = professor.FirstOrDefault().User_Name;
                    return RedirectToAction("WelcomeProfessor", "Login");
                }
                if (teamleader.FirstOrDefault() != null)
                {
                    Session["id"] = teamleader.FirstOrDefault().id;
                    Session["User_Name"] = teamleader.FirstOrDefault().User_Name;
                    return RedirectToAction("WelcomeTeamLeader", "Login");

                }
            }





            else
            {
                ModelState.AddModelError("", "Invalid Data");
            }

            return View(adm);

        }

        public ActionResult Welcome()
        {

            return View();
        }
        public ActionResult WelcomeProfessor()
        {

            return View();
        }
        public ActionResult WelcomeTeamLeader()
        {

            return View();
        }














    }
}