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

// Add Service Classes
builder.Services.AddScoped<BankAccountTypeService>();
builder.Services.AddScoped<BankAccountService>();
builder.Services.AddScoped<BudgetApplicationContext>();
builder.Services.AddScoped<IncomeService>();
builder.Services.AddScoped<IncomeTypeService>();
builder.Services.AddScoped<PaymentFrequencyTypeService>();

// Add DataAccess Classes
builder.Services.AddScoped<BankAccountDataAccess>();
builder.Services.AddScoped<BankAccountTypeDataAccess>();
builder.Services.AddScoped<IncomesDataAccess>();
builder.Services.AddScoped<IncomeTypesDataAccess>();
builder.Services.AddScoped<PaymentFrequencyTypesDataAccess>();

// Add Interfaces
builder.Services.AddTransient<ITypeDataAccess<BankAccountTypes>, BankAccountTypeDataAccess>();
builder.Services.AddTransient<ITypeDataAccess<IncomeTypes>, IncomeTypesDataAccess>();
builder.Services.AddTransient<ITypeDataAccess<PaymentFrequencyTypes>, PaymentFrequencyTypesDataAccess>();
builder.Services.AddTransient<ITypeService<BankAccountTypes>, BankAccountTypeService>();
builder.Services.AddTransient<ITypeService<IncomeTypes>, IncomeTypeService>();
builder.Services.AddTransient<ITypeService<PaymentFrequencyTypes>, PaymentFrequencyTypeService>();
builder.Services.AddTransient<IBankAccountDataAccess, BankAccountDataAccess>();
builder.Services.AddTransient<IBankAccountService, BankAccountService>();
builder.Services.AddTransient<IDataAccess<Incomes>, IncomesDataAccess>();
builder.Services.AddTransient<IIncomeService, IncomeService>();

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
