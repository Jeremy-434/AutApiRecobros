using AutApiRecobros.Models;

namespace AutApiRecobros.Services.Interfaces
{
    public interface IAliadosService
    {
        Task<Aliados> GetAliadosById(int id);
        Task<IEnumerable<Aliados>> GetAllAliados();
        Task<Aliados> CreateAliado(Aliados aliado);
        Task<Aliados> UpdateAliado(Aliados aliado);
        Task<Aliados> DeleteAliado(int id);
    }
}
