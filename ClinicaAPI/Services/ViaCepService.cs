using ClinicaAPI.Models;
using System.Net.Http.Json;
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

        public async Task<Endereco?> ObterEnderecoPorCepAsync(string cep)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<Endereco>($"https://viacep.com.br/ws/{cep}/json/");
                return response;
            }
            catch
            {
                return null;
            }
        }
    }
}
