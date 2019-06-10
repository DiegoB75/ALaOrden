using TFinal.Domain;

namespace TFinal.Service
{
    public interface IUsuarioService : ICrudService<Usuario>
    {
        Usuario FindByApodoOrEmail(string search);
    }
}