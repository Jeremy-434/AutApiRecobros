using AutApiRecobros.Models;
using AutApiRecobros.Repository;
using AutApiRecobros.Services.Interfaces;

namespace AutApiRecobros.Services
{
    public class AplicacionesService : IAplicacionesService
    {
        public readonly AplicacionesRepository _repository;
        public AplicacionesService(AplicacionesRepository repository)
        {
            this._repository = repository;
        }
        public async Task<Aplicaciones> GetAplicacionById(int id)
        {
            return await _repository.GetAplicacionById(id);
        }
        public async Task<IEnumerable<Aplicaciones>> GetAllAplicaciones()
        {
            return await _repository.GetAllAplicaciones();
        }
        public async Task<Aplicaciones> CreateAplicacion(Aplicaciones aplicacion)
        {
            return await _repository.CreateAplicacion(aplicacion);
        }
        public async Task<Aplicaciones> UpdateAplicacion(Aplicaciones aplicacion)
        {
            var oAplicacion = await _repository.GetAplicacionById(aplicacion.IdAplicacion);
            if (oAplicacion == null)
            {
                throw new ArgumentException("Servicio not found");
            }

            oAplicacion.NombreAplicacion = aplicacion.NombreAplicacion ?? oAplicacion.NombreAplicacion;
            oAplicacion.Estado = aplicacion.Estado ?? oAplicacion.Estado;
            oAplicacion.NombreSegmento = aplicacion.NombreSegmento ?? oAplicacion.NombreSegmento;
            oAplicacion.IdServicio = aplicacion.IdServicio;
            oAplicacion.IdAliado = aplicacion.IdAliado;

            var updatedAplicacion = await _repository.UpdateAplicacion(oAplicacion);
            return updatedAplicacion;
        }
        public async Task<Aplicaciones> DeleteAplicacion(int id)
        {
            Aplicaciones oAplicacion = await _repository.GetAplicacionById(id);
            //var objResult = new { message = "DELETED", response = oAplicacion };
            if (oAplicacion != null)
            {
                return await _repository.DeleteAplicacion(oAplicacion);
            }
            return oAplicacion;
            
        }
    }
}
