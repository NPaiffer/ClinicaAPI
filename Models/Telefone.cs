using System.ComponentModel.DataAnnotations;

namespace ClinicaAPI.Models
{
    public class Telefone
    {
        [Key]
        public int Id_Telefone { get; set; }

        public string? Numero_Telefone { get; set; }
        public string? Tipo_Telefone { get; set; }
    }
}
