namespace MoodMuse.Core;

public class MovieRecommendation
{
    public int Id { get; set; }
    public Emotion EmotionTag { get; set; } // Hangi duyguya uygun olduğu
    public string Title { get; set; } = string.Empty;
    public string? IMDBLink { get; set; }
    public int? Year { get; set; } // Opsiyonel
    public string? Genre { get; set; } // Opsiyonel
}