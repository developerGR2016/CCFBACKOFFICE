using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntranetRosul.Models
{
    public class AsignarOpcionRole
    {
        [Key]
        public int Id { get; set; }
        public int ARoleId { get; set;}
        public int OpcionId { get; set; }

        public virtual ARole ARoles { get; set; }
      
    }
}