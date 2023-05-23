
using Microsoft.EntityFrameworkCore;
using eventmanager.Data;
using eventmanager.Models;

var builder = WebApplication.CreateBuilder(args);

/*IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json").
    AddEnvironmentVariables()
    .Build();
*/

/*
 prima di run
dotnet add package Microsoft.Entityframework.Tools
Add-Migration InitialCreate
Update-Database

model first
database first---> opposto
 
 */
//builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("DataSource = DataBase_eventmanager.db"));


// Add services to the container.
builder.Services.AddRazorPages();

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
