using System.Text.Json;
using Microsoft.Extensions.Configuration;
using MoodMuse.Application.Interfaces;

namespace MoodMuse.Infrastructure.Services;

public class OpenAiNlpService : INlpService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private const string OpenAiEndpoint = "https://api.openai.com/v1/chat/completions";

    public OpenAiNlpService(IConfiguration configuration, HttpClient httpClient)
    {
        _apiKey = configuration["OpenAI:ApiKey"] ?? throw new ArgumentNullException(nameof(_apiKey));
        _httpClient = httpClient;
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
    }

    public async Task<string> AnalyzeSentimentAsync(string text)
    {
        var requestBody = new
        {
            model = "gpt-3.5-turbo",
            messages = new[]
            {
                new
                {
                    role = "system",
                    content = "Sen bir duygu analizi uzmanısın. Verilen metni analiz edip, tek kelimelik duygu durumu döndürmelisin. Örnek: mutlu, üzgün, kızgın, heyecanlı, endişeli, sakin."
                },
                new
                {
                    role = "user",
                    content = text
                }
            },
            temperature = 0.7,
            max_tokens = 50
        };

        var response = await _httpClient.PostAsync(
            OpenAiEndpoint,
            new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json")
        );

        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<OpenAiResponse>(responseBody);

        return result?.Choices?[0]?.Message?.Content?.Trim().ToLower() ?? "nötr";
    }
}

public class OpenAiResponse
{
    public required Choice[] Choices { get; set; }
}

public class Choice
{
    public required Message Message { get; set; }
}

public class Message
{
    public required string Content { get; set; }
} 