namespace MoodMuse.Application.DTOs;

public record RegisterUserDto(
    string Username,
    string Email,
    string Password
);

public record LoginDto(
    string Email,
    string Password
);

public record TokenDto(
    string Token,
    DateTime ExpiresAt
);

public record UserDto(
    int Id,
    string Username,
    string Email
); 