using Microsoft.EntityFrameworkCore;
using SecurityDemo;

var builder = WebApplication.CreateBuilder(args);

// 1. Registrera databasen
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=app.db"));

builder.Services.AddControllers();
builder.Services.AddCors(options => {
    options.AddPolicy("AllowAngular", 
        policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// 2. Skapa databasfilen automatiskt vid start
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

app.UseCors("AllowAngular");
app.MapControllers();
app.Run();