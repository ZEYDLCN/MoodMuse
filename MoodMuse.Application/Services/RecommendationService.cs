// MoodMuse.Application/Services/RecommendationService.cs
using MoodMuse.Application.DTOs;
using MoodMuse.Application.Interfaces;
using MoodMuse.Core; // Emotion enum'ı için
using MoodMuse.Core.Interfaces; // Repository interface'leri için
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoodMuse.Application.Services;

public class RecommendationService : IRecommendationService
{
    private readonly IMusicRecommendationRepository _musicRepo;
    private readonly IMovieRecommendationRepository _movieRepo;

    public RecommendationService(
        IMusicRecommendationRepository musicRecommendationRepository,
        IMovieRecommendationRepository movieRecommendationRepository)
    {
        _musicRepo = musicRecommendationRepository;
        _movieRepo = movieRecommendationRepository;
    }

    public async Task<IEnumerable<MusicRecommendationDto>> GetMusicRecommendationsAsync(Emotion emotion)
    {
        var recommendations = await _musicRepo.GetByEmotionAsync(emotion);

        // Entity'leri DTO'lara map et (Normalde AutoMapper kullanılır)
        return recommendations.Select(r => new MusicRecommendationDto(
            r.Id,
            r.TrackName,
            r.Artist,
            r.SourceLink
        ));
    }

    public async Task<IEnumerable<MovieRecommendationDto>> GetMovieRecommendationsAsync(Emotion emotion)
    {
        var recommendations = await _movieRepo.GetByEmotionAsync(emotion);

        // Entity'leri DTO'lara map et
        return recommendations.Select(r => new MovieRecommendationDto(
            r.Id,
            r.Title,
            r.IMDBLink,
            r.Year,
            r.Genre
        ));
    }
}