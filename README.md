# 🎭 MoodMuse - Duygu Tabanlı Öneri Sistemi | Mood-Based Recommendation System

## 🌟 Proje Hakkında | About Project

MoodMuse, kullanıcıların duygusal durumlarına göre kişiselleştirilmiş müzik ve film önerileri sunan modern bir web uygulamasıdır. OpenAI'nin güçlü NLP yeteneklerini kullanarak duygu analizi yapar ve kullanıcılara özel öneriler sunar.

MoodMuse is a modern web application that provides personalized music and movie recommendations based on users' emotional states. It performs sentiment analysis using OpenAI's powerful NLP capabilities and offers personalized suggestions to users.

## 🛠️ Teknolojiler | Technologies

### Backend
- **.NET 7.0**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **OpenAI API Integration**
- **JWT Authentication**
- **Clean Architecture**

### Frontend
- **Blazor WebAssembly**
- **Bootstrap 5**
- **Custom Components**

### Database
- **SQL Server** / **MySQL** (configurable)

## 🏗️ Mimari | Architecture

```
MoodMuse/
├── MoodMuse.API/           # Web API katmanı
├── MoodMuse.Application/   # İş mantığı ve servisler
├── MoodMuse.Core/         # Domain modelleri ve interfaces
├── MoodMuse.Infrastructure/# Veritabanı ve dış servisler
└── MoodMuse.Client/       # Blazor WASM UI
```

## ✨ Özellikler | Features

- 🔐 **Kullanıcı Yönetimi | User Management**
  - Kayıt ve Giriş | Registration and Login
  - JWT bazlı kimlik doğrulama | JWT-based authentication

- 🎯 **Duygu Analizi | Sentiment Analysis**
  - OpenAI entegrasyonu | OpenAI integration
  - Gerçek zamanlı analiz | Real-time analysis

- 🎵 **Müzik Önerileri | Music Recommendations**
  - Duygu bazlı öneriler | Mood-based suggestions
  - Spotify bağlantıları | Spotify links

- 🎬 **Film Önerileri | Movie Recommendations**
  - Duygu uyumlu filmler | Mood-matching movies
  - IMDB bağlantıları | IMDB links

- 📊 **Duygu Geçmişi | Mood History**
  - Geçmiş kayıtları | Historical records
  - Duygu trendleri | Emotion trends

## 🚀 Kurulum | Installation

1. Repository'yi klonlayın | Clone the repository:
```bash
git clone https://github.com/ZEYDLCN/MoodMuse.git
```

2. Gerekli paketleri yükleyin | Install dependencies:
```bash
dotnet restore
```

3. Veritabanını oluşturun | Create database:
```bash
cd MoodMuse.API
dotnet ef database update
```

4. API'yi başlatın | Start the API:
```bash
dotnet run
```

5. Client'ı başlatın | Start the client:
```bash
cd ../MoodMuse.Client
dotnet run
```

## ⚙️ Yapılandırma | Configuration

`appsettings.json` dosyasında aşağıdaki ayarları yapın | Configure the following in appsettings.json:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "your_database_connection_string"
  },
  "JwtSettings": {
    "Secret": "your_jwt_secret_key",
    "ExpirationInMinutes": 60
  },
  "OpenAI": {
    "ApiKey": "your_openai_api_key"
  }
}
```

## 🤝 Katkıda Bulunma | Contributing

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📝 Lisans | License

Bu proje MIT lisansı altında lisanslanmıştır. Detaylar için [LICENSE](LICENSE) dosyasına bakın.

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## 📞 İletişim | Contact

Zeynep Dilican - [@ZEYDLCN](https://github.com/ZEYDLCN)

Proje Linki | Project Link: [https://github.com/ZEYDLCN/MoodMuse](https://github.com/ZEYDLCN/MoodMuse) 