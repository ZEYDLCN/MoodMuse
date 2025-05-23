using MoodMuse.Application.DTOs;

namespace MoodMuse.Application.Interfaces;

public interface IAuthService
{
    Task<UserDto> RegisterAsync(RegisterUserDto registerDto);
    Task<TokenDto> LoginAsync(LoginDto loginDto);
} 