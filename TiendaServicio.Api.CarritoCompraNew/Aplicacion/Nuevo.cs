using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicio.Api.CarritoCompraNew.Modelo;
using TiendaServicio.Api.CarritoCompraNew.Persistencia;

namespace TiendaServicio.Api.CarritoCompraNew.Aplicacion
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public DateTime FechaCreacionSession { get; set; }

            public List<string> ProductoLista { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly CarritoContexto _contexto;
            public Manejador(CarritoContexto contexto)
            {
                _contexto = contexto;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var carritoSesion = new CarritoSession
                {
                    FechaCreacion = request.FechaCreacionSession
                };

                _contexto.CarritoSession.Add(carritoSesion);
                var value = await _contexto.SaveChangesAsync();

                if (value == 0)
                {
                    throw new Exception("Error en la insercion del carrito de compreas");
                }
                int id = carritoSesion.CarritoSessionId;

                foreach (var obj in request.ProductoLista)
                {
                    var detalleSesion = new CarritoSessionDetalle
                    {
                        FechaCreacion = DateTime.Now,
                        CarritoSessionId = id,
                        ProductoSeleccionado = obj
                    };

                    _contexto.carritoSessionDetalle.Add(detalleSesion);
                }

                value = await _contexto.SaveChangesAsync();

                if (value > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo inesrtar el detalle del carrito de comprar");
            }
        }
    }
}
