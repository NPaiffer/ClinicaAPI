using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ClinicaAPI.Models;
using ClinicaAPI.Services.Interfaces;

namespace ClinicaAPI.Services
{
    public class ViaCepService : IViaCepService
    {
        private readonly HttpClient _httpClient;

        public ViaCepService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Endereco?> GetEnderecoByCepAsync(string cep)
        {
            var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();
            var endereco = JsonSerializer.Deserialize<Endereco>(json);
            return endereco;
        }

        public Task<Endereco?> ObterEnderecoPorCepAsync(string cep)
        {
            throw new NotImplementedException();
        }
    }
}
