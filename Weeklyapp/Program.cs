using Microsoft.AspNetCore.Authentication.Cookies;
using Weeklyapp.DataLayer.Services.Interfaces;
using Weeklyapp.DataLayer.Services.Data;

var builder = WebApplication.CreateBuilder(args);

// Configura i servizi dell'applicazione
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IPrenotazioneService, PrenotazioneService>();
builder.Services.AddScoped<ICameraService, CameraService>();
builder.Services.AddScoped<IServizioAggiuntivoService, ServizioAggiuntivoService>();
builder.Services.AddScoped<IAuthService, AuthService>();

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
