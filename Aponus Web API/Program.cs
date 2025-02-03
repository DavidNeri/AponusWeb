using Aponus_Web_API.Acceso_a_Datos;
using Aponus_Web_API.Controllers;
using Aponus_Web_API.Modelos;
using Aponus_Web_API.Negocio;
using Aponus_Web_API.Systema;
using Aponus_Web_API.Utilidades;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<AD_Componentes>();
builder.Services.AddScoped<AD_Compras>();
builder.Services.AddScoped<AD_Entidades>();
builder.Services.AddScoped<AD_Suministros>();
builder.Services.AddScoped<AD_Productos>();
builder.Services.AddScoped<AD_Categorias>();
builder.Services.AddScoped<AD_Movimientos>();
builder.Services.AddScoped<AD_Stocks>();
builder.Services.AddScoped<AD_Usuarios>();
builder.Services.AddScoped<AD_Ventas>();
builder.Services.AddScoped<AD_Auditorias>();

builder.Services.AddScoped<BS_Categorias>();
builder.Services.AddScoped<BS_Compras>();
builder.Services.AddScoped<BS_Componentes>();
builder.Services.AddScoped<BS_Entidades>();
builder.Services.AddScoped<BS_Movimientos>();
builder.Services.AddScoped<BS_Productos>();
builder.Services.AddScoped<BS_Stocks>();
builder.Services.AddScoped<BS_Suministros>();
builder.Services.AddScoped<BS_Ventas>();
builder.Services.AddScoped<BS_Dashboard>();
builder.Services.AddScoped<SS_Aditorias>();


builder.Services.AddScoped<CategoriesController>();
builder.Services.AddScoped<ComponentsController>();
builder.Services.AddScoped<EntitiesController>();
builder.Services.AddScoped<MovmentsController>();
builder.Services.AddScoped<ProductsController>();
builder.Services.AddScoped<PurchaseController>();
builder.Services.AddScoped<SalesController>();
builder.Services.AddScoped<StocksController>();
builder.Services.AddScoped<SuppliesController>();
builder.Services.AddScoped<UsersController>();
builder.Services.AddScoped<DashBoardController>();
builder.Services.AddScoped<AuditController>();



builder.Services.AddScoped<UTL_Suministros>();
builder.Services.AddScoped<UTL_Categorias>();
builder.Services.AddScoped<UTL_JsonWebToken>();


builder.Services.AddScoped<SS_Usuarios>();

builder.Services.AddTransient<UTL_Entorno>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddControllers();
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    options.SerializerSettings.DateFormatString = "dd/MM/yyyy HH:mm:ss";

});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddPolicy("NuevaPolitca", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.Configure<FormOptions>(options =>
{
    options.MemoryBufferThreshold = int.MaxValue;
    options.ValueCountLimit = int.MaxValue;
    options.ValueLengthLimit = int.MaxValue;
    options.MultipartBodyLengthLimit = int.MaxValue;
});

var Key = builder.Environment.IsDevelopment()
                ? Environment.GetEnvironmentVariable("JWT_SECRET_KEY", EnvironmentVariableTarget.User)
                    ?? throw new InvalidOperationException("JWT_SECRET_KEY no conigurada para Desarrollo")
                : Environment.GetEnvironmentVariable("JWT_SECRET_KEY")
                    ?? throw new InvalidOperationException("JWT_SECRET_KEY no conigurada para Produccion");

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(optiones =>
    {
        optiones.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "https://aponusweb.onrender.com/",
            ValidAudience = "https://aponus-front-sa.vercel.app/",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key))
        };
    });

if (builder.Environment.IsProduction())
{
    builder.WebHost.ConfigureKestrel(serverOptions =>
    {
        serverOptions.ListenAnyIP(Int32.Parse(Environment.GetEnvironmentVariable("PORT") ?? "10000"));
    });

}

var ConnectionString = builder.Environment.IsDevelopment() ? Environment.GetEnvironmentVariable("DATABASE_URL", EnvironmentVariableTarget.User) : Environment.GetEnvironmentVariable("DATABASE_URL");

builder.Services.AddDbContext<AponusContext>(options => options.UseNpgsql(ConnectionString).EnableSensitiveDataLogging(false));
var CorsPolicy = "permitirOrigenEspcifico";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CorsPolicy, Policy =>
    {
        Policy.WithOrigins("https://aponus-front-sa.vercel.app/", "https://aponusweb.onrender.com/")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseCors(CorsPolicy);
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
