using Microsoft.EntityFrameworkCore;
using RegistroJugadores.DAL;
using RegistroJugadores.Models;
using System.Linq.Expressions;

namespace RegistroJugadores.Services;

public class MovimientosService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Existe(int MovimientoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Movimientos
            .AnyAsync(Movimientos => Movimientos.MovimientoId == MovimientoId);

    }

    public async Task<bool> Insertar(Movimientos Movimiento)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Movimientos.Add(Movimiento);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Movimientos Movimiento)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Update(Movimiento);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Movimientos Movimiento)
    {
        if (!await Existe(Movimiento.MovimientoId))
        {
            return await Insertar(Movimiento);
        }
        else
        {
            return await Modificar(Movimiento);
        }
    }

    public async Task<Movimientos> Buscar(int MovimientoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Movimientos.FirstOrDefaultAsync(Movimientos => Movimientos.MovimientoId == MovimientoId);
    }

    public async Task<bool> Eliminar(int MovimientoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Movimientos.
            AsNoTracking()
            .Where(Movimientos => Movimientos.MovimientoId == MovimientoId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<List<Movimientos>> Listar(Expression<Func<Movimientos, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Movimientos
            .Include(movimiento => movimiento.Partida)
            .Include(movimiento => movimiento.Jugador)
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }



}
