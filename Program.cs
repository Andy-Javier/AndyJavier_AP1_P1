using AndyJavier_AP1_P1.Components;
using AndyJavier_AP1_P1.DAL;
using Microsoft.EntityFrameworkCore;
using AndyJavier_AP1_P1.Models;
using AndyJavier_AP1_P1.Services;

namespace AndyJavier_AP1_P1;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        // Obtenemos el ConStr para usarlo en el contexto
        var ConStr = builder.Configuration.GetConnectionString("ConStr");

        // Agregamos el contexto al builder con el ConStr
        builder.Services.AddDbContext<Contexto>(Options => Options.UseSqlite(ConStr));

        // Registro de servicios
        builder.Services.AddScoped<PrestamoServices>();
        builder.Services.AddScoped<DeudorServices>();
        builder.Services.AddScoped<CobroServices>();
        builder.Services.AddScoped<CobroDetalleServices>();

        builder.Services.AddBlazorBootstrap();

        // Habilitar errores detallados para el circuito
        builder.Services.AddServerSideBlazor()
            .AddCircuitOptions(options => {
                options.DetailedErrors = true; // Habilita los errores detallados
            });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage(); // Esto mostrará errores detallados en desarrollo
        }
        else
        {
            app.UseExceptionHandler("/Error", createScopeForErrors: true);
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseAntiforgery();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.Run();
    }
}
