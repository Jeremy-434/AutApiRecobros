using AutApiRecobros.Models;
using AutApiRecobros.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AutApiRecobros.Repository
{
    public class AliadosRepository : IAliadosRepository
    {
        public readonly MyDbContext _dbContext;

        public AliadosRepository(MyDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<Aliados> GetAliadosById(int id)
        {
            return await _dbContext.Aliados.FindAsync(id);
        }
        public async Task<IEnumerable<Aliados>> GetAllAliados()
        {
            return await _dbContext.Aliados.ToListAsync();
        }
        public async Task<Aliados> CreateAliado(Aliados aliado)
        {
            _dbContext.Aliados.Add(aliado);
            await _dbContext.SaveChangesAsync();
            return aliado;
        }
        public async Task<Aliados> UpdateAliado(Aliados aliado)
        {
            _dbContext.Aliados.Update(aliado);
            await _dbContext.SaveChangesAsync();
            return aliado;
        }
        public async Task<Aliados> DeleteAliado(Aliados aliado)
        {
            _dbContext.Aliados.Remove(aliado);
            await _dbContext.SaveChangesAsync();
            return aliado;
        }
    }
}
