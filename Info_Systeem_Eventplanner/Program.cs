using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Info_Systeem_Eventplanner.Models;
using Info_Systeem_Eventplanner.Data;

var builder = WebApplication.CreateBuilder(args);

// Voeg de DbContext toe aan de DI-container
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddAuthentication()
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // Inlogpagina
        options.LogoutPath = "/Account/Logout"; // Uitlogpagina
    });


// Voeg controllers en Razor Pages toe
builder.Services.AddControllersWithViews(); // Of builder.Services.AddRazorPages(); als je Razor Pages gebruikt

// Eventuele andere services die je nodig hebt
// builder.Services.AddScoped<IMyService, MyService>(); // Voeg dit toe als je extra services hebt

var app = builder.Build();

// Configureer de HTTP-pijplijn
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();  // Gebruik voor development
}
else
{
    app.UseExceptionHandler("/Home/Error");  // Gebruik voor productie
    app.UseHsts();
}

// Gebruik statische bestanden (indien nodig)
app.UseStaticFiles();

// Routing configureren
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Start de applicatie
app.Run();
