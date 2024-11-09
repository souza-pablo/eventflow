using EventFlow.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace EventFlow.ViewModels
{
    public class InscricaoViewModel
    {
        [Key] 
        public int Id { get; set; }

        [Required] 
        public int EventoId { get; set; }
        [Required] 
        public int ParticipanteId { get; set; }
        [Required]
        [Display(Name = "Data de Inscrição")] 
        public DateTime DataInscricao { get; set; }
        [Required]
        [Display(Name = "Status de Pagamento")] 
        public StatusPagamento StatusPagamento { get; set; }
        [Required]
        [Display(Name = "Método de Pagamento")] 
        public MetodoPagamento MetodoPagamento { get; set; }
        public IEnumerable<SelectListItem> StatusPagamentoOptions { get; set; }
        public IEnumerable<SelectListItem> MetodoPagamentoOptions { get; set; }
    }
}
