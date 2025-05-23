// MoodMuse.Client/Program.cs
using Microsoft.AspNetCore.Components.Web;
using MoodMuse.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MoodMuse.Client; // E�er App component'i veya ba�ka referanslar varsa
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app"); // Varsay�lan App component'i
builder.RootComponents.Add<HeadOutlet>("head::after"); // Head y�netimi i�in

// API i�in HttpClient'� yap�land�r ve DI container'a ekle
// Backend API'nizin �al��t��� adresi buraya yaz�n.
// Geli�tirme s�ras�nda API'niz genellikle https://localhost:PORT_NUMARASI gibi bir adreste �al���r.
// MoodMuse.API projesinin launchSettings.json dosyas�ndaki applicationUrl'den do�ru portu al�n.
// �rne�in, API'niz 7180 portunda �al���yorsa:
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
builder.Services.AddScoped<IAuthService, AuthService>();

// Auth handler'ı ekle
builder.Services.AddScoped<AuthorizationMessageHandler>();
builder.Services.AddHttpClient("AuthAPI", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"] ?? builder.HostEnvironment.BaseAddress);
}).AddHttpMessageHandler<AuthorizationMessageHandler>();

builder.Services.AddScoped<MoodApiService>();
// Eer API'niz farkl bir portta �al���yorsa (�rn: 5180 http i�in), onu kullan�n.
// HTTPS kullanmak daha iyidir.

// Buraya ileride ekleyece�imiz client-side servisleri de kaydedece�iz.
// builder.Services.AddScoped<IMoodApiService, MoodApiService>();

await builder.Build().RunAsync();