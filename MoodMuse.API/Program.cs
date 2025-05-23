// MoodMuse.API/Program.cs

using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using MoodMuse.Application.Interfaces;         // Application katman interface'leri
using MoodMuse.Application.Services;          // Application katman� servisleri
using MoodMuse.Core.Interfaces;               // Core katman� interface'leri
using MoodMuse.Infrastructure;                // AppDbContext
using MoodMuse.Infrastructure.Repositories;     // Infrastructure katman� repository'leri
using Microsoft.Extensions.DependencyInjection; // CreateScope i�in
using MoodMuse.Core;                           // User entity'si i�in
using Microsoft.Extensions.Logging;             // ILogger i�in
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// 1. Veritaban balant string'ini appsettings.json'dan al
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. AppDbContext'i DI container'a ekle
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString, npgsqlOptionsAction: sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(30),
            errorCodesToAdd: null);
    }));

// DI Kay�tlar�
builder.Services.AddScoped<IMoodEntryRepository, MoodEntryRepository>();
builder.Services.AddScoped<IMusicRecommendationRepository, MusicRecommendationRepository>();
builder.Services.AddScoped<IMovieRecommendationRepository, MovieRecommendationRepository>();
builder.Services.AddScoped<INlpService, LocalNlpService>();
builder.Services.AddScoped<IMoodService, MoodService>();
builder.Services.AddScoped<IRecommendationService, RecommendationService>();

// << ---- CORS AYARI BA�LANGICI (G�N 4 EKLENT�S�) ---- >>
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins"; // CORS policy ad�

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          // Blazor WASM uygulaman�z�n �al��t��� adresleri buraya yaz�n.
                          // MoodMuse.Client projesinin Properties/launchSettings.json dosyas�ndaki
                          // applicationUrl de�erlerinden HTTPS ve HTTP portlar�n� al�n.
                          // �RNEK PORTLAR (KEND� PORTLARINIZLA DE���T�R�N!):
                          policy.WithOrigins("https://localhost:7050", // Blazor WASM HTTPS portu
                                             "http://localhost:5050")  // Blazor WASM HTTP portu
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});
// << ---- CORS AYARI SONU ---- >>

// JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // Veritaban� Migration ve Test Kullan�c�s� Seeding
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var logger = services.GetRequiredService<ILogger<Program>>();
        try
        {
            var context = services.GetRequiredService<AppDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                logger.LogInformation("Applying database migrations...");
                context.Database.Migrate();
                logger.LogInformation("Database migrations applied successfully.");
            }
            else
            {
                logger.LogInformation("No pending migrations to apply.");
            }
            if (!context.Users.Any())
            {
                logger.LogInformation("Seeding initial Test User...");
                context.Users.Add(new User { Name = "Test User One", Email = "testuser1@example.com" });
                context.SaveChanges();
                logger.LogInformation("Initial Test User seeded successfully. First user ID should be 1.");
            }
            else
            {
                logger.LogInformation("Users table is not empty. Skipping seed for Test User.");
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while migrating or seeding the database.");
        }
    }
}

app.UseHttpsRedirection();

// << ---- CORS MIDDLEWARE'�N� EKLE (G�N 4 EKLENT�S�) ---- >>
// Bu sat�r UseRouting'den sonra (e�er a��k�a eklenmi�se) ve UseAuthentication/UseAuthorization'dan �nce gelmelidir.
// .NET 6'da UseHttpsRedirection'dan sonra, UseAuthorization'dan �nce iyi bir yerdir.
app.UseCors(MyAllowSpecificOrigins);
// << ---- CORS MIDDLEWARE'� SONU ---- >>

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();