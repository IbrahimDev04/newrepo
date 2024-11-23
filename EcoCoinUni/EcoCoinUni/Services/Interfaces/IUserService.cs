using EcoCoinUni.Dtos.UserDtos;

namespace EcoCoinUni.Services.Interfaces;

public interface IUserService
{
    Task RegisterAsync(RegisterDto dto);
}

