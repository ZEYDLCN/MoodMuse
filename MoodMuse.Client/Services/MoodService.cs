using System.Net.Http.Json;
using MoodMuse.Application.DTOs;
using MoodMuse.Application.Interfaces;

namespace MoodMuse.Client.Services;

public class MoodService : IMoodService
{
    private readonly HttpClient _httpClient;

    public MoodService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<RecommendationResponse> GetRecommendationsAsync(string text, int userId)
    {
        var response = await _httpClient.PostAsJsonAsync("api/moods", text);
        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception(error);
        }
        return await response.Content.ReadFromJsonAsync<RecommendationResponse>();
    }

    public async Task<IEnumerable<MoodEntryDto>> GetUserMoodHistoryAsync(int userId)
    {
        var response = await _httpClient.GetAsync("api/moods/history");
        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception(error);
        }
        return await response.Content.ReadFromJsonAsync<IEnumerable<MoodEntryDto>>();
    }
} 