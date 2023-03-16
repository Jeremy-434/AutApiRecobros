using AutApiRecobros.Services.Interfaces;

namespace AutApiRecobros.Services
{
    public class ArchivoService : IArchivoService
    {
        public async Task SaveFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("Not File");
            }

            using var reader = new StreamReader(file.OpenReadStream());
            string lineOne = await reader.ReadLineAsync();
            string[] fields = lineOne.Split('|');

            if (fields.Length != 7)
            {
                throw new ArgumentException("El archivo no cumple con los requisitos");
            }

            try
            {
                var filePath = "\\\\bjavaplivitd\\TmpFuentes\\Recobros\\" + file.FileName;
                
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
