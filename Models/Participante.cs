using System.ComponentModel.DataAnnotations;

namespace EventFlow.Models
{
    public class Participante : Pessoa
    {
        [Required]
        [Display(Name = "Data de Nascimento")]
        public DateOnly DataNascimento { get; set; }

        public ICollection<Inscricao> Inscricoes { get; set; } = new List<Inscricao>();
    }
}
