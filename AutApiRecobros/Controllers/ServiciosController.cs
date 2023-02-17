using AutApiRecobros.Models;
using AutApiRecobros.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutApiRecobros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosController : Controller
    {
        private readonly ServiciosService serviciosService;

        public ServiciosController(ServiciosService serviciosService)
        {
            this.serviciosService = serviciosService;
        }

        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {
            List<Servicios>? servicios = serviciosService.Listar();
            return StatusCode(StatusCodes.Status200OK, new { messaje = "ok", response = servicios });
        }
    }
}
