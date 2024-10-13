using AndyJavier_AP1_P1.Components;
using AndyJavier_AP1_P1.DAL;
using AndyJavier_AP1_P1.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Obtenemos el ConStr
var conStr = builder.Configuration.GetConnectionString("ConStr");

// Agregamos el contexto al builder con el ConStr
builder.Services.AddDbContext<Contexto>(options => options.UseSqlite(conStr));

// Registra los servicios
builder.Services.AddScoped<PrestamoServices>();
builder.Services.AddScoped<CobroServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
