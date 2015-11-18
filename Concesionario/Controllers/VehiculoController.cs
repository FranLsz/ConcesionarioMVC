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
            ViewBag.idTipo = id;
            return View(db.Vehiculo.Where(o => o.tipo == id));
        }
        [HttpPost]
        public ActionResult Alta(Vehiculo model)
        {
            db.Vehiculo.Add(model);
            db.SaveChanges();

            return Json(model);

        }
        public ActionResult Buscar(string value, string filtro, int tipo)
        {
            switch (filtro)
            {
                case "matricula":
                    var data1 = db.Vehiculo.
                        Where(o => o.tipo == tipo && o.matricula.Contains(value));
                    return PartialView("_listadoVehiculo", data1);

                case "marca":

                    var data2 = db.Vehiculo.
                        Where(o => o.tipo == tipo && o.marca.Contains(value));
                    return PartialView("_listadoVehiculo", data2);

                default:
                    return PartialView("_listadoVehiculo", db.Vehiculo);
            }
        }
    }
}