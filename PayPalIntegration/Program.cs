using PayPalIntegration;
using PayPalIntegration.Components;
using static PayPalIntegration.Settings;
var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// load settings from appsettings.json
PayPalBusinessEmail = configuration.GetValue(typeof(string), nameof(PayPalBusinessEmail), null) as string;

if (PayPalBusinessEmail == "YOUR_ACCOUNT@business.example.com")
{
    // follow: https://developer.paypal.com/tools/sandbox/accounts/
    throw new Exception("Please set your PayPal business email in appsettings.json");
}

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

// Used to get httpContext in razor pages
builder.Services.AddHttpContextAccessor();
var app = builder.Build();

// Here we configure the event that should be executed when a payment with has been completed (Events.OnPaymentCompleted)
app.UseMiddleware<PayPal.PayPalIpnMiddleware>((object)Events.OnPaymentCompleted);

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
