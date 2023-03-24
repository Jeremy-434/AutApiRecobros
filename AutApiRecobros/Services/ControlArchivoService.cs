using AutApiRecobros.Models;
using AutApiRecobros.Repository;
using AutApiRecobros.Services.Interfaces;

namespace AutApiRecobros.Services
{
    public class ControlArchivoService : IControlArchivoService
    {
        public readonly ControlArchivoRepository _repository;
        public ControlArchivoService(ControlArchivoRepository repository)
        {
            this._repository = repository;
        }
        public async Task<IEnumerable<ControlArchivos>> GetAll()
        {
            return await _repository.GetAll();
        }
        public async Task<ControlArchivos> CreateControlArchivo(ControlArchivos controlArchivo)
        {
            return await _repository.CreateControlArchivo(controlArchivo);
        }

    }
}
