using System.Threading.Tasks;
using ClinicaAPI.Models;

namespace ClinicaAPI.Services
{
    public interface IViaCepService
    {
        Task<EnderecoResponse> ConsultarCepAsync(string cep);
    }
}
