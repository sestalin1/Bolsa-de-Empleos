
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Bolsa_de_empleos.Models;

namespace Bolsa_de_empleos.Controllers
{
    [Authorize]
    public class CategoriasTrabajoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CategoriasTrabajo
        public ActionResult Index()
        {
            return View(db.CategoriasTrabajo.ToList());
        }

        // GET: CategoriasTrabajo/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaTrabajo categoriaTrabajo = db.CategoriasTrabajo.Find(id);
            if (categoriaTrabajo == null)
            {
                return HttpNotFound();
            }
            return View(categoriaTrabajo);
        }

        // GET: CategoriasTrabajo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriasTrabajo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nombre,Descripcion")] CategoriaTrabajo categoriaTrabajo)
        {
            if (ModelState.IsValid)
            {
                db.CategoriasTrabajo.Add(categoriaTrabajo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoriaTrabajo);
        }

        // GET: CategoriasTrabajo/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaTrabajo categoriaTrabajo = db.CategoriasTrabajo.Find(id);
            if (categoriaTrabajo == null)
            {
                return HttpNotFound();
            }
            return View(categoriaTrabajo);
        }

        // POST: CategoriasTrabajo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Nombre,Descripcion")] CategoriaTrabajo categoriaTrabajo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoriaTrabajo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoriaTrabajo);
        }

        // GET: CategoriasTrabajo/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaTrabajo categoriaTrabajo = db.CategoriasTrabajo.Find(id);
            if (categoriaTrabajo == null)
            {
                return HttpNotFound();
            }
            return View(categoriaTrabajo);
        }

        // POST: CategoriasTrabajo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CategoriaTrabajo categoriaTrabajo = db.CategoriasTrabajo.Find(id);
            db.CategoriasTrabajo.Remove(categoriaTrabajo);
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
