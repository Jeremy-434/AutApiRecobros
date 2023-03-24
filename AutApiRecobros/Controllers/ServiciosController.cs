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
        public async Task<IActionResult> Get(int id)
        {
            Servicios servicio = await _service.GetServicioById(id);
            return Ok(servicio);
        }
        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Servicios> servicio = await _service.GetAllServicios();
            return Ok(servicio);
        }
        [HttpPost]
        [Route("guardar")]
        public async Task<IActionResult> Create(Servicios servicio)
        {
            Servicios createdServicio = await _service.CreateServicio(servicio);
            return Ok(createdServicio);
        }
        [HttpPut]
        [Route("editar")]
        public async Task<IActionResult> Update(Servicios servicio)
        {
            Servicios updatedServicio = await _service.UpdateServicio(servicio);
            return Ok(updatedServicio);
        }
        [HttpDelete]
        [Route("eliminar/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            Servicios deletedServicio = await _service.DeleteServicio(id);
            return Ok(deletedServicio);
        }
    }
}
