// MoodMuse.Core/Interfaces/IMoodEntryRepository.cs

using MoodMuse.Core; // MoodEntry entity'si için (eğer entity'ler Core projesinin kökündeyse)

namespace MoodMuse.Core.Interfaces // Eğer Interfaces klasörü oluşturduysan
// namespace MoodMuse.Core // Eğer direkt Core projesinin köküne eklediysen
{
    public interface IMoodEntryRepository
    {
        Task<MoodEntry> AddAsync(MoodEntry moodEntry);
        Task<MoodEntry?> GetByIdAsync(int id); // İleride lazım olabilir
        Task<IEnumerable<MoodEntry>> GetByUserIdAsync(int userId); // İleride lazım olabilir
        // İhtiyaç duyulabilecek diğer metodlar buraya eklenebilir
    }
}