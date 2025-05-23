// İleride DTO'ları API ve Client arasında paylaşmak için bir Shared proje kullanılabilir.
// Şimdilik DTO'ları Client tarafında da tanımlayacağız veya anonim tipler kullanacağız.
// API'den dönecek MoodAnalysisResultDto'nun client-side karşılığı
// (Bu DTO'yu bir Shared projede veya burada tekrar tanımlayabiliriz)
// Şimdilik MoodsController'dan dönen MoodAnalysisResultDto'nun yapısını varsayalım

namespace MoodMuse.Client.Services;

public class MoodAnalysisResultClientDto // MoodAnalysisResultDto'nun client-side kopyası
{
    public MoodEntryClientDto? MoodEntry { get; set; }
    public IEnumerable<MusicRecommendationClientDto>? MusicRecommendations { get; set; }
    public IEnumerable<MovieRecommendationClientDto>? MovieRecommendations { get; set; }
}
