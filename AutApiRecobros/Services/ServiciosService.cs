using AutApiRecobros.Models;
using Microsoft.EntityFrameworkCore;

namespace AutApiRecobros.Services
{

    public class ServiciosService
    {
        public readonly MyDbContext dbContext;

        public ServiciosService(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Servicios>? Listar()
        {
            try
            {
                //List<Servicios> services = new();
                //services = dbContext.Servicios.ToList();
                List<Servicios> services = dbContext.Servicios.ToList();

                return services;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }

        }
    }
}
