using Microsoft.EntityFrameworkCore;
using test_seguros_continental.Application.AutoMappers;
using test_seguros_continental.Application.Interfaces;
using test_seguros_continental.Application.Interfaces.Repository;
using test_seguros_continental.Application.Services;
using test_seguros_continental.Application.Services.Repository;
using test_seguros_continental.Domain.Entities.Client;
using test_seguros_continental.Domain.Entities.Currency;
using test_seguros_continental.Domain.Entities.Quote;
using test_seguros_continental.Domain.Entities.RateRange;
using test_seguros_continental.Domain.Entities.TypeClient;
using test_seguros_continental.Domain.Entities.TypeInsurance;
using test_seguros_continental.Infraestructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICurrencyService, CurrencyService>();
builder.Services.AddScoped<IQuoteService, QuoteService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<ITypeClientService, TypeClientService>();
builder.Services.AddScoped<ITypeInsuranceService, TypeInsuranceService>();
builder.Services.AddScoped<IRateRangeService, RateRangeService>();
builder.Services.AddScoped<ClientRepositoryService, ClientRepositoryService>();
builder.Services.AddScoped<QuoteRepositoryService, QuoteRepositoryService>();


builder.Services.AddScoped<IRepository<CurrencyEntity>, RepositoryService<CurrencyEntity>>();
builder.Services.AddScoped<IRepository<QuoteEntity>, RepositoryService<QuoteEntity>>();
builder.Services.AddScoped<IRepository<ClientEntity>, RepositoryService<ClientEntity>>();
builder.Services.AddScoped<IRepository<TypeClientEntity>, RepositoryService<TypeClientEntity>>();
builder.Services.AddScoped<IRepository<TypeInsuranceEntity>, RepositoryService<TypeInsuranceEntity>>();
builder.Services.AddScoped<IRepository<RateRangeEntity>, RepositoryService<RateRangeEntity>>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()  // ⚠️ Solo para pruebas
                  .AllowAnyMethod()
                  .AllowAnyHeader().SetIsOriginAllowedToAllowWildcardSubdomains(); ;
        });
});

builder.Services.AddAutoMapper(typeof(MappingProfile));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ContinentalContext>(Options =>
{
    Options.UseSqlServer(builder.Configuration.GetConnectionString("StoreConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
