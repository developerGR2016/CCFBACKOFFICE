using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IntranetRosul.Models;

namespace IntranetRosul.Controllers
{
    public class ARolesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ARoles
        public ActionResult Index()
        {
            return View(db.ARoles.ToList());
        }

        // GET: ARoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ARole aRole = db.ARoles.Find(id);
            if (aRole == null)
            {
                return HttpNotFound();
            }
            return View(aRole);
        }

        // GET: ARoles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ARoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] ARole aRole)
        {
            if (ModelState.IsValid)
            {
                db.ARoles.Add(aRole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aRole);
        }

        // GET: ARoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ARole aRole = db.ARoles.Find(id);
            if (aRole == null)
            {
                return HttpNotFound();
            }
            return View(aRole);
        }

        // POST: ARoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] ARole aRole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aRole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aRole);
        }

        // GET: ARoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ARole aRole = db.ARoles.Find(id);
            if (aRole == null)
            {
                return HttpNotFound();
            }
            return View(aRole);
        }

        // POST: ARoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ARole aRole = db.ARoles.Find(id);
            db.ARoles.Remove(aRole);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
