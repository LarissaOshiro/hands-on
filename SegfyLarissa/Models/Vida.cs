using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SegfyLarissa.Models
{
    public class Vida : Seguro
    {
        [Required]
        public string CPF { get; set; }
    }
}