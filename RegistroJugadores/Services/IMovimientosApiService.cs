using TicTacTocJoseR.Shared;
using TicTacTocJoseR.Shared.DTOs;

namespace RegistroJugadores.Services;

public interface IMovimientosApiService
{
    Task<Resource<MovimientoResponse>> GetMovimientoAsync(int partidaId);
    Task<Resource<MovimientosService>> PostMovimiento(int PartidaId, string Jugador, int PosicionFila, int PosicionColumna);
}
