using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaServicio.Api.CarritoCompraNew.Modelo
{
    public class CarritoSessionDetalle
    {
        public int CarritoSessionDetalleId { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string ProductoSeleccionado { get; set; }

        public int CarritoSessionId { get; set; }

        public CarritoSession carritoSession { get; set; }
    }
}
