﻿using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using p3p1_bolsa_trabajo_new.Models;
using System.Dynamic;
using PagedList;
using PagedList.Mvc;
using System;

namespace p3p1_bolsa_trabajo_new.Controllers
{
    public class OfertasController : Controller
    {
        private p3p1BolsaTrabajoEntitiesCategoriaOfertas db = new p3p1BolsaTrabajoEntitiesCategoriaOfertas();
        private p3p1BolsaTrabajoEntitiesConfiguration configDb = new p3p1BolsaTrabajoEntitiesConfiguration();

        // GET: Ofertas
        public ActionResult Index()
        {
            IOrderedQueryable<Oferta> ofertas = from o in db.Ofertas where o.activo == true orderby o.fecha_posteo descending select o;
            IOrderedQueryable<categoriaOfertaEmpleo> categorias = from c in db.categoriaOfertaEmpleos orderby c.id_categoria_ofertas select c;
            dynamic ofertas_categorias = new ExpandoObject();
            ofertas_categorias.Ofertas = ofertas;
            ofertas_categorias.Categorias = categorias;
            var result = (from s in configDb.Configuraciones where s.nombre == "cantidad registros inicio" select s.valor_configuracion).First();
            ofertas_categorias.rows2show = result;
            return View("Index", ofertas_categorias);
        }

        // GET: Ofertas/Details/5
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
            return View("Details", oferta);
        }

        // GET: Ofertas
        public ActionResult IndexAdmin()
        {
            if(Session["id_usuarios"] != null) { 
                IOrderedQueryable<Oferta> ofertas = from o in db.Ofertas orderby o.fecha_posteo descending select o;
                IOrderedQueryable<categoriaOfertaEmpleo> categorias = from c in db.categoriaOfertaEmpleos orderby c.id_categoria_ofertas select c;
                dynamic ofertas_categorias = new ExpandoObject();
                ofertas_categorias.Ofertas = ofertas;
                ofertas_categorias.Categorias = categorias;
                var result = (from s in configDb.Configuraciones where s.nombre == "cantidad registros inicio" select s.valor_configuracion).First();
                ofertas_categorias.rows2show = result;
                return View("IndexAdmin", ofertas_categorias);
            }
            else
            {
                ViewBag.ErrorMessage = "Please Login";
                return RedirectToAction("Login", "Login");
            }
        }

        // GET: Ofertas/Details/5
        public ActionResult DetailsAdmin(int? id)
        {
            if (Session["id_usuarios"] != null)
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
                return View("DetailsAdmin", oferta);
            }
            else
            {
                ViewBag.ErrorMessage = "Please Login";
                return RedirectToAction("Login", "Login");
            }
        }

        public ActionResult ViewAll(int? category_id, int? page)
        {
            if (Session["id_usuarios"] != null)
            {
                IOrderedQueryable<Oferta> ofertas = from o in db.Ofertas where o.id_categoria_ofertas == category_id orderby o.fecha_posteo descending select o;
                IOrderedQueryable<categoriaOfertaEmpleo> categorias = from c in db.categoriaOfertaEmpleos where c.id_categoria_ofertas == category_id orderby c.id_categoria_ofertas select c;
                dynamic ofertas_categorias = new ExpandoObject();
                int rows2display = 20;
                ofertas_categorias.Ofertas = ofertas.ToPagedList(page ?? 1, rows2display);
                ofertas_categorias.Categorias = categorias;
                return View("ViewAll", ofertas_categorias);
            }
            else
            {
                ViewBag.ErrorMessage = "Please Login";
                return RedirectToAction("Login", "Login");
            }
        }

        public ActionResult ViewAllUser(int? category_id, int? page)
        {
            IOrderedQueryable<Oferta> ofertas = from o in db.Ofertas where o.id_categoria_ofertas == category_id orderby o.fecha_posteo descending select o;
            IOrderedQueryable<categoriaOfertaEmpleo> categorias = from c in db.categoriaOfertaEmpleos where c.id_categoria_ofertas == category_id orderby c.id_categoria_ofertas select c;
            dynamic ofertas_categorias = new ExpandoObject();
            int rows2display = 2;
            ofertas_categorias.Ofertas = ofertas.ToPagedList(page ?? 1, rows2display);
            ofertas_categorias.Categorias = categorias;
            return View("ViewAllUser", ofertas_categorias);
        }

        // GET: Ofertas/Create
        public ActionResult Create()
        {
            ViewBag.id_categoria_ofertas = new SelectList(db.categoriaOfertaEmpleos, "id_categoria_ofertas", "titulo");
            return View();
        }

        // POST: Ofertas/Create
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

        // GET: Ofertas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["id_usuarios"] != null)
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
            else
            {
                ViewBag.ErrorMessage = "Please Login";
                return RedirectToAction("Login", "Login");
            }
        }

        // POST: Ofertas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_ofertas,titulo,descripcion,fecha_posteo,activo,id_categoria_ofertas,ubicacion,posicion,nombre_empresa")] Oferta oferta)
        {
            if (Session["id_usuarios"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(oferta).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("IndexAdmin");
                }
                ViewBag.id_categoria_ofertas = new SelectList(db.categoriaOfertaEmpleos, "id_categoria_ofertas", "titulo", oferta.id_categoria_ofertas);
                return View(oferta);
            }
            else
            {
                ViewBag.ErrorMessage = "Please Login";
                return RedirectToAction("Login", "Login");
            }
        }

        // GET: Ofertas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["id_usuarios"] != null)
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
            else
            {
                ViewBag.ErrorMessage = "Please Login";
                return RedirectToAction("Login", "Login");
            }
        }

        // POST: Ofertas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["id_usuarios"] != null)
            {
                Oferta oferta = db.Ofertas.Find(id);
                db.Ofertas.Remove(oferta);
                db.SaveChanges();
                return RedirectToAction("IndexAdmin");
            }
            else
            {
                ViewBag.ErrorMessage = "Please Login";
                return RedirectToAction("Login", "Login");
            }
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
