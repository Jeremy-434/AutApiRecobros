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
        public async Task<IActionResult> Get(int id)
        {
            Aplicaciones aplicacion = await _service.GetAplicacionById(id);
            return Ok(aplicacion);
        }
        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Aplicaciones> aplicaciones = await _service.GetAllAplicaciones();
            return Ok(aplicaciones);
        }
        [HttpPost]
        [Route("guardar")]
        public async Task<IActionResult> Create(Aplicaciones aplicacion)
        {
            Aplicaciones createdAplicacion = await _service.CreateAplicacion(aplicacion);
            return Ok(createdAplicacion);
        }
        [HttpPut]
        [Route("editar")]
        public async Task<IActionResult> Update(Aplicaciones aplicacion)
        {
            Aplicaciones oAplicacion;
            try
            {
                Aplicaciones updatedAplicacion =  await _service.UpdateAplicacion(aplicacion);
                oAplicacion = updatedAplicacion;
                return Ok(oAplicacion);
            }
            catch (Exception ex)
            {
                return new ObjectResult("No se encontraron datos") { StatusCode = ex.HResult };
            }
        }
        [HttpDelete]
        [Route("eliminar/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            Aplicaciones deletedAplicacion = await _service.DeleteAplicacion(id);
            return Ok(deletedAplicacion);

        }
    }
}
