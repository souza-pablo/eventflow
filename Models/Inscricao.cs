using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using EventFlow.Enums;

namespace EventFlow.Models
{
    public class Inscricao
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Evento")]
        public int EventoId { get; set; }

        [Required]
        [Display(Name = "Participante")]
        public int ParticipanteId { get; set; }

        [Required(ErrorMessage = "O campo Data de Inscrição é obrigatório.")]
        [Display(Name = "Data de Inscrição")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime DataInscricao { get; set; }

        [Required]
        [Display(Name = "Status de Pagamento")]
        public StatusPagamento StatusPagamento { get; set; }

        [Required]
        [Display(Name = "Método de Pagamento")]
        public MetodoPagamento MetodoPagamento { get; set; }

        [ForeignKey("EventoId")]
        public Evento? Evento { get; set; }

        [ForeignKey("ParticipanteId")]
        public Participante? Participante { get; set; }
    }
}
