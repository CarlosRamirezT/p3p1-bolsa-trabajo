using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using p3p1_bolsa_trabajo.Models;

namespace p3p1_bolsa_trabajo.Controllers
{
    public class Login_Controller : Controller
    {
        // GET: Login_
        public ActionResult Loginn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Autherize(p3p1_bolsa_trabajo.Models.Usuario UserModel)
        {
            using (Model_Usuarios db = new Model_Usuarios())
            {
                var userDetails = db.Usuarios.Where(x => x.email == UserModel.email && x.password_usuario == UserModel.password_usuario).FirstOrDefault();
                if(userDetails == null)
                {
                    UserModel.LoginErrorMessage = "email o password invalida.";
                    return View("Loginn", UserModel);
                }
                else
                {
                    Session["id_usuarios"] = userDetails.id_usuarios;
                    return RedirectToAction("Index", "Ofertas_Categorias_");
                }
            }
            return View();
        }
    }
}