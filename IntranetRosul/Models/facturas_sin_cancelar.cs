using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntranetRosul.Models
{
    public class facturas_sin_cancelar
    {

        public string NumAtCard { get; set; }
        public string Tipo_Documento { get; set; }
        public string JrnlMemo { get; set; }
        public string DocDate { get; set; }
        public string DocDueDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal DocTotal { get; set; }
        public string mes { get; set; }
        public string DocCur { get; set; }
    }

    
}