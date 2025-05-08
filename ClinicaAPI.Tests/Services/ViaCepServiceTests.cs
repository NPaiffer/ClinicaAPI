using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ClinicaAPI.Models;
using ClinicaAPI.Services;
using ClinicaAPI.Services.Interfaces;
using Moq;
using Moq.Protected;
using Xunit;
using Newtonsoft.Json;

public class ViaCepServiceTests
{
    [Fact]
    public async Task GetEnderecoByCepAsync_ReturnsEndereco_WhenCepIsValid()
    {
        var cep = "01001000";
        var expectedEndereco = new Endereco
        {
            Cep = "01001-000",
            Rua = "Praça da Sé",
            Bairro = "Sé",
            Cidade = "São Paulo",
            Estado = "SP"
        };

        var jsonResponse = JsonConvert.SerializeObject(expectedEndereco);
        var httpMessageHandlerMock = new Mock<HttpMessageHandler>();

        httpMessageHandlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Get &&
                    req.RequestUri.ToString().Contains(cep)),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(jsonResponse),
            });

        var httpClient = new HttpClient(httpMessageHandlerMock.Object)
        {
            BaseAddress = new Uri("https://viacep.com.br/")
        };

        var viaCepService = new ViaCepService(httpClient);

        var result = await viaCepService.GetEnderecoByCepAsync(cep);

        Assert.NotNull(result);
        Assert.Equal(expectedEndereco.Rua, result.Rua);
        Assert.Equal(expectedEndereco.Bairro, result.Bairro);
        Assert.Equal(expectedEndereco.Cidade, result.Cidade);
        Assert.Equal(expectedEndereco.Estado, result.Estado);
        Assert.Equal(expectedEndereco.Cep, result.Cep);
    }

    [Fact]
    public async Task GetEnderecoByCepAsync_ReturnsNull_WhenCepIsInvalid()
    {
        var cep = "00000000";
        var httpMessageHandlerMock = new Mock<HttpMessageHandler>();

        httpMessageHandlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound
            });

        var httpClient = new HttpClient(httpMessageHandlerMock.Object)
        {
            BaseAddress = new Uri("https://viacep.com.br/")
        };

        var viaCepService = new ViaCepService(httpClient);

        var result = await viaCepService.GetEnderecoByCepAsync(cep);

        Assert.Null(result);
    }
}
