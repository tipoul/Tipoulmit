using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Tipoul.Console.WebApi.Data;
using Tipoul.Console.WebApi.Infrastructure;
using Tipoul.Console.WebApi.Services;
using Tipoul.Framework.DataAccessLayer;
using Tipoul.Shaparak.Services.BehPardakhtGateWay;
using Tipoul.Shaparak.Services.Data;
using Tipoul.Wallet.Switch.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ShaparakContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ShaparakConnection")));
builder.Services.AddDbContext<TipoulFrameworkDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("FrameworkConnection")));

builder.Services.AddDbContext<ConsoleContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); 
    app.UseStaticFiles();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyRvLinkBridge v1"));
}
else if (app.Environment.IsProduction())
{
    app.UseDeveloperExceptionPage();
    app.UseStaticFiles(); 
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyRvLinkBridge v1"));
}



   



app.UseHttpsRedirection();
app.UseCors(builder => builder
	 .AllowAnyOrigin()
	 .AllowAnyMethod()

	 .AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
