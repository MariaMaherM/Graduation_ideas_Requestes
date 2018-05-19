using IA_Project.Models;
using IA_Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IA_Project.Controllers;

namespace IA_Project.Controllers
{
    public class ProfessorController : Controller
    {
        ProjectContext db = new ProjectContext();
        // GET: Professor
        public ActionResult Index()
        {
            return View();
        }

        // GET: Professor/Details/5
        public ActionResult Details()
        {
            return View();
        }





        // GET: Professor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Professor/Create
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





        public ActionResult Edit()
        {
            

            return View();
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(Professor pf)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(pf).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("WelcomeProfessor","Login");
            }
            catch
            {
                return View("WelcomeProfessor", "Login");
            }





        }



        public ActionResult finishTeam()
        {
            Professor prof = new Professor();
            var tm = db.TeamLeaders.ToList();
            TeamLeader tl = new TeamLeader();
            ProfessorTeamLeader pt = new ProfessorTeamLeader()
            {
                Professors = prof,
                TeamLeaders = tm

            };
            var details = (from userlist in db.Table_Request
                           where userlist.id_TeamLeader == tl.id && userlist.id_professor == tl.id_professor
                           select new
                           {
                               userlist.id_professor,
                               userlist.id_TeamLeader
                           }).ToList();
            var num = db.TeamLeaders.ToList();


            return View(num.ToList());
        }



        public ActionResult ShowMyTeam() {
            Professor prof = new Professor();
            var tm = db.TeamLeaders.ToList();
            TeamLeader tl = new TeamLeader();
            ProfessorTeamLeader pt = new ProfessorTeamLeader()
            {
                Professors = prof,
                TeamLeaders = tm

            };
            var details = (from userlist in db.Table_Request
                           where userlist.id_TeamLeader==tl.id&&userlist.id_professor==tl.id_professor
                           select new
                           {
                               userlist.id_professor,
                               userlist.id_TeamLeader
                           }).ToList();
            var num = db.TeamLeaders.ToList();


            return View(num.ToList());
        }



        //// GET: Professor/Edit/5
        //public ActionResult Edit()//int id
        //{
        //    return View();
        //}

        //// POST: Professor/Edit/5
        //[HttpPost]
        //public ActionResult Edit(Professor pf)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        db.Professors.Add(pf);
        //        db.SaveChanges();
        //  return RedirectToAction("WelcomeProfessor");
        //    }




        //    return View(pf);




        //}



        public ActionResult ShowAcceptedTM() {

            Professor prof = new Professor();
            var tm = db.TeamLeaders.ToList();
            TeamLeader tl = new TeamLeader();
            ProfessorTeamLeader pt = new ProfessorTeamLeader()
            {
                Professors = prof,
                TeamLeaders = tm

            };
            var details = (from userlist in db.Table_Request
                           where userlist.id_TeamLeader == tl.id && userlist.id_professor == tl.id_professor
                           select new
                           {
                               userlist.id_professor,
                               userlist.id_TeamLeader
                           }).ToList();
            var num = db.TeamLeaders.ToList();


            return View(num.ToList());
           

        }



        public ActionResult Reject(int id)
        {
            TeamLeader tr = db.TeamLeaders.Single(x => x.id == id);
            return View(tr);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Reject")]
        public ActionResult Reject(TeamLeader tr)
        {

            try
            {
                // TODO: Add delete logic here
                tr = db.TeamLeaders.Find(tr.id);
                db.TeamLeaders.Remove(tr);
                db.SaveChanges();

         
                return RedirectToAction("Login", "Login");
            }
            catch
            {
                return View("Login", "Login");
            }
        }


        public ActionResult Delete(int id)
        {
            Table_Request tr = db.Table_Request.Single(x => x.id_TeamLeader == id);
            return View(tr);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(Table_Request tr)
        {

            try
            {
                // TODO: Add delete logic here
                tr = db.Table_Request.Find(tr.request_id);
                db.Table_Request.Remove(tr);
                db.SaveChanges();

                TeamLeader tl = new TeamLeader();
                var details = (from userlist in db.Table_Request
                               where userlist.id_TeamLeader == tl.id && userlist.id_professor == tl.id_professor
                               select new
                               {
                             
                                   userlist.status
                               }).ToList();

                var sta = details.FirstOrDefault().status;
                

                return RedirectToAction("WelcomeProfessor", "Login");
            }
            catch
            {
                return View("WelcomeProfessor", "Login");
            }
        }
    }
}
