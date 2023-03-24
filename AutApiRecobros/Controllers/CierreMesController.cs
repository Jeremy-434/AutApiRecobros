using AutApiRecobros.Models;
using AutApiRecobros.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AutApiRecobros.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[Controller]")]
    [ApiController]
    public class CierreMesController : ControllerBase
    {
        public readonly CierreMesService _service;
        public CierreMesController(CierreMesService service)
        {
            this._service = service;
        }
        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<CierreMes> cierreMesList = await _service.GetAllCierreMes();
            return Ok(cierreMesList);
        }
    }
}
