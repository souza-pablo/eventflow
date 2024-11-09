using System.ComponentModel.DataAnnotations;

namespace EventFlow.Models
{
    public class Organizador : Pessoa
    {
        public ICollection<Evento> Eventos { get; set; } = new List<Evento>();
    }
}
