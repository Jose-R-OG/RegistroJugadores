using TicTacTocJoseR.Shared;
using TicTacTocJoseR.Shared.DTOs;

namespace TIicTacTocJose.BlazorWasm.Services;

public interface IJugadoresApiService
{
    Task<Resource<List<JugadorResponse>>> GetJugadoresAsync();
    Task<Resource<JugadorResponse>> GetJugadoresAsync(int JugadorId);
    Task<Resource<JugadorResponse>> PostJugadores(string nombre, string email);
}
