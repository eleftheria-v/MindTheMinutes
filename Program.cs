using Meeting_Minutes.Data;
using Meeting_Minutes.Models;
using Meeting_Minutes.Services;
using Meeting_Minutes.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. (old ConfigureServices method)
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDbConnection")));
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IMeetingService, MeetingService>();
builder.Services.AddScoped<IMailService, MailService>();

builder.Services.Configure<IdentityOptions>(opt =>
{
    // Setting-up the password policy
    opt.Password.RequireDigit = false;
    opt.Password.RequiredLength = 6;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireUppercase = false;
    opt.SignIn.RequireConfirmedEmail = false;
});





//old Configure Method

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
app.MapRazorPages();




// Database seeding
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    // requires using Microsoft.Extensions.Configuration;
    var config = app.Services.GetRequiredService<IConfiguration>();
    // Set password with the Secret Manager tool.
    // dotnet user-secrets set SeedUserPW <pw>

    var context = services.GetRequiredService<Meeting_Minutes.Data.ApplicationDbContext>();
    context.Database.Migrate();
    SeedData.Initialize(services).Wait();

}


app.Run();
