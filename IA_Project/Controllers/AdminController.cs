using IA_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IA_Project.Controllers;
using System.Data.Entity;

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
        public ActionResult Details(int id)
        {
            return View();
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
                return RedirectToAction("ShowProfessors","Admin");
            }
            catch
            {
                return View("ShowProfessors", "Admin");
            }
        }
    }
}
