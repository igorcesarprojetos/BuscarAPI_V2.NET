using BuscarAPI_V2.Domain.Interfaces;
using BuscarAPI_V2.Main.Components;
using BuscarAPI_V2.Services;
using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BuscarAPI_V2.Main.Data;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContextFactory<BuscarAPI_V2MainContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("BuscarAPI_V2MainContext") ?? throw new InvalidOperationException("Connection string 'BuscarAPI_V2MainContext' not found.")));

//builder.Services.AddQuickGridEntityFrameworkAdapter();

//builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient<IPerfilService, PerfilService>("SuporteTI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7059");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
    client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c3VhcmlvIjoiYWRtaW4iLCJlbXByZXNhIjoiU3Vwb3J0ZVRJIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiYWRtaW5pc3RyYWRvciIsImV4cCI6MTc3MTgwNjc0NiwiaXNzIjoiU1VQT1JURVRJIiwiYXVkIjoiQ2xpZW50ZVNVUE9SVEVUSSJ9._7qiaxrb3QEq0COM0Ay1LQdCND6QCR8_W8nWGCbI4z8");
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseMigrationsEndPoint();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
