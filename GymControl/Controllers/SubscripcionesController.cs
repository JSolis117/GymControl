using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GymControl.Models;

namespace GymControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscripcionesController : ControllerBase
    {
        private readonly GymControlContext _context;

        public SubscripcionesController(GymControlContext context)
        {
            _context = context;
        }

        // GET: api/Subscripciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subscripcione>>> GetSubscripciones()
        {
            return await _context.Subscripciones.ToListAsync();
        }

        // GET: api/Subscripciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subscripcione>> GetSubscripcione(int id)
        {
            var subscripcione = await _context.Subscripciones.FindAsync(id);

            if (subscripcione == null)
            {
                return NotFound();
            }

            return subscripcione;
        }

        // PUT: api/Subscripciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubscripcione(int id, Subscripcione subscripcione)
        {
            if (id != subscripcione.Idsubscripcion)
            {
                return BadRequest();
            }

            _context.Entry(subscripcione).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscripcioneExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Subscripciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Subscripcione>> PostSubscripcione(Subscripcione subscripcione)
        {
            _context.Subscripciones.Add(subscripcione);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubscripcione", new { id = subscripcione.Idsubscripcion }, subscripcione);
        }

        // DELETE: api/Subscripciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscripcione(int id)
        {
            var subscripcione = await _context.Subscripciones.FindAsync(id);
            if (subscripcione == null)
            {
                return NotFound();
            }

            _context.Subscripciones.Remove(subscripcione);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubscripcioneExists(int id)
        {
            return _context.Subscripciones.Any(e => e.Idsubscripcion == id);
        }
    }
}
