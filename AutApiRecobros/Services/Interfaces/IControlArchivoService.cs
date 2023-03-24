using AutApiRecobros.Models;

namespace AutApiRecobros.Services.Interfaces
{
    public interface IControlArchivoService
    {
        Task<IEnumerable<ControlArchivos>> GetAll();
        Task<ControlArchivos> CreateControlArchivo(ControlArchivos control);
    }
}
