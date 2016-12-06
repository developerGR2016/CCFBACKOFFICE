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
    public class permisosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: permisos
        public ActionResult Index()
        {
            var permisoes = db.permisoes.Include(p => p.Catagorias);
            return View(permisoes.ToList());
        }

        // GET: permisos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            permiso permiso = db.permisoes.Find(id);
            if (permiso == null)
            {
                return HttpNotFound();
            }
            return View(permiso);
        }

        // GET: permisos/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Name");
            return View();
        }

        // POST: permisos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,CategoriaId")] permiso permiso)
        {
            if (ModelState.IsValid)
            {
                db.permisoes.Add(permiso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Name", permiso.CategoriaId);
            return View(permiso);
        }

        // GET: permisos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            permiso permiso = db.permisoes.Find(id);
            if (permiso == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Name", permiso.CategoriaId);
            return View(permiso);
        }

        // POST: permisos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,CategoriaId")] permiso permiso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(permiso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Name", permiso.CategoriaId);
            return View(permiso);
        }

        // GET: permisos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            permiso permiso = db.permisoes.Find(id);
            if (permiso == null)
            {
                return HttpNotFound();
            }
            return View(permiso);
        }

        // POST: permisos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            permiso permiso = db.permisoes.Find(id);
            db.permisoes.Remove(permiso);
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
