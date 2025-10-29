using RegistroJugadores.DTOs;

namespace RegistroJugadores.Services;

public interface IPartidaApiService
{
    Task<Resource<List<PartidaResponse>>> GetPartidasAsync();
    Task<Resource<PartidaResponse>> GetPartidaAsync(int partidaId);
    Task<Resource<PartidaResponse>> PostPartida(int jugador1, int jugador2);
    Task<Resource<PartidaResponse>> PutPartida(int partidaId, int jugador1, int? jugador2);
}
