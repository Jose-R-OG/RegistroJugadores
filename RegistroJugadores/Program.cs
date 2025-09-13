using RegistroJugadores.Components;
using Microsoft.EntityFrameworkCore;
using RegistroJugadores.DAL;

namespace RegistroJugadores;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        var ConStr = builder.Configuration.GetConnectionString("SqlConStr");
        builder.Services.AddDbContextFactory<Contexto>(options => options.UseSqlServer(ConStr));

        builder.Services.AddScoped<Services.JugadoresService>();
        builder.Services.AddScoped<Services.PartidasService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseAntiforgery();

        app.MapStaticAssets();
        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.Run();
    }
}
