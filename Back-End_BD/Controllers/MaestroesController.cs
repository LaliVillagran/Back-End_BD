using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Back_End_BD.Models;

namespace Back_End_BD.Controllers
{
    public class MaestroesController : Controller
    {
        private AlumnoDbContext db = new AlumnoDbContext();

        // GET: Maestroes
        public ActionResult Index()
        {
            return View(db.Maestros.ToList());
        }

        // GET: Maestroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maestro maestro = db.Maestros.Find(id);
            if (maestro == null)
            {
                return HttpNotFound();
            }
            return View(maestro);
        }

        // GET: Maestroes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Maestroes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Matricula,Nombre,Apellidos,Correo,Edad")] Maestro maestro)
        {
            if (ModelState.IsValid)
            {
                db.Maestros.Add(maestro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(maestro);
        }

        // GET: Maestroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maestro maestro = db.Maestros.Find(id);
            if (maestro == null)
            {
                return HttpNotFound();
            }
            return View(maestro);
        }

        // POST: Maestroes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Matricula,Nombre,Apellidos,Correo,Edad")] Maestro maestro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maestro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(maestro);
        }

        // GET: Maestroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maestro maestro = db.Maestros.Find(id);
            if (maestro == null)
            {
                return HttpNotFound();
            }
            return View(maestro);
        }

        // POST: Maestroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Maestro maestro = db.Maestros.Find(id);
            db.Maestros.Remove(maestro);
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
