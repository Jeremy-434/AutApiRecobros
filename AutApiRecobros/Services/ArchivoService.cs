using AutApiRecobros.Models;
using AutApiRecobros.Repository;
using AutApiRecobros.Services.Interfaces;

namespace AutApiRecobros.Services
{
    public class ArchivoService : IArchivoService
    {
        public readonly ParametrosRepository _repository;
        public ArchivoService(ParametrosRepository repository)
        {
            this._repository = repository;
        }
        public async Task SaveFile(IFormFile file)
        {

            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("Not File");
            }

            Parametros parametros = await _repository.GetParametroById(1);
            Console.WriteLine(parametros);

            using var reader = new StreamReader(file.OpenReadStream());
            string lineOne = await reader.ReadLineAsync();
            string[] fields = lineOne.Split('|');

            if (fields.Length != parametros.NumColumnasArchivo)
            {
                throw new ArgumentException("El archivo no tiene los "+parametros.NumColumnasArchivo+" campos correspondientes");
            }

            try
            {
                var filePath = parametros.RutaArchivosProcesar + file.FileName;

                using var stream = System.IO.File.Create(filePath);
                await file.CopyToAsync(stream);
                Console.WriteLine("El archivo se ha guardado correctamente.");
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
