﻿using Microsoft.EntityFrameworkCore;
using RegistroJugadores.DAL;    
using RegistroJugadores.Models;
using System.Linq.Expressions;

namespace RegistroJugadores.Services;

public class PartidasService(IDbContextFactory<Contexto> DbFactory)
{
   public async Task<bool> Existe(int PartidaId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Partidas
            .AnyAsync(p => p.PartidaId == PartidaId);

    }
    public async Task<bool> Guardar(Partidas partida)
    {
        if (!await Existe(partida.PartidaId))
        {
            return await Insertar(partida);
        }
        else
        {
            return await Modificar(partida);
        }
    }

    public async Task<bool> Insertar(Partidas partida)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Partidas.Add(partida);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Partidas partida)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Update(partida);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<Partidas> Buscar(int PartidaId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Partidas.FirstOrDefaultAsync(p => p.PartidaId == PartidaId);
    }

    public async Task<bool> Eliminar(int PartidaId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Partidas.
            AsNoTracking()
            .Where(p => p.PartidaId == PartidaId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<List<Partidas>> Listar(Expression<Func<Partidas, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Partidas
            .Include(partida => partida.Jugador1)
            .Include(partida => partida.Jugador2)
            .Include(partida => partida.Ganador)
            .Include(partida => partida.TurnoJugador)
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }
}

