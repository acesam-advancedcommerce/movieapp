using MovieApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using MovieApp.Domain.Interfaces;
using MovieApp.Infrastructure.Repositories;
using MovieApp.Application.Interfaces;
using MovieApp.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddScoped<IMovieRepository, MovieRepository>();

builder.Services.AddScoped<IMovieService, MovieService>();

builder.Services.AddHttpClient<IMovieService, MovieService>();

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
