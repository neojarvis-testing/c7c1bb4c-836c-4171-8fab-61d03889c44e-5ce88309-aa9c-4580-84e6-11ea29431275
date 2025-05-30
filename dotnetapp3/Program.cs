using Microsoft.EntityFrameworkCore;
using dotnetapp3;
using dotnetapp3.Data;
using dotnetapp3.Services;
using dotnetapp3.Repository;
using CommonLibrary.Lib;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setup =>
{
    var scheme = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "Put **_ONLY_** yur JWT Bearer token on textbox below!",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };
    setup.AddSecurityDefinition(scheme.Reference.Id, scheme);
    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { scheme, Array.Empty<string>() }
    });
});

builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddControllers().AddJsonOptions(options => {
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// Init app settings
AppSettings.Init(builder.Configuration);

// JWT
TokenLib.ConfigureJWTServices(builder.Services);

// Auth Policies
builder.Services.AddAuthorization(options => TokenLib.AuthorizationOptions(options));

// DB Context
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(AppSettings.ApplicationDbConnectionString));

// Repositories
builder.Services.AddTransient<IAccountRepository , AccountRepository>();
builder.Services.AddTransient<IFixedDepositRepository , FixedDepositRepository>();
builder.Services.AddTransient<IRecurringDepositRepository , RecurringDepositRepository>();

// Services
builder.Services.AddScoped<IFixedDepositService, FixedDepositService>();
builder.Services.AddScoped<IRecurringDepositService, RecurringDepositService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
