using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using p3p1_bolsa_trabajo.Models;

namespace p3p1_bolsa_trabajo.Controllers
{
    public class Ofertas_Categorias_Controller : Controller
    {
        private p3p1BolsaTrabajoEntities1 db = new p3p1BolsaTrabajoEntities1();

        // GET: Ofertas_Categorias_
        public ActionResult Index()
        {
            IOrderedQueryable<Oferta> ofertas = from o in db.Ofertas where o.activo == true orderby o.fecha_posteo descending select o;
            IOrderedQueryable<categoriaOfertaEmpleo> categorias = from c in db.categoriaOfertaEmpleos orderby c.id_categoria_ofertas select c;
            dynamic ofertas_categorias = new ExpandoObject();
            ofertas_categorias.Ofertas = ofertas;
            ofertas_categorias.Categorias = categorias;
            return View(ofertas_categorias);
        }

        // GET: Ofertas_Categorias_/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oferta oferta = db.Ofertas.Find(id);
            if (oferta == null)
            {
                return HttpNotFound();
            }
            return View(oferta);
        }

        // GET: Ofertas_Categorias_/Create
        public ActionResult Create()
        {
            ViewBag.id_categoria_ofertas = new SelectList(db.categoriaOfertaEmpleos, "id_categoria_ofertas", "titulo");
            return View();
        }

        // POST: Ofertas_Categorias_/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_ofertas,titulo,descripcion,fecha_posteo,activo,id_categoria_ofertas,ubicacion,posicion,nombre_empresa")] Oferta oferta)
        {
            if (ModelState.IsValid)
            {
                db.Ofertas.Add(oferta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_categoria_ofertas = new SelectList(db.categoriaOfertaEmpleos, "id_categoria_ofertas", "titulo", oferta.id_categoria_ofertas);
            return View(oferta);
        }

        // GET: Ofertas_Categorias_/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oferta oferta = db.Ofertas.Find(id);
            if (oferta == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_categoria_ofertas = new SelectList(db.categoriaOfertaEmpleos, "id_categoria_ofertas", "titulo", oferta.id_categoria_ofertas);
            return View(oferta);
        }

        // POST: Ofertas_Categorias_/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_ofertas,titulo,descripcion,fecha_posteo,activo,id_categoria_ofertas,ubicacion,posicion,nombre_empresa")] Oferta oferta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oferta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_categoria_ofertas = new SelectList(db.categoriaOfertaEmpleos, "id_categoria_ofertas", "titulo", oferta.id_categoria_ofertas);
            return View(oferta);
        }

        // GET: Ofertas_Categorias_/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oferta oferta = db.Ofertas.Find(id);
            if (oferta == null)
            {
                return HttpNotFound();
            }
            return View(oferta);
        }

        // POST: Ofertas_Categorias_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Oferta oferta = db.Ofertas.Find(id);
            db.Ofertas.Remove(oferta);
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
