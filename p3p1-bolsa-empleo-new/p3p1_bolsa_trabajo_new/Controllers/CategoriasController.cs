using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using p3p1_bolsa_trabajo_new.Models;

namespace p3p1_bolsa_trabajo_new.Controllers
{
    public class CategoriasController : Controller
    {
        private p3p1BolsaTrabajoEntitiesCategorias db = new p3p1BolsaTrabajoEntitiesCategorias();

        // GET: Categorias
        public ActionResult Index()
        {
            return View(db.categoriaOfertaEmpleos.ToList());
        }

        // GET: Categorias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categoriaOfertaEmpleo categoriaOfertaEmpleo = db.categoriaOfertaEmpleos.Find(id);
            if (categoriaOfertaEmpleo == null)
            {
                return HttpNotFound();
            }
            return View(categoriaOfertaEmpleo);
        }

        // GET: Categorias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_categoria_ofertas,titulo")] categoriaOfertaEmpleo categoriaOfertaEmpleo)
        {
            if (ModelState.IsValid)
            {
                db.categoriaOfertaEmpleos.Add(categoriaOfertaEmpleo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoriaOfertaEmpleo);
        }

        // GET: Categorias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categoriaOfertaEmpleo categoriaOfertaEmpleo = db.categoriaOfertaEmpleos.Find(id);
            if (categoriaOfertaEmpleo == null)
            {
                return HttpNotFound();
            }
            return View(categoriaOfertaEmpleo);
        }

        // POST: Categorias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_categoria_ofertas,titulo")] categoriaOfertaEmpleo categoriaOfertaEmpleo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoriaOfertaEmpleo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoriaOfertaEmpleo);
        }

        // GET: Categorias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categoriaOfertaEmpleo categoriaOfertaEmpleo = db.categoriaOfertaEmpleos.Find(id);
            if (categoriaOfertaEmpleo == null)
            {
                return HttpNotFound();
            }
            return View(categoriaOfertaEmpleo);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            categoriaOfertaEmpleo categoriaOfertaEmpleo = db.categoriaOfertaEmpleos.Find(id);
            db.categoriaOfertaEmpleos.Remove(categoriaOfertaEmpleo);
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
