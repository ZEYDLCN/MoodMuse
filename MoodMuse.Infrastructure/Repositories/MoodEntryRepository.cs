// MoodMuse.Infrastructure/Repositories/MoodEntryRepository.cs

using Microsoft.EntityFrameworkCore;
using MoodMuse.Core; // MoodEntry entity'si için
using MoodMuse.Core.Interfaces; // IMoodEntryRepository interface'i için
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoodMuse.Infrastructure.Repositories
{
    public class MoodEntryRepository : IMoodEntryRepository
    {
        private readonly AppDbContext _context; // Veritabanı context'imiz

        // Constructor ile AppDbContext'i enjekte ediyoruz
        public MoodEntryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<MoodEntry> AddAsync(MoodEntry moodEntry)
        {
            // MoodEntry'yi DbContext'e ekle
            await _context.MoodEntries.AddAsync(moodEntry);
            // Değişiklikleri veritabanına kaydet
            await _context.SaveChangesAsync();
            return moodEntry; // Eklenen entity'yi geri döndür
        }

        public async Task<MoodEntry?> GetByIdAsync(int id)
        {
            // Belirli bir ID'ye sahip MoodEntry'yi bul ve User bilgisini de dahil et
            // FirstOrDefaultAsync, eşleşen ilk kaydı veya hiç kayıt yoksa null döner
            return await _context.MoodEntries
                .Include(m => m.User) // İlgili User nesnesini de yükle (Eager Loading)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<MoodEntry>> GetByUserIdAsync(int userId)
        {
            // Belirli bir kullanıcıya ait tüm MoodEntry'leri tarihe göre tersten sıralı olarak getir
            return await _context.MoodEntries
                .Where(m => m.UserId == userId)
                .OrderByDescending(m => m.EntryDate)
                .ToListAsync();
        }
    }
}