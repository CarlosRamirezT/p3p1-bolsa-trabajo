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
    public class ConfigurationController : Controller
    {
        private p3p1BolsaTrabajoEntitiesConfiguration db = new p3p1BolsaTrabajoEntitiesConfiguration();

        // GET: Configuration
        public ActionResult Index()
        {
            if (Session["id_usuarios"] != null)
            {
                return View(db.Configuraciones.ToList());
            }
            else
            {
                ViewBag.ErrorMessage = "Please Login";
                return RedirectToAction("Login", "Login");
            }
        }

        // GET: Configuration/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["id_usuarios"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Configuracione configuracione = db.Configuraciones.Find(id);
                if (configuracione == null)
                {
                    return HttpNotFound();
                }
                return View(configuracione);
            }
            else
            {
                ViewBag.ErrorMessage = "Please Login";
                return RedirectToAction("Login", "Login");
            }
        }

        // POST: Configuration/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_configuraciones,nombre,valor_configuracion")] Configuracione configuracione)
        {
            if (Session["id_usuarios"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(configuracione).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(configuracione);
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
