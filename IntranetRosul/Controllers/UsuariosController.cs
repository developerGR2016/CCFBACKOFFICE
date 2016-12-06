using IntranetRosul.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntranetRosul.Controllers
{
    public class UsuariosController : Controller
    {
  


        // GET: Usuarios
        public ActionResult Index()
        {
            var context = new ApplicationDbContext();
            var users = context.Users.ToList();
            
            return View(users);
        }
    }
}