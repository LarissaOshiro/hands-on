using SegfyLarissa.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SegfyLarissa.Context
{
    public class SeguroContext : DbContext
    {
        public DbSet<Seguro> Seguros { get; set; }
    }
}