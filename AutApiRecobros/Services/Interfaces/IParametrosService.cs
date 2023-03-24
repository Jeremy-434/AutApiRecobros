using AutApiRecobros.Models;

namespace AutApiRecobros.Services.Interfaces
{
    public interface IParametrosService
    {
        Task<Parametros> GetParametroById(int id);
        Task<Parametros> UpdateParametro(Parametros parametro);
    }
}
