using BlazorServer.BuilderPatternExample.Data;
using BlazorServer.BuilderPatternExample.Infrastructure;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using NetCore.AutoRegisterDi;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();
builder.Services.AddSingleton<WeatherForecastService>();

InjectPatternFromAssemblies(builder, "Repository");
InjectPatternFromAssemblies(builder, "Service");

builder.Services.AddDbContext<BuilderPatternExampleContext>(
    opt => opt.UseSqlite(builder.Configuration.GetConnectionString("BuilderPattern")));

var app = builder.Build();

await EnsureDbIsMigrated(app.Services);

async Task EnsureDbIsMigrated(IServiceProvider services)
{
    using var scope = services.CreateScope();
    using var ctx = scope.ServiceProvider.GetService<BuilderPatternExampleContext>();
    if (ctx != null)
    {
        await ctx.Database.MigrateAsync();
    }
}

void InjectPatternFromAssemblies(WebApplicationBuilder builder, string pattern, params Assembly[] assembly)
{
    builder.Services.RegisterAssemblyPublicNonGenericClasses(assembly)
            .Where(c => c.Name.EndsWith(pattern, StringComparison.CurrentCultureIgnoreCase))
            .AsPublicImplementedInterfaces();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
