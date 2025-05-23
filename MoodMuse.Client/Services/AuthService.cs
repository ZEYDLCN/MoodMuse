using System.Net.Http.Json;
using MoodMuse.Application.DTOs;
using MoodMuse.Application.Interfaces;

namespace MoodMuse.Client.Services;

public class AuthService : IAuthService
{
    private readonly HttpClient _httpClient;

    public AuthService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<UserDto> RegisterAsync(RegisterUserDto registerDto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/auth/register", registerDto);
        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception(error);
        }
        return await response.Content.ReadFromJsonAsync<UserDto>();
    }

    public async Task<TokenDto> LoginAsync(LoginDto loginDto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/auth/login", loginDto);
        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception(error);
        }
        return await response.Content.ReadFromJsonAsync<TokenDto>();
    }
} 