using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Npgsql;
using ProyectoFinal.Data;
using ProyectoFinal.Repositories;
using ProyectoFinal.Services;
using OpenApi = Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// --- 1. CONFIGURACIÓN DE PUERTO PARA RAILWAY ---
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://0.0.0.0:{port}");
// ----------------------------------------------

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApi.OpenApiInfo
    {
        Title = "Transport API",
        Version = "v1",
        Description = "API de Transporte con Autenticación JWT"
    });

    c.AddSecurityDefinition("Bearer", new OpenApi.OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme.",
        Name = "Authorization",
        In = OpenApi.ParameterLocation.Header,
        Type = OpenApi.SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApi.OpenApiSecurityRequirement
    {
        {
            new OpenApi.OpenApiSecurityScheme
            {
                Reference = new OpenApi.OpenApiReference
                {
                    Type = OpenApi.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = OpenApi.ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

// --- 2. LÓGICA DE CONEXIÓN A BASE DE DATOS (RAILWAY + LOCAL) ---
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

// Si existe la variable de Railway, la usamos y la convertimos
if (!string.IsNullOrEmpty(databaseUrl))
{
    var uri = new Uri(databaseUrl);
    var userInfo = uri.UserInfo.Split(':');
    var builderDb = new NpgsqlConnectionStringBuilder
    {
        Host = uri.Host,
        Port = uri.Port,
        Username = userInfo[0],
        Password = userInfo[1],
        Database = uri.LocalPath.TrimStart('/'),
        SslMode = SslMode.Require,
        TrustServerCertificate = true
    };
    connectionString = builderDb.ToString();
}
// ---------------------------------------------------------------

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<IPassengerRepository, PassengerRepository>();
builder.Services.AddScoped<IDriverRepository, DriverRepository>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<ITripRepository, TripRepository>();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IPassengerService, PassengerService>();
builder.Services.AddScoped<IDriverService, DriverService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();
builder.Services.AddScoped<ITripService, TripService>();

// Obtenemos la clave del appsettings O de las variables de entorno (prioridad entorno)
var key = Environment.GetEnvironmentVariable("JWT_KEY") ?? builder.Configuration["Jwt:Key"];

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key!)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

var app = builder.Build();

// Swagger siempre visible (incluso en Producción)
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();