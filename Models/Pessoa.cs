using System.ComponentModel.DataAnnotations;

namespace EventFlow.Models
{
    public class Pessoa {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "O e-mail deve ser válido.")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "O telefone deve ser válido.")]
        public string Telefone { get; set; }
    }
}
