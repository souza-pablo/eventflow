using System.ComponentModel.DataAnnotations;

namespace EventFlow.Models
{
    public class Endereco
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo CEP é obrigatório.")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "O CEP deve conter 8 dígitos.")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "O campo Logradouro é obrigatório.")]
        [StringLength(100, ErrorMessage = "O Logradouro pode ter no máximo 100 caracteres.")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O campo Número é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O Número deve ser um valor positivo.")]
        public int Numero { get; set; }

        [StringLength(50, ErrorMessage = "O Complemento pode ter no máximo 50 caracteres.")]
        public string? Complemento { get; set; }

        [Required(ErrorMessage = "O campo Bairro é obrigatório.")]
        [StringLength(50, ErrorMessage = "O Bairro pode ter no máximo 50 caracteres.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo Localidade é obrigatório.")]
        [StringLength(50, ErrorMessage = "A Localidade pode ter no máximo 50 caracteres.")]
        public string Localidade { get; set; }

        [Required(ErrorMessage = "O campo UF é obrigatório.")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "A UF deve ter exatamente 2 caracteres.")]
        [RegularExpression(@"^[A-Z]{2}$", ErrorMessage = "A UF deve conter apenas letras maiúsculas.")]
        public string UF { get; set; }
    }
}
