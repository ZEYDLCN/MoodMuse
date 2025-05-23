namespace MoodMuse.Core;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty; // Nullable referans tipleri için başlangıç değeri
    public string Email { get; set; } = string.Empty;

    // Şifre ile ilgili alanları (PasswordHash, PasswordSalt) şimdilik eklemiyoruz.
    // Onları Gün 6'da Auth kısmında ekleyeceğiz.

    // Navigation Property (İlişkili MoodEntry'ler için)
    // Bu, bir kullanıcının birden fazla ruh hali girişi olabileceğini belirtir.
    public virtual ICollection<MoodEntry> MoodEntries { get; set; } = new List<MoodEntry>();
}