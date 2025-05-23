namespace MoodMuse.Core;

public class MusicRecommendation
{
    public int Id { get; set; }
    public Emotion EmotionTag { get; set; } // Hangi duyguya uygun olduğu
    public string TrackName { get; set; } = string.Empty;
    public string Artist { get; set; } = string.Empty;
    public string? SourceLink { get; set; } // Opsiyonel: Spotify, YouTube linki vb.
}