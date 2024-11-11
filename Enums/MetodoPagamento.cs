using System.ComponentModel.DataAnnotations;

namespace EventFlow.Enums
{
    public enum MetodoPagamento {
        PIX = 0,
        Dinheiro = 1,
        [Display(Name = "Cartão de Crédito")]
        CartaoCredito = 2,
        [Display(Name = "Cartão de Débito")]
        CartaoDebito = 3
    }
}
