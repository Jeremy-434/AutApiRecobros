using AutApiRecobros.Models;

namespace AutApiRecobros.Services.Interfaces
{
    public interface IServiciosService
    {
        Task<Servicios> GetServicioById(int id);
        Task<IEnumerable<Servicios>> GetAllServicios();
        Task<Servicios> CreateServicio(Servicios servicio);
        Task<Servicios> UpdateServicio(Servicios servicio);
        Task<Servicios> DeleteServicio(int id);
    }
}
