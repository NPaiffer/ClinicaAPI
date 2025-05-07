using Xunit;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ClinicaAPI.Controllers;
using ClinicaAPI.Services;
using ClinicaAPI.Models;
using System.Threading.Tasks;

public class UsuarioControllerTests
{
    [Fact]
    public async Task Register_ReturnsOkResult()
    {
        var mockService = new Mock<IAuthService>();
        mockService.Setup(s => s.RegisterAsync(It.IsAny<AuthRequest>()))
                   .ReturnsAsync(new AuthResponse { Token = "abc", UserId = "1", Message = "Success" });

        var controller = new UsuarioController(mockService.Object);

        var result = await controller.Register(new AuthRequest { Email = "test@test.com", Password = "1234" });

        var okResult = Assert.IsType<OkObjectResult>(result);
        var response = Assert.IsType<AuthResponse>(okResult.Value);
        Assert.Equal("abc", response.Token);
    }
}
