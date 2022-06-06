using Identity.Api.Infrastructure.DependencyInjection;
using Identity.Api.Infrastructure.Options;
using Identity.BL.Interfaces;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder();

builder.Services.Configure<AuthenticationOption>(
    builder.Configuration.GetSection(AuthenticationOption.Authentication)
);

builder.Services.AddControllers();
builder.Services.AddAuthorization();
builder.Services.AddJwtAuthentification(builder.Configuration);
builder.Services.AddScoped<IAuthenticationOption>(provider =>
{
    var options = provider.GetService<IOptions<AuthenticationOption>>();
    return options.Value;
});

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
