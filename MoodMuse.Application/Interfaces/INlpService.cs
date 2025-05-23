// MoodMuse.Application/Interfaces/INlpService.cs
using MoodMuse.Core; // Emotion enum'ı için
using System.Threading.Tasks;

namespace MoodMuse.Application.Interfaces;

public interface INlpService
{
    Task<string> AnalyzeSentimentAsync(string text);
}