using AutApiRecobros.Models;

namespace AutApiRecobros.Repository.Interfaces
{
    public interface IParametrosRepository
    {
        Task<Parametros> GetParametroById(int id);
        Task<Parametros> UpdateParametro(Parametros parametro);
    }
}
