using AutApiRecobros.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AutApiRecobros.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class ArchivoController : Controller
    {
        public readonly ArchivoService _service;
        public ArchivoController(ArchivoService service)
        {
            this._service = service;
        }
        [HttpPost]
        public async Task<ActionResult> SaveFile([FromForm]IFormFile file)
        {
            try
            {
                await _service.SaveFile(file);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
