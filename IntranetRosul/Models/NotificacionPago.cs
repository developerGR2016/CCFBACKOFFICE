using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntranetRosul.Models
{
    public class NotificacionPago
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "Factura a Pagar")]
        public string factura { get; set; }
        [Display(Name = "Monto y/o saldo")]
        public string monedaF { get; set;  }
        [Display(Name = "Moneda")]
        public string montoSaldo { get; set;  }
        [Display(Name = "No Documento")]
        public string documento { get; set;  }
        [Display(Name = "Tipo Documento")]
        public string tipoDeposito { get; set;  }
        [Display(Name = "Numero de cuentas bancarias")]
        public string cuentaBancaria { get; set;  }
        [Display(Name = "Moneda")]
        public string monedaR { get; set; }
        [Display(Name = "Monto")]
        public string montoD { get; set; }
    }


}