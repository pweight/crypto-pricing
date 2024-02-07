using crypto_pricing.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<ICoinMarketcapService, CoinMarketcapService>(client =>
{
    // client.BaseAddress = new Uri("https://sandbox-api.coinmarketcap.com/");
    client.BaseAddress = new Uri("https://pro-api.coinmarketcap.com/");
    client.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", "SECRET_CMC_PRO_API_KEY");
});

var app = builder.Build();

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
