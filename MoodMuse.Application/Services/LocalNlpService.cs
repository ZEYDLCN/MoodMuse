// MoodMuse.Application/Services/LocalNlpService.cs
using MoodMuse.Application.Interfaces;
using MoodMuse.Core; // Emotion enum'ı için
using System.Threading.Tasks;

namespace MoodMuse.Application.Services;

public class LocalNlpService : INlpService
{
    public Task<string> AnalyzeSentimentAsync(string text)
    {
        // Basit anahtar kelime analizi
        text = text.ToLower();

        if (text.Contains("mutlu") || text.Contains("sevinç") || text.Contains("güzel"))
            return Task.FromResult("mutlu");
        
        if (text.Contains("üzgün") || text.Contains("kötü") || text.Contains("mutsuz"))
            return Task.FromResult("üzgün");
        
        if (text.Contains("kızgın") || text.Contains("öfke") || text.Contains("sinir"))
            return Task.FromResult("kızgın");
        
        if (text.Contains("heyecan") || text.Contains("coşku"))
            return Task.FromResult("heyecanlı");
        
        if (text.Contains("endişe") || text.Contains("korku") || text.Contains("kaygı"))
            return Task.FromResult("endişeli");
        
        if (text.Contains("sakin") || text.Contains("huzur") || text.Contains("rahat"))
            return Task.FromResult("sakin");

        return Task.FromResult("nötr");
    }
}