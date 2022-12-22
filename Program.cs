using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AspDotnetDemo.Data;
using AspDotnetDemo.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<AspDotnetDemoContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("AspDotnetDemoContext") ?? throw new InvalidOperationException("Connection string 'AspDotnetDemoContext' not found.")));

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<AspDotnetDemoContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("AspDotnetDemoContext")));
}
else
{
    builder.Services.AddDbContext<AspDotnetDemoContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("AspDotnetDemoContext")));
}

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
// app.UseAuthorization();
app.MapRazorPages();

app.Run();
