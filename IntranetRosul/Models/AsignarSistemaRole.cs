﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntranetRosul.Models
{
    public class AsignarSistemaRole
    {
        [Key]
        public int Id { get; set; }
        public int ARoleId {get; set;}
        public int SistemaId { get; set; }

        public virtual ARole ARoles { get; set; }
        public virtual Sistema Sistemas { get; set;  }

    }
}