using CourceProject.Components;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Blazored.LocalStorage;
using CourceProject.Components.Data;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

try
{
    Log.Information("Starting web application");
    var builder = WebApplication.CreateBuilder(args);
    // Add services to the container.
    builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

    builder.Logging.ClearProviders();
    builder.Logging.AddConsole();
    builder.Host.UseSerilog(); // <-- Add this line
    builder.Services.AddBlazoredLocalStorage();
    builder.Services.AddScoped<IUserRepository, InDbSQLiteListUsers>();
    builder.Services.AddScoped<IAccountRepository, InDbSQLiteListAccounts>();

    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseSqlite(builder.Configuration.GetConnectionString("AppDb"));
    });

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


}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}












