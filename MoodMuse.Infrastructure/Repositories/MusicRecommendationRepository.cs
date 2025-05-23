// MoodMuse.Infrastructure/Repositories/MusicRecommendationRepository.cs
using Microsoft.EntityFrameworkCore;
using MoodMuse.Core; // MusicRecommendation ve Emotion için
using MoodMuse.Core.Interfaces; // IMusicRecommendationRepository için
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoodMuse.Infrastructure.Repositories;

public class MusicRecommendationRepository : IMusicRecommendationRepository
{
    private readonly AppDbContext _context;

    public MusicRecommendationRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<MusicRecommendation>> GetByEmotionAsync(Emotion emotion)
    {
        // Belirli bir duyguya (Emotion enum'ının integer değeri) sahip müzik önerilerini getir.
        // Örnek: İlk 5 tanesini alalım (isteğe bağlı)
        return await _context.MusicRecommendations
            .Where(r => r.EmotionTag == emotion)
            .Take(5) // Her duygu için en fazla 5 öneri gösterelim (isteğe bağlı)
            .ToListAsync();
    }
}