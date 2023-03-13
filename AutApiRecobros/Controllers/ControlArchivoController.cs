using AutApiRecobros.Models;
using AutApiRecobros.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AutApiRecobros.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class ControlArchivoController : ControllerBase
    {
        public readonly ControlArchivoService _service;
        public ControlArchivoController(ControlArchivoService service)
        {
            this._service = service;
        }
        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> Get()
        {
            IEnumerable<ControlArchivos> controlArchivo = await _service.GetAll();
            return Ok(controlArchivo);
        }
        [HttpPost]
        [Route("guardar")]
        public async Task<IActionResult> Create(ControlArchivos controlArchivo)
        {
            ControlArchivos createdControlArchivo = await _service.CreateControlArchivo(controlArchivo);
            return Ok(createdControlArchivo);
        }
    }
}
