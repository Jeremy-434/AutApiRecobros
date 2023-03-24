using AutApiRecobros.Models;
using AutApiRecobros.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AutApiRecobros.Repository
{
    public class CierreMesRepository : ICierreMesRepository
    {
        public readonly MyDbContext _dbContext;
        public CierreMesRepository(MyDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<IEnumerable<CierreMes>> GetAllCierreMes()
        {
            return await _dbContext.CierreMes.ToListAsync();
        }
        public async Task<CierreMes> GetCierreMesById(int id)
        {
            return await _dbContext.CierreMes.FindAsync(id);
        }
        public async Task<CierreMes> CreateCierreMes(CierreMes cierreMes)
        {
            _dbContext.CierreMes.Add(cierreMes);
            await _dbContext.SaveChangesAsync();
            return cierreMes;
        }
        public async Task<CierreMes> DeleteCierreMes(CierreMes cierreMes)
        {
            _dbContext.CierreMes.Remove(cierreMes);
            await _dbContext.SaveChangesAsync();
            return cierreMes;
        }
    }
}
