using AutApiRecobros.Models;
using AutApiRecobros.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AutApiRecobros.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class AliadosController : ControllerBase
    {
        public readonly AliadosService _service;
        public AliadosController(AliadosService service)
        {
            this._service = service;
        }
        [HttpGet]
        [Route("listar/{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            Aliados aliado = await _service.GetAliadosById(id);
            return Ok(aliado);
        }
        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Aliados> aliados = (IEnumerable<Aliados>)await _service.GetAllAliados();
            return Ok(aliados);
        }
        [HttpPost]
        [Route("guardar")]
        public async Task<IActionResult> Add(Aliados aliado)
        {
            Aliados createdAliado = await _service.CreateAliado(aliado);
            return Ok(createdAliado);
        }
        [HttpPut]
        [Route("editar")]
        public async Task<IActionResult> Update(Aliados aliado)
        {
            Aliados updatedAliado = await _service.UpdateAliado(aliado);
            return Ok(updatedAliado);
        }
        [HttpDelete]
        [Route("eliminar/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            Aliados deleteAliado = await _service.DeleteAliado(id);
            return Ok(deleteAliado);
        }
    }
}
