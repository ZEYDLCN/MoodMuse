// MoodMuse.Application/Interfaces/IRecommendationService.cs
using MoodMuse.Application.DTOs;
using MoodMuse.Core; // Emotion enum'ı için
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoodMuse.Application.Interfaces;

public interface IRecommendationService
{
    Task<IEnumerable<MusicRecommendationDto>> GetMusicRecommendationsAsync(Emotion emotion);
    Task<IEnumerable<MovieRecommendationDto>> GetMovieRecommendationsAsync(Emotion emotion);
}