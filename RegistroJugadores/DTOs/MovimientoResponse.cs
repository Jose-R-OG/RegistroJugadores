using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroJugadores.DTOs;

public record MovimientoResponse(
    int PartidaId,
    string Jugador,
    int PosicionFila,
    int PosicionColumna
);
