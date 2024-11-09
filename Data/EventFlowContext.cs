using EventFlow.Models;
using Microsoft.EntityFrameworkCore;

namespace EventFlow.Data
{
    public class EventFlowContext : DbContext
    {
        public EventFlowContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Participante> Participantes { get; set; }
        public DbSet<Inscricao> Inscricoes { get; set; }
        public DbSet<Organizador> Organizadores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Evento>()
                .HasOne(e => e.Organizador)
                .WithMany(o => o.Eventos)
                .HasForeignKey(e => e.OrganizadorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Inscricao>()
                .HasOne(i => i.Evento)
                .WithMany(e => e.Inscricoes)
                .HasForeignKey(i => i.EventoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Inscricao>()
                .HasOne(i => i.Participante)
                .WithMany(p => p.Inscricoes)
                .HasForeignKey(i => i.ParticipanteId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
