using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntranetRosul.Controllers
{
    public class JuridicoController : Controller
    {
        // GET: Juridico
        public ActionResult Index()
        {
            return View();
        }

        // GET: Bancos
        public ActionResult Bancos() {

            return View();

        }
    }
}