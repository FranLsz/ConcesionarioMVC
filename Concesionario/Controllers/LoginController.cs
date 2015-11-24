using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Concesionario.Models;
using Concesionario.Seguridad;
using Concesionario.Utilidades;

namespace Concesionario.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            //var c = ConfigurationManager.AppSettings["ClaveCifrado"];
            //var v = SeguridadUtilidades.Cifrar("fran@mail.com", c);

            return View();
        }

        [HttpPost]
        public ActionResult Index(Usuario model)
        {
            if (Membership.ValidateUser(model.username, model.password))
            {
                FormsAuthentication.RedirectFromLoginPage(model.username, false);
                return null;
            }

            return View(model);
        }

        public ActionResult LogOut()
        {

            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}