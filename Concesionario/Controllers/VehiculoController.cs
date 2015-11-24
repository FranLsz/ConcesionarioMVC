using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Concesionario.Models;

namespace Concesionario.Controllers
{
    [Authorize]
    public class VehiculoController : Controller
    {
        ConcesionarioEntities db = new ConcesionarioEntities();

        // GET: Vehiculo
       /* public ActionResult Index()
        {
            return View();
        }*/


        public ActionResult ListadoPorTipo(int id)
        {
            ViewBag.idTipo = id;
            return View(db.Vehiculo.Where(o => o.idTipo == id));
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
            var data = db.Vehiculo.Where(o => o.idTipo == tipo);
            switch (filtro)
            {
                case "matricula":
                    data = data.Where(o => o.matricula.Contains(value));
                    break;
                case "marca":
                    data = data.Where(o => o.marca.Contains(value));
                    break;
            }
            return PartialView("_listadoVehiculo", data);
        }

        public ActionResult Eliminar(int id)
        {
            var model = db.Vehiculo.FirstOrDefault(o => o.id == id);

            if (model != null)
            {
                db.Vehiculo.Remove(model);
                db.SaveChanges();
                return Json(model, JsonRequestBehavior.AllowGet);
            }

            return HttpNotFound();

        }
    }
}