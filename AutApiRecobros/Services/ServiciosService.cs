using AutApiRecobros.Models;
using AutApiRecobros.Repository;

using AutApiRecobros.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AutApiRecobros.Services
{

    public class ServiciosService : IServiciosService
    {
        public readonly ServiciosRepository _repository;

        public ServiciosService(ServiciosRepository repository)
        {
            this._repository = repository;
        }

        public async Task<Servicios> GetServicioById(int id)
        {
            return await _repository.GetServicioById(id);
        }
        public async Task<IEnumerable<Servicios>> GetAllServicios()
        {
            return await _repository.GetAllServicios();
        }
        public async Task<Servicios> CreateServicio(Servicios servicio)
        {
            return await _repository.CreateServicio(servicio);
        }
        public async Task<Servicios> UpdateServicio(Servicios servicio)
        {
            var existingServicio = await _repository.GetServicioById(servicio.IdServicio);
            if (existingServicio == null)
            {
                throw new ArgumentException("Servicio not found");
            }

            existingServicio.NombreServicio = servicio.NombreServicio ?? existingServicio.NombreServicio;
            existingServicio.Descripcion = servicio.Descripcion ?? existingServicio.Descripcion;
            existingServicio.Driver = servicio.Driver ?? existingServicio.Driver;
            existingServicio.ResponsableReporte = servicio.ResponsableReporte ?? existingServicio.ResponsableReporte;
            existingServicio.ClaseActividad = servicio.ClaseActividad ?? existingServicio.ClaseActividad;
            existingServicio.ClaseCosto = servicio.ClaseCosto ?? existingServicio.ClaseCosto;
            existingServicio.PorcentajeComparacion = servicio.PorcentajeComparacion ?? existingServicio.PorcentajeComparacion;

            var updatedServicio = await _repository.UpdateServicio(existingServicio);

            return updatedServicio;
        }
        public async Task DeleteServicio(int id)
        {
            var servicio = await _repository.GetServicioById(id);
            if (servicio != null)
            {
                await _repository.DeleteServicio(servicio);
            }
        }
    }
}
