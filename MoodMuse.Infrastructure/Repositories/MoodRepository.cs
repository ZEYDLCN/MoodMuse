using Microsoft.EntityFrameworkCore;
using MoodMuse.Core.Interfaces;
using MoodMuse.Core.Models;
using MoodMuse.Infrastructure.Data;

namespace MoodMuse.Infrastructure.Repositories;

public class MoodRepository : IMoodRepository
{
    private readonly ApplicationDbContext _context;

    public MoodRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<MoodEntry> AddAsync(MoodEntry moodEntry)
    {
        _context.MoodEntries.Add(moodEntry);
        await _context.SaveChangesAsync();
        return moodEntry;
    }

    public async Task<IEnumerable<MoodEntry>> GetUserMoodHistoryAsync(int userId)
    {
        return await _context.MoodEntries
            .Where(m => m.UserId == userId)
            .OrderByDescending(m => m.CreatedAt)
            .ToListAsync();
    }
} 