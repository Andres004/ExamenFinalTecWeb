using ProyectoFinal.Models;
using ProyectoFinal.Models.DTOS;
using ProyectoFinal.Models.DTOS.ProyectoFinal.Models.DTOS;
using ProyectoFinal.Repositories;

namespace ProyectoFinal.Services
{
    public class ConductorService : IConductorService
    {
        private readonly IConductorRepository _conductores;
        private readonly IConfiguration _configuration;

        public ConductorService(IConductorRepository conductores, IConfiguration configuration)
        {
            _conductores = conductores;
            _configuration = configuration;
        }


        public Task<int> CreateAsync(RegisterConductorDto dto)
        {
            throw new NotImplementedException();
        }

        /*
        public async Task<(bool ok, LoginResponseDto? response)> LoginAsync(LoginDto dto)
        {
            var conductor = await _conductores.GetByEmailAddress(dto.Email);
            if (conductor == null) return (false, null);

            var ok = BCrypt.Net.BCrypt.Verify(dto.Password, conductor.PasswordHash);
            if (!ok) return (false, null);

            
            // Generar par access/refresh
            var (accessToken, expiresIn, jti) = GenerateJwtToken(user);
            var refreshToken = GenerateSecureRefreshToken();
            
            var refreshDays = int.Parse(_configuration["Jwt:RefreshDays"] ?? "14");

            conductor.RefreshToken = refreshToken;
            conductor.RefreshTokenExpiresAt = DateTime.UtcNow.AddDays(refreshDays);
            conductor.RefreshTokenRevokedAt = null;
            conductor.CurrentJwtId = jti;
            await _conductores.UpdateAsync(conductor);
            
            var resp = new LoginResponseDto
            {
                User = new UserDto { Id = conductor.Id, Username = conductor.Nombre, Email = conductor.Email },
                Role = conductor.Role,
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                ExpiresIn = expiresIn,
                TokenType = "Bearer"
            };

            return (true, resp);
        }
        

        public async Task<(bool ok, LoginResponseDto? response)> RefreshAsync(RefreshRequestDto dto)
        {
            // Buscar conductor que tenga ese refresh token (simple)
            var user = await _conductores.GetByRefreshToken(dto.RefreshToken);
            if (user == null) return (false, null);

            // Validaciones de refresh
            if (user.RefreshToken != dto.RefreshToken) return (false, null);
            if (user.RefreshTokenRevokedAt.HasValue) return (false, null);
            if (!user.RefreshTokenExpiresAt.HasValue || user.RefreshTokenExpiresAt.Value < DateTime.UtcNow) return (false, null);

            // Rotación: generar nuevo access + refresh y revocar el anterior
            var (accessToken, expiresIn, jti) = GenerateJwtToken(user);
            var newRefresh = GenerateSecureRefreshToken();
            var refreshDays = int.Parse(_configuration["Jwt:RefreshDays"] ?? "14");

            user.RefreshToken = newRefresh;
            user.RefreshTokenExpiresAt = DateTime.UtcNow.AddDays(refreshDays);
            user.RefreshTokenRevokedAt = null; // seguimos activo
            user.CurrentJwtId = jti;
            await _conductores.UpdateAsync(user);

            var resp = new LoginResponseDto
            {
                User = new UserDto { Id = user.Id, Username = user.Nombre, Email = user.Email },
                Role = user.Role,
                AccessToken = accessToken,
                RefreshToken = newRefresh,
                ExpiresIn = expiresIn,
                TokenType = "Bearer"
            };

            return (true, resp);
        }
        */
        public async Task<string> RegisterAsync(RegisterConductorDto dto)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);
            var conductor = new Conductor
            {
                Email = dto.Email,
                PasswordHash = hashedPassword,
                Nombre = dto.Nombre,
                Role = dto.Role
            };
            await _conductores.AddAsync(conductor);
            return conductor.Id.ToString();
        }
    }
}
