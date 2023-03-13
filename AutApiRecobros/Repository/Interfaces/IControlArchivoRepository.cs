using AutApiRecobros.Models;

namespace AutApiRecobros.Repository.Interfaces
{
    public interface IControlArchivoRepository
    {
        Task<IEnumerable<ControlArchivos>> GetAll();
        Task<ControlArchivos> CreateControlArchivo(ControlArchivos controlArchivo);
    }
}
