using Xunit;
using Moq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ClinicaAPI.Models;
using ClinicaAPI.Services;
using Moq.Protected;
using System.Threading;
using System.Text;
using System.Text.Json;

public class AuthServiceTests
{
    [Fact]
    public async Task LoginAsync_ReturnsToken()
    {
        var request = new AuthRequest { Email = "test@example.com", Password = "1234" };
        var expectedResponse = new AuthResponse { Token = "fake-token", UserId = "1", Message = "Success" };

        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonSerializer.Serialize(expectedResponse), Encoding.UTF8, "application/json")
            });

        var httpClient = new HttpClient(mockHandler.Object)
        {
            BaseAddress = new System.Uri("https://fake-auth-service.com/api/")
        };

        var service = new AuthService(httpClient);

        var result = await service.LoginAsync(request);

        Assert.Equal("fake-token", result.Token);
    }
}
