using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Trabajo_1.Models;

namespace Trabajo_1.Controllers
{
    public class CategoriaProductosController : Controller
    {
        private Tarea1Entities2 db = new Tarea1Entities2();

        // GET: CategoriaProductos
        public ActionResult Index()
        {
            return View(db.CategoriaProductos.ToList());
        }

        // GET: CategoriaProductos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaProductos categoriaProductos = db.CategoriaProductos.Find(id);
            if (categoriaProductos == null)
            {
                return HttpNotFound();
            }
            return View(categoriaProductos);
        }

        // GET: CategoriaProductos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaProductos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre")] CategoriaProductos categoriaProductos)
        {
            if (ModelState.IsValid)
            {
                db.CategoriaProductos.Add(categoriaProductos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoriaProductos);
        }

        // GET: CategoriaProductos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaProductos categoriaProductos = db.CategoriaProductos.Find(id);
            if (categoriaProductos == null)
            {
                return HttpNotFound();
            }
            return View(categoriaProductos);
        }

        // POST: CategoriaProductos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre")] CategoriaProductos categoriaProductos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoriaProductos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoriaProductos);
        }

        // GET: CategoriaProductos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaProductos categoriaProductos = db.CategoriaProductos.Find(id);
            if (categoriaProductos == null)
            {
                return HttpNotFound();
            }
            return View(categoriaProductos);
        }

        // POST: CategoriaProductos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoriaProductos categoriaProductos = db.CategoriaProductos.Find(id);
            db.CategoriaProductos.Remove(categoriaProductos);
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
