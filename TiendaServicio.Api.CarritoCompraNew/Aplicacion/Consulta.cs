using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicio.Api.CarritoCompraNew.Persistencia;
using TiendaServicio.Api.CarritoCompraNew.RemoteInterface;

namespace TiendaServicio.Api.CarritoCompraNew.Aplicacion
{
    public class Consulta
    {
        public class Ejecuta:IRequest<CarritoDto>{
            public int CarritoSessionId { get; set; }
         }

        public class Manejador : IRequestHandler<Ejecuta, CarritoDto>
        {
            private readonly CarritoContexto _contexto;
            private readonly ILibrosService _libroService;

            public Manejador(CarritoContexto contexto , ILibrosService librosService)
            {
                _contexto = contexto;
                _libroService = librosService;
            }
            public async Task<CarritoDto> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var carritoSession =await _contexto.CarritoSession.FirstOrDefaultAsync(x => x.CarritoSessionId == request.CarritoSessionId);
                var carritoSessionDetalle = await _contexto.carritoSessionDetalle.Where(x => x.CarritoSessionId == request.CarritoSessionId).ToListAsync();
                var listaCarritoDto = new List<CarritoDetalleDto>();                
                foreach (var libro in carritoSessionDetalle)
                {
                    var response = await _libroService.GetLibro(new Guid(libro.ProductoSeleccionado));
                    if (response.resultado)
                    {
                        var objetoLibro = response.Libro;
                        var carritoDetalle = new CarritoDetalleDto
                        {
                            TituloLibro = objetoLibro.Titulo,
                            FechaPublicacion = objetoLibro.FechaPublicacion,
                            LibroId = objetoLibro.LibreriaMaterialId
                        };
                        listaCarritoDto.Add(carritoDetalle);
                    }
                }
                var carritoSessionDto = new CarritoDto
                {
                    CarritoId = carritoSession.CarritoSessionId,
                    FechaCreacionSesion = carritoSession.FechaCreacion,
                    ListaProducto = listaCarritoDto
                };

                return carritoSessionDto;
            }
        }
    }
}
