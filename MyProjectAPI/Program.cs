using MyLibrary;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select((index =>
    {
        var date = CalculateDate(index);

        return new WeatherForecast
        (
            date,
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)],
            WeatherCalculator.DetermineSeason(date)
        );
    }))
    .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

static DateOnly CalculateDate(int index)
{
    return DateOnly.FromDateTime(DateTime.Now.AddDays(index));
}

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary, string Season)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
