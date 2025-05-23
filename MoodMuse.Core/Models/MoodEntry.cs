namespace MoodMuse.Core.Models;

public class MoodEntry
{
    public int Id { get; set; }
    public required string Text { get; set; }
    public required string Sentiment { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public int UserId { get; set; }
    public User? User { get; set; }
} 