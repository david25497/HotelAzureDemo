using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using HotelUltraGroup.Infrastructure.Context;
using HotelUltraGroup.Core.Application.Interfaces.Repositories;
using HotelUltraGroup.Infrastructure.Data.Repositories;
using HotelUltraGroup.Core.Application.Interfaces.Services;
using HotelUltraGroup.Core.Application.Services;
using HotelUltraGroup.Core.Application.Common.Interfaces;
using HotelUltraGroup.Core.Application.Common;
using HotelUltraGroup.Infrastructure.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region Services Configuration
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Contexts
#region Contexts
builder.Services.AddDbContext<HotelContext>(opt =>
{
    opt.UseSqlServer("name=DefaultConnection");
});
#endregion

// Authorization Policies
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
        policy.RequireClaim(ClaimTypes.Role, "Admin"));

    options.AddPolicy("UserPolicy", policy =>
        policy.RequireClaim(ClaimTypes.Role, "User"));
});

// Authentication
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["AuthSettings:Audience"],
        ValidIssuer = builder.Configuration["AuthSettings:Issuer"],
        RequireExpirationTime = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["AuthSettings:key"])),
    };
});
#endregion

#region Dependency Injection
/*
_______________________________________________________________________________________________
Tipo de Registro	|Cuándo se crea la instancia	        |Cuándo se usa la misma instancia  |
--------------------|---------------------------------------|----------------------------------|
AddTransient	    |Cada vez que alguien la necesita	    |Nunca, siempre es nueva           |
AddScoped	        |Una vez por cada petición HTTP	        |Mientras dure la misma petición   |
AddSingleton	    |Solo una vez (cuando inicia la app)	|Siempre, todos comparten la misma | 
--------------------|---------------------------------------|----------------------------------|
Peticion es cada llamada a un endpoint. 
 */
builder.Services.AddTransient<ITokenServices, TokenServices>();
builder.Services.AddTransient<IEmailServices, EmailServices>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<IHotelService, HotelService>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddTransient<ErrorBD>();
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("Email"));
#endregion

#region AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
#endregion

var app = builder.Build();

#region CORS Configuration
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin  
    .AllowCredentials());
#endregion

// Configure the HTTP request pipeline.
#region HTTP Pipeline Configuration
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
if (app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
#endregion

app.Run();
