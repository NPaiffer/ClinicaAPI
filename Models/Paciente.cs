using System.ComponentModel.DataAnnotations;

namespace ClinicaAPI.Models
{
    public class Paciente
    {
        [Key]
        public int Cpf_Paciente { get; set; }

        public string? Nome_Paciente { get; set; }
        public DateTime Data_Nascimento { get; set; }
        public string? Genero_Paciente { get; set; }
        public int? Cnpj_Clinica { get; set; }
        public int? Id_Endereco { get; set; }
        public int? Id_Telefone { get; set; }
    }
}
