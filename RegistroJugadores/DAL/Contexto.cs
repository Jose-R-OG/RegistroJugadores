using Microsoft.EntityFrameworkCore;
using RegistroJugadores.Models;

namespace RegistroJugadores.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public virtual DbSet<Jugadores> Jugadores { get; set; }
    public virtual DbSet<Partidas> Partidas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Partidas>(entity =>
        {

            entity.HasOne(p => p.Jugador1)
                  .WithMany()
                  .HasForeignKey(p => p.Jugador1Id)
                  .OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(p => p.Jugador2)
                  .WithMany()
                  .HasForeignKey(p => p.Jugador2Id)
                  .OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(p => p.Ganador)
                  .WithMany()
                  .HasForeignKey(p => p.GanadorId)
                  .OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(p => p.TurnoJugador)
                  .WithMany()
                  .HasForeignKey(p => p.TurnoJugadorId)
                  .OnDelete(DeleteBehavior.NoAction);


        });
    }

}

