namespace ClinicaAPI.Models
{
    public class Endereco
    {
        public int Id_Endereco { get; set; }
        public string? Rua_Endereco { get; set; }
        public int Numero_Endereco { get; set; }
        public string? Complemento_Endereco { get; set; }
        public string? Bairro_Endereco { get; set; }
        public string? Cidade_Endereco { get; set; }
        public string? Estado_Endereco { get; set; }
        public int Cep { get; set; }
    }
}
