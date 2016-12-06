using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntranetRosul.Models
{
    public class Sistema
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Sistema")]
        public string Name { get; set; }
        [Display(Name = "Descripción")]
        public string Description { get; set;  }

    }
}