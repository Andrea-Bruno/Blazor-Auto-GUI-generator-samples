using CloudSubscription.Components;
using static CloudSubscription.Settings;
var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// load settings from appsettings.json
ApiEndpoint = configuration.GetValue(typeof(string), nameof(ApiEndpoint) , null) as string;

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

// Used to get httpContext in razor pages
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
