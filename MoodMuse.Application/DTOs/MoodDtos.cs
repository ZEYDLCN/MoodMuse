using MoodMuse.Core.Models;

namespace MoodMuse.Application.DTOs;

public class MoodEntryDto
{
    public int Id { get; set; }
    public string Text { get; set; }
    public string Sentiment { get; set; }
    public DateTime CreatedAt { get; set; }

    public MoodEntryDto(int id, string text, string sentiment, DateTime createdAt)
    {
        Id = id;
        Text = text;
        Sentiment = sentiment;
        CreatedAt = createdAt;
    }
}

public class RecommendationResponse
{
    public string Sentiment { get; set; }
    public IEnumerable<MusicRecommendation> MusicRecommendations { get; set; }
    public IEnumerable<MovieRecommendation> MovieRecommendations { get; set; }

    public RecommendationResponse(string sentiment, IEnumerable<MusicRecommendation> musicRecommendations, IEnumerable<MovieRecommendation> movieRecommendations)
    {
        Sentiment = sentiment;
        MusicRecommendations = musicRecommendations;
        MovieRecommendations = movieRecommendations;
    }
} 