namespace ClinicaAPI.Models
{
    public class Clinica
    {
        public int Cnpj_Clinica { get; set; }
        public string? Nome_Clinica { get; set; }
        public int? Id_Usuario { get; set; }
        public int? Id_Endereco { get; set; }
        public int? Id_Telefone { get; set; }
    }
}
