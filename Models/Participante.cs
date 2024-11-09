using System.ComponentModel.DataAnnotations;

namespace EventFlow.Models
{
    public class Participante : Pessoa
    {
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento")] 
        public DateTime DataNascimento { get; set; }

        public ICollection<Inscricao> Inscricoes { get; set; } = new List<Inscricao>();
    }
}
