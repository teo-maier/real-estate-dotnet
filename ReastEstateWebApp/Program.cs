using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReastEstateWebApp.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ReastEstateWebAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ReastEstateWebAppContext") ??
                         throw new InvalidOperationException(
                             "Connection string 'ReastEstateWebAppContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<LibraryIdentityContext>();

builder.Services.AddDbContext<LibraryIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ReastEstateWebAppContext") ??
                         throw new InvalidOperationException(
                             "Connectionstring 'ReastEstateWebAppContext' not found.")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
;

app.UseAuthorization();

app.MapRazorPages();

app.Run();