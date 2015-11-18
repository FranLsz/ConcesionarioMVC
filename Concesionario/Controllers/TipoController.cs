using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Concesionario.Models;

namespace Concesionario.Controllers
{
    public class TipoController : Controller
    {
        Concesionario15Entities db = new Concesionario15Entities();

        // GET: Tipo
        public ActionResult Index()
        {
            return View(db.Tipo);
        }

        
    }
}