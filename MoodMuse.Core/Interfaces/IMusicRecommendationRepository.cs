// MoodMuse.Core/Interfaces/IMusicRecommendationRepository.cs
using MoodMuse.Core; // MusicRecommendation ve Emotion için
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoodMuse.Core.Interfaces;

public interface IMusicRecommendationRepository
{
    Task<IEnumerable<MusicRecommendation>> GetByEmotionAsync(Emotion emotion);
    // İleride farklı filtreleme veya getirme metodları eklenebilir
}