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
    [Authorize]
    public class ConfiguracionesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Configuraciones
        public ActionResult Index()
        {
            return View(db.configuraciones.ToList());
        }

        // GET: Configuraciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Configuracion configuracion = db.configuraciones.Find(id);
            if (configuracion == null)
            {
                return HttpNotFound();
            }
            return View(configuracion);
        }

        // GET: Configuraciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Configuraciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,idioma,diasEmpleos,cantidadEmpleos")] Configuracion configuracion)
        {
            if (ModelState.IsValid)
            {
                db.configuraciones.Add(configuracion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(configuracion);
        }

        // GET: Configuraciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Configuracion configuracion = db.configuraciones.Find(id);
            if (configuracion == null)
            {
                return HttpNotFound();
            }
            return View(configuracion);
        }

        // POST: Configuraciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idioma,diasEmpleos,cantidadEmpleos")] Configuracion configuracion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(configuracion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(configuracion);
        }

        // GET: Configuraciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Configuracion configuracion = db.configuraciones.Find(id);
            if (configuracion == null)
            {
                return HttpNotFound();
            }
            return View(configuracion);
        }

        // POST: Configuraciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Configuracion configuracion = db.configuraciones.Find(id);
            db.configuraciones.Remove(configuracion);
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
