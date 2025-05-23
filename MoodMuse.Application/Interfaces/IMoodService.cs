// MoodMuse.Application/Interfaces/IMoodService.cs
// ...
using MoodMuse.Application.DTOs;

namespace MoodMuse.Application.Interfaces;

public interface IMoodService
{
    Task<RecommendationResponse> GetRecommendationsAsync(string text, int userId);
    Task<IEnumerable<MoodEntryDto>> GetUserMoodHistoryAsync(int userId);
}