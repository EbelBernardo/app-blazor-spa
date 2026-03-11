using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Projeto_SPA_Blazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var apiUrl = builder.Configuration["ApiSettings:BaseUrl"];

builder.Services.AddHttpClient<CategoryService>(client =>
{
    client.BaseAddress = new Uri(apiUrl!);
});

builder.Services.AddHttpClient<ProductService>(client =>
{
    client.BaseAddress = new Uri(apiUrl!);
});

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
