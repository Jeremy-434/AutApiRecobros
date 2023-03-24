using AutApiRecobros.Models;
using AutApiRecobros.Repository;
using AutApiRecobros.Services.Interfaces;

namespace AutApiRecobros.Services
{
    public class ParametrosService : IParametrosService
    {
        public readonly ParametrosRepository _repository;
        public ParametrosService(ParametrosRepository repository)
        {
            this._repository = repository;
        }
        public async Task<Parametros> GetParametroById(int id)
        {
            return await _repository.GetParametroById(id);
        }
        public async Task<Parametros> UpdateParametro(Parametros parametro)
        {
            Parametros oParametros = await _repository.GetParametroById(parametro.IdParametro);
            if(oParametros == null)
            {
                throw new ArgumentException("Parametro no encontrado");
            }

            oParametros.RutaArchivosProcesar = parametro.RutaArchivosProcesar ?? oParametros.RutaArchivosProcesar;
            oParametros.BytesMaxArchivo = parametro.BytesMaxArchivo != null ? parametro.BytesMaxArchivo : oParametros.BytesMaxArchivo;
            oParametros.NumColumnasArchivo = parametro.NumColumnasArchivo != null ? parametro.NumColumnasArchivo : oParametros.NumColumnasArchivo;
            oParametros.NumMesesEliminacionHistorico = parametro.NumMesesEliminacionHistorico != null ? parametro.NumMesesEliminacionHistorico : oParametros.NumMesesEliminacionHistorico;

            Parametros updatedParametro = await _repository.UpdateParametro(oParametros);
            return updatedParametro;
        }
    }
}
