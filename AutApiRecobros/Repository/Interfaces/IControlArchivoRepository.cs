using AutApiRecobros.Models;

namespace AutApiRecobros.Repository.Interfaces
{
    public interface IControlArchivoRepository
    {
        Task<IEnumerable<ControlArchivos>> GetAll();
        Task<ControlArchivos> GetControlArchivoById(int id);
        Task<ControlArchivos> CreateControlArchivo(ControlArchivos controlArchivo);
    }
}
