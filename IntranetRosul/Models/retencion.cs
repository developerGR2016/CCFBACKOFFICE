using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntranetRosul.Models
{
    public class retencion
    {
        [Key]
        public int id { get; set; }
        public string factura { get; set; }
        public string montoF { get; set; }
        public string tipoDocmento { get; set; }
        public string retencionDoc { get; set; }
        public string montoR { get; set; }
    }
}