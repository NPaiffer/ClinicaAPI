using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ClinicaAPI.Models;

namespace ClinicaAPI.Services
{
    public class ViaCepService : IViaCepService
    {
        private readonly HttpClient _httpClient;

        public ViaCepService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<EnderecoResponse> ConsultarCepAsync(string cep)
        {
            var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<EnderecoResponse>(content);
        }
    }
}
