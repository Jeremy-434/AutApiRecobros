using AutApiRecobros.Models;
using AutApiRecobros.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace AutApiRecobros.Repository
{
    public class ServiciosRepository : IServiciosRepository
    {
        private readonly MyDbContext _context;

        public ServiciosRepository(MyDbContext context)
        {
            this._context = context;
        }

        public async Task<Servicios> GetServicioById(int id)
        {
            Servicios servicio = await _context.Servicios.FindAsync(id);
            return servicio;
        }
        public async Task<IEnumerable<Servicios>> GetAllServicios()
        {
            return await _context.Servicios.ToListAsync();
        }
        public async Task<Servicios> CreateServicio(Servicios servicio)
        {
            _context.Servicios.Add(servicio);
            await _context.SaveChangesAsync();
            return servicio;
        }
        public async Task<Servicios> UpdateServicio(Servicios servicio)
        {
            _context.Servicios.Update(servicio);
            await _context.SaveChangesAsync();
            return servicio;
        }
        public async Task DeleteServicio(Servicios servicio)
        {
            _context.Servicios.Remove(servicio);
            await _context.SaveChangesAsync();
        }
    }
}
