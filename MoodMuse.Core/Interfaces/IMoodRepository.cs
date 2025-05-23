using MoodMuse.Core.Models;

namespace MoodMuse.Core.Interfaces;

public interface IMoodRepository
{
    Task<MoodEntry> AddAsync(MoodEntry moodEntry);
    Task<IEnumerable<MoodEntry>> GetUserMoodHistoryAsync(int userId);
} 