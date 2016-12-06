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
    public class OpcionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Opcions
        public ActionResult Index()
        {
            var opcions = db.Opcions.Include(o => o.Menus);
            return View(opcions.ToList());
        }

        // GET: Opcions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opcion opcion = db.Opcions.Find(id);
            if (opcion == null)
            {
                return HttpNotFound();
            }
            return View(opcion);
        }

        // GET: Opcions/Create
        public ActionResult Create()
        {
            ViewBag.MenuId = new SelectList(db.Menus, "Id", "Nombre");
            ViewBag.OpcionPadreId = new SelectList(db.Opcions.Where(d => d.Nivel == 0), "Id", "Nombre");
            return View();
        }

        // POST: Opcions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Descripcion,Path,MenuId,Orden,Nivel,OpcionPadreId")] Opcion opcion)
        {
            if (ModelState.IsValid)
            {
                db.Opcions.Add(opcion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MenuId = new SelectList(db.Menus, "Id", "Nombre", opcion.MenuId);
            return View(opcion);
        }

        // GET: Opcions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opcion opcion = db.Opcions.Find(id);
            if (opcion == null)
            {
                return HttpNotFound();
            }
            ViewBag.MenuId = new SelectList(db.Menus, "Id", "Nombre", opcion.MenuId);
            ViewBag.OpcionPadreId = new SelectList(db.Opcions, "OpcionPadreId", "Nombre", opcion.OpcionPadreId);
            return View(opcion);
        }

        // POST: Opcions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Descripcion,Path,MenuId,Orden,Nivel,OpcionPadreId")] Opcion opcion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(opcion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MenuId = new SelectList(db.Menus, "Id", "Nombre", opcion.MenuId);
            ViewBag.OpcionPadreId = new SelectList(db.Opcions.Where(d => d.Nivel == 0), "Id", "Nombre");
            return View(opcion);
        }

        // GET: Opcions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opcion opcion = db.Opcions.Find(id);
            if (opcion == null)
            {
                return HttpNotFound();
            }
            return View(opcion);
        }

        // POST: Opcions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Opcion opcion = db.Opcions.Find(id);
            db.Opcions.Remove(opcion);
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
