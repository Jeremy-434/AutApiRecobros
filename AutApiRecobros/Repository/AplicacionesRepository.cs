using AutApiRecobros.Models;
using AutApiRecobros.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AutApiRecobros.Repository
{
    public class AplicacionesRepository : IAplicacionesRepository
    {
        public readonly MyDbContext _context;

        public AplicacionesRepository(MyDbContext context)
        {
            this._context = context;
        }
        public async Task<Aplicaciones> GetAplicacionById(int id)
        {
            return await _context.Aplicaciones
                .Include(servicio => servicio.IdServicioNavigation)
                .Include(aliado => aliado.IdAliadoNavigation)
                .Where(aplicacion => aplicacion.IdAplicacion == id)
                .FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Aplicaciones>> GetAllAplicaciones()
        {
            return await _context.Aplicaciones
                .Include(servicio => servicio.IdServicioNavigation)
                .Include(aliado => aliado.IdAliadoNavigation)
                .ToListAsync();
        }
        public async Task<Aplicaciones> CreateAplicacion(Aplicaciones aplicacion)
        {
            _context.Aplicaciones.Add(aplicacion);
            await _context.SaveChangesAsync();
            return aplicacion;
        }
        public async Task<Aplicaciones> UpdateAplicacion(Aplicaciones aplicacion)
        {
            _context.Aplicaciones.Update(aplicacion);
            await _context.SaveChangesAsync();
            return aplicacion;
        }
        public async Task<Aplicaciones> DeleteAplicacion(Aplicaciones aplicacion)
        {
            _context.Aplicaciones.Remove(aplicacion);
            await _context.SaveChangesAsync();
            return aplicacion;
        }
    }
}
