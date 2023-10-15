using AuthSimulator.Client.Code;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string url = builder.Configuration.GetSection("AuthServer").Value;

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
.AddCookie(options =>
{
    options.LoginPath = "/home/index"; // Must be lowercase
})
.AddOAuth("custom", options =>
{
    options.ClientId = "fakeid";
    options.ClientSecret = "fakesecret";
    options.CallbackPath = "/custom";
    options.AuthorizationEndpoint = $"{url}/auth";
    options.TokenEndpoint = $"{url}/token";
    options.UserInformationEndpoint = $"{url}/userinfo";
    options.SaveTokens = true;
    
    options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
    options.ClaimActions.MapJsonKey(ClaimTypes.Name, "name");
    options.ClaimActions.MapJsonKey(ClaimTypes.GivenName, "given_name");
    options.ClaimActions.MapJsonKey(ClaimTypes.Surname, "family_name");
    options.ClaimActions.MapJsonKey(ClaimTypes.Email, "email");

    options.Scope.Add("openid");
    options.Scope.Add("profile");
    options.Scope.Add("email");

    options.Events = new OAuthEvents
    {
        OnCreatingTicket = async context =>
        {
            var request = new HttpRequestMessage(HttpMethod.Get, context.Options.UserInformationEndpoint);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", context.AccessToken);
            var response = await context.Backchannel.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, context.HttpContext.RequestAborted);
            response.EnsureSuccessStatusCode();
            var json = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
            context.RunClaimActions(json.RootElement);
        }
    };
})
.AddGoogle(options =>
{
    options.ClientId = "fakeid";
    options.ClientSecret = "fakesecret";
    options.AuthorizationEndpoint = $"{url}/auth";
    options.TokenEndpoint = $"{url}/token";
    options.UserInformationEndpoint = $"{url}/userinfo";

})
.AddFacebook(options =>
{
    options.ClientId = "fakeid";
    options.ClientSecret = "fakesecret";
    options.AuthorizationEndpoint = $"{url}/auth";
    options.TokenEndpoint = $"{url}/token";
    options.UserInformationEndpoint = $"{url}/userinfo";

})
.AddMicrosoftAccount(options =>
{
    options.ClientId = "fakeid";
    options.ClientSecret = "fakesecret";
    options.AuthorizationEndpoint = $"{url}/auth";
    options.TokenEndpoint = $"{url}/token";
    options.UserInformationEndpoint = $"{url}/userinfo";

});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
