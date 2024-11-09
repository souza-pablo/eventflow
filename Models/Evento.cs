using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EventFlow.Models
{
    public class Evento
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O nome do evento deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "O local do evento deve ter no máximo 200 caracteres.")]
        public string Local { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "O preço deve ser um valor positivo.")]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }

        [StringLength(100)]
        [Display(Name = "Previsão Climática")]
        public string PrevisaoClimatica { get; set; }

        [Required]
        [Display(Name = "Quantidade de Participantes")]
        public int QuantidadeParticipantes;

        [Required]
        public int OrganizadorId { get; set; }

        [ForeignKey("OrganizadorId")]
        public Organizador Organizador { get; set; }

        public ICollection<Inscricao> Inscricoes { get; set; } = new List<Inscricao>();
    }
}
