using WebApplication.Services;

var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services
    .AddTransient<TransientService>()
    .AddScoped<ScopedService>()
    .AddSingleton<SingletonService>()
    ;

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
