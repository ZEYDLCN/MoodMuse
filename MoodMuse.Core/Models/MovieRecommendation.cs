namespace MoodMuse.Core.Models;

public class MovieRecommendation
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Year { get; set; }
    public required string Description { get; set; }
    public string? ImdbUrl { get; set; }
    public DateTime CreatedAt { get; set; }
} 