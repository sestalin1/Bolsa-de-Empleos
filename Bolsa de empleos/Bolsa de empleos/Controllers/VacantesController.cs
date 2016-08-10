using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bolsa_de_empleos.Models;

namespace Bolsa_de_empleos.Controllers
{
    public class VacantesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Vacantes
        public ActionResult Index()
        {
            var vacantes = db.Vacantes.Include(v => v.categoriaTrabajo);
            return View(vacantes.ToList());
        }

        // GET: Vacantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacante vacante = db.Vacantes.Find(id);
            if (vacante == null)
            {
                return HttpNotFound();
            }
            return View(vacante);
        }

        // GET: Vacantes/Create
        public ActionResult Create()
        {
            ViewBag.categoriaID = new SelectList(db.CategoriasTrabajo, "Nombre", "Descripcion");
            return View();
        }

        // POST: Vacantes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,titulo,categoriaID,fechaPublicacion,estatus,ubicacion,posicion,empresa,tipoTrabajo,logo,descripcion,comoAplicar,accesibilidad")] Vacante vacante)
        {
            if (ModelState.IsValid)
            {
                db.Vacantes.Add(vacante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categoriaID = new SelectList(db.CategoriasTrabajo, "Nombre", "Descripcion", vacante.categoriaID);
            return View(vacante);
        }

        // GET: Vacantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacante vacante = db.Vacantes.Find(id);
            if (vacante == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoriaID = new SelectList(db.CategoriasTrabajo, "Nombre", "Descripcion", vacante.categoriaID);
            return View(vacante);
        }

        // POST: Vacantes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,titulo,categoriaID,fechaPublicacion,estatus,ubicacion,posicion,empresa,tipoTrabajo,logo,descripcion,comoAplicar,accesibilidad")] Vacante vacante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vacante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoriaID = new SelectList(db.CategoriasTrabajo, "Nombre", "Descripcion", vacante.categoriaID);
            return View(vacante);
        }

        // GET: Vacantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacante vacante = db.Vacantes.Find(id);
            if (vacante == null)
            {
                return HttpNotFound();
            }
            return View(vacante);
        }

        // POST: Vacantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vacante vacante = db.Vacantes.Find(id);
            db.Vacantes.Remove(vacante);
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
