using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Concesionario.Models;

namespace Concesionario.Controllers
{
    [Authorize]
    public class TipoController : Controller
    {
        ConcesionarioEntities db = new ConcesionarioEntities();

        // GET: Tipo
        public ActionResult Index()
        {
            return View(db.Tipo);
        }

      

    }
}