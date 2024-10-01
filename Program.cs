using AndyJavier_AP1_P1.Components;
using AndyJavier_AP1_P1.DAL;
using Microsoft.EntityFrameworkCore;

namespace AndyJavier_AP1_P1;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        var conStr = builder.Configuration.GetConnectionString("ConStr");
        builder.Services.AddDbContext<Contexto>(options => options.UseSqlite(conStr));

        // Registrar PrestamoServices
        builder.Services.AddScoped<PrestamoServices>();
        builder.Services.AddBlazorBootstrap();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
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
