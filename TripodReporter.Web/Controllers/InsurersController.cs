using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TripodReporter.Domain.Repositories;
using TripodReporter.Domain.Contexts;
using TripodReporter.Domain.Entities;

namespace TripodReporter.Web.Controllers
{
    public class InsurersController : Controller
    {
        //private ReporterContext db = new ReporterContext();
        private IRepository<Insurer> repo;
        public InsurersController(IRepository<Insurer> insurerParam)
        {
            repo = insurerParam;
        }


        // GET: Insurers
        public ActionResult Index()
        {
            //return View(db.Insurers.ToList());
            var result = repo.GetAll().ToList();
            return View(result);
        }

        // GET: Insurers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Insurer insurer = db.Insurers.Find(id);
            var insurer = repo.Query(x => x.InsurerId == id).Single();
            if (insurer == null)
            {
                return HttpNotFound();
            }
            
            return View(insurer);
        }

        // GET: Insurers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Insurers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InsurerId,Name")] Insurer insurer)
        {
            if (ModelState.IsValid)
            {
                //db.Insurers.Add(insurer);
                //db.SaveChanges();
                //return RedirectToAction("Index");
                repo.Add(insurer);
                repo.Commit();
                RedirectToAction("Index");
            }

            return View(insurer);
        }

        // GET: Insurers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Insurer insurer = db.Insurers.Find(id);
            var insurer = repo.Query(x => x.InsurerId == id).Single();
            if (insurer == null)
            {
                return HttpNotFound();
            }
            return View(insurer);
        }

        // POST: Insurers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InsurerId,Name")] Insurer insurer)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(insurer).State = EntityState.Modified;
                //db.SaveChanges();
                repo.AddOrUpdate(insurer);
                repo.Commit();
                return RedirectToAction("Index");
            }
            return View(insurer);
        }

        // GET: Insurers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Insurer insurer = db.Insurers.Find(id);
            var insurer = repo.Query(d => d.InsurerId == id).Single();
            if (insurer == null)
            {
                return HttpNotFound();
            }
            return View(insurer);
        }

        // POST: Insurers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Insurer insurer = db.Insurers.Find(id);
            //db.Insurers.Remove(insurer);
            //db.SaveChanges();
            var policy = repo.Query(x => x.InsurerId == id).Single();
            repo.Delete(policy);
            repo.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
