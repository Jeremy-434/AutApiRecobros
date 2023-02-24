using AutApiRecobros.Models;
using AutApiRecobros.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AutApiRecobros.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosController : ControllerBase
    {
        private readonly ServiciosService _service;

        public ServiciosController(ServiciosService serviciosService)
        {
            this._service = serviciosService;
        }

        [HttpGet]
        [Route("listar/{id:int}")]
        public IActionResult GetByid(int id)
        {
            var servicio = _service.GetServicioById(id);
            return StatusCode(StatusCodes.Status200OK, new { messaje = "OK", response = servicio.Result });
        }
        [HttpGet]
        [Route("listar")]
        public IActionResult Get()
        {
            var servicio = _service.GetAllServicios();
            return StatusCode(StatusCodes.Status200OK, new { message = "OK", response = servicio.Result });
        }
        [HttpPost]
        [Route("guardar")]
        public IActionResult Create(Servicios servicio)
        {
            var createdServicio = _service.CreateServicio(servicio);
            return StatusCode(StatusCodes.Status200OK, new { message = "CREATED", response = createdServicio.Result });
        }
        [HttpPut]
        [Route("editar")]
        public IActionResult Update(Servicios servicio)
        {
            var updatedServicio = _service.UpdateServicio(servicio);
            return StatusCode(StatusCodes.Status200OK, new { message = "UPDATED", response = updatedServicio.Result });
        }
        [HttpDelete]
        [Route("eliminar/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            Servicios deletedServicio = await _service.DeleteServicio(id);
            return StatusCode(StatusCodes.Status200OK, new { message = "DELETED", response = deletedServicio });
        }
    }
}
