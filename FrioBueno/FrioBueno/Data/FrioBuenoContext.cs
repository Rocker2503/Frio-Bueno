using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FrioBueno.Models;

namespace FrioBueno.Models
{
    public class FrioBuenoContext : DbContext
    {
        public FrioBuenoContext (DbContextOptions<FrioBuenoContext> options)
            : base(options)
        {
        }

        public DbSet<FrioBueno.Models.Cliente> Cliente { get; set; }

        public DbSet<FrioBueno.Models.Carga> Carga { get; set; }

        public DbSet<FrioBueno.Models.DetalleCarga> DetalleCarga { get; set; }

        public DbSet<FrioBueno.Models.Producto> Producto { get; set; }

        public DbSet<FrioBueno.Models.ProductosParaDespacho> ProductosParaDespacho { get; set; }

        public DbSet<FrioBueno.Models.LotesParaDespacho> LotesParaDespacho { get; set; }

        public DbSet<AsocDespachoProductos> AsocDespachoProductos { get; set; }
        
        public DbSet<ClienteDespacho> ClienteDespachos { get; set; }

        public DbSet<Despacho> Despacho { get; set; }
    }
}
