using Microsoft.AspNetCore.Authentication.Cookies;
using Weeklyapp.Services;
using Weeklyapp.DAO;
using Weeklyapp.DataLayer.Entities;
using Weeklyapp.DataLayer.Services.Data;
using Weeklyapp.DataLayer.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Configura i servizi dell'applicazione
builder.Services.AddScoped<ClienteDao>();
builder.Services.AddScoped<CameraDao>();
builder.Services.AddScoped<PrenotazioneDao>();
builder.Services.AddScoped<ServizioAggiuntivoDao>();

builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<CameraService>();
builder.Services.AddScoped<PrenotazioneService>();
builder.Services.AddScoped<ServizioAggiuntivoService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<CheckoutService>();

// Aggiungi servizi al container
builder.Services.AddControllersWithViews();

// Configura l'autenticazione
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";
    });

var app = builder.Build();

// Configura il pipeline delle richieste HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
