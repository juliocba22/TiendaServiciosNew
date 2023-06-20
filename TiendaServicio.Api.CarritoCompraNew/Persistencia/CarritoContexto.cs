using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaServicio.Api.CarritoCompraNew.Modelo;

namespace TiendaServicio.Api.CarritoCompraNew.Persistencia
{
    public class CarritoContexto : DbContext
    {
        public CarritoContexto(DbContextOptions<CarritoContexto> options) : base(options) { }
        
        public DbSet<CarritoSession> CarritoSession { get; set; }
        public DbSet<CarritoSessionDetalle> carritoSessionDetalle { get; set; }
    }
}
