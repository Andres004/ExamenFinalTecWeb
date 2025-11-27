using ProyectoFinal.Models.DTOS;
using ProyectoFinal.Models.DTOS.ProyectoFinal.Models.DTOS;

namespace ProyectoFinal.Services
{
    public interface IConductorService
    {
        Task<int> CreateAsync(CreateConductorDto dto);
        //Task<ConductorViajesDto?> GetViajesAsync(int id);

        //Task<(bool ok, LoginResponseDto? response)> LoginAsync(LoginDto dto);
        Task<string> RegisterAsync(RegisterConductorDto dto);
        //Task<(bool ok, LoginResponseDto? response)> RefreshAsync(RefreshRequestDto dto);
    }
}
