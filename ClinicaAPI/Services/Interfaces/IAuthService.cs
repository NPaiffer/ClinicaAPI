using System.Threading.Tasks;
using ClinicaAPI.Models;

public interface IAuthService
{
    Task<AuthResponse> LoginAsync(AuthRequest request);
    Task<AuthResponse> RegisterAsync(AuthRequest request);
}
