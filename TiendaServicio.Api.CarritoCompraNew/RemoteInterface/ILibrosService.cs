using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaServicio.Api.CarritoCompraNew.RemoteModel;

namespace TiendaServicio.Api.CarritoCompraNew.RemoteInterface
{
    public interface ILibrosService
    {
        Task<(bool resultado,LibroRemote Libro , string ErrorMessage)> GetLibro(Guid LibroId);
    }
}
