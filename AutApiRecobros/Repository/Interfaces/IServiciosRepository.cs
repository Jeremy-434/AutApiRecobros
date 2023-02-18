using AutApiRecobros.Models;

namespace AutApiRecobros.Repository.Interfaces
{
    public interface IServiciosRepository
    {
        Task<Servicios> GetServicioById(int id);
        Task<IEnumerable<Servicios>> GetAllServicios();
        Task<Servicios> CreateServicio(Servicios servicio);
        Task<Servicios> UpdateServicio(Servicios servicio);
        Task DeleteServicio(Servicios servicio);
    }
}
