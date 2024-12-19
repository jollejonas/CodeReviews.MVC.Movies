using Microsoft.EntityFrameworkCore;
using Movies.jollejonas.Data;
using MvcMovie.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MoviesjollejonasContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MoviesjollejonasContext") ?? throw new InvalidOperationException("Connection string 'MoviesjollejonasContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();