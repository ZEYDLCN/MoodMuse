// MoodMuse.Application/DTOs/MovieRecommendationDto.cs
namespace MoodMuse.Application.DTOs;

public record MovieRecommendationDto(
    int Id,
    string Title,
    string? IMDBLink, // Nullable olabilir
    int? Year,       // Nullable olabilir
    string? Genre    // Nullable olabilir
);