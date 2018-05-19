using IA_Project.Models;
using IA_Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IA_Project.Controllers;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace IA_Project.Controllers
{
    public class TeamLeaderController : Controller
    {
        ProjectContext db = new ProjectContext();
        // GET: TeamLeader
        public ActionResult Index()
        {
            return View();
        }

        // GET: TeamLeader/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }




        public JsonResult SendEmailToUser(string y)
        {
            bool result = true;

            result = SendEmail(y, "acceptance", "<p>hi<br>thats my acceptance mail for you</p>");

            return Json(result, JsonRequestBehavior.AllowGet);

        }

        public bool SendEmail(string ToEmail, string Subject, String EmailBody)
        {
            try
            {
                SmtpClient SmtpServer = new SmtpClient();
                SmtpServer.Host = "smtp.gmail.com";
                MailMessage mail = new MailMessage("mariamaher86@gmail.com", ToEmail, Subject, EmailBody);

                SmtpServer.Port = 587;
                SmtpServer.UseDefaultCredentials = true;
                SmtpServer.Credentials = new NetworkCredential("mariamaher86@gmail.com", "01273395379");
                SmtpServer.EnableSsl = true;
                mail.IsBodyHtml = true;
                mail.BodyEncoding = UTF8Encoding.UTF8;
                SmtpServer.Send(mail);

                return true;

            }

            catch (Exception ex)
            {
                return false;
            }
        }





        public ActionResult registforPG() {


           
            TeamLeader tm = new TeamLeader();
            var pf = db.Professors.ToList();
            TeamLeaderViewModel tlvm = new TeamLeaderViewModel()
            {
                TeamLeaders = tm,
                Professosrs = pf

            };
            //var pg = db.PGs.ToList();
            //PhotographerClient pc = new PhotographerClient
            //{
            //    photographers= pg
            //};

            var mm = (from userlist in db.TeamLeaders
                          select new
                          {

                              userlist.Email,
                              userlist.id,
                              userlist.User_Name,
                              userlist.Department
                          }).ToList();


            var get = db.Professors.ToList().Where(c=>c.Department== mm.FirstOrDefault().Department);
            SelectList list = new SelectList(get, "id", "User_Name");
            ViewBag.pg = list;

            return View(tlvm);
        }


        // GET: TeamLeader/Create
        public ActionResult Register()
        {
            TeamLeader tm = new TeamLeader();
            var  pf= db.Professors.ToList();
            TeamLeaderViewModel tlvm = new TeamLeaderViewModel()
            {
                TeamLeaders = tm,
                Professosrs = pf

            };


            Session["department"] = tm.Department;

       


            



            return View(tlvm);
        }

        [HttpPost]
        public ActionResult Register(TeamLeaderViewModel tlvm)
        {
            if (ModelState.IsValid)
                {
                    db.TeamLeaders.Add(tlvm.TeamLeaders);

                    db.SaveChanges();
                
                
                return RedirectToAction("Register");
            }
            var get = db.Professors.ToList().Where(c => c.Department == Session["department"].ToString());
            SelectList list = new SelectList(get, "id", "User_Name");
            ViewBag.pg = list;
            return Json(new { result = 0 });
        }

           


        // GET: TeamLeader/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeamLeader/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TeamLeader/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TeamLeader/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TeamLeader/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TeamLeader/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
