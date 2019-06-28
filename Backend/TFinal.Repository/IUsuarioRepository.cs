using TFinal.Domain;

namespace TFinal.Repository
{
    public interface IUsuarioRepository : ICrudRepository<Usuario>
    {
        Usuario FindByApodoOrEmail(Usuario entity);    
    }
}