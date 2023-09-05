using App.Gateway;
using Microsoft.Identity.Web;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

builder.Services.AddMicrosoftIdentityWebApiAuthentication(builder.Configuration);

builder.Services.AddOcelot(builder.Configuration);

builder.Services.DecorateClaimAuthoriser();

var app = builder.Build();

app.UseAuthentication();

app.UseOcelot().Wait();

app.Run();
