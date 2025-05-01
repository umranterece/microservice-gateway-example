using Contact.API.Infrastructure;
using Contact.API.Services;

var builder = WebApplication.CreateBuilder(args);

// API dinleme adresini belirle
builder.WebHost.UseUrls("https://localhost:9002");

// Controller ve servisleri ekle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Bağımlılıkları ekle
builder.Services.AddScoped<IContactService, ContactService>();

var app = builder.Build();

// Development ortamında Swagger aktif olsun
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// HTTPS yönlendirme (gerekliyse aktif et)
// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();