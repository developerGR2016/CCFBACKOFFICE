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
    public class AsignarRolSistemasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AsignarRolSistemas
        public ActionResult Index()
        {
            var asignarRolSistemas = db.AsignarRolSistemas.Include(a => a.ARoles);
            return View(asignarRolSistemas.ToList());
        }

        // GET: AsignarRolSistemas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignarRolSistema asignarRolSistema = db.AsignarRolSistemas.Find(id);
            if (asignarRolSistema == null)
            {
                return HttpNotFound();
            }
            return View(asignarRolSistema);
        }

        // GET: AsignarRolSistemas/Create
        public ActionResult Create()
        {
            ViewBag.ARoleId = new SelectList(db.ARoles, "Id", "Name");
            return View();
        }

        // POST: AsignarRolSistemas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SistemaId,ARoleId")] AsignarRolSistema asignarRolSistema)
        {
            if (ModelState.IsValid)
            {
                db.AsignarRolSistemas.Add(asignarRolSistema);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ARoleId = new SelectList(db.ARoles, "Id", "Name", asignarRolSistema.ARoleId);
            return View(asignarRolSistema);
        }

        // GET: AsignarRolSistemas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignarRolSistema asignarRolSistema = db.AsignarRolSistemas.Find(id);
            if (asignarRolSistema == null)
            {
                return HttpNotFound();
            }
            ViewBag.ARoleId = new SelectList(db.ARoles, "Id", "Name", asignarRolSistema.ARoleId);
            return View(asignarRolSistema);
        }

        // POST: AsignarRolSistemas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SistemaId,ARoleId")] AsignarRolSistema asignarRolSistema)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asignarRolSistema).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ARoleId = new SelectList(db.ARoles, "Id", "Name", asignarRolSistema.ARoleId);
            return View(asignarRolSistema);
        }

        // GET: AsignarRolSistemas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignarRolSistema asignarRolSistema = db.AsignarRolSistemas.Find(id);
            if (asignarRolSistema == null)
            {
                return HttpNotFound();
            }
            return View(asignarRolSistema);
        }

        // POST: AsignarRolSistemas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AsignarRolSistema asignarRolSistema = db.AsignarRolSistemas.Find(id);
            db.AsignarRolSistemas.Remove(asignarRolSistema);
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
