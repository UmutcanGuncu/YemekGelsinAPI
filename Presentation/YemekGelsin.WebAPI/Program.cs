using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using YemekGelsin.Application.Abstractions.Services;
using YemekGelsin.Application.Abstractions.Token;
using YemekGelsin.Application.CQRS.Handlers.Auths;
using YemekGelsin.Application.Profiles;
using YemekGelsin.Domain.Entities;
using YemekGelsin.Infastructure.Services.Token;
using YemekGelsin.Persistence.Contexts;
using YemekGelsin.Persistence.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});
builder.Services.AddOpenApi();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped(typeof(IGenericService<>),typeof(GenericService<>));
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IRestaurantService, RestaurantService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<ITokenHandler, TokenService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
    typeof(Program).Assembly,
    typeof(RegisterCommandRequestHandler).Assembly));
builder.Services.AddDbContext<YemekGelsinDbContext>(cfg =>
{
    cfg.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddCors(options =>
    options.AddPolicy("CORSPolicy", opt =>
        opt.AllowAnyOrigin() // Belirli bir origin
            .AllowAnyHeader()
            .AllowAnyMethod()
    )); 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
builder.Services.AddIdentity<AppUser, AppRole>(opt =>
    {
        opt.User.RequireUniqueEmail = true;
        opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
        opt.Lockout.MaxFailedAccessAttempts = 4; // 4 tane başarısız giriş denemesinden sonra 5 dk giriş yapılamayacak
    })
    .AddEntityFrameworkStores<YemekGelsinDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddAuthentication(opt =>
    {
        opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            //Gelen Tokenda bakılacak parametreleri bildirecez
            ValidateAudience = true, // Oluşturacak token değerini kimlerin kullanacağını belirtiriz localhost:2025
            ValidateIssuer = true, // oluşturulacak token değerini kiin dağıttığını ifade eder
            ValidateLifetime = true, // oluşturulan token değerinin süresini kontrol etmemizi sağlar
            ValidateIssuerSigningKey = true, // üretilecek token değerinin uygulamamıza ait değer olan signinkey'in doğrulanmasıdır
            
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
            LifetimeValidator = ( notBefore,  expires, securityToken,  validationParameters) => expires != null ? expires> DateTime.UtcNow : false,
            RoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
        };
    });
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}
app.UseCors("CORSPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();