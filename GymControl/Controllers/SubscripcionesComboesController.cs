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
    public class SubscripcionesComboesController : ControllerBase
    {
        private readonly GymControlContext _context;

        public SubscripcionesComboesController(GymControlContext context)
        {
            _context = context;
        }

        // GET: api/SubscripcionesComboes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubscripcionesCombo>>> GetSubscripcionesCombos()
        {
            return await _context.SubscripcionesCombos.ToListAsync();
        }

        // GET: api/SubscripcionesComboes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubscripcionesCombo>> GetSubscripcionesCombo(int id)
        {
            var subscripcionesCombo = await _context.SubscripcionesCombos.FindAsync(id);

            if (subscripcionesCombo == null)
            {
                return NotFound();
            }

            return subscripcionesCombo;
        }

        // PUT: api/SubscripcionesComboes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubscripcionesCombo(int id, SubscripcionesCombo subscripcionesCombo)
        {
            if (id != subscripcionesCombo.IdsubscripcionCombo)
            {
                return BadRequest();
            }

            _context.Entry(subscripcionesCombo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscripcionesComboExists(id))
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

        // POST: api/SubscripcionesComboes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SubscripcionesCombo>> PostSubscripcionesCombo(SubscripcionesCombo subscripcionesCombo)
        {
            _context.SubscripcionesCombos.Add(subscripcionesCombo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubscripcionesCombo", new { id = subscripcionesCombo.IdsubscripcionCombo }, subscripcionesCombo);
        }

        // DELETE: api/SubscripcionesComboes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscripcionesCombo(int id)
        {
            var subscripcionesCombo = await _context.SubscripcionesCombos.FindAsync(id);
            if (subscripcionesCombo == null)
            {
                return NotFound();
            }

            _context.SubscripcionesCombos.Remove(subscripcionesCombo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubscripcionesComboExists(int id)
        {
            return _context.SubscripcionesCombos.Any(e => e.IdsubscripcionCombo == id);
        }
    }
}
