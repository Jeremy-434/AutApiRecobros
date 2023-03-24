using AutApiRecobros.Models;

namespace AutApiRecobros.Services.Interfaces
{
    public interface ICierreMesService
    {
        Task<IEnumerable<CierreMes>> GetAllCierreMes();
        Task<CierreMes> CreateCierreMes(CierreMes cierreMes);
        Task<CierreMes> DeleteCierreMes(int id);
    }
}
