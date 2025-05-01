using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Ocelot yapılandırma dosyasını oku
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

// Ocelot servislerini ekle
builder.Services.AddOcelot(builder.Configuration);

var app = builder.Build();

// HTTPS yönlendirme (isteğe bağlı, https kullanıyorsan)
app.UseHttpsRedirection();

// Ocelot middleware'i en sonda çalışmalı
await app.UseOcelot();

app.Run();