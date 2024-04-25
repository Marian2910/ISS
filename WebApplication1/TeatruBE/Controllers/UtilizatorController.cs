using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TeatruBE.Models;

namespace TeatruBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilizatorController : ControllerBase
    {
        private readonly TeatruContext _context;

        public UtilizatorController(TeatruContext context)
        {
            _context = context;
        }

        // GET: api/Utilizator
        [HttpGet]
        public ActionResult<IEnumerable<Utilizator>> GetUtilizators()
        {
            return _context.Utilizators.ToList();
        }

        // GET: api/Utilizator/5
        [HttpGet("{id}")]
        public ActionResult<Utilizator> GetUtilizator(int id)
        {
            var utilizator = _context.Utilizators.Find(id);

            if (utilizator == null)
            {
                return NotFound();
            }

            return utilizator;
        }

        // POST: api/Utilizator
        [HttpPost]
        public ActionResult<Utilizator> PostUtilizator(Utilizator utilizator)
        {
            _context.Utilizators.Add(utilizator);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetUtilizator), new { id = utilizator.UserId }, utilizator);
        }

        // DELETE: api/Utilizator/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUtilizator(int id)
        {
            var utilizator = _context.Utilizators.Find(id);
            if (utilizator == null)
            {
                return NotFound();
            }

            _context.Utilizators.Remove(utilizator);
            _context.SaveChanges();

            return NoContent();
        }
    }
}