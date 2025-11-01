using RegistroJugadores.DTOs;

namespace RegistroJugadores.Services;

public interface IJugadoresApiService
{
    Task<Resource<List<JugadorResponse>>> GetJugadoresAsync();
    Task<Resource<JugadorResponse>> GetJugadorAsync(int JugadorId);
    Task<Resource<JugadorResponse>> PostJugadores(string nombre, string email);
    Task<Resource<JugadorResponse>> PutJugador(int JugadorId, string nombre, string email);
}