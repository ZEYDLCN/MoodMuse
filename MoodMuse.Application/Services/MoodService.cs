// MoodMuse.Application/Services/MoodService.cs
// ... (mevcut using'ler) ...
// using MoodMuse.Core.Interfaces; // IMoodEntryRepository için - zaten var
// using MoodMuse.Application.Interfaces; // INlpService için - zaten var, IRecommendationService de eklenecek

using MoodMuse.Application.DTOs;
using MoodMuse.Application.Interfaces;
using MoodMuse.Core.Models;
using MoodMuse.Core.Interfaces;

namespace MoodMuse.Application.Services;

public class MoodService : IMoodService
{
    private readonly INlpService _nlpService;
    private readonly IMoodRepository _moodRepository;

    public MoodService(INlpService nlpService, IMoodRepository moodRepository)
    {
        _nlpService = nlpService;
        _moodRepository = moodRepository;
    }

    public async Task<RecommendationResponse> GetRecommendationsAsync(string text, int userId)
    {
        var sentiment = await _nlpService.AnalyzeSentimentAsync(text);

        // Örnek öneriler (gerçek uygulamada bir öneri algoritması kullanılmalı)
        var musicRecommendations = new List<MusicRecommendation>
        {
            new MusicRecommendation
            {
                Title = "Happy",
                Artist = "Pharrell Williams",
                Description = "Neşeli bir şarkı",
                SpotifyUrl = "https://open.spotify.com/track/60nZcImufyMA1MKQY3dcCH",
                CreatedAt = DateTime.UtcNow
            }
        };

        var movieRecommendations = new List<MovieRecommendation>
        {
            new MovieRecommendation
            {
                Title = "La La Land",
                Year = "2016",
                Description = "Müzikal romantik film",
                ImdbUrl = "https://www.imdb.com/title/tt3783958/",
                CreatedAt = DateTime.UtcNow
            }
        };

        // Kullanıcının ruh halini kaydet
        var moodEntry = new MoodEntry
        {
            UserId = userId,
            Text = text,
            Sentiment = sentiment,
            CreatedAt = DateTime.UtcNow
        };

        await _moodRepository.AddAsync(moodEntry);

        return new RecommendationResponse(sentiment, musicRecommendations, movieRecommendations);
    }

    public async Task<IEnumerable<MoodEntryDto>> GetUserMoodHistoryAsync(int userId)
    {
        var moodEntries = await _moodRepository.GetUserMoodHistoryAsync(userId);
        return moodEntries.Select(m => new MoodEntryDto(m.Id, m.Text, m.Sentiment, m.CreatedAt));
    }
}