// MoodMuse.Application/DTOs/MusicRecommendationDto.cs
namespace MoodMuse.Application.DTOs;

public record MusicRecommendationDto(
    int Id,
    string TrackName,
    string Artist,
    string? SourceLink // Nullable olabilir
);