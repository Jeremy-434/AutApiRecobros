using AutApiRecobros.Models;
using AutApiRecobros.Repository;
using AutApiRecobros.Services.Interfaces;

namespace AutApiRecobros.Services
{
    public class CierreMesService : ICierreMesService
    {
        public readonly CierreMesRepository _repository;
        public CierreMesService(CierreMesRepository repository)
        {
            this._repository = repository;
        }
        public async Task<IEnumerable<CierreMes>> GetAllCierreMes()
        {
            return await _repository.GetAllCierreMes();
        }  
        public async Task<CierreMes> CreateCierreMes(CierreMes cierreMes)
        {
            return await _repository.CreateCierreMes(cierreMes);
        }
        public async Task<CierreMes> DeleteCierreMes(int id)
        {
            CierreMes cierreMes = await _repository.GetCierreMesById(id);
            if(cierreMes != null)
            {
                return await _repository.DeleteCierreMes(cierreMes);
            }
            return cierreMes;
        }
    }
}
