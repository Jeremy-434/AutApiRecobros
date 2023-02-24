using AutApiRecobros.Models;

namespace AutApiRecobros.Repository.Interfaces
{
    public interface IAplicacionesRepository
    {
        Task<Aplicaciones> GetAplicacionById(int id);
        Task<IEnumerable<Aplicaciones>> GetAllAplicaciones();
        Task<Aplicaciones> CreateAplicacion(Aplicaciones aplicacion);
        Task<Aplicaciones> UpdateAplicacion(Aplicaciones aplicacion);
        Task<Aplicaciones> DeleteAplicacion(Aplicaciones aplicacion);
    }
}
