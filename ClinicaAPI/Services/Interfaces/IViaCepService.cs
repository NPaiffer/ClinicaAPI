using ClinicaAPI.Models;

namespace ClinicaAPI.Services.Interfaces
{
    public interface IViaCepService
    {
        Task<Endereco?> ObterEnderecoPorCepAsync(string cep);
    }
}
