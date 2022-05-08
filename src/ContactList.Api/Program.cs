using ContactList.Api.Configurations;
using ContactList.Infrastructure.Settings;
using ContactListWebApi.Configurations;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

var connectionStrings = new ConnStringSettings();
configuration.Bind(key: nameof(connectionStrings), connectionStrings);

var jwtSettings = new JwtSettings();
configuration.Bind(key: nameof(jwtSettings), jwtSettings);

builder.Services.AddRouting();
builder.Services.AddOdataSetup();
builder.Services.AddAppSettingsSetup(configuration);
builder.Services.AddDependencyInjectionSetup();
builder.Services.AddAutoMapper(typeof(ContactList.Infrastructure.Settings.AutoMapper));
builder.Services.AddMiddlewareSetup();
builder.Services.AddFluentValidationSetup();
builder.Services.AddControllers();
builder.Services.AddAuthenticationSetup(jwtSettings.Secret, jwtSettings);
builder.Services.AddSwaggerServiceSetup();
builder.Services.AddHttpClient();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.AddCorsSetup();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.AddSwaggerAppSetup();

app.Run();
