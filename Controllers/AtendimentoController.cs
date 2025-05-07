
using Microsoft.AspNetCore.Mvc;
using ClinicaAPI.Data;
using ClinicaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtendimentoController : ControllerBase
    {
        private readonly ClinicaContext _context;

        public AtendimentoController(ClinicaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Atendimento>>> GetAtendimentos()
        {
            return await _context.Atendimentos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Atendimento>> GetAtendimento(int id)
        {
            var atendimento = await _context.Atendimentos.FindAsync(id);
            if (atendimento == null) return NotFound();
            return atendimento;
        }

        [HttpPost]
        public async Task<ActionResult<Atendimento>> PostAtendimento(Atendimento atendimento)
        {
            _context.Atendimentos.Add(atendimento);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAtendimento), new { id = atendimento.Id_Atendimento }, atendimento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAtendimento(int id, Atendimento atendimento)
        {
            if (id != atendimento.Id_Atendimento) return BadRequest();

            _context.Entry(atendimento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AtendimentoExists(id)) return NotFound();
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAtendimento(int id)
        {
            var atendimento = await _context.Atendimentos.FindAsync(id);
            if (atendimento == null) return NotFound();

            _context.Atendimentos.Remove(atendimento);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool AtendimentoExists(int id)
        {
            return _context.Atendimentos.Any(e => e.Id_Atendimento == id);
        }
    }
}
