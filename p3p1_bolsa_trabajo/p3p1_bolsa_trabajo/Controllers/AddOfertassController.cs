using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using p3p1_bolsa_trabajo.Models;

namespace p3p1_bolsa_trabajo.Models
{
    public class AddOfertassController : Controller
    {
        [HttpGet]
        public ActionResult Aofertas()
        {
            Oferta ofertaModel = new Oferta();
            return View(ofertaModel);
        }
        [HttpPost]
        public ActionResult Aofertas(Oferta ofertaModel)
        {
            using (p3p1BolsaTrabajoEntities1 dbmodel = new p3p1BolsaTrabajoEntities1())
            {
                dbmodel.Ofertas.Add(ofertaModel);
                dbmodel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccesMessage = "Ingresado Exitosamente";
            return View("Aofertas", new Oferta());
        }
    }
}