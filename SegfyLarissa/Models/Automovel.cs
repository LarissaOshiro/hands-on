using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SegfyLarissa.Models
{
    public class Automovel : Seguro
    {
        [Required]
        public string Placa { get; set; }
    }
}