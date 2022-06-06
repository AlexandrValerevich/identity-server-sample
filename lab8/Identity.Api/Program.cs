using MediatR;
using Identity.Api.Infrastructure.DependencyInjection;
using Identity.Api.Infrastructure.Options;
using Identity.BL.Interfaces;
using Identity.BL.Services;
using Identity.DAL.Respository;
using Microsoft.Extensions.Options;
using Identity.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();

builder.Services.Configure<AuthenticationOption>(
    builder.Configuration.GetSection(AuthenticationOption.Authentication)
);
builder.Services.AddScoped<IAuthenticationOption>(provider =>
{
    var options = provider.GetService<IOptions<AuthenticationOption>>();
    return options.Value;
});

builder.Services.AddControllers();
builder.Services.AddAuthorization();
builder.Services.AddJwtAuthentification(builder.Configuration);

builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IPasswordService, PasswordService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddDbContext<DbUserContext>(options => 
{
    options.UseSqlite("Data Source=user.db");
});
builder.Services.AddMediatR(typeof(Program));
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
