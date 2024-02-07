using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using lab3.Data;
using lab3.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("lab3ContextConnection") ?? throw new InvalidOperationException("Connection string 'lab3ContextConnection' not found.");

builder.Services.AddDbContext<lab3Context>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<lab3User>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<lab3Context>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
