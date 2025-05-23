namespace MoodMuse.Core.Models;

public class MusicRecommendation
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Artist { get; set; }
    public required string Description { get; set; }
    public string? SpotifyUrl { get; set; }
    public DateTime CreatedAt { get; set; }
} 