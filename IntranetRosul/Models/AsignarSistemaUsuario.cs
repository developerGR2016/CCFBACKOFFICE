using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IntranetRosul.Models
{
    public class AsignarSistemaUsuario
    {
        [Key]
        public int Id { get; set; }
        [Display (Name="USUARIO")]
        public string UserName { get; set; }
        [Display (Name="SISTEMA")]
        public int SistemaId { get; set; }

    
        public virtual Sistema Sistemas { get; set; }
   

    }
}