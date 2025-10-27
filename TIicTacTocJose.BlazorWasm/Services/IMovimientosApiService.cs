using TicTacTocJoseR.Shared;
using TicTacTocJoseR.Shared.DTOs;

namespace TIicTacTocJose.BlazorWasm.Services;

public interface IMovimientosApiService
{
    Task<Resource<List<MovimientoResponse>>> GetMovimientoAsync(int partidaId);
    Task<Resource<MovimientoResponse>> PostMovimiento(int PartidaId, string Jugador, int PosicionFila, int PosicionColumna);
}
