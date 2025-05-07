using System.ComponentModel.DataAnnotations;

namespace ClinicaAPI.Models
{
    public class Usuario
    {
        [Key]
        public int Id_Usuario { get; set; } 

        public string? Email_Usuario { get; set; }
        public string? Senha_Usuario { get; set; }
        public string? Status_Usuario { get; set; }
    }
}
