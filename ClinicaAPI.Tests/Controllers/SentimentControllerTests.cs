using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using ClinicaAPI;

namespace ClinicaAPI.Tests.Controllers
{
    public class SentimentControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public SentimentControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Theory]
        [InlineData("Eu estou muito feliz hoje!", "Positivo")]
        [InlineData("Isso foi horrível", "Negativo")]
        [InlineData("", null)]
        public async Task AnalyzeSentiment_ReturnsExpectedSentiment(string input, string expected)
        {
            var response = await _client.PostAsJsonAsync("/api/sentiment/analyze", new { text = input });

            if (string.IsNullOrWhiteSpace(input))
            {
                response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
                return;
            }

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<SentimentResponse>();
            result.Should().NotBeNull();
            result!.Sentimento.Should().Be(expected);
        }

        private class SentimentResponse
        {
            public string Sentimento { get; set; }
        }
    }
}
