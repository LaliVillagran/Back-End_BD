using Back_End_BD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Back_End_BD.Controllers
{
    public class AlumnosController : Controller
    {
        // GET: Alumnos
        public ActionResult Index()
        {
            
            using (AlumnoDbContext dbAlumnos = new AlumnoDbContext())
            {
              //select * from alumnos;
            return View(dbAlumnos.Alumnos.ToList()); 
            }
        }

        public ActionResult Details(int? id)
        {

            using (AlumnoDbContext dbAlumnos = new AlumnoDbContext())
            {
                //select * from alumnos;
                Alumno alumno = dbAlumnos.Alumnos.Find(id);
                if(alumno == null)
                {
                    return HttpNotFound();
                }
                return View(alumno);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Alumno alum)
        {
            using (AlumnoDbContext dbAlumnos = new AlumnoDbContext())
            {
                dbAlumnos.Alumnos.Add(alum);
                dbAlumnos.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {

            using (AlumnoDbContext dbAlumnos = new AlumnoDbContext())
            {
                return View(dbAlumnos.Alumnos.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Edit(Alumno alum)
        {

            using (AlumnoDbContext dbAlumnos = new AlumnoDbContext())
            {
                dbAlumnos.Entry(alum).State = System.Data.Entity.EntityState.Modified;
                dbAlumnos.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {

            using (AlumnoDbContext dbAlumnos = new AlumnoDbContext())
            {
                return View(dbAlumnos.Alumnos.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Delete(Alumno alum, int? id)
        {

            using (AlumnoDbContext dbAlumnos = new AlumnoDbContext())
            {
                Alumno al = dbAlumnos.Alumnos.Where(x => x.Id == id).FirstOrDefault();
                dbAlumnos.Alumnos.Remove(al);
                dbAlumnos.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}