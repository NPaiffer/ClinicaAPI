using System.ComponentModel.DataAnnotations;

namespace ClinicaAPI.Models
{
    public class Endereco
    {
        public string Cep { get; set; } = string.Empty;
        public int Id_Endereco { get; set; }
        public string Logradouro { get; set; } = string.Empty;
        public int Numero { get; set; }
        public string Bairro { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
    }
}

