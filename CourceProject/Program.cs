using CourceProject.Components;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Blazored.SessionStorage;
using CourceProject.Components.Data;
using CourceProject.Components.Services;
using CourceProject.Components.Models;
using Blazored.Toast;
using Microsoft.Extensions.DependencyInjection;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("log.txt")
    .CreateLogger();
Log.Logger.Information("Запуск приложения: " + DateTime.Now);
try
{
    Log.Information("Starting web application");
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
    builder.Services.AddBlazoredToast();
    
    builder.Logging.ClearProviders();
    builder.Logging.AddConsole();
    builder.Host.UseSerilog(); // <-- Add this line
    builder.Services.AddOptions<CryptoString>()
    .BindConfiguration("CryptoString");
    builder.Services.AddBlazoredSessionStorage();
    builder.Services.AddScoped<IEmailSender>(sendMessage=>new SmtpEmailSender("AdministrationManagerPasswords"));
    builder.Services.AddScoped<IEncryptor, PassswordEncryptor>();
    builder.Services.AddScoped<IUserRepository, InDbSQLiteListUsers>();
    builder.Services.AddScoped<IAccountRepository, InDbSQLiteListAccounts>();
    builder.Services.AddScoped<IConfidantRepository, InDbSQLiteListConfidants>();
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
    Log.Logger.Information("Остановка приложения: " + DateTime.Now);
    Log.CloseAndFlush();
}












