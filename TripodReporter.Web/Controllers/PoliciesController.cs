using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using TripodReporter.Domain.Contexts;
using TripodReporter.Domain.Entities;
using TripodReporter.Domain.Repositories;
using TripodReporter.Web.Infrastructure;


namespace TripodReporter.Web.Controllers
{
    public class PoliciesController : Controller
    {
        private IRepository<Policy> repo;
        private IRepository<Client> repo1;
        private IRepository<Insurer> repo2;

        public PoliciesController(IRepository<Policy> db, IRepository<Client> db1, IRepository<Insurer> db2)
        {
            repo = db;
            repo1 = db1;
            repo2 = db2;
        }

        // GET: Policies
        public ActionResult Index()
        {
            //This line is to include Client & Insurer Table data in Listing Policices
            //Think of including exception handling for odd errors
            var ToInclude = repo.GetAll().AsQueryable().Include(p => p.Client).Include(p => p.Insurer);
            //ToInclude.Where(x => x.PolicyDate.Year == 2014).ToList();
            return View(ToInclude.ToList());
            //return View(ToInclude.Where(x => x.PolicyDate.Year == 2014).ToList());
        }

        public void _ToExcel()
        {
            //You want to export to excel using this method
            System.Web.UI.WebControls.GridView gv = new System.Web.UI.WebControls.GridView();
            gv.DataSource = repo.GetAll().AsQueryable().Include(p => p.Client).Include(p => p.Insurer).ToList().Take(5);
            gv.DataBind();
            Response.ClearContent();
            Response.AddHeader("content-dispostion", "attachment;filename=report.xls");
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Write(sw.ToString());
            //Response.WriteFile()
            Response.End();
            RedirectToAction("index");
        }

        [HttpPost]
        public ExcelResult ExportToExcel()
        {
            //created an excelresult type and make the table on screen an excel sheet.
            System.Web.UI.WebControls.GridView gv = new System.Web.UI.WebControls.GridView();
            gv.DataSource = repo.GetAll().AsQueryable().Include(p => p.Client).Include(p => p.Insurer).ToList().Take(5);
            gv.DataBind();
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            return new ExcelResult{
                stringwriter = sw.ToString()
            };
        }
        

        // GET: Policies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Policy policy = repo.Query(x => x.PolicyId == id).Single();
            if (policy == null)
            {
                return HttpNotFound();
            }
            return View(policy);
        }

        // GET: Policies/Create
        public ActionResult Create()
        {
            //ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "ClientName");
            //ViewBag.InsurerId = new SelectList(db.Insurers, "InsurerId", "Name");

            
            ViewBag.ClientId = new SelectList(repo1.GetAll(), "ClientId", "ClientName");
            ViewBag.InsurerId = new SelectList(repo2.GetAll(), "InsurerId", "Name");
            return View();
        }

        // POST: Policies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PolicyId,ClientId,PolicyNumber,InsurerId,PolicyDetails,PolicyType,PolicyDate,PolicyValue,PremiumPaid,Comission")] Policy policy)
        {
            if (ModelState.IsValid)
            {
                repo.Add(policy);
                repo.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(repo1.GetAll(), "ClientId", "ClientName", policy.ClientId);
            ViewBag.InsurerId = new SelectList(repo2.GetAll(), "InsurerId", "Name", policy.InsurerId);
            
            return View(policy);
        }

        // GET: Policies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Policy policy = repo.Query(e => e.PolicyId == id).Single();
            if (policy == null)
            {
                return HttpNotFound();
            }

            ViewBag.ClientId = new SelectList(repo1.GetAll(), "ClientId", "ClientName", policy.ClientId);
            ViewBag.InsurerId = new SelectList(repo2.GetAll(), "InsurerId", "Name", policy.InsurerId);
            return View(policy);
        }

        // POST: Policies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PolicyId,ClientId,PolicyNumber,InsurerId,PolicyDetails,PolicyType,PolicyDate,PolicyValue,PremiumPaid,Comission")] Policy policy)
        {
            if (ModelState.IsValid)
            {
                repo.AddOrUpdate(policy);
                repo.Commit();
                return RedirectToAction("Index");
            }
           
            ViewBag.ClientId = new SelectList(repo1.GetAll(), "ClientId", "ClientName", policy.ClientId);
            ViewBag.InsurerId = new SelectList(repo2.GetAll(), "InsurerId", "Name", policy.InsurerId);
            return View(policy);
        }

        // GET: Policies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Policy policy = repo.Query(d => d.PolicyId == id).Single();
            if (policy == null)
            {
                return HttpNotFound();
            }
            return View(policy);
        }

        // POST: Policies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Policy policy = repo.Query(d => d.PolicyId == id).Single();
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
