// MoodMuse.API/Controllers/RecommendationsController.cs

using Microsoft.AspNetCore.Mvc;
using MoodMuse.Application.Interfaces;
using MoodMuse.Core; // Emotion enum'ı için
using System;
using System.Linq;
using System.Threading.Tasks;
// using Microsoft.AspNetCore.Authorization; // Auth eklendiğinde bu satırın yorumunu kaldıracağız

namespace MoodMuse.API.Controllers;

[Route("api/[controller]")]
[ApiController]
// [Authorize] // Auth eklendiğinde
public class RecommendationsController : ControllerBase
{
    private readonly IRecommendationService _recommendationService;
    private readonly ILogger<RecommendationsController> _logger; // Loglama için (opsiyonel ama iyi pratik)

    public RecommendationsController(IRecommendationService recommendationService, ILogger<RecommendationsController> logger)
    {
        _recommendationService = recommendationService;
        _logger = logger;
    }

    // GET /api/recommendations/Happy
    // GET /api/recommendations/Sad
    // GET /api/recommendations/1 (Eğer enum'ı sayı olarak göndermek isterseniz)
    [HttpGet("{emotionName}")]
    public async Task<IActionResult> GetRecommendationsByEmotion(string emotionName)
    {
        _logger.LogInformation("Fetching recommendations for emotion: {EmotionName}", emotionName);

        // Gelen string'i Emotion enum'ına çevir.
        // Büyük/küçük harf duyarsız eşleşme için ignoreCase=true
        if (Enum.TryParse<Emotion>(emotionName, true, out Emotion parsedEmotion))
        {
            try
            {
                var musicRecs = await _recommendationService.GetMusicRecommendationsAsync(parsedEmotion);
                var movieRecs = await _recommendationService.GetMovieRecommendationsAsync(parsedEmotion);

                if (!musicRecs.Any() && !movieRecs.Any())
                {
                    _logger.LogWarning("No recommendations found for emotion: {ParsedEmotion}", parsedEmotion);
                    return NotFound($"No recommendations found for emotion: {emotionName}");
                }

                // İki listeyi tek bir anonim nesne veya özel bir DTO içinde döndürebiliriz.
                var result = new
                {
                    Emotion = parsedEmotion.ToString(),
                    MusicRecommendations = musicRecs,
                    MovieRecommendations = movieRecs
                };
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching recommendations for emotion: {EmotionName}", emotionName);
                return StatusCode(500, "An unexpected error occurred while fetching recommendations.");
            }
        }
        else
        {
            _logger.LogWarning("Invalid emotion name provided: {EmotionName}", emotionName);
            // Geçersiz bir duygu adı gelirse Bad Request döndür.
            // Desteklenen duyguların listesini de döndürebiliriz.
            var validEmotions = Enum.GetNames(typeof(Emotion)).ToList();
            return BadRequest($"Invalid emotion name: '{emotionName}'. Valid emotions are: {string.Join(", ", validEmotions)}");
        }
    }
}