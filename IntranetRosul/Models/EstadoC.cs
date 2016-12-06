using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntranetRosul.Models
{
    public class EstadoC
    {
        public string orden { get; set; }
        public string saldolineaa2 { get; set; }
        public string SALDOX { get; set; }
        public string NO_ESTADO2 { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal ABONO2 { get; set; }
        public string TOTALFACT { get; set; }
        public string SaldoLineaa1 { get; set; }
        public string INI { get; set; }
        public string FIN { get; set; }
        public string Local { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}",
               ApplyFormatInEditMode = true)]
        public DateTime RefDate { get; set; }
        public string TIPO_DOCUMENTO { get; set; }
        public string NO_DOCUMENTO { get; set; }
        public string NO_RECIBO { get; set; }
        public string NO_FACTURA { get; set; }
        public string CURRENCY { get; set; }
        public string TIPO_CAMBIO { get; set; }
        public string TOTALFACTURA { get; set; }
        public string NO_series { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public string NO_ESTADO { get; set; }
        public decimal Cargo { get; set; }
        public string Abono { get; set; }
        public string AcumuladoFinal { get; set; }
        public string Saldo { get; set; }
        public string Vence { get; set; }
        public string FormaPago { get; set; }
        public string Notas { get; set; }
        public string TransId { get; set; }
        public string Line_ID { get; set; }
        public string Origen_Documento { get; set; }
        public string Cliente { get; set; }

        public string NombreCliente { get; set; }

        public string Cheque { get; set; }
        public string Moneda { get; set; }
        public string MontoCheque { get; set; }

        public string CuentaBanco { get; set; }
        public string Transaccion { get; set; }
        public string Fecha_FActura { get; set; }

       

    }
 
}