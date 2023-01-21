using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using UserDataManager.Server.DbContextConfiguration;
using System.Configuration;
using System.Reflection;
using MediatR;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);
string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<UserDataManagerDbContext>(
                x => x.UseSqlServer(builder.Configuration.GetConnectionString("UserDataManager"),
                x => x.MigrationsHistoryTable("__UserDataManager_MigrationHistory", "UserDataManager")));
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

//CORS 
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
