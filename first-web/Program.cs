using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using first_web.Pages;
using System.Net.Http;
using first_web.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Register HttpClient with a base address
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://todo-api.bestcar.id/") // Set your API base address
});

// Register your services
builder.Services.AddScoped<TodoService>();
builder.Services.AddScoped<TodoDetailService>();
builder.Services.AddScoped<AuthService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();