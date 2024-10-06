namespace ClinicaAPI.Models
{
    public class Atendimento
    {
        public int Id_Atendimento { get; set; }
        public string? Tipo_Procedimento { get; set; }
        public string? Descricao_Atendimento { get; set; }
        public DateTime Data_Atendimento { get; set; }
        public float Custo_Estimado { get; set; }
        public int? Cpf_Paciente { get; set; }
        public int? Cpf_Dentista { get; set; }
    }
}
