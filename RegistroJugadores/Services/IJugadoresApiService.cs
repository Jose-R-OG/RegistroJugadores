using TicTacTocJoseR.Shared;
using TicTacTocJoseR.Shared.DTOs;

namespace RegistroJugadores.Services;

public interface IJugadoresApiService
{
    Task<Resource<List<JugadorResponse>>> GetJugadoresAsync();
    Task<Resource<JugadorResponse>> GetJugadoresAsync(string nombre);
    Task<Resource<JugadorResponse>> PostJugadores(string nombre, string email);
}
