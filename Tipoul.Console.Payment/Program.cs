using Microsoft.EntityFrameworkCore;
using Tipoul.Console.WebApi.Data;
using Tipoul.Framework.DataAccessLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ConsoleContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConsoleConnection")));
builder.Services.AddDbContext<TipoulFrameworkDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("FrameworkConnection")));
builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
