using System.ComponentModel.DataAnnotations;

public class ContactViewModel
{
    [Required(ErrorMessage = "Nome é obrigatório")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Email é obrigatório")]
    [EmailAddress(ErrorMessage = "Formato de email inválido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Mensagem é obrigatória")]
    public string Message { get; set; }
}
