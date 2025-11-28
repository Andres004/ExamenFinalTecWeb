using ProyectoFinal.Models.DTOS.Auth;

namespace ProyectoFinal.Services;

public interface IAuthService
{
    Task<LoginResponseDto> LoginAsync(LoginDto dto);
    Task<LoginResponseDto> RegisterPassengerAsync(RegisterPassengerDto dto);
    Task<LoginResponseDto> RegisterDriverAsync(RegisterDriverDto dto);
}
