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
            var oServicio = await _repository.GetServicioById(servicio.IdServicio);
            if (oServicio == null)
            {
                throw new ArgumentException("Servicio not found");
            }

            oServicio.NombreServicio = servicio.NombreServicio ?? oServicio.NombreServicio;
            oServicio.Descripcion = servicio.Descripcion ?? oServicio.Descripcion;
            oServicio.Driver = servicio.Driver ?? oServicio.Driver;
            oServicio.ResponsableReporte = servicio.ResponsableReporte ?? oServicio.ResponsableReporte;
            oServicio.ClaseActividad = servicio.ClaseActividad ?? oServicio.ClaseActividad;
            oServicio.ClaseCosto = servicio.ClaseCosto ?? oServicio.ClaseCosto;
            oServicio.PorcentajeComparacion = servicio.PorcentajeComparacion ?? oServicio.PorcentajeComparacion;

            var updatedServicio = await _repository.UpdateServicio(oServicio);
            return updatedServicio;
        }
        public async Task<Servicios> DeleteServicio(int id)
        {
            Servicios oServicio = await _repository.GetServicioById(id);
            if (oServicio != null)
            {
                return await _repository.DeleteServicio(oServicio);
            }
            return oServicio;
        }
    }
}
