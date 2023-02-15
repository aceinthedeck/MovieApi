using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MovieApi;
using MovieApi.Repository;
using MovieApi.Services;

var builder = WebApplication.CreateBuilder(args);

// DI
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IFileUploadService, LocalFileUploadService>();

var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
if (connectionString == null)
{
    connectionString = builder.Configuration.GetConnectionString("movies");
}

// Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// automaticlly apply migrations on startup
using(var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

