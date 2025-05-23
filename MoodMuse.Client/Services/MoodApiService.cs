using System;
using System.Net.Http;
using System.Net.Http.Json; // AddJsonAsync ve ReadFromJsonAsync için
using System.Threading.Tasks;
// İleride DTO'ları API ve Client arasında paylaşmak için bir Shared proje kullanılabilir.
// Şimdilik DTO'ları Client tarafında da tanımlayacağız veya anonim tipler kullanacağız.
// API'den dönecek MoodAnalysisResultDto'nun client-side karşılığı
// (Bu DTO'yu bir Shared projede veya burada tekrar tanımlayabiliriz)
// Şimdilik MoodsController'dan dönen MoodAnalysisResultDto'nun yapısını varsayalım

namespace MoodMuse.Client.Services;
public class MoodApiService
{
    private readonly HttpClient _httpClient;
    public MoodApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<MoodAnalysisResultClientDto?> CreateMoodEntryAsync(string moodText)
    {
        if (string.IsNullOrWhiteSpace(moodText))
        {
            return null; // veya throw new ArgumentException("Mood text cannot be empty.");
        }

        var requestDto = new CreateMoodEntryClientDto { Text = moodText };

        // API'deki POST /api/moods endpoint'ine istek gönder
        var response = await _httpClient.PostAsJsonAsync("api/moods", requestDto);

        if (response.IsSuccessStatusCode)
        {
            // Başarılı ise, cevabı MoodAnalysisResultClientDto olarak oku
            return await response.Content.ReadFromJsonAsync<MoodAnalysisResultClientDto>();
        }
        else
        {
            // Hata durumunda (şimdilik) null döndür veya hata detayını logla/işle
            // var errorContent = await response.Content.ReadAsStringAsync();
            // Console.WriteLine($"Error from API: {response.StatusCode} - {errorContent}");
            return null;
        }
    }
    
}