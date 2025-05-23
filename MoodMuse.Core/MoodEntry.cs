namespace MoodMuse.Core;

public class MoodEntry
{
    public int Id { get; set; }
    public int UserId { get; set; } // Foreign Key
    public string Text { get; set; } = string.Empty;
    public Emotion DetectedEmotion { get; set; }
    public DateTime EntryDate { get; set; }

    // Navigation Property (İlişkili User için)
    // Bu, her ruh hali girişinin bir kullanıcıya ait olduğunu belirtir.
    public virtual User? User { get; set; }
}