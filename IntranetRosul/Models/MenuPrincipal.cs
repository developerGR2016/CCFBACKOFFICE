using IntranetRosul.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntranetRosul.Models
{
    public class MenuPrincipal
    {
        public static List<Menu> GetMenus() {

                using(ApplicationDbContext context = new ApplicationDbContext()){
                return context.Menus.ToList();
            }
        }
    }
}