// MoodMuse.Core/Interfaces/IMovieRecommendationRepository.cs
using MoodMuse.Core; // MovieRecommendation ve Emotion için
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoodMuse.Core.Interfaces;

public interface IMovieRecommendationRepository
{
    Task<IEnumerable<MovieRecommendation>> GetByEmotionAsync(Emotion emotion);
    // İleride farklı filtreleme veya getirme metodları eklenebilir
}