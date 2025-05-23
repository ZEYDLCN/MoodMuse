// MoodMuse.API/Controllers/MoodsController.cs

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoodMuse.Application.DTOs;
using MoodMuse.Application.Interfaces;
using System.Threading.Tasks;
// using Microsoft.AspNetCore.Authorization; // Auth eklendiğinde bu satırın yorumunu kaldıracağız
// using Microsoft.Extensions.Logging; // Eğer bu controller'da da loglama istersen

namespace MoodMuse.API.Controllers;

[Route("api/[controller]")] // URL: /api/moods
[ApiController]
[Authorize]
public class MoodsController : ControllerBase
{
    private readonly IMoodService _moodService;
    // private readonly ILogger<MoodsController> _logger; // Opsiyonel: Bu controller için loglama

    public MoodsController(IMoodService moodService /*, ILogger<MoodsController> logger */)
    {
        _moodService = moodService;
        // _logger = logger; // Opsiyonel
    }

    [HttpPost] // POST /api/moods
    public async Task<IActionResult> CreateMoodEntry([FromBody] CreateMoodEntryDto createMoodEntryDto)
    {
        if (createMoodEntryDto == null || string.IsNullOrWhiteSpace(createMoodEntryDto.Text))
        {
            return BadRequest("Mood text cannot be empty.");
        }

        if (!ModelState.IsValid) // DTO'da validasyon attribute'ları varsa
        {
            return BadRequest(ModelState);
        }

        // TODO: UserId'yi authentication'dan al. Şimdilik sabit bir değer kullanalım.
        var tempUserId = 1; // Örnek kullanıcı ID'si (Program.cs'de oluşturduğumuz kullanıcı)

        try
        {
            // _moodService.CreateMoodEntryAsync artık MoodAnalysisResultDto döndürüyor
            var moodAnalysisResult = await _moodService.CreateMoodEntryAsync(createMoodEntryDto, tempUserId);

            if (moodAnalysisResult == null)
            {
                // _logger?.LogError("MoodService returned null for CreateMoodEntryAsync."); // Opsiyonel loglama
                return StatusCode(500, "An error occurred while processing your mood entry.");
            }

            // Oluşturulan kaynağın URI'si ile birlikte 201 Created döndürmek daha iyi bir pratiktir.
            // Ancak MoodAnalysisResultDto'nun bir 'Id'si olmadığı için direkt Ok dönüyoruz.
            // İstersen moodAnalysisResult.MoodEntry.Id üzerinden CreatedAtAction yapabilirsin.
            return Ok(moodAnalysisResult);
        }
        catch (Exception ex)
        {
            // _logger?.LogError(ex, "An error occurred in CreateMoodEntry endpoint."); // Opsiyonel loglama
            // Geliştirme ortamında daha detaylı hata döndürülebilir:
            // return StatusCode(500, $"An unexpected error occurred: {ex.Message}");
            return StatusCode(500, "An unexpected error occurred while creating the mood entry.");
        }
    }

    [HttpPost]
    public async Task<ActionResult<RecommendationResponse>> AnalyzeMood([FromBody] string text)
    {
        try
        {
            var userId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value);
            var result = await _moodService.GetRecommendationsAsync(text, userId);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("history")]
    public async Task<ActionResult<IEnumerable<MoodEntryDto>>> GetHistory()
    {
        try
        {
            var userId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value);
            var history = await _moodService.GetUserMoodHistoryAsync(userId);
            return Ok(history);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}