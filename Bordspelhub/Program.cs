using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Bordspelhub.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("BordspelhubContextConnection") ?? throw new InvalidOperationException("Connection string 'BordspelhubContextConnection' not found.");

builder.Services.AddDbContext<BordspelhubContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<BordspelhubContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

//Swagger For API
builder.Services.AddSwaggerGen();

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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

//Swagger For API
app.UseSwagger();
app.UseSwaggerUI();
