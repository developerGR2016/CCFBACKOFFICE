using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntranetRosul.Models
{
    public class Estado
    {
        public string NumAtCard{ get; set; }
        public string Tipo { get; set; }
        public string JrnlMemo { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}",
           ApplyFormatInEditMode = true)]
        public DateTime DocDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}",
           ApplyFormatInEditMode = true)]
        public DateTime DocDueDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}",
           ApplyFormatInEditMode = true)]
        public string Cargo { get; set; }
        public string Pago { get; set; }
    }
}