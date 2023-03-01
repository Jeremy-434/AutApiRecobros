using AutApiRecobros.Models;
using AutApiRecobros.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace AutApiRecobros.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class AplicacionesController : ControllerBase
    {
        public readonly AplicacionesService _service;
        public AplicacionesController(AplicacionesService service)
        {
            this._service = service;
        }
        [HttpGet]
        [Route("listar/{id:int}")]
        public IActionResult Get(int id)
        {
            var aplicacion = _service.GetAplicacionById(id);
            return StatusCode(StatusCodes.Status200OK, new { messaje = "OK", response = aplicacion.Result });
        }
        [HttpGet]
        [Route("listar")]
        public IActionResult GetAll()
        {
            var aplicaciones = _service.GetAllAplicaciones();
            return StatusCode(StatusCodes.Status200OK, new { messaje = "OK", response = aplicaciones.Result });
        }
        [HttpPost]
        [Route("guardar")]
        public IActionResult Create(Aplicaciones aplicacion)
        {
            var createdAplicacion = _service.CreateAplicacion(aplicacion);
            return StatusCode(StatusCodes.Status200OK, new { messaje = "CREATED", response = createdAplicacion.Result });
        }
        [HttpPut]
        [Route("editar")]
        public async Task<IActionResult> Update(Aplicaciones aplicacion)
        {
            Aplicaciones oAplicacion = new();
            try
            {
                Aplicaciones updatedAplicacion =  await _service.UpdateAplicacion(aplicacion);
                oAplicacion = updatedAplicacion;
                return StatusCode(StatusCodes.Status200OK, new { messaje = "UPDATE", response = updatedAplicacion });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { messaje = ex.Message, response = oAplicacion });
            }
        }
        [HttpDelete]
        [Route("eliminar/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            Aplicaciones deletedAplicacion = await _service.DeleteAplicacion(id);
            return StatusCode(StatusCodes.Status200OK, new { messaje = "DELETED", response = deletedAplicacion });

        }
    }
}
