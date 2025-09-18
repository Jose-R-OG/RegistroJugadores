using Microsoft.EntityFrameworkCore;
using RegistroJugadores.Models;

namespace RegistroJugadores.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public virtual DbSet<Jugadores> Jugadores { get; set; }
    public virtual DbSet<Partidas> Partidas { get; set; }
    public virtual DbSet<Movimientos> Movimientos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Partidas>(entity =>
        {

            entity.HasOne(partidas => partidas.Jugador1)
                  .WithMany()
                  .HasForeignKey(partidas => partidas.Jugador1Id)
                  .OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(partidas => partidas.Jugador2)
                  .WithMany()
                  .HasForeignKey(partidas => partidas.Jugador2Id)
                  .OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(partidas => partidas.Ganador)
                  .WithMany()
                  .HasForeignKey(partidas => partidas.GanadorId)
                  .OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(partidas => partidas.TurnoJugador)
                  .WithMany()
                  .HasForeignKey(partidas => partidas.TurnoJugadorId)
                  .OnDelete(DeleteBehavior.NoAction);


        });

        modelBuilder.Entity<Movimientos>(entity =>
        {
            entity.HasOne(m => m.Jugador)
                  .WithMany(j => j.Movimientos)
                  .HasForeignKey(m => m.JugadorId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(m => m.Partida)
                  .WithMany()
                  .HasForeignKey(m => m.PartidaId)
                  .OnDelete(DeleteBehavior.Restrict);
        });
    }

}

