using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using p3p1_bolsa_trabajo.Models;

namespace p3p1_bolsa_trabajo.Controllers
{
    public class Ofertas_Controller : Controller
    {
        [HttpGet]
        public ActionResult AddOfertas()
        {
            Oferta ofertaModel = new Oferta();
            return View(ofertaModel);
        }
        [HttpPost]
        public ActionResult AddOfertas(Oferta ofertaModel)
        {
            using (p3p1BolsaTrabajoEntities1 dbmodel = new p3p1BolsaTrabajoEntities1())
            {
                dbmodel.Ofertas.Add(ofertaModel);
                dbmodel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccesMessage = "Ingreso exitoso";
            return View("AddOfertas", new Oferta());
        }
    }
}