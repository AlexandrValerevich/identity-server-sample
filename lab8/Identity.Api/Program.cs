using MediatR;
using Identity.Api.Infrastructure.DependencyInjection;
using Identity.BL.Interfaces;
using Identity.BL.Services;
using Identity.DAL.Respository;

var builder = WebApplication.CreateBuilder();

builder.Services.AddDefaultCors();
builder.Services.AddControllers();
builder.Services.AddAuthorization();
builder.Services.AddJwtAuthentification(builder.Configuration);
builder.Services.AddAuthentificationOptions(builder.Configuration);

builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IPasswordService, PasswordService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddUserDbContext();
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
