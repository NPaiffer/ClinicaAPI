using System.ComponentModel.DataAnnotations;

namespace ClinicaAPI.Models
{
    public class Clinica
    {
        [Key]
        public string Cnpj_Clinica { get; set; }

        public string Nome_Clinica { get; set; }
        public int? Id_Usuario { get; set; }
        public int? Id_Endereco { get; set; }
        public int? Id_Telefone { get; set; }
    }
}
