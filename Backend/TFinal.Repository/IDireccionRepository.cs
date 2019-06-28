using System.Collections.Generic;
using TFinal.Domain;

namespace TFinal.Repository
{
    public interface IDireccionRepository : ICrudRepository<Direccion>
    {
                List<Direccion> ListByUsuario(int idUsuario);
    }
}