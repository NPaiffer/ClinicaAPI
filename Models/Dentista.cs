namespace ClinicaAPI.Models
{
    public class Dentista
    {
        public int Cpf_Dentista { get; set; }
        public string? Nome_Dentista { get; set; }
        public string? Cro_Dentista { get; set; }
        public string? Especialidade { get; set; }
        public string? Email_Dentista { get; set; }
        public DateTime Data_Contratacao { get; set; }
        public int? Cnpj_Clinica { get; set; }
        public int? Id_Endereco { get; set; }
        public int? Id_Telefone { get; set; }
    }
}
