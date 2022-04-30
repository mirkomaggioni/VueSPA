using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using VueCliMiddleware;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

//builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<ApplicationDbContext>();

//builder.Services.AddIdentityServer()
//    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

//builder.Services.AddAuthentication()
//    .AddIdentityServerJwt();

builder.Services.AddCors();
builder.Services.AddControllers();


var appSettingsSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingsSection);

// configure jwt authentication
var appSettings = appSettingsSection.Get<AppSettings>();
var key = Encoding.ASCII.GetBytes(appSettings.Secret);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.Events = new JwtBearerEvents
    {
        OnTokenValidated = context =>
        {
            var userService = context.HttpContext.RequestServices.GetRequiredService<UserService>();
            var userId = int.Parse(context.Principal.Identity.Name);
            var user = userService.GetById(userId);
            if (user == null)
            {
                // return unauthorized if user no longer exists
                context.Fail("Unauthorized");
            }
            return Task.CompletedTask;
        }
    };
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddScoped<UserService>();

var app = builder.Build();

using (var db = new ApplicationDbContext(builder.Configuration))
{
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.

app.UseStaticFiles();
if (!app.Environment.IsDevelopment())
{
    app.UseSpaStaticFiles();
}

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.UseWhen(context => !context.Request.Path.ToString().StartsWith("/api"), appB =>
{
    appB.UseSpa(spa =>
    {
        // To learn more about options for serving an Angular SPA from ASP.NET Core,
        // see https://go.microsoft.com/fwlink/?linkid=864501

        spa.Options.SourcePath = "ClientApp";

        if (app.Environment.IsDevelopment())
        {
            spa.UseVueCli(npmScript: "serve", port: 8092, forceKill: true, https: false);
        }
    });

});

app.Run();
