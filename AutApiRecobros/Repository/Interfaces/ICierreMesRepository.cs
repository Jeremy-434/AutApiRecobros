using AutApiRecobros.Models;

namespace AutApiRecobros.Repository.Interfaces
{
    public interface ICierreMesRepository
    {
        Task<IEnumerable<CierreMes>> GetAllCierreMes();
        Task<CierreMes> GetCierreMesById(int id);
        Task<CierreMes> CreateCierreMes(CierreMes cierreMes);
        Task<CierreMes> DeleteCierreMes(CierreMes cierreMes);
    }
}
