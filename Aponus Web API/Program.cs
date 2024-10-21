using Aponus_Web_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.Features;
using Aponus_Web_API.Acceso_a_Datos.Productos;
using Aponus_Web_API.Business;
using Aponus_Web_API.Controllers;
using Aponus_Web_API.Acceso_a_Datos.Sistema;
using Aponus_Web_API.Acceso_a_Datos.Componentes;
using Aponus_Web_API.Acceso_a_Datos.Entidades;
using Aponus_Web_API.Acceso_a_Datos.Insumos;
using Aponus_Web_API.Acceso_a_Datos.Stocks;
using Aponus_Web_API.Acceso_a_Datos.Ventas;
using Aponus_Web_API.Support.Movimientos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ComponentesProductos>();
builder.Services.AddScoped<ObtenerComponentes>();
builder.Services.AddScoped<OperacionesComponentes>();
builder.Services.AddScoped<ABM_Entidades>();
builder.Services.AddScoped<ObtenerInsumos>();
builder.Services.AddScoped<AD_Productos>();
builder.Services.AddScoped<ObtenerProductos>();
builder.Services.AddScoped<Categorias>();
builder.Services.AddScoped<MovimientosStock>();
builder.Services.AddScoped<Stocks>();
builder.Services.AddScoped<Aponus_Web_API.Acceso_a_Datos.Usuarios.Usuarios>();
builder.Services.AddScoped<ABM_Ventas>();
builder.Services.AddScoped<Suministros>();

builder.Services.AddScoped<BS_Movimientos>();
builder.Services.AddScoped<BS_Stocks>();
builder.Services.AddScoped<BS_Entidades>();
builder.Services.AddScoped<BS_Categorias>();

builder.Services.AddScoped<CategoriesController>();

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


if (builder.Environment.IsProduction())
{
    builder.WebHost.ConfigureKestrel(serverOptions =>
    {
        serverOptions.ListenAnyIP(Int32.Parse(Environment.GetEnvironmentVariable("PORT") ?? "10000"));
    });

}


var ConnectionString = builder.Environment.IsDevelopment() ? Environment.GetEnvironmentVariable("DATABASE_URL", EnvironmentVariableTarget.User) : Environment.GetEnvironmentVariable("DATABASE_URL");

builder.Services.AddDbContext<AponusContext>(options => options.UseNpgsql(ConnectionString).EnableSensitiveDataLogging(false));
Console.WriteLine($"Cadena de conexión obtenida: {ConnectionString}");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("NuevaPolitca");
app.UseAuthorization();
app.MapControllers();
app.Run();
