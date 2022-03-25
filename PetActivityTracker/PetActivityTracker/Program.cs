using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PetActivityTracker.Data;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PetActivityTrackerContext>(options =>
    options.UseSqlServer("workstation id=PetActivityTracker.mssql.somee.com;packet size=4096;user id=wtotokshau_SQLLogin_1;pwd=xfr2k1v5yz;data source=PetActivityTracker.mssql.somee.com;persist security info=False;initial catalog=PetActivityTracker"));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache();
/*
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
*/
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

/*
app.UseSession();
*/

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
