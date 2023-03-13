using AutApiRecobros.Models;
using AutApiRecobros.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AutApiRecobros.Repository
{
    public class ControlArchivoRepository : IControlArchivoRepository
    {
        public readonly MyDbContext _dbContext;
        public ControlArchivoRepository(MyDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<IEnumerable<ControlArchivos>> GetAll()
        {
            return await _dbContext.ControlArchivos
                .Include(aliado => aliado.IdAliadoNavigation)
                .ToListAsync();
        }
        public async Task<ControlArchivos> CreateControlArchivo(ControlArchivos controlArchivo)
        {
            _dbContext.ControlArchivos.Add(controlArchivo);
            await _dbContext.SaveChangesAsync();
            return controlArchivo;
        }
    }
}
