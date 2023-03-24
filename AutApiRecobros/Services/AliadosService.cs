using AutApiRecobros.Models;
using AutApiRecobros.Repository;
using AutApiRecobros.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AutApiRecobros.Services
{
    public class AliadosService : IAliadosService
    {
        public readonly AliadosRepository _repository;
        public AliadosService(AliadosRepository repository)
        {
            this._repository = repository;
        }
        public async Task<Aliados> GetAliadosById(int id)
        {
            return await _repository.GetAliadosById(id);
        }
        public async Task<IEnumerable<Aliados>> GetAllAliados()
        {
            return await _repository.GetAllAliados();
        }
        public async Task<Aliados> CreateAliado(Aliados aliado)
        {
            return await _repository.CreateAliado(aliado);
        }
        public async Task<Aliados> UpdateAliado(Aliados aliado)
        {
            Aliados oAliado = await _repository.GetAliadosById(aliado.IdAliado);
            if(oAliado == null)
            {
                throw new ArgumentException("Aliado not found");
            }
            oAliado.NombreAliado = aliado.NombreAliado ?? oAliado.NombreAliado;
            oAliado.Usuario = aliado.Usuario ?? oAliado.Usuario;
            oAliado.Estado = aliado.Estado ?? oAliado.Estado;
            oAliado.CorreoResponsable = aliado.CorreoResponsable ?? oAliado.CorreoResponsable;
            oAliado.Fecha = aliado.Fecha ?? oAliado.Fecha;

            Aliados updatedAliado = await _repository.UpdateAliado(oAliado);
            return updatedAliado;
        }
        public async Task<Aliados> DeleteAliado(int id)
        {
            Aliados oAliado = await _repository.GetAliadosById(id);
            if(oAliado != null)
            {
                return await _repository.DeleteAliado(oAliado);
            }
            return oAliado;
        }
    }
}
