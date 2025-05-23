# MoodMuse - Ruh Haline Göre Öneri Sistemi

MoodMuse, kullanıcıların ruh hallerine göre müzik ve film önerileri sunan bir web uygulamasıdır. Doğal dil işleme (NLP) teknolojileri kullanarak kullanıcının duygusal durumunu analiz eder ve buna uygun öneriler sunar.

## Özellikler

- Kullanıcı kayıt ve giriş sistemi
- Ruh hali analizi (OpenAI GPT-3.5 ile)
- Kişiselleştirilmiş müzik ve film önerileri
- Ruh hali geçmişi görüntüleme ve filtreleme
- Modern ve kullanıcı dostu arayüz

## Teknolojiler

- Backend: ASP.NET Core 7.0
- Frontend: Blazor WebAssembly
- Veritabanı: SQL Server
- Authentication: JWT
- NLP: OpenAI GPT-3.5
- UI Framework: Bootstrap 5

## Kurulum

1. Projeyi klonlayın:
```bash
git clone https://github.com/yourusername/MoodMuse.git
```

2. Veritabanını oluşturun:
```bash
cd MoodMuse
dotnet ef database update
```

3. API anahtarlarını ayarlayın:
- `MoodMuse.API/appsettings.json` dosyasında OpenAI API anahtarınızı ekleyin
- JWT secret key'i güncelleyin

4. Projeyi çalıştırın:
```bash
dotnet run --project MoodMuse.API
dotnet run --project MoodMuse.Client
```

## Kullanım

1. Kayıt olun veya giriş yapın
2. Ana sayfada duygularınızı yazın
3. Sistem duygu analizini yapacak ve size öneriler sunacak
4. Geçmiş sayfasından önceki ruh hallerinizi görüntüleyebilirsiniz

## Katkıda Bulunma

1. Fork edin
2. Feature branch oluşturun (`git checkout -b feature/amazing-feature`)
3. Değişikliklerinizi commit edin (`git commit -m 'Add some amazing feature'`)
4. Branch'inizi push edin (`git push origin feature/amazing-feature`)
5. Pull Request oluşturun

## Lisans

Bu proje MIT lisansı altında lisanslanmıştır. Detaylar için `LICENSE` dosyasına bakın. 