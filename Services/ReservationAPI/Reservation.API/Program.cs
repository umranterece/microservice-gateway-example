using Reservation.API.Infrastructure;
using Reservation.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Reservation.API dinleme portu (Ocelot Gateway 9001'e bağlanacak)
builder.WebHost.UseUrls("https://localhost:9001");

// Servis kayıtları
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency injection
builder.Services.AddScoped<IReservationService, ReservationService>();

var app = builder.Build();

// Geliştirme ortamıysa Swagger aç
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// HTTPS zorunlu değilse kapalı bırakabilirsin (yoksa uncomment et)
// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();