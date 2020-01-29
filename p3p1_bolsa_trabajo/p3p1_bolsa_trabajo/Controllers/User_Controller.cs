using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using p3p1_bolsa_trabajo.Models;

namespace p3p1_bolsa_trabajo.Controllers
{
    public class User_Controller : Controller
    {

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            Usuario usuarioModel = new Usuario();
            return View(usuarioModel);
        }
        [HttpPost]
        public ActionResult AddOrEdit(Usuario usuarioModel)
        {
            using (Model_Usuarios dbmodel = new Model_Usuarios())
            {
                if (dbmodel.Usuarios.Any(x => x.email == usuarioModel.email))
                {
                    ViewBag.DuplicateMessage = "El email ingresado esta en uso";
                    return View("AddOrEdit", usuarioModel);
                }
                dbmodel.Usuarios.Add(usuarioModel);
                dbmodel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccesMessage = "Registro Exitoso";
            return View("AddOrEdit", new Usuario());
        }
    }
}