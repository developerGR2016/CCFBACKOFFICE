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
    public class AsignarSistemaUsuariosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AsignarSistemaUsuarios
        public ActionResult Index()
        {
            var asignarSistemaUsuarios = db.AsignarSistemaUsuarios.Include(a => a.Sistemas);
            return View(asignarSistemaUsuarios.ToList());
        }

        // GET: AsignarSistemaUsuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignarSistemaUsuario asignarSistemaUsuario = db.AsignarSistemaUsuarios.Find(id);
            if (asignarSistemaUsuario == null)
            {
                return HttpNotFound();
            }
            return View(asignarSistemaUsuario);
        }

        // GET: AsignarSistemaUsuarios/Create/nombredeusuario
        public ActionResult Create(string UserName)
        {
            ViewBag.SistemaId = new SelectList(db.Sistemas, "Id", "Name");
            ViewBag.usuario = UserName;
            return View();
        }

        // POST: AsignarSistemaUsuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,SistemaId")] AsignarSistemaUsuario asignarSistemaUsuario)
        {
            if (ModelState.IsValid)
            {
                db.AsignarSistemaUsuarios.Add(asignarSistemaUsuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SistemaId = new SelectList(db.Sistemas, "Id", "Name", asignarSistemaUsuario.SistemaId);
            return View(asignarSistemaUsuario);
        }

        // GET: AsignarSistemaUsuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignarSistemaUsuario asignarSistemaUsuario = db.AsignarSistemaUsuarios.Find(id);
            if (asignarSistemaUsuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.SistemaId = new SelectList(db.Sistemas, "Id", "Name", asignarSistemaUsuario.SistemaId);
            return View(asignarSistemaUsuario);
        }

        // POST: AsignarSistemaUsuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,SistemaId")] AsignarSistemaUsuario asignarSistemaUsuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asignarSistemaUsuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SistemaId = new SelectList(db.Sistemas, "Id", "Name", asignarSistemaUsuario.SistemaId);
            return View(asignarSistemaUsuario);
        }

        // POST: AsignarSistemausuarios/

        // GET: AsignarSistemaUsuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignarSistemaUsuario asignarSistemaUsuario = db.AsignarSistemaUsuarios.Find(id);
            if (asignarSistemaUsuario == null)
            {
                return HttpNotFound();
            }
            return View(asignarSistemaUsuario);
        }

        // POST: AsignarSistemaUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AsignarSistemaUsuario asignarSistemaUsuario = db.AsignarSistemaUsuarios.Find(id);
            db.AsignarSistemaUsuarios.Remove(asignarSistemaUsuario);
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
