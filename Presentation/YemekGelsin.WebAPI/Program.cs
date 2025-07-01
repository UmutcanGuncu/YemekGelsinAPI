using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using YemekGelsin.Application.Abstractions.Services;
using YemekGelsin.Domain.Entities;
using YemekGelsin.Persistence.Contexts;
using YemekGelsin.Persistence.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped(typeof(IGenericService<>),typeof(GenericService<>));
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IRestaurantService, RestaurantService>();
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