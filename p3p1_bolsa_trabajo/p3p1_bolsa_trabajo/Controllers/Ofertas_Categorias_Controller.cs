using System.Data;
using System.Dynamic;
using System.Linq;
using System.Net;
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
