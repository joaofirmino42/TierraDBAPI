using Scalar.AspNetCore;
using TierraDb.Business.Business;
using TierraDb.Business.Interface;
using TierraDB.Dal.Factory;
using TierraDB.Dal.Interfaces;
using TierraDB.Dal.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<ISqlConnectionFactory, SqlConnectionFactory>();

builder.Services.AddScoped<IQuoteBusiness, QuoteBusiness>();
builder.Services.AddScoped<IQuoteRepository, FileRepository>();

builder.Services.AddScoped<IHotelBusiness, HotelBusiness>();
builder.Services.AddScoped<IHotelRepository, HotelRepository>();

builder.Services.AddScoped<IServicoBusiness, ServicoBusiness>();
builder.Services.AddScoped<IServicoRepository, ServicoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.MapScalarApiReference(options =>
{
    options.WithTheme(ScalarTheme.BluePlanet);
});

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
