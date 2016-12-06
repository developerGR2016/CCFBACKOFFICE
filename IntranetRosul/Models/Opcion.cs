using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntranetRosul.Models
{
    public class Opcion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Path { get; set; }
        public int MenuId { get; set; }
        public int Orden { get; set;  }
        public int Nivel { get; set; }
        public int OpcionPadreId { get; set; }

        public virtual Menu Menus { get; set; }
    }
}