using System.ComponentModel.DataAnnotations;

namespace EventFlow.Models
{
    public class Pessoa {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo E-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail deve ser válido.")]
        [StringLength(50, ErrorMessage = "O nome do evento deve ter no máximo 50 caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "O telefone deve conter exatamente 11 dígitos.")]
        public string Telefone { get; set; }
    }
}
