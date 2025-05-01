# Microservice Gateway Example with Ocelot

Bu proje, .NET 6 ile geliştirilmiş bir **Microservice mimarisi örneğidir**.  
Merkezi bir **API Gateway** ile iki mikroservisin (Reservation ve Contact) yönetimi ve yönlendirmesi sağlanmıştır.

---

## 🧱 Proje Yapısı


---

## 🚀 Teknolojiler

- ASP.NET Core 6
- Ocelot (API Gateway)
- Minimal API yapılandırması
- Swagger (her mikroserviste)
- REST mimarisi
- Rider IDE uyumlu yapı
- Git version control

---

## ⚙️ Çalıştırma Talimatları (Rider)

### 1. Rider'da aç
Projeyi **Rider IDE** ile açın.

### 2. Gerekli portları kontrol edin

| Servis          | URL                          |
|-----------------|------------------------------|
| APIGateway      | `https://localhost:9000`     |
| Reservation.API | `https://localhost:9001`     |
| Contact.API     | `https://localhost:9002`     |

### 3. `launchSettings.json` dosyaları hazır

Her projede doğru portla yapılandırılmıştır.

### 4. `Run/Debug Configurations` → `Compound` yapı oluştur

- APIGateway
- Reservation.API
- Contact.API  
aynı anda ayağa kaldırılır.

---

## 🔁 Ocelot Yönlendirme Kuralları

### `ocelot.json` içeriği:

```json
{
  "Routes": [
    {
      "DownstreamPathTemplate": "/api/Reservation/{id}",
      "DownstreamScheme": "https",
      "DownstreamHostAndPorts": [{ "Host": "localhost", "Port": 9001 }],
      "UpstreamPathTemplate": "/r/{id}",
      "UpstreamHttpMethod": [ "GET" ]
    },
    {
      "DownstreamPathTemplate": "/api/Contact/{id}",
      "DownstreamScheme": "https",
      "DownstreamHostAndPorts": [{ "Host": "localhost", "Port": 9002 }],
      "UpstreamPathTemplate": "/c/{id}",
      "UpstreamHttpMethod": [ "GET" ]
    }
  ],
  "GlobalConfiguration": {
    "BaseUrl": "https://localhost:9000"
  }
}
