using IntranetRosul.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntranetRosul.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var DATOS = db.Users.Single(t => t.Email == User.Identity.Name);
            ViewBag.Nombres = DATOS.Primer_Nombre + " " + DATOS.Segundo_Nombre + " " + DATOS.Primer_Apellido + " " + DATOS.Segundo_Apellido;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult _MainMenu()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            return View(db.Menus.ToList());
        }
    }

   

    public class LayoutInjecterAttribute : ActionFilterAttribute
    {
        private readonly string _masterName;
        public LayoutInjecterAttribute(string masterName)
        {
            _masterName = masterName;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            var result = filterContext.Result as ViewResult;
            if (result != null)
            {
                result.MasterName = _masterName;
            }
        }
    }
}