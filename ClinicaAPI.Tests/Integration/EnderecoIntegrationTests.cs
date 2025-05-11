using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ClinicaAPI.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using ClinicaAPI.Tests.Utils;

namespace ClinicaAPI.Tests.Integration
{
    public class EnderecoIntegrationTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public EnderecoIntegrationTests(CustomWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task PostGetDelete_Endereco_Success()
        {
            var novoEndereco = new Endereco
            {
                Logradouro = "Rua Exemplo",
                Numero = "123",
                Bairro = "Centro",
                Cidade = "São Paulo",
                Estado = "SP",
                Cep = "01001-000"
            };

            var postResponse = await _client.PostAsJsonAsync("/api/endereco", novoEndereco);
            postResponse.EnsureSuccessStatusCode();
            var enderecoCriado = await postResponse.Content.ReadFromJsonAsync<Endereco>();

            Assert.NotNull(enderecoCriado);
            Assert.NotEqual(0, enderecoCriado.Id_Endereco);

            var getResponse = await _client.GetAsync($"/api/endereco/{enderecoCriado.Id_Endereco}");
            getResponse.EnsureSuccessStatusCode();
            var enderecoObtido = await getResponse.Content.ReadFromJsonAsync<Endereco>();

            Assert.Equal(novoEndereco.Logradouro, enderecoObtido?.Logradouro);

            var deleteResponse = await _client.DeleteAsync($"/api/endereco/{enderecoCriado.Id_Endereco}");
            Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);
        }
    }
}
