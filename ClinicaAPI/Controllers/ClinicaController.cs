using Microsoft.AspNetCore.Mvc;
using ClinicaAPI.Data;
using ClinicaAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicaController : ControllerBase
    {
        private readonly ClinicaContext _context;

        public ClinicaController(ClinicaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clinica>>> GetClinicas()
        {
            return await _context.Clinicas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Clinica>> GetClinica(string id)
        {
            var clinica = await _context.Clinicas.FindAsync(id);
            if (clinica == null) return NotFound();
            return clinica;
        }

        [HttpPost]
        public async Task<ActionResult<Clinica>> PostClinica(Clinica clinica)
        {
            _context.Clinicas.Add(clinica);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetClinica), new { id = clinica.Cnpj_Clinica }, clinica);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutClinica(string id, Clinica clinica)
        {
            if (id != clinica.Cnpj_Clinica) return BadRequest();

            _context.Entry(clinica).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClinicaExists(id)) return NotFound();
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClinica(string id)
        {
            var clinica = await _context.Clinicas.FindAsync(id);
            if (clinica == null) return NotFound();

            _context.Clinicas.Remove(clinica);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool ClinicaExists(string id)
        {
            return _context.Clinicas.Any(e => e.Cnpj_Clinica == id);
        }
    }
}
