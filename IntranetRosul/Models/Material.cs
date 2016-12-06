using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntranetRosul.Models
{
    public class Material
    {
        public string COD_FAMILIA { get; set; }
        public string DES_FAMILIA { get; set; }
        public string COD_SUBFAMILIA { get; set; }
        public string DES_SUBFAMILIA { get; set; }
        public string COD_PROYECTO { get; set; }
        public string DES_PROYECTO { get; set; }
        public string COD_BODEGA{ get; set; }
        public string DES_BODEGA { get; set; }
        public string COD_DETALLE { get; set; }
        public string DES_DETALLE { get; set; }
        public string COD_UNIDAD { get; set; }
        public string DES_UNIDAD { get; set; }
        public string CAN_INICIAL { get; set; }
        public string CAN_ACTUAL { get; set; }
        public string FEC_INGRESO { get; set; }
        public string CANT_TOMA_FISICA { get; set; }
        public string COD_CUENTA { get; set; }
        public string DES_CUENTA { get; set; }
        public string MON_DETALLE { get; set; }
        public string CAN_MINIMO { get; set; }
        public string CAN_MAXIMO { get; set; }
        public string MON_BRUTO { get; set; }
    }
}