using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntranetRosul.Models
{
    public class AsignarRolSistema
    {

        [Key]
        public int Id { get; set; }
        [Display(Name = "SISTEMA")]
        public string SistemaId { get; set; }
        [Display(Name = "ROLE")]
        public int ARoleId { get; set; }

        public virtual Sistema Sistemas  { get; set; }
        public virtual ARole ARoles  { get; set; }
    }
}