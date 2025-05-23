// MoodMuse.Application/DTOs/CreateMoodEntryDto.cs
namespace MoodMuse.Application.DTOs;

public record CreateMoodEntryDto(string Text);
// Şimdilik sadece metin alıyoruz. UserId'yi serviste veya controller'da ele alacağız.