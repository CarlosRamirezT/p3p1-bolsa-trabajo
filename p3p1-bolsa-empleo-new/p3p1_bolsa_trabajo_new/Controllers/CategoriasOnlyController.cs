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
    public class CategoriasOnlyController : Controller
    {
        private p3p1BolsaTrabajoEntitiesCategoriaOfertas db = new p3p1BolsaTrabajoEntitiesCategoriaOfertas();

        // GET: CategoriasOnly
        public ActionResult Index()
        {
            if (Session["id_usuarios"] != null)
            {
                return View(db.categoriaOfertaEmpleos.ToList());
            }
            else
            {
                ViewBag.ErrorMessage = "Please Login";
                return RedirectToAction("Login", "Login");
            }
        }

        // GET: CategoriasOnly/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["id_usuarios"] != null)
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
            else
            {
                ViewBag.ErrorMessage = "Please Login";
                return RedirectToAction("Login", "Login");
            }
        }

        // GET: CategoriasOnly/Create
        public ActionResult Create()
        {
            if (Session["id_usuarios"] != null)
            {
                return View();
            }
            else
            {
                ViewBag.ErrorMessage = "Please Login";
                return RedirectToAction("Login", "Login");
            }
        }

        // POST: CategoriasOnly/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_categoria_ofertas,titulo")] categoriaOfertaEmpleo categoriaOfertaEmpleo)
        {
            if (Session["id_usuarios"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.categoriaOfertaEmpleos.Add(categoriaOfertaEmpleo);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(categoriaOfertaEmpleo);
            }
            else
            {
                ViewBag.ErrorMessage = "Please Login";
                return RedirectToAction("Login", "Login");
            }
        }

        // GET: CategoriasOnly/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["id_usuarios"] != null)
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
            else
            {
                ViewBag.ErrorMessage = "Please Login";
                return RedirectToAction("Login", "Login");
            }
        }

        // POST: CategoriasOnly/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_categoria_ofertas,titulo")] categoriaOfertaEmpleo categoriaOfertaEmpleo)
        {
            if (Session["id_usuarios"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(categoriaOfertaEmpleo).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(categoriaOfertaEmpleo);
            }
            else
            {
                ViewBag.ErrorMessage = "Please Login";
                return RedirectToAction("Login", "Login");
            }
        }

        // GET: CategoriasOnly/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["id_usuarios"] != null)
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
            else
            {
                ViewBag.ErrorMessage = "Please Login";
                return RedirectToAction("Login", "Login");
            }
        }

        // POST: CategoriasOnly/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["id_usuarios"] != null)
            {
                categoriaOfertaEmpleo categoriaOfertaEmpleo = db.categoriaOfertaEmpleos.Find(id);
                db.categoriaOfertaEmpleos.Remove(categoriaOfertaEmpleo);
                db.SaveChanges();
                return RedirectToAction("Index");
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
