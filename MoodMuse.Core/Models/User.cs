namespace MoodMuse.Core.Models;

public class User
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    public required string PasswordSalt { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<MoodEntry> MoodEntries { get; set; } = new List<MoodEntry>();
} 