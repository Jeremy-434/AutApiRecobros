using AutApiRecobros.Models;
using AutApiRecobros.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AutApiRecobros.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class ParametrosController : ControllerBase
    {
        public readonly ParametrosService _service;
        public ParametrosController(ParametrosService service)
        {
            this._service = service;
        }
        [HttpGet]
        [Route("listar/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            Parametros parametro = await _service.GetParametroById(id);
            return Ok(parametro);
        }
        [HttpPut]
        [Route("editar")]
        public async Task<IActionResult> Update(Parametros parametro)
        {
            Parametros updatedParametro = await _service.UpdateParametro(parametro);
            return Ok(updatedParametro);
        }
    }
}
