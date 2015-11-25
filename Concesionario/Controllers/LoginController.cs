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
                //se llama una vez y se borra
                TempData["miVar"] = DateTime.Now;


                Session["horaLogin"] = DateTime.Now;
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

        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registro(Usuario model)
        {
            //TEMPORAL
            using (var db = new ConcesionarioEntities())
            {
                var clave = ConfigurationManager.AppSettings["ClaveCifrado"];

                model.email = SeguridadUtilidades.Cifrar(model.email, clave);

                model.password = SeguridadUtilidades.GetSha1(model.password);
                try
                {
                    db.Usuario.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("Index", model);
                }
                catch (Exception e)
                {
                    return View(model);
                }
            }

            return View(model);
        }
    }
}