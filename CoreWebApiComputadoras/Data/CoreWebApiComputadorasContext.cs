using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoreWebApiComputadoras.Modelo;

namespace CoreWebApiComputadoras.Data
{
    public class CoreWebApiComputadorasContext : DbContext
    {
        public CoreWebApiComputadorasContext (DbContextOptions<CoreWebApiComputadorasContext> options)
            : base(options)
        {
        }

        public DbSet<CoreWebApiComputadoras.Modelo.Computadoras> Computadoras { get; set; }
    }
}
