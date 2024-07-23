using Microsoft.AspNetCore.Authentication.Cookies;
using Weeklyapp.DataLayer.Entities;
using Weeklyapp.DataLayer.Services.Interfaces;
using Weeklyapp.DataLayer.Services.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<DbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();



// Configura l'autenticazione
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
    });

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
