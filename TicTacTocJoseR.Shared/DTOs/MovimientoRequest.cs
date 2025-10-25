using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacTocJoseR.Shared.DTOs;

public record MovimientoRequest(
    int PartidaId,
    int JugadorId 
);
