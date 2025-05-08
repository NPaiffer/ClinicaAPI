using Microsoft.AspNetCore.Mvc;
using ClinicaAPI.Data;
using ClinicaAPI.Models;
using ClinicaAPI.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly ClinicaContext _context;
        private readonly IViaCepService _viaCepService;

        public EnderecoController(ClinicaContext context, IViaCepService viaCepService)
        {
            _context = context;
            _viaCepService = viaCepService;
        }

        // GET: api/Endereco
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Endereco>>> GetEnderecos()
        {
            return await _context.Enderecos.ToListAsync();
        }

        // GET: api/Endereco/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Endereco>> GetEndereco(int id)
        {
            var endereco = await _context.Enderecos.FindAsync(id);
            if (endereco == null) return NotFound();
            return endereco;
        }

        // POST: api/Endereco
        [HttpPost]
        public async Task<ActionResult<Endereco>> PostEndereco(Endereco endereco)
        {
            _context.Enderecos.Add(endereco);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEndereco), new { id = endereco.Id_Endereco }, endereco);
        }

        // PUT: api/Endereco/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEndereco(int id, Endereco endereco)
        {
            if (id != endereco.Id_Endereco) return BadRequest();

            _context.Entry(endereco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnderecoExists(id)) return NotFound();
                throw;
            }

            return NoContent();
        }

        // DELETE: api/Endereco/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEndereco(int id)
        {
            var endereco = await _context.Enderecos.FindAsync(id);
            if (endereco == null) return NotFound();

            _context.Enderecos.Remove(endereco);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // NOVA ROTA: api/Endereco/consulta/01001000
        [HttpGet("consulta/{cep}")]
        public async Task<IActionResult> ConsultarCep(string cep)
        {
            var endereco = await _viaCepService.ConsultarCepAsync(cep);
            if (endereco == null || endereco.Cep == null)
                return NotFound(new { message = "CEP não encontrado" });

            return Ok(endereco);
        }

        private bool EnderecoExists(int id)
        {
            return _context.Enderecos.Any(e => e.Id_Endereco == id);
        }
    }
}
