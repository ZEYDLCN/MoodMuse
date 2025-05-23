// MoodMuse.Infrastructure/Repositories/MovieRecommendationRepository.cs
using Microsoft.EntityFrameworkCore;
using MoodMuse.Core; // MovieRecommendation ve Emotion için
using MoodMuse.Core.Interfaces; // IMovieRecommendationRepository için
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoodMuse.Infrastructure.Repositories;

public class MovieRecommendationRepository : IMovieRecommendationRepository
{
    private readonly AppDbContext _context;

    public MovieRecommendationRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<MovieRecommendation>> GetByEmotionAsync(Emotion emotion)
    {
        // Belirli bir duyguya (Emotion enum'ının integer değeri) sahip film önerilerini getir.
        // Örnek: İlk 3 tanesini alalım (isteğe bağlı)
        return await _context.MovieRecommendations
            .Where(r => r.EmotionTag == emotion)
            .Take(3) // Her duygu için en fazla 3 öneri gösterelim (isteğe bağlı)
            .ToListAsync();
    }
}