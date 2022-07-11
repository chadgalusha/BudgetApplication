using BudgetApplication.Data;
using BudgetApplication.DataAccess;
using BudgetApplication.Models;
using BudgetApplication.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();

builder.Services.AddScoped<BankAccountTypeService>();
builder.Services.AddScoped<BankAccountService>();
builder.Services.AddScoped<BudgetApplicationContext>();
builder.Services.AddScoped<BankAccountDataAccess>();
builder.Services.AddScoped<BankAccountTypeDataAccess>();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.File("C:\\Users\\ChadGalusha\\source\\repos\\BudgetApplication\\BudgetApplication\\logs\\BudgetApplicationLogs.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

Log.Information("Application Initializing");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(name: "BankAccounts",
    pattern: "{area:exists}/{controller=BankAccounts}/{acton=bankaccounts}");

app.Run();
