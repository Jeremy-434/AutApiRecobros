using AutApiRecobros.Models;

namespace AutApiRecobros.Repository.Interfaces
{
    public interface IAliadosRepository
    {
        Task<Aliados> GetAliadosById(int id);
        Task<IEnumerable<Aliados>> GetAllAliados();
        Task<Aliados> CreateAliado(Aliados aliado);
        Task<Aliados> UpdateAliado(Aliados aliado);
        Task<Aliados> DeleteAliado(Aliados aliado);
    }
}
