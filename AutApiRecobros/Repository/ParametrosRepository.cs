using AutApiRecobros.Models;
using AutApiRecobros.Repository.Interfaces;

namespace AutApiRecobros.Repository
{
    public class ParametrosRepository : IParametrosRepository
    {
        public readonly MyDbContext _dbContext;
        public ParametrosRepository(MyDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<Parametros> GetParametroById(int id)
        {
            return await _dbContext.Parametros.FindAsync(id);
        }
        public async Task<Parametros> UpdateParametro(Parametros parametro)
        {
            _dbContext.Parametros.Update(parametro);
            await _dbContext.SaveChangesAsync();
            return parametro;
        }
    }
}
