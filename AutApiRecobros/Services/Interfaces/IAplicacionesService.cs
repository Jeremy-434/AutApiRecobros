using AutApiRecobros.Models;

namespace AutApiRecobros.Services.Interfaces
{
    public interface IAplicacionesService
    {
        Task<Aplicaciones> GetAplicacionById(int id);
        Task<IEnumerable<Aplicaciones>> GetAllAplicaciones();
        Task<Aplicaciones> CreateAplicacion(Aplicaciones aplicacion);
        Task<Aplicaciones> UpdateAplicacion(Aplicaciones aplicacion);
        Task<Aplicaciones> DeleteAplicacion(int id);
    }
}
