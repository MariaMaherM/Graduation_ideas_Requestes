using IA_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IA_Project.Controllers;
using System.Data.Entity;
using System.Net.Mail;
using System.Net;
using System.Text;
using IA_Project.ViewModel;

namespace IA_Project.Controllers
{
    public class AdminController : Controller
    {
        ProjectContext db = new ProjectContext();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Details/5
        public ActionResult showMemberPF(int id)
        {



            Professor prof = new Professor();
            var tm = db.TeamLeaders.ToList();
            ProfessorTeamLeader pt = new ProfessorTeamLeader()
            {
                Professors = prof,
                TeamLeaders = tm

            };

            var details = (from userlist in db.TeamLeaders
                           where userlist.id_professor == prof.id
                           select new
                           {
                               userlist.member1_Name,
                               userlist.member2_Name,
                               userlist.member3_Name,
                               userlist.member4_Name,
                               userlist.member5_Name,
                               userlist.User_Name,
                               userlist.id


                           }).ToList();

            var num = db.TeamLeaders.ToList().Where(c => c.id == id);
            return View(num.ToList());
        }

        public ActionResult ShowProfessors()
        {
            return View(db.Professors.ToList());
        }
        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Details(int id)
        {



            var num = db.Professors.ToList().SingleOrDefault(c => c.id == id);

            return View(num);

        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(Professor prof)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Professors.Add(prof);
                    db.SaveChanges();
                }
                return RedirectToAction("ShowProfessors","Admin");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id=1)
        {
            Admin adm = db.Admins.Single(x=>x.id==id);
            
            return View(adm);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit( Admin adm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(adm).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Welcome","Login");
            }
            catch
            {
                return View("Welcome", "Login");
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            Professor pro = db.Professors.Single(x => x.id == id);
            return View(pro);
        }

        // POST: Admin/Delete/5
        [HttpPost , ActionName("Delete")]
        public ActionResult Delete(Professor pro)
        {
            try
            {
                // TODO: Add delete logic here
               pro = db.Professors.Find(pro.id);
                db.Professors.Remove(pro);
                db.SaveChanges();
                return RedirectToAction("ShowProfessors", "Admin");
            }
            catch
            {
                return RedirectToAction("ShowProfessors", "Admin");
            }
        }






        public JsonResult SendEmailToUser(string y)
        {
            bool result = false;
            //da el mota3'air
            result = SendEmail(y, "acceptance", "<p>hi<br>thats my acceptance mail for you</p>");

            return Json(result, JsonRequestBehavior.AllowGet);

        }

        public bool SendEmail(string ToEmail, string Subject, string EmailBody)
        {
            try
            {
                string SenderEmail = System.Configuration.ConfigurationManager.AppSettings["SenderEmail"].ToString();
                string SenderPass = System.Configuration.ConfigurationManager.AppSettings["SenderPass"].ToString();
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Timeout = 100000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(SenderEmail, SenderPass);
                MailMessage msg = new MailMessage(SenderEmail, ToEmail, Subject, EmailBody);
                msg.IsBodyHtml = true;
                msg.BodyEncoding = UTF8Encoding.UTF8;
                client.Send(msg);
                return true;
            }

            catch (Exception Ex)
            {
                return false;
            }

        }
    }
}
