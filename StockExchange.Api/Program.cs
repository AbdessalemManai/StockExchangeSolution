using Extensions.Hosting.AsyncInitialization;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StockExchange.Api.Controllers.Infrastructure;
using StockExchange.Api.Options;
using StockExchange.Application.Tickers.FindTickerBySymbol;
using StockExchange.Data.Database;
using StockExchange.Data.Domain.Tickers;
using StockExchange.Domain.TickerAggregate;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("CustomTickers.json", false, true);
ConfigurationManager configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<StockExchangeDbContext>(options =>
              options.UseSqlServer(
                  configuration.GetConnectionString("DefaultConnection"),
                  x => x.MigrationsHistoryTable("__MigrationsHistory", StockExchangeDbContext.DEFAULTSCHEMA)
              ),
              ServiceLifetime.Transient);
builder.Services.AddCustomTickersOptions(configuration);
builder.Services.AddAsyncInitializer<SeedInitializer>();

//Add CQRS
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

//Add repository
builder.Services.AddScoped<ITickerRepository, TickerRepository>();

//Add Handler configuration
builder.Services.AddMediatR(typeof(FindTickerBySymbolHandler).GetTypeInfo().Assembly);

var app = builder.Build();

//Launch Seeder 
using (var scope = app.Services.CreateAsyncScope())
{
    var dbInitializer = scope.ServiceProvider.GetRequiredService<IAsyncInitializer>();
    await dbInitializer.InitializeAsync();
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