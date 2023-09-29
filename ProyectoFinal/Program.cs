using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Data;
using ProyectoFinal.Interfaces;
using ProyectoFinal.Models;
using ProyectoFinal.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using ProyectoFinal.helpers;
using ProyectoFinal.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthorizationCore(options =>
{
    options.AddPolicy("AuntenticacionUsuario", policy =>
    {
        policy.RequireAuthenticatedUser();
    });
    options.AddPolicy("Administrador", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireRole("admin");
    });
});
builder.Services.AddControllersWithViews();
//builder.Services.AddAuthentication(
//    CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie(options =>
//    {
//        options.LoginPath = "/account/login";
//        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
//    });
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<DireccionRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<iPhotoService, PhotoService>();
builder.Services.Configure<CloudinaySettings>(builder.Configuration.GetSection("CloudinarySettings"));
builder.Services.AddDbContext<AplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("BasedeDatos")));
builder.Services.AddIdentity<AppUser,IdentityRole>()
    .AddEntityFrameworkStores<AplicationDbContext>()
    .AddDefaultTokenProviders()
    .AddRoles<IdentityRole>();
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddAuthentication(CookieAuthenticationDefaults
    .AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/account/login";
        options.AccessDeniedPath = "/account/AccessDenied";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    });
var app = builder.Build();


if (args.Length == 1 && args[0].ToLower() == "seeddata")
{
    await Seed.SeedUsersAndRolesAsync(app);
    //Seed.SeedData(app);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
