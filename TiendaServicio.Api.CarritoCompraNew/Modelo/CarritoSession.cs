﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaServicio.Api.CarritoCompraNew.Modelo
{
    public class CarritoSession
    {
        public int CarritoSessionId { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public ICollection<CarritoSessionDetalle> ListaDetalle { get; set; }
    }
}
