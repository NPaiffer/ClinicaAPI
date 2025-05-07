using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaAPI.Models
{
    public class Atendimento
    {
        [Key]
        public int Id_Atendimento { get; set; }

        [Required]
        [MaxLength(100)]
        public string Tipo_Procedimento { get; set; }

        [MaxLength(255)]
        public string? Descricao_Atendimento { get; set; }

        [Required]
        public DateTime Data_Atendimento { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Custo_Estimado { get; set; }

        [ForeignKey("Paciente")]
        public int? Cpf_Paciente { get; set; }
        public Paciente? Paciente { get; set; }

        [ForeignKey("Dentista")]
        public int? Cpf_Dentista { get; set; }
        public Dentista? Dentista { get; set; }
    }
}
