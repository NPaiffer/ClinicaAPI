using Microsoft.AspNetCore.Mvc;
using ClinicaAPI.Data;
using ClinicaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DentistaController : ControllerBase
    {
        private readonly ClinicaContext _context;

        public DentistaController(ClinicaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dentista>>> GetDentistas()
        {
            return await _context.Dentistas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Dentista>> GetDentista(int id)
        {
            var dentista = await _context.Dentistas.FindAsync(id);
            if (dentista == null) return NotFound();
            return dentista;
        }

        [HttpPost]
        public async Task<ActionResult<Dentista>> PostDentista(Dentista dentista)
        {
            _context.Dentistas.Add(dentista);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDentista), new { id = dentista.Cpf_Dentista }, dentista);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDentista(int id, Dentista dentista)
        {
            if (id != dentista.Cpf_Dentista) return BadRequest();

            _context.Entry(dentista).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DentistaExists(id)) return NotFound();
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDentista(int id)
        {
            var dentista = await _context.Dentistas.FindAsync(id);
            if (dentista == null) return NotFound();

            _context.Dentistas.Remove(dentista);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool DentistaExists(int id)
        {
            return _context.Dentistas.Any(e => e.Cpf_Dentista == id);
        }
    }
}
