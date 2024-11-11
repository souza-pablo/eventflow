using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EventFlow.Models
{
    public class Evento
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome do evento deve ter entre 3 e 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Data é obrigatório.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O campo Preço é obrigatório.")]
        [Range(0, double.MaxValue, ErrorMessage = "O preço deve ser um valor positivo.")]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Preço")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "O campo Previsão Climática é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "A previsão climática deve ter entre 3 e 100 caracteres")]
        [Display(Name = "Previsão Climática")]
        public string PrevisaoClimatica { get; set; }

        [Required(ErrorMessage = "O campo Quantidade de Participantes é obrigatório.")]
        [Display(Name = "Quantidade de Participantes")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade de participantes deve ser um valor positivo.")]
        public int QuantidadeParticipantes { get; set; }

        [Required]
        [Display(Name = "Organizador")]
        public int OrganizadorId { get; set; }

        [ForeignKey("OrganizadorId")]
        public Organizador? Organizador { get; set; }

        [Required]
        public int EnderecoId { get; set; }

        [ForeignKey("EnderecoId")]
        public Endereco? Endereco { get; set; }

        public ICollection<Inscricao> Inscricoes { get; set; } = new List<Inscricao>();
    }
}
