using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Concesionario.Models;

namespace Concesionario.Controllers
{
    public class VehiculoController : Controller
    {
        Concesionario15Entities db = new Concesionario15Entities();

        // GET: Vehiculo
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ListadoPorTipo(int id)
        {

            return View(db.Vehiculo.Where(o=>o.tipo == id));
        }
    }
}