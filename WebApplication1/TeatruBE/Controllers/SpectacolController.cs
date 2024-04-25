using Microsoft.AspNetCore.Mvc;
using TeatruBE.Models;
using TeatruBE.Services;

namespace TeatruBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpectacolController : ControllerBase
    {
        private readonly ISpectacolService _service;

        public SpectacolController(ISpectacolService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Spectacol>> GetSpectacols()
        {
            return Ok(_service.GetAllSpectacols());
        }

        [HttpGet("{id}")]
        public ActionResult<Spectacol> GetSpectacol(int id)
        {
            var spectacol = _service.GetById(id);

            if (spectacol == null)
            {
                return NotFound();
            }

            return spectacol;
        }

        [HttpPost]
        public IActionResult PostSpectacol(Spectacol spectacol)
        {
            _service.AddSpectacol(spectacol);

            return CreatedAtAction(nameof(GetSpectacol), new { id = spectacol.SpectacolId }, spectacol);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSpectacol(int id)
        {
            try
            {
                _service.DeleteSpectacol(id);
                return NoContent();
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }
    }
}