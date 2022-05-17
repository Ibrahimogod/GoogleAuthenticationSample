using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;

builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/api/account/google-login";
        options.LogoutPath = "/api/account/logout";
    })
    .AddGoogle(options =>
    {
        options.ClientId = Configuration["Authentication:Google:ClientId"];
        options.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
    });

builder.Services.AddControllersWithViews();

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
