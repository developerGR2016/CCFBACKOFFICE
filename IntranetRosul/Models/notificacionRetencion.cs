
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace IntranetRosul.Models
{
    public class notificacionRetencion
    {
        [Key]
        public int id { get; set; }
        [Display(Name="Factura")]   
        public string factura { get; set; }
        [Display(Name = "Monto")]
        public string montoF { get; set;  }
        [Display(Name = "Tipo de Documento")]
        public string tipo { get;  set; }
        [Display(Name = "No. Retención")]
        public string noDoc { get; set; }
        [Display(Name = "Monto de Retención")]
        public string montoR { get; set; }
        public string path { get; set; }
    }
}