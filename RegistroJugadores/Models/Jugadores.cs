using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroJugadores.Models;

public class Jugadores
{
    [Key]
    public int JugadorId { get; set; }

    [Required(ErrorMessage = "Este campo es requerido")]
    public string nombres { get; set; }

    [Required(ErrorMessage = "Este campo es requerido")]
    [Range(1, int.MaxValue, ErrorMessage = "Las partidas no pueden ser menor a 1")]
    public int victorias { get; set; }
    public int Derrotas { get; set; }   
    public int Empate { get; set; }

    [InverseProperty(nameof(Models.Movimientos.Jugador))]
    public virtual ICollection<Movimientos> Movimientos { get; set; } = new List<Movimientos>();
}
