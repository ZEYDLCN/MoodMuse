// İleride DTO'ları API ve Client arasında paylaşmak için bir Shared proje kullanılabilir.
// Şimdilik DTO'ları Client tarafında da tanımlayacağız veya anonim tipler kullanacağız.
// API'den dönecek MoodAnalysisResultDto'nun client-side karşılığı
// (Bu DTO'yu bir Shared projede veya burada tekrar tanımlayabiliriz)
// Şimdilik MoodsController'dan dönen MoodAnalysisResultDto'nun yapısını varsayalım

namespace MoodMuse.Client.Services;

public class MoodEntryClientDto // Bu, MoodEntryDto'nun client-side kopyası
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string? Text { get; set; }
    public string? DetectedEmotion { get; set; }
    public DateTime EntryDate { get; set; }
}
