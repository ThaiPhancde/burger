using burger.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Security;

    var builder = WebApplication.CreateBuilder(args);
    var connection = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<DataContext>(option => option.UseSqlServer(connection));
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

app.MapControllerRoute(
name: "areas",
pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
name: "Default",
pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "Foodmenu",
    pattern: "{controller=FoodMenu}/{action=Burger}/{id?}");
app.MapControllerRoute(
    name: "Deals",
    pattern: "{controller=Deals}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "Cart",
    pattern: "{controller=Cart}/{action=CartView}/{id?}");
app.MapControllerRoute(
    name: "Address",
    pattern: "{controller=StoreAddress}/{action=Index}/{id?}");
app.Run();
