using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Tipoul.Wallet.Switch.Data;
using Tipoul.Wallet.Switch.Entity;
using Wallet.Hub.WebApi.Data;
using Wallet.Hub.WebApi.Infrastructure;
using Wallet.Hub.WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<SwitchWalletContext> (options => options.UseSqlServer(builder.Configuration.GetConnectionString("SwitchDefaultConnection")));
builder.Services.AddDbContext<HubWebApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));




builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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
