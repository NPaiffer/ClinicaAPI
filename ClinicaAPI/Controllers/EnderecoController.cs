using Microsoft.AspNetCore.Mvc;
using ClinicaAPI.Data;
using ClinicaAPI.Models;
using Microsoft.EntityFrameworkCore;
using ClinicaAPI.Services.Interfaces;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Endereco>>> GetEnderecos()
        {
            return await _context.Enderecos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Endereco>> GetEndereco(int id)
        {
            var endereco = await _context.Enderecos.FindAsync(id);
            if (endereco == null) return NotFound();
            return endereco;
        }

        [HttpPost]
        public async Task<ActionResult<Endereco>> PostEndereco(Endereco endereco)
        {
            _context.Enderecos.Add(endereco);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEndereco), new { id = endereco.Id_Endereco }, endereco);
        }

        [HttpGet("cep/{cep}")]
        public async Task<ActionResult<Endereco>> ObterEnderecoPorCep(string cep)
        {
            var endereco = await _viaCepService.ObterEnderecoPorCepAsync(cep);
            if (endereco == null) return NotFound("Endereço não encontrado para o CEP fornecido.");
            return Ok(endereco);
        }

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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEndereco(int id)
        {
            var endereco = await _context.Enderecos.FindAsync(id);
            if (endereco == null) return NotFound();

            _context.Enderecos.Remove(endereco);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool EnderecoExists(int id)
        {
            return _context.Enderecos.Any(e => e.Id_Endereco == id);
        }
    }
}
