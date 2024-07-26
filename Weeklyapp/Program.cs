using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Weeklyapp.DAO;
using Weeklyapp.DataLayer.Services.Data;
using Weeklyapp.DataLayer.Services.Interfaces;
using Weeklyapp.Services;

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

// Configura l'autenticazione JWT
var key = Encoding.ASCII.GetBytes("lKpE9r7x@!Z&hC2vB7x#T4kW8uQ$eR3tY5iU2oP1sL&dM9n");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "il_tuo_issuer",
        ValidAudience = "la_tua_audience",
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
})
.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
{
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
});

// Aggiungi i servizi di autorizzazione
builder.Services.AddAuthorization();

// Aggiungi i servizi dei controller e MVC
builder.Services.AddControllersWithViews();

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
