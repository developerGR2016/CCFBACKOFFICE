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
    public class AsignarPermisoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AsignarPermisoes
        public ActionResult Index()
        {
            //if (idUser == null) {
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            var asignarPermisoes = db.AsignarPermisoes.Include(a => a.ARoles).Include(a => a.permisos).Include(a => a.Sistemas);
       
            return View(asignarPermisoes.ToList());
        }

        private ActionResult View(List<AsignarPermiso> list, int idUser)
        {
            throw new NotImplementedException();
        }

        // GET: AsignarPermisoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignarPermiso asignarPermiso = db.AsignarPermisoes.Find(id);
            if (asignarPermiso == null)
            {
                return HttpNotFound();
            }
            return View(asignarPermiso);
        }

        // GET: AsignarPermisoes/Create
        public ActionResult Create()
        {
            ViewBag.ARoleId = new SelectList(db.ARoles, "Id", "Name");
            ViewBag.permisoId = new SelectList(db.permisoes, "Id", "Name");
            ViewBag.SistemaId = new SelectList(db.Sistemas, "Id", "Name");
            return View();
        }

        // POST: AsignarPermisoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,ARoleId,SistemaId,permisoId")] AsignarPermiso asignarPermiso)
        {
            if (ModelState.IsValid)
            {
                db.AsignarPermisoes.Add(asignarPermiso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ARoleId = new SelectList(db.ARoles, "Id", "Name", asignarPermiso.ARoleId);
            ViewBag.permisoId = new SelectList(db.permisoes, "Id", "Name", asignarPermiso.permisoId);
            ViewBag.SistemaId = new SelectList(db.Sistemas, "Id", "Name", asignarPermiso.SistemaId);
            return View(asignarPermiso);
        }

        // GET: AsignarPermisoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignarPermiso asignarPermiso = db.AsignarPermisoes.Find(id);
            if (asignarPermiso == null)
            {
                return HttpNotFound();
            }
            ViewBag.ARoleId = new SelectList(db.ARoles, "Id", "Name", asignarPermiso.ARoleId);
            ViewBag.permisoId = new SelectList(db.permisoes, "Id", "Name", asignarPermiso.permisoId);
            ViewBag.SistemaId = new SelectList(db.Sistemas, "Id", "Name", asignarPermiso.SistemaId);
            return View(asignarPermiso);
        }

        // POST: AsignarPermisoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,ARoleId,SistemaId,permisoId")] AsignarPermiso asignarPermiso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asignarPermiso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ARoleId = new SelectList(db.ARoles, "Id", "Name", asignarPermiso.ARoleId);
            ViewBag.permisoId = new SelectList(db.permisoes, "Id", "Name", asignarPermiso.permisoId);
            ViewBag.SistemaId = new SelectList(db.Sistemas, "Id", "Name", asignarPermiso.SistemaId);
            return View(asignarPermiso);
        }

        // GET: AsignarPermisoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignarPermiso asignarPermiso = db.AsignarPermisoes.Find(id);
            if (asignarPermiso == null)
            {
                return HttpNotFound();
            }
            return View(asignarPermiso);
        }

        // GET: AsignarPermisoes/Asignar/1
        public ActionResult Asignar(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.idUsuario= id;
            return View();
        }

        // POST: AsignarPermisoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AsignarPermiso asignarPermiso = db.AsignarPermisoes.Find(id);
            db.AsignarPermisoes.Remove(asignarPermiso);
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
