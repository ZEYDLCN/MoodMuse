// MoodMuse.Application/DTOs/MoodAnalysisResultDto.cs
using System.Collections.Generic;

namespace MoodMuse.Application.DTOs;

public record MoodAnalysisResultDto(
    MoodEntryDto MoodEntry,
    IEnumerable<MusicRecommendationDto> MusicRecommendations,
    IEnumerable<MovieRecommendationDto> MovieRecommendations
);