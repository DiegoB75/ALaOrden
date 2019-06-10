using System.Collections.Generic;
using TFinal.Domain;

namespace TFinal.Service
{
    public interface IDireccionService : ICrudService<Direccion>
    {
        List<Direccion> ListByUsuario(int idUsuario);
    }
}