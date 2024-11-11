
// D:\Aponus SA\Aponus Web API\bin\Debug\net7.0\Aponus Web API.dll
// Aponus Web API, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// Global type: <Module>
// Entry point: Program.<Main>$
// Architecture: AnyCPU (64-bit preferred)
// Runtime: v4.0.30319
// This assembly was compiled using the /deterministic option.
// Hash algorithm: SHA1
// Debug info: Loaded from portable PDB: D:\Aponus SA\Aponus Web API\bin\Debug\net7.0\Aponus Web API.pdb

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Annytab.Stemmer;
using Aponus_Web_API.Acceso_a_Datos;
using Aponus_Web_API.Controllers;
using Aponus_Web_API.Modelos;
using Aponus_Web_API.Negocio;
using Aponus_Web_API.Objetos_de_Transferencia_de_Datos;
using Aponus_Web_API.Systema;
using Aponus_Web_API.Utilidades;
using Aponus_Web_API.Utilidades.Nombres_Geograficos;
using Aponus_Web_API.Utilidades.Servicios_BIN;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Fractions;
using MessagePack;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Npgsql;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using NpgsqlTypes;
using NtpClient;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default | DebuggableAttribute.DebuggingModes.DisableOptimizations | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints | DebuggableAttribute.DebuggingModes.EnableEditAndContinue)]
[assembly: TargetFramework(".NETCoreApp,Version=v7.0", FrameworkDisplayName = ".NET 7.0")]
[assembly: AssemblyCompany("Aponus Web API")]
[assembly: AssemblyConfiguration("Debug")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0+40458ff78fc1bed632cb3cdfa4aa4ccd73d341fe")]
[assembly: AssemblyProduct("Aponus Web API")]
[assembly: AssemblyTitle("Aponus Web API")]
[assembly: ApplicationPart("Swashbuckle.AspNetCore.SwaggerGen")]
[assembly: AssemblyVersion("1.0.0.0")]
[module: System.Runtime.CompilerServices.RefSafetyRules(11)]
namespace Microsoft.CodeAnalysis
{
	[CompilerGenerated]
	[Microsoft.CodeAnalysis.Embedded]
	internal sealed class EmbeddedAttribute : Attribute
	{
	}
}
namespace System.Runtime.CompilerServices
{
	[CompilerGenerated]
	[Microsoft.CodeAnalysis.Embedded]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter, AllowMultiple = false, Inherited = false)]
	internal sealed class NullableAttribute : Attribute
	{
		public readonly byte[] NullableFlags;

		public NullableAttribute(byte P_0)
		{
			NullableFlags = new byte[1] { P_0 };
		}

		public NullableAttribute(byte[] P_0)
		{
			NullableFlags = P_0;
		}
	}
	[CompilerGenerated]
	[Microsoft.CodeAnalysis.Embedded]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method | AttributeTargets.Interface | AttributeTargets.Delegate, AllowMultiple = false, Inherited = false)]
	internal sealed class NullableContextAttribute : Attribute
	{
		public readonly byte Flag;

		public NullableContextAttribute(byte P_0)
		{
			Flag = P_0;
		}
	}
	[CompilerGenerated]
	[Microsoft.CodeAnalysis.Embedded]
	[AttributeUsage(AttributeTargets.Module, AllowMultiple = false, Inherited = false)]
	internal sealed class RefSafetyRulesAttribute : Attribute
	{
		public readonly int Version;

		public RefSafetyRulesAttribute(int P_0)
		{
			Version = P_0;
		}
	}
}
[CompilerGenerated]
internal class Program
{
	private static void _003CMain_003E_0024(string[] args)
	{
		WebApplicationBuilder webApplicationBuilder = WebApplication.CreateBuilder(args);
		webApplicationBuilder.Services.AddScoped<AD_Componentes>();
		webApplicationBuilder.Services.AddScoped<AD_Compras>();
		webApplicationBuilder.Services.AddScoped<AD_Entidades>();
		webApplicationBuilder.Services.AddScoped<AD_Suministros>();
		webApplicationBuilder.Services.AddScoped<AD_Productos>();
		webApplicationBuilder.Services.AddScoped<AD_Categorias>();
		webApplicationBuilder.Services.AddScoped<AD_Movimientos>();
		webApplicationBuilder.Services.AddScoped<AD_Stocks>();
		webApplicationBuilder.Services.AddScoped<AD_Usuarios>();
		webApplicationBuilder.Services.AddScoped<AD_Ventas>();
		webApplicationBuilder.Services.AddScoped<BS_Categorias>();
		webApplicationBuilder.Services.AddScoped<BS_Compras>();
		webApplicationBuilder.Services.AddScoped<BS_Componentes>();
		webApplicationBuilder.Services.AddScoped<BS_Entidades>();
		webApplicationBuilder.Services.AddScoped<BS_Movimientos>();
		webApplicationBuilder.Services.AddScoped<BS_Productos>();
		webApplicationBuilder.Services.AddScoped<BS_Stocks>();
		webApplicationBuilder.Services.AddScoped<BS_Suministros>();
		webApplicationBuilder.Services.AddScoped<BS_Ventas>();
		webApplicationBuilder.Services.AddScoped<CategoriesController>();
		webApplicationBuilder.Services.AddScoped<ComponentsController>();
		webApplicationBuilder.Services.AddScoped<EntitiesController>();
		webApplicationBuilder.Services.AddScoped<MovmentsController>();
		webApplicationBuilder.Services.AddScoped<ProductsController>();
		webApplicationBuilder.Services.AddScoped<PurchaseController>();
		webApplicationBuilder.Services.AddScoped<SalesController>();
		webApplicationBuilder.Services.AddScoped<StocksController>();
		webApplicationBuilder.Services.AddScoped<SuppliesController>();
		webApplicationBuilder.Services.AddScoped<UsersController>();
		webApplicationBuilder.Services.AddScoped<UTL_Suministros>();
		webApplicationBuilder.Services.AddScoped<UTL_Categorias>();
		webApplicationBuilder.Services.AddScoped<SS_Usuarios>();
		webApplicationBuilder.Services.AddControllers();
		webApplicationBuilder.Services.AddControllersWithViews().AddNewtonsoftJson(delegate(MvcNewtonsoftJsonOptions options)
		{
			options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
			options.SerializerSettings.DateFormatString = "dd/MM/yyyy HH:mm:ss";
		});
		webApplicationBuilder.Services.AddEndpointsApiExplorer();
		webApplicationBuilder.Services.AddSwaggerGen();
		webApplicationBuilder.Services.AddCors(delegate(CorsOptions options)
		{
			options.AddPolicy("NuevaPolitca", delegate(CorsPolicyBuilder app)
			{
				app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
			});
		});
		webApplicationBuilder.Services.Configure(delegate(FormOptions options)
		{
			options.MemoryBufferThreshold = int.MaxValue;
			options.ValueCountLimit = int.MaxValue;
			options.ValueLengthLimit = int.MaxValue;
			options.MultipartBodyLengthLimit = 2147483647L;
		});
		if (webApplicationBuilder.Environment.IsProduction())
		{
			webApplicationBuilder.WebHost.ConfigureKestrel(delegate(KestrelServerOptions serverOptions)
			{
				serverOptions.ListenAnyIP(int.Parse(Environment.GetEnvironmentVariable("PORT") ?? "10000"));
			});
		}
		string ConnectionString = (webApplicationBuilder.Environment.IsDevelopment() ? Environment.GetEnvironmentVariable("DATABASE_URL", EnvironmentVariableTarget.User) : Environment.GetEnvironmentVariable("DATABASE_URL"));
		webApplicationBuilder.Services.AddDbContext<AponusContext>(delegate(DbContextOptionsBuilder options)
		{
			options.UseNpgsql(ConnectionString).EnableSensitiveDataLogging(sensitiveDataLoggingEnabled: false);
		});
		Console.WriteLine("Cadena de conexión obtenida: " + ConnectionString);
		WebApplication webApplication = webApplicationBuilder.Build();
		if (webApplication.Environment.IsDevelopment())
		{
			webApplication.UseSwagger();
			webApplication.UseSwaggerUI();
		}
		webApplication.UseCors("NuevaPolitca");
		webApplication.UseAuthorization();
		webApplication.MapControllers();
		webApplication.Run();
	}
}
namespace Aponus_Web_API.Utilidades
{
	public class NombresGeograficos
	{
		private static readonly HttpClient _httpClient = new HttpClient();

		private static readonly string usuario = "davidcneri";

		internal async Task<IActionResult> ListarPaises()
		{
			try
			{
				string URL = "http://api.geonames.org/countryInfoJSON?username=" + usuario;
				HttpResponseMessage RespuestaHttp = await _httpClient.GetAsync(URL);
				RespuestaHttp.EnsureSuccessStatusCode();
				CountryResponse Respuesta = JsonConvert.DeserializeObject<CountryResponse>(await RespuestaHttp.Content.ReadAsStringAsync());
				return new JsonResult(Respuesta);
			}
			catch (Exception ex)
			{
				Exception EX = ex;
				return new ContentResult
				{
					Content = (EX.InnerException?.Message ?? EX.Message),
					ContentType = "application/json",
					StatusCode = 400
				};
			}
		}

		internal async Task<IActionResult> ListarProvincias(int CountryId)
		{
			string URL = $"http://api.geonames.org/childrenJSON?geonameId={CountryId}&username={usuario}";
			HttpResponseMessage RespuestaHttp = await _httpClient.GetAsync(URL);
			RespuestaHttp.EnsureSuccessStatusCode();
			List<Estados_Provincias> Estados_Provincias = JsonConvert.DeserializeObject<StatesResponse>(await RespuestaHttp.Content.ReadAsStringAsync())?.Geonames;
			Estados_Provincias?.ForEach(delegate(Estados_Provincias x)
			{
				x.ToponymName = x.ToponymName.Replace(" Province", "").Replace(" State", "").Replace(" Region", "")
					.Replace(" Departament", "")
					.Replace(" Prefecture", "")
					.Replace(" Territory", "")
					.Trim();
			});
			return new JsonResult(Estados_Provincias);
		}

		internal async Task<IActionResult> ListarCiudades(string CountryId, string Estado_Provincia_Id)
		{
			string URL = $"http://api.geonames.org/searchJSON?&adminCode1={Estado_Provincia_Id}&country={CountryId}&username={usuario}";
			HttpResponseMessage RespuestaHttp = await _httpClient.GetAsync(URL);
			RespuestaHttp.EnsureSuccessStatusCode();
			CitiesResponse Respuesta = JsonConvert.DeserializeObject<CitiesResponse>(await RespuestaHttp.Content.ReadAsStringAsync());
			return new JsonResult(Respuesta);
		}
	}
	public class UTL_Categorias
	{
		public string? GenerarIdTipoProducto(string tipo)
		{
			try
			{
				string text = Regex.Replace(tipo.Trim(), "\\s+", " ").ToUpper();
				SpanishStemmer stemmer = new SpanishStemmer();
				string[] source = text.Split(' ');
				return string.Join("_", source.Select((string Palabra) => stemmer.GetSteamWord(Palabra).ToUpper()));
			}
			catch (Exception)
			{
				return null;
			}
		}
	}
	public class UTL_Cloudinary
	{
		private readonly Cloudinary _cloudinary;

		private readonly HttpClient _httpClient;

		public UTL_Cloudinary()
		{
			Account account = new Account("dxbgg3dtr", "748723842847532", "xT7aSgIFPip_8cu3mdb2jhj4LZk");
			_cloudinary = new Cloudinary(account);
			_httpClient = new HttpClient();
		}

		public List<ArchivosMovimientosStock> SubirArchivosMovimiento(List<IFormFile> Archivos, string Proveedor)
		{
			List<ArchivosMovimientosStock> list = new List<ArchivosMovimientosStock>();
			DateTime dateTime = UTL_Fechas.ObtenerFechaHora();
			string value = dateTime.ToString("yyyyMMdd");
			string value2 = dateTime.ToString("HHmmss");
			foreach (IFormFile Archivo in Archivos)
			{
				using Stream stream = Archivo.OpenReadStream();
				RawUploadParams parameters = new RawUploadParams
				{
					File = new FileDescription(Archivo.FileName, stream),
					PublicId = $"Aponus/Movimientos_Documentos/{Proveedor}/{Archivo.FileName}_{value}_{value2}"
				};
				RawUploadResult rawUploadResult = _cloudinary.Upload(parameters);
				list.Add(new ArchivosMovimientosStock
				{
					HashArchivo = Archivo.FileName,
					PathArchivo = rawUploadResult.SecureUrl.ToString()
				});
			}
			return list;
		}

		public async Task<(byte[]? Archivo, string? error)> DescargarArchivo(string publicId)
		{
			try
			{
				string url = _cloudinary.Api.UrlImgUp.BuildUrl(publicId);
				return (Archivo: await _httpClient.GetByteArrayAsync(url), error: null);
			}
			catch (Exception ex2)
			{
				Exception ex = ex2;
				Console.WriteLine("Error al descargar archivo de Cloudinary: " + (ex.InnerException?.Message ?? ex.Message));
				return (Archivo: null, error: "Error al objener datos del archivo: " + (ex.InnerException?.Message ?? ex.Message));
			}
		}
	}
	public class UTL_Fechas
	{
		public static DateTime ObtenerFechaHora()
		{
			DateTime result = DateTime.Now;
			string[] array = new string[4] { "Time.Windows.com", "pool.ntp.org", "south-america.pool.ntp.org", "Time.Windows.com" };
			bool flag = false;
			string[] array2 = array;
			foreach (string text in array2)
			{
				try
				{
					INtpConnection ntpConnection = new NtpConnection(text);
					result = ntpConnection.GetUtc().AddHours(-3.0);
					flag = true;
				}
				catch (Exception ex)
				{
					Console.WriteLine("Error al conectarse al servidor NTP " + text + ": " + ex.Message);
					continue;
				}
				break;
			}
			if (!flag)
			{
				result = DateTime.Now;
			}
			return result;
		}
	}
	public class UTL_FiltrosComprasVentas
	{
		public DateTime? Desde { get; set; }

		public DateTime? Hasta { get; set; }

		public int? IdEntidad { get; set; }

		public int? IdCompraVenta { get; set; }
	}
	public class UTL_FiltrosMovimientos
	{
		[JsonPropertyName("idProveedor")]
		public int? IdProveedor { get; set; }

		[JsonPropertyName("etapa")]
		public string? Etapa { get; set; }

		[JsonPropertyName("desde")]
		public DateTime? Desde { get; set; }

		[JsonPropertyName("hasta")]
		public DateTime? Hasta { get; set; }

		public Expression<Func<DTOMovimientosStock, bool>> ConstruirCondicionWhere(UTL_FiltrosMovimientos filtros)
		{
			UTL_FiltrosMovimientos filtros2 = filtros;
			ParameterExpression parameterExpression = System.Linq.Expressions.Expression.Parameter(typeof(DTOMovimientosStock));
			List<System.Linq.Expressions.Expression> list = new List<System.Linq.Expressions.Expression>();
			IEnumerable<PropertyInfo> enumerable = from Prop in typeof(UTL_FiltrosMovimientos).GetProperties()
				where Prop.GetValue(filtros2) != null
				select Prop;
			foreach (PropertyInfo item5 in enumerable)
			{
				if (item5.PropertyType == typeof(DateTime?) && item5.GetValue(filtros2) is DateTime?)
				{
					if (item5.Name.Contains("Desde") && item5.GetValue(filtros2) != null)
					{
						BinaryExpression item = System.Linq.Expressions.Expression.GreaterThanOrEqual(System.Linq.Expressions.Expression.Property(parameterExpression, "FechaHoraCreado"), System.Linq.Expressions.Expression.Constant(filtros2.Desde, typeof(DateTime?)));
						list.Add(item);
					}
					else if (item5.Name.Contains("Hasta") && item5.GetValue(filtros2) != null)
					{
						BinaryExpression item2 = System.Linq.Expressions.Expression.LessThanOrEqual(System.Linq.Expressions.Expression.Property(parameterExpression, "FechaHoraCreado"), System.Linq.Expressions.Expression.Constant(filtros2.Hasta, typeof(DateTime?)));
						list.Add(item2);
					}
				}
				if (item5.Name.Equals("Etapa"))
				{
					string propertyName = "CampoStockDestino";
					MemberExpression memberExpression = System.Linq.Expressions.Expression.Property(parameterExpression, "Suministros");
					ParameterExpression parameterExpression2 = System.Linq.Expressions.Expression.Parameter(typeof(DTOSuministrosMovimientosStock));
					MemberExpression instance = System.Linq.Expressions.Expression.Property(parameterExpression2, propertyName);
					MethodInfo method = typeof(string).GetMethod("Contains", new Type[1] { typeof(string) });
					MethodCallExpression body = System.Linq.Expressions.Expression.Call(instance, method, System.Linq.Expressions.Expression.Constant(filtros2.Etapa, typeof(string)));
					Expression<Func<DTOSuministrosMovimientosStock, bool>> expression = System.Linq.Expressions.Expression.Lambda<Func<DTOSuministrosMovimientosStock, bool>>(body, new ParameterExpression[1] { parameterExpression2 });
					MethodCallExpression item3 = System.Linq.Expressions.Expression.Call(typeof(Enumerable), "Any", new Type[1] { typeof(DTOSuministrosMovimientosStock) }, memberExpression, expression);
					list.Add(item3);
				}
				else if (item5.Name.Equals("IdProveedor"))
				{
					string propertyName = "IdProveedor";
					MemberExpression expression2 = System.Linq.Expressions.Expression.Property(parameterExpression, propertyName);
					MemberExpression instance2 = System.Linq.Expressions.Expression.Property(expression2, "NombreProveedor");
					ParameterExpression expression3 = System.Linq.Expressions.Expression.Parameter(typeof(DTOEntidades));
					MemberExpression memberExpression2 = System.Linq.Expressions.Expression.Property(expression3, "NombreProveedor");
					MethodInfo method2 = typeof(string).GetMethod("Contains", new Type[1] { typeof(string) });
					MethodCallExpression item4 = System.Linq.Expressions.Expression.Call(instance2, method2, System.Linq.Expressions.Expression.Constant(filtros2.IdProveedor, typeof(string)));
					list.Add(item4);
				}
			}
			System.Linq.Expressions.Expression body2 = (list.Any() ? list.Aggregate(System.Linq.Expressions.Expression.AndAlso) : System.Linq.Expressions.Expression.Constant(true));
			return System.Linq.Expressions.Expression.Lambda<Func<DTOMovimientosStock, bool>>(body2, new ParameterExpression[1] { parameterExpression });
		}
	}
	public class UTL_FormatoSuministros
	{
		public string IdSuministro { get; set; } = string.Empty;


		public string? Descripcion { get; set; }

		public int? DiametroNominal { get; set; }

		public decimal? Diametro { get; set; }

		public string? Tolerancia { get; set; }

		public decimal? Espesor { get; set; }

		public decimal? Longitud { get; set; }

		public decimal? Altura { get; set; }

		public int? Perfil { get; set; }

		public decimal? Valor { get; set; }

		public string? UnidadAlmacenamiento { get; set; }

		public string? UnidadFraccionamiento { get; set; }
	}
	public class UTL_NombresSuministros
	{
		public List<(string, string, string?)> formatearNombres(List<UTL_FormatoSuministros> list)
		{
			List<(string, string, string)> list2 = new List<(string, string, string)>();
			foreach (UTL_FormatoSuministros item3 in list)
			{
				string item = item3.IdSuministro ?? "";
				string value = item3.Descripcion ?? "";
				string text = (item3.Diametro.HasValue ? $"{item3.Diametro:####}" : null);
				string text2 = (item3.Longitud.HasValue ? $"{item3.Longitud:#,0}" : null);
				string text3 = (item3.Altura.HasValue ? $"{item3.Altura:####}" : null);
				string text4 = (item3.Espesor.HasValue ? $"{item3.Espesor:####}" : null);
				string text5 = (item3.Perfil.HasValue ? $"{item3.Perfil:####}" : null);
				string text6 = item3.Tolerancia ?? "";
				string text7 = item3.DiametroNominal.ToString() ?? "";
				string item2 = ((item3.UnidadFraccionamiento != null) ? item3.UnidadAlmacenamiento : item3.UnidadAlmacenamiento);
				StringBuilder stringBuilder = new StringBuilder();
				StringBuilder stringBuilder2 = stringBuilder;
				StringBuilder stringBuilder3 = stringBuilder2;
				StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(0, 1, stringBuilder2);
				handler.AppendFormatted(value);
				stringBuilder3.Append(ref handler);
				if (text != null)
				{
					stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder4 = stringBuilder2;
					handler = new StringBuilder.AppendInterpolatedStringHandler(13, 1, stringBuilder2);
					handler.AppendLiteral(", Diametro:");
					handler.AppendFormatted(text);
					handler.AppendLiteral("mm");
					stringBuilder4.Append(ref handler);
				}
				if (text2 != null)
				{
					stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder5 = stringBuilder2;
					handler = new StringBuilder.AppendInterpolatedStringHandler(13, 1, stringBuilder2);
					handler.AppendLiteral(", Longitud:");
					handler.AppendFormatted(text2);
					handler.AppendLiteral("mm");
					stringBuilder5.Append(ref handler);
				}
				if (text3 != null)
				{
					stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder6 = stringBuilder2;
					handler = new StringBuilder.AppendInterpolatedStringHandler(11, 1, stringBuilder2);
					handler.AppendLiteral(", Altura:");
					handler.AppendFormatted(text3);
					handler.AppendLiteral("mm");
					stringBuilder6.Append(ref handler);
				}
				if (text4 != null)
				{
					stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder7 = stringBuilder2;
					handler = new StringBuilder.AppendInterpolatedStringHandler(12, 1, stringBuilder2);
					handler.AppendLiteral(", Espesor:");
					handler.AppendFormatted(text4);
					handler.AppendLiteral("mm");
					stringBuilder7.Append(ref handler);
				}
				if (text5 != null)
				{
					stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder8 = stringBuilder2;
					handler = new StringBuilder.AppendInterpolatedStringHandler(9, 1, stringBuilder2);
					handler.AppendLiteral(", Perfil:");
					handler.AppendFormatted(text5);
					stringBuilder8.Append(ref handler);
				}
				if (text6 != "")
				{
					stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder9 = stringBuilder2;
					handler = new StringBuilder.AppendInterpolatedStringHandler(13, 1, stringBuilder2);
					handler.AppendLiteral(", Tolerancia:");
					handler.AppendFormatted(text6);
					stringBuilder9.Append(ref handler);
				}
				if (text7 != "")
				{
					stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder10 = stringBuilder2;
					handler = new StringBuilder.AppendInterpolatedStringHandler(7, 1, stringBuilder2);
					handler.AppendLiteral(", DN:");
					handler.AppendFormatted(text7);
					handler.AppendLiteral("mm");
					stringBuilder10.Append(ref handler);
				}
				list2.Add(new(string, string, string)
				{
					Item1 = item,
					Item2 = stringBuilder.ToString(),
					Item3 = item2
				});
			}
			return list2;
		}
	}
	public class UTL_ParametrosCuotas
	{
		[JsonProperty(PropertyName = "cantidadCuotas", NullValueHandling = NullValueHandling.Ignore)]
		public int CantidadCuotas { get; set; }

		[JsonProperty(PropertyName = "montoVenta", NullValueHandling = NullValueHandling.Ignore)]
		public decimal MontoVenta { get; set; }

		[JsonProperty(PropertyName = "interes", NullValueHandling = NullValueHandling.Ignore)]
		public decimal Interes { get; set; } = default(decimal);

	}
	public class UTL_Productos
	{
		[JsonProperty(PropertyName = "largo", NullValueHandling = NullValueHandling.Ignore)]
		public string? Largo { get; set; } = "Largo";


		[JsonProperty(PropertyName = "ancho", NullValueHandling = NullValueHandling.Ignore)]
		public string? Ancho { get; set; } = "Ancho";


		[JsonProperty(PropertyName = "espesor", NullValueHandling = NullValueHandling.Ignore)]
		public string? Espesor { get; set; } = "Espesor";


		[JsonProperty(PropertyName = "perfil", NullValueHandling = NullValueHandling.Ignore)]
		public string? Perfil { get; set; } = "Perfil";


		[JsonProperty(PropertyName = "diametro", NullValueHandling = NullValueHandling.Ignore)]
		public string? Diametro { get; set; } = "Diámetro";


		[JsonProperty(PropertyName = "diametroNominal", NullValueHandling = NullValueHandling.Ignore)]
		public string? DiametroNominal { get; set; } = "DN";


		[JsonProperty(PropertyName = "peso", NullValueHandling = NullValueHandling.Ignore)]
		public string? Peso { get; set; } = "Peso";


		[JsonProperty(PropertyName = "altura", NullValueHandling = NullValueHandling.Ignore)]
		public string? Altura { get; set; } = "Altura";


		[JsonProperty(PropertyName = "tolerancia", NullValueHandling = NullValueHandling.Ignore)]
		public string? Tolerancia { get; set; } = "Tolerancia";


		[JsonProperty(PropertyName = "longitud", NullValueHandling = NullValueHandling.Ignore)]
		public string? Longitud { get; set; } = "Longitud";


		[JsonProperty(PropertyName = "recibido", NullValueHandling = NullValueHandling.Ignore)]
		public string? Recibido { get; set; } = "Recibidos";


		[JsonProperty(PropertyName = "pintura", NullValueHandling = NullValueHandling.Ignore)]
		public string? Pintura { get; set; } = "En Pintura";


		[JsonProperty(PropertyName = "proceso", NullValueHandling = NullValueHandling.Ignore)]
		public string? Proceso { get; set; } = "En Proceso";


		[JsonProperty(PropertyName = "granallado", NullValueHandling = NullValueHandling.Ignore)]
		public string? Granallado { get; set; } = "En Granallado";


		[JsonProperty(PropertyName = "moldeado", NullValueHandling = NullValueHandling.Ignore)]
		public string? Moldeado { get; set; } = "Moldeados";


		[JsonProperty(PropertyName = "requerido", NullValueHandling = NullValueHandling.Ignore)]
		public string? Requerido { get; set; } = "Requeridos";


		[JsonProperty(PropertyName = "disponibles", NullValueHandling = NullValueHandling.Ignore)]
		public string? Disponibles { get; set; } = "Disponibles";


		[JsonProperty(PropertyName = "faltantes", NullValueHandling = NullValueHandling.Ignore)]
		public string? Faltantes { get; set; } = "Faltantes";


		[JsonProperty(PropertyName = "total", NullValueHandling = NullValueHandling.Ignore)]
		public string? Total { get; set; } = "MontoCompra";


		[JsonProperty(PropertyName = "cantidad", NullValueHandling = NullValueHandling.Ignore)]
		public string? Cantidad { get; private set; } = "Cantidad";


		[JsonProperty(PropertyName = "precioLista", NullValueHandling = NullValueHandling.Ignore)]
		public string? PrecioLista { get; private set; } = "Precio de Lista";


		[JsonProperty(PropertyName = "precioFinal", NullValueHandling = NullValueHandling.Ignore)]
		public string? PrecioFinal { get; private set; } = "Precio Final";


		[JsonProperty(PropertyName = "porcentajeGanancia", NullValueHandling = NullValueHandling.Ignore)]
		public string? PorcentajeGanancia { get; private set; } = "Porcentaje de Ganancia";


		public string[] ObtenerColumnas(List<DTOStockProductos>? StockProductos, List<DTOComponenteFormateado>? Especificacionesformato)
		{
			List<string> list = new List<string>();
			if (StockProductos != null)
			{
				if (StockProductos.Any((DTOStockProductos x) => x.DiametroNominal != null && x.DiametroNominal != "-"))
				{
					list.Add(DiametroNominal ?? "");
				}
				if (StockProductos.Any((DTOStockProductos x) => x.Tolerancia != null && x.Tolerancia != "-"))
				{
					list.Add(Tolerancia ?? "");
				}
				if (StockProductos.Any((DTOStockProductos x) => x.Cantidad != null && x.Cantidad != "-"))
				{
					list.Add(Cantidad ?? "");
				}
				if (StockProductos.Any((DTOStockProductos x) => x.PrecioLista != null && x.PrecioLista != "-"))
				{
					list.Add(PrecioLista ?? "");
				}
				if (StockProductos.Any((DTOStockProductos x) => x.PrecioFinal != null && x.PrecioFinal != "-"))
				{
					list.Add(PrecioFinal ?? "");
				}
				if (StockProductos.Any((DTOStockProductos x) => x.PorcentajeGanancia != null && x.PorcentajeGanancia != "-"))
				{
					list.Add(PorcentajeGanancia ?? "");
				}
				return list.ToArray();
			}
			if (Especificacionesformato != null)
			{
				if (Especificacionesformato.Any((DTOComponenteFormateado x) => x.Largo != null && !x.Largo.Contains('-')))
				{
					list.Add(Largo ?? "");
				}
				if (Especificacionesformato.Any((DTOComponenteFormateado x) => x.Ancho != null && !x.Ancho.Contains('-')))
				{
					list.Add(Ancho ?? "");
				}
				if (Especificacionesformato.Any((DTOComponenteFormateado x) => x.Longitud != null && !x.Longitud.Contains('-')))
				{
					list.Add(Longitud ?? "");
				}
				if (Especificacionesformato.Any((DTOComponenteFormateado x) => x.Espesor != null && !x.Espesor.Contains('-')))
				{
					list.Add(Espesor ?? "");
				}
				if (Especificacionesformato.Any((DTOComponenteFormateado x) => x.Altura != null && !x.Altura.Contains('-')))
				{
					list.Add(Altura ?? "");
				}
				if (Especificacionesformato.Any((DTOComponenteFormateado x) => x.Diametro != null && !x.Diametro.Contains('-')))
				{
					list.Add(Diametro ?? "");
				}
				if (Especificacionesformato.Any((DTOComponenteFormateado x) => x.DiametroNominal != null && !x.DiametroNominal.Contains('-')))
				{
					list.Add(DiametroNominal ?? "");
				}
				if (Especificacionesformato.Any((DTOComponenteFormateado x) => x.Tolerancia != null && !x.Tolerancia.Contains('-')))
				{
					list.Add(Tolerancia ?? "");
				}
				if (Especificacionesformato.Any((DTOComponenteFormateado x) => x.Peso != null && !x.Peso.Contains('-')))
				{
					list.Add(Peso ?? "");
				}
				if (Especificacionesformato.Any((DTOComponenteFormateado x) => x.Perfil != null && !x.Perfil.Contains('-')))
				{
					list.Add(Perfil ?? "");
				}
				if (Especificacionesformato.Any((DTOComponenteFormateado x) => x.Recibido != null && !x.Recibido.Contains('-')))
				{
					list.Add(Recibido ?? "");
				}
				if (Especificacionesformato.Any((DTOComponenteFormateado x) => x.Granallado != null && !x.Granallado.Contains('-')))
				{
					list.Add(Granallado ?? "");
				}
				if (Especificacionesformato.Any((DTOComponenteFormateado x) => x.Pintura != null && !x.Pintura.Contains('-')))
				{
					list.Add(Pintura ?? "");
				}
				if (Especificacionesformato.Any((DTOComponenteFormateado x) => x.Proceso != null && !x.Proceso.Contains('-')))
				{
					list.Add(Proceso ?? "");
				}
				if (Especificacionesformato.Any((DTOComponenteFormateado x) => x.Moldeado != null && !x.Moldeado.Contains('-')))
				{
					list.Add(Moldeado ?? "");
				}
				if (Especificacionesformato.Any((DTOComponenteFormateado x) => x.Requerido != null && !x.Requerido.Contains('-')))
				{
					list.Add(Requerido ?? "");
				}
				if (Especificacionesformato.Any((DTOComponenteFormateado x) => x.Disponibles != null && !x.Disponibles.Contains('-')))
				{
					list.Add(Disponibles ?? "");
				}
				if (Especificacionesformato.Any((DTOComponenteFormateado x) => x.Faltantes != null && !x.Faltantes.Contains('-')))
				{
					list.Add(Faltantes ?? "");
				}
				if (Especificacionesformato.Any((DTOComponenteFormateado x) => x.Total != null && !x.Total.Contains('-')))
				{
					list.Add(Total ?? "");
				}
				return list.ToArray();
			}
			return list.ToArray();
		}
	}
	public class UTL_Suministros
	{
		private readonly AD_Stocks _stocks;

		public UTL_Suministros(AD_Stocks stocks)
		{
			_stocks = stocks;
		}

		internal List<SuministrosMovimientosStock>? MapeoSuministrosDB(List<DTOSuministrosMovimientosStock>? Suministros, string? Origen, string? Destino)
		{
			List<StockInsumos> list = new List<StockInsumos>();
			foreach (DTOSuministrosMovimientosStock item in Suministros ?? Enumerable.Empty<DTOSuministrosMovimientosStock>())
			{
				list.Add(_stocks.BuscarInsumo(item.IdSuministro) ?? new StockInsumos());
			}
			if (list.Count > 0 && Suministros != null && Suministros.Count == list.Count)
			{
				List<SuministrosMovimientosStock> list2 = new List<SuministrosMovimientosStock>();
				return (from StockSuministros in list
					join SuministrosMovimiento in Suministros on StockSuministros.IdInsumo equals SuministrosMovimiento.IdSuministro
					select new { StockSuministros, SuministrosMovimiento } into x
					select new SuministrosMovimientosStock
					{
						IdSuministro = x.SuministrosMovimiento.IdSuministro,
						Cantidad = Convert.ToDecimal(x.SuministrosMovimiento.Cantidad)
					}).ToList();
			}
			return null;
		}
	}
}
namespace Aponus_Web_API.Utilidades.Servicios_BIN
{
	public class BINInfo
	{
		public string Scheme { get; set; } = string.Empty;


		public string Type { get; set; } = string.Empty;


		public string Brand { get; set; } = string.Empty;


		public BankInfo Bank { get; set; } = new BankInfo();

	}
	public class BankInfo
	{
		public string Name { get; set; } = string.Empty;

	}
	public class UTL_IdentificacionesBancarias
	{
		private static readonly HttpClient _httpClient = new HttpClient();

		internal async Task<IActionResult> ObtenerDatosTarjeta(string BIN)
		{
			string URL = "https://lookup.binlist.net/" + BIN;
			HttpResponseMessage Respuesta = await _httpClient.GetAsync(URL);
			Respuesta.EnsureSuccessStatusCode();
			BINInfo binInfo = JsonConvert.DeserializeObject<BINInfo>(await Respuesta.Content.ReadAsStringAsync());
			return new JsonResult(binInfo);
		}
	}
}
namespace Aponus_Web_API.Utilidades.Nombres_Geograficos
{
	public class CitiesResponse
	{
		public List<Ciudades> geonames { get; set; } = new List<Ciudades>();

	}
	public class Ciudades
	{
		[JsonProperty(PropertyName = "toponymName", NullValueHandling = NullValueHandling.Ignore)]
		public string ToponymName { get; set; } = string.Empty;


		[JsonProperty(PropertyName = "countryCode", NullValueHandling = NullValueHandling.Ignore)]
		public string CountryCode { get; set; } = string.Empty;


		[JsonProperty(PropertyName = "adminCode1", NullValueHandling = NullValueHandling.Ignore)]
		public string AdminCode1 { get; set; } = string.Empty;

	}
	public class CountryResponse
	{
		[JsonProperty(PropertyName = "geonames", NullValueHandling = NullValueHandling.Ignore)]
		public List<Paises> Geonames { get; set; } = new List<Paises>();

	}
	public class Estados_Provincias
	{
		[JsonProperty(PropertyName = "toponymName", NullValueHandling = NullValueHandling.Ignore)]
		public string ToponymName { get; set; } = string.Empty;


		[JsonProperty(PropertyName = "geonameId", NullValueHandling = NullValueHandling.Ignore)]
		public string GeonameId { get; set; } = string.Empty;


		[JsonProperty(PropertyName = "countryCode", NullValueHandling = NullValueHandling.Ignore)]
		public string countryCode { get; set; } = string.Empty;


		[JsonProperty(PropertyName = "adminCode1", NullValueHandling = NullValueHandling.Ignore)]
		public string adminCode1 { get; set; } = string.Empty;

	}
	public class Paises
	{
		[JsonProperty(PropertyName = "countryName", NullValueHandling = NullValueHandling.Ignore)]
		public string CountryName { get; set; } = string.Empty;


		[JsonProperty(PropertyName = "countryCode", NullValueHandling = NullValueHandling.Ignore)]
		public string CountryCode { get; set; } = string.Empty;


		[JsonProperty(PropertyName = "geonameId", NullValueHandling = NullValueHandling.Ignore)]
		public int GeonameId { get; set; }
	}
	public class StatesResponse
	{
		public List<Estados_Provincias> Geonames { get; set; } = new List<Estados_Provincias>();

	}
}
namespace Aponus_Web_API.Systema
{
	public class SS_Usuarios
	{
		private readonly AD_Usuarios AdUsuarios;

		public SS_Usuarios(AD_Usuarios _usuarios)
		{
			AdUsuarios = _usuarios;
		}

		internal DTOUsuarios? ValidarUsuario(DTOUsuarios Usuario)
		{
			return AdUsuarios.ValidarCredenciales(Usuario);
		}

		public async Task<IActionResult> NuevoUsuario(DTOUsuarios Usuario)
		{
			Usuarios _Usuario = new Usuarios
			{
				Usuario = (Usuario.Usuario ?? ""),
				IdPerfil = Usuario.IdPerfil.GetValueOrDefault(),
				Correo = (Usuario.Correo ?? ""),
				Contraseña = (Usuario.Contraseña ?? "")
			};
			try
			{
				await AdUsuarios.Nuevo(_Usuario);
				return new StatusCodeResult(200);
			}
			catch (Exception ex)
			{
				return new ContentResult
				{
					Content = (ex.InnerException?.Message ?? ex.Message),
					ContentType = "application/json",
					StatusCode = 500
				};
			}
		}
	}
}
namespace Aponus_Web_API.Objetos_de_Transferencia_de_Datos
{
	public class DTOActualizarCategorias
	{
		public DTOCategorias? Anterior { get; set; }

		public DTOCategorias? Nueva { get; set; }
	}
	public class DTOCategorias : DTODescripciones
	{
		[JsonProperty(PropertyName = "idTipo", NullValueHandling = NullValueHandling.Ignore)]
		public string? IdTipo { get; set; }

		[JsonProperty(PropertyName = "descripcionTipo", NullValueHandling = NullValueHandling.Ignore)]
		public string? DescripcionTipo { get; set; }
	}
	public class DTOComponenteFormateado : DTOStockFormateado
	{
		[JsonProperty(Order = 1, PropertyName = "idDescripcion", NullValueHandling = NullValueHandling.Ignore)]
		public int? IdDescripcion { get; set; }

		[JsonProperty(Order = 2, PropertyName = "IdComponente", NullValueHandling = NullValueHandling.Ignore)]
		public string? idComponente { get; set; }

		[JsonProperty(Order = 3, PropertyName = "largo", NullValueHandling = NullValueHandling.Ignore)]
		public string? Largo { get; set; }

		[JsonProperty(Order = 4, PropertyName = "ancho", NullValueHandling = NullValueHandling.Ignore)]
		public string? Ancho { get; set; }

		[JsonProperty(Order = 5, PropertyName = "longitud", NullValueHandling = NullValueHandling.Ignore)]
		public string? Longitud { get; set; }

		[JsonProperty(Order = 6, PropertyName = "espesor", NullValueHandling = NullValueHandling.Ignore)]
		public string? Espesor { get; set; }

		[JsonProperty(Order = 7, PropertyName = "Altura", NullValueHandling = NullValueHandling.Ignore)]
		public string? Altura { get; set; }

		[JsonProperty(Order = 8, PropertyName = "diametro", NullValueHandling = NullValueHandling.Ignore)]
		public string? Diametro { get; set; }

		[JsonProperty(Order = 9, PropertyName = "diametroNominal", NullValueHandling = NullValueHandling.Ignore)]
		public string? DiametroNominal { get; set; }

		[JsonProperty(Order = 10, PropertyName = "tolerancia", NullValueHandling = NullValueHandling.Ignore)]
		public string? Tolerancia { get; set; }

		[JsonProperty(Order = 11, PropertyName = "peso", NullValueHandling = NullValueHandling.Ignore)]
		public string? Peso { get; set; }

		[JsonProperty(Order = 12, PropertyName = "perfil", NullValueHandling = NullValueHandling.Ignore)]
		public string? Perfil { get; set; }

		[JsonProperty(Order = 13, PropertyName = "idFraccionamiento", NullValueHandling = NullValueHandling.Ignore)]
		public string? idFraccionamiento { get; set; }

		[JsonProperty(Order = 14, PropertyName = "idAlmacenamiento", NullValueHandling = NullValueHandling.Ignore)]
		public string? idAlmacenamiento { get; set; }
	}
	public class DTOComponentesProducto
	{
		[JsonProperty(PropertyName = "idProducto", NullValueHandling = NullValueHandling.Ignore)]
		public string? IdProducto { get; set; }

		[JsonProperty(PropertyName = "idComponente", NullValueHandling = NullValueHandling.Ignore)]
		public string? IdComponente { get; set; }

		[JsonProperty(PropertyName = "cantidad", NullValueHandling = NullValueHandling.Ignore)]
		public decimal? Cantidad { get; set; }

		[JsonProperty(PropertyName = "peso", NullValueHandling = NullValueHandling.Ignore)]
		public decimal? Peso { get; set; }

		[JsonProperty(PropertyName = "largo", NullValueHandling = NullValueHandling.Ignore)]
		public decimal? Largo { get; set; }
	}
	public class DTOCompras
	{
		[JsonProperty(PropertyName = "idCompra", NullValueHandling = NullValueHandling.Ignore)]
		public int? IdCompra { get; set; }

		[JsonProperty(PropertyName = "idProveedor", NullValueHandling = NullValueHandling.Ignore)]
		public int IdProveedor { get; set; }

		[JsonProperty(PropertyName = "fechaHora", NullValueHandling = NullValueHandling.Ignore)]
		public DateTime? FechaHora { get; set; }

		[JsonProperty(PropertyName = "idUsuario", NullValueHandling = NullValueHandling.Ignore)]
		public string IdUsuario { get; set; } = string.Empty;


		[JsonProperty(PropertyName = "montoTotal", NullValueHandling = NullValueHandling.Ignore)]
		public decimal? SaldoTotal { get; set; }

		[JsonProperty(PropertyName = "saldoPendiente", NullValueHandling = NullValueHandling.Ignore)]
		public decimal? SaldoPendiente { get; set; }

		[JsonProperty(PropertyName = "idEstadoCompra", NullValueHandling = NullValueHandling.Ignore)]
		public int? IdEstadoCompra { get; set; }

		[JsonProperty(PropertyName = "saldoCancelado", NullValueHandling = NullValueHandling.Ignore)]
		public decimal? SaldoCancelado => SaldoTotal ?? (0m - SaldoPendiente.GetValueOrDefault());

		[JsonProperty(PropertyName = "usuario", NullValueHandling = NullValueHandling.Ignore)]
		public DTOUsuarios Usuario { get; set; } = new DTOUsuarios();


		[JsonProperty(PropertyName = "estado", NullValueHandling = NullValueHandling.Ignore)]
		public virtual DTOEstadosCompras Estado { get; set; } = new DTOEstadosCompras();


		[JsonProperty(PropertyName = "proveedor", NullValueHandling = NullValueHandling.Ignore)]
		public virtual DTOEntidades Proveedor { get; set; } = new DTOEntidades();


		[JsonProperty(PropertyName = "detallesCompra", NullValueHandling = NullValueHandling.Ignore)]
		public virtual ICollection<DTOComprasDetalles> DetallesCompra { get; set; } = new HashSet<DTOComprasDetalles>();


		[JsonProperty(PropertyName = "pagos", NullValueHandling = NullValueHandling.Ignore)]
		public virtual ICollection<DTOPagosCompras> Pagos { get; set; } = new HashSet<DTOPagosCompras>();

	}
	public class DTOComprasDetalles
	{
		public int IdCompra { get; set; }

		public string IdInsumo { get; set; } = string.Empty;


		public int Cantidad { get; set; }
	}
	public class DTOCuotasCompras
	{
		[JsonProperty(PropertyName = "idCuota", NullValueHandling = NullValueHandling.Ignore)]
		public int? IdCuota { get; set; }

		[JsonProperty(PropertyName = "idCompra", NullValueHandling = NullValueHandling.Ignore)]
		public int? IdVenta { get; set; }

		[JsonProperty(PropertyName = "numeroCuota", NullValueHandling = NullValueHandling.Ignore)]
		public int NumeroCuota { get; set; }

		[JsonProperty(PropertyName = "monto", NullValueHandling = NullValueHandling.Ignore)]
		public decimal Monto { get; set; }

		[JsonProperty(PropertyName = "fechaVencimiento", NullValueHandling = NullValueHandling.Ignore)]
		public DateTime FechaVencimiento { get; set; }

		[JsonProperty(PropertyName = "idEstadoCuota", NullValueHandling = NullValueHandling.Ignore)]
		public int IdEstadoCuota { get; set; }

		[JsonProperty(PropertyName = "fechaPago", NullValueHandling = NullValueHandling.Ignore)]
		public DateTime? FechaPago { get; set; }

		[JsonProperty(PropertyName = "estadoCuota", NullValueHandling = NullValueHandling.Ignore)]
		public virtual DTOEstadosCuotasCompras? EstadoCuota { get; set; }
	}
	public class DTOCuotasVentas
	{
		[JsonProperty(PropertyName = "idCuota", NullValueHandling = NullValueHandling.Ignore)]
		public int? IdCuota { get; set; }

		[JsonProperty(PropertyName = "idVenta", NullValueHandling = NullValueHandling.Ignore)]
		public int? IdVenta { get; set; }

		[JsonProperty(PropertyName = "numeroCuota", NullValueHandling = NullValueHandling.Ignore)]
		public int NumeroCuota { get; set; }

		[JsonProperty(PropertyName = "monto", NullValueHandling = NullValueHandling.Ignore)]
		public decimal Monto { get; set; }

		[JsonProperty(PropertyName = "fechaVencimiento", NullValueHandling = NullValueHandling.Ignore)]
		public DateTime FechaVencimiento { get; set; }

		[JsonProperty(PropertyName = "idEstadoCuota", NullValueHandling = NullValueHandling.Ignore)]
		public int IdEstadoCuota { get; set; }

		[JsonProperty(PropertyName = "fechaPago", NullValueHandling = NullValueHandling.Ignore)]
		public DateTime? FechaPago { get; set; }

		[JsonProperty(PropertyName = "estadoCuota", NullValueHandling = NullValueHandling.Ignore)]
		public virtual DTOEstadosCuotasVentas? EstadoCuota { get; set; }
	}
	public class DTODatosArchivosMovimientosStock
	{
		[JsonProperty(PropertyName = "idMovimiento", NullValueHandling = NullValueHandling.Ignore)]
		public int? IdMovimiento { get; set; }

		[JsonProperty(PropertyName = "nombreArchivo", NullValueHandling = NullValueHandling.Ignore)]
		public string? NombreArchivo { get; set; }

		[JsonProperty(PropertyName = "path", NullValueHandling = NullValueHandling.Ignore)]
		public string? Path { get; set; }

		[JsonProperty(PropertyName = "mimeType", NullValueHandling = NullValueHandling.Ignore)]
		public string? MimeType { get; set; }

		[JsonProperty(PropertyName = "Extension", NullValueHandling = NullValueHandling.Ignore)]
		public string? Extension { get; set; }

		[JsonProperty(PropertyName = "mensajeError", NullValueHandling = NullValueHandling.Ignore)]
		public string? MensajeError { get; set; }

		[JsonProperty(PropertyName = "datosArchivo", NullValueHandling = NullValueHandling.Ignore)]
		public byte[]? DatosArchivo { get; set; }
	}
	public class DTODescripcionComponentes
	{
		[JsonProperty(PropertyName = "idDescripcion", NullValueHandling = NullValueHandling.Ignore)]
		public int IdDescripcion { get; set; } = 0;


		[JsonProperty(PropertyName = "descripcion", NullValueHandling = NullValueHandling.Ignore)]
		public string Descripcion { get; set; } = string.Empty;


		[JsonProperty(PropertyName = "idAlmacenamiento", NullValueHandling = NullValueHandling.Ignore)]
		public string IdAlmacenamiento { get; set; } = string.Empty;


		[JsonProperty(PropertyName = "idFraccionamiento", NullValueHandling = NullValueHandling.Ignore)]
		public string? IdFraccionamiento { get; set; }
	}
	public class DTODescripciones
	{
		[JsonProperty(PropertyName = "idDescripcion", NullValueHandling = NullValueHandling.Ignore)]
		public int IdDescripcion { get; set; } = 0;


		[JsonProperty(PropertyName = "descripcion", NullValueHandling = NullValueHandling.Ignore)]
		public string? Descripcion { get; set; }
	}
	public class DTODescripcionesProductos
	{
		[JsonProperty(Order = 1, PropertyName = "idDescripcion", NullValueHandling = NullValueHandling.Ignore)]
		public int IdDescripcion { get; set; }

		[JsonProperty(Order = 2, PropertyName = "nombreDescripcion", NullValueHandling = NullValueHandling.Ignore)]
		public string NombreDescripcion { get; set; } = string.Empty;


		[JsonProperty(Order = 3, PropertyName = "productos", NullValueHandling = NullValueHandling.Ignore)]
		public List<DTOStockProductos> Productos { get; set; } = new List<DTOStockProductos>();


		[JsonProperty(Order = 100, PropertyName = "columnas", NullValueHandling = NullValueHandling.Ignore)]
		public string[]? Columnas { get; set; }
	}
	public class DTODetallesComponenteProducto : DTOStockFormateado
	{
		[JsonProperty(PropertyName = "idDescripcion", NullValueHandling = NullValueHandling.Ignore)]
		public int? IdDescripcion { get; set; }

		[JsonProperty(PropertyName = "idComponente", NullValueHandling = NullValueHandling.Ignore)]
		public string? idComponente { get; set; }

		[JsonProperty(PropertyName = "largo", NullValueHandling = NullValueHandling.Ignore)]
		public decimal? Largo { get; set; }

		[JsonProperty(PropertyName = "ancho", NullValueHandling = NullValueHandling.Ignore)]
		public decimal? Ancho { get; set; }

		[JsonProperty(PropertyName = "espesor", NullValueHandling = NullValueHandling.Ignore)]
		public decimal? Espesor { get; set; }

		[JsonProperty(PropertyName = "perfil", NullValueHandling = NullValueHandling.Ignore)]
		public int? Perfil { get; set; }

		[JsonProperty(PropertyName = "diametro", NullValueHandling = NullValueHandling.Ignore)]
		public decimal? Diametro { get; set; }

		[JsonProperty(PropertyName = "diametroNominal", NullValueHandling = NullValueHandling.Ignore)]
		public int? DiametroNominal { get; set; }

		[JsonProperty(PropertyName = "Altura", NullValueHandling = NullValueHandling.Ignore)]
		public decimal? Altura { get; set; }

		[JsonProperty(PropertyName = "tolerancia", NullValueHandling = NullValueHandling.Ignore)]
		public string? Tolerancia { get; set; }

		[JsonProperty(PropertyName = "longitud", NullValueHandling = NullValueHandling.Ignore)]
		public decimal? Longitud { get; set; }

		[JsonProperty(PropertyName = "idFraccionamiento", NullValueHandling = NullValueHandling.Ignore)]
		public string? idFraccionamiento { get; set; }

		[JsonProperty(PropertyName = "idAlmacenamiento", NullValueHandling = NullValueHandling.Ignore)]
		public string? idAlmacenamiento { get; set; }

		[JsonProperty(PropertyName = "peso", NullValueHandling = NullValueHandling.Ignore)]
		public decimal? Peso { get; set; }
	}
	public class DTOEntidades
	{
		[JsonProperty(Order = 100, PropertyName = "idEntidad", NullValueHandling = NullValueHandling.Ignore)]
		public int? IdEntidad { get; set; }

		[JsonProperty(Order = 3, PropertyName = "nombreClave", NullValueHandling = NullValueHandling.Ignore)]
		public string? NombreClave { get; set; }

		[JsonProperty(Order = 2, PropertyName = "nombre", NullValueHandling = NullValueHandling.Ignore)]
		public string? Nombre { get; set; }

		[JsonProperty(Order = 1, PropertyName = "apellido", NullValueHandling = NullValueHandling.Ignore)]
		public string? Apellido { get; set; }

		[JsonProperty(Order = 4, PropertyName = "pais", NullValueHandling = NullValueHandling.Ignore)]
		public string? Pais { get; set; }

		[JsonProperty(Order = 6, PropertyName = "ciudad", NullValueHandling = NullValueHandling.Ignore)]
		public string? Ciudad { get; set; }

		[JsonProperty(Order = 5, PropertyName = "provincia", NullValueHandling = NullValueHandling.Ignore)]
		public string? Provincia { get; set; }

		[JsonProperty(Order = 7, PropertyName = "localidad", NullValueHandling = NullValueHandling.Ignore)]
		public string? Localidad { get; set; }

		[JsonProperty(Order = 8, PropertyName = "calle", NullValueHandling = NullValueHandling.Ignore)]
		public string? Calle { get; set; }

		[JsonProperty(Order = 9, PropertyName = "altura", NullValueHandling = NullValueHandling.Ignore)]
		public string? Altura { get; set; }

		[JsonProperty(Order = 10, PropertyName = "codigoPostal", NullValueHandling = NullValueHandling.Ignore)]
		public string? CodigoPostal { get; set; }

		[JsonProperty(Order = 11, PropertyName = "barrio", NullValueHandling = NullValueHandling.Ignore)]
		public string? Barrio { get; set; }

		[JsonProperty(Order = 12, PropertyName = "telefono1", NullValueHandling = NullValueHandling.Ignore)]
		public string? Telefono1 { get; set; }

		[JsonProperty(Order = 13, PropertyName = "telefono2", NullValueHandling = NullValueHandling.Ignore)]
		public string? Telefono2 { get; set; }

		[JsonProperty(Order = 14, PropertyName = "telefono3", NullValueHandling = NullValueHandling.Ignore)]
		public string? Telefono3 { get; set; }

		[JsonProperty(Order = 15, PropertyName = "email", NullValueHandling = NullValueHandling.Ignore)]
		public string? Email { get; set; }

		[JsonProperty(Order = 16, PropertyName = "idFiscal", NullValueHandling = NullValueHandling.Ignore)]
		public string IdFiscal { get; set; } = string.Empty;


		[JsonProperty(Order = 17, PropertyName = "fechaRegistro", NullValueHandling = NullValueHandling.Ignore)]
		public DateTime? FechaRegistro { get; set; }

		[JsonProperty(Order = 18, PropertyName = "idUsuarioRegistro", NullValueHandling = NullValueHandling.Ignore)]
		public string? IdUsuarioRegistro { get; set; }

		[JsonProperty(Order = 19, PropertyName = "idTipo", NullValueHandling = NullValueHandling.Ignore)]
		public int IdTipo { get; set; }

		[JsonProperty(Order = 19, PropertyName = "idCategoria", NullValueHandling = NullValueHandling.Ignore)]
		public int IdCategoria { get; set; }

		[JsonProperty(Order = 19, PropertyName = "idEstado", NullValueHandling = NullValueHandling.Ignore)]
		public bool? IdEstado { get; set; }
	}
	public class DTOEntidadesCategorias
	{
		[JsonProperty(PropertyName = "idTipo", NullValueHandling = NullValueHandling.Ignore)]
		public int? IdTipo { get; set; }

		[JsonProperty(PropertyName = "idCategoria", NullValueHandling = NullValueHandling.Ignore)]
		public int? IdCategoria { get; set; }

		[JsonProperty(PropertyName = "nombreCategoria", NullValueHandling = NullValueHandling.Ignore)]
		public string? NombreCategoria { get; set; }
	}
	public class DTOEntidadesTipos
	{
		[JsonProperty(PropertyName = "idTipo", NullValueHandling = NullValueHandling.Ignore)]
		public int? IdTipo { get; set; }

		[JsonProperty(PropertyName = "nombre", NullValueHandling = NullValueHandling.Ignore)]
		public string? Nombre { get; set; }
	}
	public class DTOEstadosCompras
	{
		public int IdEstadoCompra { get; set; }

		public string Descripcion { get; set; } = string.Empty;

	}
	public class DTOEstadosCuotasCompras
	{
		public int IdEstadoCuota { get; set; }

		public string Descripcion { get; set; } = string.Empty;


		public int IdEstado { get; set; }
	}
	public class DTOEstadosCuotasVentas
	{
		public int IdEstadoCuota { get; set; }

		public string Descripcion { get; set; } = string.Empty;


		public int IdEstado { get; set; }
	}
	public class DTOEstadosMovimientosStock
	{
		[JsonProperty(PropertyName = "idEstadoMovimiento", NullValueHandling = NullValueHandling.Ignore)]
		public int? idEstadoMovimiento { get; set; }

		[JsonProperty(PropertyName = "desripcion", NullValueHandling = NullValueHandling.Ignore)]
		public string Descripcion { get; set; } = string.Empty;


		[JsonProperty(PropertyName = "idEstado", NullValueHandling = NullValueHandling.Ignore)]
		public int? IdEstado { get; set; }
	}
	public class DTOEstadosVentas
	{
		[JsonProperty(PropertyName = "idEstadoVenta", NullValueHandling = NullValueHandling.Ignore)]
		public int? IdEstadoVenta { get; set; }

		[JsonProperty(PropertyName = "descripcion", NullValueHandling = NullValueHandling.Ignore)]
		public string? Descripcion { get; set; }

		[JsonProperty(PropertyName = "idEstado", NullValueHandling = NullValueHandling.Ignore)]
		public int? IdEstado { get; set; }
	}
	public class DTOInfoPropsComponentes
	{
		[JsonProperty(PropertyName = "nombre", NullValueHandling = NullValueHandling.Ignore)]
		public string? Nombre { get; set; }

		[JsonProperty(PropertyName = "tipo", NullValueHandling = NullValueHandling.Ignore)]
		public string? Tipo { get; set; }
	}
	public class DTOInsumos : DTOStockFormateado
	{
		[JsonProperty(PropertyName = "idInsumo", NullValueHandling = NullValueHandling.Ignore)]
		public new string? IdInsumo { get; set; }

		[JsonProperty(PropertyName = "nombre", NullValueHandling = NullValueHandling.Ignore)]
		public string? Nombre { get; set; }
	}
	public class DTOMediosPago
	{
		[JsonProperty(PropertyName = "idMedioPago", NullValueHandling = NullValueHandling.Ignore)]
		public int IdMedioPago { get; set; }

		[JsonProperty(PropertyName = "codigoMPago", NullValueHandling = NullValueHandling.Ignore)]
		public string? CodigoMPago { get; set; }

		[JsonProperty(PropertyName = "descripcion", NullValueHandling = NullValueHandling.Ignore)]
		public string Descripcion { get; set; } = string.Empty;


		[JsonProperty(PropertyName = "idEstado", NullValueHandling = NullValueHandling.Ignore)]
		public int? IdEstado { get; set; }
	}
	public class DTOMovimientosStock
	{
		[JsonProperty(PropertyName = "idMovimiento", NullValueHandling = NullValueHandling.Ignore)]
		public int? IdMovimiento { get; set; }

		[JsonProperty(PropertyName = "usuarioCreacion", NullValueHandling = NullValueHandling.Ignore)]
		public string? UsuarioCreacion { get; set; }

		[JsonProperty(PropertyName = "usuarioModificacion", NullValueHandling = NullValueHandling.Ignore)]
		public string? UsuarioModificacion { get; set; }

		[JsonProperty(PropertyName = "fechaHoraCreado", NullValueHandling = NullValueHandling.Ignore)]
		public DateTime? FechaHoraCreado { get; set; }

		[JsonProperty(PropertyName = "fechaHoraUltimaModificacion", NullValueHandling = NullValueHandling.Ignore)]
		public DateTime? FechaHoraUltimaModificacion { get; set; }

		[JsonProperty(PropertyName = "idProveedorOrigen", NullValueHandling = NullValueHandling.Ignore)]
		public int? IdProveedorOrigen { get; set; }

		[JsonProperty(PropertyName = "idProveedorDestino", NullValueHandling = NullValueHandling.Ignore)]
		public int? IdProveedorDestino { get; set; }

		[JsonProperty(PropertyName = "origen", NullValueHandling = NullValueHandling.Ignore)]
		public string? Origen { get; set; }

		[JsonProperty(PropertyName = "destino", NullValueHandling = NullValueHandling.Ignore)]
		public string? Destino { get; set; }

		[JsonProperty(PropertyName = "tipo", NullValueHandling = NullValueHandling.Ignore)]
		public string? Tipo { get; set; }

		[JsonProperty(PropertyName = "proveedorDestino", NullValueHandling = NullValueHandling.Ignore)]
		public DTOEntidades? Proveedor { get; set; }

		[JsonProperty(PropertyName = "proveedorOrigen", NullValueHandling = NullValueHandling.Ignore)]
		public DTOEntidades? ProveedorOrigen { get; set; }

		[JsonProperty(PropertyName = "Suministros", NullValueHandling = NullValueHandling.Ignore)]
		public List<DTOSuministrosMovimientosStock>? Suministros { get; set; }

		[JsonProperty(PropertyName = "infoArchivos", NullValueHandling = NullValueHandling.Ignore)]
		public List<DTODatosArchivosMovimientosStock>? DatosArchivos { get; set; } = new List<DTODatosArchivosMovimientosStock>();


		[JsonProperty(PropertyName = "archivos", NullValueHandling = NullValueHandling.Ignore)]
		public List<IFormFile>? Archivos { get; set; }

		[JsonProperty(PropertyName = "idEstado", NullValueHandling = NullValueHandling.Ignore)]
		public int? IdEstado { get; set; }

		[JsonProperty(PropertyName = "estado", NullValueHandling = NullValueHandling.Ignore)]
		public string? Estado { get; set; }
	}
	public class DTOPagosCompras
	{
		public int IdPago { get; set; }

		public int IdCompra { get; set; }

		public int IdMedioPago { get; set; }

		public decimal Monto { get; set; }

		public DateTime? Fecha { get; set; }

		public virtual DTOMediosPago MedioPago { get; set; } = new DTOMediosPago();


		public virtual DTOCompras Compra { get; set; } = new DTOCompras();

	}
	public class DTOPagosVentas
	{
		[JsonProperty(PropertyName = "idPago", NullValueHandling = NullValueHandling.Ignore)]
		public int IdPago { get; set; }

		[JsonProperty(PropertyName = "idVenta", NullValueHandling = NullValueHandling.Ignore)]
		public int IdVenta { get; set; }

		[JsonProperty(PropertyName = "idMedioPago", NullValueHandling = NullValueHandling.Ignore)]
		public int IdMedioPago { get; set; }

		[JsonProperty(PropertyName = "monto", NullValueHandling = NullValueHandling.Ignore)]
		public decimal Monto { get; set; }

		[JsonProperty(PropertyName = "fechaPago", NullValueHandling = NullValueHandling.Ignore)]
		public DateTime? Fecha { get; set; }

		[JsonProperty(PropertyName = "medioPago", NullValueHandling = NullValueHandling.Ignore)]
		public DTOMediosPago? MedioPago { get; set; }
	}
	public class DTOProducto
	{
		[JsonProperty(PropertyName = "idTipo", NullValueHandling = NullValueHandling.Ignore)]
		public string? IdTipo { get; set; }

		[JsonProperty(PropertyName = "idProducto", NullValueHandling = NullValueHandling.Ignore)]
		public string? IdProducto { get; set; }

		[JsonProperty(PropertyName = "idDescripcion", NullValueHandling = NullValueHandling.Ignore)]
		public int? IdDescripcion { get; set; }

		[JsonProperty(PropertyName = "diametroNominal", NullValueHandling = NullValueHandling.Ignore)]
		public int? DiametroNominal { get; set; }

		[JsonProperty(PropertyName = "tolerancia", NullValueHandling = NullValueHandling.Ignore)]
		public string? Tolerancia { get; set; }

		[JsonProperty(PropertyName = "cantidad", NullValueHandling = NullValueHandling.Ignore)]
		public int? Cantidad { get; set; }

		[JsonProperty(PropertyName = "precioLista", NullValueHandling = NullValueHandling.Ignore)]
		public decimal? PrecioLista { get; set; }

		[JsonProperty(PropertyName = "precioFinal", NullValueHandling = NullValueHandling.Ignore)]
		public decimal? PrecioFinal { get; set; }

		[JsonProperty(PropertyName = "porcentajeGanancia", NullValueHandling = NullValueHandling.Ignore)]
		public decimal? PorcentajeGanancia { get; set; }

		[JsonProperty(PropertyName = "componentesProducto", NullValueHandling = NullValueHandling.Ignore)]
		public List<DTOComponentesProducto> Componentes { get; set; } = new List<DTOComponentesProducto>();

	}
	public class DTOProductoComponente
	{
		[JsonProperty(PropertyName = "idProducto", NullValueHandling = NullValueHandling.Ignore)]
		public string? IdProducto { get; set; }

		[JsonProperty(PropertyName = "idComponente", NullValueHandling = NullValueHandling.Ignore)]
		public string IdComponente { get; set; } = "";


		[JsonProperty(PropertyName = "descripcion", NullValueHandling = NullValueHandling.Ignore)]
		public string? Descripcion { get; set; }

		[JsonProperty(PropertyName = "perfil", NullValueHandling = NullValueHandling.Ignore)]
		public int? Perfil { get; set; }

		[JsonProperty(PropertyName = "longitud", NullValueHandling = NullValueHandling.Ignore)]
		public decimal? Longitud { get; set; }

		[JsonProperty(PropertyName = "diametroNominal", NullValueHandling = NullValueHandling.Ignore)]
		public int? DiametroNominal { get; set; }

		[JsonProperty(PropertyName = "altura", NullValueHandling = NullValueHandling.Ignore)]
		public decimal? Altura { get; set; }

		[JsonProperty(PropertyName = "largo", NullValueHandling = NullValueHandling.Ignore)]
		public decimal? Largo { get; set; }

		[JsonProperty(PropertyName = "diametro", NullValueHandling = NullValueHandling.Ignore)]
		public decimal? Diametro { get; set; }

		[JsonProperty(PropertyName = "espesor", NullValueHandling = NullValueHandling.Ignore)]
		public decimal? Espesor { get; set; }

		[JsonProperty(PropertyName = "tolerancia", NullValueHandling = NullValueHandling.Ignore)]
		public string Tolerancia { get; set; } = "";


		[JsonProperty(PropertyName = "stockComponente", NullValueHandling = NullValueHandling.Ignore)]
		public List<DTOStock>? StockComponente { get; set; }

		[JsonProperty(PropertyName = "stockFormateado", NullValueHandling = NullValueHandling.Ignore)]
		public List<DTOStockFormateado>? StockFormateado { get; set; }
	}
	public class DTOStock
	{
		[JsonProperty(PropertyName = "idInsumo", NullValueHandling = NullValueHandling.Ignore)]
		public string? IdInsumo { get; set; }

		[JsonProperty(PropertyName = "peso", NullValueHandling = NullValueHandling.Ignore)]
		public decimal? Peso { get; set; }

		[JsonProperty(PropertyName = "cantidad", NullValueHandling = NullValueHandling.Ignore)]
		public decimal? Cantidad { get; set; }

		[JsonProperty(PropertyName = "longitud", NullValueHandling = NullValueHandling.Ignore)]
		public decimal? Longitud { get; set; }

		[JsonProperty(PropertyName = "recibido", NullValueHandling = NullValueHandling.Ignore)]
		public decimal? Recibido { get; set; }

		[JsonProperty(PropertyName = "granallado", NullValueHandling = NullValueHandling.Ignore)]
		public decimal? Granallado { get; set; }

		[JsonProperty(PropertyName = "pintura", NullValueHandling = NullValueHandling.Ignore)]
		public decimal? Pintura { get; set; }

		[JsonProperty(PropertyName = "moldeado", NullValueHandling = NullValueHandling.Ignore)]
		public decimal? Moldeado { get; set; }

		[JsonProperty(PropertyName = "proceso", NullValueHandling = NullValueHandling.Ignore)]
		public decimal? Proceso { get; set; }

		[JsonProperty(PropertyName = "pendientes", NullValueHandling = NullValueHandling.Ignore)]
		public decimal? Pendientes { get; set; }

		[JsonProperty(PropertyName = "total", NullValueHandling = NullValueHandling.Ignore)]
		public decimal? Total { get; set; }

		[JsonProperty(PropertyName = "faltantes", NullValueHandling = NullValueHandling.Ignore)]
		public decimal? Faltantes { get; set; }

		[JsonProperty(PropertyName = "disponibles", NullValueHandling = NullValueHandling.Ignore)]
		public decimal? Disponibles { get; set; }
	}
	public class DTOStockFormateado
	{
		[JsonProperty(Order = 15, PropertyName = "idInsumo", NullValueHandling = NullValueHandling.Ignore)]
		public string? IdInsumo { get; set; }

		[JsonProperty(Order = 16, PropertyName = "NombreInsumo", NullValueHandling = NullValueHandling.Ignore)]
		public string? NombreInsumo { get; set; }

		[JsonProperty(Order = 17, PropertyName = "recibido", NullValueHandling = NullValueHandling.Ignore)]
		public string? Recibido { get; set; }

		[JsonProperty(Order = 18, PropertyName = "granallado", NullValueHandling = NullValueHandling.Ignore)]
		public string? Granallado { get; set; }

		[JsonProperty(Order = 19, PropertyName = "pintura", NullValueHandling = NullValueHandling.Ignore)]
		public string? Pintura { get; set; }

		[JsonProperty(Order = 20, PropertyName = "proceso", NullValueHandling = NullValueHandling.Ignore)]
		public string? Proceso { get; set; }

		[JsonProperty(Order = 21, PropertyName = "moldeado", NullValueHandling = NullValueHandling.Ignore)]
		public string? Moldeado { get; set; }

		[JsonProperty(Order = 22, PropertyName = "requerido", NullValueHandling = NullValueHandling.Ignore)]
		public string? Requerido { get; set; }

		[JsonProperty(Order = 23, PropertyName = "disponibles", NullValueHandling = NullValueHandling.Ignore)]
		public string? Disponibles { get; set; }

		[JsonProperty(Order = 24, PropertyName = "faltantes", NullValueHandling = NullValueHandling.Ignore)]
		public string? Faltantes { get; set; }

		[JsonProperty(Order = 25, PropertyName = "total", NullValueHandling = NullValueHandling.Ignore)]
		public string? Total { get; set; }
	}
	public class DTOStockProductos : DTOStockFormateado
	{
		[JsonProperty(Order = 1, PropertyName = "idProducto", NullValueHandling = NullValueHandling.Ignore)]
		public string? IdProducto { get; set; }

		[JsonProperty(Order = 2, PropertyName = "idTipo", NullValueHandling = NullValueHandling.Ignore)]
		public string IdTipo { get; set; } = string.Empty;


		[JsonProperty(Order = 3, PropertyName = "idDescripcion", NullValueHandling = NullValueHandling.Ignore)]
		public string? IdDescripcion { get; set; }

		[JsonProperty(Order = 4, PropertyName = "diametroNominal", NullValueHandling = NullValueHandling.Ignore)]
		public string? DiametroNominal { get; set; }

		[JsonProperty(Order = 5, PropertyName = "tolerancia", NullValueHandling = NullValueHandling.Ignore)]
		public string? Tolerancia { get; set; }

		[JsonProperty(Order = 6, PropertyName = "cantidad", NullValueHandling = NullValueHandling.Ignore)]
		public string? Cantidad { get; set; }

		[JsonProperty(Order = 7, PropertyName = "precioLista", NullValueHandling = NullValueHandling.Ignore)]
		public string? PrecioLista { get; set; }

		[JsonProperty(Order = 8, PropertyName = "precioFinal", NullValueHandling = NullValueHandling.Ignore)]
		public string? PrecioFinal { get; set; }

		[JsonProperty(Order = 9, PropertyName = "porcentajeGanancia", NullValueHandling = NullValueHandling.Ignore)]
		public string? PorcentajeGanancia { get; set; }
	}
	public class DTOStockUpdate
	{
		[JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
		public string? Id { get; set; }

		[JsonProperty(PropertyName = "idExistencia", NullValueHandling = NullValueHandling.Ignore)]
		public string? IdExistencia { get; set; }

		[JsonProperty(PropertyName = "idTipoExistencia", NullValueHandling = NullValueHandling.Ignore)]
		public int? IdTipoExistencia { get; set; }

		[JsonProperty(PropertyName = "origen", NullValueHandling = NullValueHandling.Ignore)]
		public string? Origen { get; set; }

		[JsonProperty(PropertyName = "destino", NullValueHandling = NullValueHandling.Ignore)]
		public string? Destino { get; set; }

		[JsonProperty(PropertyName = "operador", NullValueHandling = NullValueHandling.Ignore)]
		public string? Operador { get; set; }

		[JsonProperty(PropertyName = "cantidad", NullValueHandling = NullValueHandling.Ignore)]
		public decimal? Cantidad { get; set; }

		[JsonProperty(PropertyName = "idJuntaPerfil", NullValueHandling = NullValueHandling.Ignore)]
		public string? IdJuntaPerfil { get; set; }

		[JsonProperty(PropertyName = "idBulon", NullValueHandling = NullValueHandling.Ignore)]
		public string? IdBulon { get; set; }

		[JsonProperty(PropertyName = "usuario", NullValueHandling = NullValueHandling.Ignore)]
		public string? Usuario { get; set; }

		[JsonProperty(PropertyName = "archivos", NullValueHandling = NullValueHandling.Ignore)]
		public List<IFormFile>? Archivos { get; set; }

		[JsonProperty(PropertyName = "idProveedorOrigen", NullValueHandling = NullValueHandling.Ignore)]
		public int? IdProveedorOrigen { get; set; }

		[JsonProperty(PropertyName = "idEntidad", NullValueHandling = NullValueHandling.Ignore)]
		public int? IdEntidad { get; set; }

		[JsonProperty(PropertyName = "Suministros", NullValueHandling = NullValueHandling.Ignore)]
		public List<DTOSuministrosMovimientosStock>? Suministros { get; set; }
	}
	public class DTOSuministrosMovimientosStock
	{
		[JsonProperty(PropertyName = "idMovimiento", NullValueHandling = NullValueHandling.Ignore)]
		public int? IdMovimiento { get; set; }

		[JsonProperty(PropertyName = "idSuministro", NullValueHandling = NullValueHandling.Ignore)]
		public string IdSuministro { get; set; } = string.Empty;


		[JsonProperty(PropertyName = "nombreSuministro", NullValueHandling = NullValueHandling.Ignore)]
		public string? NombreSuministro { get; set; }

		[JsonProperty(PropertyName = "valorAnteriorOrigen", NullValueHandling = NullValueHandling.Ignore)]
		public string? ValorAnteriorOrigen { get; set; }

		[JsonProperty(PropertyName = "valorAnteriorDestino", NullValueHandling = NullValueHandling.Ignore)]
		public string? ValorAnteriorDestino { get; set; }

		[JsonProperty(PropertyName = "valorNuevoOrigen", NullValueHandling = NullValueHandling.Ignore)]
		public string? ValorNuevoOrigen { get; set; }

		[JsonProperty(PropertyName = "valorNuevoDestino", NullValueHandling = NullValueHandling.Ignore)]
		public string? ValorNuevoDestino { get; set; }

		[JsonProperty(PropertyName = "cantidad", NullValueHandling = NullValueHandling.Ignore)]
		public string? Cantidad { get; set; }
	}
	public class DTOTipoInsumos : DTODetallesComponenteProducto
	{
		[JsonProperty(PropertyName = "idDescripcion")]
		public new int? IdDescripcion { get; set; }

		[JsonProperty(PropertyName = "descripcion")]
		public string? Descripcion { get; set; }

		[JsonProperty(PropertyName = "especificaciones", NullValueHandling = NullValueHandling.Ignore)]
		public List<DTODetallesComponenteProducto>? Especificaciones { get; set; } = null;


		[JsonProperty(PropertyName = "especificacionesFormato", NullValueHandling = NullValueHandling.Ignore)]
		public List<DTOComponenteFormateado>? especificacionesFormato { get; set; } = null;


		[JsonProperty(PropertyName = "columnas", NullValueHandling = NullValueHandling.Ignore)]
		public string[]? Columnas { get; set; }

		[JsonProperty(PropertyName = "columnasProp", NullValueHandling = NullValueHandling.Ignore)]
		public UTL_Productos? ColumnasProp { get; set; }
	}
	public class DTOTiposProductos
	{
		[JsonProperty(PropertyName = "idTipo", NullValueHandling = NullValueHandling.Ignore)]
		public string IdTipo { get; set; } = string.Empty;


		[JsonProperty(PropertyName = "descripcionTipo", NullValueHandling = NullValueHandling.Ignore)]
		public string DescripcionTipo { get; set; } = string.Empty;


		public List<DTODescripcionesProductos> DescripcionProductos { get; set; } = new List<DTODescripcionesProductos>();

	}
	public class DTOUsuarios
	{
		[JsonProperty(PropertyName = "usuario", NullValueHandling = NullValueHandling.Ignore)]
		public string? Usuario { get; set; }

		[JsonProperty(PropertyName = "contraseña", NullValueHandling = NullValueHandling.Ignore)]
		public string? Contraseña { get; set; }

		[JsonProperty(PropertyName = "Correo", NullValueHandling = NullValueHandling.Ignore)]
		public string? Correo { get; set; }

		[JsonProperty(PropertyName = "idPerfil", NullValueHandling = NullValueHandling.Ignore)]
		public int? IdPerfil { get; set; }
	}
	public class DTOVentas
	{
		[JsonProperty(PropertyName = "idVenta", NullValueHandling = NullValueHandling.Ignore)]
		public int? IdVenta { get; set; }

		[Required(ErrorMessage = "El campo 'Cliente' es obligatorio")]
		[JsonProperty(PropertyName = "idCliente", NullValueHandling = NullValueHandling.Ignore)]
		public int IdCliente { get; set; }

		[JsonProperty(PropertyName = "fechaHora", NullValueHandling = NullValueHandling.Ignore)]
		public DateTime? FechaHora { get; set; }

		[Required(ErrorMessage = "El campo 'Usuario' es obligatorio")]
		[JsonProperty(PropertyName = "idUsuario", NullValueHandling = NullValueHandling.Ignore)]
		public string IdUsuario { get; set; } = string.Empty;


		[JsonProperty(PropertyName = "montoTotal", NullValueHandling = NullValueHandling.Ignore)]
		public decimal MontoTotal { get; set; } = default(decimal);


		[JsonProperty(PropertyName = "saldoPendiente", NullValueHandling = NullValueHandling.Ignore)]
		public decimal? SaldoPendiente { get; set; }

		[JsonProperty(PropertyName = "idEstadoVenta", NullValueHandling = NullValueHandling.Ignore)]
		public int IdEstadoVenta { get; set; }

		[JsonProperty(PropertyName = "cliente", NullValueHandling = NullValueHandling.Ignore)]
		public DTOEntidades? Cliente { get; set; }

		[JsonProperty(PropertyName = "detallesVenta", NullValueHandling = NullValueHandling.Ignore)]
		public ICollection<DTOVentasDetalles>? DetallesVenta { get; set; }

		[JsonProperty(PropertyName = "pagos", NullValueHandling = NullValueHandling.Ignore)]
		public ICollection<DTOPagosVentas>? Pagos { get; set; }

		[JsonProperty(PropertyName = "cuotas", NullValueHandling = NullValueHandling.Ignore)]
		public ICollection<DTOCuotasVentas>? Cuotas { get; set; }

		[JsonProperty(PropertyName = "estado", NullValueHandling = NullValueHandling.Ignore)]
		public ICollection<DTOEstadosVentas>? Estado { get; set; }
	}
	public class DTOVentasDetalles
	{
		[JsonProperty(PropertyName = "idVenta", NullValueHandling = NullValueHandling.Ignore)]
		public int? IdVenta { get; set; }

		[JsonProperty(PropertyName = "idProducto", NullValueHandling = NullValueHandling.Ignore)]
		public string IdProducto { get; set; } = string.Empty;


		[JsonProperty(PropertyName = "cantidad", NullValueHandling = NullValueHandling.Ignore)]
		public int Cantidad { get; set; }

		[JsonProperty(PropertyName = "precio", NullValueHandling = NullValueHandling.Ignore)]
		public decimal Precio { get; set; }

		public decimal SubTotal => Precio * (decimal)Cantidad;
	}
}
namespace Aponus_Web_API.Negocio
{
	public class BS_Categorias
	{
		private readonly AD_Categorias AdCategorias;

		private readonly AD_Componentes _ComponentesProductos;

		public BS_Categorias(AD_Categorias _AdCategorias, AD_Componentes componentesProductos)
		{
			AdCategorias = _AdCategorias;
			_ComponentesProductos = componentesProductos;
		}

		internal async Task<IActionResult> NormalizarDescripcionProducto(DTOCategorias NuevaCategoria)
		{
			ProductosDescripcion DescripcionProductoDB = new ProductosDescripcion
			{
				DescripcionProducto = Regex.Replace(NuevaCategoria.Descripcion ?? "", "\\s+", " ").Trim().ToUpper()
			};
			var (StatusCode, Error) = await AdCategorias.AgregarDescripcionProducto(DescripcionProductoDB, NuevaCategoria.IdTipo ?? "");
			if (Error != null)
			{
				return new ContentResult
				{
					Content = (Error.InnerException?.Message ?? Error.Message),
					ContentType = "application/json",
					StatusCode = 500
				};
			}
			return new StatusCodeResult(StatusCode.Value);
		}

		internal JsonResult NormalizarNombreTipoProducto(DTOCategorias NuevaCategoria)
		{
			try
			{
				NuevaCategoria.IdTipo = new UTL_Categorias().GenerarIdTipoProducto(NuevaCategoria.DescripcionTipo ?? "");
				NuevaCategoria.DescripcionTipo = NuevaCategoria.DescripcionTipo?.ToUpper();
				AdCategorias.AgregarTipoProducto(NuevaCategoria);
				return new JsonResult(NuevaCategoria.IdTipo);
			}
			catch (DbUpdateException ex)
			{
				return new JsonResult(ex.InnerException?.Message.ToString());
			}
		}

		internal async Task<IActionResult> MapearDescripcionesProductosDTO(string IdTipo)
		{
			List<ProductosDescripcion> resultado;
			Exception error;
			(resultado, error) = await AdCategorias.ListarDescripcionesProductos(IdTipo);
			if (error != null)
			{
				return new ContentResult
				{
					Content = (error.InnerException?.Message ?? error.Message),
					ContentType = "ApplicationBuilder/json",
					StatusCode = 500
				};
			}
			List<DTODescripcionesProductos> ListadoDescripciones = new List<DTODescripcionesProductos>();
			resultado.ForEach(delegate(ProductosDescripcion descripcion)
			{
				ListadoDescripciones.Add(new DTODescripcionesProductos
				{
					IdDescripcion = descripcion.IdDescripcion,
					NombreDescripcion = (descripcion.DescripcionProducto ?? "")
				});
			});
			return new JsonResult(ListadoDescripciones);
		}

		internal IActionResult ValidarOperacionActualizacion(DTOActualizarCategorias ActualizarCategorias)
		{
			try
			{
				if (ActualizarCategorias == null || ActualizarCategorias.Anterior?.IdTipo == null || ActualizarCategorias == null || ActualizarCategorias.Nueva?.DescripcionTipo == null || ActualizarCategorias.Nueva.IdTipo != null)
				{
					if ((ActualizarCategorias == null || ActualizarCategorias.Anterior?.IdTipo == null) && ActualizarCategorias?.Nueva?.IdTipo == null)
					{
						if (ActualizarCategorias != null && ActualizarCategorias.Nueva?.Descripcion != null)
						{
							DTOCategorias? anterior = ActualizarCategorias.Anterior;
							if (anterior != null)
							{
								_ = anterior.IdDescripcion;
								if (true)
								{
									ActualizarCategorias.Nueva.Descripcion = ActualizarCategorias.Nueva.Descripcion.TrimEnd().ToUpper();
									try
									{
										AdCategorias.ActualizarDescripcionProd(ActualizarCategorias);
										return new StatusCodeResult(200);
									}
									catch (DbUpdateException ex)
									{
										string text = ((ex.InnerException == null) ? ex.Message : ex.InnerException.Message);
										return new ContentResult
										{
											StatusCode = 500,
											Content = "Ocurrio un error " + text,
											ContentType = "text/plain"
										};
									}
								}
							}
						}
						if (ActualizarCategorias?.Nueva?.Descripcion == null)
						{
							return new ContentResult
							{
								StatusCode = 400,
								Content = "El campo 'Descripcion' no puede estar vacio",
								ContentType = "text/plain"
							};
						}
						return new ContentResult
						{
							StatusCode = 400,
							Content = "Faltan Datos",
							ContentType = "text/plain"
						};
					}
					if (ActualizarCategorias != null && ActualizarCategorias.Anterior?.IdTipo != null && ActualizarCategorias.Nueva?.IdTipo != null && ActualizarCategorias.Anterior.IdTipo != ActualizarCategorias.Nueva.IdTipo && ActualizarCategorias.Anterior.IdDescripcion == ActualizarCategorias.Nueva.IdDescripcion)
					{
						AdCategorias.ActualizarTipos_Descripciones(ActualizarCategorias);
						return new StatusCodeResult(200);
					}
					return new ContentResult
					{
						StatusCode = 400,
						Content = "Faltan Datos",
						ContentType = "text/plain"
					};
				}
				ActualizarCategorias.Nueva.IdTipo = new UTL_Categorias().GenerarIdTipoProducto(ActualizarCategorias.Nueva.DescripcionTipo);
				ActualizarCategorias.Nueva.DescripcionTipo = ActualizarCategorias.Nueva.DescripcionTipo.TrimEnd().ToUpper();
				ProductosTipo productosTipo = AdCategorias.ObtenerTipo(ActualizarCategorias.Anterior.IdTipo);
				if (productosTipo == null)
				{
					return new ContentResult
					{
						StatusCode = 400,
						Content = "Error: El campo 'Descripcion' no puede estar vacio",
						ContentType = "text/plain"
					};
				}
				try
				{
					AdCategorias.ActualizarTipoProd(ActualizarCategorias);
				}
				catch (DbUpdateException ex2)
				{
					string text2 = ((ex2.InnerException == null) ? ex2.Message : ex2.InnerException.Message);
					return new ContentResult
					{
						StatusCode = 400,
						Content = "Ocurrio un error " + text2,
						ContentType = "text/plain"
					};
				}
			}
			catch (DbUpdateException)
			{
				return new StatusCodeResult(500);
			}
			return new ContentResult
			{
				StatusCode = 500,
				Content = "Error Interno, fin de la instruccion",
				ContentType = "text/plain"
			};
		}

		internal IActionResult MapearNombresComponentesDTO()
		{
			List<ComponentesDescripcion> list = _ComponentesProductos.ListarNombresComponentes();
			try
			{
				if (list != null)
				{
					List<DTODescripcionComponentes> DTODescripcionesComponentes = new List<DTODescripcionComponentes>();
					list.ForEach(delegate(ComponentesDescripcion componentes)
					{
						DTODescripcionesComponentes.Add(new DTODescripcionComponentes
						{
							Descripcion = (componentes.Descripcion ?? ""),
							IdAlmacenamiento = componentes.IdAlmacenamiento,
							IdDescripcion = componentes.IdDescripcion,
							IdFraccionamiento = componentes.IdFraccionamiento
						});
					});
					return new JsonResult(DTODescripcionesComponentes);
				}
			}
			catch (Exception ex)
			{
				return new ContentResult
				{
					StatusCode = 500,
					Content = (ex.InnerException?.Message ?? ex.Message),
					ContentType = "text/plain"
				};
			}
			return new JsonResult(null);
		}

		internal async Task<IActionResult> MapeoComponenteBD(DTODescripcionComponentes Componente)
		{
			ComponentesDescripcion componente = new ComponentesDescripcion
			{
				Descripcion = Regex.Replace(Componente.Descripcion, "\\s+", " ").Trim().ToUpper(),
				IdAlmacenamiento = (Componente.IdAlmacenamiento ?? ""),
				IdFraccionamiento = (Componente?.IdFraccionamiento ?? "")
			};
			if (Componente == null || Componente.IdDescripcion != 0)
			{
				componente.IdDescripcion = Componente.IdDescripcion;
				var (statusCode, _error) = await AdCategorias.ModificarDescripcionComponente(componente);
				if (_error != null)
				{
					return new ContentResult
					{
						StatusCode = 500,
						Content = (_error.InnerException?.Message ?? _error.Message),
						ContentType = "text/plain"
					};
				}
				return new StatusCodeResult(statusCode.Value);
			}
			var (StatusCode, error) = await AdCategorias.AgregarDescripcionCompoente(componente);
			if (error != null)
			{
				return new ContentResult
				{
					StatusCode = 500,
					Content = (error.InnerException?.Message ?? error.Message),
					ContentType = "text/plain"
				};
			}
			return new StatusCodeResult(StatusCode.Value);
		}

		internal async Task<IActionResult> RegistrarCambioEstadoTipoProducto(string idTipo)
		{
			ProductosTipo TipoProducto = AdCategorias.ObtenerTipo(idTipo);
			if (TipoProducto != null)
			{
				TipoProducto.IdEstado = 0;
				var (statusCode, error) = await AdCategorias.MetodosProductos().DesactivarTipoProductoyRelaciones(TipoProducto);
				if (error != null)
				{
					return new ContentResult
					{
						Content = (error.InnerException?.Message ?? error.Message),
						ContentType = "application/json",
						StatusCode = 500
					};
				}
				if (statusCode.GetValueOrDefault() == 200)
				{
					return new StatusCodeResult(statusCode.Value);
				}
			}
			return new JsonResult(null);
		}

		internal async Task<IActionResult> RegistrarCambioEstadoDescripcionProducto(int idDescription)
		{
			List<ProductosDescripcion> Descripciones;
			Exception error;
			(Descripciones, error) = await AdCategorias.ListarDescripcionesProductos(string.Empty);
			if (error != null)
			{
				return new ContentResult
				{
					Content = (error.InnerException?.Message ?? error.Message),
					ContentType = "application/json",
					StatusCode = 500
				};
			}
			ProductosDescripcion productosDescripcion = Descripciones.FirstOrDefault((ProductosDescripcion x) => x.IdDescripcion == idDescription);
			if (productosDescripcion != null)
			{
				productosDescripcion.IdEstado = 0;
				(int? StatusCode, Exception? Error) tuple2 = await AdCategorias.MetodosProductos().DesactivarDescripcionProductoyRelaciones(productosDescripcion);
				var (Resultado, _) = tuple2;
				_ = tuple2.Error;
				if (error != null)
				{
					return new ContentResult
					{
						Content = (error.InnerException?.Message ?? error.Message),
						ContentType = "application/json",
						StatusCode = 500
					};
				}
				if (Resultado.GetValueOrDefault() == 200)
				{
					return new StatusCodeResult(Resultado.Value);
				}
			}
			return new JsonResult(null);
		}

		internal async Task<JsonResult> MapearTiposProductosDTO()
		{
			List<ProductosTipo> TiposProductos = await AdCategorias.MetodosProductos().ListarTiposProductos();
			List<DTOTiposProductos> DTOTiposProducto = new List<DTOTiposProductos>();
			foreach (ProductosTipo TipoProducto in TiposProductos ?? Enumerable.Empty<ProductosTipo>())
			{
				DTOTiposProducto.Add(new DTOTiposProductos
				{
					IdTipo = TipoProducto.IdTipo,
					DescripcionTipo = (TipoProducto.DescripcionTipo ?? "")
				});
			}
			return new JsonResult(DTOTiposProducto);
		}
	}
	public class BS_Componentes
	{
		private readonly AD_Componentes _componentesProductos;

		public BS_Componentes(AD_Componentes componentesProductos)
		{
			_componentesProductos = componentesProductos;
		}

		internal JsonResult? DeterminarProp(DTODetallesComponenteProducto? Especificaciones)
		{
			return _componentesProductos.ListarProp(CategorizarPropiedades(Especificaciones).Item1, CategorizarPropiedades(Especificaciones).Item2);
		}

		internal IActionResult GuardarComponentesProducto(List<DTOComponentesProducto> ComponentesProd)
		{
			if (ComponentesProd.All((DTOComponentesProducto x) => x.IdProducto != null))
			{
				foreach (DTOComponentesProducto item in ComponentesProd)
				{
					try
					{
						_componentesProductos.GuardarComponenteProd(new Productos_Componentes
						{
							IdProducto = (item?.IdProducto ?? ""),
							IdComponente = (item?.IdComponente ?? ""),
							Cantidad = item?.Cantidad,
							Longitud = item?.Largo,
							Peso = item?.Peso
						});
					}
					catch (DbUpdateException)
					{
						return new ContentResult
						{
							Content = "Error al actualizar la Base de Datos",
							ContentType = "text/plan",
							StatusCode = 400
						};
					}
					catch (DbEntityValidationException ex2)
					{
						string text = "";
						foreach (DbEntityValidationResult entityValidationError in ex2.EntityValidationErrors)
						{
							foreach (DbValidationError validationError in entityValidationError.ValidationErrors)
							{
								text = text + "Error de validación: Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage + "\n";
							}
						}
						return new ContentResult
						{
							Content = text,
							StatusCode = 400
						};
					}
					catch (InvalidOperationException)
					{
						return new ContentResult
						{
							Content = "Operacion Invalida",
							ContentType = "text/plan",
							StatusCode = 400
						};
					}
					catch (Exception)
					{
						return new ContentResult
						{
							Content = "Objeto Inexistente",
							ContentType = "text/plan",
							StatusCode = 400
						};
					}
				}
				return new StatusCodeResult(200);
			}
			return new ContentResult
			{
				Content = "Faltan Datos",
				ContentType = "text/plan",
				StatusCode = 400
			};
		}

		internal async Task<IActionResult> MapeoComponentesDetalleDTO(int? IdDescripcion)
		{
			List<ComponentesDetalle> Listado;
			Exception Ex;
			(Listado, Ex) = await _componentesProductos.ListarDetalleComponentes(IdDescripcion);
			if (Ex != null)
			{
				return new ContentResult
				{
					Content = (Ex.InnerException?.Message ?? Ex.Message),
					ContentType = "application/json",
					StatusCode = 500
				};
			}
			List<DTODetallesComponenteProducto> ComponentesDetalle = new List<DTODetallesComponenteProducto>();
			Listado.ForEach(delegate(ComponentesDetalle x)
			{
				ComponentesDetalle.Add(new DTODetallesComponenteProducto
				{
					IdInsumo = x.IdInsumo,
					IdDescripcion = x.IdDescripcion,
					Altura = x.Altura,
					Espesor = x.Espesor,
					Diametro = x.Diametro,
					DiametroNominal = x.DiametroNominal,
					Longitud = x.Longitud,
					Perfil = x.Perfil,
					Tolerancia = x.Tolerancia,
					Peso = x.Peso,
					idFraccionamiento = x.IdFraccionamiento,
					idAlmacenamiento = x.IdAlmacenamiento
				});
			});
			return new JsonResult(Listado);
		}

		internal JsonResult? ObtenerIdComponente(DTODetallesComponenteProducto? Especificaciones)
		{
			return _componentesProductos.ObtenerId(CategorizarPropiedades(Especificaciones).Item2);
		}

		internal IActionResult ObtenerPropsComponentes()
		{
			ComponentesDetalle componentesDetalle = new ComponentesDetalle();
			Type type = componentesDetalle.GetType();
			PropertyInfo[] properties = type.GetProperties();
			List<DTOInfoPropsComponentes> list = new List<DTOInfoPropsComponentes>();
			Dictionary<Type, string> dictionary = new Dictionary<Type, string>();
			dictionary.Add(typeof(int), "int");
			dictionary.Add(typeof(string), "string");
			dictionary.Add(typeof(decimal), "decimal");
			dictionary.Add(typeof(int?), "int");
			dictionary.Add(typeof(decimal?), "decimal");
			Dictionary<Type, string> dictionary2 = dictionary;
			PropertyInfo[] array = properties;
			foreach (PropertyInfo propertyInfo in array)
			{
				if (dictionary2.TryGetValue(propertyInfo.PropertyType, out var value) && !propertyInfo.Name.Contains("IdInsumo"))
				{
					list.Add(new DTOInfoPropsComponentes
					{
						Nombre = propertyInfo.Name,
						Tipo = value
					});
				}
			}
			return new JsonResult(list);
		}

		internal async Task<IActionResult> MapeoDetalleNombreComponenteDTO(int? IdDescripcionComponente)
		{
			List<ComponentesDescripcion> Listado;
			Exception error;
			(Listado, error) = await _componentesProductos.ListarTiposAlacenamiento(IdDescripcionComponente);
			if (error != null)
			{
				return new ContentResult
				{
					Content = (error.InnerException?.Message ?? error.Message),
					ContentType = "application/json",
					StatusCode = 400
				};
			}
			List<DTODescripcionComponentes> ListadoDetallesNombresComponentes = new List<DTODescripcionComponentes>();
			Listado.ForEach(delegate(ComponentesDescripcion x)
			{
				ListadoDetallesNombresComponentes.Add(new DTODescripcionComponentes
				{
					IdDescripcion = x.IdDescripcion,
					Descripcion = (x.Descripcion ?? ""),
					IdAlmacenamiento = x.IdAlmacenamiento,
					IdFraccionamiento = x.IdFraccionamiento
				});
			});
			return new JsonResult(ListadoDetallesNombresComponentes);
		}

		private (string[], List<(string Nombre, string Valor)>) CategorizarPropiedades(DTODetallesComponenteProducto? Especificaciones)
		{
			string[] array = new string[0];
			List<(string, string)> list = new List<(string, string)>();
			PropertyInfo[] properties = typeof(DTODetallesComponenteProducto).GetProperties();
			PropertyInfo[] array2 = properties;
			foreach (PropertyInfo propertyInfo in array2)
			{
				object value = propertyInfo.GetValue(Especificaciones);
				bool flag = typeof(ComponentesDetalle).GetProperty(propertyInfo.Name) != null;
				if (value == null && propertyInfo.Name != "idComponente" && flag)
				{
					Array.Resize(ref array, array.Length + 1);
					array[^1] = propertyInfo.Name;
				}
				else if (value != null)
				{
					string item = value.ToString() ?? "";
					list.Add((propertyInfo.Name, item));
				}
			}
			return (array, list);
		}
	}
	public class BS_Compras
	{
		private readonly AD_Compras AdCompras;

		public BS_Compras(AD_Compras _adCompras)
		{
			AdCompras = _adCompras;
		}

		internal async Task<IActionResult> Listar(UTL_FiltrosComprasVentas? Filtros)
		{
			IQueryable<Compras> QueryCompras;
			Exception error;
			(QueryCompras, error) = AdCompras.ObtenerDatos(Filtros);
			if (error != null)
			{
				return new ContentResult
				{
					Content = (error.InnerException?.Message ?? error.Message),
					ContentType = "application/json",
					StatusCode = 400
				};
			}
			return new JsonResult(await QueryCompras.Select((Compras x) => new DTOCompras
			{
				DetallesCompra = x.DetallesCompra.Select((ComprasDetalles y) => new DTOComprasDetalles
				{
					IdCompra = y.IdCompra,
					Cantidad = y.Cantidad,
					IdInsumo = y.IdInsumo
				}).ToList(),
				FechaHora = x.FechaHora,
				IdCompra = x.IdCompra,
				IdProveedor = x.IdProveedor,
				Pagos = x.Pagos.Select((PagosCompras y) => new DTOPagosCompras
				{
					IdCompra = y.IdCompra,
					Fecha = y.Fecha,
					IdMedioPago = y.IdMedioPago,
					Monto = y.Monto,
					IdPago = y.IdPago
				}).ToList(),
				Proveedor = new DTOEntidades
				{
					IdEntidad = x.IdProveedorNavigation.IdEntidad,
					Apellido = x.IdProveedorNavigation.Apellido,
					Nombre = x.IdProveedorNavigation.Nombre,
					NombreClave = x.IdProveedorNavigation.NombreClave
				},
				SaldoPendiente = x.SaldoPendiente,
				SaldoTotal = x.MontoTotal,
				IdUsuario = x.IdUsuario
			}).ToListAsync());
		}

		internal async Task<IActionResult> ProcesarDatosCompra(DTOCompras Compra)
		{
			int num;
			if (!string.IsNullOrEmpty(Compra.IdUsuario) && Compra.DetallesCompra.Count != 0)
			{
				decimal? saldoTotal = Compra.SaldoTotal;
				num = (((saldoTotal.GetValueOrDefault() == default(decimal)) & saldoTotal.HasValue) ? 1 : 0);
			}
			else
			{
				num = 1;
			}
			if (num != 0)
			{
				return new ContentResult
				{
					Content = "Faltan Datos",
					ContentType = "application/json",
					StatusCode = 400
				};
			}
			Compras compra = new Compras
			{
				IdProveedor = Compra.IdProveedor,
				IdUsuario = Compra.IdUsuario,
				DetallesCompra = Compra.DetallesCompra.Select((DTOComprasDetalles dc) => new ComprasDetalles
				{
					Cantidad = dc.Cantidad,
					IdInsumo = dc.IdInsumo,
					IdCompra = dc.IdCompra,
					DetallesInsumo = new ComponentesDetalle
					{
						IdInsumo = dc.IdInsumo
					}
				}).ToList(),
				FechaHora = UTL_Fechas.ObtenerFechaHora(),
				Pagos = Compra.Pagos.Select((DTOPagosCompras p) => new PagosCompras
				{
					IdCompra = p.IdCompra,
					Fecha = p.Fecha,
					IdMedioPago = p.IdMedioPago,
					MedioPago = new MediosPago
					{
						IdMedioPago = p.IdMedioPago
					},
					IdPago = p.IdPago,
					Monto = p.Monto
				}).ToList(),
				IdProveedorNavigation = new Entidades
				{
					IdEntidad = Compra.IdProveedor
				},
				Usuario = new Usuarios
				{
					Usuario = Compra.IdUsuario
				},
				MontoTotal = Compra.SaldoTotal.GetValueOrDefault(),
				SaldoPendiente = Compra.SaldoPendiente.GetValueOrDefault()
			};
			if (Compra.IdCompra.HasValue && Compra.IdCompra.HasValue)
			{
				int IdCompra = Compra.IdCompra.Value;
				Compras _Compra = await AdCompras.BuscarCompra(IdCompra);
				if (_Compra != null)
				{
					compra.IdCompra = _Compra.IdCompra;
				}
			}
			if (await AdCompras.Guardar(compra))
			{
				return new StatusCodeResult(200);
			}
			return new ContentResult
			{
				Content = "Error interno, no se aplicaron los cambios",
				ContentType = "application/json",
				StatusCode = 400
			};
		}

		internal async Task<IActionResult> RegistrarPago(DTOPagosCompras pago)
		{
			PagosCompras Pago = new PagosCompras
			{
				IdCompra = pago.IdCompra,
				Compra = new Compras
				{
					IdCompra = pago.IdCompra
				},
				Monto = pago.Monto,
				Fecha = UTL_Fechas.ObtenerFechaHora(),
				IdMedioPago = pago.IdMedioPago,
				MedioPago = new MediosPago
				{
					IdMedioPago = pago.IdMedioPago
				}
			};
			var (Resultado, Error) = await AdCompras.RegistrarPago(Pago);
			if (Error != null)
			{
				return new ContentResult
				{
					Content = (Error.InnerException?.Message ?? Error.Message),
					ContentType = "application/json",
					StatusCode = 500
				};
			}
			return Resultado;
		}
	}
	public class BS_Entidades
	{
		public class Tipos
		{
			private readonly AD_Entidades AdEntidades;

			public Tipos(AD_Entidades adEntidades)
			{
				AdEntidades = adEntidades;
			}

			internal async Task<IActionResult> ValidarTipoEntidad(int id)
			{
				try
				{
					List<EntidadesTipos> LstTipos;
					Exception ex2;
					(LstTipos, ex2) = await AdEntidades.ListarTiposEntidades();
					if (ex2 != null)
					{
						return new ContentResult
						{
							Content = (ex2.InnerException?.Message ?? ex2.Message),
							ContentType = "application/json",
							StatusCode = 400
						};
					}
					EntidadesTipos TipoEntidad = LstTipos.FirstOrDefault((EntidadesTipos x) => x.IdTipo == id);
					if (TipoEntidad != null)
					{
						TipoEntidad.IdEstado = 0;
						var (Resultado, _ex) = await AdEntidades.DesactivarTipoyRelaciones(TipoEntidad);
						if (_ex != null)
						{
							return new ContentResult
							{
								Content = (_ex.InnerException?.Message ?? _ex.Message),
								ContentType = "application/json",
								StatusCode = 400
							};
						}
						return new StatusCodeResult(Resultado.Value);
					}
					return new ContentResult
					{
						Content = "No se encontró el Tipo",
						ContentType = "application/json",
						StatusCode = 400
					};
				}
				catch (Exception ex3)
				{
					Exception ex = ex3;
					return new ContentResult
					{
						Content = (ex.InnerException?.Message ?? ex.Message),
						ContentType = "application/json",
						StatusCode = 400
					};
				}
			}

			internal async Task<IActionResult> MapeoDTOTipoEntidadDB(DTOEntidadesTipos tipoEntidad)
			{
				EntidadesTipos NuevoTipo = new EntidadesTipos
				{
					NombreTipo = ((!string.IsNullOrEmpty(tipoEntidad.Nombre)) ? Regex.Replace(tipoEntidad.Nombre, "\\s+", " ").Trim().ToUpper() : string.Empty),
					IdTipo = tipoEntidad.IdTipo.GetValueOrDefault()
				};
				var (Resultado, ex) = await AdEntidades.GuardarTipoEntidad(NuevoTipo);
				if (ex != null)
				{
					return new ContentResult
					{
						Content = (ex.InnerException?.Message ?? ex.Message),
						ContentType = "application/json",
						StatusCode = 400
					};
				}
				return new StatusCodeResult(Resultado.Value);
			}

			internal async Task<IActionResult> MapeoTiposEntidadesDTO()
			{
				List<DTOEntidadesTipos> DTOEntidades = new List<DTOEntidadesTipos>();
				List<EntidadesTipos> LstTipos;
				Exception ex;
				(LstTipos, ex) = await AdEntidades.ListarTiposEntidades();
				if (ex != null)
				{
					return new ContentResult
					{
						Content = (ex.InnerException?.Message ?? ex?.Message),
						ContentType = "application/json",
						StatusCode = 400
					};
				}
				LstTipos.ForEach(delegate(EntidadesTipos X)
				{
					DTOEntidades.Add(new DTOEntidadesTipos
					{
						IdTipo = X.IdTipo,
						Nombre = X.NombreTipo
					});
				});
				return new JsonResult(DTOEntidades);
			}
		}

		public class Categorias
		{
			private readonly AD_Entidades AdEntidades;

			public Categorias(AD_Entidades adEntidades)
			{
				AdEntidades = adEntidades;
			}

			internal async Task<IActionResult> ValidarCategoria(int idCategoria)
			{
				List<EntidadesCategorias> LstEntidades;
				Exception ex;
				(LstEntidades, ex) = await AdEntidades.ListarCategorias(null);
				if (ex != null)
				{
					return new ContentResult
					{
						Content = (ex.InnerException?.Message ?? ex?.Message),
						ContentType = "application/json",
						StatusCode = 400
					};
				}
				EntidadesCategorias CategoriaEntidad = LstEntidades.FirstOrDefault((EntidadesCategorias x) => x.IdCategoria == idCategoria);
				if (CategoriaEntidad != null)
				{
					CategoriaEntidad.IdEstado = 0;
					var (resultado, _ex) = await AdEntidades.CambiarEstadoCategoria(CategoriaEntidad);
					if (_ex != null)
					{
						return new ContentResult
						{
							Content = (_ex.InnerException?.Message ?? _ex?.Message),
							ContentType = "application/json",
							StatusCode = 400
						};
					}
					return new StatusCodeResult(resultado.Value);
				}
				return new ContentResult
				{
					Content = "No se encontróla Categoría",
					ContentType = "application/json",
					StatusCode = 400
				};
			}

			internal async Task<IActionResult> MapeoNuevaCategoriaDB(DTOEntidadesCategorias nuevaCategoria)
			{
				EntidadesCategorias entidadesCategorias = new EntidadesCategorias
				{
					IdCategoria = nuevaCategoria.IdCategoria.GetValueOrDefault(),
					NombreCategoria = ((!string.IsNullOrEmpty(nuevaCategoria.NombreCategoria)) ? Regex.Replace(nuevaCategoria.NombreCategoria, "\\s+", " ").Trim().ToUpper() : "")
				};
				var (Resultado, ex) = await AdEntidades.GuardarCategoria(entidadesCategorias, nuevaCategoria.IdTipo);
				if (ex != null)
				{
					return new ContentResult
					{
						Content = (ex.InnerException?.Message ?? ex.Message),
						ContentType = "application/json",
						StatusCode = 400
					};
				}
				return new StatusCodeResult(Resultado.Value);
			}

			internal async Task<IActionResult> MapeoEntidadesCategoriasDTO(int? idTipo)
			{
				new List<EntidadesCategorias>();
				List<DTOEntidadesCategorias> DTOCategorias = new List<DTOEntidadesCategorias>();
				List<EntidadesCategorias> LstCategorias;
				Exception ex;
				(LstCategorias, ex) = await AdEntidades.ListarCategorias(idTipo);
				if (ex != null)
				{
					return new ContentResult
					{
						Content = (ex.InnerException?.Message ?? ex.Message),
						ContentType = "application/json",
						StatusCode = 400
					};
				}
				LstCategorias.ForEach(delegate(EntidadesCategorias c)
				{
					DTOCategorias.Add(new DTOEntidadesCategorias
					{
						IdTipo = idTipo,
						IdCategoria = c.IdCategoria,
						NombreCategoria = c.NombreCategoria
					});
				});
				return new JsonResult(DTOCategorias);
			}
		}

		private readonly AD_Entidades AdEntidades;

		public BS_Entidades(AD_Entidades adEntidades)
		{
			AdEntidades = adEntidades;
		}

		public Tipos TiposEntidades()
		{
			return new Tipos(AdEntidades);
		}

		public Categorias CategoriasEntidades()
		{
			return new Categorias(AdEntidades);
		}

		internal async Task<IActionResult> ValidarEntidad(int idEntidad)
		{
			IQueryable<Entidades> LstEntidades = AdEntidades.ListarEntidades();
			Entidades Entidad = LstEntidades.FirstOrDefault((Entidades x) => x.IdEntidad == idEntidad);
			if (Entidad == null)
			{
				return new ContentResult
				{
					ContentType = "application/json",
					StatusCode = 400,
					Content = "No se encontró la Entidad"
				};
			}
			var (Status, error) = await AdEntidades.DeshabilitarEntidad(Entidad);
			if (error != null)
			{
				return new ContentResult
				{
					ContentType = "application/json",
					StatusCode = 400,
					Content = (error.InnerException?.Message ?? error.Message)
				};
			}
			return new StatusCodeResult(Status.Value);
		}

		internal IActionResult MapeoEntidadesDTO(int IdTipo, int IdCategoria, int IdEntidad)
		{
			try
			{
				IQueryable<Entidades> source = AdEntidades.ListarEntidades();
				if (IdEntidad != 0)
				{
					source = source.Where((Entidades x) => x.IdEntidad == IdEntidad);
				}
				if (IdTipo != 0)
				{
					source = source.Where((Entidades x) => x.IdTipo == IdTipo);
				}
				if (IdCategoria != 0)
				{
					source = source.Where((Entidades x) => x.IdCategoria == IdCategoria);
				}
				List<DTOEntidades> value = source.Select((Entidades x) => new DTOEntidades
				{
					IdEntidad = x.IdEntidad,
					NombreClave = x.NombreClave,
					Nombre = x.Nombre,
					Apellido = x.Apellido,
					Pais = x.Pais,
					Ciudad = x.Ciudad,
					Provincia = x.Provincia,
					Localidad = x.Localidad,
					Calle = x.Calle,
					Altura = x.Altura,
					CodigoPostal = x.CodigoPostal,
					Barrio = x.Barrio,
					Telefono1 = x.Telefono1,
					Telefono2 = x.Telefono2,
					Telefono3 = x.Telefono3,
					Email = x.Email,
					IdFiscal = x.IdFiscal,
					FechaRegistro = x.FechaRegistro,
					IdUsuarioRegistro = x.IdUsuarioRegistro,
					IdTipo = x.IdTipo,
					IdCategoria = x.IdCategoria
				}).ToList();
				return new JsonResult(value);
			}
			catch (Exception ex)
			{
				return new ContentResult
				{
					ContentType = "application/json",
					StatusCode = 400,
					Content = ((!string.IsNullOrEmpty(ex.InnerException?.Message)) ? ("Error:\n" + ex.InnerException.Message) : ("Error:\n" + ex.Message))
				};
			}
		}

		internal IActionResult ValidaryNormalizarDatos(DTOEntidades Entidad)
		{
			try
			{
				if (Entidad.Nombre == null && Entidad.Apellido == null && Entidad.NombreClave == null)
				{
					return new ContentResult
					{
						Content = "Completar Nombre, Apellido y/o Razón Social",
						ContentType = "application/json",
						StatusCode = 400
					};
				}
				DateTime dateTime = UTL_Fechas.ObtenerFechaHora();
				Entidad.NombreClave = ((!string.IsNullOrEmpty(Entidad.NombreClave)) ? Regex.Replace(Entidad.NombreClave, "\\s+", " ").Trim().ToUpper() : (Regex.Replace(Entidad.Apellido ?? "", "\\s+", " ").Trim().ToUpper() + " " + Regex.Replace(Entidad.Nombre ?? "", "\\s+", " ").Trim().ToUpper()));
				PropertyInfo[] properties = Entidad.GetType().GetProperties();
				foreach (PropertyInfo propertyInfo in properties)
				{
					if (propertyInfo.PropertyType == typeof(string) && !propertyInfo.Name.ToLower().Equals("idfiscal") && !propertyInfo.Name.ToLower().Equals("idusuarioregistro"))
					{
						string text = (string)propertyInfo.GetValue(Entidad);
						string value = Regex.Replace(text ?? "", "\\s+ ", " ").Trim().ToUpper();
						propertyInfo.SetValue(Entidad, value);
					}
					else if (propertyInfo.Name.ToLower().Equals("idfiscal"))
					{
						string text2 = (string)propertyInfo.GetValue(Entidad);
						string value2 = Regex.Replace(text2 ?? "", "-", "");
						propertyInfo.SetValue(Entidad, value2);
					}
				}
				return AdEntidades.GuardarEntidad(Entidad);
			}
			catch (Exception ex)
			{
				return new ContentResult
				{
					ContentType = "application/json",
					StatusCode = 400,
					Content = ((!string.IsNullOrEmpty(ex.InnerException?.Message)) ? ("Error:\n" + ex.InnerException.Message) : ("Error:\n" + ex.Message))
				};
			}
		}
	}
	public class BS_Movimientos
	{
		public class Archivos
		{
			private readonly AponusContext AponusDbContext;

			private readonly AD_Stocks stocks;

			private readonly AD_Movimientos _movimientosStock;

			private readonly BS_Entidades BsEntidades;

			public Archivos(AponusContext aponusDbContext, AD_Stocks _stocks, AD_Movimientos movimientosStock, BS_Entidades bsEntidades)
			{
				AponusDbContext = aponusDbContext;
				stocks = _stocks;
				_movimientosStock = movimientosStock;
				BsEntidades = bsEntidades;
			}

			internal async Task<IActionResult> Agregar(DTOMovimientosStock ArchivosMovimiento)
			{
				DTOMovimientosStock ArchivosMovimiento2 = ArchivosMovimiento;
				DTOMovimientosStock DatosMovimiento = await _movimientosStock.ObtenerDatosMovimiento(ArchivosMovimiento2.IdMovimiento.GetValueOrDefault(-1));
				new List<DTOEntidades>();
				if (DatosMovimiento != null)
				{
					IActionResult ProveedoresActionResult = BsEntidades.MapeoEntidadesDTO(ArchivosMovimiento2.IdProveedorDestino.GetValueOrDefault(), 0, 0);
					IEnumerable<DTOEntidades> ProveedoresList = default(IEnumerable<DTOEntidades>);
					int num;
					if (ProveedoresActionResult is JsonResult { Value: not null } jsonProveedores)
					{
						object value = jsonProveedores.Value;
						ProveedoresList = value as IEnumerable<DTOEntidades>;
						num = ((ProveedoresList != null) ? 1 : 0);
					}
					else
					{
						num = 0;
					}
					if (num != 0)
					{
						DTOEntidades proveedor = (from x in ProveedoresList
							where x.IdEntidad == ArchivosMovimiento2.IdProveedorDestino
							select new DTOEntidades
							{
								Apellido = x.Apellido,
								Nombre = x.Nombre,
								NombreClave = x.NombreClave
							}).FirstOrDefault();
						if (ArchivosMovimiento2.Archivos != null && proveedor != null)
						{
							List<ArchivosMovimientosStock> DatosArchivos = new UTL_Cloudinary().SubirArchivosMovimiento(ArchivosMovimiento2.Archivos, (!string.IsNullOrEmpty(proveedor?.NombreClave)) ? proveedor.NombreClave : (proveedor?.Apellido + "_" + proveedor?.Nombre));
							DatosArchivos.ForEach(delegate(ArchivosMovimientosStock x)
							{
								x.IdMovimiento = ArchivosMovimiento2.IdMovimiento.GetValueOrDefault();
							});
							using IDbContextTransaction transacccion = AponusDbContext.Database.BeginTransaction();
							bool RollBack = false;
							if (stocks.GuardarDatosArchivosMovimiento(AponusDbContext, DatosArchivos))
							{
								RollBack = true;
							}
							if (_movimientosStock.RegistrarModificacion(AponusDbContext, ArchivosMovimiento2))
							{
								RollBack = true;
							}
							if (RollBack)
							{
								transacccion.Rollback();
								return new ContentResult
								{
									Content = "Error Interno, No se aplicaron los cambios",
									ContentType = "application/json",
									StatusCode = 400
								};
							}
							AponusDbContext.SaveChanges();
							AponusDbContext.Database.CommitTransaction();
							return new StatusCodeResult(200);
						}
						return new ContentResult
						{
							Content = "Faltan Datos",
							ContentType = "application/json",
							StatusCode = 400
						};
					}
					return new ContentResult
					{
						Content = "No se encontró el IdProveedorNavigation",
						ContentType = "application/json",
						StatusCode = 400
					};
				}
				return new ContentResult
				{
					Content = "No se encontró el movimiento",
					ContentType = "application/json",
					StatusCode = 400
				};
			}

			internal IActionResult Eliminar(DTOMovimientosStock Movimiento)
			{
				AD_Movimientos.ArchivosMovimientos archivosMovimientos = _movimientosStock.Archivos();
				bool flag = false;
				if (Movimiento.DatosArchivos != null)
				{
					using (IDbContextTransaction dbContextTransaction = AponusDbContext.Database.BeginTransaction())
					{
						try
						{
							if (!archivosMovimientos.Eliminar(AponusDbContext, (Movimiento?.IdMovimiento).GetValueOrDefault(-1), Movimiento?.DatosArchivos?.Select((DTODatosArchivosMovimientosStock x) => x.NombreArchivo ?? "").First() ?? ""))
							{
								flag = true;
							}
							if (!_movimientosStock.RegistrarModificacion(AponusDbContext, Movimiento ?? new DTOMovimientosStock()))
							{
								flag = true;
							}
							if (flag)
							{
								dbContextTransaction.Rollback();
								return new ContentResult
								{
									Content = "Error interno, no se aplicaron los cambios",
									ContentType = "application/json",
									StatusCode = 500
								};
							}
							AponusDbContext.SaveChanges();
							AponusDbContext.Database.CommitTransaction();
							return new StatusCodeResult(200);
						}
						catch (Exception)
						{
							return new ContentResult
							{
								Content = "Error interno, no se aplicaron los cambios",
								ContentType = "application/json",
								StatusCode = 500
							};
						}
					}
				}
				return new ContentResult
				{
					Content = "Faltan los archivos a ValidarCategoria",
					ContentType = "application/json",
					StatusCode = 400
				};
			}
		}

		public class Estados
		{
			private readonly AponusContext AponusDbContext;

			public Estados(AponusContext aponusDbContext)
			{
				AponusDbContext = aponusDbContext;
			}

			public IActionResult Listar()
			{
				List<EstadosMovimientosStock> value = AD_Movimientos.Estados.Listar(AponusDbContext);
				return new JsonResult(value);
			}

			internal async Task<IActionResult> Guardar(DTOEstadosMovimientosStock estado)
			{
				estado.Descripcion = Regex.Replace(estado.Descripcion, "\\s+", " ").Trim().ToUpper();
				string insert = "INSERT INTO \"ESTADOS_MOVIMIENTOS_STOCK\" (\"DESCRIPCION\") VALUES (@DESCRIPCION)";
				try
				{
					EstadosMovimientosStock Existe = AponusDbContext.EstadoMovimientosStock.Find(estado.idEstadoMovimiento);
					if (Existe != null)
					{
						Existe.IdEstado = estado.IdEstado ?? Existe.IdEstado;
						Existe.Descripcion = estado.Descripcion ?? Existe.Descripcion;
						Existe.IdEstadoMovimiento = estado.idEstadoMovimiento ?? Existe.IdEstadoMovimiento;
						AponusDbContext.EstadoMovimientosStock.Update(Existe);
						await AponusDbContext.SaveChangesAsync();
						return new StatusCodeResult(200);
					}
					await AponusDbContext.Database.ExecuteSqlRawAsync(insert, new NpgsqlParameter("@DESCRIPCION", estado.Descripcion)
					{
						NpgsqlDbType = NpgsqlDbType.Varchar
					});
					return new StatusCodeResult(200);
				}
				catch (Exception ex2)
				{
					Exception ex = ex2;
					return new JsonResult(ex.Message);
				}
			}
		}

		private readonly BS_Stocks BsStocks;

		private readonly AD_Stocks _stocks;

		private readonly AponusContext AponusDbContext;

		private readonly AD_Movimientos _movimientosStock;

		private readonly UTL_Suministros _suministros;

		private readonly AD_Suministros _obtenerInsumos;

		private readonly BS_Entidades BsEntidades;

		public BS_Movimientos(BS_Stocks bsStocks, AponusContext aponusDbContext, AD_Stocks stocks, AD_Movimientos movimientosStock, UTL_Suministros suministros, AD_Suministros obtenerInsumos, BS_Entidades bsEntidades)
		{
			BsStocks = bsStocks;
			_stocks = stocks;
			AponusDbContext = aponusDbContext;
			_movimientosStock = movimientosStock;
			_suministros = suministros;
			_obtenerInsumos = obtenerInsumos;
			BsEntidades = bsEntidades;
		}

		internal IActionResult ProcesarDatosMovimiento(DTOMovimientosStock DTOMovimiento)
		{
			try
			{
				List<StockInsumos> list = new List<StockInsumos>();
				IEnumerable<DTOSuministrosMovimientosStock> suministros = DTOMovimiento.Suministros;
				foreach (DTOSuministrosMovimientosStock item in suministros ?? Enumerable.Empty<DTOSuministrosMovimientosStock>())
				{
					StockInsumos stockInsumos = _stocks.BuscarInsumo(item.IdSuministro);
					if (stockInsumos != null)
					{
						list.Add(stockInsumos);
					}
				}
				if (DTOMovimiento.Suministros?.Count == list.Count)
				{
					return BsStocks.ProcesarDatosMovimiento(DTOMovimiento);
				}
				return new ContentResult
				{
					Content = "No se encontraron uno o mas Suministros\n No se realizaron modificaciones",
					ContentType = "application/json",
					StatusCode = 400
				};
			}
			catch (Exception ex)
			{
				return new ContentResult
				{
					Content = (ex.InnerException?.Message ?? ex.Message),
					ContentType = "application/json",
					StatusCode = 400
				};
			}
		}

		internal IActionResult Actualizar(DTOMovimientosStock ActualizacionMovimiento)
		{
			try
			{
				_movimientosStock.Actualizar(ActualizacionMovimiento);
				return new StatusCodeResult(200);
			}
			catch (Exception)
			{
				return new ContentResult
				{
					Content = "Error interno, no se aplicaron los cambios",
					ContentType = "application/json",
					StatusCode = 400
				};
			}
		}

		internal async Task<IActionResult> Listar(UTL_FiltrosMovimientos? Filtros)
		{
			List<DTOMovimientosStock> ListaMovimientos = await _movimientosStock.Listar(Filtros);
			List<string> SuministrosId = ListaMovimientos.SelectMany(delegate(DTOMovimientosStock x)
			{
				IEnumerable<string> result;
				if (x.Suministros == null)
				{
					IEnumerable<string> enumerable = Enumerable.Empty<string>();
					result = enumerable;
				}
				else
				{
					result = x.Suministros.Select((DTOSuministrosMovimientosStock s) => s.IdSuministro);
				}
				return result;
			}).ToList();
			List<(string IdSuministro, string NombreFormateado, string? Unidad)> SuministrosFormateados = _obtenerInsumos.ObtenerDetalles(SuministrosId);
			foreach (DTOMovimientosStock movimiento in ListaMovimientos)
			{
				string FechaHora = (movimiento.FechaHoraCreado.HasValue ? movimiento.FechaHoraCreado.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty);
				movimiento.FechaHoraCreado = Convert.ToDateTime(FechaHora);
				IEnumerable<DTOSuministrosMovimientosStock> suministros = movimiento.Suministros;
				foreach (DTOSuministrosMovimientosStock suministro in suministros ?? Enumerable.Empty<DTOSuministrosMovimientosStock>())
				{
					(string IdSuministro, string NombreFormateado, string? Unidad) SumFormat = SuministrosFormateados.FirstOrDefault<(string, string, string)>(((string IdSuministro, string NombreFormateado, string Unidad) x) => x.IdSuministro == suministro.IdSuministro);
					suministro.NombreSuministro = SumFormat.NombreFormateado;
					suministro.Cantidad = suministro.Cantidad + " " + SumFormat.Unidad;
				}
			}
			List<int?> MovimientosIds = ListaMovimientos.Select((DTOMovimientosStock m) => m.IdMovimiento).Distinct().ToList();
			UTL_Cloudinary cloudinary = new UTL_Cloudinary();
			List<DTODatosArchivosMovimientosStock> InfoArchivosMovimientos = await _movimientosStock.InfoArchivos(MovimientosIds);
			foreach (DTODatosArchivosMovimientosStock item in InfoArchivosMovimientos ?? Enumerable.Empty<DTODatosArchivosMovimientosStock>())
			{
				var (archivo, error) = await cloudinary.DescargarArchivo(item?.Path ?? "");
				if (item != null)
				{
					item.DatosArchivo = archivo;
					item.MensajeError = error;
				}
			}
			foreach (DTOMovimientosStock Movimiento in ListaMovimientos)
			{
				Movimiento.DatosArchivos = InfoArchivosMovimientos?.Where((DTODatosArchivosMovimientosStock x) => x.IdMovimiento == Movimiento.IdMovimiento).ToList();
			}
			return new JsonResult(ListaMovimientos);
		}

		internal IActionResult ActualizarSuministros(DTOMovimientosStock Movimiento)
		{
			DTOMovimientosStock Movimiento2 = Movimiento;
			bool flag = false;
			IEnumerable<DTOSuministrosMovimientosStock> suministros = Movimiento2.Suministros;
			foreach (DTOSuministrosMovimientosStock item in suministros ?? Enumerable.Empty<DTOSuministrosMovimientosStock>())
			{
				item.IdMovimiento = Movimiento2.IdMovimiento;
			}
			List<SuministrosMovimientosStock> list = _suministros.MapeoSuministrosDB(Movimiento2.Suministros, Movimiento2.Origen, Movimiento2.Destino);
			list?.ForEach(delegate(SuministrosMovimientosStock x)
			{
				x.IdMovimiento = Movimiento2.IdMovimiento.GetValueOrDefault(-1);
			});
			using IDbContextTransaction dbContextTransaction = AponusDbContext.Database.BeginTransaction();
			if (list != null && _stocks.GuardarSuministrosMovimiento(AponusDbContext, list))
			{
				flag = true;
			}
			if (!_movimientosStock.RegistrarModificacion(AponusDbContext, Movimiento2))
			{
				flag = true;
			}
			if (flag)
			{
				dbContextTransaction.Rollback();
				return new ContentResult
				{
					Content = "Error interno, no se aplicaron los cambios",
					ContentType = "application/json",
					StatusCode = 400
				};
			}
			AponusDbContext.Database.CommitTransaction();
			AponusDbContext.SaveChanges();
			return new StatusCodeResult(200);
		}

		internal IActionResult Eliminar(int IdMovimiento)
		{
			bool flag = false;
			using IDbContextTransaction dbContextTransaction = AponusDbContext.Database.BeginTransaction();
			if (!_movimientosStock.Eliminar(AponusDbContext, IdMovimiento))
			{
				flag = true;
			}
			if (flag)
			{
				dbContextTransaction.Rollback();
				return new ContentResult
				{
					Content = "Error interno, no se aplicaron los cambios",
					ContentType = "application/json",
					StatusCode = 400
				};
			}
			dbContextTransaction.Commit();
			AponusDbContext.SaveChanges();
			return new StatusCodeResult(200);
		}

		public Archivos ArchivosMovimientos()
		{
			return new Archivos(AponusDbContext, _stocks, _movimientosStock, BsEntidades);
		}

		public Estados EstadosMovimientos()
		{
			return new Estados(AponusDbContext);
		}
	}
	public class BS_Productos
	{
		private readonly AD_Componentes _componentesProductos;

		private readonly AD_Productos AdProductos;

		public BS_Productos(AD_Componentes componentesProductos, AD_Productos adProductos)
		{
			_componentesProductos = componentesProductos;
			AdProductos = adProductos;
		}

		internal async Task<JsonResult> ListarDN(string? typeId)
		{
			return await AdProductos.ListarDN(typeId ?? "");
		}

		internal async Task<JsonResult> ListarDN(string? typeId, int? idDescription)
		{
			return await AdProductos.ListarDN(typeId, idDescription);
		}

		internal JsonResult NewListarComponentesProducto(DTOProducto Producto)
		{
			int? cantidad = Producto.Cantidad;
			int valueOrDefault = cantidad.GetValueOrDefault();
			if (!cantidad.HasValue)
			{
				valueOrDefault = 1;
				int? cantidad2 = valueOrDefault;
				Producto.Cantidad = cantidad2;
			}
			return _componentesProductos.ObtenerComponentesFormateados(Producto);
		}

		internal JsonResult ListarProductos(string? TypeId)
		{
			return AdProductos.Listar(TypeId ?? "");
		}

		internal JsonResult ListarProductos()
		{
			return AdProductos.Listar();
		}

		internal JsonResult ListarProductos(string? typeId, int? IdDescription)
		{
			return AdProductos.Listar(typeId, IdDescription);
		}

		internal JsonResult ListarProductos(string? typeId, int? IdDescription, int? Dn)
		{
			return AdProductos.Listar(typeId, IdDescription, Dn);
		}

		internal IActionResult ProcesarDatos(DTOProducto Producto)
		{
			if (Producto.IdProducto == null)
			{
				if (Producto.IdTipo != null && Producto.IdDescripcion.HasValue && Producto.DiametroNominal.HasValue && Producto.Tolerancia != null)
				{
					Producto.IdProducto = AdProductos.GenerarIdProd(Producto);
					Producto producto = AdProductos.BuscarProducto(Producto.IdProducto);
					if (producto == null)
					{
						AdProductos.GuardarProducto(Producto);
					}
					else
					{
						ProductUpdate(Producto);
					}
					if (Producto.Componentes != null)
					{
						foreach (DTOComponentesProducto componente in Producto.Componentes)
						{
							componente.IdProducto = Producto.IdProducto;
						}
						ActualizarComponentes(Producto.Componentes);
					}
					return new JsonResult(Producto.IdProducto);
				}
				return new ContentResult
				{
					Content = "Faltan Datos",
					ContentType = "application/json",
					StatusCode = 400
				};
			}
			return ProductUpdate(Producto);
		}

		internal IActionResult ProductUpdate(DTOProducto ActualizarProducto)
		{
			DTOProducto ActualizarProducto2 = ActualizarProducto;
			bool flag = false;
			try
			{
				Producto producto = AdProductos.BuscarProducto(ActualizarProducto2.IdProducto ?? "");
				PropertyInfo[] array = (from prop in ActualizarProducto2.GetType().GetProperties()
					where prop.GetValue(ActualizarProducto2) != null
					select prop).ToArray();
				if (producto != null)
				{
					producto.IdEstado = 1;
					PropertyInfo[] array2 = array;
					foreach (PropertyInfo propertyInfo in array2)
					{
						PropertyInfo property = producto.GetType().GetProperty(propertyInfo.Name);
						if (!(property != null))
						{
							continue;
						}
						object value = property.GetValue(producto);
						object value2 = propertyInfo.GetValue(ActualizarProducto2);
						if (value == null || value.Equals(value2) || !(propertyInfo.Name != "idProducto"))
						{
							continue;
						}
						property.SetValue(producto, value2);
						if (propertyInfo.Name.Contains("IdDescripcion") || propertyInfo.Name.Contains("Tolerancia") || propertyInfo.Name.Contains("IdTipo"))
						{
							if (value2 == null)
							{
								return new ContentResult
								{
									Content = "Faltan Datos, No se realizaron modificaciones",
									ContentType = "application/json",
									StatusCode = 400
								};
							}
							flag = true;
						}
					}
					Producto producto2 = producto;
					if (flag)
					{
						string text = ActualizarProducto2.IdProducto ?? "";
						string text2 = AdProductos.GenerarIdProd(new DTOProducto
						{
							IdProducto = null,
							DiametroNominal = producto2.DiametroNominal,
							IdDescripcion = producto2.IdDescripcion,
							IdTipo = producto2.IdTipo,
							Tolerancia = producto2.Tolerancia
						});
						if (text != text2)
						{
							if (AdProductos.BuscarProducto(text2) != null)
							{
								return new ContentResult
								{
									Content = "Producto existente, no se aplicaron los cambios",
									ContentType = "application/json",
									StatusCode = 400
								};
							}
							AdProductos.ModifyProductDetails(producto2);
							AdProductos.ActualizarIdProd(text, text2);
							return new JsonResult(text2);
						}
					}
					else if (producto2 != null)
					{
						AdProductos.ModifyProductDetails(producto2);
					}
					return new JsonResult(producto2?.IdProducto ?? null);
				}
				return new ContentResult
				{
					Content = "No se encontró el Producto a Modificar",
					ContentType = "application/json",
					StatusCode = 404
				};
			}
			catch (Exception)
			{
				return new ContentResult
				{
					Content = "Producto existente, no se aplicaron los cambios",
					ContentType = "application/json",
					StatusCode = 400
				};
			}
		}

		internal IActionResult ActualizarComponentes(List<DTOComponentesProducto> Componentes)
		{
			List<Productos_Componentes> list = new List<Productos_Componentes>();
			try
			{
				if (Componentes != null)
				{
					string idProducto = (from x in Componentes
						where x.IdProducto != null
						select x.IdProducto).FirstOrDefault() ?? "";
					AdProductos.DeleteAllProductComponents(idProducto);
				}
				foreach (DTOComponentesProducto item in Componentes ?? Enumerable.Empty<DTOComponentesProducto>())
				{
					list.Add(new Productos_Componentes
					{
						Cantidad = item.Cantidad,
						IdComponente = (item.IdComponente ?? ""),
						IdProducto = (item.IdProducto ?? ""),
						Longitud = item.Largo,
						Peso = item.Peso
					});
				}
				foreach (Productos_Componentes item2 in list)
				{
					_componentesProductos.GuardarComponenteProd(item2);
				}
				return new StatusCodeResult(200);
			}
			catch (DbUpdateException ex)
			{
				if (ex.InnerException?.Message != null)
				{
					return new ContentResult
					{
						Content = ex.InnerException.Message,
						ContentType = "application/json"
					};
				}
				return new ContentResult
				{
					Content = ex.Message,
					ContentType = "application/json"
				};
			}
			catch (Exception ex2)
			{
				if (ex2.InnerException?.Message != null)
				{
					return new ContentResult
					{
						Content = ex2.InnerException.Message,
						ContentType = "application/json"
					};
				}
				return new ContentResult
				{
					Content = ex2.Message,
					ContentType = "application/json"
				};
			}
		}
	}
	public class BS_Stocks
	{
		public class StockProductos
		{
			private readonly AD_Componentes _componentesProductos;

			private readonly AponusContext AponusDbContext;

			private readonly AD_Stocks AdStocks;

			public StockProductos(AD_Componentes componentesProductos, AponusContext _aponusDbContext, AD_Stocks _adStocks)
			{
				_componentesProductos = componentesProductos;
				AponusDbContext = _aponusDbContext;
				AdStocks = _adStocks;
			}

			internal async Task<IActionResult> Actualizar(DTOStockProductos DTOStockProducto)
			{
				try
				{
					Producto StockProductoDB = new Producto();
					PropertyInfo[] PropsDTOStockProducto = DTOStockProducto.GetType().GetProperties();
					PropertyInfo[] PropsObjStockInsumosDB = StockProductoDB.GetType().GetProperties();
					PropertyInfo[] array = PropsDTOStockProducto;
					foreach (PropertyInfo PropDTO in array)
					{
						PropertyInfo[] array2 = PropsObjStockInsumosDB;
						foreach (PropertyInfo PropObjDB in array2)
						{
							if (PropObjDB.Name.ToLower().Contains(PropDTO.Name.ToLower()) && PropDTO.GetValue(DTOStockProducto) != null)
							{
								PropObjDB.SetValue(StockProductoDB, PropDTO.GetValue(DTOStockProducto));
							}
						}
					}
					if (await AdStocks.StockProductos().Actualizar(StockProductoDB))
					{
						return new StatusCodeResult(200);
					}
					return new ContentResult
					{
						Content = "No se aplicaron los cambios",
						ContentType = "application/json",
						StatusCode = 400
					};
				}
				catch (Exception ex2)
				{
					Exception ex = ex2;
					return new ContentResult
					{
						Content = (ex.InnerException?.Message ?? ex.Message),
						ContentType = "application/json",
						StatusCode = 400
					};
				}
			}

			internal async Task<IActionResult> Incrementar(DTOProducto Producto)
			{
				List<Productos_Componentes> list = (string.IsNullOrEmpty(Producto.IdProducto) ? null : (await _componentesProductos.ObtenerComponentes(Producto.IdProducto)));
				List<Productos_Componentes> Componentes = list;
				List<ComponentesDescripcion> ComponentesDetalle = _componentesProductos.ListarNombresComponentes();
				List<(string id, int IdDesc, decimal? Longitud, decimal? Peso)> ListaDetallesComponentes = _componentesProductos.ListarIdDescripcionComponentesProducto(Componentes?.Select((Productos_Componentes x) => x.IdComponente).ToArray() ?? Array.Empty<string>());
				List<Aponus_Web_API.Modelos.StockInsumos> StockComponentes = new List<Aponus_Web_API.Modelos.StockInsumos>();
				if (Componentes != null)
				{
					foreach (Productos_Componentes Componente in Componentes)
					{
						Productos_Componentes productos_Componentes = Componente;
						decimal? cantidad2;
						if (Componente.Cantidad.HasValue)
						{
							decimal value = Producto.Cantidad.GetValueOrDefault();
							decimal? cantidad = Componente.Cantidad;
							cantidad2 = (decimal?)value * cantidad;
						}
						else
						{
							cantidad2 = null;
						}
						productos_Componentes.Cantidad = cantidad2;
						Productos_Componentes productos_Componentes2 = Componente;
						decimal? longitud;
						if (Componente.Longitud.HasValue)
						{
							decimal value = Producto.Cantidad.GetValueOrDefault();
							decimal? cantidad = Componente.Longitud;
							longitud = (decimal?)value * cantidad;
						}
						else
						{
							longitud = null;
						}
						productos_Componentes2.Longitud = longitud;
						Productos_Componentes productos_Componentes3 = Componente;
						decimal? peso;
						if (Componente.Peso.HasValue)
						{
							decimal value = Producto.Cantidad.GetValueOrDefault();
							decimal? cantidad = Componente.Peso;
							peso = (decimal?)value * cantidad;
						}
						else
						{
							peso = null;
						}
						productos_Componentes3.Peso = peso;
						Aponus_Web_API.Modelos.StockInsumos StockDisponibleComponente = AdStocks.BuscarInsumo(Componente.IdComponente) ?? new Aponus_Web_API.Modelos.StockInsumos();
						int IdDescripcionComponente = (from x in ListaDetallesComponentes
							where x.id.Equals(Componente.IdComponente)
							select x.IdDesc).First();
						string TipoAlmacenamiento = (from x in ComponentesDetalle?.Where((ComponentesDescripcion x) => x.IdDescripcion == IdDescripcionComponente)
							select x.IdAlmacenamiento).First() ?? "";
						string TipoFraccionamiento = (from x in ComponentesDetalle?.Where((ComponentesDescripcion x) => x.IdDescripcion == IdDescripcionComponente)
							select x.IdFraccionamiento).First();
						if (TipoFraccionamiento != null && TipoAlmacenamiento != TipoFraccionamiento)
						{
							if (TipoFraccionamiento.Equals("UD") && TipoAlmacenamiento.Equals("KG"))
							{
								decimal PesoUnidadComponente = (from x in ListaDetallesComponentes
									where x.Equals(Componente.IdComponente)
									select x.Peso).First().GetValueOrDefault();
								decimal value = PesoUnidadComponente;
								decimal? cantidad = Componente.Cantidad;
								decimal PesoTotalUnProducto = ((decimal?)value * cantidad).GetValueOrDefault(1m);
								value = PesoTotalUnProducto;
								cantidad = Componente.Cantidad;
								decimal PesoRequerido = ((decimal?)value * cantidad).GetValueOrDefault(1m);
								decimal PesoDisponible = StockDisponibleComponente.Proceso.GetValueOrDefault();
								decimal PesoRestante = PesoDisponible - PesoRequerido;
								StockComponentes.Add(new Aponus_Web_API.Modelos.StockInsumos
								{
									IdInsumo = Componente.IdComponente,
									Proceso = PesoRestante
								});
							}
							else if (TipoFraccionamiento.Equals("CM") && TipoAlmacenamiento.Equals("UD"))
							{
								decimal? LargoTotalInsumo = (from x in ListaDetallesComponentes
									where x.id.Equals(Componente.IdComponente)
									select x.Longitud).First();
								decimal CantidadStock = StockDisponibleComponente.Proceso.GetValueOrDefault();
								decimal? LongitudTotalCmDisponible = LargoTotalInsumo.GetValueOrDefault() * CantidadStock;
								decimal LongitudNecesaria = Componente.Longitud ?? ((decimal)(Producto.Cantidad.HasValue ? new int?(0) : null).GetValueOrDefault(1));
								decimal LongitudRestanteCm = LongitudTotalCmDisponible ?? (0m - LongitudNecesaria);
								decimal value = LongitudRestanteCm;
								decimal? cantidad = LargoTotalInsumo;
								int CantidadRestante = (int)Math.Floor(((decimal?)value / cantidad).GetValueOrDefault(1m));
								StockComponentes.Add(new Aponus_Web_API.Modelos.StockInsumos
								{
									IdInsumo = Componente.IdComponente,
									Proceso = CantidadRestante
								});
							}
						}
						else if (TipoFraccionamiento?.Equals(TipoAlmacenamiento) ?? true)
						{
							TipoFraccionamiento = TipoAlmacenamiento;
							if (TipoFraccionamiento.Equals("UD"))
							{
								decimal UnidadesUnProducto = Componente.Cantidad.GetValueOrDefault(1m);
								decimal value = UnidadesUnProducto;
								decimal? num = Producto.Cantidad;
								decimal unidadesNecesarias = ((decimal?)value * num).GetValueOrDefault(1m);
								decimal UnidadesStock = StockDisponibleComponente.Proceso.GetValueOrDefault();
								decimal UnidadesRestantess = UnidadesStock - unidadesNecesarias;
								StockComponentes.Add(new Aponus_Web_API.Modelos.StockInsumos
								{
									IdInsumo = Componente.IdComponente,
									Proceso = UnidadesRestantess
								});
							}
							else if (TipoFraccionamiento.Equals("KG"))
							{
								decimal PesoUnProducto = Componente.Peso.GetValueOrDefault(1m);
								decimal value = PesoUnProducto;
								decimal? num2 = Producto.Cantidad;
								decimal PesoNecesario = ((decimal?)value * num2).GetValueOrDefault(1m);
								decimal PesoStock = StockDisponibleComponente.Proceso.GetValueOrDefault();
								decimal PesoRestante2 = PesoStock - PesoNecesario;
								StockComponentes.Add(new Aponus_Web_API.Modelos.StockInsumos
								{
									IdInsumo = Componente.IdComponente,
									Proceso = PesoRestante2
								});
							}
							else if (TipoFraccionamiento.Equals("CM"))
							{
								decimal? LargoTotalInsumo2 = (from x in ListaDetallesComponentes
									where x.id.Equals(Componente.IdComponente)
									select x.Longitud).First();
								decimal CantidadStock2 = StockDisponibleComponente.Proceso.GetValueOrDefault();
								decimal? LongitudTotalCmDisponible2 = LargoTotalInsumo2.GetValueOrDefault() * CantidadStock2;
								decimal LongitudNecesaria2 = Componente.Longitud ?? ((decimal)(Producto.Cantidad.HasValue ? new int?(0) : null).GetValueOrDefault(1));
								decimal LongitudRestanteCm2 = LongitudTotalCmDisponible2 ?? (0m - LongitudNecesaria2);
								decimal value = LongitudRestanteCm2;
								decimal? cantidad = LargoTotalInsumo2;
								int CantidadRestante2 = (int)Math.Floor(((decimal?)value / cantidad).GetValueOrDefault(1m));
								StockComponentes.Add(new Aponus_Web_API.Modelos.StockInsumos
								{
									IdInsumo = Componente.IdComponente,
									Proceso = CantidadRestante2
								});
							}
						}
						using IDbContextTransaction transaccion = AponusDbContext.Database.BeginTransaction();
						try
						{
							foreach (Aponus_Web_API.Modelos.StockInsumos item in StockComponentes)
							{
								if (!AdStocks.ActualizarStockInsumo(AponusDbContext, new DTOStockUpdate
								{
									Id = item.IdInsumo,
									Cantidad = item.Proceso
								}))
								{
									transaccion.Rollback();
									return new ContentResult
									{
										Content = "No se aplicaron los  cambios",
										ContentType = "application/json",
										StatusCode = 400
									};
								}
							}
							transaccion.Commit();
						}
						catch (Exception ex2)
						{
							Exception ex = ex2;
							transaccion.Rollback();
							return new ContentResult
							{
								Content = "Error: " + (ex.InnerException?.Message ?? ex.Message),
								ContentType = "application/json",
								StatusCode = 400
							};
						}
					}
					return new StatusCodeResult(200);
				}
				return new ContentResult
				{
					Content = "Error interno, no se encontraron los componentes. No se aplicaron los cambios",
					ContentType = "application/json",
					StatusCode = 400
				};
			}
		}

		public class StockInsumos
		{
			private readonly AD_Stocks AdStocks;

			public StockInsumos(AD_Stocks adStocks)
			{
				AdStocks = adStocks;
			}

			internal async Task<IActionResult> Actualizar(DTOStock DtoStockInsumo)
			{
				try
				{
					Aponus_Web_API.Modelos.StockInsumos ObjStockInsumosDB = new Aponus_Web_API.Modelos.StockInsumos();
					PropertyInfo[] PropsDTOStockInsumo = DtoStockInsumo.GetType().GetProperties();
					PropertyInfo[] PropsObjStockInsumosDB = ObjStockInsumosDB.GetType().GetProperties();
					PropertyInfo[] array = PropsDTOStockInsumo;
					foreach (PropertyInfo PropDTO in array)
					{
						PropertyInfo[] array2 = PropsObjStockInsumosDB;
						foreach (PropertyInfo PropObjDB in array2)
						{
							if (PropObjDB.Name.ToLower().Contains(PropDTO.Name.ToLower()) && PropDTO.GetValue(DtoStockInsumo) != null)
							{
								PropObjDB.SetValue(ObjStockInsumosDB, PropDTO.GetValue(DtoStockInsumo));
							}
						}
					}
					if (await AdStocks.StockInsumos().Actualizar(ObjStockInsumosDB))
					{
						return new StatusCodeResult(200);
					}
					return new ContentResult
					{
						Content = "No se aplicaron los cambios",
						ContentType = "application/json",
						StatusCode = 400
					};
				}
				catch (Exception ex2)
				{
					Exception ex = ex2;
					return new ContentResult
					{
						Content = (ex.InnerException?.Message ?? ex.Message),
						ContentType = "application/json",
						StatusCode = 400
					};
				}
			}
		}

		private readonly AponusContext AponusDbContext;

		private readonly AD_Componentes _ComponentesProductos;

		private readonly AD_Stocks AdStocks;

		private readonly BS_Entidades BsEntidades;

		public BS_Stocks(AponusContext _aponusContext, AD_Stocks adStocks, AD_Componentes componentesProductos, BS_Entidades bsEntidades)
		{
			AponusDbContext = _aponusContext;
			AdStocks = adStocks;
			_ComponentesProductos = componentesProductos;
			BsEntidades = bsEntidades;
		}

		public StockInsumos OperacionesStockInsumos()
		{
			return new StockInsumos(AdStocks);
		}

		public StockProductos OperacionesStockProductos()
		{
			return new StockProductos(_ComponentesProductos, AponusDbContext, AdStocks);
		}

		internal JsonResult ListarProductos(string typeId, int idDescription)
		{
			string typeId2 = typeId;
			List<DTOTiposProductos> list = AdStocks.ListarProductos();
			if (typeId2.Equals("0") && idDescription != 0)
			{
				List<DTOTiposProductos> list2 = list.Where((DTOTiposProductos x) => x.IdTipo == typeId2 && x.DescripcionProductos.Any((DTODescripcionesProductos d) => d.IdDescripcion == idDescription)).ToList();
				list2.ForEach(delegate(DTOTiposProductos tpd)
				{
					tpd.DescripcionProductos.ForEach(delegate(DTODescripcionesProductos dpp)
					{
						dpp.Columnas = new UTL_Productos().ObtenerColumnas(dpp.Productos, null);
					});
				});
				return new JsonResult(list2);
			}
			if (!typeId2.Equals("0"))
			{
				List<DTOTiposProductos> list3 = list.Where((DTOTiposProductos x) => x.IdTipo == typeId2).ToList();
				list3.ForEach(delegate(DTOTiposProductos tpd)
				{
					tpd.DescripcionProductos.ForEach(delegate(DTODescripcionesProductos dpp)
					{
						dpp.Columnas = new UTL_Productos().ObtenerColumnas(dpp.Productos, null);
					});
				});
				return new JsonResult(list3);
			}
			if (idDescription != 0)
			{
				List<DTOTiposProductos> list4 = list.Where((DTOTiposProductos x) => x.DescripcionProductos.Any((DTODescripcionesProductos x) => x.IdDescripcion == idDescription)).ToList();
				list4.ForEach(delegate(DTOTiposProductos tpd)
				{
					tpd.DescripcionProductos.ForEach(delegate(DTODescripcionesProductos dpp)
					{
						dpp.Columnas = new UTL_Productos().ObtenerColumnas(dpp.Productos, null);
					});
				});
				return new JsonResult(list4);
			}
			list.ForEach(delegate(DTOTiposProductos tpd)
			{
				tpd.DescripcionProductos.ForEach(delegate(DTODescripcionesProductos dpp)
				{
					dpp.Columnas = new UTL_Productos().ObtenerColumnas(dpp.Productos, null);
				});
			});
			return new JsonResult(list);
		}

		internal IActionResult ObtenerDatosInsumos(int? IdDescripcion)
		{
			return AdStocks.ListarInsumosProducto(IdDescripcion);
		}

		internal IActionResult ProcesarDatosMovimiento(DTOMovimientosStock Movimiento)
		{
			DTOMovimientosStock Movimiento2 = Movimiento;
			bool flag = false;
			using IDbContextTransaction dbContextTransaction = AponusDbContext.Database.BeginTransaction();
			IEnumerable<DTOSuministrosMovimientosStock> suministros = Movimiento2.Suministros;
			foreach (DTOSuministrosMovimientosStock item in suministros ?? Enumerable.Empty<DTOSuministrosMovimientosStock>())
			{
				if (!AdStocks.ActualizarStockInsumo(AponusDbContext, new DTOStockUpdate
				{
					Id = item.IdSuministro,
					Origen = Movimiento2.Origen,
					Destino = Movimiento2.Destino,
					Cantidad = Convert.ToDecimal(item.Cantidad)
				}))
				{
					flag = true;
				}
			}
			int? IdMovimiento = AdStocks.GuardarDatosMovimiento(AponusDbContext, new Stock_Movimientos
			{
				CreadoUsuario = (Movimiento2.UsuarioCreacion ?? "ERROR"),
				ModificadoUsuario = Movimiento2.UsuarioModificacion,
				FechaHoraCreado = UTL_Fechas.ObtenerFechaHora(),
				IdProveedor = Movimiento2.IdProveedorDestino.GetValueOrDefault(),
				Tipo = Movimiento2.Tipo,
				Destino = ((!string.IsNullOrEmpty(Movimiento2.Destino)) ? Movimiento2.Destino.ToUpper() : ""),
				Origen = ((!string.IsNullOrEmpty(Movimiento2.Origen)) ? Movimiento2.Origen.ToUpper() : "")
			});
			if (!IdMovimiento.HasValue)
			{
				flag = true;
			}
			suministros = Movimiento2.Suministros;
			List<SuministrosMovimientosStock> suministros2 = (suministros ?? Enumerable.Empty<DTOSuministrosMovimientosStock>()).Select((DTOSuministrosMovimientosStock x) => new SuministrosMovimientosStock
			{
				IdMovimiento = IdMovimiento.GetValueOrDefault(),
				Cantidad = Convert.ToDecimal(x.Cantidad),
				IdSuministro = x.IdSuministro
			}).ToList();
			if (!AdStocks.GuardarSuministrosMovimiento(AponusDbContext, suministros2))
			{
				flag = true;
			}
			IActionResult actionResult = BsEntidades.MapeoEntidadesDTO(Movimiento2.IdProveedorDestino.GetValueOrDefault(), 0, 0);
			DTOEntidades dTOEntidades = new DTOEntidades();
			if (actionResult is JsonResult { Value: not null, Value: IEnumerable<DTOEntidades> value })
			{
				dTOEntidades = value.FirstOrDefault((DTOEntidades x) => x.IdEntidad == Movimiento2.IdProveedorDestino);
			}
			string text = dTOEntidades?.Apellido + "_" + dTOEntidades?.Nombre;
			string text2 = dTOEntidades?.NombreClave;
			if (Movimiento2.Archivos != null && Movimiento2.Archivos.Count > 0)
			{
				List<ArchivosMovimientosStock> list = new UTL_Cloudinary().SubirArchivosMovimiento(Movimiento2.Archivos, string.IsNullOrEmpty(text2) ? text : text2);
				if (list.Count == 0)
				{
					flag = true;
				}
				Movimiento2.IdMovimiento = IdMovimiento;
				list.ForEach(delegate(ArchivosMovimientosStock x)
				{
					x.IdMovimiento = IdMovimiento.GetValueOrDefault();
				});
				if (!AdStocks.GuardarDatosArchivosMovimiento(AponusDbContext, list))
				{
					flag = true;
				}
			}
			if (flag)
			{
				dbContextTransaction.Rollback();
				return new ContentResult
				{
					Content = "Error interno, no se aplicaron los cambios",
					ContentType = "Aplication/Json",
					StatusCode = 500
				};
			}
			AponusDbContext.Database.CommitTransaction();
			AponusDbContext.SaveChanges();
			AponusDbContext.Dispose();
			return new StatusCodeResult(200);
		}
	}
	public class BS_Suministros
	{
		private readonly AD_Componentes Componentes;

		private readonly AD_Stocks stocks;

		public BS_Suministros(AD_Componentes componentes, AD_Stocks _stocks)
		{
			Componentes = componentes;
			stocks = _stocks;
		}

		internal JsonResult ObtenerNuevoIdComponente(string ComponentDescription)
		{
			return Componentes.ObtenerNuevoId(ComponentDescription);
		}

		internal IActionResult GuardarInsumoProducto(DTODetallesComponenteProducto componente)
		{
			try
			{
				if (componente.idComponente != null && componente.IdDescripcion.HasValue)
				{
					Componentes.GuardarComponente(new ComponentesDetalle
					{
						IdInsumo = componente.idComponente,
						Diametro = componente.Diametro,
						Altura = componente.Altura,
						IdDescripcion = componente.IdDescripcion.Value,
						DiametroNominal = componente.DiametroNominal,
						Espesor = componente.Espesor,
						IdAlmacenamiento = componente.idAlmacenamiento,
						IdFraccionamiento = componente.idFraccionamiento,
						Longitud = componente.Longitud,
						Perfil = componente.Perfil,
						Peso = componente.Peso,
						Tolerancia = componente.Tolerancia
					});
					return new StatusCodeResult(200);
				}
				return new ContentResult
				{
					Content = "El Codigo de Insumo y la Descripcion no pueden ser nulos",
					ContentType = "text/plan",
					StatusCode = 400
				};
			}
			catch (DbUpdateException ex)
			{
				string content = ((ex.InnerException?.Message == null) ? ex.Message : ex.InnerException.Message);
				return new ContentResult
				{
					Content = content,
					ContentType = "text/plan",
					StatusCode = 500
				};
			}
		}

		internal IActionResult ListarNombresFormateados()
		{
			List<DTOTipoInsumos> list = new List<DTOTipoInsumos>();
			List<UTL_FormatoSuministros> list2 = new List<UTL_FormatoSuministros>();
			IActionResult actionResult = stocks.ListarInsumosProducto();
			if (actionResult is JsonResult jsonResult)
			{
				list = jsonResult.Value as List<DTOTipoInsumos>;
			}
			IEnumerable<DTOTipoInsumos> enumerable = list;
			foreach (DTOTipoInsumos item in enumerable ?? Enumerable.Empty<DTOTipoInsumos>())
			{
				IEnumerable<DTOComponenteFormateado> especificacionesFormato = item.especificacionesFormato;
				foreach (DTOComponenteFormateado item2 in especificacionesFormato ?? Enumerable.Empty<DTOComponenteFormateado>())
				{
					UTL_FormatoSuministros obj = new UTL_FormatoSuministros
					{
						IdSuministro = (item2.idComponente ?? string.Empty),
						Descripcion = item.Descripcion,
						Altura = ((!string.IsNullOrEmpty(item2.Altura) && !item2.Altura.Contains('-')) ? new decimal?(Convert.ToDecimal(item2.Altura.Replace("mm", ""))) : null),
						Diametro = ((!string.IsNullOrEmpty(item2.Altura) && !item2.Altura.Contains('-')) ? new decimal?(Convert.ToDecimal(item2.Altura.Replace("mm", ""))) : null),
						DiametroNominal = ((!string.IsNullOrEmpty(item2.DiametroNominal) && !item2.DiametroNominal.Contains('-')) ? new int?(Convert.ToInt32(item2.DiametroNominal.Replace("mm", ""))) : null),
						Espesor = ((!string.IsNullOrEmpty(item2.Espesor) && !item2.Espesor.Contains('-')) ? new decimal?(Convert.ToDecimal(item2.Espesor.Replace("mm", ""))) : null),
						Longitud = ((!string.IsNullOrEmpty(item2.Longitud) && !item2.Longitud.Contains('-')) ? new decimal?(Convert.ToDecimal(item2.Longitud.Replace("mm", ""))) : null),
						Perfil = ((!string.IsNullOrEmpty(item2.Perfil) && !item2.Perfil.Contains('-')) ? new int?(Convert.ToInt32(item2.Perfil)) : null)
					};
					string? tolerancia = item2.Tolerancia;
					obj.Tolerancia = ((tolerancia != null && tolerancia.Equals('-')) ? "" : item2.Tolerancia);
					obj.UnidadAlmacenamiento = ((!string.IsNullOrEmpty(item2.idAlmacenamiento)) ? item2.idAlmacenamiento : null);
					obj.UnidadFraccionamiento = ((!string.IsNullOrEmpty(item2.idFraccionamiento)) ? item2.idFraccionamiento : null);
					list2.Add(obj);
				}
			}
			List<(string, string, string)> source = new UTL_NombresSuministros().formatearNombres(list2);
			source = source.OrderBy<(string, string, string), string>(((string IdSuministro, string Nombre, string Unidad) x) => x.Nombre).ToList();
			List<Dictionary<string, string>> value = source.Select<(string, string, string), Dictionary<string, string>>(((string IdSuministro, string Nombre, string Unidad) item) => new Dictionary<string, string>
			{
				{ "idInsumo", item.IdSuministro },
				{ "nombre", item.Nombre }
			}).ToList();
			return new JsonResult(value);
		}
	}
	public class BS_Ventas
	{
		public class Estados
		{
			private readonly AD_Ventas AdVentas;

			public Estados(AD_Ventas adVentas)
			{
				AdVentas = adVentas;
			}

			internal IActionResult Eliminar(int id)
			{
				try
				{
					AdVentas.EliminarEstado(new EstadosVentas
					{
						IdEstadoVenta = id
					});
					return new StatusCodeResult(200);
				}
				catch (Exception ex)
				{
					return new ContentResult
					{
						Content = (ex.InnerException?.Message ?? ex.Message),
						ContentType = "application/json",
						StatusCode = 100
					};
				}
			}

			internal async Task<IActionResult> ValidarDatos(DTOEstadosVentas Estado)
			{
				try
				{
					Estado.Descripcion = Regex.Replace(Estado.Descripcion ?? "", "\\s+", " ").Trim().ToUpper();
					if (string.IsNullOrEmpty(Estado.Descripcion))
					{
						return new ContentResult
						{
							Content = "El estado no puede estar vacío",
							ContentType = "application/json",
							StatusCode = 400
						};
					}
					await AdVentas.GuardarEstado(Estado);
					return new StatusCodeResult(200);
				}
				catch (Exception ex2)
				{
					Exception ex = ex2;
					return new ContentResult
					{
						Content = (ex.InnerException?.Message ?? ex.Message),
						ContentType = "application/json",
						StatusCode = 400
					};
				}
			}
		}

		private readonly AD_Ventas AdVentas;

		public BS_Ventas(AD_Ventas adVentas)
		{
			AdVentas = adVentas;
		}

		public Estados EstadosVentas()
		{
			return new Estados(AdVentas);
		}

		internal async Task<IActionResult> ProcesarDatosVenta(DTOVentas Venta)
		{
			decimal saldoPendiente = Venta.MontoTotal;
			if (Venta.DetallesVenta == null || (Venta.Pagos == null && Venta.Cuotas != null) || (Venta.Cuotas == null && Venta.Pagos == null))
			{
				return new ContentResult
				{
					Content = "Faltan Datos",
					ContentType = "application/json",
					StatusCode = 400
				};
			}
			Ventas NuevaVenta = new Ventas
			{
				IdCliente = Venta.IdCliente,
				FechaHora = UTL_Fechas.ObtenerFechaHora(),
				IdUsuario = Venta.IdUsuario,
				IdEstadoVenta = Venta.IdEstadoVenta,
				MontoTotal = Venta.MontoTotal
			};
			if (Venta.DetallesVenta != null)
			{
				foreach (DTOVentasDetalles vta in Venta.DetallesVenta)
				{
					NuevaVenta.DetallesVenta.Add(new VentasDetalles
					{
						IdProducto = vta.IdProducto,
						Cantidad = vta.Cantidad,
						Precio = vta.Precio,
						IdProductoNavigation = new Producto
						{
							IdProducto = vta.IdProducto
						}
					});
				}
			}
			if (Venta.Pagos != null)
			{
				foreach (DTOPagosVentas vtaPagos in Venta.Pagos)
				{
					saldoPendiente -= vtaPagos.Monto;
					NuevaVenta.Pagos.Add(new PagosVentas
					{
						Fecha = (vtaPagos.Fecha ?? UTL_Fechas.ObtenerFechaHora()),
						Monto = vtaPagos.Monto,
						IdMedioPago = vtaPagos.IdMedioPago
					});
				}
				NuevaVenta.SaldoPendiente = saldoPendiente;
			}
			if (Venta.Cuotas != null)
			{
				foreach (DTOCuotasVentas Cuota in Venta.Cuotas)
				{
					NuevaVenta.Cuotas.Add(new CuotasVentas
					{
						NumeroCuota = Cuota.NumeroCuota,
						Monto = Cuota.Monto,
						FechaVencimiento = Cuota.FechaVencimiento,
						IdEstadoCuota = Cuota.IdEstadoCuota
					});
				}
			}
			bool Resultado = await AdVentas.Guardar(NuevaVenta);
			return new ContentResult
			{
				Content = (Resultado ? "Datos Guardados" : "Error interno, no se guardaron los datos"),
				ContentType = "Application/Json",
				StatusCode = (Resultado ? 200 : 500)
			};
		}

		public static ICollection<DTOCuotasVentas> CalcularCuotas(UTL_ParametrosCuotas Parametros)
		{
			ICollection<DTOCuotasVentas> collection = new List<DTOCuotasVentas>();
			DateTime dateTime = UTL_Fechas.ObtenerFechaHora();
			decimal num = (Parametros.MontoVenta + Parametros.MontoVenta * Parametros.Interes) / (decimal)Parametros.CantidadCuotas;
			decimal num2 = Parametros.MontoVenta % (decimal)Parametros.CantidadCuotas;
			for (int i = 1; i <= Parametros.CantidadCuotas; i++)
			{
				if (1 == 0)
				{
				}
				DateTime dateTime2 = ((i != 1) ? dateTime.AddDays(30.0) : dateTime);
				if (1 == 0)
				{
				}
				dateTime = dateTime2;
				ICollection<DTOCuotasVentas> collection2 = collection;
				DTOCuotasVentas dTOCuotasVentas = new DTOCuotasVentas();
				dTOCuotasVentas.NumeroCuota = i;
				DTOCuotasVentas dTOCuotasVentas2 = dTOCuotasVentas;
				int num3 = i;
				if (1 == 0)
				{
				}
				decimal monto = ((num3 != Parametros.CantidadCuotas) ? num : (num + num2));
				if (1 == 0)
				{
				}
				dTOCuotasVentas2.Monto = monto;
				dTOCuotasVentas.FechaVencimiento = dateTime;
				collection2.Add(dTOCuotasVentas);
			}
			return collection;
		}

		internal IActionResult Filtrar(UTL_FiltrosComprasVentas? filtros)
		{
			UTL_FiltrosComprasVentas filtros2 = filtros;
			try
			{
				IQueryable<Ventas> source = AdVentas.ListarVentas();
				UTL_FiltrosComprasVentas uTL_FiltrosComprasVentas = filtros2;
				if (uTL_FiltrosComprasVentas != null && uTL_FiltrosComprasVentas.IdEntidad.HasValue)
				{
					source = source.Where((Ventas x) => (int?)x.IdCliente == filtros2.IdEntidad);
				}
				UTL_FiltrosComprasVentas uTL_FiltrosComprasVentas2 = filtros2;
				if (uTL_FiltrosComprasVentas2 != null && uTL_FiltrosComprasVentas2.Desde.HasValue)
				{
					source = source.Where((Ventas X) => X.FechaHora >= filtros2.Desde);
				}
				UTL_FiltrosComprasVentas uTL_FiltrosComprasVentas3 = filtros2;
				if (uTL_FiltrosComprasVentas3 != null && uTL_FiltrosComprasVentas3.Hasta.HasValue)
				{
					source = source.Where((Ventas X) => X.FechaHora >= filtros2.Hasta);
				}
				List<DTOVentas> value = source.Select((Ventas x) => new DTOVentas
				{
					IdVenta = x.IdVenta,
					IdCliente = x.IdCliente,
					FechaHora = x.FechaHora,
					IdUsuario = x.IdUsuario,
					IdEstadoVenta = x.IdEstadoVenta,
					MontoTotal = x.MontoTotal,
					SaldoPendiente = x.SaldoPendiente,
					DetallesVenta = x.DetallesVenta.Select((VentasDetalles y) => new DTOVentasDetalles
					{
						Cantidad = y.Cantidad,
						IdProducto = y.IdProducto,
						IdVenta = y.IdVenta
					}).ToList(),
					Cuotas = x.Cuotas.Select((CuotasVentas Cuotas) => new DTOCuotasVentas
					{
						FechaPago = Cuotas.FechaPago,
						FechaVencimiento = Cuotas.FechaVencimiento,
						NumeroCuota = Cuotas.NumeroCuota,
						Monto = Cuotas.Monto,
						EstadoCuota = new DTOEstadosCuotasVentas
						{
							Descripcion = Cuotas.EstadoCuota.Descripcion,
							IdEstado = Cuotas.EstadoCuota.IdEstado
						}
					}).ToList(),
					Cliente = new DTOEntidades
					{
						Nombre = x.Cliente.Nombre,
						Apellido = x.Cliente.Apellido,
						NombreClave = x.Cliente.NombreClave,
						IdTipo = x.Cliente.IdTipo,
						IdCategoria = x.Cliente.IdCategoria
					},
					Pagos = x.Pagos.Select((PagosVentas Pagos) => new DTOPagosVentas
					{
						IdMedioPago = Pagos.IdMedioPago,
						IdPago = Pagos.IdPago,
						IdVenta = Pagos.IdVenta,
						Monto = Pagos.Monto,
						MedioPago = new DTOMediosPago
						{
							Descripcion = Pagos.MedioPago.Descripcion,
							IdMedioPago = Pagos.MedioPago.IdMedioPago,
							CodigoMPago = Pagos.MedioPago.CodigoMPago
						}
					}).ToList()
				}).ToList();
				return new JsonResult(value);
			}
			catch (Exception ex)
			{
				return new ContentResult
				{
					Content = (ex.InnerException?.Message ?? ex.Message),
					ContentType = "application/json",
					StatusCode = 400
				};
			}
		}
	}
}
namespace Aponus_Web_API.Modelos
{
	public class AponusContext : Microsoft.EntityFrameworkCore.DbContext
	{
		public virtual Microsoft.EntityFrameworkCore.DbSet<ComponentesDetalle> ComponentesDetalles { get; set; }

		public virtual Microsoft.EntityFrameworkCore.DbSet<Productos_Componentes> Componentes_Productos { get; set; }

		public virtual Microsoft.EntityFrameworkCore.DbSet<Stock_Movimientos> Stock_Movimientos { get; set; }

		public virtual Microsoft.EntityFrameworkCore.DbSet<ArchivosMovimientosStock> ArchivosStock { get; set; }

		public virtual Microsoft.EntityFrameworkCore.DbSet<StockInsumos> stockInsumos { get; set; }

		public virtual Microsoft.EntityFrameworkCore.DbSet<ComponentesDescripcion> ComponentesDescripcions { get; set; }

		public virtual Microsoft.EntityFrameworkCore.DbSet<Producto> Productos { get; set; }

		public virtual Microsoft.EntityFrameworkCore.DbSet<ProductosDescripcion> ProductosDescripcions { get; set; }

		public virtual Microsoft.EntityFrameworkCore.DbSet<ProductosTipo> ProductosTipos { get; set; }

		public virtual Microsoft.EntityFrameworkCore.DbSet<Productos_Tipos_Descripcion> Producto_Tipo_Descripcion { get; set; }

		public virtual Microsoft.EntityFrameworkCore.DbSet<Usuarios> Usuarios { get; set; }

		public virtual Microsoft.EntityFrameworkCore.DbSet<Entidades> Entidades { get; set; }

		public virtual Microsoft.EntityFrameworkCore.DbSet<SuministrosMovimientosStock> SuministrosMovimientoStock { get; set; }

		public virtual Microsoft.EntityFrameworkCore.DbSet<EstadosProductos> EstadosProducto { get; set; }

		public virtual Microsoft.EntityFrameworkCore.DbSet<EstadosProductosComponentes> EstadosProductosComponente { get; set; }

		public virtual Microsoft.EntityFrameworkCore.DbSet<EstadosComponentesDetalles> EstadosComponentesDetalle { get; set; }

		public virtual Microsoft.EntityFrameworkCore.DbSet<EstadosTiposProductos> EstadosTiposProducto { get; set; }

		public virtual Microsoft.EntityFrameworkCore.DbSet<EstadosProductosDescripciones> EstadosProductosDescripcione { get; set; }

		public virtual Microsoft.EntityFrameworkCore.DbSet<EstadosMovimientosStock> EstadoMovimientosStock { get; set; }

		public virtual Microsoft.EntityFrameworkCore.DbSet<EstadosArchivosMovimientosStock> EstadoArchivosMovimientosStock { get; set; }

		public virtual Microsoft.EntityFrameworkCore.DbSet<EstadosSuministrosMovimientosStock> EstadoSuministrosMovimientosStock { get; set; }

		public virtual Microsoft.EntityFrameworkCore.DbSet<EntidadesCategorias> CategoriasEntidades { get; set; }

		public virtual Microsoft.EntityFrameworkCore.DbSet<EntidadesTipos> TiposEntidades { get; set; }

		public virtual Microsoft.EntityFrameworkCore.DbSet<EntidadesTiposCategorias> EntidadeTiposCategorias { get; set; }

		public virtual Microsoft.EntityFrameworkCore.DbSet<Compras> Compra { get; set; }

		public virtual Microsoft.EntityFrameworkCore.DbSet<PagosCompras> PagosCompra { get; set; }

		public virtual Microsoft.EntityFrameworkCore.DbSet<ComprasDetalles> ComprasDetalle { get; set; }

		public virtual Microsoft.EntityFrameworkCore.DbSet<EstadosCompras> EstadosCompra { get; set; }

		public virtual Microsoft.EntityFrameworkCore.DbSet<CuotasCompras> CuotasCompra { get; set; }

		public virtual Microsoft.EntityFrameworkCore.DbSet<EstadosCuotasCompras> EstadosCuotasCompra { get; set; }

		public virtual Microsoft.EntityFrameworkCore.DbSet<MediosPago> MediosPagos { get; set; }

		public virtual Microsoft.EntityFrameworkCore.DbSet<Ventas> ventas { get; set; }

		public virtual Microsoft.EntityFrameworkCore.DbSet<PagosVentas> pagosVentas { get; set; }

		public virtual Microsoft.EntityFrameworkCore.DbSet<VentasDetalles> ventasDetalle { get; set; }

		public virtual Microsoft.EntityFrameworkCore.DbSet<EstadosVentas> estadosVentas { get; set; }

		public virtual Microsoft.EntityFrameworkCore.DbSet<CuotasVentas> cuotasVentas { get; set; }

		public virtual Microsoft.EntityFrameworkCore.DbSet<EstadosCuotasVentas> estadosCuotasVentas { get; set; }

		public virtual Microsoft.EntityFrameworkCore.DbSet<PerfilesUsuarios> perfilesUsuarios { get; set; }

		public AponusContext(DbContextOptions<AponusContext> options)
			: base(options)
		{
		}

		public AponusContext()
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.UseCollation("Modern_Spanish_CI_AI");
			modelBuilder.Entity(delegate(EntityTypeBuilder<CuotasCompras> entity)
			{
				entity.ToTable("CUOTAS_COMPRAS");
				entity.HasKey((CuotasCompras p) => p.IdCuota);
				entity.Property((CuotasCompras p) => p.IdCompra).HasColumnName("ID_COMPRA");
				entity.Property((CuotasCompras p) => p.Monto).HasColumnType("decimal(18,2)");
				entity.Property((CuotasCompras p) => p.FechaVencimiento).HasColumnType("timestamp");
				entity.Property((CuotasCompras p) => p.FechaPago).HasColumnType("timestamp");
				entity.HasOne((CuotasCompras p) => p.CompraNavigation).WithMany((Compras p) => p.CuotasCompra).HasPrincipalKey((Compras PK) => PK.IdCompra)
					.HasForeignKey((CuotasCompras FK) => FK.IdCompra)
					.HasConstraintName("FK_CUOTAS_COMPRAS_COMPRAS_ID_COMPRA");
				entity.HasOne((CuotasCompras p) => p.EstadoCuotaCompra).WithMany((EstadosCuotasCompras p) => p.IdEstadoCuotaNavigation).HasPrincipalKey((EstadosCuotasCompras p) => p.IdEstadoCuota)
					.HasForeignKey((CuotasCompras p) => p.IdEstadoCuota)
					.HasConstraintName("FK_CUOTAS_COMPRAS_ESTADOS_CUOTAS_COMPRAS_ID_ESTADO_CUOTA");
			});
			modelBuilder.Entity(delegate(EntityTypeBuilder<EstadosCuotasCompras> entity)
			{
				entity.ToTable("ESTADOS_CUOTAS_COMPRAS");
				entity.HasKey((EstadosCuotasCompras p) => p.IdEstadoCuota);
				entity.Property((EstadosCuotasCompras p) => p.Descripcion).HasColumnType("text");
				entity.Property((EstadosCuotasCompras p) => p.IdEstado).HasDefaultValueSql("1");
			});
			modelBuilder.Entity(delegate(EntityTypeBuilder<PerfilesUsuarios> entity)
			{
				entity.ToTable("USUARIOS_PERFILES");
				entity.HasKey((PerfilesUsuarios PK) => PK.IdPerfil);
				entity.Property((PerfilesUsuarios p) => p.IdPerfil).HasColumnName("ID_PERFIL").HasColumnType("integer")
					.UseIdentityColumn();
				entity.Property((PerfilesUsuarios p) => p.Descripcion).HasColumnType("varchar(100)").HasColumnName("DESCRIPCION");
				entity.Property((PerfilesUsuarios p) => p.IdEstado).HasColumnType("integer").HasColumnName("ID_ESTADO");
			});
			modelBuilder.Entity(delegate(EntityTypeBuilder<EntidadesTiposCategorias> entity)
			{
				entity.ToTable("ENTIDADES_TIPOS_CATEGORIAS");
				entity.HasKey((EntidadesTiposCategorias PK) => new { PK.idTipoEntidad, PK.IdCategoriaEntidad });
				entity.Property((EntidadesTiposCategorias p) => p.idTipoEntidad).HasColumnName("ID_TIPO").HasColumnType("int");
				entity.Property((EntidadesTiposCategorias p) => p.IdCategoriaEntidad).HasColumnName("ID_CATEGORIA").HasColumnType("int");
			});
			modelBuilder.Entity(delegate(EntityTypeBuilder<EstadosCuotasVentas> entity)
			{
				entity.ToTable("ESTADOS_CUOTAS_VENTAS");
				entity.HasKey((EstadosCuotasVentas pk) => pk.IdEstadoCuota);
				entity.Property((EstadosCuotasVentas p) => p.IdEstadoCuota).HasColumnType("int").HasColumnName("ID_ESTADO_CUOTA")
					.UseIdentityColumn();
				entity.Property((EstadosCuotasVentas p) => p.Descripcion).HasColumnName("DESCRIPCION").HasColumnType("text");
				entity.Property((EstadosCuotasVentas p) => p.IdEstado).HasColumnType("int").HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				entity.HasMany((EstadosCuotasVentas p) => p.IdEstadoCuotaNavigation).WithOne((CuotasVentas p) => p.EstadoCuota).HasPrincipalKey((EstadosCuotasVentas p) => p.IdEstadoCuota)
					.HasForeignKey((CuotasVentas FK) => FK.IdEstadoCuota);
			});
			modelBuilder.Entity(delegate(EntityTypeBuilder<CuotasVentas> entity)
			{
				entity.ToTable("CUOTAS_VENTAS");
				entity.HasKey((CuotasVentas PK) => PK.IdCuota);
				entity.Property((CuotasVentas p) => p.IdCuota).HasColumnType("int").HasColumnName("ID_CUOTA")
					.UseIdentityColumn();
				entity.Property((CuotasVentas p) => p.IdVenta).HasColumnType("int").HasColumnName("ID_VENTA");
				entity.Property((CuotasVentas p) => p.NumeroCuota).HasColumnType("int").HasColumnName("NUMERO_CUOTA");
				entity.Property((CuotasVentas p) => p.Monto).HasColumnName("MONTO").HasColumnType("decimal(18,2)")
					.HasDefaultValueSql("0.00");
				entity.Property((CuotasVentas p) => p.FechaVencimiento).HasColumnName("FECHA_VENCIMIENTO").HasColumnType("timestamp");
				entity.Property((CuotasVentas p) => p.IdEstadoCuota).HasColumnName("ID_ESTADO_CUOTA").HasDefaultValueSql("1");
				entity.Property((CuotasVentas p) => p.FechaPago).HasColumnName("FECHA_PAGO").HasColumnType("timestamp");
			});
			modelBuilder.Entity(delegate(EntityTypeBuilder<Ventas> entity)
			{
				entity.ToTable("VENTAS");
				entity.HasKey((Ventas p) => p.IdVenta);
				entity.Property((Ventas p) => p.IdVenta).HasColumnName("ID_VENTA").HasColumnType("int")
					.UseIdentityColumn();
				entity.Property((Ventas p) => p.IdCliente).HasColumnName("ID_CLIENTE").HasColumnType("int");
				entity.Property((Ventas p) => p.FechaHora).HasColumnName("FECHA_HORA").HasColumnType("timestamp");
				entity.Property((Ventas p) => p.IdUsuario).HasColumnName("ID_USUARIO").HasColumnType("varchar(50)");
				entity.Property((Ventas p) => p.MontoTotal).HasColumnName("MONTO_TOTAL").HasColumnType("decimal(18,2)");
				entity.Property((Ventas p) => p.IdEstadoVenta).HasColumnName("ID_ESTADO_VENTA").HasColumnType("int");
				entity.Property((Ventas p) => p.SaldoPendiente).HasColumnName("SALDO_PENDIENTE");
				entity.HasOne((Ventas p) => p.Usuario).WithMany((Usuarios p) => p.Ventas).HasForeignKey((Ventas FK) => FK.IdUsuario)
					.HasPrincipalKey((Usuarios PK) => PK.Usuario)
					.OnDelete(DeleteBehavior.NoAction);
				entity.HasOne((Ventas p) => p.Estado).WithMany((EstadosVentas p) => p.ventas).HasForeignKey((Ventas FK) => FK.IdEstadoVenta)
					.HasPrincipalKey((EstadosVentas PK) => PK.IdEstadoVenta);
				entity.HasOne((Ventas p) => p.Cliente).WithMany((Entidades p) => p.ventas).HasForeignKey((Ventas FK) => FK.IdCliente)
					.HasPrincipalKey((Entidades PK) => PK.IdEntidad)
					.OnDelete(DeleteBehavior.NoAction);
				entity.HasMany((Ventas p) => p.Pagos).WithOne((PagosVentas p) => p.Venta).HasForeignKey((PagosVentas p) => p.IdVenta);
				entity.HasMany((Ventas p) => p.Cuotas).WithOne((CuotasVentas p) => p.Venta).HasPrincipalKey((Ventas P) => P.IdVenta)
					.HasForeignKey((CuotasVentas p) => p.IdVenta);
			});
			modelBuilder.Entity(delegate(EntityTypeBuilder<VentasDetalles> entity)
			{
				entity.ToTable("VENTAS_DETALLES");
				entity.HasKey((VentasDetalles PK) => new { PK.IdVenta, PK.IdProducto });
				entity.Property((VentasDetalles p) => p.IdVenta).HasColumnType("int").HasColumnName("ID_VENTA");
				entity.Property((VentasDetalles p) => p.IdProducto).HasColumnType("varchar(50)").HasColumnName("ID_PRODUCTO");
				entity.Property((VentasDetalles p) => p.Cantidad).HasColumnType("decimal(18,2)").HasColumnName("CANTIDAD");
				entity.Property((VentasDetalles p) => p.Precio).HasColumnType("decimal(18,2)").HasColumnName("PRECIO");
				entity.HasOne((VentasDetalles p) => p.Venta).WithMany((Ventas p) => p.DetallesVenta).HasPrincipalKey((Ventas PK) => PK.IdVenta)
					.HasForeignKey((VentasDetalles FK) => FK.IdVenta);
				entity.HasOne((VentasDetalles p) => p.IdProductoNavigation).WithMany((Producto p) => p.Ventas).HasForeignKey((VentasDetalles FK) => FK.IdProducto)
					.HasPrincipalKey((Producto PK) => PK.IdProducto)
					.HasConstraintName("FK_VENTAS_DETALLES_PRODUCTOS_ID_PRODUCTO");
			});
			modelBuilder.Entity(delegate(EntityTypeBuilder<PagosVentas> entity)
			{
				entity.ToTable("PAGOS_VENTAS");
				entity.HasKey((PagosVentas PK) => PK.IdPago);
				entity.Property((PagosVentas P) => P.IdPago).HasColumnName("ID_PAGO").HasColumnType("int")
					.UseIdentityColumn();
				entity.Property((PagosVentas p) => p.IdVenta).HasColumnType("int").HasColumnName("ID_VENTA");
				entity.Property((PagosVentas p) => p.IdMedioPago).HasColumnName("ID_MEDIO_PAGO").HasColumnType("int");
				entity.Property((PagosVentas p) => p.Monto).HasColumnName("MONTO").HasColumnType("decimal(18,2)");
				entity.Property((PagosVentas p) => p.Fecha).HasColumnName("FECHA").HasColumnType("timestamp");
				entity.HasOne((PagosVentas p) => p.MedioPago).WithMany((MediosPago p) => p.PagosVentasNavigation).HasForeignKey((PagosVentas FK) => FK.IdMedioPago)
					.HasPrincipalKey((MediosPago PK) => PK.IdMedioPago);
				entity.HasOne((PagosVentas p) => p.Venta).WithMany((Ventas p) => p.Pagos).HasPrincipalKey((Ventas PK) => PK.IdVenta)
					.HasForeignKey((PagosVentas FK) => FK.IdVenta);
			});
			modelBuilder.Entity(delegate(EntityTypeBuilder<EstadosVentas> entity)
			{
				entity.ToTable("ESTADOS_VENTAS");
				entity.HasKey((EstadosVentas PK) => PK.IdEstadoVenta);
				entity.Property((EstadosVentas P) => P.IdEstadoVenta).HasColumnName("ID_ESTADO_VENTA").HasColumnType("int")
					.UseIdentityColumn();
				entity.Property((EstadosVentas P) => P.IdEstado).HasColumnName("ID_ESTADO").HasColumnType("int")
					.HasDefaultValue("1");
				entity.Property((EstadosVentas P) => P.Descripcion).HasColumnName("DESCRIPCION").HasColumnType("text");
			});
			modelBuilder.Entity(delegate(EntityTypeBuilder<ComprasDetalles> entity)
			{
				entity.ToTable("COMPRAS_DETALLE");
				entity.HasKey((ComprasDetalles PK) => new { PK.IdCompra, PK.IdInsumo });
				entity.Property((ComprasDetalles p) => p.IdCompra).HasColumnType("int").HasColumnName("ID_COMPRA");
				entity.Property((ComprasDetalles p) => p.IdInsumo).HasColumnType("varchar(50)").HasColumnName("ID_INSUMO");
				entity.Property((ComprasDetalles p) => p.Cantidad).HasColumnType("decimal(18,2)").HasColumnName("CANTIDAD");
				entity.HasOne((ComprasDetalles p) => p.Compra).WithMany((Compras p) => p.DetallesCompra).HasPrincipalKey((Compras PK) => PK.IdCompra)
					.HasForeignKey((ComprasDetalles FK) => FK.IdCompra);
				entity.HasOne((ComprasDetalles p) => p.DetallesInsumo).WithMany((ComponentesDetalle p) => p.ComprasNavigation).HasForeignKey((ComprasDetalles FK) => FK.IdInsumo)
					.HasPrincipalKey((ComponentesDetalle PK) => PK.IdInsumo);
			});
			modelBuilder.Entity(delegate(EntityTypeBuilder<MediosPago> entity)
			{
				entity.ToTable("MEDIOS_PAGO");
				entity.HasKey((MediosPago PK) => PK.IdMedioPago);
				entity.Property((MediosPago p) => p.IdMedioPago).HasColumnName("ID_MEDIO_PAGO").HasColumnType("int")
					.UseIdentityColumn();
				entity.Property((MediosPago p) => p.CodigoMPago).HasColumnType("text").HasColumnName("CODIGO_MPAGO");
				entity.Property((MediosPago p) => p.Descripcion).HasColumnType("text").HasColumnName("DESCRIPCION");
				entity.Property((MediosPago p) => p.IdEstado).HasColumnType("int").HasColumnName("ID_ESTADO")
					.HasDefaultValue("1");
			});
			modelBuilder.Entity(delegate(EntityTypeBuilder<PagosCompras> entity)
			{
				entity.ToTable("PAGOS_COMPRAS");
				entity.HasKey((PagosCompras PK) => PK.IdPago);
				entity.Property((PagosCompras P) => P.IdPago).HasColumnName("ID_PAGO").HasColumnType("int")
					.UseIdentityColumn();
				entity.Property((PagosCompras p) => p.IdCompra).HasColumnType("int").HasColumnName("ID_COMPRA");
				entity.Property((PagosCompras p) => p.IdMedioPago).HasColumnName("ID_MEDIO_PAGO").HasColumnType("int");
				entity.Property((PagosCompras p) => p.Monto).HasColumnName("SUBTOTAL").HasColumnType("decimal(18,2)");
				entity.Property((PagosCompras p) => p.Fecha).HasColumnType("timestamp");
				entity.HasOne((PagosCompras p) => p.MedioPago).WithMany((MediosPago p) => p.PagosComprasNavigation).HasForeignKey((PagosCompras FK) => FK.IdMedioPago)
					.HasPrincipalKey((MediosPago PK) => PK.IdMedioPago);
				entity.HasOne((PagosCompras p) => p.Compra).WithMany((Compras p) => p.Pagos).HasPrincipalKey((Compras PK) => PK.IdCompra)
					.HasForeignKey((PagosCompras FK) => FK.IdCompra);
			});
			modelBuilder.Entity(delegate(EntityTypeBuilder<EstadosCompras> entity)
			{
				entity.ToTable("ESTADOS_COMPRAS");
				entity.HasKey((EstadosCompras PK) => PK.IdEstadoCompra);
				entity.Property((EstadosCompras P) => P.IdEstadoCompra).HasColumnName("ID_ESTADO_COMPRA").HasColumnType("int")
					.HasAnnotation("SqlServer:Identity", "1, 1");
				entity.Property((EstadosCompras P) => P.IdEstado).HasColumnName("ID_ESTADO").HasColumnType("int");
				entity.Property((EstadosCompras P) => P.Descripcion).HasColumnName("DESCRIPCION").HasColumnType("text");
			});
			modelBuilder.Entity(delegate(EntityTypeBuilder<Compras> entity)
			{
				entity.ToTable("COMPRAS");
				entity.HasKey((Compras p) => p.IdCompra);
				entity.Property((Compras p) => p.IdCompra).HasColumnName("ID_COMPRA").HasColumnType("int")
					.UseIdentityColumn();
				entity.Property((Compras p) => p.IdProveedor).HasColumnName("ID_PROVEEDOR").HasColumnType("int");
				entity.Property((Compras p) => p.FechaHora).HasColumnName("FECHA_HORA").HasColumnType("timestamp");
				entity.Property((Compras p) => p.IdUsuario).HasColumnName("ID_USUARIO").HasColumnType("varchar(50)");
				entity.HasOne((Compras p) => p.Usuario).WithMany((Usuarios p) => p.Compras).HasForeignKey((Compras FK) => FK.IdUsuario)
					.HasPrincipalKey((Usuarios PK) => PK.Usuario)
					.OnDelete(DeleteBehavior.NoAction);
				entity.Property((Compras p) => p.IdEstadoCompra).HasColumnName("ID_ESTADO_COMPRA").HasColumnType("int");
				entity.Property((Compras p) => p.MontoTotal).HasColumnType("decimal(18,2)").HasColumnName("MONTO_TOTAL");
				entity.Property((Compras p) => p.SaldoPendiente).HasColumnType("decimal(18,2)").HasColumnName("SALDO_PENDIENTE");
				entity.HasOne((Compras p) => p.Estado).WithMany((EstadosCompras p) => p.compras).HasPrincipalKey((EstadosCompras PK) => PK.IdEstadoCompra)
					.HasForeignKey((Compras FK) => FK.IdEstadoCompra)
					.HasConstraintName("FK_COMPRAS_ESTADOS_COMPRAS_ID_ESTADO_COMPRA");
				entity.HasOne((Compras p) => p.Usuario).WithMany((Usuarios p) => p.Compras).HasPrincipalKey((Usuarios PK) => PK.Usuario)
					.HasForeignKey((Compras FK) => FK.IdUsuario)
					.HasConstraintName("FK_COMPRAS_USUARIOS_IDUSUARIO");
				entity.HasOne((Compras p) => p.IdProveedorNavigation).WithMany((Entidades p) => p.compras).HasForeignKey((Compras p) => p.IdProveedor)
					.HasPrincipalKey((Entidades p) => p.IdEntidad)
					.OnDelete(DeleteBehavior.NoAction);
				entity.HasMany((Compras p) => p.Pagos).WithOne((PagosCompras p) => p.Compra).HasForeignKey((PagosCompras p) => p.IdCompra);
			});
			modelBuilder.Entity(delegate(EntityTypeBuilder<EntidadesTipos> entity)
			{
				entity.ToTable("ENTIDADES_TIPOS");
				entity.HasKey((EntidadesTipos PK) => PK.IdTipo);
				entity.Property((EntidadesTipos P) => P.IdTipo).HasColumnName("ID_TIPO").UseIdentityColumn();
				entity.Property((EntidadesTipos P) => P.IdEstado).HasDefaultValueSql("1").HasColumnName("ID_ESTADO");
				entity.Property((EntidadesTipos p) => p.NombreTipo).HasColumnName("NOMBRE").HasColumnType("text");
				entity.HasMany((EntidadesTipos p) => p.Entidades).WithOne((Entidades p) => p.TipoEntidad).HasForeignKey((Entidades FK) => FK.IdTipo);
				entity.HasMany((EntidadesTipos p) => p.TiposCategoriasNavigation).WithOne((EntidadesTiposCategorias p) => p.TipoEntidad).HasPrincipalKey((EntidadesTipos PK) => PK.IdTipo)
					.HasForeignKey((EntidadesTiposCategorias FK) => FK.idTipoEntidad);
			});
			modelBuilder.Entity(delegate(EntityTypeBuilder<EntidadesCategorias> entity)
			{
				entity.ToTable("ENTIDADES_CATEGORIAS");
				entity.HasKey((EntidadesCategorias PK) => PK.IdCategoria);
				entity.Property((EntidadesCategorias P) => P.IdCategoria).HasColumnName("ID_CATEGORIA").ValueGeneratedOnAdd()
					.UseIdentityColumn();
				entity.Property((EntidadesCategorias P) => P.IdEstado).HasDefaultValueSql("1").HasColumnName("ID_ESTADO");
				entity.Property((EntidadesCategorias p) => p.NombreCategoria).HasColumnName("NOMBRE_CATEGORIA").HasColumnType("text");
				entity.HasMany((EntidadesCategorias p) => p.Entidades).WithOne((Entidades p) => p.CategoriaEntidad).HasForeignKey((Entidades FK) => FK.IdCategoria);
				entity.HasMany((EntidadesCategorias p) => p.TiposCategoriasNavigation).WithOne((EntidadesTiposCategorias p) => p.CategoriaEntidad).HasPrincipalKey((EntidadesCategorias PK) => PK.IdCategoria)
					.HasForeignKey((EntidadesTiposCategorias FK) => FK.IdCategoriaEntidad);
			});
			modelBuilder.Entity(delegate(EntityTypeBuilder<EstadosMovimientosStock> entity)
			{
				entity.ToTable("ESTADOS_MOVIMIENTOS_STOCK");
				entity.HasKey((EstadosMovimientosStock PK) => PK.IdEstadoMovimiento);
				entity.Property((EstadosMovimientosStock p) => p.IdEstadoMovimiento).HasColumnName("ID_ESTADO_MOVIMIENTO").HasColumnType("int")
					.ValueGeneratedOnAdd();
				entity.Property((EstadosMovimientosStock p) => p.IdEstado).HasColumnName("ID_ESTADO").HasDefaultValueSql("1");
				entity.Property((EstadosMovimientosStock p) => p.Descripcion).HasColumnName("DESCRIPCION").HasColumnType("text");
				entity.HasMany((EstadosMovimientosStock p) => p.movimientosStock).WithOne((Stock_Movimientos p) => p.estadoMovimiento).HasForeignKey((Stock_Movimientos p) => p.IdEstadoMovimiento);
			});
			modelBuilder.Entity(delegate(EntityTypeBuilder<EstadosArchivosMovimientosStock> entity)
			{
				entity.ToTable("ESTADOS_ARCHIVOS_MOVIMIENTOS_STOCK");
				entity.HasKey((EstadosArchivosMovimientosStock PK) => PK.IdEstado);
				entity.Property((EstadosArchivosMovimientosStock p) => p.IdEstado).HasColumnName("ID_ESTADO").UseIdentityColumn();
				entity.Property((EstadosArchivosMovimientosStock p) => p.Descripcion).HasColumnName("DESCRIPCION").HasColumnType("text");
				entity.HasMany((EstadosArchivosMovimientosStock p) => p.ArchivosMovimientoStock).WithOne((ArchivosMovimientosStock p) => p.ArchivosMovimientosStockNavigation).HasForeignKey((ArchivosMovimientosStock p) => p.IdEstado);
			});
			modelBuilder.Entity(delegate(EntityTypeBuilder<EstadosSuministrosMovimientosStock> entity)
			{
				entity.ToTable("ESTADOS_SUMINISTROS_MOVIMIENTOS_STOCK");
				entity.HasKey((EstadosSuministrosMovimientosStock PK) => PK.IdEstado);
				entity.Property((EstadosSuministrosMovimientosStock p) => p.IdEstado).HasColumnName("ID_ESTADO");
				entity.Property((EstadosSuministrosMovimientosStock p) => p.Descripcion).HasColumnName("DESCRIPCION").HasColumnType("text");
				entity.HasMany((EstadosSuministrosMovimientosStock p) => p.SuministrosMovimientoStock).WithOne((SuministrosMovimientosStock p) => p.EstadosSuministrosMovimientosStockNavigation).HasForeignKey((SuministrosMovimientosStock p) => p.IdEstado)
					.HasConstraintName("FK_SUMINISTROS_MOVIMIENTOS_STOCK_ESTADOS_SUMINISTROS_MOVIMIENTO");
			});
			modelBuilder.Entity(delegate(EntityTypeBuilder<EstadosProductosDescripciones> entity)
			{
				entity.ToTable("ESTADOS_PRODUCTOS_DESCRIPCIONES");
				entity.HasKey((EstadosProductosDescripciones PK) => PK.IdEstado);
				entity.Property((EstadosProductosDescripciones p) => p.IdEstado).HasColumnName("ID_ESTADO").HasDefaultValueSql("1");
				entity.Property((EstadosProductosDescripciones p) => p.Descripcion).HasColumnName("DESCRIPCION").HasColumnType("text");
				entity.HasMany((EstadosProductosDescripciones p) => p.ProductosDescripcions).WithOne((ProductosDescripcion p) => p.IdEstadoNavigation).HasForeignKey((ProductosDescripcion p) => p.IdEstado);
			});
			modelBuilder.Entity(delegate(EntityTypeBuilder<EstadosTiposProductos> entity)
			{
				entity.ToTable("ESTADOS_PRODUCTOS_TIPOS");
				entity.HasKey((EstadosTiposProductos PK) => PK.IdEstado);
				entity.Property((EstadosTiposProductos e) => e.IdEstado).HasColumnName("ID_ESTADO");
				entity.Property((EstadosTiposProductos e) => e.Descripcion).HasColumnType("text").HasColumnName("DESCRIPCION");
				entity.HasMany((EstadosTiposProductos e) => e.ProductosTipos).WithOne((ProductosTipo e) => e.IdEstadoNavigation).HasForeignKey((ProductosTipo e) => e.IdEstado);
			});
			modelBuilder.Entity(delegate(EntityTypeBuilder<EstadosComponentesDetalles> entity)
			{
				entity.ToTable("ESTADOS_COMPONENTES_DETALLES");
				entity.HasKey((EstadosComponentesDetalles e) => e.IdEstado);
				entity.Property((EstadosComponentesDetalles e) => e.IdEstado).HasColumnName("ID_ESTADO");
				entity.Property((EstadosComponentesDetalles e) => e.Descripcion).HasColumnType("text").HasColumnName("DESCRIPCION");
				entity.HasMany((EstadosComponentesDetalles e) => e.ComponentesDetalle).WithOne((ComponentesDetalle e) => e.IdEstadoNavigation).HasForeignKey((ComponentesDetalle e) => e.IdEstado);
			});
			modelBuilder.Entity(delegate(EntityTypeBuilder<EstadosProductosComponentes> entity)
			{
				entity.ToTable("ESTADOS_PRODUCTOS_COMPONENTES");
				entity.HasKey((EstadosProductosComponentes PK) => PK.IdEstado);
				entity.Property((EstadosProductosComponentes e) => e.IdEstado).HasColumnName("ID_ESTADO");
				entity.Property((EstadosProductosComponentes e) => e.Descripcion).HasColumnType("text").HasColumnName("DESCRIPCION");
				entity.HasMany((EstadosProductosComponentes e) => e.ProductosComponentes).WithOne((Productos_Componentes e) => e.IdEstadoNavigation).HasForeignKey((Productos_Componentes e) => e.IdEstado);
			});
			modelBuilder.Entity(delegate(EntityTypeBuilder<EstadosProductos> entity)
			{
				entity.ToTable("ESTADOS_PRODUCTOS");
				entity.HasKey((EstadosProductos PK) => PK.IdEstado);
				entity.Property((EstadosProductos entity) => entity.IdEstado).HasColumnName("ID_ESTADO");
				entity.Property((EstadosProductos e) => e.Descripcion).HasColumnType("text").HasColumnName("DESCRIPCION");
				entity.HasMany((EstadosProductos e) => e.Productos).WithOne((Producto e) => e.IdEstadoNavigation).HasForeignKey((Producto e) => e.IdEstado);
			});
			modelBuilder.Entity(delegate(EntityTypeBuilder<SuministrosMovimientosStock> entity)
			{
				entity.ToTable("SUMINISTROS_MOVIMIENTOS_STOCK");
				entity.HasKey((SuministrosMovimientosStock PK) => new { PK.IdMovimiento, PK.IdSuministro });
				entity.Property((SuministrosMovimientosStock e) => e.IdMovimiento).HasColumnName("ID_MOVIMIENTO").HasColumnType("int");
				entity.Property((SuministrosMovimientosStock e) => e.IdSuministro).HasColumnName("ID_SUMINISTRO").HasColumnType("varchar(50)");
				entity.Property((SuministrosMovimientosStock e) => e.Cantidad).HasColumnName("CANTIDAD").HasColumnType("decimal(18,2)");
				entity.Property((SuministrosMovimientosStock e) => e.IdEstado).HasColumnName("ID_ESTADO").HasDefaultValueSql("1");
			});
			modelBuilder.Entity(delegate(EntityTypeBuilder<StockInsumos> entity)
			{
				entity.ToTable("STOCK_INSUMOS");
				entity.Property((StockInsumos e) => e.IdInsumo).HasColumnName("ID_INSUMO").HasColumnType("varchar(50)");
				entity.HasKey((StockInsumos PK) => PK.IdInsumo).HasName("PK_STOCK_INSUMOS");
				entity.Property((StockInsumos e) => e.Recibido).HasColumnName("RECIBIDO").HasColumnType("decimal");
				entity.Property((StockInsumos e) => e.Granallado).HasColumnName("GRANALLADO").HasColumnType("decimal");
				entity.Property((StockInsumos e) => e.Pintura).HasColumnName("PINTURA").HasColumnType("decimal");
				entity.Property((StockInsumos e) => e.Proceso).HasColumnName("PROCESO").HasColumnType("decimal");
				entity.Property((StockInsumos e) => e.Moldeado).HasColumnName("MOLDEADO").HasColumnType("decimal");
				entity.Property((StockInsumos e) => e.Pendiente).HasColumnName("PENDIENTE").HasColumnType("decimal(18,2)");
			});
			modelBuilder.Entity(delegate(EntityTypeBuilder<Productos_Componentes> entity)
			{
				entity.ToTable("PRODUCTOS_COMPONENTES");
				entity.Property((Productos_Componentes e) => e.IdProducto).HasColumnName("ID_PRODUCTO").HasColumnType("varchar(50)");
				entity.Property((Productos_Componentes e) => e.IdComponente).HasColumnName("ID_COMPONENTE").HasColumnType("varchar(50)");
				entity.HasKey((Productos_Componentes PK) => new { PK.IdProducto, PK.IdComponente }).HasName("PK_PRODUCTOS_COMPONENTES");
				entity.Property((Productos_Componentes e) => e.Cantidad).HasColumnName("CANTIDAD").HasColumnType("decimal(18,2)");
				entity.Property((Productos_Componentes e) => e.Peso).HasColumnName("PESO").HasColumnType("decimal(18,2)");
				entity.Property((Productos_Componentes e) => e.Longitud).HasColumnName("LONGITUD").HasColumnType("decimal(18,2)");
				entity.Property((Productos_Componentes e) => e.IdEstado).HasColumnName("ID_ESTADO").HasDefaultValueSql("1");
			});
			modelBuilder.Entity(delegate(EntityTypeBuilder<ComponentesDetalle> entity)
			{
				entity.Property((ComponentesDetalle e) => e.IdInsumo).HasColumnName("ID_INSUMO").HasColumnType("varchar(50)");
				entity.HasKey((ComponentesDetalle e) => e.IdInsumo).HasName("PK_ID_INSUMO");
				entity.ToTable("COMPONENTES_DETALLE");
				entity.Property((ComponentesDetalle e) => e.IdDescripcion).HasColumnName("ID_DESCRIPCION");
				entity.Property((ComponentesDetalle e) => e.Diametro).HasColumnName("DIAMETRO").HasColumnType("decimal(18,2)");
				entity.Property((ComponentesDetalle e) => e.DiametroNominal).HasColumnName("DIAMETRO_NOMINAL").HasColumnType("int")
					.IsRequired(required: false)
					.HasDefaultValue(null);
				entity.Property((ComponentesDetalle e) => e.Espesor).HasColumnName("ESPESOR").HasColumnType("decimal(18,2)");
				entity.Property((ComponentesDetalle e) => e.Longitud).HasColumnName("LONGITUD").HasColumnType("decimal(18,2)");
				entity.Property((ComponentesDetalle e) => e.Altura).HasColumnName("ALTURA").HasColumnType("decimal(18,2)");
				entity.Property((ComponentesDetalle e) => e.Perfil).HasColumnName("PERFIL");
				entity.Property((ComponentesDetalle e) => e.Tolerancia).HasColumnName("TOLERANCIA").HasColumnType("varchar(50)");
				entity.Property((ComponentesDetalle e) => e.Peso).HasColumnName("PESO").HasColumnType("decimal(18,3)");
				entity.Property((ComponentesDetalle e) => e.IdEstado).HasDefaultValueSql("1").HasColumnName("ID_ESTADO")
					.HasColumnType("int");
				entity.Property((ComponentesDetalle e) => e.IdFraccionamiento).HasColumnName("ID_FRACCIONAMIENTO").HasColumnType("varchar(50)");
				entity.Property((ComponentesDetalle e) => e.IdAlmacenamiento).HasColumnName("ID_ALMACENAMIENTO").HasColumnType("varchar(50)");
			});
			modelBuilder.Entity(delegate(EntityTypeBuilder<ComponentesDescripcion> entity)
			{
				entity.HasKey((ComponentesDescripcion e) => e.IdDescripcion);
				entity.ToTable("COMPONENTES_DESCRIPCION");
				entity.Property((ComponentesDescripcion e) => e.IdDescripcion).HasColumnName("ID_DESCRIPCION").UseIdentityColumn();
				entity.Property((ComponentesDescripcion e) => e.Descripcion).HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnName("DESCRIPCION");
				entity.Property((ComponentesDescripcion p) => p.IdAlmacenamiento).HasColumnType("varchar(50)").HasColumnName("ID_ALMACENAMIENTO")
					.IsRequired();
				entity.Property((ComponentesDescripcion p) => p.IdFraccionamiento).HasColumnName("ID_FRACCIONAMIENTO").HasColumnType("varchar(50)");
			});
			modelBuilder.Entity(delegate(EntityTypeBuilder<Producto> entity)
			{
				entity.HasKey((Producto e) => e.IdProducto);
				entity.ToTable("PRODUCTOS");
				entity.Property((Producto e) => e.IdProducto).HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnName("ID_PRODUCTO");
				entity.Property((Producto e) => e.Cantidad).HasDefaultValueSql("((0))").HasColumnName("CANTIDAD");
				entity.Property((Producto e) => e.DiametroNominal).HasColumnName("DIAMETRO_NOMINAL");
				entity.Property((Producto e) => e.IdDescripcion).HasColumnName("ID_DESCRIPCION");
				entity.Property((Producto e) => e.IdTipo).HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnName("ID_TIPO");
				entity.Property((Producto e) => e.PrecioLista).HasDefaultValueSql("((0))").HasColumnType("money")
					.HasColumnName("PRECIO_LISTA");
				entity.Property((Producto e) => e.PrecioFinal).HasColumnName("PRECIO_FINAL");
				entity.Property((Producto e) => e.PorcentajeGanancia).HasColumnName("PORCENTAJE_GANANCIA");
				entity.Property((Producto e) => e.Tolerancia).HasColumnName("TOLERANCIA");
				entity.Property((Producto e) => e.IdEstado).HasColumnName("ID_ESTADO").HasDefaultValueSql("1");
				entity.HasOne((Producto d) => d.IdDescripcionNavigation).WithMany((ProductosDescripcion p) => p.Productos).HasForeignKey((Producto d) => d.IdDescripcion)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_PRODUCTOS_PRODUCTOS_DESCRIPCION");
				entity.HasOne((Producto d) => d.IdTipoNavigation).WithMany((ProductosTipo p) => p.Productos).HasForeignKey((Producto d) => d.IdTipo)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_PRODUCTOS_PRODUCTOS_TIPOS");
				entity.HasMany((Producto p) => p.Ventas).WithOne((VentasDetalles p) => p.IdProductoNavigation).HasForeignKey((VentasDetalles FK) => FK.IdProducto)
					.HasPrincipalKey((Producto PK) => PK.IdProducto)
					.HasConstraintName("FK_VENTAS_DETALLES_PRODUCTOS_ID_PRODUCTO");
			});
			modelBuilder.Entity(delegate(EntityTypeBuilder<ProductosDescripcion> entity)
			{
				entity.HasKey((ProductosDescripcion e) => e.IdDescripcion);
				entity.ToTable("PRODUCTOS_DESCRIPCION");
				entity.Property((ProductosDescripcion e) => e.IdDescripcion).HasColumnName("ID_DESCRIPCION").UseIdentityColumn();
				entity.Property((ProductosDescripcion e) => e.DescripcionProducto).HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnName("DESCRIPCION");
				entity.Property((ProductosDescripcion e) => e.IdEstado).HasColumnName("ID_ESTADO").HasDefaultValueSql("1");
			});
			modelBuilder.Entity(delegate(EntityTypeBuilder<ProductosTipo> entity)
			{
				entity.HasKey((ProductosTipo e) => e.IdTipo).HasName("PK_PRODUCTOS_TIPOS");
				entity.ToTable("PRODUCTOS_TIPOS");
				entity.Property((ProductosTipo e) => e.IdTipo).HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnName("ID_TIPO");
				entity.Property((ProductosTipo e) => e.DescripcionTipo).HasMaxLength(100).IsUnicode(unicode: false)
					.HasColumnName("DESCRIPCION");
				entity.Property((ProductosTipo e) => e.IdEstado).HasColumnName("ID_ESTADO").UseIdentityColumn()
					.HasDefaultValueSql("1");
			});
			modelBuilder.Entity(delegate(EntityTypeBuilder<Productos_Tipos_Descripcion> entity)
			{
				entity.ToTable("PRODUCTOS_TIPOS_DESCRIPCION");
				entity.HasKey((Productos_Tipos_Descripcion Key) => new { Key.IdTipo, Key.IdDescripcion });
				entity.Property((Productos_Tipos_Descripcion e) => e.IdTipo).HasColumnName("ID_TIPO").HasColumnType("varchar(50)");
				entity.Property((Productos_Tipos_Descripcion e) => e.IdDescripcion).HasColumnName("ID_DESCRIPCION");
				entity.HasOne((Productos_Tipos_Descripcion p) => p.IdTipoNavigation).WithMany((ProductosTipo p) => p.Producto_Tipo_Descripcione).HasForeignKey((Productos_Tipos_Descripcion FK) => FK.IdTipo)
					.HasConstraintName("FK_PRODUCTOS_TIPOS_DESCRIPCION_ID_TIPO")
					.OnDelete(DeleteBehavior.NoAction);
				entity.HasOne((Productos_Tipos_Descripcion p) => p.IdDescripcionNavigation).WithMany((ProductosDescripcion p) => p.Producto_Tipo_Descripcione).HasForeignKey((Productos_Tipos_Descripcion FK) => FK.IdDescripcion)
					.HasConstraintName("FK_PRODUCTOS_TIPOS_DESCRIPCION_ID_DESCRIPCION")
					.OnDelete(DeleteBehavior.NoAction);
			});
			modelBuilder.Entity(delegate(EntityTypeBuilder<Usuarios> entity)
			{
				entity.ToTable("USUARIOS");
				entity.HasKey((Usuarios e) => e.Usuario);
				entity.Property((Usuarios e) => e.Usuario).HasColumnName("USUARIO").HasColumnType("varchar(50)");
				entity.Property((Usuarios e) => e.IdPerfil).HasColumnName("ID_PERFIL").HasColumnType("int");
				entity.Property((Usuarios e) => e.Correo).HasColumnName("CORREO").HasColumnType("varchar(50)");
				entity.Property((Usuarios e) => e.Contraseña).HasColumnName("CONTRASEÑA").HasColumnType("varchar(50)");
				entity.HasMany((Usuarios e) => e.IdUsuarioRegistroNavigation).WithOne((Entidades u) => u.UsuarioRegistro).HasForeignKey((Entidades e) => e.IdUsuarioRegistro);
				entity.HasOne((Usuarios p) => p.Perfil).WithMany((PerfilesUsuarios p) => p.UsuariosNavigation).HasConstraintName("FK_USUARIOS_PERFILES_USUARIOS_ID_PERFIL")
					.HasPrincipalKey((PerfilesUsuarios PK) => PK.IdPerfil)
					.HasForeignKey((Usuarios FK) => FK.IdPerfil);
			});
			modelBuilder.Entity(delegate(EntityTypeBuilder<Stock_Movimientos> entity)
			{
				entity.ToTable("STOCK_MOVIMIENTOS");
				entity.HasKey((Stock_Movimientos e) => e.IdMovimiento);
				entity.Property((Stock_Movimientos e) => e.IdMovimiento).HasColumnName("ID_MOVIMIENTO").HasColumnType("int")
					.ValueGeneratedOnAdd();
				entity.Property((Stock_Movimientos e) => e.CreadoUsuario).HasColumnName("USUARIO_CREADO").HasColumnType("varchar(50)");
				entity.Property((Stock_Movimientos e) => e.ModificadoUsuario).HasColumnName("USUARIO_MODIFICA").HasColumnType("varchar(50)");
				entity.Property((Stock_Movimientos e) => e.FechaHoraCreado).HasColumnName("FECHA_HORA_CREADO").HasColumnType("timestamp");
				entity.Property((Stock_Movimientos e) => e.FechaHoraUltimaModificacion).HasColumnName("FECHA_HORA_ULTIMA_MODIFICACION").HasColumnType("timestamp");
				entity.Property((Stock_Movimientos e) => e.IdProveedor).HasColumnName("ID_PROVEEDOR").HasColumnType("int");
				entity.Property((Stock_Movimientos e) => e.IdEstadoMovimiento).HasColumnName("ID_ESTADO_MOVIMIENTO").HasColumnType("int")
					.HasDefaultValueSql("1");
				entity.Property((Stock_Movimientos e) => e.Origen).HasColumnName("ORIGEN").HasColumnType("varchar(50)");
				entity.Property((Stock_Movimientos e) => e.Destino).HasColumnName("DESTINO").HasColumnType("varchar(50)");
				entity.Property((Stock_Movimientos e) => e.Tipo).HasColumnName("TIPO").HasColumnType("varchar(15)");
				entity.HasOne((Stock_Movimientos e) => e.Proveeedor).WithMany((Entidades e) => e.Movimientos).HasForeignKey((Stock_Movimientos e) => e.IdProveedor)
					.HasPrincipalKey((Entidades PK) => PK.IdEntidad)
					.HasForeignKey((Stock_Movimientos FK) => FK.IdProveedor)
					.HasConstraintName("FK_STOCK_MOVIMIENTOS_ENTIDADES_ID_PROVEEDOR_DESTINO");
			});
			modelBuilder.Entity(delegate(EntityTypeBuilder<ArchivosMovimientosStock> entity)
			{
				entity.HasKey((ArchivosMovimientosStock e) => new { e.IdMovimiento, e.HashArchivo });
				entity.ToTable("ARCHIVOS_STOCK");
				entity.Property((ArchivosMovimientosStock e) => e.IdMovimiento).HasColumnName("ID_MOVIMIENTO");
				entity.Property((ArchivosMovimientosStock e) => e.HashArchivo).HasColumnName("HASH_ARCHIVO").HasColumnType("varchar(255)");
				entity.Property((ArchivosMovimientosStock e) => e.PathArchivo).HasColumnName("PATH").HasColumnType("text");
				entity.Property((ArchivosMovimientosStock e) => e.MimeType).HasColumnName("MIME_TYPE").HasColumnType("text");
				entity.HasOne((ArchivosMovimientosStock e) => e.StockMovimiento).WithMany().HasForeignKey((ArchivosMovimientosStock e) => e.IdMovimiento)
					.HasPrincipalKey((Stock_Movimientos p) => p.IdMovimiento)
					.HasConstraintName("FK_ARCHIVOS_STOCK_STOCK_MOVIMIENTOS_ID_MOVIMIENTO");
				entity.Property((ArchivosMovimientosStock e) => e.IdEstado).HasColumnName("ID_ESTADO").HasDefaultValueSql("1");
			});
			modelBuilder.Entity(delegate(EntityTypeBuilder<Entidades> entity)
			{
				entity.HasKey((Entidades e) => e.IdEntidad);
				entity.ToTable("ENTIDADES");
				entity.Property((Entidades e) => e.IdEntidad).HasColumnName("ID_ENTIDAD");
				entity.Property((Entidades e) => e.NombreClave).HasColumnName("NOMBRE_CLAVE");
				entity.Property((Entidades e) => e.Nombre).HasColumnName("NOMBRE").HasColumnType("text");
				entity.Property((Entidades e) => e.Apellido).HasColumnName("APELLIDO").HasColumnType("text");
				entity.Property((Entidades e) => e.Pais).HasColumnName("PAIS");
				entity.Property((Entidades e) => e.Ciudad).HasColumnName("CIUDAD");
				entity.Property((Entidades e) => e.Localidad).HasColumnName("LOCALIDAD").HasColumnType("text");
				entity.Property((Entidades e) => e.Calle).HasColumnName("CALLE");
				entity.Property((Entidades e) => e.Altura).HasColumnName("ALTURA");
				entity.Property((Entidades e) => e.CodigoPostal).HasColumnName("CODIGO_POSTAL");
				entity.Property((Entidades e) => e.Telefono1).HasColumnName("TELEFONO_1");
				entity.Property((Entidades e) => e.Telefono2).HasColumnName("TELEFONO_2");
				entity.Property((Entidades e) => e.Telefono3).HasColumnName("TELEFONO_3");
				entity.Property((Entidades e) => e.Email).HasColumnName("EMAIL");
				entity.Property((Entidades e) => e.IdFiscal).HasColumnName("ID_FISCAL");
				entity.Property((Entidades e) => e.FechaRegistro).HasColumnName("FECHA_REGISTRO").HasColumnType("timestamp");
				entity.Property((Entidades e) => e.IdUsuarioRegistro).HasColumnName("ID_USUARIO_REGISTRO").HasColumnType("varchar(50)")
					.IsRequired();
				entity.Property((Entidades x) => x.Barrio).HasColumnName("BARRIO").HasColumnType("text");
				entity.Property((Entidades x) => x.IdTipo).HasColumnName("ID_TIPO").HasColumnType("int");
				entity.Property((Entidades x) => x.IdCategoria).HasColumnName("ID_CATEGORIA").HasColumnType("int");
				entity.Property((Entidades e) => e.IdEstado).HasColumnName("ID_ESTADO").HasDefaultValueSql("(1)");
			});
		}
	}
	public class ArchivosMovimientosStock
	{
		public int IdMovimiento { get; set; }

		public string HashArchivo { get; set; } = string.Empty;


		public string PathArchivo { get; set; } = string.Empty;


		public string? MimeType { get; set; }

		public int IdEstado { get; set; } = 1;


		[ForeignKey("IdMovimiento")]
		public virtual Stock_Movimientos StockMovimiento { get; set; } = new Stock_Movimientos();


		public virtual EstadosArchivosMovimientosStock? ArchivosMovimientosStockNavigation { get; set; }
	}
	public class ComponentesDescripcion
	{
		[MessagePack.Key("ID_DESCRIPCION")]
		public int IdDescripcion { get; set; }

		public string? Descripcion { get; set; }

		public string IdAlmacenamiento { get; set; } = string.Empty;


		public string? IdFraccionamiento { get; set; }
	}
	public class ComponentesDetalle
	{
		[System.ComponentModel.DataAnnotations.Key]
		public string IdInsumo { get; set; } = string.Empty;


		public int IdDescripcion { get; set; }

		public decimal? Diametro { get; set; }

		public int? DiametroNominal { get; set; }

		public decimal? Espesor { get; set; }

		public decimal? Longitud { get; set; }

		public decimal? Altura { get; set; }

		public int? Perfil { get; set; }

		public string? Tolerancia { get; set; }

		public decimal? Peso { get; set; }

		public string? IdFraccionamiento { get; set; }

		public string? IdAlmacenamiento { get; set; }

		[ForeignKey("ID_ESTADO")]
		public int IdEstado { get; set; }

		[System.Text.Json.Serialization.JsonIgnore]
		public virtual EstadosComponentesDetalles IdEstadoNavigation { get; set; } = new EstadosComponentesDetalles();


		public virtual ICollection<ComprasDetalles> ComprasNavigation { get; set; } = new HashSet<ComprasDetalles>();

	}
	public class Compras
	{
		[System.ComponentModel.DataAnnotations.Key]
		[Column("ID_COMPRA")]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int IdCompra { get; set; }

		[Column("ID_PROVEEDOR")]
		public int IdProveedor { get; set; }

		[Column("FECHA_HORA")]
		public DateTime FechaHora { get; set; }

		[ForeignKey("ID_USUARIO")]
		public string IdUsuario { get; set; } = string.Empty;


		[Column("MONTO_TOTAL")]
		public decimal MontoTotal { get; set; }

		[Column("SALDO_PENDIENTE")]
		public decimal? SaldoPendiente { get; set; }

		[Column("ID_ESTADO_COMPRA")]
		public int IdEstadoCompra { get; set; }

		[NotMapped]
		public decimal SaldoCancelado => MontoTotal - SaldoPendiente.GetValueOrDefault();

		public virtual Entidades IdProveedorNavigation { get; set; } = new Entidades();


		public virtual Usuarios Usuario { get; set; } = new Usuarios();


		public virtual EstadosCompras Estado { get; set; } = new EstadosCompras();


		public virtual ICollection<ComprasDetalles> DetallesCompra { get; set; } = new HashSet<ComprasDetalles>();


		public virtual ICollection<PagosCompras> Pagos { get; set; } = new HashSet<PagosCompras>();


		public virtual ICollection<CuotasCompras> CuotasCompra { get; set; } = new HashSet<CuotasCompras>();

	}
	public class ComprasDetalles
	{
		[System.ComponentModel.DataAnnotations.Key]
		[ForeignKey("ID_COMPRA")]
		public int IdCompra { get; set; }

		[System.ComponentModel.DataAnnotations.Key]
		[ForeignKey("ID_INSUMO")]
		public string IdInsumo { get; set; } = string.Empty;


		[Column("CANTIDAD")]
		public int Cantidad { get; set; }

		public virtual ComponentesDetalle DetallesInsumo { get; set; } = new ComponentesDetalle();


		public virtual Compras Compra { get; set; } = new Compras();

	}
	public class CuotasCompras
	{
		[System.ComponentModel.DataAnnotations.Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ID_CUOTA")]
		public int IdCuota { get; set; }

		[ForeignKey("ID_COMPRA")]
		public int IdCompra { get; set; }

		[Column("NUMERO_CUOTA")]
		public int NumeroCuota { get; set; }

		[Column("MONTO")]
		public decimal Monto { get; set; }

		[Column("FECHA_VENCIMIENTO")]
		public DateTime FechaVencimiento { get; set; }

		[ForeignKey("ID_ESTADO_CUOTA")]
		public int IdEstadoCuota { get; set; }

		[Column("FECHA_PAGO")]
		public DateTime? FechaPago { get; set; }

		public virtual Compras CompraNavigation { get; set; } = new Compras();


		public virtual EstadosCuotasCompras EstadoCuotaCompra { get; set; } = new EstadosCuotasCompras();

	}
	public class CuotasVentas
	{
		[System.ComponentModel.DataAnnotations.Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ID_CUOTA")]
		public int IdCuota { get; set; }

		[ForeignKey("ID_VENTA")]
		public int IdVenta { get; set; }

		[Column("NUMERO_CUOTA")]
		public int NumeroCuota { get; set; }

		[Column("MONTO")]
		public decimal Monto { get; set; }

		[Column("FECHA_VENCIMIENTO")]
		public DateTime FechaVencimiento { get; set; }

		[ForeignKey("ID_ESTADO_CUOTA")]
		public int IdEstadoCuota { get; set; }

		[Column("FECHA_PAGO")]
		public DateTime? FechaPago { get; set; }

		public virtual Ventas Venta { get; set; } = new Ventas();


		public virtual EstadosCuotasVentas EstadoCuota { get; set; } = new EstadosCuotasVentas();

	}
	public class Entidades
	{
		[System.ComponentModel.DataAnnotations.Key]
		[Column("ID_ENTIDAD")]
		public int IdEntidad { get; set; }

		[Column("NOMBRE_CLAVE")]
		public string? NombreClave { get; set; }

		[Column("NOMBRE")]
		public string? Nombre { get; set; }

		[Column("APELLIDO")]
		public string? Apellido { get; set; }

		[Column("PAIS")]
		public string? Pais { get; set; }

		[Column("CIUDAD")]
		public string? Ciudad { get; set; }

		[Column("PROVINCIA")]
		public string? Provincia { get; set; }

		[Column("LOCALIDAD")]
		public string? Localidad { get; set; }

		[Column("BARRIO")]
		public string? Barrio { get; set; }

		[Column("CALLE")]
		public string? Calle { get; set; }

		[Column("ALTURA")]
		public string? Altura { get; set; }

		[Column("CODIGO_POSTAL")]
		public string? CodigoPostal { get; set; }

		[Column("TELEFONO_1")]
		public string? Telefono1 { get; set; }

		[Column("TELEFONO_2")]
		public string? Telefono2 { get; set; }

		[Column("TELEFONO_3")]
		public string? Telefono3 { get; set; }

		[Column("EMAIL")]
		public string? Email { get; set; }

		[Column("ID_FISCAL")]
		public string IdFiscal { get; set; } = string.Empty;


		[Column("FECHA_REGISTRO")]
		public DateTime FechaRegistro { get; set; }

		[ForeignKey("ID_USUARIO_REGISTRO")]
		public string IdUsuarioRegistro { get; set; } = string.Empty;


		[ForeignKey("ID_CATEGORIA")]
		public int IdCategoria { get; set; }

		[ForeignKey("ID_TIPO")]
		public int IdTipo { get; set; }

		[Column("ID_ESTADO")]
		public int IdEstado { get; set; }

		public virtual ICollection<Stock_Movimientos> Movimientos { get; set; } = new HashSet<Stock_Movimientos>();


		public virtual ICollection<Compras> compras { get; set; } = new HashSet<Compras>();


		public virtual ICollection<Ventas> ventas { get; set; } = new HashSet<Ventas>();


		public virtual Usuarios UsuarioRegistro { get; set; } = new Usuarios();


		public virtual EntidadesCategorias CategoriaEntidad { get; set; } = new EntidadesCategorias();


		public virtual EntidadesTipos TipoEntidad { get; set; } = new EntidadesTipos();

	}
	public class EntidadesCategorias
	{
		[System.ComponentModel.DataAnnotations.Key]
		[Column("ID_CATEGORIA")]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int IdCategoria { get; set; }

		[Column("NOMBRE_CATEGORIA")]
		public string NombreCategoria { get; set; } = string.Empty;


		[Column("ID_ESTADO")]
		public int IdEstado { get; set; }

		public virtual ICollection<Entidades> Entidades { get; set; } = new List<Entidades>();


		public virtual ICollection<EntidadesTiposCategorias> TiposCategoriasNavigation { get; set; } = new List<EntidadesTiposCategorias>();

	}
	public class EntidadesTipos
	{
		[System.ComponentModel.DataAnnotations.Key]
		[Column("ID_TIPO")]
		public int IdTipo { get; set; }

		[Column("NOMBRE")]
		public string NombreTipo { get; set; } = string.Empty;


		[Column("ID_ESTADO")]
		public int IdEstado { get; set; }

		public virtual ICollection<Entidades> Entidades { get; set; } = new List<Entidades>();


		public virtual ICollection<EntidadesTiposCategorias> TiposCategoriasNavigation { get; set; } = new List<EntidadesTiposCategorias>();

	}
	public class EntidadesTiposCategorias
	{
		[ForeignKey("ID_TIPO")]
		public int idTipoEntidad { get; set; }

		[ForeignKey("ID_CATEGORIA")]
		public int IdCategoriaEntidad { get; set; }

		public virtual EntidadesTipos TipoEntidad { get; set; } = new EntidadesTipos();


		public virtual EntidadesCategorias CategoriaEntidad { get; set; } = new EntidadesCategorias();

	}
	public class EstadosArchivosMovimientosStock
	{
		[System.ComponentModel.DataAnnotations.Key]
		[Column("ID_ESTADO")]
		public int IdEstado { get; set; } = 1;


		[Column("DESCRIPCION")]
		public string Descripcion { get; set; } = string.Empty;


		public virtual ICollection<ArchivosMovimientosStock> ArchivosMovimientoStock { get; set; } = new List<ArchivosMovimientosStock>();

	}
	public class EstadosComponentesDetalles
	{
		[System.ComponentModel.DataAnnotations.Key]
		[Column("ID_ESTADO")]
		public int IdEstado { get; set; }

		[Column("DESCRIPCION")]
		public string Descripcion { get; set; } = string.Empty;


		public virtual ICollection<ComponentesDetalle> ComponentesDetalle { get; set; } = new List<ComponentesDetalle>();

	}
	public class EstadosCompras
	{
		[System.ComponentModel.DataAnnotations.Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ID_ESTADO_COMPRA")]
		public int IdEstadoCompra { get; set; }

		[Column("DESCRIPCION")]
		public string Descripcion { get; set; } = string.Empty;


		[Column("ID_ESTADO")]
		public int IdEstado { get; set; }

		public virtual ICollection<Compras> compras { get; set; } = new HashSet<Compras>();

	}
	public class EstadosCuotasCompras
	{
		[System.ComponentModel.DataAnnotations.Key]
		[Column("ID_ESTADO_CUOTA")]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int IdEstadoCuota { get; set; }

		[Column("DESCRIPCION")]
		public string Descripcion { get; set; } = string.Empty;


		[Column("ID_ESTADO")]
		public int IdEstado { get; set; }

		public virtual ICollection<CuotasCompras> IdEstadoCuotaNavigation { get; set; } = new HashSet<CuotasCompras>();

	}
	public class EstadosCuotasVentas
	{
		[System.ComponentModel.DataAnnotations.Key]
		[Column("ID_ESTADO_CUOTA")]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int IdEstadoCuota { get; set; }

		[Column("DESCRIPCION")]
		public string Descripcion { get; set; } = string.Empty;


		[Column("ID_ESTADO")]
		public int IdEstado { get; set; }

		public virtual ICollection<CuotasVentas> IdEstadoCuotaNavigation { get; set; } = new HashSet<CuotasVentas>();

	}
	public class EstadosMovimientosStock
	{
		[System.ComponentModel.DataAnnotations.Key]
		[Column("ID_ESTADO_MOVIMIENTO")]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int? IdEstadoMovimiento { get; set; }

		[Column("DESCRIPCION")]
		public string Descripcion { get; set; } = string.Empty;


		[Column("ID_ESTADO_PROPIO")]
		public int IdEstado { get; set; }

		public virtual ICollection<Stock_Movimientos> movimientosStock { get; set; } = new List<Stock_Movimientos>();

	}
	public class EstadosProductos
	{
		[System.ComponentModel.DataAnnotations.Key]
		[Column("ID_ESTADO")]
		public int IdEstado { get; set; }

		[Column("DESCRIPCION")]
		public string Descripcion { get; set; } = string.Empty;


		public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();

	}
	public class EstadosProductosComponentes
	{
		[System.ComponentModel.DataAnnotations.Key]
		[Column("ID_ESTADO")]
		public int IdEstado { get; set; }

		[Column("DESCRIPCION")]
		public string Descripcion { get; set; } = string.Empty;


		public virtual ICollection<Productos_Componentes> ProductosComponentes { get; set; } = new List<Productos_Componentes>();

	}
	public class EstadosProductosDescripciones
	{
		[System.ComponentModel.DataAnnotations.Key]
		[Column("ID_ESTADO")]
		public int IdEstado { get; set; }

		[Column("DESCRIPCION")]
		public string Descripcion { get; set; } = string.Empty;


		public virtual ICollection<ProductosDescripcion> ProductosDescripcions { get; set; } = new List<ProductosDescripcion>();

	}
	public class EstadosSuministrosMovimientosStock
	{
		[System.ComponentModel.DataAnnotations.Key]
		[Column("ID_ESTADO")]
		public int IdEstado { get; set; } = 1;


		[Column("DESCRIPCION")]
		public string Descripcion { get; set; } = string.Empty;


		public virtual ICollection<SuministrosMovimientosStock>? SuministrosMovimientoStock { get; set; }
	}
	public class EstadosTiposProductos
	{
		[System.ComponentModel.DataAnnotations.Key]
		[Column("ID_ESTADO")]
		public int IdEstado { get; set; }

		[Column("DESCRIPCION")]
		public string Descripcion { get; set; } = string.Empty;


		public virtual ICollection<ProductosTipo> ProductosTipos { get; set; } = new List<ProductosTipo>();

	}
	public class EstadosVentas
	{
		[System.ComponentModel.DataAnnotations.Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ID_ESTADO_VENTA")]
		public int IdEstadoVenta { get; set; }

		[Column("DESCRIPCION")]
		public string Descripcion { get; set; } = string.Empty;


		[Column("ID_ESTADO")]
		public int IdEstado { get; set; }

		public virtual ICollection<Ventas> ventas { get; set; } = new HashSet<Ventas>();

	}
	public class MediosPago
	{
		[System.ComponentModel.DataAnnotations.Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ID_MEDIO_PAGO")]
		public int IdMedioPago { get; set; }

		[Column("CODIGO_MPAGO")]
		public string? CodigoMPago { get; set; }

		[Column("DESCRIPCION")]
		public string Descripcion { get; set; } = string.Empty;


		[Column("ID_ESTADO")]
		public int IdEstado { get; set; }

		public virtual ICollection<PagosCompras> PagosComprasNavigation { get; set; } = new HashSet<PagosCompras>();


		public virtual ICollection<PagosVentas> PagosVentasNavigation { get; set; } = new HashSet<PagosVentas>();

	}
	public class PagosCompras
	{
		[System.ComponentModel.DataAnnotations.Key]
		[Column("ID_PAGO", Order = 2)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int IdPago { get; set; }

		[ForeignKey("ID_COMPRA")]
		public int IdCompra { get; set; }

		[ForeignKey("ID_MEDIO_PAGO")]
		public int IdMedioPago { get; set; }

		[Column("MONTO")]
		public decimal Monto { get; set; }

		[Column("FECHA")]
		public DateTime? Fecha { get; set; }

		public virtual MediosPago MedioPago { get; set; } = new MediosPago();


		public virtual Compras Compra { get; set; } = new Compras();

	}
	public class PagosVentas
	{
		[System.ComponentModel.DataAnnotations.Key]
		[Column("ID_PAGO", Order = 2)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int IdPago { get; set; }

		[ForeignKey("ID_VENTA")]
		public int IdVenta { get; set; }

		[ForeignKey("ID_MEDIO_PAGO")]
		public int IdMedioPago { get; set; }

		[Column("MONTO")]
		public decimal Monto { get; set; }

		[Column("FECHA")]
		public DateTime? Fecha { get; set; }

		public virtual MediosPago MedioPago { get; set; } = new MediosPago();


		public virtual Ventas Venta { get; set; } = new Ventas();

	}
	public class PerfilesUsuarios
	{
		[System.ComponentModel.DataAnnotations.Key]
		[Column("ID_PERFIL")]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int IdPerfil { get; set; }

		[Column("DESCRIPCION")]
		public string Descripcion { get; set; } = string.Empty;


		[Column("ID_ESTADO")]
		public int IdEstado { get; set; }

		public virtual ICollection<Usuarios> UsuariosNavigation { get; set; } = new HashSet<Usuarios>();

	}
	public class Producto
	{
		public string IdProducto { get; set; } = null;


		public int IdDescripcion { get; set; }

		public string IdTipo { get; set; } = null;


		public int? DiametroNominal { get; set; }

		public string? Tolerancia { get; set; }

		public int? Cantidad { get; set; }

		public decimal? PrecioLista { get; set; }

		[Column(TypeName = "decimal(18,2)")]
		public decimal? PrecioFinal { get; set; }

		[Column(TypeName = "decimal(18,2)")]
		public decimal? PorcentajeGanancia { get; set; }

		[ForeignKey("ID_ESTADO")]
		public int IdEstado { get; set; }

		public virtual ProductosDescripcion IdDescripcionNavigation { get; set; } = null;


		public virtual ProductosTipo IdTipoNavigation { get; set; } = null;


		public virtual EstadosProductos IdEstadoNavigation { get; set; } = new EstadosProductos();


		public virtual ICollection<VentasDetalles> Ventas { get; set; } = null;

	}
	public class ProductosDescripcion
	{
		[Column("ID_DESCRIPCION")]
		public int IdDescripcion { get; set; }

		[Column("DESCRIPCION")]
		public string? DescripcionProducto { get; set; }

		[ForeignKey("ID_ESTADO")]
		public int IdEstado { get; set; }

		public virtual EstadosProductosDescripciones IdEstadoNavigation { get; set; } = new EstadosProductosDescripciones();


		public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();


		public virtual ICollection<Productos_Tipos_Descripcion> Producto_Tipo_Descripcione { get; set; } = new HashSet<Productos_Tipos_Descripcion>();

	}
	public class ProductosTipo
	{
		[Column("ID_TIPO")]
		public string IdTipo { get; set; } = null;


		[Column("DESCRIPCION")]
		public string? DescripcionTipo { get; set; }

		[ForeignKey("ID_ESTADO")]
		public int IdEstado { get; set; }

		public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();


		public virtual EstadosTiposProductos IdEstadoNavigation { get; set; } = new EstadosTiposProductos();


		public virtual ICollection<Productos_Tipos_Descripcion> Producto_Tipo_Descripcione { get; set; } = new HashSet<Productos_Tipos_Descripcion>();

	}
	public class Productos_Componentes
	{
		public string IdProducto { get; set; } = string.Empty;


		public string IdComponente { get; set; } = string.Empty;


		public decimal? Cantidad { get; set; }

		public decimal? Peso { get; set; }

		public decimal? Longitud { get; set; }

		[ForeignKey("ID_ESTADO")]
		public int IdEstado { get; set; }

		public virtual EstadosProductosComponentes IdEstadoNavigation { get; set; } = new EstadosProductosComponentes();

	}
	public class Productos_Tipos_Descripcion
	{
		[Column("ID_DESCRIPCION")]
		public int? IdDescripcion { get; set; }

		[Column("ID_TIPO")]
		public string IdTipo { get; set; } = string.Empty;


		public virtual ProductosTipo IdTipoNavigation { get; set; } = new ProductosTipo();


		public virtual ProductosDescripcion IdDescripcionNavigation { get; set; } = new ProductosDescripcion();

	}
	public class StockInsumos
	{
		public string IdInsumo { get; set; } = string.Empty;


		public decimal? Recibido { get; set; }

		public decimal? Granallado { get; set; }

		public decimal? Pintura { get; set; }

		public decimal? Proceso { get; set; }

		public decimal? Moldeado { get; set; }

		public decimal? Pendiente { get; set; }
	}
	public class Stock_Movimientos
	{
		[MessagePack.Key("ID_MOVIMIENTO")]
		[ForeignKey("ID_MOVIMIENTO")]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int IdMovimiento { get; set; }

		[Column("USUARIO_CREADO")]
		public string CreadoUsuario { get; set; } = "";


		[Column("FECHA_HORA_CREADO")]
		public DateTime FechaHoraCreado { get; set; }

		[Column("USUARIO_MODIFICA")]
		public string? ModificadoUsuario { get; set; }

		[Column("FECHA_HORA_ULTIMA_MODIFICACION")]
		public DateTime? FechaHoraUltimaModificacion { get; set; }

		[ForeignKey("ID_PROVEEDOR")]
		public int IdProveedor { get; set; }

		[Column("ORIGEN")]
		public string? Origen { get; set; }

		[Column("DESTINO")]
		public string? Destino { get; set; }

		[Column("TIPO")]
		public string? Tipo { get; set; }

		[Column("ID_ESTADO_MOVIMIENTO")]
		public int IdEstadoMovimiento { get; set; } = 1;


		public virtual Entidades? Proveeedor { get; set; }

		public virtual EstadosMovimientosStock? estadoMovimiento { get; set; }

		public virtual ICollection<SuministrosMovimientosStock>? Suministros { get; set; }
	}
	public class SuministrosMovimientosStock
	{
		[MessagePack.Key("ID_MOVIMIENTO")]
		public int IdMovimiento { get; set; }

		[MessagePack.Key("ID_SUMINISTRO")]
		public string IdSuministro { get; set; } = "";


		[Column("CANTIDAD")]
		public decimal Cantidad { get; set; }

		[Column("ID_ESTADO")]
		public int IdEstado { get; set; }

		public virtual EstadosSuministrosMovimientosStock? EstadosSuministrosMovimientosStockNavigation { get; set; } = new EstadosSuministrosMovimientosStock();

	}
	public class Usuarios
	{
		public string Usuario { get; set; } = "";


		public string Contraseña { get; set; } = "";


		public string Correo { get; set; } = "";


		public int IdPerfil { get; set; }

		public virtual ICollection<Entidades> IdUsuarioRegistroNavigation { get; set; } = new HashSet<Entidades>();


		public virtual ICollection<Compras> Compras { get; set; } = new HashSet<Compras>();


		public virtual ICollection<Ventas> Ventas { get; set; } = new HashSet<Ventas>();


		public virtual PerfilesUsuarios Perfil { get; set; } = new PerfilesUsuarios();

	}
	public class Ventas
	{
		[System.ComponentModel.DataAnnotations.Key]
		[Column("ID_VENTA")]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int IdVenta { get; set; }

		[Column("ID_CLIENTE")]
		public int IdCliente { get; set; }

		[Column("FECHA_HORA")]
		public DateTime FechaHora { get; set; }

		[ForeignKey("ID_USUARIO")]
		public string IdUsuario { get; set; } = "";


		[Column("MONTO_TOTAL")]
		public decimal MontoTotal { get; set; }

		[Column("SALDO_PENDIENTE")]
		public decimal? SaldoPendiente { get; set; }

		[Column("ID_ESTADO_VENTA")]
		public int IdEstadoVenta { get; set; }

		[NotMapped]
		public decimal SaldoCancelado => MontoTotal - SaldoPendiente.GetValueOrDefault();

		public virtual Entidades Cliente { get; set; } = new Entidades();


		public virtual Usuarios Usuario { get; set; } = new Usuarios();


		public virtual EstadosVentas Estado { get; set; } = new EstadosVentas();


		public virtual ICollection<VentasDetalles> DetallesVenta { get; set; } = new HashSet<VentasDetalles>();


		public virtual ICollection<PagosVentas> Pagos { get; set; } = new HashSet<PagosVentas>();


		public virtual ICollection<CuotasVentas> Cuotas { get; set; } = new HashSet<CuotasVentas>();

	}
	public class VentasDetalles
	{
		[System.ComponentModel.DataAnnotations.Key]
		[ForeignKey("ID_VENTA")]
		public int IdVenta { get; set; }

		[System.ComponentModel.DataAnnotations.Key]
		[ForeignKey("ID_PRODUCTO")]
		public string IdProducto { get; set; } = "";


		[Column("PRECIO")]
		public decimal Precio { get; set; }

		[Column("CANTIDAD")]
		public int Cantidad { get; set; }

		[Column("ENTREGADOS")]
		public int? Entregados { get; set; }

		public virtual Producto IdProductoNavigation { get; set; } = new Producto();


		public virtual Ventas Venta { get; set; } = new Ventas();

	}
}
namespace Aponus_Web_API.Migrations
{
	[DbContext(typeof(AponusContext))]
	[Migration("20240912011537_InitialCreate")]
	public class InitialCreate : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
		}

		protected override void BuildTargetModel(ModelBuilder modelBuilder)
		{
			modelBuilder.UseCollation("Modern_Spanish_CI_AI").HasAnnotation("ProductVersion", "7.0.11").HasAnnotation("Proxies:ChangeTracking", false)
				.HasAnnotation("Proxies:CheckEquality", false)
				.HasAnnotation("Proxies:LazyLoading", true)
				.HasAnnotation("Relational:MaxIdentifierLength", 63);
			modelBuilder.UseIdentityByDefaultColumns();
			modelBuilder.Entity("Aponus_Web_API.Modelos.ArchivosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdMovimiento").HasColumnType("int").HasColumnName("ID_MOVIMIENTO");
				b.Property<string>("HashArchivo").HasColumnType("varchar(255)").HasColumnName("HASH_ARCHIVO");
				b.Property<byte>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("Varbinary(1)")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("MimeType").HasColumnType("varchar(MAX)").HasColumnName("MIME_TYPE");
				b.Property<string>("PathArchivo").IsRequired().HasColumnType("varchar(MAX)")
					.HasColumnName("PATH");
				b.HasKey("IdMovimiento", "HashArchivo");
				b.HasIndex("IdEstadoMovimiento");
				b.ToTable("ARCHIVOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComponentesDescripcion", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdDescripcion").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_DESCRIPCION");
				b.Property<int>("IdDescripcion").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdDescripcion");
				b.ToTable("COMPONENTES_DESCRIPCION", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComponentesDetalle", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdInsumo").HasColumnType("varchar(50)").HasColumnName("ID_INSUMO");
				b.Property<decimal?>("Altura").HasColumnType("decimal(18,2)").HasColumnName("ALTURA");
				b.Property<decimal?>("Diametro").HasColumnType("decimal(18,2)").HasColumnName("DIAMETRO");
				b.Property<int?>("DiametroNominal").HasColumnType("int").HasColumnName("DIAMETRO_NOMINAL");
				b.Property<decimal?>("Espesor").HasColumnType("decimal(18,2)").HasColumnName("ESPESOR");
				b.Property<string>("IdAlmacenamiento").HasColumnType("nvarchar(50)").HasColumnName("ID_ALMACENAMIENTO");
				b.Property<int>("IdDescripcion").HasColumnType("integer").HasColumnName("ID_DESCRIPCION");
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("varbinary(1)")
					.HasDefaultValueSql("1");
				b.Property<string>("IdFraccionamiento").HasColumnType("nvarchar(50)").HasColumnName("ID_FRACCIONAMIENTO");
				b.Property<decimal?>("Longitud").HasColumnType("decimal(18,2)").HasColumnName("LONGITUD");
				b.Property<int?>("Perfil").HasColumnType("integer").HasColumnName("PERFIL");
				b.Property<decimal?>("Peso").HasColumnType("decimal(18,3)").HasColumnName("PESO");
				b.Property<string>("Tolerancia").HasColumnType("varchar(50)").HasColumnName("TOLERANCIA");
				b.HasKey("IdInsumo").HasName("PK_ID_INSUMO");
				b.HasIndex("IdEstadoMovimiento");
				b.ToTable("COMPONENTES_DETALLE", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Compras", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCompra").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_COMPRA")
					.HasAnnotation("SqlServer:Identity", "1, 1");
				b.Property<int>("IdCompra").UseIdentityByDefaultColumn();
				b.Property<DateTime>("FechaHora").HasColumnType("datetime").HasColumnName("FECHA_HORA");
				b.Property<int>("IdEstadoCompra").HasColumnType("int").HasColumnName("ID_ESTADO_COMPRA");
				b.Property<int>("IdProveedor").HasColumnType("int").HasColumnName("ID_PROVEEDOR");
				b.Property<string>("IdUsuario").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("ID_USUARIO");
				b.Property<decimal?>("SaldoPendiente").HasColumnType("decimal(18,2)").HasColumnName("SALDO_CANCELADO");
				b.Property<decimal>("MontoTotal").HasColumnType("decimal(18,2)").HasColumnName("SALDO_TOTAL");
				b.HasKey("IdCompra");
				b.HasIndex("IdEstadoCompra");
				b.HasIndex("IdProveedor");
				b.HasIndex("IdUsuario");
				b.ToTable("COMPRAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComprasDetalles", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCompra").HasColumnType("int").HasColumnName("ID_COMPRA");
				b.Property<string>("IdInsumo").HasColumnType("varchar(50)").HasColumnName("ID_INSUMO");
				b.Property<decimal>("Cantidad").HasColumnType("decimal(18,2)").HasColumnName("CANTIDAD");
				b.HasKey("IdCompra", "IdInsumo");
				b.HasIndex("IdInsumo");
				b.ToTable("COMPRAS_DETALLE", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.CuotasVentas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCuota").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_CUOTA")
					.HasAnnotation("SqlServer:Identity", "1, 1");
				b.Property<int>("IdCuota").UseIdentityByDefaultColumn();
				b.Property<DateTime?>("Fecha").HasColumnType("datetime").HasColumnName("FECHA_PAGO");
				b.Property<DateTime>("FechaVencimiento").HasColumnType("datetime").HasColumnName("FECHA_VENCIMIENTO");
				b.Property<int>("IdEstadoCuota").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_CUOTA")
					.HasDefaultValueSql("1");
				b.Property<int>("IdVenta").HasColumnType("int").HasColumnName("ID_VENTA");
				b.Property<decimal>("Monto").ValueGeneratedOnAdd().HasColumnType("decimal(18,2)")
					.HasColumnName("MONTO")
					.HasDefaultValueSql("0.00");
				b.Property<int>("NumeroCuota").HasColumnType("int").HasColumnName("NUMERO_CUOTA");
				b.HasKey("IdCuota");
				b.HasIndex("IdEstadoCuota");
				b.HasIndex("IdVenta");
				b.ToTable("CUOTAS_VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Entidades", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEntidad").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ENTIDAD");
				b.Property<int>("IdEntidad").UseIdentityByDefaultColumn();
				b.Property<string>("Altura").HasColumnType("text").HasColumnName("ALTURA");
				b.Property<string>("Apellido").HasColumnType("varchar(max)").HasColumnName("APELLIDO");
				b.Property<string>("Barrio").HasColumnType("varchar(max)").HasColumnName("BARRIO");
				b.Property<string>("Calle").HasColumnType("text").HasColumnName("CALLE");
				b.Property<string>("Ciudad").HasColumnType("text").HasColumnName("CIUDAD");
				b.Property<string>("CodigoPostal").HasColumnType("text").HasColumnName("CODIGO_POSTAL");
				b.Property<string>("Email").HasColumnType("text").HasColumnName("EMAIL");
				b.Property<DateTime>("FechaRegistro").HasColumnType("timestamp with time zone").HasColumnName("FECHA_REGISTRO");
				b.Property<int>("IdCategoria").HasColumnType("int").HasColumnName("ID_CATEGORIA");
				b.Property<byte>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("varbinary(1)")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("(1)");
				b.Property<string>("IdFiscal").IsRequired().HasColumnType("text")
					.HasColumnName("ID_FISCAL");
				b.Property<int>("IdTipo").HasColumnType("int").HasColumnName("ID_TIPO");
				b.Property<string>("IdUsuarioRegistro").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("ID_USUARIO_REGISTRO");
				b.Property<string>("Localidad").HasColumnType("varchar(MAX)").HasColumnName("LOCALIDAD");
				b.Property<string>("Nombre").HasColumnType("varchar(max)").HasColumnName("NOMBRE");
				b.Property<string>("NombreClave").IsRequired().HasColumnType("text")
					.HasColumnName("NOMBRE_CLAVE");
				b.Property<string>("Pais").HasColumnType("text").HasColumnName("PAIS");
				b.Property<string>("Provincia").HasColumnType("text").HasColumnName("PROVINCIA");
				b.Property<string>("Telefono1").HasColumnType("text").HasColumnName("TELEFONO_1");
				b.Property<string>("Telefono2").HasColumnType("text").HasColumnName("TELEFONO_2");
				b.Property<string>("Telefono3").HasColumnType("text").HasColumnName("TELEFONO_3");
				b.HasKey("IdEntidad");
				b.HasIndex("IdCategoria");
				b.HasIndex("IdTipo");
				b.HasIndex("IdUsuarioRegistro");
				b.ToTable("ENTIDADES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesCategorias", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCategoria").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_CATEGORIA")
					.HasAnnotation("SqlServer:Identity", "1, 1");
				b.Property<int>("IdCategoria").UseIdentityByDefaultColumn();
				b.Property<byte>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("varbinary(1)")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("NombreCategoria").IsRequired().HasColumnType("nvarchar(max)")
					.HasColumnName("NOMBRE_CATEGORIA");
				b.HasKey("IdCategoria");
				b.ToTable("ENTIDADES_CATEGORIAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesTipos", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdTipo").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_TIPO")
					.HasAnnotation("SqlServer:Identity", "1, 1");
				b.Property<int>("IdTipo").UseIdentityByDefaultColumn();
				b.Property<byte>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("varbinary(1)")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("NombreTipo").IsRequired().HasColumnType("nvarchar(max)")
					.HasColumnName("NOMBRE");
				b.HasKey("IdTipo");
				b.ToTable("ENTIDADES_TIPOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesTiposCategorias", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("idTipoEntidad").HasColumnType("int").HasColumnName("ID_TIPO");
				b.Property<int>("IdCategoriaEntidad").HasColumnType("int").HasColumnName("ID_CATEGORIA");
				b.HasKey("idTipoEntidad", "IdCategoriaEntidad");
				b.HasIndex("IdCategoriaEntidad");
				b.ToTable("ENTIDADES_TIPOS_CATEGORIAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosArchivosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<byte>("IdEstadoMovimiento").HasColumnType("varbinary(1)").HasColumnName("ID_ESTADO");
				b.Property<string>("Descripcion").IsRequired().HasColumnType("nvarchar(max)")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstadoMovimiento");
				b.ToTable("ESTADOS_ARCHIVOS_MOVIMIENTOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosComponentesDetalles", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("varbinary(1)")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstadoMovimiento").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("nvarchar(max)")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstadoMovimiento");
				b.ToTable("EstadosComponentesDetalle");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCompras", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoCompra").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_COMPRA")
					.HasAnnotation("SqlServer:Identity", "1, 1");
				b.Property<int>("IdEstadoCompra").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("nvarchar(max)")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstadoMovimiento").HasColumnType("int").HasColumnName("ID_ESTADO");
				b.HasKey("IdEstadoCompra");
				b.ToTable("ESTADOS_COMPRAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCuotasVentas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoCuota").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_CUOTA")
					.HasAnnotation("SqlServer:Identity", "1, 1");
				b.Property<int>("IdEstadoCuota").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("varchar(MAX)")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.HasKey("IdEstadoCuota");
				b.ToTable("ESTADOS_CUOTAS_VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int?>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO");
				b.Property<int?>("IdEstadoMovimiento").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("nvarchar(max)")
					.HasColumnName("DESCRIPCION");
				b.Property<byte?>("IdEstadoPropio").ValueGeneratedOnAdd().HasColumnType("varbinary(1)")
					.HasColumnName("ID_ESTADO_PROPIO")
					.HasDefaultValueSql("1");
				b.HasKey("IdEstadoMovimiento");
				b.ToTable("ESTADOS_MOVIMIENTOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductos", delegate(EntityTypeBuilder b)
			{
				b.Property<byte>("IdEstadoMovimiento").HasColumnType("varbinary(1)").HasColumnName("ID_ESTADO");
				b.Property<string>("Descripcion").IsRequired().HasColumnType("nvarchar(max)")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstadoMovimiento");
				b.ToTable("EstadosProducto");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductosComponentes", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("varbinary(1)")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstadoMovimiento").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("nvarchar(max)")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstadoMovimiento");
				b.ToTable("EstadosProductosComponente");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductosDescripciones", delegate(EntityTypeBuilder b)
			{
				b.Property<byte>("IdEstadoMovimiento").HasColumnType("varbinary(1)").HasColumnName("ID_ESTADO");
				b.Property<string>("Descripcion").IsRequired().HasColumnType("nvarchar(max)")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstadoMovimiento");
				b.ToTable("ESTADOS_PRODUCTOS_DESCRIPCIONES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosSuministrosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<byte>("IdEstadoMovimiento").HasColumnType("varbinary(1)").HasColumnName("ID_ESTADO");
				b.Property<string>("Descripcion").IsRequired().HasColumnType("nvarchar(max)")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstadoMovimiento");
				b.ToTable("ESTADOS_SUMINISTROS_MOVIMIENTOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosTiposProductos", delegate(EntityTypeBuilder b)
			{
				b.Property<byte>("IdEstadoMovimiento").HasColumnType("varbinary(1)").HasColumnName("ID_ESTADO");
				b.Property<string>("Descripcion").IsRequired().HasColumnType("nvarchar(max)")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstadoMovimiento");
				b.ToTable("ESTADOS_PRODUCTOS_TIPOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosVentas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoVenta").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_VENTA")
					.HasAnnotation("SqlServer:Identity", "1, 1");
				b.Property<int>("IdEstadoVenta").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("nvarchar(max)")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("int")
					.HasDefaultValue(1)
					.HasColumnName("ID_ESTADO");
				b.HasKey("IdEstadoVenta");
				b.ToTable("ESTADOS_VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.MediosPago", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdMedioPago").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_MEDIO_PAGO")
					.HasAnnotation("SqlServer:Identity", "1,1");
				b.Property<int>("IdMedioPago").UseIdentityByDefaultColumn();
				b.Property<string>("CodigoMPago").HasColumnType("nvarchar(max)").HasColumnName("CODIGO_MPAGO");
				b.Property<string>("Descripcion").IsRequired().HasColumnType("nvarchar(max)")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("int")
					.HasDefaultValue(1)
					.HasColumnName("ID_ESTADO");
				b.HasKey("IdMedioPago");
				b.ToTable("MEDIOS_PAGO", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PagosCompras", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdPago").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_PAGO")
					.HasColumnOrder(2)
					.HasAnnotation("SqlServer:Identity", "1,1");
				b.Property<int>("IdPago").UseIdentityByDefaultColumn();
				b.Property<int?>("CantidadCuotas").HasColumnType("int").HasColumnName("CANTIDAD_CUOTAS");
				b.Property<int?>("CantidadCuotasCanceladas").HasColumnType("int").HasColumnName("CANTIDAD_CUOTAS_CANCELADAS");
				b.Property<int>("IdCompra").HasColumnType("int").HasColumnName("ID_COMPRA");
				b.Property<int>("IdMedioPago").HasColumnType("int").HasColumnName("ID_MEDIO_PAGO");
				b.Property<decimal>("Monto").HasColumnType("decimal(18,2)").HasColumnName("SUBTOTAL");
				b.Property<decimal?>("SaldoPendiente").HasColumnType("decimal(18,2)").HasColumnName("SUBTOTAL_CANCELADO");
				b.Property<decimal>("MontoCompra").HasColumnType("decimal(18,2)").HasColumnName("TOTAL");
				b.HasKey("IdPago");
				b.HasIndex("IdCompra");
				b.HasIndex("IdMedioPago");
				b.ToTable("PAGOS_COMPRAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PagosVentas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdPago").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_PAGO")
					.HasColumnOrder(2)
					.HasAnnotation("SqlServer:Identity", "1,1");
				b.Property<int>("IdPago").UseIdentityByDefaultColumn();
				b.Property<DateTime?>("Fecha").HasColumnType("datetime").HasColumnName("FECHA");
				b.Property<int>("IdMedioPago").HasColumnType("int").HasColumnName("ID_MEDIO_PAGO");
				b.Property<int>("IdVenta").HasColumnType("int").HasColumnName("ID_VENTA");
				b.Property<decimal>("Monto").HasColumnType("decimal(18,2)").HasColumnName("MONTO");
				b.HasKey("IdPago");
				b.HasIndex("IdMedioPago");
				b.HasIndex("IdVenta");
				b.ToTable("PAGOS_VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Producto", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdProducto").HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("ID_PRODUCTO");
				b.Property<int?>("Cantidad").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("CANTIDAD")
					.HasDefaultValueSql("((0))");
				b.Property<int?>("DiametroNominal").HasColumnType("integer").HasColumnName("DIAMETRO_NOMINAL");
				b.Property<int>("IdDescripcion").HasColumnType("integer").HasColumnName("ID_DESCRIPCION");
				b.Property<byte>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("varbinary(1)")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("IdTipo").IsRequired().HasMaxLength(50)
					.IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("ID_TIPO");
				b.Property<decimal?>("PorcentajeGanancia").HasColumnType("decimal(18,2)").HasColumnName("PORCENTAJE_GANANCIA");
				b.Property<decimal?>("PrecioFinal").HasColumnType("decimal(18,2)").HasColumnName("PRECIO_FINAL");
				b.Property<decimal?>("PrecioLista").ValueGeneratedOnAdd().HasColumnType("money")
					.HasColumnName("PRECIO_LISTA")
					.HasDefaultValueSql("((0))");
				b.Property<string>("Tolerancia").HasColumnType("text").HasColumnName("TOLERANCIA");
				b.HasKey("IdProducto");
				b.HasIndex("IdDescripcion");
				b.HasIndex("IdEstadoMovimiento");
				b.HasIndex("IdTipo");
				b.ToTable("PRODUCTOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosDescripcion", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdDescripcion").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_DESCRIPCION");
				b.Property<int>("IdDescripcion").UseIdentityByDefaultColumn();
				b.Property<string>("DescripcionProducto").HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("DESCRIPCION");
				b.Property<byte>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("varbinary(1)")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.HasKey("IdDescripcion");
				b.HasIndex("IdEstadoMovimiento");
				b.ToTable("PRODUCTOS_DESCRIPCION", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosTipo", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdTipo").HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("ID_TIPO");
				b.Property<string>("DescripcionTipo").HasMaxLength(100).IsUnicode(unicode: false)
					.HasColumnType("character varying(100)")
					.HasColumnName("DESCRIPCION");
				b.Property<byte>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("varbinary(1)")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.HasKey("IdTipo").HasName("PK_Table_1");
				b.HasIndex("IdEstadoMovimiento");
				b.ToTable("PRODUCTOS_TIPOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Productos_Componentes", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdProducto").HasColumnType("varchar(50)").HasColumnName("ID_PRODUCTO");
				b.Property<string>("IdComponente").HasColumnType("varchar(50)").HasColumnName("ID_COMPONENTE");
				b.Property<decimal?>("Cantidad").HasColumnType("decimal(18,2)").HasColumnName("CANTIDAD");
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("varbinary(1)")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<decimal?>("Longitud").HasColumnType("decimal(18,2)").HasColumnName("LONGITUD");
				b.Property<decimal?>("Peso").HasColumnType("decimal(18,2)").HasColumnName("PESO");
				b.HasKey("IdProducto", "IdComponente").HasName("PK_PRODUCTOS_COMPONENTES");
				b.HasIndex("IdEstadoMovimiento");
				b.ToTable("PRODUCTOS_COMPONENTES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Productos_Tipos_Descripcion", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdTipo").HasColumnType("text").HasColumnName("ID_TIPO");
				b.Property<int?>("IdDescripcion").HasColumnType("integer").HasColumnName("ID_DESCRIPCION");
				b.HasKey("IdTipo", "IdDescripcion");
				b.ToTable("PRODUCTOS_TIPOS_DESCRIPCION", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.StockInsumos", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdInsumo").HasColumnType("varchar(50)").HasColumnName("ID_INSUMO");
				b.Property<decimal?>("Granallado").HasColumnType("decimal").HasColumnName("GRANALLADO");
				b.Property<decimal?>("Moldeado").HasColumnType("decimal").HasColumnName("MOLDEADO");
				b.Property<decimal?>("Pendiente").HasColumnType("decimal(18,2)").HasColumnName("PENDIENTE");
				b.Property<decimal?>("Pintura").HasColumnType("decimal").HasColumnName("PINTURA");
				b.Property<decimal?>("Proceso").HasColumnType("decimal").HasColumnName("PROCESO");
				b.Property<decimal?>("Recibido").HasColumnType("decimal").HasColumnName("RECIBIDO");
				b.HasKey("IdInsumo").HasName("PK_STOCK_INSUMOS");
				b.ToTable("STOCK_INSUMOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Stock_Movimientos", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdMovimiento").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_MOVIMIENTO");
				b.Property<int>("IdMovimiento").UseIdentityByDefaultColumn();
				b.Property<string>("CreadoUsuario").IsRequired().HasColumnType("nvarchar(50)")
					.HasColumnName("USUARIO_CREADO");
				b.Property<string>("Destino").HasColumnType("varchar(50)").HasColumnName("DESTINO");
				b.Property<DateTime>("FechaHoraCreado").HasColumnType("datetime2(7)").HasColumnName("FECHA_HORA_CREADO");
				b.Property<DateTime?>("FechaHoraUltimaModificacion").HasColumnType("datetime2(7)").HasColumnName("FECHA_HORA_ULTIMA_MODIFICACION");
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<int>("IdEntidad").HasColumnType("int").HasColumnName("ID_PROVEEDOR_DESTINO");
				b.Property<int>("IdProveedorOrigen").HasColumnType("int").HasColumnName("ID_PROVEEDOR_ORIGEN");
				b.Property<string>("ModificadoUsuario").IsRequired().HasColumnType("nvarchar(50)")
					.HasColumnName("USUARIO_MODIFICA");
				b.Property<string>("Origen").HasColumnType("varchar(50)").HasColumnName("ORIGEN");
				b.Property<string>("Tipo").HasColumnType("varchar(15)").HasColumnName("TIPO");
				b.HasKey("IdMovimiento");
				b.HasIndex("IdEstadoMovimiento");
				b.HasIndex("IdEntidad");
				b.HasIndex("IdProveedorOrigen");
				b.ToTable("Stock_Movimientos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.SuministrosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdMovimiento").HasColumnType("int").HasColumnName("ID_MOVIMIENTO");
				b.Property<string>("IdSuministro").HasColumnType("nvarchar(50)").HasColumnName("ID_SUMINISTRO");
				b.Property<decimal>("Cantidad").HasColumnType("decimal(18,2)").HasColumnName("CANTIDAD");
				b.Property<byte>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("Varbinary(1)")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<decimal?>("ValorAnteriorDestino").HasColumnType("decimal(18,2)").HasColumnName("VALOR_ANTERIOR_DESTINO");
				b.Property<decimal?>("ValorAnteriorOrigen").HasColumnType("decimal(18,2)").HasColumnName("VALOR_ANTERIOR_ORIGEN");
				b.Property<decimal?>("ValorNuevoDestino").HasColumnType("numeric").HasColumnName("VALOR_NUEVO_DESTINO");
				b.Property<decimal?>("ValorNuevoOrigen").HasColumnType("decimal(18,2)").HasColumnName("VALOR_NUEVO_ORIGEN");
				b.HasKey("IdMovimiento", "IdSuministro");
				b.HasIndex("IdEstadoMovimiento");
				b.ToTable("SUMINISTROS_MOVIMIENTOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Usuarios", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("Usuario").HasColumnType("varchar(50)").HasColumnName("USUARIO");
				b.Property<string>("Contraseña").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("CONTRASEÑA");
				b.Property<int>("IdPerfil").HasColumnType("int").HasColumnName("ID_PERFIL");
				b.Property<string>("Correo").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("CORREO");
				b.HasKey("Usuario");
				b.ToTable("Usuarios");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Ventas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdVenta").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_VENTA")
					.HasAnnotation("SqlServer:Identity", "1, 1");
				b.Property<int>("IdVenta").UseIdentityByDefaultColumn();
				b.Property<DateTime>("FechaHora").HasColumnType("datetime").HasColumnName("FECHA_HORA");
				b.Property<int>("IdEntidad").HasColumnType("int").HasColumnName("ID_CLIENTE");
				b.Property<int>("IdEstadoVenta").HasColumnType("int").HasColumnName("ID_ESTADO_VENTA");
				b.Property<string>("IdUsuario").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("ID_USUARIO");
				b.Property<decimal>("SaldoPendiente").HasColumnType("numeric").HasColumnName("SALDO_PENDIENTE");
				b.Property<decimal>("MontoCompra").HasColumnType("decimal(18,2)").HasColumnName("TOTAL");
				b.HasKey("IdVenta");
				b.HasIndex("IdEntidad");
				b.HasIndex("IdEstadoVenta");
				b.HasIndex("IdUsuario");
				b.ToTable("VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.VentasDetalles", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdVenta").HasColumnType("int").HasColumnName("ID_VENTA");
				b.Property<string>("IdProducto").HasColumnType("varchar(50)").HasColumnName("ID_PRODUCTO");
				b.Property<decimal>("Cantidad").HasColumnType("decimal(18,2)").HasColumnName("CANTIDAD");
				b.Property<int?>("Entregados").HasColumnType("integer").HasColumnName("ENTREGADOS");
				b.Property<decimal>("Precio").HasColumnType("decimal(18,2)").HasColumnName("PRECIO");
				b.HasKey("IdVenta", "IdProducto");
				b.HasIndex("IdProducto");
				b.ToTable("VENTAS_DETALLES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ArchivosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosArchivosMovimientosStock", "ArchivosMovimientosStockNavigation").WithMany("ArchivosMovimientoStock").HasForeignKey("IdEstadoMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Stock_Movimientos", "StockMovimiento").WithMany().HasForeignKey("IdMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("ArchivosMovimientosStockNavigation");
				b.Navigation("StockMovimiento");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComponentesDetalle", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosComponentesDetalles", "IdEstadoNavigation").WithMany("ComponentesDetalle").HasForeignKey("IdEstadoMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdEstadoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Compras", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosCompras", "Estado").WithMany("compras").HasForeignKey("IdEstadoCompra")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Entidades", "IdProveedor").WithMany("compras").HasForeignKey("IdProveedor")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Usuarios", "Usuario").WithMany("Compras").HasForeignKey("IdUsuario")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired();
				b.Navigation("Estado");
				b.Navigation("IdProveedor");
				b.Navigation("Usuario");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComprasDetalles", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Compras", "CompraNavigation").WithMany("DetallesCompra").HasForeignKey("IdCompra")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.ComponentesDetalle", "DetallesInsumo").WithMany("ComprasNavigation").HasForeignKey("IdInsumo")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("CompraNavigation");
				b.Navigation("DetallesInsumo");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.CuotasVentas", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosCuotasVentas", "EstadoCuota").WithMany("IdEstadoCuotaNavigation").HasForeignKey("IdEstadoCuota")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Ventas", "Venta").WithMany("Cuotas").HasForeignKey("IdVenta")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("EstadoCuota");
				b.Navigation("Venta");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Entidades", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EntidadesCategorias", "CategoriaEntidad").WithMany("Entidades").HasForeignKey("IdCategoria")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.EntidadesTipos", "TipoEntidad").WithMany("Entidades").HasForeignKey("IdTipo")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Usuarios", "UsuarioRegistro").WithMany("IdUsuarioRegistroNavigation").HasForeignKey("IdUsuarioRegistro")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("CategoriaEntidad");
				b.Navigation("TipoEntidad");
				b.Navigation("UsuarioRegistro");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesTiposCategorias", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EntidadesCategorias", "CategoriaEntidad").WithMany("TiposCategoriasNavigation").HasForeignKey("IdCategoriaEntidad")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.EntidadesTipos", "TipoEntidad").WithMany("TiposCategoriasNavigation").HasForeignKey("idTipoEntidad")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("CategoriaEntidad");
				b.Navigation("TipoEntidad");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PagosCompras", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Compras", "CompraNavigation").WithMany("Pagos").HasForeignKey("IdCompra")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.MediosPago", "MedioPago").WithMany("PagosComprasNavigation").HasForeignKey("IdMedioPago")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("CompraNavigation");
				b.Navigation("MedioPago");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PagosVentas", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.MediosPago", "MedioPago").WithMany("PagosVentasNavigation").HasForeignKey("IdMedioPago")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Ventas", "Venta").WithMany("Pagos").HasForeignKey("IdVenta")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("MedioPago");
				b.Navigation("Venta");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Producto", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.ProductosDescripcion", "IdDescripcionNavigation").WithMany("StockInsumos").HasForeignKey("IdDescripcion")
					.IsRequired()
					.HasConstraintName("FK_PRODUCTOS_PRODUCTOS_DESCRIPCION");
				b.HasOne("Aponus_Web_API.Modelos.EstadosProductos", "IdEstadoNavigation").WithMany("StockInsumos").HasForeignKey("IdEstadoMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.ProductosTipo", "IdTipoNavigation").WithMany("StockInsumos").HasForeignKey("IdTipo")
					.IsRequired()
					.HasConstraintName("FK_PRODUCTOS_PRODUCTOS_TIPOS");
				b.Navigation("IdDescripcionNavigation");
				b.Navigation("IdEstadoNavigation");
				b.Navigation("IdTipoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosDescripcion", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosProductosDescripciones", "IdEstadoNavigation").WithMany("ProductosDescripcions").HasForeignKey("IdEstadoMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdEstadoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosTipo", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosTiposProductos", "IdEstadoNavigation").WithMany("ProductosTipos").HasForeignKey("IdEstadoMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdEstadoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Productos_Componentes", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosProductosComponentes", "IdEstadoNavigation").WithMany("ProductosComponentes").HasForeignKey("IdEstadoMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdEstadoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Stock_Movimientos", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosMovimientosStock", "estadoMovimiento").WithMany("movimientosStock").HasForeignKey("IdEstadoMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Entidades", "IdProveedor").WithMany("Movimientos").HasForeignKey("IdEntidad")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Entidades", "IdProveedorNavigation").WithMany("Movimientos").HasForeignKey("IdProveedor")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdProveedor");
				b.Navigation("IdProveedorNavigation");
				b.Navigation("estadoMovimiento");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.SuministrosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosSuministrosMovimientosStock", "EstadosSuministrosMovimientosStockNavigation").WithMany("SuministrosMovimientoStock").HasForeignKey("IdEstadoMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Stock_Movimientos", null).WithMany("Suministros").HasForeignKey("IdMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("EstadosSuministrosMovimientosStockNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Ventas", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Entidades", "Cliente").WithMany("ventas").HasForeignKey("IdEntidad")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.EstadosVentas", "Estado").WithMany("ventas").HasForeignKey("IdEstadoVenta")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Usuarios", "Usuario").WithMany("Ventas").HasForeignKey("IdUsuario")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired();
				b.Navigation("Cliente");
				b.Navigation("Estado");
				b.Navigation("Usuario");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.VentasDetalles", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Producto", "IdProductoNavigation").WithMany("Ventas").HasForeignKey("IdProducto")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_VENTAS_DETALLES_PRODUCTOS_ID_PRODUCTO");
				b.HasOne("Aponus_Web_API.Modelos.Ventas", "Venta").WithMany("DetallesVenta").HasForeignKey("IdVenta")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdProductoNavigation");
				b.Navigation("Venta");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComponentesDetalle", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ComprasNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Compras", delegate(EntityTypeBuilder b)
			{
				b.Navigation("DetallesCompra");
				b.Navigation("Pagos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Entidades", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Movimientos");
				b.Navigation("MovimientosOrigen");
				b.Navigation("compras");
				b.Navigation("ventas");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesCategorias", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Entidades");
				b.Navigation("TiposCategoriasNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesTipos", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Entidades");
				b.Navigation("TiposCategoriasNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosArchivosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ArchivosMovimientoStock");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosComponentesDetalles", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ComponentesDetalle");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCompras", delegate(EntityTypeBuilder b)
			{
				b.Navigation("compras");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCuotasVentas", delegate(EntityTypeBuilder b)
			{
				b.Navigation("IdEstadoCuotaNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Navigation("movimientosStock");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductos", delegate(EntityTypeBuilder b)
			{
				b.Navigation("StockInsumos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductosComponentes", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ProductosComponentes");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductosDescripciones", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ProductosDescripcions");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosSuministrosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Navigation("SuministrosMovimientoStock");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosTiposProductos", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ProductosTipos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosVentas", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ventas");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.MediosPago", delegate(EntityTypeBuilder b)
			{
				b.Navigation("PagosComprasNavigation");
				b.Navigation("PagosVentasNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Producto", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Ventas");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosDescripcion", delegate(EntityTypeBuilder b)
			{
				b.Navigation("StockInsumos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosTipo", delegate(EntityTypeBuilder b)
			{
				b.Navigation("StockInsumos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Stock_Movimientos", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Suministros");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Usuarios", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Compras");
				b.Navigation("IdUsuarioRegistroNavigation");
				b.Navigation("Ventas");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Ventas", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Cuotas");
				b.Navigation("DetallesVenta");
				b.Navigation("Pagos");
			});
		}
	}
	[DbContext(typeof(AponusContext))]
	[Migration("20240920071613_PERFILES_USUARIOS")]
	public class PERFILESUSUARIOS : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateIndex("IX_USUARIOS_ID_PERFIL", "USUARIOS", "ID_PERFIL");
			migrationBuilder.AddForeignKey("FK_USUARIOS_PERFILES_USUARIOS_ID_PERFIL", "USUARIOS", "ID_PERFIL", "USUARIOS_PERFILES", null, null, "ID_PERFIL", ReferentialAction.NoAction, ReferentialAction.Cascade);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
		}

		protected override void BuildTargetModel(ModelBuilder modelBuilder)
		{
			modelBuilder.UseCollation("Modern_Spanish_CI_AI").HasAnnotation("ProductVersion", "7.0.11").HasAnnotation("Proxies:ChangeTracking", false)
				.HasAnnotation("Proxies:CheckEquality", false)
				.HasAnnotation("Proxies:LazyLoading", true)
				.HasAnnotation("Relational:MaxIdentifierLength", 63);
			modelBuilder.UseIdentityByDefaultColumns();
			modelBuilder.Entity("Aponus_Web_API.Modelos.ArchivosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdMovimiento").HasColumnType("int").HasColumnName("ID_MOVIMIENTO");
				b.Property<string>("HashArchivo").HasColumnType("varchar(255)").HasColumnName("HASH_ARCHIVO");
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("MimeType").HasColumnType("varchar(MAX)").HasColumnName("MIME_TYPE");
				b.Property<string>("PathArchivo").IsRequired().HasColumnType("varchar(MAX)")
					.HasColumnName("PATH");
				b.HasKey("IdMovimiento", "HashArchivo");
				b.HasIndex("IdEstadoMovimiento");
				b.ToTable("ARCHIVOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComponentesDescripcion", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdDescripcion").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_DESCRIPCION");
				b.Property<int>("IdDescripcion").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdDescripcion");
				b.ToTable("COMPONENTES_DESCRIPCION", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComponentesDetalle", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdInsumo").HasColumnType("varchar(50)").HasColumnName("ID_INSUMO");
				b.Property<decimal?>("Altura").HasColumnType("decimal(18,2)").HasColumnName("ALTURA");
				b.Property<decimal?>("Diametro").HasColumnType("decimal(18,2)").HasColumnName("DIAMETRO");
				b.Property<int?>("DiametroNominal").HasColumnType("int").HasColumnName("DIAMETRO_NOMINAL");
				b.Property<decimal?>("Espesor").HasColumnType("decimal(18,2)").HasColumnName("ESPESOR");
				b.Property<string>("IdAlmacenamiento").HasColumnType("nvarchar(50)").HasColumnName("ID_ALMACENAMIENTO");
				b.Property<int>("IdDescripcion").HasColumnType("integer").HasColumnName("ID_DESCRIPCION");
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasDefaultValueSql("1");
				b.Property<string>("IdFraccionamiento").HasColumnType("nvarchar(50)").HasColumnName("ID_FRACCIONAMIENTO");
				b.Property<decimal?>("Longitud").HasColumnType("decimal(18,2)").HasColumnName("LONGITUD");
				b.Property<int?>("Perfil").HasColumnType("integer").HasColumnName("PERFIL");
				b.Property<decimal?>("Peso").HasColumnType("decimal(18,3)").HasColumnName("PESO");
				b.Property<string>("Tolerancia").HasColumnType("varchar(50)").HasColumnName("TOLERANCIA");
				b.HasKey("IdInsumo").HasName("PK_ID_INSUMO");
				b.HasIndex("IdEstadoMovimiento");
				b.ToTable("COMPONENTES_DETALLE", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Compras", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCompra").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_COMPRA");
				b.Property<int>("IdCompra").UseIdentityByDefaultColumn();
				b.Property<DateTime>("FechaHora").HasColumnType("datetime").HasColumnName("FECHA_HORA");
				b.Property<int>("IdEstadoCompra").HasColumnType("int").HasColumnName("ID_ESTADO_COMPRA");
				b.Property<int>("IdProveedor").HasColumnType("int").HasColumnName("ID_PROVEEDOR");
				b.Property<string>("IdUsuario").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("ID_USUARIO");
				b.Property<decimal?>("SaldoPendiente").HasColumnType("decimal(18,2)").HasColumnName("SALDO_CANCELADO");
				b.Property<decimal>("MontoTotal").HasColumnType("decimal(18,2)").HasColumnName("SALDO_TOTAL");
				b.HasKey("IdCompra");
				b.HasIndex("IdEstadoCompra");
				b.HasIndex("IdProveedor");
				b.HasIndex("IdUsuario");
				b.ToTable("COMPRAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComprasDetalles", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCompra").HasColumnType("int").HasColumnName("ID_COMPRA");
				b.Property<string>("IdInsumo").HasColumnType("varchar(50)").HasColumnName("ID_INSUMO");
				b.Property<decimal>("Cantidad").HasColumnType("decimal(18,2)").HasColumnName("CANTIDAD");
				b.HasKey("IdCompra", "IdInsumo");
				b.HasIndex("IdInsumo");
				b.ToTable("COMPRAS_DETALLE", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.CuotasVentas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCuota").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_CUOTA");
				b.Property<int>("IdCuota").UseIdentityByDefaultColumn();
				b.Property<DateTime?>("Fecha").HasColumnType("datetime").HasColumnName("FECHA_PAGO");
				b.Property<DateTime>("FechaVencimiento").HasColumnType("datetime").HasColumnName("FECHA_VENCIMIENTO");
				b.Property<int>("IdEstadoCuota").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_CUOTA")
					.HasDefaultValueSql("1");
				b.Property<int>("IdVenta").HasColumnType("int").HasColumnName("ID_VENTA");
				b.Property<decimal>("Monto").ValueGeneratedOnAdd().HasColumnType("decimal(18,2)")
					.HasColumnName("MONTO")
					.HasDefaultValueSql("0.00");
				b.Property<int>("NumeroCuota").HasColumnType("int").HasColumnName("NUMERO_CUOTA");
				b.HasKey("IdCuota");
				b.HasIndex("IdEstadoCuota");
				b.HasIndex("IdVenta");
				b.ToTable("CUOTAS_VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Entidades", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEntidad").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ENTIDAD");
				b.Property<int>("IdEntidad").UseIdentityByDefaultColumn();
				b.Property<string>("Altura").HasColumnType("text").HasColumnName("ALTURA");
				b.Property<string>("Apellido").HasColumnType("varchar(max)").HasColumnName("APELLIDO");
				b.Property<string>("Barrio").HasColumnType("varchar(max)").HasColumnName("BARRIO");
				b.Property<string>("Calle").HasColumnType("text").HasColumnName("CALLE");
				b.Property<string>("Ciudad").HasColumnType("text").HasColumnName("CIUDAD");
				b.Property<string>("CodigoPostal").HasColumnType("text").HasColumnName("CODIGO_POSTAL");
				b.Property<string>("Email").HasColumnType("text").HasColumnName("EMAIL");
				b.Property<DateTime>("FechaRegistro").HasColumnType("timestamp with time zone").HasColumnName("FECHA_REGISTRO");
				b.Property<int>("IdCategoria").HasColumnType("int").HasColumnName("ID_CATEGORIA");
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("(1)");
				b.Property<string>("IdFiscal").IsRequired().HasColumnType("text")
					.HasColumnName("ID_FISCAL");
				b.Property<int>("IdTipo").HasColumnType("int").HasColumnName("ID_TIPO");
				b.Property<string>("IdUsuarioRegistro").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("ID_USUARIO_REGISTRO");
				b.Property<string>("Localidad").HasColumnType("varchar(MAX)").HasColumnName("LOCALIDAD");
				b.Property<string>("Nombre").HasColumnType("varchar(max)").HasColumnName("NOMBRE");
				b.Property<string>("NombreClave").IsRequired().HasColumnType("text")
					.HasColumnName("NOMBRE_CLAVE");
				b.Property<string>("Pais").HasColumnType("text").HasColumnName("PAIS");
				b.Property<string>("Provincia").HasColumnType("text").HasColumnName("PROVINCIA");
				b.Property<string>("Telefono1").HasColumnType("text").HasColumnName("TELEFONO_1");
				b.Property<string>("Telefono2").HasColumnType("text").HasColumnName("TELEFONO_2");
				b.Property<string>("Telefono3").HasColumnType("text").HasColumnName("TELEFONO_3");
				b.HasKey("IdEntidad");
				b.HasIndex("IdCategoria");
				b.HasIndex("IdTipo");
				b.HasIndex("IdUsuarioRegistro");
				b.ToTable("ENTIDADES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesCategorias", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCategoria").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_CATEGORIA");
				b.Property<int>("IdCategoria").UseIdentityByDefaultColumn();
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("NombreCategoria").IsRequired().HasColumnType("nvarchar(max)")
					.HasColumnName("NOMBRE_CATEGORIA");
				b.HasKey("IdCategoria");
				b.ToTable("ENTIDADES_CATEGORIAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesTipos", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdTipo").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_TIPO");
				b.Property<int>("IdTipo").UseIdentityByDefaultColumn();
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("NombreTipo").IsRequired().HasColumnType("nvarchar(max)")
					.HasColumnName("NOMBRE");
				b.HasKey("IdTipo");
				b.ToTable("ENTIDADES_TIPOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesTiposCategorias", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("idTipoEntidad").HasColumnType("int").HasColumnName("ID_TIPO");
				b.Property<int>("IdCategoriaEntidad").HasColumnType("int").HasColumnName("ID_CATEGORIA");
				b.HasKey("idTipoEntidad", "IdCategoriaEntidad");
				b.HasIndex("IdCategoriaEntidad");
				b.ToTable("ENTIDADES_TIPOS_CATEGORIAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosArchivosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstadoMovimiento").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("nvarchar(max)")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstadoMovimiento");
				b.ToTable("ESTADOS_ARCHIVOS_MOVIMIENTOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosComponentesDetalles", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstadoMovimiento").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("nvarchar(max)")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstadoMovimiento");
				b.ToTable("ESTADOS_COMPONENTES_DETALLES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCompras", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoCompra").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_COMPRA")
					.HasAnnotation("SqlServer:Identity", "1, 1");
				b.Property<int>("IdEstadoCompra").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("nvarchar(max)")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstadoMovimiento").HasColumnType("int").HasColumnName("ID_ESTADO");
				b.HasKey("IdEstadoCompra");
				b.ToTable("ESTADOS_COMPRAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCuotasVentas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoCuota").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_CUOTA");
				b.Property<int>("IdEstadoCuota").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("varchar(MAX)")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.HasKey("IdEstadoCuota");
				b.ToTable("ESTADOS_CUOTAS_VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int?>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_MOVIMIENTO");
				b.Property<int?>("IdEstadoMovimiento").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("nvarchar(max)")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.HasKey("IdEstadoMovimiento");
				b.ToTable("ESTADOS_MOVIMIENTOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductos", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstadoMovimiento").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("nvarchar(max)")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstadoMovimiento");
				b.ToTable("ESTADOS_PRODUCTOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductosComponentes", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstadoMovimiento").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("nvarchar(max)")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstadoMovimiento");
				b.ToTable("ESTADOS_PRODUCTOS_COMPONENTES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductosDescripciones", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstadoMovimiento").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("nvarchar(max)")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstadoMovimiento");
				b.ToTable("ESTADOS_PRODUCTOS_DESCRIPCIONES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosSuministrosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstadoMovimiento").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("nvarchar(max)")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstadoMovimiento");
				b.ToTable("ESTADOS_SUMINISTROS_MOVIMIENTOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosTiposProductos", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstadoMovimiento").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("nvarchar(max)")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstadoMovimiento");
				b.ToTable("ESTADOS_PRODUCTOS_TIPOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosVentas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoVenta").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_VENTA");
				b.Property<int>("IdEstadoVenta").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("nvarchar(max)")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("int")
					.HasDefaultValue(1)
					.HasColumnName("ID_ESTADO");
				b.HasKey("IdEstadoVenta");
				b.ToTable("ESTADOS_VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.MediosPago", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdMedioPago").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_MEDIO_PAGO");
				b.Property<int>("IdMedioPago").UseIdentityByDefaultColumn();
				b.Property<string>("CodigoMPago").HasColumnType("nvarchar(max)").HasColumnName("CODIGO_MPAGO");
				b.Property<string>("Descripcion").IsRequired().HasColumnType("nvarchar(max)")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("int")
					.HasDefaultValue(1)
					.HasColumnName("ID_ESTADO");
				b.HasKey("IdMedioPago");
				b.ToTable("MEDIOS_PAGO", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PagosCompras", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdPago").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_PAGO")
					.HasColumnOrder(2);
				b.Property<int>("IdPago").UseIdentityByDefaultColumn();
				b.Property<int?>("CantidadCuotas").HasColumnType("int").HasColumnName("CANTIDAD_CUOTAS");
				b.Property<int?>("CantidadCuotasCanceladas").HasColumnType("int").HasColumnName("CANTIDAD_CUOTAS_CANCELADAS");
				b.Property<int>("IdCompra").HasColumnType("int").HasColumnName("ID_COMPRA");
				b.Property<int>("IdMedioPago").HasColumnType("int").HasColumnName("ID_MEDIO_PAGO");
				b.Property<decimal>("Monto").HasColumnType("decimal(18,2)").HasColumnName("SUBTOTAL");
				b.Property<decimal?>("SaldoPendiente").HasColumnType("decimal(18,2)").HasColumnName("SUBTOTAL_CANCELADO");
				b.Property<decimal>("MontoCompra").HasColumnType("decimal(18,2)").HasColumnName("TOTAL");
				b.HasKey("IdPago");
				b.HasIndex("IdCompra");
				b.HasIndex("IdMedioPago");
				b.ToTable("PAGOS_COMPRAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PagosVentas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdPago").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_PAGO")
					.HasColumnOrder(2);
				b.Property<int>("IdPago").UseIdentityByDefaultColumn();
				b.Property<DateTime?>("Fecha").HasColumnType("datetime").HasColumnName("FECHA");
				b.Property<int>("IdMedioPago").HasColumnType("int").HasColumnName("ID_MEDIO_PAGO");
				b.Property<int>("IdVenta").HasColumnType("int").HasColumnName("ID_VENTA");
				b.Property<decimal>("Monto").HasColumnType("decimal(18,2)").HasColumnName("MONTO");
				b.HasKey("IdPago");
				b.HasIndex("IdMedioPago");
				b.HasIndex("IdVenta");
				b.ToTable("PAGOS_VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PerfilesUsuarios", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdPerfil").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_PERFIL");
				b.Property<int>("IdPerfil").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("varcahr(100)")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstadoMovimiento").HasColumnType("integer").HasColumnName("ID_ESTADO");
				b.HasKey("IdPerfil");
				b.ToTable("USUARIOS_PERFILES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Producto", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdProducto").HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("ID_PRODUCTO");
				b.Property<int?>("Cantidad").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("CANTIDAD")
					.HasDefaultValueSql("((0))");
				b.Property<int?>("DiametroNominal").HasColumnType("integer").HasColumnName("DIAMETRO_NOMINAL");
				b.Property<int>("IdDescripcion").HasColumnType("integer").HasColumnName("ID_DESCRIPCION");
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("IdTipo").IsRequired().HasMaxLength(50)
					.IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("ID_TIPO");
				b.Property<decimal?>("PorcentajeGanancia").HasColumnType("decimal(18,2)").HasColumnName("PORCENTAJE_GANANCIA");
				b.Property<decimal?>("PrecioFinal").HasColumnType("decimal(18,2)").HasColumnName("PRECIO_FINAL");
				b.Property<decimal?>("PrecioLista").ValueGeneratedOnAdd().HasColumnType("money")
					.HasColumnName("PRECIO_LISTA")
					.HasDefaultValueSql("((0))");
				b.Property<string>("Tolerancia").HasColumnType("text").HasColumnName("TOLERANCIA");
				b.HasKey("IdProducto");
				b.HasIndex("IdDescripcion");
				b.HasIndex("IdEstadoMovimiento");
				b.HasIndex("IdTipo");
				b.ToTable("PRODUCTOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosDescripcion", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdDescripcion").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_DESCRIPCION");
				b.Property<int>("IdDescripcion").UseIdentityByDefaultColumn();
				b.Property<string>("DescripcionProducto").HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.HasKey("IdDescripcion");
				b.HasIndex("IdEstadoMovimiento");
				b.ToTable("PRODUCTOS_DESCRIPCION", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosTipo", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdTipo").HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("ID_TIPO");
				b.Property<string>("DescripcionTipo").HasMaxLength(100).IsUnicode(unicode: false)
					.HasColumnType("character varying(100)")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<int>("IdEstadoMovimiento").UseIdentityByDefaultColumn();
				b.HasKey("IdTipo").HasName("PK_PRODUCTOS_TIPOS");
				b.HasIndex("IdEstadoMovimiento");
				b.ToTable("PRODUCTOS_TIPOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Productos_Componentes", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdProducto").HasColumnType("varchar(50)").HasColumnName("ID_PRODUCTO");
				b.Property<string>("IdComponente").HasColumnType("varchar(50)").HasColumnName("ID_COMPONENTE");
				b.Property<decimal?>("Cantidad").HasColumnType("decimal(18,2)").HasColumnName("CANTIDAD");
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<decimal?>("Longitud").HasColumnType("decimal(18,2)").HasColumnName("LONGITUD");
				b.Property<decimal?>("Peso").HasColumnType("decimal(18,2)").HasColumnName("PESO");
				b.HasKey("IdProducto", "IdComponente").HasName("PK_PRODUCTOS_COMPONENTES");
				b.HasIndex("IdEstadoMovimiento");
				b.ToTable("PRODUCTOS_COMPONENTES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Productos_Tipos_Descripcion", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdTipo").HasColumnType("text").HasColumnName("ID_TIPO");
				b.Property<int?>("IdDescripcion").HasColumnType("integer").HasColumnName("ID_DESCRIPCION");
				b.HasKey("IdTipo", "IdDescripcion");
				b.ToTable("PRODUCTOS_TIPOS_DESCRIPCION", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.StockInsumos", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdInsumo").HasColumnType("varchar(50)").HasColumnName("ID_INSUMO");
				b.Property<decimal?>("Granallado").HasColumnType("decimal").HasColumnName("GRANALLADO");
				b.Property<decimal?>("Moldeado").HasColumnType("decimal").HasColumnName("MOLDEADO");
				b.Property<decimal?>("Pendiente").HasColumnType("decimal(18,2)").HasColumnName("PENDIENTE");
				b.Property<decimal?>("Pintura").HasColumnType("decimal").HasColumnName("PINTURA");
				b.Property<decimal?>("Proceso").HasColumnType("decimal").HasColumnName("PROCESO");
				b.Property<decimal?>("Recibido").HasColumnType("decimal").HasColumnName("RECIBIDO");
				b.HasKey("IdInsumo").HasName("PK_STOCK_INSUMOS");
				b.ToTable("STOCK_INSUMOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Stock_Movimientos", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdMovimiento").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_MOVIMIENTO");
				b.Property<int>("IdMovimiento").UseIdentityByDefaultColumn();
				b.Property<string>("CreadoUsuario").IsRequired().HasColumnType("nvarchar(50)")
					.HasColumnName("USUARIO_CREADO");
				b.Property<string>("Destino").HasColumnType("varchar(50)").HasColumnName("DESTINO");
				b.Property<DateTime>("FechaHoraCreado").HasColumnType("datetime2(7)").HasColumnName("FECHA_HORA_CREADO");
				b.Property<DateTime?>("FechaHoraUltimaModificacion").HasColumnType("datetime2(7)").HasColumnName("FECHA_HORA_ULTIMA_MODIFICACION");
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<int>("IdEntidad").HasColumnType("int").HasColumnName("ID_PROVEEDOR_DESTINO");
				b.Property<int>("IdProveedorOrigen").HasColumnType("int").HasColumnName("ID_PROVEEDOR_ORIGEN");
				b.Property<string>("ModificadoUsuario").IsRequired().HasColumnType("nvarchar(50)")
					.HasColumnName("USUARIO_MODIFICA");
				b.Property<string>("Origen").HasColumnType("varchar(50)").HasColumnName("ORIGEN");
				b.Property<string>("Tipo").HasColumnType("varchar(15)").HasColumnName("TIPO");
				b.HasKey("IdMovimiento");
				b.HasIndex("IdEstadoMovimiento");
				b.HasIndex("IdEntidad");
				b.HasIndex("IdProveedorOrigen");
				b.ToTable("STOCK_MOVIMIENTOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.SuministrosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdMovimiento").HasColumnType("int").HasColumnName("ID_MOVIMIENTO");
				b.Property<string>("IdSuministro").HasColumnType("nvarchar(50)").HasColumnName("ID_SUMINISTRO");
				b.Property<decimal>("Cantidad").HasColumnType("decimal(18,2)").HasColumnName("CANTIDAD");
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<decimal?>("ValorAnteriorDestino").HasColumnType("decimal(18,2)").HasColumnName("VALOR_ANTERIOR_DESTINO");
				b.Property<decimal?>("ValorAnteriorOrigen").HasColumnType("decimal(18,2)").HasColumnName("VALOR_ANTERIOR_ORIGEN");
				b.Property<decimal?>("ValorNuevoDestino").HasColumnType("numeric").HasColumnName("VALOR_NUEVO_DESTINO");
				b.Property<decimal?>("ValorNuevoOrigen").HasColumnType("decimal(18,2)").HasColumnName("VALOR_NUEVO_ORIGEN");
				b.HasKey("IdMovimiento", "IdSuministro");
				b.HasIndex("IdEstadoMovimiento");
				b.ToTable("SUMINISTROS_MOVIMIENTOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Usuarios", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("Usuario").HasColumnType("varchar(50)").HasColumnName("USUARIO");
				b.Property<string>("Contraseña").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("CONTRASEÑA");
				b.Property<int>("IdPerfil").HasColumnType("int").HasColumnName("ID_PERFIL");
				b.Property<string>("Correo").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("CORREO");
				b.HasKey("Usuario");
				b.HasIndex("IdPerfil");
				b.ToTable("USUARIOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Ventas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdVenta").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_VENTA");
				b.Property<int>("IdVenta").UseIdentityByDefaultColumn();
				b.Property<DateTime>("FechaHora").HasColumnType("datetime").HasColumnName("FECHA_HORA");
				b.Property<int>("IdEntidad").HasColumnType("int").HasColumnName("ID_CLIENTE");
				b.Property<int>("IdEstadoVenta").HasColumnType("int").HasColumnName("ID_ESTADO_VENTA");
				b.Property<string>("IdUsuario").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("ID_USUARIO");
				b.Property<decimal>("SaldoPendiente").HasColumnType("numeric").HasColumnName("SALDO_PENDIENTE");
				b.Property<decimal>("MontoCompra").HasColumnType("decimal(18,2)").HasColumnName("TOTAL");
				b.HasKey("IdVenta");
				b.HasIndex("IdEntidad");
				b.HasIndex("IdEstadoVenta");
				b.HasIndex("IdUsuario");
				b.ToTable("VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.VentasDetalles", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdVenta").HasColumnType("int").HasColumnName("ID_VENTA");
				b.Property<string>("IdProducto").HasColumnType("varchar(50)").HasColumnName("ID_PRODUCTO");
				b.Property<decimal>("Cantidad").HasColumnType("decimal(18,2)").HasColumnName("CANTIDAD");
				b.Property<int?>("Entregados").HasColumnType("integer").HasColumnName("ENTREGADOS");
				b.Property<decimal>("Precio").HasColumnType("decimal(18,2)").HasColumnName("PRECIO");
				b.HasKey("IdVenta", "IdProducto");
				b.HasIndex("IdProducto");
				b.ToTable("VENTAS_DETALLES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ArchivosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosArchivosMovimientosStock", "ArchivosMovimientosStockNavigation").WithMany("ArchivosMovimientoStock").HasForeignKey("IdEstadoMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Stock_Movimientos", "StockMovimiento").WithMany().HasForeignKey("IdMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_ARCHIVOS_STOCK_STOCK_MOVIMIENTOS_ID_MOVIMIENTO");
				b.Navigation("ArchivosMovimientosStockNavigation");
				b.Navigation("StockMovimiento");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComponentesDetalle", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosComponentesDetalles", "IdEstadoNavigation").WithMany("ComponentesDetalle").HasForeignKey("IdEstadoMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdEstadoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Compras", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosCompras", "Estado").WithMany("compras").HasForeignKey("IdEstadoCompra")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Entidades", "IdProveedor").WithMany("compras").HasForeignKey("IdProveedor")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Usuarios", "Usuario").WithMany("Compras").HasForeignKey("IdUsuario")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired();
				b.Navigation("Estado");
				b.Navigation("IdProveedor");
				b.Navigation("Usuario");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComprasDetalles", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Compras", "CompraNavigation").WithMany("DetallesCompra").HasForeignKey("IdCompra")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.ComponentesDetalle", "DetallesInsumo").WithMany("ComprasNavigation").HasForeignKey("IdInsumo")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("CompraNavigation");
				b.Navigation("DetallesInsumo");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.CuotasVentas", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosCuotasVentas", "EstadoCuota").WithMany("IdEstadoCuotaNavigation").HasForeignKey("IdEstadoCuota")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Ventas", "Venta").WithMany("Cuotas").HasForeignKey("IdVenta")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("EstadoCuota");
				b.Navigation("Venta");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Entidades", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EntidadesCategorias", "CategoriaEntidad").WithMany("Entidades").HasForeignKey("IdCategoria")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.EntidadesTipos", "TipoEntidad").WithMany("Entidades").HasForeignKey("IdTipo")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Usuarios", "UsuarioRegistro").WithMany("IdUsuarioRegistroNavigation").HasForeignKey("IdUsuarioRegistro")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("CategoriaEntidad");
				b.Navigation("TipoEntidad");
				b.Navigation("UsuarioRegistro");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesTiposCategorias", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EntidadesCategorias", "CategoriaEntidad").WithMany("TiposCategoriasNavigation").HasForeignKey("IdCategoriaEntidad")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.EntidadesTipos", "TipoEntidad").WithMany("TiposCategoriasNavigation").HasForeignKey("idTipoEntidad")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("CategoriaEntidad");
				b.Navigation("TipoEntidad");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PagosCompras", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Compras", "CompraNavigation").WithMany("Pagos").HasForeignKey("IdCompra")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.MediosPago", "MedioPago").WithMany("PagosComprasNavigation").HasForeignKey("IdMedioPago")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("CompraNavigation");
				b.Navigation("MedioPago");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PagosVentas", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.MediosPago", "MedioPago").WithMany("PagosVentasNavigation").HasForeignKey("IdMedioPago")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Ventas", "Venta").WithMany("Pagos").HasForeignKey("IdVenta")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("MedioPago");
				b.Navigation("Venta");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Producto", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.ProductosDescripcion", "IdDescripcionNavigation").WithMany("StockInsumos").HasForeignKey("IdDescripcion")
					.IsRequired()
					.HasConstraintName("FK_PRODUCTOS_PRODUCTOS_DESCRIPCION");
				b.HasOne("Aponus_Web_API.Modelos.EstadosProductos", "IdEstadoNavigation").WithMany("StockInsumos").HasForeignKey("IdEstadoMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.ProductosTipo", "IdTipoNavigation").WithMany("StockInsumos").HasForeignKey("IdTipo")
					.IsRequired()
					.HasConstraintName("FK_PRODUCTOS_PRODUCTOS_TIPOS");
				b.Navigation("IdDescripcionNavigation");
				b.Navigation("IdEstadoNavigation");
				b.Navigation("IdTipoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosDescripcion", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosProductosDescripciones", "IdEstadoNavigation").WithMany("ProductosDescripcions").HasForeignKey("IdEstadoMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdEstadoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosTipo", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosTiposProductos", "IdEstadoNavigation").WithMany("ProductosTipos").HasForeignKey("IdEstadoMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdEstadoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Productos_Componentes", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosProductosComponentes", "IdEstadoNavigation").WithMany("ProductosComponentes").HasForeignKey("IdEstadoMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdEstadoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Stock_Movimientos", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosMovimientosStock", "estadoMovimiento").WithMany("movimientosStock").HasForeignKey("IdEstadoMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Entidades", "IdProveedor").WithMany("Movimientos").HasForeignKey("IdEntidad")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Entidades", "ProveedorOrigen").WithMany("MovimientosOrigen").HasForeignKey("IdProveedorOrigen")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdProveedor");
				b.Navigation("ProveedorOrigen");
				b.Navigation("estadoMovimiento");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.SuministrosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosSuministrosMovimientosStock", "EstadosSuministrosMovimientosStockNavigation").WithMany("SuministrosMovimientoStock").HasForeignKey("IdEstadoMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Stock_Movimientos", null).WithMany("Suministros").HasForeignKey("IdMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("EstadosSuministrosMovimientosStockNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Usuarios", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.PerfilesUsuarios", "Perfil").WithMany("UsuariosNavigation").HasForeignKey("IdPerfil")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_USUARIOS_PERFILES_USUARIOS_ID_PERFIL");
				b.Navigation("Perfil");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Ventas", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Entidades", "Cliente").WithMany("ventas").HasForeignKey("IdEntidad")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.EstadosVentas", "Estado").WithMany("ventas").HasForeignKey("IdEstadoVenta")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Usuarios", "Usuario").WithMany("Ventas").HasForeignKey("IdUsuario")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired();
				b.Navigation("Cliente");
				b.Navigation("Estado");
				b.Navigation("Usuario");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.VentasDetalles", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Producto", "IdProductoNavigation").WithMany("Ventas").HasForeignKey("IdProducto")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_VENTAS_DETALLES_PRODUCTOS_ID_PRODUCTO");
				b.HasOne("Aponus_Web_API.Modelos.Ventas", "Venta").WithMany("DetallesVenta").HasForeignKey("IdVenta")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdProductoNavigation");
				b.Navigation("Venta");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComponentesDetalle", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ComprasNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Compras", delegate(EntityTypeBuilder b)
			{
				b.Navigation("DetallesCompra");
				b.Navigation("Pagos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Entidades", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Movimientos");
				b.Navigation("MovimientosOrigen");
				b.Navigation("compras");
				b.Navigation("ventas");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesCategorias", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Entidades");
				b.Navigation("TiposCategoriasNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesTipos", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Entidades");
				b.Navigation("TiposCategoriasNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosArchivosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ArchivosMovimientoStock");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosComponentesDetalles", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ComponentesDetalle");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCompras", delegate(EntityTypeBuilder b)
			{
				b.Navigation("compras");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCuotasVentas", delegate(EntityTypeBuilder b)
			{
				b.Navigation("IdEstadoCuotaNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Navigation("movimientosStock");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductos", delegate(EntityTypeBuilder b)
			{
				b.Navigation("StockInsumos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductosComponentes", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ProductosComponentes");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductosDescripciones", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ProductosDescripcions");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosSuministrosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Navigation("SuministrosMovimientoStock");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosTiposProductos", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ProductosTipos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosVentas", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ventas");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.MediosPago", delegate(EntityTypeBuilder b)
			{
				b.Navigation("PagosComprasNavigation");
				b.Navigation("PagosVentasNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PerfilesUsuarios", delegate(EntityTypeBuilder b)
			{
				b.Navigation("UsuariosNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Producto", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Ventas");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosDescripcion", delegate(EntityTypeBuilder b)
			{
				b.Navigation("StockInsumos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosTipo", delegate(EntityTypeBuilder b)
			{
				b.Navigation("StockInsumos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Stock_Movimientos", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Suministros");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Usuarios", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Compras");
				b.Navigation("IdUsuarioRegistroNavigation");
				b.Navigation("Ventas");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Ventas", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Cuotas");
				b.Navigation("DetallesVenta");
				b.Navigation("Pagos");
			});
		}
	}
	[DbContext(typeof(AponusContext))]
	[Migration("20240924090601_Correciones en DescripcionProducto y Entidades")]
	public class CorrecionesenDescripcionProductoyEntidades : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			Type typeFromHandle = typeof(string);
			migrationBuilder.AlterColumn<string>("NOMBRE_CLAVE", "ENTIDADES", null, null, null, rowVersion: false, null, nullable: true, null, null, null, typeFromHandle);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
		}

		protected override void BuildTargetModel(ModelBuilder modelBuilder)
		{
			modelBuilder.UseCollation("Modern_Spanish_CI_AI").HasAnnotation("ProductVersion", "7.0.11").HasAnnotation("Proxies:ChangeTracking", false)
				.HasAnnotation("Proxies:CheckEquality", false)
				.HasAnnotation("Proxies:LazyLoading", true)
				.HasAnnotation("Relational:MaxIdentifierLength", 63);
			modelBuilder.UseIdentityByDefaultColumns();
			modelBuilder.Entity("Aponus_Web_API.Modelos.ArchivosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdMovimiento").HasColumnType("int").HasColumnName("ID_MOVIMIENTO");
				b.Property<string>("HashArchivo").HasColumnType("varchar(255)").HasColumnName("HASH_ARCHIVO");
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("MimeType").HasColumnType("varchar(MAX)").HasColumnName("MIME_TYPE");
				b.Property<string>("PathArchivo").IsRequired().HasColumnType("varchar(MAX)")
					.HasColumnName("PATH");
				b.HasKey("IdMovimiento", "HashArchivo");
				b.HasIndex("IdEstadoMovimiento");
				b.ToTable("ARCHIVOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComponentesDescripcion", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdDescripcion").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_DESCRIPCION");
				b.Property<int>("IdDescripcion").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdDescripcion");
				b.ToTable("COMPONENTES_DESCRIPCION", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComponentesDetalle", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdInsumo").HasColumnType("varchar(50)").HasColumnName("ID_INSUMO");
				b.Property<decimal?>("Altura").HasColumnType("decimal(18,2)").HasColumnName("ALTURA");
				b.Property<decimal?>("Diametro").HasColumnType("decimal(18,2)").HasColumnName("DIAMETRO");
				b.Property<int?>("DiametroNominal").HasColumnType("int").HasColumnName("DIAMETRO_NOMINAL");
				b.Property<decimal?>("Espesor").HasColumnType("decimal(18,2)").HasColumnName("ESPESOR");
				b.Property<string>("IdAlmacenamiento").HasColumnType("nvarchar(50)").HasColumnName("ID_ALMACENAMIENTO");
				b.Property<int>("IdDescripcion").HasColumnType("integer").HasColumnName("ID_DESCRIPCION");
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("IdFraccionamiento").HasColumnType("nvarchar(50)").HasColumnName("ID_FRACCIONAMIENTO");
				b.Property<decimal?>("Longitud").HasColumnType("decimal(18,2)").HasColumnName("LONGITUD");
				b.Property<int?>("Perfil").HasColumnType("integer").HasColumnName("PERFIL");
				b.Property<decimal?>("Peso").HasColumnType("decimal(18,3)").HasColumnName("PESO");
				b.Property<string>("Tolerancia").HasColumnType("varchar(50)").HasColumnName("TOLERANCIA");
				b.HasKey("IdInsumo").HasName("PK_ID_INSUMO");
				b.HasIndex("IdEstadoMovimiento");
				b.ToTable("COMPONENTES_DETALLE", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Compras", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCompra").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_COMPRA");
				b.Property<int>("IdCompra").UseIdentityByDefaultColumn();
				b.Property<DateTime>("FechaHora").HasColumnType("timestamp").HasColumnName("FECHA_HORA");
				b.Property<int>("IdEstadoCompra").HasColumnType("int").HasColumnName("ID_ESTADO_COMPRA");
				b.Property<int>("IdProveedor").HasColumnType("int").HasColumnName("ID_PROVEEDOR");
				b.Property<string>("IdUsuario").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("ID_USUARIO");
				b.Property<decimal?>("SaldoPendiente").HasColumnType("decimal(18,2)").HasColumnName("SALDO_CANCELADO");
				b.Property<decimal>("MontoTotal").HasColumnType("decimal(18,2)").HasColumnName("SALDO_TOTAL");
				b.HasKey("IdCompra");
				b.HasIndex("IdEstadoCompra");
				b.HasIndex("IdProveedor");
				b.HasIndex("IdUsuario");
				b.ToTable("COMPRAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComprasDetalles", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCompra").HasColumnType("int").HasColumnName("ID_COMPRA");
				b.Property<string>("IdInsumo").HasColumnType("varchar(50)").HasColumnName("ID_INSUMO");
				b.Property<decimal>("Cantidad").HasColumnType("decimal(18,2)").HasColumnName("CANTIDAD");
				b.HasKey("IdCompra", "IdInsumo");
				b.HasIndex("IdInsumo");
				b.ToTable("COMPRAS_DETALLE", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.CuotasVentas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCuota").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_CUOTA");
				b.Property<int>("IdCuota").UseIdentityByDefaultColumn();
				b.Property<DateTime?>("Fecha").HasColumnType("timestamp").HasColumnName("FECHA_PAGO");
				b.Property<DateTime>("FechaVencimiento").HasColumnType("timestamp").HasColumnName("FECHA_VENCIMIENTO");
				b.Property<int>("IdEstadoCuota").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_CUOTA")
					.HasDefaultValueSql("1");
				b.Property<int>("IdVenta").HasColumnType("int").HasColumnName("ID_VENTA");
				b.Property<decimal>("Monto").ValueGeneratedOnAdd().HasColumnType("decimal(18,2)")
					.HasColumnName("MONTO")
					.HasDefaultValueSql("0.00");
				b.Property<int>("NumeroCuota").HasColumnType("int").HasColumnName("NUMERO_CUOTA");
				b.HasKey("IdCuota");
				b.HasIndex("IdEstadoCuota");
				b.HasIndex("IdVenta");
				b.ToTable("CUOTAS_VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Entidades", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEntidad").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ENTIDAD");
				b.Property<int>("IdEntidad").UseIdentityByDefaultColumn();
				b.Property<string>("Altura").HasColumnType("text").HasColumnName("ALTURA");
				b.Property<string>("Apellido").HasColumnType("varchar(max)").HasColumnName("APELLIDO");
				b.Property<string>("Barrio").HasColumnType("varchar(max)").HasColumnName("BARRIO");
				b.Property<string>("Calle").HasColumnType("text").HasColumnName("CALLE");
				b.Property<string>("Ciudad").HasColumnType("text").HasColumnName("CIUDAD");
				b.Property<string>("CodigoPostal").HasColumnType("text").HasColumnName("CODIGO_POSTAL");
				b.Property<string>("Email").HasColumnType("text").HasColumnName("EMAIL");
				b.Property<DateTime>("FechaRegistro").HasColumnType("timestamp").HasColumnName("FECHA_REGISTRO");
				b.Property<int>("IdCategoria").HasColumnType("int").HasColumnName("ID_CATEGORIA");
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("(1)");
				b.Property<string>("IdFiscal").IsRequired().HasColumnType("text")
					.HasColumnName("ID_FISCAL");
				b.Property<int>("IdTipo").HasColumnType("int").HasColumnName("ID_TIPO");
				b.Property<string>("IdUsuarioRegistro").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("ID_USUARIO_REGISTRO");
				b.Property<string>("Localidad").HasColumnType("varchar(MAX)").HasColumnName("LOCALIDAD");
				b.Property<string>("Nombre").HasColumnType("varchar(max)").HasColumnName("NOMBRE");
				b.Property<string>("NombreClave").IsRequired().HasColumnType("text")
					.HasColumnName("NOMBRE_CLAVE");
				b.Property<string>("Pais").HasColumnType("text").HasColumnName("PAIS");
				b.Property<string>("Provincia").HasColumnType("text").HasColumnName("PROVINCIA");
				b.Property<string>("Telefono1").HasColumnType("text").HasColumnName("TELEFONO_1");
				b.Property<string>("Telefono2").HasColumnType("text").HasColumnName("TELEFONO_2");
				b.Property<string>("Telefono3").HasColumnType("text").HasColumnName("TELEFONO_3");
				b.HasKey("IdEntidad");
				b.HasIndex("IdCategoria");
				b.HasIndex("IdTipo");
				b.HasIndex("IdUsuarioRegistro");
				b.ToTable("ENTIDADES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesCategorias", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCategoria").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_CATEGORIA");
				b.Property<int>("IdCategoria").UseIdentityByDefaultColumn();
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("NombreCategoria").IsRequired().HasColumnType("nvarchar(max)")
					.HasColumnName("NOMBRE_CATEGORIA");
				b.HasKey("IdCategoria");
				b.ToTable("ENTIDADES_CATEGORIAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesTipos", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdTipo").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_TIPO");
				b.Property<int>("IdTipo").UseIdentityByDefaultColumn();
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("NombreTipo").IsRequired().HasColumnType("nvarchar(max)")
					.HasColumnName("NOMBRE");
				b.HasKey("IdTipo");
				b.ToTable("ENTIDADES_TIPOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesTiposCategorias", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("idTipoEntidad").HasColumnType("int").HasColumnName("ID_TIPO");
				b.Property<int>("IdCategoriaEntidad").HasColumnType("int").HasColumnName("ID_CATEGORIA");
				b.HasKey("idTipoEntidad", "IdCategoriaEntidad");
				b.HasIndex("IdCategoriaEntidad");
				b.ToTable("ENTIDADES_TIPOS_CATEGORIAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosArchivosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstadoMovimiento").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("nvarchar(max)")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstadoMovimiento");
				b.ToTable("ESTADOS_ARCHIVOS_MOVIMIENTOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosComponentesDetalles", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstadoMovimiento").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("nvarchar(max)")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstadoMovimiento");
				b.ToTable("ESTADOS_COMPONENTES_DETALLES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCompras", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoCompra").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_COMPRA")
					.HasAnnotation("SqlServer:Identity", "1, 1");
				b.Property<int>("IdEstadoCompra").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("nvarchar(max)")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstadoMovimiento").HasColumnType("int").HasColumnName("ID_ESTADO");
				b.HasKey("IdEstadoCompra");
				b.ToTable("ESTADOS_COMPRAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCuotasVentas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoCuota").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_CUOTA");
				b.Property<int>("IdEstadoCuota").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("varchar(MAX)")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.HasKey("IdEstadoCuota");
				b.ToTable("ESTADOS_CUOTAS_VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int?>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_MOVIMIENTO");
				b.Property<int?>("IdEstadoMovimiento").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("nvarchar(max)")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.HasKey("IdEstadoMovimiento");
				b.ToTable("ESTADOS_MOVIMIENTOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductos", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstadoMovimiento").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("nvarchar(max)")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstadoMovimiento");
				b.ToTable("ESTADOS_PRODUCTOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductosComponentes", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstadoMovimiento").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("nvarchar(max)")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstadoMovimiento");
				b.ToTable("ESTADOS_PRODUCTOS_COMPONENTES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductosDescripciones", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("Descripcion").IsRequired().HasColumnType("nvarchar(max)")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstadoMovimiento");
				b.ToTable("ESTADOS_PRODUCTOS_DESCRIPCIONES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosSuministrosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstadoMovimiento").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("nvarchar(max)")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstadoMovimiento");
				b.ToTable("ESTADOS_SUMINISTROS_MOVIMIENTOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosTiposProductos", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstadoMovimiento").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("nvarchar(max)")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstadoMovimiento");
				b.ToTable("ESTADOS_PRODUCTOS_TIPOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosVentas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoVenta").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_VENTA");
				b.Property<int>("IdEstadoVenta").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("nvarchar(max)")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("int")
					.HasDefaultValue(1)
					.HasColumnName("ID_ESTADO");
				b.HasKey("IdEstadoVenta");
				b.ToTable("ESTADOS_VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.MediosPago", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdMedioPago").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_MEDIO_PAGO");
				b.Property<int>("IdMedioPago").UseIdentityByDefaultColumn();
				b.Property<string>("CodigoMPago").HasColumnType("nvarchar(max)").HasColumnName("CODIGO_MPAGO");
				b.Property<string>("Descripcion").IsRequired().HasColumnType("nvarchar(max)")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("int")
					.HasDefaultValue(1)
					.HasColumnName("ID_ESTADO");
				b.HasKey("IdMedioPago");
				b.ToTable("MEDIOS_PAGO", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PagosCompras", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdPago").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_PAGO")
					.HasColumnOrder(2);
				b.Property<int>("IdPago").UseIdentityByDefaultColumn();
				b.Property<int?>("CantidadCuotas").HasColumnType("int").HasColumnName("CANTIDAD_CUOTAS");
				b.Property<int?>("CantidadCuotasCanceladas").HasColumnType("int").HasColumnName("CANTIDAD_CUOTAS_CANCELADAS");
				b.Property<int>("IdCompra").HasColumnType("int").HasColumnName("ID_COMPRA");
				b.Property<int>("IdMedioPago").HasColumnType("int").HasColumnName("ID_MEDIO_PAGO");
				b.Property<decimal>("Monto").HasColumnType("decimal(18,2)").HasColumnName("SUBTOTAL");
				b.Property<decimal?>("SaldoPendiente").HasColumnType("decimal(18,2)").HasColumnName("SUBTOTAL_CANCELADO");
				b.Property<decimal>("MontoCompra").HasColumnType("decimal(18,2)").HasColumnName("TOTAL");
				b.HasKey("IdPago");
				b.HasIndex("IdCompra");
				b.HasIndex("IdMedioPago");
				b.ToTable("PAGOS_COMPRAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PagosVentas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdPago").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_PAGO")
					.HasColumnOrder(2);
				b.Property<int>("IdPago").UseIdentityByDefaultColumn();
				b.Property<DateTime?>("Fecha").HasColumnType("timestamp").HasColumnName("FECHA");
				b.Property<int>("IdMedioPago").HasColumnType("int").HasColumnName("ID_MEDIO_PAGO");
				b.Property<int>("IdVenta").HasColumnType("int").HasColumnName("ID_VENTA");
				b.Property<decimal>("Monto").HasColumnType("decimal(18,2)").HasColumnName("MONTO");
				b.HasKey("IdPago");
				b.HasIndex("IdMedioPago");
				b.HasIndex("IdVenta");
				b.ToTable("PAGOS_VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PerfilesUsuarios", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdPerfil").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_PERFIL");
				b.Property<int>("IdPerfil").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("varcahr(100)")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstadoMovimiento").HasColumnType("integer").HasColumnName("ID_ESTADO");
				b.HasKey("IdPerfil");
				b.ToTable("USUARIOS_PERFILES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Producto", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdProducto").HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("ID_PRODUCTO");
				b.Property<int?>("Cantidad").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("CANTIDAD")
					.HasDefaultValueSql("((0))");
				b.Property<int?>("DiametroNominal").HasColumnType("integer").HasColumnName("DIAMETRO_NOMINAL");
				b.Property<int>("IdDescripcion").HasColumnType("integer").HasColumnName("ID_DESCRIPCION");
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("IdTipo").IsRequired().HasMaxLength(50)
					.IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("ID_TIPO");
				b.Property<decimal?>("PorcentajeGanancia").HasColumnType("decimal(18,2)").HasColumnName("PORCENTAJE_GANANCIA");
				b.Property<decimal?>("PrecioFinal").HasColumnType("decimal(18,2)").HasColumnName("PRECIO_FINAL");
				b.Property<decimal?>("PrecioLista").ValueGeneratedOnAdd().HasColumnType("money")
					.HasColumnName("PRECIO_LISTA")
					.HasDefaultValueSql("((0))");
				b.Property<string>("Tolerancia").HasColumnType("text").HasColumnName("TOLERANCIA");
				b.HasKey("IdProducto");
				b.HasIndex("IdDescripcion");
				b.HasIndex("IdEstadoMovimiento");
				b.HasIndex("IdTipo");
				b.ToTable("PRODUCTOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosDescripcion", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdDescripcion").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_DESCRIPCION");
				b.Property<int>("IdDescripcion").UseIdentityByDefaultColumn();
				b.Property<string>("DescripcionProducto").HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.HasKey("IdDescripcion");
				b.HasIndex("IdEstadoMovimiento");
				b.ToTable("PRODUCTOS_DESCRIPCION", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosTipo", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdTipo").HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("ID_TIPO");
				b.Property<string>("DescripcionTipo").HasMaxLength(100).IsUnicode(unicode: false)
					.HasColumnType("character varying(100)")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<int>("IdEstadoMovimiento").UseIdentityByDefaultColumn();
				b.HasKey("IdTipo").HasName("PK_PRODUCTOS_TIPOS");
				b.HasIndex("IdEstadoMovimiento");
				b.ToTable("PRODUCTOS_TIPOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Productos_Componentes", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdProducto").HasColumnType("varchar(50)").HasColumnName("ID_PRODUCTO");
				b.Property<string>("IdComponente").HasColumnType("varchar(50)").HasColumnName("ID_COMPONENTE");
				b.Property<decimal?>("Cantidad").HasColumnType("decimal(18,2)").HasColumnName("CANTIDAD");
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<decimal?>("Longitud").HasColumnType("decimal(18,2)").HasColumnName("LONGITUD");
				b.Property<decimal?>("Peso").HasColumnType("decimal(18,2)").HasColumnName("PESO");
				b.HasKey("IdProducto", "IdComponente").HasName("PK_PRODUCTOS_COMPONENTES");
				b.HasIndex("IdEstadoMovimiento");
				b.ToTable("PRODUCTOS_COMPONENTES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Productos_Tipos_Descripcion", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdTipo").HasColumnType("character varying(50)").HasColumnName("ID_TIPO");
				b.Property<int?>("IdDescripcion").HasColumnType("integer").HasColumnName("ID_DESCRIPCION");
				b.HasKey("IdTipo", "IdDescripcion");
				b.HasIndex("IdDescripcion");
				b.ToTable("PRODUCTOS_TIPOS_DESCRIPCION", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.StockInsumos", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdInsumo").HasColumnType("varchar(50)").HasColumnName("ID_INSUMO");
				b.Property<decimal?>("Granallado").HasColumnType("decimal").HasColumnName("GRANALLADO");
				b.Property<decimal?>("Moldeado").HasColumnType("decimal").HasColumnName("MOLDEADO");
				b.Property<decimal?>("Pendiente").HasColumnType("decimal(18,2)").HasColumnName("PENDIENTE");
				b.Property<decimal?>("Pintura").HasColumnType("decimal").HasColumnName("PINTURA");
				b.Property<decimal?>("Proceso").HasColumnType("decimal").HasColumnName("PROCESO");
				b.Property<decimal?>("Recibido").HasColumnType("decimal").HasColumnName("RECIBIDO");
				b.HasKey("IdInsumo").HasName("PK_STOCK_INSUMOS");
				b.ToTable("STOCK_INSUMOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Stock_Movimientos", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdMovimiento").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_MOVIMIENTO");
				b.Property<int>("IdMovimiento").UseIdentityByDefaultColumn();
				b.Property<string>("CreadoUsuario").IsRequired().HasColumnType("nvarchar(50)")
					.HasColumnName("USUARIO_CREADO");
				b.Property<string>("Destino").HasColumnType("varchar(50)").HasColumnName("DESTINO");
				b.Property<DateTime>("FechaHoraCreado").HasColumnType("timestamp").HasColumnName("FECHA_HORA_CREADO");
				b.Property<DateTime?>("FechaHoraUltimaModificacion").HasColumnType("timestamp").HasColumnName("FECHA_HORA_ULTIMA_MODIFICACION");
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<int>("IdEntidad").HasColumnType("int").HasColumnName("ID_PROVEEDOR_DESTINO");
				b.Property<int>("IdProveedorOrigen").HasColumnType("int").HasColumnName("ID_PROVEEDOR_ORIGEN");
				b.Property<string>("ModificadoUsuario").IsRequired().HasColumnType("nvarchar(50)")
					.HasColumnName("USUARIO_MODIFICA");
				b.Property<string>("Origen").HasColumnType("varchar(50)").HasColumnName("ORIGEN");
				b.Property<string>("Tipo").HasColumnType("varchar(15)").HasColumnName("TIPO");
				b.HasKey("IdMovimiento");
				b.HasIndex("IdEstadoMovimiento");
				b.HasIndex("IdEntidad");
				b.HasIndex("IdProveedorOrigen");
				b.ToTable("STOCK_MOVIMIENTOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.SuministrosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdMovimiento").HasColumnType("int").HasColumnName("ID_MOVIMIENTO");
				b.Property<string>("IdSuministro").HasColumnType("nvarchar(50)").HasColumnName("ID_SUMINISTRO");
				b.Property<decimal>("Cantidad").HasColumnType("decimal(18,2)").HasColumnName("CANTIDAD");
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<decimal?>("ValorAnteriorDestino").HasColumnType("decimal(18,2)").HasColumnName("VALOR_ANTERIOR_DESTINO");
				b.Property<decimal?>("ValorAnteriorOrigen").HasColumnType("decimal(18,2)").HasColumnName("VALOR_ANTERIOR_ORIGEN");
				b.Property<decimal?>("ValorNuevoDestino").HasColumnType("numeric").HasColumnName("VALOR_NUEVO_DESTINO");
				b.Property<decimal?>("ValorNuevoOrigen").HasColumnType("decimal(18,2)").HasColumnName("VALOR_NUEVO_ORIGEN");
				b.HasKey("IdMovimiento", "IdSuministro");
				b.HasIndex("IdEstadoMovimiento");
				b.ToTable("SUMINISTROS_MOVIMIENTOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Usuarios", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("Usuario").HasColumnType("varchar(50)").HasColumnName("USUARIO");
				b.Property<string>("Contraseña").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("CONTRASEÑA");
				b.Property<int>("IdPerfil").HasColumnType("int").HasColumnName("ID_PERFIL");
				b.Property<string>("Correo").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("CORREO");
				b.HasKey("Usuario");
				b.HasIndex("IdPerfil");
				b.ToTable("USUARIOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Ventas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdVenta").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_VENTA");
				b.Property<int>("IdVenta").UseIdentityByDefaultColumn();
				b.Property<DateTime>("FechaHora").HasColumnType("timestamp").HasColumnName("FECHA_HORA");
				b.Property<int>("IdEntidad").HasColumnType("int").HasColumnName("ID_CLIENTE");
				b.Property<int>("IdEstadoVenta").HasColumnType("int").HasColumnName("ID_ESTADO_VENTA");
				b.Property<string>("IdUsuario").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("ID_USUARIO");
				b.Property<decimal>("SaldoPendiente").HasColumnType("numeric").HasColumnName("SALDO_PENDIENTE");
				b.Property<decimal>("MontoCompra").HasColumnType("decimal(18,2)").HasColumnName("TOTAL");
				b.HasKey("IdVenta");
				b.HasIndex("IdEntidad");
				b.HasIndex("IdEstadoVenta");
				b.HasIndex("IdUsuario");
				b.ToTable("VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.VentasDetalles", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdVenta").HasColumnType("int").HasColumnName("ID_VENTA");
				b.Property<string>("IdProducto").HasColumnType("varchar(50)").HasColumnName("ID_PRODUCTO");
				b.Property<decimal>("Cantidad").HasColumnType("decimal(18,2)").HasColumnName("CANTIDAD");
				b.Property<int?>("Entregados").HasColumnType("integer").HasColumnName("ENTREGADOS");
				b.Property<decimal>("Precio").HasColumnType("decimal(18,2)").HasColumnName("PRECIO");
				b.HasKey("IdVenta", "IdProducto");
				b.HasIndex("IdProducto");
				b.ToTable("VENTAS_DETALLES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ArchivosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosArchivosMovimientosStock", "ArchivosMovimientosStockNavigation").WithMany("ArchivosMovimientoStock").HasForeignKey("IdEstadoMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Stock_Movimientos", "StockMovimiento").WithMany().HasForeignKey("IdMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_ARCHIVOS_STOCK_STOCK_MOVIMIENTOS_ID_MOVIMIENTO");
				b.Navigation("ArchivosMovimientosStockNavigation");
				b.Navigation("StockMovimiento");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComponentesDetalle", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosComponentesDetalles", "IdEstadoNavigation").WithMany("ComponentesDetalle").HasForeignKey("IdEstadoMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdEstadoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Compras", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosCompras", "Estado").WithMany("compras").HasForeignKey("IdEstadoCompra")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Entidades", "IdProveedor").WithMany("compras").HasForeignKey("IdProveedor")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Usuarios", "Usuario").WithMany("Compras").HasForeignKey("IdUsuario")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired();
				b.Navigation("Estado");
				b.Navigation("IdProveedor");
				b.Navigation("Usuario");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComprasDetalles", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Compras", "CompraNavigation").WithMany("DetallesCompra").HasForeignKey("IdCompra")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.ComponentesDetalle", "DetallesInsumo").WithMany("ComprasNavigation").HasForeignKey("IdInsumo")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("CompraNavigation");
				b.Navigation("DetallesInsumo");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.CuotasVentas", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosCuotasVentas", "EstadoCuota").WithMany("IdEstadoCuotaNavigation").HasForeignKey("IdEstadoCuota")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Ventas", "Venta").WithMany("Cuotas").HasForeignKey("IdVenta")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("EstadoCuota");
				b.Navigation("Venta");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Entidades", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EntidadesCategorias", "CategoriaEntidad").WithMany("Entidades").HasForeignKey("IdCategoria")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.EntidadesTipos", "TipoEntidad").WithMany("Entidades").HasForeignKey("IdTipo")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Usuarios", "UsuarioRegistro").WithMany("IdUsuarioRegistroNavigation").HasForeignKey("IdUsuarioRegistro")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("CategoriaEntidad");
				b.Navigation("TipoEntidad");
				b.Navigation("UsuarioRegistro");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesTiposCategorias", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EntidadesCategorias", "CategoriaEntidad").WithMany("TiposCategoriasNavigation").HasForeignKey("IdCategoriaEntidad")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.EntidadesTipos", "TipoEntidad").WithMany("TiposCategoriasNavigation").HasForeignKey("idTipoEntidad")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("CategoriaEntidad");
				b.Navigation("TipoEntidad");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PagosCompras", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Compras", "CompraNavigation").WithMany("Pagos").HasForeignKey("IdCompra")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.MediosPago", "MedioPago").WithMany("PagosComprasNavigation").HasForeignKey("IdMedioPago")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("CompraNavigation");
				b.Navigation("MedioPago");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PagosVentas", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.MediosPago", "MedioPago").WithMany("PagosVentasNavigation").HasForeignKey("IdMedioPago")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Ventas", "Venta").WithMany("Pagos").HasForeignKey("IdVenta")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("MedioPago");
				b.Navigation("Venta");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Producto", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.ProductosDescripcion", "IdDescripcionNavigation").WithMany("StockProductos").HasForeignKey("IdDescripcion")
					.IsRequired()
					.HasConstraintName("FK_PRODUCTOS_PRODUCTOS_DESCRIPCION");
				b.HasOne("Aponus_Web_API.Modelos.EstadosProductos", "IdEstadoNavigation").WithMany("StockProductos").HasForeignKey("IdEstadoMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.ProductosTipo", "IdTipoNavigation").WithMany("StockProductos").HasForeignKey("IdTipo")
					.IsRequired()
					.HasConstraintName("FK_PRODUCTOS_PRODUCTOS_TIPOS");
				b.Navigation("IdDescripcionNavigation");
				b.Navigation("IdEstadoNavigation");
				b.Navigation("IdTipoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosDescripcion", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosProductosDescripciones", "IdEstadoNavigation").WithMany("ProductosDescripcions").HasForeignKey("IdEstadoMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdEstadoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosTipo", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosTiposProductos", "IdEstadoNavigation").WithMany("ProductosTipos").HasForeignKey("IdEstadoMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdEstadoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Productos_Componentes", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosProductosComponentes", "IdEstadoNavigation").WithMany("ProductosComponentes").HasForeignKey("IdEstadoMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdEstadoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Productos_Tipos_Descripcion", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.ProductosDescripcion", "IdDescripcionNavigation").WithMany("Producto_Tipo_Descripcione").HasForeignKey("IdDescripcion")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired()
					.HasConstraintName("FK_PRODUCTOS_TIPOS_DESCRIPCION_ID_DESCRIPCION");
				b.HasOne("Aponus_Web_API.Modelos.ProductosTipo", "IdTipoNavigation").WithMany("Producto_Tipo_Descripcione").HasForeignKey("IdTipo")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired()
					.HasConstraintName("FK_PRODUCTOS_TIPOS_DESCRIPCION_ID_TIPO");
				b.Navigation("IdDescripcionNavigation");
				b.Navigation("IdTipoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Stock_Movimientos", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosMovimientosStock", "estadoMovimiento").WithMany("movimientosStock").HasForeignKey("IdEstadoMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Entidades", "IdProveedor").WithMany("Movimientos").HasForeignKey("IdEntidad")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Entidades", "ProveedorOrigen").WithMany("MovimientosOrigen").HasForeignKey("IdProveedorOrigen")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdProveedor");
				b.Navigation("ProveedorOrigen");
				b.Navigation("estadoMovimiento");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.SuministrosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosSuministrosMovimientosStock", "EstadosSuministrosMovimientosStockNavigation").WithMany("SuministrosMovimientoStock").HasForeignKey("IdEstadoMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Stock_Movimientos", null).WithMany("Suministros").HasForeignKey("IdMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("EstadosSuministrosMovimientosStockNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Usuarios", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.PerfilesUsuarios", "Perfil").WithMany("UsuariosNavigation").HasForeignKey("IdPerfil")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_USUARIOS_PERFILES_USUARIOS_ID_PERFIL");
				b.Navigation("Perfil");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Ventas", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Entidades", "Cliente").WithMany("ventas").HasForeignKey("IdEntidad")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.EstadosVentas", "Estado").WithMany("ventas").HasForeignKey("IdEstadoVenta")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Usuarios", "Usuario").WithMany("Ventas").HasForeignKey("IdUsuario")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired();
				b.Navigation("Cliente");
				b.Navigation("Estado");
				b.Navigation("Usuario");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.VentasDetalles", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Producto", "IdProductoNavigation").WithMany("Ventas").HasForeignKey("IdProducto")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_VENTAS_DETALLES_PRODUCTOS_ID_PRODUCTO");
				b.HasOne("Aponus_Web_API.Modelos.Ventas", "Venta").WithMany("DetallesVenta").HasForeignKey("IdVenta")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdProductoNavigation");
				b.Navigation("Venta");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComponentesDetalle", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ComprasNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Compras", delegate(EntityTypeBuilder b)
			{
				b.Navigation("DetallesCompra");
				b.Navigation("Pagos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Entidades", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Movimientos");
				b.Navigation("MovimientosOrigen");
				b.Navigation("compras");
				b.Navigation("ventas");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesCategorias", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Entidades");
				b.Navigation("TiposCategoriasNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesTipos", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Entidades");
				b.Navigation("TiposCategoriasNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosArchivosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ArchivosMovimientoStock");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosComponentesDetalles", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ComponentesDetalle");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCompras", delegate(EntityTypeBuilder b)
			{
				b.Navigation("compras");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCuotasVentas", delegate(EntityTypeBuilder b)
			{
				b.Navigation("IdEstadoCuotaNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Navigation("movimientosStock");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductos", delegate(EntityTypeBuilder b)
			{
				b.Navigation("StockProductos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductosComponentes", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ProductosComponentes");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductosDescripciones", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ProductosDescripcions");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosSuministrosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Navigation("SuministrosMovimientoStock");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosTiposProductos", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ProductosTipos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosVentas", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ventas");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.MediosPago", delegate(EntityTypeBuilder b)
			{
				b.Navigation("PagosComprasNavigation");
				b.Navigation("PagosVentasNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PerfilesUsuarios", delegate(EntityTypeBuilder b)
			{
				b.Navigation("UsuariosNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Producto", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Ventas");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosDescripcion", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Producto_Tipo_Descripcione");
				b.Navigation("StockProductos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosTipo", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Producto_Tipo_Descripcione");
				b.Navigation("StockProductos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Stock_Movimientos", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Suministros");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Usuarios", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Compras");
				b.Navigation("IdUsuarioRegistroNavigation");
				b.Navigation("Ventas");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Ventas", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Cuotas");
				b.Navigation("DetallesVenta");
				b.Navigation("Pagos");
			});
		}
	}
	[DbContext(typeof(AponusContext))]
	[Migration("20240930092411_Correciones en Movimientos")]
	public class CorrecionesenMovimientos : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn("VALOR_ANTERIOR_DESTINO", "SUMINISTROS_MOVIMIENTOS_STOCK");
			migrationBuilder.DropColumn("VALOR_ANTERIOR_ORIGEN", "SUMINISTROS_MOVIMIENTOS_STOCK");
			migrationBuilder.DropColumn("VALOR_NUEVO_DESTINO", "SUMINISTROS_MOVIMIENTOS_STOCK");
			migrationBuilder.DropColumn("VALOR_NUEVO_ORIGEN", "SUMINISTROS_MOVIMIENTOS_STOCK");
			migrationBuilder.CreateIndex("IX_STOCK_MOVIMIENTOS_ID_ESTADO_MOVIMIENTO", "STOCK_MOVIMIENTOS", "ID_ESTADO_MOVIMIENTO");
			migrationBuilder.CreateIndex("IX_COMPRAS_ID_ESTADO_COMPRA", "COMPRAS", "ID_ESTADO_COMPRA");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey("FK_COMPRAS_ESTADOS_COMPRAS_EstadoIdEstadoCompra", "COMPRAS");
			migrationBuilder.DropForeignKey("FK_STOCK_MOVIMIENTOS_ESTADOS_MOVIMIENTOS_STOCK_ID_ESTADO_MOVIM~", "STOCK_MOVIMIENTOS");
			migrationBuilder.DropForeignKey("FK_SUMINISTROS_MOVIMIENTOS_STOCK_ESTADOS_SUMINISTROS_MOVIMIENTO", "SUMINISTROS_MOVIMIENTOS_STOCK");
			migrationBuilder.DropPrimaryKey("PK_ESTADOS_MOVIMIENTOS_STOCK", "ESTADOS_MOVIMIENTOS_STOCK");
			migrationBuilder.DropIndex("IX_COMPRAS_EstadoIdEstadoCompra", "COMPRAS");
			migrationBuilder.DropColumn("ID_ESTADO_MOVIMIENTO", "ESTADOS_MOVIMIENTOS_STOCK");
			migrationBuilder.DropColumn("EstadoIdEstadoCompra", "COMPRAS");
			migrationBuilder.RenameColumn("ID_ESTADO_MOVIMIENTO", "STOCK_MOVIMIENTOS", "ID_ESTADO");
			migrationBuilder.RenameIndex("IX_STOCK_MOVIMIENTOS_ID_ESTADO_MOVIMIENTO", "IX_STOCK_MOVIMIENTOS_ID_ESTADO", "STOCK_MOVIMIENTOS");
			Type typeFromHandle = typeof(string);
			migrationBuilder.AlterColumn<string>("ID_SUMINISTRO", "SUMINISTROS_MOVIMIENTOS_STOCK", "nvarchar(50)", null, null, rowVersion: false, null, nullable: false, null, null, null, typeFromHandle, "varchar(50)");
			migrationBuilder.AddColumn<decimal>("VALOR_ANTERIOR_DESTINO", "SUMINISTROS_MOVIMIENTOS_STOCK", "numeric(18,2)", null, null, rowVersion: false, null, nullable: true);
			migrationBuilder.AddColumn<decimal>("VALOR_ANTERIOR_ORIGEN", "SUMINISTROS_MOVIMIENTOS_STOCK", "numeric(18,2)", null, null, rowVersion: false, null, nullable: true);
			migrationBuilder.AddColumn<decimal>("VALOR_NUEVO_DESTINO", "SUMINISTROS_MOVIMIENTOS_STOCK", "numeric", null, null, rowVersion: false, null, nullable: true);
			migrationBuilder.AddColumn<decimal>("VALOR_NUEVO_ORIGEN", "SUMINISTROS_MOVIMIENTOS_STOCK", "numeric(18,2)", null, null, rowVersion: false, null, nullable: true);
			typeFromHandle = typeof(string);
			migrationBuilder.AlterColumn<string>("USUARIO_MODIFICA", "STOCK_MOVIMIENTOS", "nvarchar(50)", null, null, rowVersion: false, null, nullable: false, "", null, null, typeFromHandle, "varchar(50)", null, null, oldRowVersion: false, oldNullable: true);
			typeFromHandle = typeof(string);
			migrationBuilder.AlterColumn<string>("USUARIO_CREADO", "STOCK_MOVIMIENTOS", "nvarchar(50)", null, null, rowVersion: false, null, nullable: false, null, null, null, typeFromHandle, "varchar(50)");
			typeFromHandle = typeof(string);
			migrationBuilder.AlterColumn<string>("ID_TIPO", "PRODUCTOS_TIPOS_DESCRIPCION", "character varying(50)", null, null, rowVersion: false, null, nullable: false, null, null, null, typeFromHandle, "varchar(50)");
			typeFromHandle = typeof(string);
			migrationBuilder.AlterColumn<string>("DESCRIPCION", "MEDIOS_PAGO", "nvarchar(max)", null, null, rowVersion: false, null, nullable: false, null, null, null, typeFromHandle, "text");
			typeFromHandle = typeof(string);
			migrationBuilder.AlterColumn<string>("CODIGO_MPAGO", "MEDIOS_PAGO", "nvarchar(max)", null, null, rowVersion: false, null, nullable: true, null, null, null, typeFromHandle, "text", null, null, oldRowVersion: false, oldNullable: true);
			typeFromHandle = typeof(string);
			migrationBuilder.AlterColumn<string>("DESCRIPCION", "ESTADOS_VENTAS", "nvarchar(max)", null, null, rowVersion: false, null, nullable: false, null, null, null, typeFromHandle, "text");
			typeFromHandle = typeof(string);
			migrationBuilder.AlterColumn<string>("DESCRIPCION", "ESTADOS_SUMINISTROS_MOVIMIENTOS_STOCK", "nvarchar(max)", null, null, rowVersion: false, null, nullable: false, null, null, null, typeFromHandle, "text");
			typeFromHandle = typeof(string);
			migrationBuilder.AlterColumn<string>("DESCRIPCION", "ESTADOS_PRODUCTOS_TIPOS", "nvarchar(max)", null, null, rowVersion: false, null, nullable: false, null, null, null, typeFromHandle, "text");
			typeFromHandle = typeof(string);
			migrationBuilder.AlterColumn<string>("DESCRIPCION", "ESTADOS_PRODUCTOS_DESCRIPCIONES", "nvarchar(max)", null, null, rowVersion: false, null, nullable: false, null, null, null, typeFromHandle, "text");
			typeFromHandle = typeof(string);
			migrationBuilder.AlterColumn<string>("DESCRIPCION", "ESTADOS_PRODUCTOS_COMPONENTES", "nvarchar(max)", null, null, rowVersion: false, null, nullable: false, null, null, null, typeFromHandle, "text");
			typeFromHandle = typeof(string);
			migrationBuilder.AlterColumn<string>("DESCRIPCION", "ESTADOS_PRODUCTOS", "nvarchar(max)", null, null, rowVersion: false, null, nullable: false, null, null, null, typeFromHandle, "text");
			typeFromHandle = typeof(int);
			migrationBuilder.AlterColumn<int>("ID_ESTADO", "ESTADOS_MOVIMIENTOS_STOCK", "integer", null, null, rowVersion: false, null, nullable: false, null, "1", null, typeFromHandle, "integer", null, null, oldRowVersion: false, oldNullable: false, null, "1").Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
			typeFromHandle = typeof(string);
			migrationBuilder.AlterColumn<string>("DESCRIPCION", "ESTADOS_MOVIMIENTOS_STOCK", "nvarchar(max)", null, null, rowVersion: false, null, nullable: false, null, null, null, typeFromHandle, "text");
			typeFromHandle = typeof(string);
			migrationBuilder.AlterColumn<string>("DESCRIPCION", "ESTADOS_CUOTAS_VENTAS", "varchar(MAX)", null, null, rowVersion: false, null, nullable: false, null, null, null, typeFromHandle, "text");
			typeFromHandle = typeof(string);
			migrationBuilder.AlterColumn<string>("DESCRIPCION", "ESTADOS_COMPRAS", "nvarchar(max)", null, null, rowVersion: false, null, nullable: false, null, null, null, typeFromHandle, "text");
			typeFromHandle = typeof(string);
			migrationBuilder.AlterColumn<string>("DESCRIPCION", "ESTADOS_COMPONENTES_DETALLES", "nvarchar(max)", null, null, rowVersion: false, null, nullable: false, null, null, null, typeFromHandle, "text");
			typeFromHandle = typeof(string);
			migrationBuilder.AlterColumn<string>("DESCRIPCION", "ESTADOS_ARCHIVOS_MOVIMIENTOS_STOCK", "nvarchar(max)", null, null, rowVersion: false, null, nullable: false, null, null, null, typeFromHandle, "text");
			typeFromHandle = typeof(string);
			migrationBuilder.AlterColumn<string>("NOMBRE", "ENTIDADES_TIPOS", "nvarchar(max)", null, null, rowVersion: false, null, nullable: false, null, null, null, typeFromHandle, "text");
			typeFromHandle = typeof(string);
			migrationBuilder.AlterColumn<string>("NOMBRE_CATEGORIA", "ENTIDADES_CATEGORIAS", "nvarchar(max)", null, null, rowVersion: false, null, nullable: false, null, null, null, typeFromHandle, "text");
			typeFromHandle = typeof(string);
			migrationBuilder.AlterColumn<string>("NOMBRE_CLAVE", "ENTIDADES", "text", null, null, rowVersion: false, null, nullable: false, "", null, null, typeFromHandle, "text", null, null, oldRowVersion: false, oldNullable: true);
			typeFromHandle = typeof(string);
			migrationBuilder.AlterColumn<string>("NOMBRE", "ENTIDADES", "varchar(max)", null, null, rowVersion: false, null, nullable: true, null, null, null, typeFromHandle, "text", null, null, oldRowVersion: false, oldNullable: true);
			typeFromHandle = typeof(string);
			migrationBuilder.AlterColumn<string>("LOCALIDAD", "ENTIDADES", "varchar(MAX)", null, null, rowVersion: false, null, nullable: true, null, null, null, typeFromHandle, "text", null, null, oldRowVersion: false, oldNullable: true);
			typeFromHandle = typeof(string);
			migrationBuilder.AlterColumn<string>("BARRIO", "ENTIDADES", "varchar(max)", null, null, rowVersion: false, null, nullable: true, null, null, null, typeFromHandle, "text", null, null, oldRowVersion: false, oldNullable: true);
			typeFromHandle = typeof(string);
			migrationBuilder.AlterColumn<string>("APELLIDO", "ENTIDADES", "varchar(max)", null, null, rowVersion: false, null, nullable: true, null, null, null, typeFromHandle, "text", null, null, oldRowVersion: false, oldNullable: true);
			typeFromHandle = typeof(string);
			migrationBuilder.AlterColumn<string>("ID_FRACCIONAMIENTO", "COMPONENTES_DETALLE", "nvarchar(50)", null, null, rowVersion: false, null, nullable: true, null, null, null, typeFromHandle, "varchar(50)", null, null, oldRowVersion: false, oldNullable: true);
			typeFromHandle = typeof(string);
			migrationBuilder.AlterColumn<string>("ID_ALMACENAMIENTO", "COMPONENTES_DETALLE", "nvarchar(50)", null, null, rowVersion: false, null, nullable: true, null, null, null, typeFromHandle, "varchar(50)", null, null, oldRowVersion: false, oldNullable: true);
			typeFromHandle = typeof(string);
			migrationBuilder.AlterColumn<string>("PATH", "ARCHIVOS_STOCK", "varchar(MAX)", null, null, rowVersion: false, null, nullable: false, null, null, null, typeFromHandle, "text");
			typeFromHandle = typeof(string);
			migrationBuilder.AlterColumn<string>("MIME_TYPE", "ARCHIVOS_STOCK", "varchar(MAX)", null, null, rowVersion: false, null, nullable: true, null, null, null, typeFromHandle, "text", null, null, oldRowVersion: false, oldNullable: true);
			migrationBuilder.AddPrimaryKey("PK_ESTADOS_MOVIMIENTOS_STOCK", "ESTADOS_MOVIMIENTOS_STOCK", "ID_ESTADO");
			migrationBuilder.CreateIndex("IX_COMPRAS_ID_ESTADO_COMPRA", "COMPRAS", "ID_ESTADO_COMPRA");
			migrationBuilder.AddForeignKey("FK_COMPRAS_ESTADOS_COMPRAS_ID_ESTADO_COMPRA", "COMPRAS", "ID_ESTADO_COMPRA", "ESTADOS_COMPRAS", null, null, "ID_ESTADO_COMPRA", ReferentialAction.NoAction, ReferentialAction.Cascade);
			migrationBuilder.AddForeignKey("FK_STOCK_MOVIMIENTOS_ESTADOS_MOVIMIENTOS_STOCK_ID_ESTADO", "STOCK_MOVIMIENTOS", "ID_ESTADO", "ESTADOS_MOVIMIENTOS_STOCK", null, null, "ID_ESTADO", ReferentialAction.NoAction, ReferentialAction.Cascade);
			migrationBuilder.AddForeignKey("FK_SUMINISTROS_MOVIMIENTOS_STOCK_ESTADOS_SUMINISTROS_MOVIMIENT~", "SUMINISTROS_MOVIMIENTOS_STOCK", "ID_ESTADO", "ESTADOS_SUMINISTROS_MOVIMIENTOS_STOCK", null, null, "ID_ESTADO", ReferentialAction.NoAction, ReferentialAction.Cascade);
		}

		protected override void BuildTargetModel(ModelBuilder modelBuilder)
		{
			modelBuilder.UseCollation("Modern_Spanish_CI_AI").HasAnnotation("ProductVersion", "7.0.11").HasAnnotation("Proxies:ChangeTracking", false)
				.HasAnnotation("Proxies:CheckEquality", false)
				.HasAnnotation("Proxies:LazyLoading", true)
				.HasAnnotation("Relational:MaxIdentifierLength", 63);
			modelBuilder.UseIdentityByDefaultColumns();
			modelBuilder.Entity("Aponus_Web_API.Modelos.ArchivosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdMovimiento").HasColumnType("int").HasColumnName("ID_MOVIMIENTO");
				b.Property<string>("HashArchivo").HasColumnType("varchar(255)").HasColumnName("HASH_ARCHIVO");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("MimeType").HasColumnType("text").HasColumnName("MIME_TYPE");
				b.Property<string>("PathArchivo").IsRequired().HasColumnType("text")
					.HasColumnName("PATH");
				b.HasKey("IdMovimiento", "HashArchivo");
				b.HasIndex("IdEstado");
				b.ToTable("ARCHIVOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComponentesDescripcion", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdDescripcion").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_DESCRIPCION");
				b.Property<int>("IdDescripcion").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdDescripcion");
				b.ToTable("COMPONENTES_DESCRIPCION", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComponentesDetalle", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdInsumo").HasColumnType("varchar(50)").HasColumnName("ID_INSUMO");
				b.Property<decimal?>("Altura").HasColumnType("decimal(18,2)").HasColumnName("ALTURA");
				b.Property<decimal?>("Diametro").HasColumnType("decimal(18,2)").HasColumnName("DIAMETRO");
				b.Property<int?>("DiametroNominal").HasColumnType("int").HasColumnName("DIAMETRO_NOMINAL");
				b.Property<decimal?>("Espesor").HasColumnType("decimal(18,2)").HasColumnName("ESPESOR");
				b.Property<string>("IdAlmacenamiento").HasColumnType("varchar(50)").HasColumnName("ID_ALMACENAMIENTO");
				b.Property<int>("IdDescripcion").HasColumnType("integer").HasColumnName("ID_DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("IdFraccionamiento").HasColumnType("varchar(50)").HasColumnName("ID_FRACCIONAMIENTO");
				b.Property<decimal?>("Longitud").HasColumnType("decimal(18,2)").HasColumnName("LONGITUD");
				b.Property<int?>("Perfil").HasColumnType("integer").HasColumnName("PERFIL");
				b.Property<decimal?>("Peso").HasColumnType("decimal(18,3)").HasColumnName("PESO");
				b.Property<string>("Tolerancia").HasColumnType("varchar(50)").HasColumnName("TOLERANCIA");
				b.HasKey("IdInsumo").HasName("PK_ID_INSUMO");
				b.HasIndex("IdEstado");
				b.ToTable("COMPONENTES_DETALLE", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Compras", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCompra").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_COMPRA");
				b.Property<int>("IdCompra").UseIdentityByDefaultColumn();
				b.Property<int>("EstadoIdEstadoCompra").HasColumnType("int");
				b.Property<DateTime>("FechaHora").HasColumnType("timestamp").HasColumnName("FECHA_HORA");
				b.Property<int>("IdEstadoCompra").HasColumnType("int").HasColumnName("ID_ESTADO_COMPRA");
				b.Property<int>("IdProveedor").HasColumnType("int").HasColumnName("ID_PROVEEDOR");
				b.Property<string>("IdUsuario").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("ID_USUARIO");
				b.Property<decimal?>("SaldoPendiente").HasColumnType("decimal(18,2)").HasColumnName("SALDO_CANCELADO");
				b.Property<decimal>("MontoTotal").HasColumnType("decimal(18,2)").HasColumnName("SALDO_TOTAL");
				b.HasKey("IdCompra");
				b.HasIndex("EstadoIdEstadoCompra");
				b.HasIndex("IdProveedor");
				b.HasIndex("IdUsuario");
				b.ToTable("COMPRAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComprasDetalles", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCompra").HasColumnType("int").HasColumnName("ID_COMPRA");
				b.Property<string>("IdInsumo").HasColumnType("varchar(50)").HasColumnName("ID_INSUMO");
				b.Property<decimal>("Cantidad").HasColumnType("decimal(18,2)").HasColumnName("CANTIDAD");
				b.HasKey("IdCompra", "IdInsumo");
				b.HasIndex("IdInsumo");
				b.ToTable("COMPRAS_DETALLE", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.CuotasVentas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCuota").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_CUOTA");
				b.Property<int>("IdCuota").UseIdentityByDefaultColumn();
				b.Property<DateTime?>("Fecha").HasColumnType("timestamp").HasColumnName("FECHA_PAGO");
				b.Property<DateTime>("FechaVencimiento").HasColumnType("timestamp").HasColumnName("FECHA_VENCIMIENTO");
				b.Property<int>("IdEstadoCuota").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_CUOTA")
					.HasDefaultValueSql("1");
				b.Property<int>("IdVenta").HasColumnType("int").HasColumnName("ID_VENTA");
				b.Property<decimal>("Monto").ValueGeneratedOnAdd().HasColumnType("decimal(18,2)")
					.HasColumnName("MONTO")
					.HasDefaultValueSql("0.00");
				b.Property<int>("NumeroCuota").HasColumnType("int").HasColumnName("NUMERO_CUOTA");
				b.HasKey("IdCuota");
				b.HasIndex("IdEstadoCuota");
				b.HasIndex("IdVenta");
				b.ToTable("CUOTAS_VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Entidades", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEntidad").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ENTIDAD");
				b.Property<int>("IdEntidad").UseIdentityByDefaultColumn();
				b.Property<string>("Altura").HasColumnType("text").HasColumnName("ALTURA");
				b.Property<string>("Apellido").HasColumnType("text").HasColumnName("APELLIDO");
				b.Property<string>("Barrio").HasColumnType("text").HasColumnName("BARRIO");
				b.Property<string>("Calle").HasColumnType("text").HasColumnName("CALLE");
				b.Property<string>("Ciudad").HasColumnType("text").HasColumnName("CIUDAD");
				b.Property<string>("CodigoPostal").HasColumnType("text").HasColumnName("CODIGO_POSTAL");
				b.Property<string>("Email").HasColumnType("text").HasColumnName("EMAIL");
				b.Property<DateTime>("FechaRegistro").HasColumnType("timestamp").HasColumnName("FECHA_REGISTRO");
				b.Property<int>("IdCategoria").HasColumnType("int").HasColumnName("ID_CATEGORIA");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("(1)");
				b.Property<string>("IdFiscal").IsRequired().HasColumnType("text")
					.HasColumnName("ID_FISCAL");
				b.Property<int>("IdTipo").HasColumnType("int").HasColumnName("ID_TIPO");
				b.Property<string>("IdUsuarioRegistro").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("ID_USUARIO_REGISTRO");
				b.Property<string>("Localidad").HasColumnType("text").HasColumnName("LOCALIDAD");
				b.Property<string>("Nombre").HasColumnType("text").HasColumnName("NOMBRE");
				b.Property<string>("NombreClave").HasColumnType("text").HasColumnName("NOMBRE_CLAVE");
				b.Property<string>("Pais").HasColumnType("text").HasColumnName("PAIS");
				b.Property<string>("Provincia").HasColumnType("text").HasColumnName("PROVINCIA");
				b.Property<string>("Telefono1").HasColumnType("text").HasColumnName("TELEFONO_1");
				b.Property<string>("Telefono2").HasColumnType("text").HasColumnName("TELEFONO_2");
				b.Property<string>("Telefono3").HasColumnType("text").HasColumnName("TELEFONO_3");
				b.HasKey("IdEntidad");
				b.HasIndex("IdCategoria");
				b.HasIndex("IdTipo");
				b.HasIndex("IdUsuarioRegistro");
				b.ToTable("ENTIDADES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesCategorias", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCategoria").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_CATEGORIA");
				b.Property<int>("IdCategoria").UseIdentityByDefaultColumn();
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("NombreCategoria").IsRequired().HasColumnType("text")
					.HasColumnName("NOMBRE_CATEGORIA");
				b.HasKey("IdCategoria");
				b.ToTable("ENTIDADES_CATEGORIAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesTipos", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdTipo").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_TIPO");
				b.Property<int>("IdTipo").UseIdentityByDefaultColumn();
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("NombreTipo").IsRequired().HasColumnType("text")
					.HasColumnName("NOMBRE");
				b.HasKey("IdTipo");
				b.ToTable("ENTIDADES_TIPOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesTiposCategorias", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("idTipoEntidad").HasColumnType("int").HasColumnName("ID_TIPO");
				b.Property<int>("IdCategoriaEntidad").HasColumnType("int").HasColumnName("ID_CATEGORIA");
				b.HasKey("idTipoEntidad", "IdCategoriaEntidad");
				b.HasIndex("IdCategoriaEntidad");
				b.ToTable("ENTIDADES_TIPOS_CATEGORIAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosArchivosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_ARCHIVOS_MOVIMIENTOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosComponentesDetalles", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_COMPONENTES_DETALLES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCompras", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoCompra").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_COMPRA")
					.HasAnnotation("SqlServer:Identity", "1, 1");
				b.Property<int>("IdEstadoCompra").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").HasColumnType("int").HasColumnName("ID_ESTADO");
				b.HasKey("IdEstadoCompra");
				b.ToTable("ESTADOS_COMPRAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCuotasVentas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoCuota").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_CUOTA");
				b.Property<int>("IdEstadoCuota").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.HasKey("IdEstadoCuota");
				b.ToTable("ESTADOS_CUOTAS_VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int?>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_MOVIMIENTO");
				b.Property<int?>("IdEstadoMovimiento").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.HasKey("IdEstadoMovimiento");
				b.ToTable("ESTADOS_MOVIMIENTOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductos", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_PRODUCTOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductosComponentes", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_PRODUCTOS_COMPONENTES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductosDescripciones", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_PRODUCTOS_DESCRIPCIONES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosSuministrosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_SUMINISTROS_MOVIMIENTOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosTiposProductos", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_PRODUCTOS_TIPOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosVentas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoVenta").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_VENTA");
				b.Property<int>("IdEstadoVenta").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("int")
					.HasDefaultValue(1)
					.HasColumnName("ID_ESTADO");
				b.HasKey("IdEstadoVenta");
				b.ToTable("ESTADOS_VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.MediosPago", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdMedioPago").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_MEDIO_PAGO");
				b.Property<int>("IdMedioPago").UseIdentityByDefaultColumn();
				b.Property<string>("CodigoMPago").HasColumnType("text").HasColumnName("CODIGO_MPAGO");
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("int")
					.HasDefaultValue(1)
					.HasColumnName("ID_ESTADO");
				b.HasKey("IdMedioPago");
				b.ToTable("MEDIOS_PAGO", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PagosCompras", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdPago").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_PAGO")
					.HasColumnOrder(2);
				b.Property<int>("IdPago").UseIdentityByDefaultColumn();
				b.Property<int?>("CantidadCuotas").HasColumnType("int").HasColumnName("CANTIDAD_CUOTAS");
				b.Property<int?>("CantidadCuotasCanceladas").HasColumnType("int").HasColumnName("CANTIDAD_CUOTAS_CANCELADAS");
				b.Property<int>("IdCompra").HasColumnType("int").HasColumnName("ID_COMPRA");
				b.Property<int>("IdMedioPago").HasColumnType("int").HasColumnName("ID_MEDIO_PAGO");
				b.Property<decimal>("Monto").HasColumnType("decimal(18,2)").HasColumnName("SUBTOTAL");
				b.Property<decimal?>("SaldoPendiente").HasColumnType("decimal(18,2)").HasColumnName("SUBTOTAL_CANCELADO");
				b.Property<decimal>("MontoCompra").HasColumnType("decimal(18,2)").HasColumnName("TOTAL");
				b.HasKey("IdPago");
				b.HasIndex("IdCompra");
				b.HasIndex("IdMedioPago");
				b.ToTable("PAGOS_COMPRAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PagosVentas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdPago").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_PAGO")
					.HasColumnOrder(2);
				b.Property<int>("IdPago").UseIdentityByDefaultColumn();
				b.Property<DateTime?>("Fecha").HasColumnType("timestamp").HasColumnName("FECHA");
				b.Property<int>("IdMedioPago").HasColumnType("int").HasColumnName("ID_MEDIO_PAGO");
				b.Property<int>("IdVenta").HasColumnType("int").HasColumnName("ID_VENTA");
				b.Property<decimal>("Monto").HasColumnType("decimal(18,2)").HasColumnName("MONTO");
				b.HasKey("IdPago");
				b.HasIndex("IdMedioPago");
				b.HasIndex("IdVenta");
				b.ToTable("PAGOS_VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PerfilesUsuarios", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdPerfil").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_PERFIL");
				b.Property<int>("IdPerfil").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("varcahr(100)")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").HasColumnType("integer").HasColumnName("ID_ESTADO");
				b.HasKey("IdPerfil");
				b.ToTable("USUARIOS_PERFILES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Producto", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdProducto").HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("ID_PRODUCTO");
				b.Property<int?>("Cantidad").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("CANTIDAD")
					.HasDefaultValueSql("((0))");
				b.Property<int?>("DiametroNominal").HasColumnType("integer").HasColumnName("DIAMETRO_NOMINAL");
				b.Property<int>("IdDescripcion").HasColumnType("integer").HasColumnName("ID_DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("IdTipo").IsRequired().HasMaxLength(50)
					.IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("ID_TIPO");
				b.Property<decimal?>("PorcentajeGanancia").HasColumnType("decimal(18,2)").HasColumnName("PORCENTAJE_GANANCIA");
				b.Property<decimal?>("PrecioFinal").HasColumnType("decimal(18,2)").HasColumnName("PRECIO_FINAL");
				b.Property<decimal?>("PrecioLista").ValueGeneratedOnAdd().HasColumnType("money")
					.HasColumnName("PRECIO_LISTA")
					.HasDefaultValueSql("((0))");
				b.Property<string>("Tolerancia").HasColumnType("text").HasColumnName("TOLERANCIA");
				b.HasKey("IdProducto");
				b.HasIndex("IdDescripcion");
				b.HasIndex("IdEstado");
				b.HasIndex("IdTipo");
				b.ToTable("PRODUCTOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosDescripcion", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdDescripcion").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_DESCRIPCION");
				b.Property<int>("IdDescripcion").UseIdentityByDefaultColumn();
				b.Property<string>("DescripcionProducto").HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.HasKey("IdDescripcion");
				b.HasIndex("IdEstado");
				b.ToTable("PRODUCTOS_DESCRIPCION", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosTipo", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdTipo").HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("ID_TIPO");
				b.Property<string>("DescripcionTipo").HasMaxLength(100).IsUnicode(unicode: false)
					.HasColumnType("character varying(100)")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.HasKey("IdTipo").HasName("PK_PRODUCTOS_TIPOS");
				b.HasIndex("IdEstado");
				b.ToTable("PRODUCTOS_TIPOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Productos_Componentes", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdProducto").HasColumnType("varchar(50)").HasColumnName("ID_PRODUCTO");
				b.Property<string>("IdComponente").HasColumnType("varchar(50)").HasColumnName("ID_COMPONENTE");
				b.Property<decimal?>("Cantidad").HasColumnType("decimal(18,2)").HasColumnName("CANTIDAD");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<decimal?>("Longitud").HasColumnType("decimal(18,2)").HasColumnName("LONGITUD");
				b.Property<decimal?>("Peso").HasColumnType("decimal(18,2)").HasColumnName("PESO");
				b.HasKey("IdProducto", "IdComponente").HasName("PK_PRODUCTOS_COMPONENTES");
				b.HasIndex("IdEstado");
				b.ToTable("PRODUCTOS_COMPONENTES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Productos_Tipos_Descripcion", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdTipo").HasColumnType("varchar(50)").HasColumnName("ID_TIPO");
				b.Property<int?>("IdDescripcion").HasColumnType("integer").HasColumnName("ID_DESCRIPCION");
				b.HasKey("IdTipo", "IdDescripcion");
				b.HasIndex("IdDescripcion");
				b.ToTable("PRODUCTOS_TIPOS_DESCRIPCION", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.StockInsumos", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdInsumo").HasColumnType("varchar(50)").HasColumnName("ID_INSUMO");
				b.Property<decimal?>("Granallado").HasColumnType("decimal").HasColumnName("GRANALLADO");
				b.Property<decimal?>("Moldeado").HasColumnType("decimal").HasColumnName("MOLDEADO");
				b.Property<decimal?>("Pendiente").HasColumnType("decimal(18,2)").HasColumnName("PENDIENTE");
				b.Property<decimal?>("Pintura").HasColumnType("decimal").HasColumnName("PINTURA");
				b.Property<decimal?>("Proceso").HasColumnType("decimal").HasColumnName("PROCESO");
				b.Property<decimal?>("Recibido").HasColumnType("decimal").HasColumnName("RECIBIDO");
				b.HasKey("IdInsumo").HasName("PK_STOCK_INSUMOS");
				b.ToTable("STOCK_INSUMOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Stock_Movimientos", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdMovimiento").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_MOVIMIENTO");
				b.Property<int>("IdMovimiento").UseIdentityByDefaultColumn();
				b.Property<string>("CreadoUsuario").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("USUARIO_CREADO");
				b.Property<string>("Destino").HasColumnType("varchar(50)").HasColumnName("DESTINO");
				b.Property<DateTime>("FechaHoraCreado").HasColumnType("timestamp").HasColumnName("FECHA_HORA_CREADO");
				b.Property<DateTime?>("FechaHoraUltimaModificacion").HasColumnType("timestamp").HasColumnName("FECHA_HORA_ULTIMA_MODIFICACION");
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_MOVIMIENTO")
					.HasDefaultValueSql("1");
				b.Property<int>("IdProveedor").HasColumnType("int").HasColumnName("ID_PROVEEDOR_DESTINO");
				b.Property<int>("IdProveedorOrigen").HasColumnType("int").HasColumnName("ID_PROVEEDOR_ORIGEN");
				b.Property<string>("ModificadoUsuario").HasColumnType("varchar(50)").HasColumnName("USUARIO_MODIFICA");
				b.Property<string>("Origen").HasColumnType("varchar(50)").HasColumnName("ORIGEN");
				b.Property<string>("Tipo").HasColumnType("varchar(15)").HasColumnName("TIPO");
				b.HasKey("IdMovimiento");
				b.HasIndex("IdEstadoMovimiento");
				b.HasIndex("IdProveedor");
				b.HasIndex("IdProveedorOrigen");
				b.ToTable("STOCK_MOVIMIENTOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.SuministrosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdMovimiento").HasColumnType("int").HasColumnName("ID_MOVIMIENTO");
				b.Property<string>("IdSuministro").HasColumnType("varchar(50)").HasColumnName("ID_SUMINISTRO");
				b.Property<decimal>("Cantidad").HasColumnType("decimal(18,2)").HasColumnName("CANTIDAD");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.HasKey("IdMovimiento", "IdSuministro");
				b.HasIndex("IdEstado");
				b.ToTable("SUMINISTROS_MOVIMIENTOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Usuarios", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("Usuario").HasColumnType("varchar(50)").HasColumnName("USUARIO");
				b.Property<string>("Contraseña").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("CONTRASEÑA");
				b.Property<int>("IdPerfil").HasColumnType("int").HasColumnName("ID_PERFIL");
				b.Property<string>("Correo").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("CORREO");
				b.HasKey("Usuario");
				b.HasIndex("IdPerfil");
				b.ToTable("USUARIOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Ventas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdVenta").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_VENTA");
				b.Property<int>("IdVenta").UseIdentityByDefaultColumn();
				b.Property<DateTime>("FechaHora").HasColumnType("timestamp").HasColumnName("FECHA_HORA");
				b.Property<int>("IdEntidad").HasColumnType("int").HasColumnName("ID_CLIENTE");
				b.Property<int>("IdEstadoVenta").HasColumnType("int").HasColumnName("ID_ESTADO_VENTA");
				b.Property<string>("IdUsuario").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("ID_USUARIO");
				b.Property<decimal>("SaldoPendiente").HasColumnType("numeric").HasColumnName("SALDO_PENDIENTE");
				b.Property<decimal>("MontoCompra").HasColumnType("decimal(18,2)").HasColumnName("TOTAL");
				b.HasKey("IdVenta");
				b.HasIndex("IdEntidad");
				b.HasIndex("IdEstadoVenta");
				b.HasIndex("IdUsuario");
				b.ToTable("VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.VentasDetalles", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdVenta").HasColumnType("int").HasColumnName("ID_VENTA");
				b.Property<string>("IdProducto").HasColumnType("varchar(50)").HasColumnName("ID_PRODUCTO");
				b.Property<decimal>("Cantidad").HasColumnType("decimal(18,2)").HasColumnName("CANTIDAD");
				b.Property<int?>("Entregados").HasColumnType("integer").HasColumnName("ENTREGADOS");
				b.Property<decimal>("Precio").HasColumnType("decimal(18,2)").HasColumnName("PRECIO");
				b.HasKey("IdVenta", "IdProducto");
				b.HasIndex("IdProducto");
				b.ToTable("VENTAS_DETALLES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ArchivosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosArchivosMovimientosStock", "ArchivosMovimientosStockNavigation").WithMany("ArchivosMovimientoStock").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Stock_Movimientos", "StockMovimiento").WithMany().HasForeignKey("IdMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_ARCHIVOS_STOCK_STOCK_MOVIMIENTOS_ID_MOVIMIENTO");
				b.Navigation("ArchivosMovimientosStockNavigation");
				b.Navigation("StockMovimiento");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComponentesDetalle", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosComponentesDetalles", "IdEstadoNavigation").WithMany("ComponentesDetalle").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdEstadoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Compras", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosCompras", "Estado").WithMany("compras").HasForeignKey("EstadoIdEstadoCompra")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Entidades", "IdProveedor").WithMany("compras").HasForeignKey("IdProveedor")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Usuarios", "Usuario").WithMany("Compras").HasForeignKey("IdUsuario")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired();
				b.Navigation("Estado");
				b.Navigation("IdProveedor");
				b.Navigation("Usuario");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComprasDetalles", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Compras", "CompraNavigation").WithMany("DetallesCompra").HasForeignKey("IdCompra")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.ComponentesDetalle", "DetallesInsumo").WithMany("ComprasNavigation").HasForeignKey("IdInsumo")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("CompraNavigation");
				b.Navigation("DetallesInsumo");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.CuotasVentas", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosCuotasVentas", "EstadoCuota").WithMany("IdEstadoCuotaNavigation").HasForeignKey("IdEstadoCuota")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Ventas", "Venta").WithMany("Cuotas").HasForeignKey("IdVenta")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("EstadoCuota");
				b.Navigation("Venta");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Entidades", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EntidadesCategorias", "CategoriaEntidad").WithMany("Entidades").HasForeignKey("IdCategoria")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.EntidadesTipos", "TipoEntidad").WithMany("Entidades").HasForeignKey("IdTipo")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Usuarios", "UsuarioRegistro").WithMany("IdUsuarioRegistroNavigation").HasForeignKey("IdUsuarioRegistro")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("CategoriaEntidad");
				b.Navigation("TipoEntidad");
				b.Navigation("UsuarioRegistro");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesTiposCategorias", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EntidadesCategorias", "CategoriaEntidad").WithMany("TiposCategoriasNavigation").HasForeignKey("IdCategoriaEntidad")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.EntidadesTipos", "TipoEntidad").WithMany("TiposCategoriasNavigation").HasForeignKey("idTipoEntidad")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("CategoriaEntidad");
				b.Navigation("TipoEntidad");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PagosCompras", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Compras", "CompraNavigation").WithMany("Pagos").HasForeignKey("IdCompra")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.MediosPago", "MedioPago").WithMany("PagosComprasNavigation").HasForeignKey("IdMedioPago")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("CompraNavigation");
				b.Navigation("MedioPago");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PagosVentas", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.MediosPago", "MedioPago").WithMany("PagosVentasNavigation").HasForeignKey("IdMedioPago")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Ventas", "Venta").WithMany("Pagos").HasForeignKey("IdVenta")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("MedioPago");
				b.Navigation("Venta");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Producto", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.ProductosDescripcion", "IdDescripcionNavigation").WithMany("StockProductos").HasForeignKey("IdDescripcion")
					.IsRequired()
					.HasConstraintName("FK_PRODUCTOS_PRODUCTOS_DESCRIPCION");
				b.HasOne("Aponus_Web_API.Modelos.EstadosProductos", "IdEstadoNavigation").WithMany("StockProductos").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.ProductosTipo", "IdTipoNavigation").WithMany("StockProductos").HasForeignKey("IdTipo")
					.IsRequired()
					.HasConstraintName("FK_PRODUCTOS_PRODUCTOS_TIPOS");
				b.Navigation("IdDescripcionNavigation");
				b.Navigation("IdEstadoNavigation");
				b.Navigation("IdTipoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosDescripcion", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosProductosDescripciones", "IdEstadoNavigation").WithMany("ProductosDescripcions").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdEstadoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosTipo", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosTiposProductos", "IdEstadoNavigation").WithMany("ProductosTipos").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdEstadoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Productos_Componentes", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosProductosComponentes", "IdEstadoNavigation").WithMany("ProductosComponentes").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdEstadoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Productos_Tipos_Descripcion", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.ProductosDescripcion", "IdDescripcionNavigation").WithMany("Producto_Tipo_Descripcione").HasForeignKey("IdDescripcion")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired()
					.HasConstraintName("FK_PRODUCTOS_TIPOS_DESCRIPCION_ID_DESCRIPCION");
				b.HasOne("Aponus_Web_API.Modelos.ProductosTipo", "IdTipoNavigation").WithMany("Producto_Tipo_Descripcione").HasForeignKey("IdTipo")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired()
					.HasConstraintName("FK_PRODUCTOS_TIPOS_DESCRIPCION_ID_TIPO");
				b.Navigation("IdDescripcionNavigation");
				b.Navigation("IdTipoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Stock_Movimientos", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosMovimientosStock", "estadoMovimiento").WithMany("movimientosStock").HasForeignKey("IdEstadoMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Entidades", "Proveeedor").WithMany("Movimientos").HasForeignKey("IdProveedor")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_STOCK_MOVIMIENTOS_ENTIDADES_ID_PROVEEDOR_DESTINO");
				b.HasOne("Aponus_Web_API.Modelos.Entidades", "ProveedorOrigen").WithMany("MovimientosOrigen").HasForeignKey("IdProveedorOrigen")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_STOCK_MOVIMIENTOS_ENTIDADES_ID_PROVEEDOR_ORIGEN");
				b.Navigation("Proveeedor");
				b.Navigation("ProveedorOrigen");
				b.Navigation("estadoMovimiento");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.SuministrosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosSuministrosMovimientosStock", "EstadosSuministrosMovimientosStockNavigation").WithMany("SuministrosMovimientoStock").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_SUMINISTROS_MOVIMIENTOS_STOCK_ESTADOS_SUMINISTROS_MOVIMIENTO");
				b.HasOne("Aponus_Web_API.Modelos.Stock_Movimientos", null).WithMany("Suministros").HasForeignKey("IdMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("EstadosSuministrosMovimientosStockNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Usuarios", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.PerfilesUsuarios", "Perfil").WithMany("UsuariosNavigation").HasForeignKey("IdPerfil")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_USUARIOS_PERFILES_USUARIOS_ID_PERFIL");
				b.Navigation("Perfil");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Ventas", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Entidades", "Cliente").WithMany("ventas").HasForeignKey("IdEntidad")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.EstadosVentas", "Estado").WithMany("ventas").HasForeignKey("IdEstadoVenta")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Usuarios", "Usuario").WithMany("Ventas").HasForeignKey("IdUsuario")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired();
				b.Navigation("Cliente");
				b.Navigation("Estado");
				b.Navigation("Usuario");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.VentasDetalles", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Producto", "IdProductoNavigation").WithMany("Ventas").HasForeignKey("IdProducto")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_VENTAS_DETALLES_PRODUCTOS_ID_PRODUCTO");
				b.HasOne("Aponus_Web_API.Modelos.Ventas", "Venta").WithMany("DetallesVenta").HasForeignKey("IdVenta")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdProductoNavigation");
				b.Navigation("Venta");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComponentesDetalle", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ComprasNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Compras", delegate(EntityTypeBuilder b)
			{
				b.Navigation("DetallesCompra");
				b.Navigation("Pagos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Entidades", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Movimientos");
				b.Navigation("MovimientosOrigen");
				b.Navigation("compras");
				b.Navigation("ventas");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesCategorias", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Entidades");
				b.Navigation("TiposCategoriasNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesTipos", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Entidades");
				b.Navigation("TiposCategoriasNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosArchivosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ArchivosMovimientoStock");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosComponentesDetalles", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ComponentesDetalle");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCompras", delegate(EntityTypeBuilder b)
			{
				b.Navigation("compras");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCuotasVentas", delegate(EntityTypeBuilder b)
			{
				b.Navigation("IdEstadoCuotaNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Navigation("movimientosStock");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductos", delegate(EntityTypeBuilder b)
			{
				b.Navigation("StockProductos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductosComponentes", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ProductosComponentes");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductosDescripciones", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ProductosDescripcions");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosSuministrosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Navigation("SuministrosMovimientoStock");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosTiposProductos", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ProductosTipos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosVentas", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ventas");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.MediosPago", delegate(EntityTypeBuilder b)
			{
				b.Navigation("PagosComprasNavigation");
				b.Navigation("PagosVentasNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PerfilesUsuarios", delegate(EntityTypeBuilder b)
			{
				b.Navigation("UsuariosNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Producto", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Ventas");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosDescripcion", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Producto_Tipo_Descripcione");
				b.Navigation("StockProductos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosTipo", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Producto_Tipo_Descripcione");
				b.Navigation("StockProductos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Stock_Movimientos", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Suministros");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Usuarios", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Compras");
				b.Navigation("IdUsuarioRegistroNavigation");
				b.Navigation("Ventas");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Ventas", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Cuotas");
				b.Navigation("DetallesVenta");
				b.Navigation("Pagos");
			});
		}
	}
	[DbContext(typeof(AponusContext))]
	[Migration("20240930104033_ModelSnapshotUpdate")]
	public class ModelSnapshotUpdate : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
		}

		protected override void BuildTargetModel(ModelBuilder modelBuilder)
		{
			modelBuilder.UseCollation("Modern_Spanish_CI_AI").HasAnnotation("ProductVersion", "7.0.11").HasAnnotation("Proxies:ChangeTracking", false)
				.HasAnnotation("Proxies:CheckEquality", false)
				.HasAnnotation("Proxies:LazyLoading", true)
				.HasAnnotation("Relational:MaxIdentifierLength", 63);
			modelBuilder.UseIdentityByDefaultColumns();
			modelBuilder.Entity("Aponus_Web_API.Modelos.ArchivosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdMovimiento").HasColumnType("int").HasColumnName("ID_MOVIMIENTO");
				b.Property<string>("HashArchivo").HasColumnType("varchar(255)").HasColumnName("HASH_ARCHIVO");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("MimeType").HasColumnType("text").HasColumnName("MIME_TYPE");
				b.Property<string>("PathArchivo").IsRequired().HasColumnType("text")
					.HasColumnName("PATH");
				b.HasKey("IdMovimiento", "HashArchivo");
				b.HasIndex("IdEstado");
				b.ToTable("ARCHIVOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComponentesDescripcion", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdDescripcion").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_DESCRIPCION");
				b.Property<int>("IdDescripcion").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdDescripcion");
				b.ToTable("COMPONENTES_DESCRIPCION", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComponentesDetalle", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdInsumo").HasColumnType("varchar(50)").HasColumnName("ID_INSUMO");
				b.Property<decimal?>("Altura").HasColumnType("decimal(18,2)").HasColumnName("ALTURA");
				b.Property<decimal?>("Diametro").HasColumnType("decimal(18,2)").HasColumnName("DIAMETRO");
				b.Property<int?>("DiametroNominal").HasColumnType("int").HasColumnName("DIAMETRO_NOMINAL");
				b.Property<decimal?>("Espesor").HasColumnType("decimal(18,2)").HasColumnName("ESPESOR");
				b.Property<string>("IdAlmacenamiento").HasColumnType("varchar(50)").HasColumnName("ID_ALMACENAMIENTO");
				b.Property<int>("IdDescripcion").HasColumnType("integer").HasColumnName("ID_DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("IdFraccionamiento").HasColumnType("varchar(50)").HasColumnName("ID_FRACCIONAMIENTO");
				b.Property<decimal?>("Longitud").HasColumnType("decimal(18,2)").HasColumnName("LONGITUD");
				b.Property<int?>("Perfil").HasColumnType("integer").HasColumnName("PERFIL");
				b.Property<decimal?>("Peso").HasColumnType("decimal(18,3)").HasColumnName("PESO");
				b.Property<string>("Tolerancia").HasColumnType("varchar(50)").HasColumnName("TOLERANCIA");
				b.HasKey("IdInsumo").HasName("PK_ID_INSUMO");
				b.HasIndex("IdEstado");
				b.ToTable("COMPONENTES_DETALLE", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Compras", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCompra").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_COMPRA");
				b.Property<int>("IdCompra").UseIdentityByDefaultColumn();
				b.Property<int>("EstadoIdEstadoCompra").HasColumnType("int");
				b.Property<DateTime>("FechaHora").HasColumnType("timestamp").HasColumnName("FECHA_HORA");
				b.Property<int>("IdEstadoCompra").HasColumnType("int").HasColumnName("ID_ESTADO_COMPRA");
				b.Property<int>("IdProveedor").HasColumnType("int").HasColumnName("ID_PROVEEDOR");
				b.Property<string>("IdUsuario").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("ID_USUARIO");
				b.Property<decimal?>("SaldoPendiente").HasColumnType("decimal(18,2)").HasColumnName("SALDO_CANCELADO");
				b.Property<decimal>("MontoTotal").HasColumnType("decimal(18,2)").HasColumnName("SALDO_TOTAL");
				b.HasKey("IdCompra");
				b.HasIndex("EstadoIdEstadoCompra");
				b.HasIndex("IdProveedor");
				b.HasIndex("IdUsuario");
				b.ToTable("COMPRAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComprasDetalles", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCompra").HasColumnType("int").HasColumnName("ID_COMPRA");
				b.Property<string>("IdInsumo").HasColumnType("varchar(50)").HasColumnName("ID_INSUMO");
				b.Property<decimal>("Cantidad").HasColumnType("decimal(18,2)").HasColumnName("CANTIDAD");
				b.HasKey("IdCompra", "IdInsumo");
				b.HasIndex("IdInsumo");
				b.ToTable("COMPRAS_DETALLE", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.CuotasVentas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCuota").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_CUOTA");
				b.Property<int>("IdCuota").UseIdentityByDefaultColumn();
				b.Property<DateTime?>("Fecha").HasColumnType("timestamp").HasColumnName("FECHA_PAGO");
				b.Property<DateTime>("FechaVencimiento").HasColumnType("timestamp").HasColumnName("FECHA_VENCIMIENTO");
				b.Property<int>("IdEstadoCuota").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_CUOTA")
					.HasDefaultValueSql("1");
				b.Property<int>("IdVenta").HasColumnType("int").HasColumnName("ID_VENTA");
				b.Property<decimal>("Monto").ValueGeneratedOnAdd().HasColumnType("decimal(18,2)")
					.HasColumnName("MONTO")
					.HasDefaultValueSql("0.00");
				b.Property<int>("NumeroCuota").HasColumnType("int").HasColumnName("NUMERO_CUOTA");
				b.HasKey("IdCuota");
				b.HasIndex("IdEstadoCuota");
				b.HasIndex("IdVenta");
				b.ToTable("CUOTAS_VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Entidades", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEntidad").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ENTIDAD");
				b.Property<int>("IdEntidad").UseIdentityByDefaultColumn();
				b.Property<string>("Altura").HasColumnType("text").HasColumnName("ALTURA");
				b.Property<string>("Apellido").HasColumnType("text").HasColumnName("APELLIDO");
				b.Property<string>("Barrio").HasColumnType("text").HasColumnName("BARRIO");
				b.Property<string>("Calle").HasColumnType("text").HasColumnName("CALLE");
				b.Property<string>("Ciudad").HasColumnType("text").HasColumnName("CIUDAD");
				b.Property<string>("CodigoPostal").HasColumnType("text").HasColumnName("CODIGO_POSTAL");
				b.Property<string>("Email").HasColumnType("text").HasColumnName("EMAIL");
				b.Property<DateTime>("FechaRegistro").HasColumnType("timestamp").HasColumnName("FECHA_REGISTRO");
				b.Property<int>("IdCategoria").HasColumnType("int").HasColumnName("ID_CATEGORIA");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("(1)");
				b.Property<string>("IdFiscal").IsRequired().HasColumnType("text")
					.HasColumnName("ID_FISCAL");
				b.Property<int>("IdTipo").HasColumnType("int").HasColumnName("ID_TIPO");
				b.Property<string>("IdUsuarioRegistro").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("ID_USUARIO_REGISTRO");
				b.Property<string>("Localidad").HasColumnType("text").HasColumnName("LOCALIDAD");
				b.Property<string>("Nombre").HasColumnType("text").HasColumnName("NOMBRE");
				b.Property<string>("NombreClave").HasColumnType("text").HasColumnName("NOMBRE_CLAVE");
				b.Property<string>("Pais").HasColumnType("text").HasColumnName("PAIS");
				b.Property<string>("Provincia").HasColumnType("text").HasColumnName("PROVINCIA");
				b.Property<string>("Telefono1").HasColumnType("text").HasColumnName("TELEFONO_1");
				b.Property<string>("Telefono2").HasColumnType("text").HasColumnName("TELEFONO_2");
				b.Property<string>("Telefono3").HasColumnType("text").HasColumnName("TELEFONO_3");
				b.HasKey("IdEntidad");
				b.HasIndex("IdCategoria");
				b.HasIndex("IdTipo");
				b.HasIndex("IdUsuarioRegistro");
				b.ToTable("ENTIDADES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesCategorias", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCategoria").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_CATEGORIA");
				b.Property<int>("IdCategoria").UseIdentityByDefaultColumn();
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("NombreCategoria").IsRequired().HasColumnType("text")
					.HasColumnName("NOMBRE_CATEGORIA");
				b.HasKey("IdCategoria");
				b.ToTable("ENTIDADES_CATEGORIAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesTipos", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdTipo").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_TIPO");
				b.Property<int>("IdTipo").UseIdentityByDefaultColumn();
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("NombreTipo").IsRequired().HasColumnType("text")
					.HasColumnName("NOMBRE");
				b.HasKey("IdTipo");
				b.ToTable("ENTIDADES_TIPOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesTiposCategorias", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("idTipoEntidad").HasColumnType("int").HasColumnName("ID_TIPO");
				b.Property<int>("IdCategoriaEntidad").HasColumnType("int").HasColumnName("ID_CATEGORIA");
				b.HasKey("idTipoEntidad", "IdCategoriaEntidad");
				b.HasIndex("IdCategoriaEntidad");
				b.ToTable("ENTIDADES_TIPOS_CATEGORIAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosArchivosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_ARCHIVOS_MOVIMIENTOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosComponentesDetalles", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_COMPONENTES_DETALLES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCompras", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoCompra").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_COMPRA")
					.HasAnnotation("SqlServer:Identity", "1, 1");
				b.Property<int>("IdEstadoCompra").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").HasColumnType("int").HasColumnName("ID_ESTADO");
				b.HasKey("IdEstadoCompra");
				b.ToTable("ESTADOS_COMPRAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCuotasVentas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoCuota").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_CUOTA");
				b.Property<int>("IdEstadoCuota").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.HasKey("IdEstadoCuota");
				b.ToTable("ESTADOS_CUOTAS_VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int?>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_MOVIMIENTO");
				b.Property<int?>("IdEstadoMovimiento").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.HasKey("IdEstadoMovimiento");
				b.ToTable("ESTADOS_MOVIMIENTOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductos", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_PRODUCTOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductosComponentes", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_PRODUCTOS_COMPONENTES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductosDescripciones", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_PRODUCTOS_DESCRIPCIONES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosSuministrosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_SUMINISTROS_MOVIMIENTOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosTiposProductos", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_PRODUCTOS_TIPOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosVentas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoVenta").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_VENTA");
				b.Property<int>("IdEstadoVenta").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("int")
					.HasDefaultValue(1)
					.HasColumnName("ID_ESTADO");
				b.HasKey("IdEstadoVenta");
				b.ToTable("ESTADOS_VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.MediosPago", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdMedioPago").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_MEDIO_PAGO");
				b.Property<int>("IdMedioPago").UseIdentityByDefaultColumn();
				b.Property<string>("CodigoMPago").HasColumnType("text").HasColumnName("CODIGO_MPAGO");
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("int")
					.HasDefaultValue(1)
					.HasColumnName("ID_ESTADO");
				b.HasKey("IdMedioPago");
				b.ToTable("MEDIOS_PAGO", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PagosCompras", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdPago").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_PAGO")
					.HasColumnOrder(2);
				b.Property<int>("IdPago").UseIdentityByDefaultColumn();
				b.Property<int?>("CantidadCuotas").HasColumnType("int").HasColumnName("CANTIDAD_CUOTAS");
				b.Property<int?>("CantidadCuotasCanceladas").HasColumnType("int").HasColumnName("CANTIDAD_CUOTAS_CANCELADAS");
				b.Property<int>("IdCompra").HasColumnType("int").HasColumnName("ID_COMPRA");
				b.Property<int>("IdMedioPago").HasColumnType("int").HasColumnName("ID_MEDIO_PAGO");
				b.Property<decimal>("Monto").HasColumnType("decimal(18,2)").HasColumnName("SUBTOTAL");
				b.Property<decimal?>("SaldoPendiente").HasColumnType("decimal(18,2)").HasColumnName("SUBTOTAL_CANCELADO");
				b.Property<decimal>("MontoCompra").HasColumnType("decimal(18,2)").HasColumnName("TOTAL");
				b.HasKey("IdPago");
				b.HasIndex("IdCompra");
				b.HasIndex("IdMedioPago");
				b.ToTable("PAGOS_COMPRAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PagosVentas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdPago").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_PAGO")
					.HasColumnOrder(2);
				b.Property<int>("IdPago").UseIdentityByDefaultColumn();
				b.Property<DateTime?>("Fecha").HasColumnType("timestamp").HasColumnName("FECHA");
				b.Property<int>("IdMedioPago").HasColumnType("int").HasColumnName("ID_MEDIO_PAGO");
				b.Property<int>("IdVenta").HasColumnType("int").HasColumnName("ID_VENTA");
				b.Property<decimal>("Monto").HasColumnType("decimal(18,2)").HasColumnName("MONTO");
				b.HasKey("IdPago");
				b.HasIndex("IdMedioPago");
				b.HasIndex("IdVenta");
				b.ToTable("PAGOS_VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PerfilesUsuarios", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdPerfil").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_PERFIL");
				b.Property<int>("IdPerfil").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("varcahr(100)")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").HasColumnType("integer").HasColumnName("ID_ESTADO");
				b.HasKey("IdPerfil");
				b.ToTable("USUARIOS_PERFILES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Producto", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdProducto").HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("ID_PRODUCTO");
				b.Property<int?>("Cantidad").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("CANTIDAD")
					.HasDefaultValueSql("((0))");
				b.Property<int?>("DiametroNominal").HasColumnType("integer").HasColumnName("DIAMETRO_NOMINAL");
				b.Property<int>("IdDescripcion").HasColumnType("integer").HasColumnName("ID_DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("IdTipo").IsRequired().HasMaxLength(50)
					.IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("ID_TIPO");
				b.Property<decimal?>("PorcentajeGanancia").HasColumnType("decimal(18,2)").HasColumnName("PORCENTAJE_GANANCIA");
				b.Property<decimal?>("PrecioFinal").HasColumnType("decimal(18,2)").HasColumnName("PRECIO_FINAL");
				b.Property<decimal?>("PrecioLista").ValueGeneratedOnAdd().HasColumnType("money")
					.HasColumnName("PRECIO_LISTA")
					.HasDefaultValueSql("((0))");
				b.Property<string>("Tolerancia").HasColumnType("text").HasColumnName("TOLERANCIA");
				b.HasKey("IdProducto");
				b.HasIndex("IdDescripcion");
				b.HasIndex("IdEstado");
				b.HasIndex("IdTipo");
				b.ToTable("PRODUCTOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosDescripcion", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdDescripcion").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_DESCRIPCION");
				b.Property<int>("IdDescripcion").UseIdentityByDefaultColumn();
				b.Property<string>("DescripcionProducto").HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.HasKey("IdDescripcion");
				b.HasIndex("IdEstado");
				b.ToTable("PRODUCTOS_DESCRIPCION", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosTipo", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdTipo").HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("ID_TIPO");
				b.Property<string>("DescripcionTipo").HasMaxLength(100).IsUnicode(unicode: false)
					.HasColumnType("character varying(100)")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.HasKey("IdTipo").HasName("PK_PRODUCTOS_TIPOS");
				b.HasIndex("IdEstado");
				b.ToTable("PRODUCTOS_TIPOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Productos_Componentes", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdProducto").HasColumnType("varchar(50)").HasColumnName("ID_PRODUCTO");
				b.Property<string>("IdComponente").HasColumnType("varchar(50)").HasColumnName("ID_COMPONENTE");
				b.Property<decimal?>("Cantidad").HasColumnType("decimal(18,2)").HasColumnName("CANTIDAD");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<decimal?>("Longitud").HasColumnType("decimal(18,2)").HasColumnName("LONGITUD");
				b.Property<decimal?>("Peso").HasColumnType("decimal(18,2)").HasColumnName("PESO");
				b.HasKey("IdProducto", "IdComponente").HasName("PK_PRODUCTOS_COMPONENTES");
				b.HasIndex("IdEstado");
				b.ToTable("PRODUCTOS_COMPONENTES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Productos_Tipos_Descripcion", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdTipo").HasColumnType("varchar(50)").HasColumnName("ID_TIPO");
				b.Property<int?>("IdDescripcion").HasColumnType("integer").HasColumnName("ID_DESCRIPCION");
				b.HasKey("IdTipo", "IdDescripcion");
				b.HasIndex("IdDescripcion");
				b.ToTable("PRODUCTOS_TIPOS_DESCRIPCION", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.StockInsumos", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdInsumo").HasColumnType("varchar(50)").HasColumnName("ID_INSUMO");
				b.Property<decimal?>("Granallado").HasColumnType("decimal").HasColumnName("GRANALLADO");
				b.Property<decimal?>("Moldeado").HasColumnType("decimal").HasColumnName("MOLDEADO");
				b.Property<decimal?>("Pendiente").HasColumnType("decimal(18,2)").HasColumnName("PENDIENTE");
				b.Property<decimal?>("Pintura").HasColumnType("decimal").HasColumnName("PINTURA");
				b.Property<decimal?>("Proceso").HasColumnType("decimal").HasColumnName("PROCESO");
				b.Property<decimal?>("Recibido").HasColumnType("decimal").HasColumnName("RECIBIDO");
				b.HasKey("IdInsumo").HasName("PK_STOCK_INSUMOS");
				b.ToTable("STOCK_INSUMOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Stock_Movimientos", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdMovimiento").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_MOVIMIENTO");
				b.Property<int>("IdMovimiento").UseIdentityByDefaultColumn();
				b.Property<string>("CreadoUsuario").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("USUARIO_CREADO");
				b.Property<string>("Destino").HasColumnType("varchar(50)").HasColumnName("DESTINO");
				b.Property<DateTime>("FechaHoraCreado").HasColumnType("timestamp").HasColumnName("FECHA_HORA_CREADO");
				b.Property<DateTime?>("FechaHoraUltimaModificacion").HasColumnType("timestamp").HasColumnName("FECHA_HORA_ULTIMA_MODIFICACION");
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_MOVIMIENTO")
					.HasDefaultValueSql("1");
				b.Property<int>("IdProveedor").HasColumnType("int").HasColumnName("ID_PROVEEDOR_DESTINO");
				b.Property<int>("IdProveedorOrigen").HasColumnType("int").HasColumnName("ID_PROVEEDOR_ORIGEN");
				b.Property<string>("ModificadoUsuario").HasColumnType("varchar(50)").HasColumnName("USUARIO_MODIFICA");
				b.Property<string>("Origen").HasColumnType("varchar(50)").HasColumnName("ORIGEN");
				b.Property<string>("Tipo").HasColumnType("varchar(15)").HasColumnName("TIPO");
				b.HasKey("IdMovimiento");
				b.HasIndex("IdEstadoMovimiento");
				b.HasIndex("IdProveedor");
				b.HasIndex("IdProveedorOrigen");
				b.ToTable("STOCK_MOVIMIENTOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.SuministrosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdMovimiento").HasColumnType("int").HasColumnName("ID_MOVIMIENTO");
				b.Property<string>("IdSuministro").HasColumnType("varchar(50)").HasColumnName("ID_SUMINISTRO");
				b.Property<decimal>("Cantidad").HasColumnType("decimal(18,2)").HasColumnName("CANTIDAD");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.HasKey("IdMovimiento", "IdSuministro");
				b.HasIndex("IdEstado");
				b.ToTable("SUMINISTROS_MOVIMIENTOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Usuarios", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("Usuario").HasColumnType("varchar(50)").HasColumnName("USUARIO");
				b.Property<string>("Contraseña").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("CONTRASEÑA");
				b.Property<int>("IdPerfil").HasColumnType("int").HasColumnName("ID_PERFIL");
				b.Property<string>("Correo").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("CORREO");
				b.HasKey("Usuario");
				b.HasIndex("IdPerfil");
				b.ToTable("USUARIOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Ventas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdVenta").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_VENTA");
				b.Property<int>("IdVenta").UseIdentityByDefaultColumn();
				b.Property<DateTime>("FechaHora").HasColumnType("timestamp").HasColumnName("FECHA_HORA");
				b.Property<int>("IdEntidad").HasColumnType("int").HasColumnName("ID_CLIENTE");
				b.Property<int>("IdEstadoVenta").HasColumnType("int").HasColumnName("ID_ESTADO_VENTA");
				b.Property<string>("IdUsuario").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("ID_USUARIO");
				b.Property<decimal>("SaldoPendiente").HasColumnType("numeric").HasColumnName("SALDO_PENDIENTE");
				b.Property<decimal>("MontoCompra").HasColumnType("decimal(18,2)").HasColumnName("TOTAL");
				b.HasKey("IdVenta");
				b.HasIndex("IdEntidad");
				b.HasIndex("IdEstadoVenta");
				b.HasIndex("IdUsuario");
				b.ToTable("VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.VentasDetalles", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdVenta").HasColumnType("int").HasColumnName("ID_VENTA");
				b.Property<string>("IdProducto").HasColumnType("varchar(50)").HasColumnName("ID_PRODUCTO");
				b.Property<decimal>("Cantidad").HasColumnType("decimal(18,2)").HasColumnName("CANTIDAD");
				b.Property<int?>("Entregados").HasColumnType("integer").HasColumnName("ENTREGADOS");
				b.Property<decimal>("Precio").HasColumnType("decimal(18,2)").HasColumnName("PRECIO");
				b.HasKey("IdVenta", "IdProducto");
				b.HasIndex("IdProducto");
				b.ToTable("VENTAS_DETALLES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ArchivosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosArchivosMovimientosStock", "ArchivosMovimientosStockNavigation").WithMany("ArchivosMovimientoStock").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Stock_Movimientos", "StockMovimiento").WithMany().HasForeignKey("IdMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_ARCHIVOS_STOCK_STOCK_MOVIMIENTOS_ID_MOVIMIENTO");
				b.Navigation("ArchivosMovimientosStockNavigation");
				b.Navigation("StockMovimiento");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComponentesDetalle", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosComponentesDetalles", "IdEstadoNavigation").WithMany("ComponentesDetalle").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdEstadoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Compras", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosCompras", "Estado").WithMany("compras").HasForeignKey("EstadoIdEstadoCompra")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Entidades", "IdProveedor").WithMany("compras").HasForeignKey("IdProveedor")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Usuarios", "Usuario").WithMany("Compras").HasForeignKey("IdUsuario")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired();
				b.Navigation("Estado");
				b.Navigation("IdProveedor");
				b.Navigation("Usuario");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComprasDetalles", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Compras", "CompraNavigation").WithMany("DetallesCompra").HasForeignKey("IdCompra")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.ComponentesDetalle", "DetallesInsumo").WithMany("ComprasNavigation").HasForeignKey("IdInsumo")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("CompraNavigation");
				b.Navigation("DetallesInsumo");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.CuotasVentas", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosCuotasVentas", "EstadoCuota").WithMany("IdEstadoCuotaNavigation").HasForeignKey("IdEstadoCuota")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Ventas", "Venta").WithMany("Cuotas").HasForeignKey("IdVenta")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("EstadoCuota");
				b.Navigation("Venta");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Entidades", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EntidadesCategorias", "CategoriaEntidad").WithMany("Entidades").HasForeignKey("IdCategoria")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.EntidadesTipos", "TipoEntidad").WithMany("Entidades").HasForeignKey("IdTipo")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Usuarios", "UsuarioRegistro").WithMany("IdUsuarioRegistroNavigation").HasForeignKey("IdUsuarioRegistro")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("CategoriaEntidad");
				b.Navigation("TipoEntidad");
				b.Navigation("UsuarioRegistro");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesTiposCategorias", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EntidadesCategorias", "CategoriaEntidad").WithMany("TiposCategoriasNavigation").HasForeignKey("IdCategoriaEntidad")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.EntidadesTipos", "TipoEntidad").WithMany("TiposCategoriasNavigation").HasForeignKey("idTipoEntidad")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("CategoriaEntidad");
				b.Navigation("TipoEntidad");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PagosCompras", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Compras", "CompraNavigation").WithMany("Pagos").HasForeignKey("IdCompra")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.MediosPago", "MedioPago").WithMany("PagosComprasNavigation").HasForeignKey("IdMedioPago")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("CompraNavigation");
				b.Navigation("MedioPago");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PagosVentas", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.MediosPago", "MedioPago").WithMany("PagosVentasNavigation").HasForeignKey("IdMedioPago")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Ventas", "Venta").WithMany("Pagos").HasForeignKey("IdVenta")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("MedioPago");
				b.Navigation("Venta");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Producto", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.ProductosDescripcion", "IdDescripcionNavigation").WithMany("StockProductos").HasForeignKey("IdDescripcion")
					.IsRequired()
					.HasConstraintName("FK_PRODUCTOS_PRODUCTOS_DESCRIPCION");
				b.HasOne("Aponus_Web_API.Modelos.EstadosProductos", "IdEstadoNavigation").WithMany("StockProductos").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.ProductosTipo", "IdTipoNavigation").WithMany("StockProductos").HasForeignKey("IdTipo")
					.IsRequired()
					.HasConstraintName("FK_PRODUCTOS_PRODUCTOS_TIPOS");
				b.Navigation("IdDescripcionNavigation");
				b.Navigation("IdEstadoNavigation");
				b.Navigation("IdTipoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosDescripcion", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosProductosDescripciones", "IdEstadoNavigation").WithMany("ProductosDescripcions").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdEstadoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosTipo", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosTiposProductos", "IdEstadoNavigation").WithMany("ProductosTipos").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdEstadoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Productos_Componentes", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosProductosComponentes", "IdEstadoNavigation").WithMany("ProductosComponentes").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdEstadoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Productos_Tipos_Descripcion", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.ProductosDescripcion", "IdDescripcionNavigation").WithMany("Producto_Tipo_Descripcione").HasForeignKey("IdDescripcion")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired()
					.HasConstraintName("FK_PRODUCTOS_TIPOS_DESCRIPCION_ID_DESCRIPCION");
				b.HasOne("Aponus_Web_API.Modelos.ProductosTipo", "IdTipoNavigation").WithMany("Producto_Tipo_Descripcione").HasForeignKey("IdTipo")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired()
					.HasConstraintName("FK_PRODUCTOS_TIPOS_DESCRIPCION_ID_TIPO");
				b.Navigation("IdDescripcionNavigation");
				b.Navigation("IdTipoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Stock_Movimientos", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosMovimientosStock", "estadoMovimiento").WithMany("movimientosStock").HasForeignKey("IdEstadoMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Entidades", "Proveeedor").WithMany("Movimientos").HasForeignKey("IdProveedor")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_STOCK_MOVIMIENTOS_ENTIDADES_ID_PROVEEDOR_DESTINO");
				b.HasOne("Aponus_Web_API.Modelos.Entidades", "ProveedorOrigen").WithMany("MovimientosOrigen").HasForeignKey("IdProveedorOrigen")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_STOCK_MOVIMIENTOS_ENTIDADES_ID_PROVEEDOR_ORIGEN");
				b.Navigation("Proveeedor");
				b.Navigation("ProveedorOrigen");
				b.Navigation("estadoMovimiento");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.SuministrosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosSuministrosMovimientosStock", "EstadosSuministrosMovimientosStockNavigation").WithMany("SuministrosMovimientoStock").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_SUMINISTROS_MOVIMIENTOS_STOCK_ESTADOS_SUMINISTROS_MOVIMIENTO");
				b.HasOne("Aponus_Web_API.Modelos.Stock_Movimientos", null).WithMany("Suministros").HasForeignKey("IdMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("EstadosSuministrosMovimientosStockNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Usuarios", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.PerfilesUsuarios", "Perfil").WithMany("UsuariosNavigation").HasForeignKey("IdPerfil")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_USUARIOS_PERFILES_USUARIOS_ID_PERFIL");
				b.Navigation("Perfil");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Ventas", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Entidades", "Cliente").WithMany("ventas").HasForeignKey("IdEntidad")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.EstadosVentas", "Estado").WithMany("ventas").HasForeignKey("IdEstadoVenta")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Usuarios", "Usuario").WithMany("Ventas").HasForeignKey("IdUsuario")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired();
				b.Navigation("Cliente");
				b.Navigation("Estado");
				b.Navigation("Usuario");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.VentasDetalles", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Producto", "IdProductoNavigation").WithMany("Ventas").HasForeignKey("IdProducto")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_VENTAS_DETALLES_PRODUCTOS_ID_PRODUCTO");
				b.HasOne("Aponus_Web_API.Modelos.Ventas", "Venta").WithMany("DetallesVenta").HasForeignKey("IdVenta")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdProductoNavigation");
				b.Navigation("Venta");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComponentesDetalle", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ComprasNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Compras", delegate(EntityTypeBuilder b)
			{
				b.Navigation("DetallesCompra");
				b.Navigation("Pagos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Entidades", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Movimientos");
				b.Navigation("MovimientosOrigen");
				b.Navigation("compras");
				b.Navigation("ventas");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesCategorias", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Entidades");
				b.Navigation("TiposCategoriasNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesTipos", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Entidades");
				b.Navigation("TiposCategoriasNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosArchivosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ArchivosMovimientoStock");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosComponentesDetalles", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ComponentesDetalle");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCompras", delegate(EntityTypeBuilder b)
			{
				b.Navigation("compras");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCuotasVentas", delegate(EntityTypeBuilder b)
			{
				b.Navigation("IdEstadoCuotaNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Navigation("movimientosStock");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductos", delegate(EntityTypeBuilder b)
			{
				b.Navigation("StockProductos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductosComponentes", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ProductosComponentes");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductosDescripciones", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ProductosDescripcions");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosSuministrosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Navigation("SuministrosMovimientoStock");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosTiposProductos", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ProductosTipos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosVentas", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ventas");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.MediosPago", delegate(EntityTypeBuilder b)
			{
				b.Navigation("PagosComprasNavigation");
				b.Navigation("PagosVentasNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PerfilesUsuarios", delegate(EntityTypeBuilder b)
			{
				b.Navigation("UsuariosNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Producto", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Ventas");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosDescripcion", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Producto_Tipo_Descripcione");
				b.Navigation("StockProductos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosTipo", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Producto_Tipo_Descripcione");
				b.Navigation("StockProductos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Stock_Movimientos", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Suministros");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Usuarios", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Compras");
				b.Navigation("IdUsuarioRegistroNavigation");
				b.Navigation("Ventas");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Ventas", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Cuotas");
				b.Navigation("DetallesVenta");
				b.Navigation("Pagos");
			});
		}
	}
	[DbContext(typeof(AponusContext))]
	[Migration("20241003104449_ComponentesDescripcion")]
	public class ComponentesDescripcion : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<string>("ID_ALMACENAMIENTO", "COMPONENTES_DESCRIPCION", "varchar(50)", null, null, rowVersion: false, null, nullable: true);
			migrationBuilder.AddColumn<string>("ID_FRACCIONAMIENTO", "COMPONENTES_DESCRIPCION", "varchar(50)", null, null, rowVersion: false, null, nullable: true);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn("ID_ALMACENAMIENTO", "COMPONENTES_DESCRIPCION");
			migrationBuilder.DropColumn("ID_FRACCIONAMIENTO", "COMPONENTES_DESCRIPCION");
		}

		protected override void BuildTargetModel(ModelBuilder modelBuilder)
		{
			modelBuilder.UseCollation("Modern_Spanish_CI_AI").HasAnnotation("ProductVersion", "7.0.11").HasAnnotation("Proxies:ChangeTracking", false)
				.HasAnnotation("Proxies:CheckEquality", false)
				.HasAnnotation("Proxies:LazyLoading", true)
				.HasAnnotation("Relational:MaxIdentifierLength", 63);
			modelBuilder.UseIdentityByDefaultColumns();
			modelBuilder.Entity("Aponus_Web_API.Modelos.ArchivosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdMovimiento").HasColumnType("int").HasColumnName("ID_MOVIMIENTO");
				b.Property<string>("HashArchivo").HasColumnType("varchar(255)").HasColumnName("HASH_ARCHIVO");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("MimeType").HasColumnType("text").HasColumnName("MIME_TYPE");
				b.Property<string>("PathArchivo").IsRequired().HasColumnType("text")
					.HasColumnName("PATH");
				b.HasKey("IdMovimiento", "HashArchivo");
				b.HasIndex("IdEstado");
				b.ToTable("ARCHIVOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComponentesDescripcion", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdDescripcion").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_DESCRIPCION");
				b.Property<int>("IdDescripcion").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("DESCRIPCION");
				b.Property<string>("IdAlmacenamiento").HasColumnType("varchar(50)").HasColumnName("ID_ALMACENAMIENTO");
				b.Property<string>("IdFraccionamiento").HasColumnType("varchar(50)").HasColumnName("ID_FRACCIONAMIENTO");
				b.HasKey("IdDescripcion");
				b.ToTable("COMPONENTES_DESCRIPCION", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComponentesDetalle", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdInsumo").HasColumnType("varchar(50)").HasColumnName("ID_INSUMO");
				b.Property<decimal?>("Altura").HasColumnType("decimal(18,2)").HasColumnName("ALTURA");
				b.Property<decimal?>("Diametro").HasColumnType("decimal(18,2)").HasColumnName("DIAMETRO");
				b.Property<int?>("DiametroNominal").HasColumnType("int").HasColumnName("DIAMETRO_NOMINAL");
				b.Property<decimal?>("Espesor").HasColumnType("decimal(18,2)").HasColumnName("ESPESOR");
				b.Property<string>("IdAlmacenamiento").HasColumnType("varchar(50)").HasColumnName("ID_ALMACENAMIENTO");
				b.Property<int>("IdDescripcion").HasColumnType("integer").HasColumnName("ID_DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("IdFraccionamiento").HasColumnType("varchar(50)").HasColumnName("ID_FRACCIONAMIENTO");
				b.Property<decimal?>("Longitud").HasColumnType("decimal(18,2)").HasColumnName("LONGITUD");
				b.Property<int?>("Perfil").HasColumnType("integer").HasColumnName("PERFIL");
				b.Property<decimal?>("Peso").HasColumnType("decimal(18,3)").HasColumnName("PESO");
				b.Property<string>("Tolerancia").HasColumnType("varchar(50)").HasColumnName("TOLERANCIA");
				b.HasKey("IdInsumo").HasName("PK_ID_INSUMO");
				b.HasIndex("IdEstado");
				b.ToTable("COMPONENTES_DETALLE", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Compras", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCompra").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_COMPRA");
				b.Property<int>("IdCompra").UseIdentityByDefaultColumn();
				b.Property<int>("EstadoIdEstadoCompra").HasColumnType("int");
				b.Property<DateTime>("FechaHora").HasColumnType("timestamp").HasColumnName("FECHA_HORA");
				b.Property<int>("IdEstadoCompra").HasColumnType("int").HasColumnName("ID_ESTADO_COMPRA");
				b.Property<int>("IdProveedor").HasColumnType("int").HasColumnName("ID_PROVEEDOR");
				b.Property<string>("IdUsuario").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("ID_USUARIO");
				b.Property<decimal?>("SaldoPendiente").HasColumnType("decimal(18,2)").HasColumnName("SALDO_CANCELADO");
				b.Property<decimal>("MontoTotal").HasColumnType("decimal(18,2)").HasColumnName("SALDO_TOTAL");
				b.HasKey("IdCompra");
				b.HasIndex("EstadoIdEstadoCompra");
				b.HasIndex("IdProveedor");
				b.HasIndex("IdUsuario");
				b.ToTable("COMPRAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComprasDetalles", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCompra").HasColumnType("int").HasColumnName("ID_COMPRA");
				b.Property<string>("IdInsumo").HasColumnType("varchar(50)").HasColumnName("ID_INSUMO");
				b.Property<decimal>("Cantidad").HasColumnType("decimal(18,2)").HasColumnName("CANTIDAD");
				b.HasKey("IdCompra", "IdInsumo");
				b.HasIndex("IdInsumo");
				b.ToTable("COMPRAS_DETALLE", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.CuotasVentas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCuota").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_CUOTA");
				b.Property<int>("IdCuota").UseIdentityByDefaultColumn();
				b.Property<DateTime?>("Fecha").HasColumnType("timestamp").HasColumnName("FECHA_PAGO");
				b.Property<DateTime>("FechaVencimiento").HasColumnType("timestamp").HasColumnName("FECHA_VENCIMIENTO");
				b.Property<int>("IdEstadoCuota").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_CUOTA")
					.HasDefaultValueSql("1");
				b.Property<int>("IdVenta").HasColumnType("int").HasColumnName("ID_VENTA");
				b.Property<decimal>("Monto").ValueGeneratedOnAdd().HasColumnType("decimal(18,2)")
					.HasColumnName("MONTO")
					.HasDefaultValueSql("0.00");
				b.Property<int>("NumeroCuota").HasColumnType("int").HasColumnName("NUMERO_CUOTA");
				b.HasKey("IdCuota");
				b.HasIndex("IdEstadoCuota");
				b.HasIndex("IdVenta");
				b.ToTable("CUOTAS_VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Entidades", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEntidad").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ENTIDAD");
				b.Property<int>("IdEntidad").UseIdentityByDefaultColumn();
				b.Property<string>("Altura").HasColumnType("text").HasColumnName("ALTURA");
				b.Property<string>("Apellido").HasColumnType("text").HasColumnName("APELLIDO");
				b.Property<string>("Barrio").HasColumnType("text").HasColumnName("BARRIO");
				b.Property<string>("Calle").HasColumnType("text").HasColumnName("CALLE");
				b.Property<string>("Ciudad").HasColumnType("text").HasColumnName("CIUDAD");
				b.Property<string>("CodigoPostal").HasColumnType("text").HasColumnName("CODIGO_POSTAL");
				b.Property<string>("Email").HasColumnType("text").HasColumnName("EMAIL");
				b.Property<DateTime>("FechaRegistro").HasColumnType("timestamp").HasColumnName("FECHA_REGISTRO");
				b.Property<int>("IdCategoria").HasColumnType("int").HasColumnName("ID_CATEGORIA");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("(1)");
				b.Property<string>("IdFiscal").IsRequired().HasColumnType("text")
					.HasColumnName("ID_FISCAL");
				b.Property<int>("IdTipo").HasColumnType("int").HasColumnName("ID_TIPO");
				b.Property<string>("IdUsuarioRegistro").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("ID_USUARIO_REGISTRO");
				b.Property<string>("Localidad").HasColumnType("text").HasColumnName("LOCALIDAD");
				b.Property<string>("Nombre").HasColumnType("text").HasColumnName("NOMBRE");
				b.Property<string>("NombreClave").HasColumnType("text").HasColumnName("NOMBRE_CLAVE");
				b.Property<string>("Pais").HasColumnType("text").HasColumnName("PAIS");
				b.Property<string>("Provincia").HasColumnType("text").HasColumnName("PROVINCIA");
				b.Property<string>("Telefono1").HasColumnType("text").HasColumnName("TELEFONO_1");
				b.Property<string>("Telefono2").HasColumnType("text").HasColumnName("TELEFONO_2");
				b.Property<string>("Telefono3").HasColumnType("text").HasColumnName("TELEFONO_3");
				b.HasKey("IdEntidad");
				b.HasIndex("IdCategoria");
				b.HasIndex("IdTipo");
				b.HasIndex("IdUsuarioRegistro");
				b.ToTable("ENTIDADES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesCategorias", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCategoria").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_CATEGORIA");
				b.Property<int>("IdCategoria").UseIdentityByDefaultColumn();
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("NombreCategoria").IsRequired().HasColumnType("text")
					.HasColumnName("NOMBRE_CATEGORIA");
				b.HasKey("IdCategoria");
				b.ToTable("ENTIDADES_CATEGORIAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesTipos", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdTipo").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_TIPO");
				b.Property<int>("IdTipo").UseIdentityByDefaultColumn();
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("NombreTipo").IsRequired().HasColumnType("text")
					.HasColumnName("NOMBRE");
				b.HasKey("IdTipo");
				b.ToTable("ENTIDADES_TIPOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesTiposCategorias", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("idTipoEntidad").HasColumnType("int").HasColumnName("ID_TIPO");
				b.Property<int>("IdCategoriaEntidad").HasColumnType("int").HasColumnName("ID_CATEGORIA");
				b.HasKey("idTipoEntidad", "IdCategoriaEntidad");
				b.HasIndex("IdCategoriaEntidad");
				b.ToTable("ENTIDADES_TIPOS_CATEGORIAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosArchivosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_ARCHIVOS_MOVIMIENTOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosComponentesDetalles", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_COMPONENTES_DETALLES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCompras", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoCompra").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_COMPRA")
					.HasAnnotation("SqlServer:Identity", "1, 1");
				b.Property<int>("IdEstadoCompra").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").HasColumnType("int").HasColumnName("ID_ESTADO");
				b.HasKey("IdEstadoCompra");
				b.ToTable("ESTADOS_COMPRAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCuotasVentas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoCuota").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_CUOTA");
				b.Property<int>("IdEstadoCuota").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.HasKey("IdEstadoCuota");
				b.ToTable("ESTADOS_CUOTAS_VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int?>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_MOVIMIENTO");
				b.Property<int?>("IdEstadoMovimiento").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.HasKey("IdEstadoMovimiento");
				b.ToTable("ESTADOS_MOVIMIENTOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductos", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_PRODUCTOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductosComponentes", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_PRODUCTOS_COMPONENTES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductosDescripciones", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_PRODUCTOS_DESCRIPCIONES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosSuministrosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_SUMINISTROS_MOVIMIENTOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosTiposProductos", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_PRODUCTOS_TIPOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosVentas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoVenta").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_VENTA");
				b.Property<int>("IdEstadoVenta").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("int")
					.HasDefaultValue(1)
					.HasColumnName("ID_ESTADO");
				b.HasKey("IdEstadoVenta");
				b.ToTable("ESTADOS_VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.MediosPago", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdMedioPago").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_MEDIO_PAGO");
				b.Property<int>("IdMedioPago").UseIdentityByDefaultColumn();
				b.Property<string>("CodigoMPago").HasColumnType("text").HasColumnName("CODIGO_MPAGO");
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("int")
					.HasDefaultValue(1)
					.HasColumnName("ID_ESTADO");
				b.HasKey("IdMedioPago");
				b.ToTable("MEDIOS_PAGO", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PagosCompras", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdPago").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_PAGO")
					.HasColumnOrder(2);
				b.Property<int>("IdPago").UseIdentityByDefaultColumn();
				b.Property<int?>("CantidadCuotas").HasColumnType("int").HasColumnName("CANTIDAD_CUOTAS");
				b.Property<int?>("CantidadCuotasCanceladas").HasColumnType("int").HasColumnName("CANTIDAD_CUOTAS_CANCELADAS");
				b.Property<int>("IdCompra").HasColumnType("int").HasColumnName("ID_COMPRA");
				b.Property<int>("IdMedioPago").HasColumnType("int").HasColumnName("ID_MEDIO_PAGO");
				b.Property<decimal>("Monto").HasColumnType("decimal(18,2)").HasColumnName("SUBTOTAL");
				b.Property<decimal?>("SaldoPendiente").HasColumnType("decimal(18,2)").HasColumnName("SUBTOTAL_CANCELADO");
				b.Property<decimal>("MontoCompra").HasColumnType("decimal(18,2)").HasColumnName("TOTAL");
				b.HasKey("IdPago");
				b.HasIndex("IdCompra");
				b.HasIndex("IdMedioPago");
				b.ToTable("PAGOS_COMPRAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PagosVentas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdPago").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_PAGO")
					.HasColumnOrder(2);
				b.Property<int>("IdPago").UseIdentityByDefaultColumn();
				b.Property<DateTime?>("Fecha").HasColumnType("timestamp").HasColumnName("FECHA");
				b.Property<int>("IdMedioPago").HasColumnType("int").HasColumnName("ID_MEDIO_PAGO");
				b.Property<int>("IdVenta").HasColumnType("int").HasColumnName("ID_VENTA");
				b.Property<decimal>("Monto").HasColumnType("decimal(18,2)").HasColumnName("MONTO");
				b.HasKey("IdPago");
				b.HasIndex("IdMedioPago");
				b.HasIndex("IdVenta");
				b.ToTable("PAGOS_VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PerfilesUsuarios", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdPerfil").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_PERFIL");
				b.Property<int>("IdPerfil").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("varcahr(100)")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").HasColumnType("integer").HasColumnName("ID_ESTADO");
				b.HasKey("IdPerfil");
				b.ToTable("USUARIOS_PERFILES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Producto", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdProducto").HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("ID_PRODUCTO");
				b.Property<int?>("Cantidad").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("CANTIDAD")
					.HasDefaultValueSql("((0))");
				b.Property<int?>("DiametroNominal").HasColumnType("integer").HasColumnName("DIAMETRO_NOMINAL");
				b.Property<int>("IdDescripcion").HasColumnType("integer").HasColumnName("ID_DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("IdTipo").IsRequired().HasMaxLength(50)
					.IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("ID_TIPO");
				b.Property<decimal?>("PorcentajeGanancia").HasColumnType("decimal(18,2)").HasColumnName("PORCENTAJE_GANANCIA");
				b.Property<decimal?>("PrecioFinal").HasColumnType("decimal(18,2)").HasColumnName("PRECIO_FINAL");
				b.Property<decimal?>("PrecioLista").ValueGeneratedOnAdd().HasColumnType("money")
					.HasColumnName("PRECIO_LISTA")
					.HasDefaultValueSql("((0))");
				b.Property<string>("Tolerancia").HasColumnType("text").HasColumnName("TOLERANCIA");
				b.HasKey("IdProducto");
				b.HasIndex("IdDescripcion");
				b.HasIndex("IdEstado");
				b.HasIndex("IdTipo");
				b.ToTable("PRODUCTOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosDescripcion", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdDescripcion").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_DESCRIPCION");
				b.Property<int>("IdDescripcion").UseIdentityByDefaultColumn();
				b.Property<string>("DescripcionProducto").HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.HasKey("IdDescripcion");
				b.HasIndex("IdEstado");
				b.ToTable("PRODUCTOS_DESCRIPCION", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosTipo", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdTipo").HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("ID_TIPO");
				b.Property<string>("DescripcionTipo").HasMaxLength(100).IsUnicode(unicode: false)
					.HasColumnType("character varying(100)")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.HasKey("IdTipo").HasName("PK_PRODUCTOS_TIPOS");
				b.HasIndex("IdEstado");
				b.ToTable("PRODUCTOS_TIPOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Productos_Componentes", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdProducto").HasColumnType("varchar(50)").HasColumnName("ID_PRODUCTO");
				b.Property<string>("IdComponente").HasColumnType("varchar(50)").HasColumnName("ID_COMPONENTE");
				b.Property<decimal?>("Cantidad").HasColumnType("decimal(18,2)").HasColumnName("CANTIDAD");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<decimal?>("Longitud").HasColumnType("decimal(18,2)").HasColumnName("LONGITUD");
				b.Property<decimal?>("Peso").HasColumnType("decimal(18,2)").HasColumnName("PESO");
				b.HasKey("IdProducto", "IdComponente").HasName("PK_PRODUCTOS_COMPONENTES");
				b.HasIndex("IdEstado");
				b.ToTable("PRODUCTOS_COMPONENTES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Productos_Tipos_Descripcion", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdTipo").HasColumnType("varchar(50)").HasColumnName("ID_TIPO");
				b.Property<int?>("IdDescripcion").HasColumnType("integer").HasColumnName("ID_DESCRIPCION");
				b.HasKey("IdTipo", "IdDescripcion");
				b.HasIndex("IdDescripcion");
				b.ToTable("PRODUCTOS_TIPOS_DESCRIPCION", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.StockInsumos", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdInsumo").HasColumnType("varchar(50)").HasColumnName("ID_INSUMO");
				b.Property<decimal?>("Granallado").HasColumnType("decimal").HasColumnName("GRANALLADO");
				b.Property<decimal?>("Moldeado").HasColumnType("decimal").HasColumnName("MOLDEADO");
				b.Property<decimal?>("Pendiente").HasColumnType("decimal(18,2)").HasColumnName("PENDIENTE");
				b.Property<decimal?>("Pintura").HasColumnType("decimal").HasColumnName("PINTURA");
				b.Property<decimal?>("Proceso").HasColumnType("decimal").HasColumnName("PROCESO");
				b.Property<decimal?>("Recibido").HasColumnType("decimal").HasColumnName("RECIBIDO");
				b.HasKey("IdInsumo").HasName("PK_STOCK_INSUMOS");
				b.ToTable("STOCK_INSUMOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Stock_Movimientos", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdMovimiento").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_MOVIMIENTO");
				b.Property<int>("IdMovimiento").UseIdentityByDefaultColumn();
				b.Property<string>("CreadoUsuario").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("USUARIO_CREADO");
				b.Property<string>("Destino").HasColumnType("varchar(50)").HasColumnName("DESTINO");
				b.Property<DateTime>("FechaHoraCreado").HasColumnType("timestamp").HasColumnName("FECHA_HORA_CREADO");
				b.Property<DateTime?>("FechaHoraUltimaModificacion").HasColumnType("timestamp").HasColumnName("FECHA_HORA_ULTIMA_MODIFICACION");
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_MOVIMIENTO")
					.HasDefaultValueSql("1");
				b.Property<int>("IdProveedor").HasColumnType("int").HasColumnName("ID_PROVEEDOR_DESTINO");
				b.Property<int>("IdProveedorOrigen").HasColumnType("int").HasColumnName("ID_PROVEEDOR_ORIGEN");
				b.Property<string>("ModificadoUsuario").HasColumnType("varchar(50)").HasColumnName("USUARIO_MODIFICA");
				b.Property<string>("Origen").HasColumnType("varchar(50)").HasColumnName("ORIGEN");
				b.Property<string>("Tipo").HasColumnType("varchar(15)").HasColumnName("TIPO");
				b.HasKey("IdMovimiento");
				b.HasIndex("IdEstadoMovimiento");
				b.HasIndex("IdProveedor");
				b.HasIndex("IdProveedorOrigen");
				b.ToTable("STOCK_MOVIMIENTOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.SuministrosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdMovimiento").HasColumnType("int").HasColumnName("ID_MOVIMIENTO");
				b.Property<string>("IdSuministro").HasColumnType("varchar(50)").HasColumnName("ID_SUMINISTRO");
				b.Property<decimal>("Cantidad").HasColumnType("decimal(18,2)").HasColumnName("CANTIDAD");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.HasKey("IdMovimiento", "IdSuministro");
				b.HasIndex("IdEstado");
				b.ToTable("SUMINISTROS_MOVIMIENTOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Usuarios", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("Usuario").HasColumnType("varchar(50)").HasColumnName("USUARIO");
				b.Property<string>("Contraseña").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("CONTRASEÑA");
				b.Property<int>("IdPerfil").HasColumnType("int").HasColumnName("ID_PERFIL");
				b.Property<string>("Correo").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("CORREO");
				b.HasKey("Usuario");
				b.HasIndex("IdPerfil");
				b.ToTable("USUARIOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Ventas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdVenta").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_VENTA");
				b.Property<int>("IdVenta").UseIdentityByDefaultColumn();
				b.Property<DateTime>("FechaHora").HasColumnType("timestamp").HasColumnName("FECHA_HORA");
				b.Property<int>("IdEntidad").HasColumnType("int").HasColumnName("ID_CLIENTE");
				b.Property<int>("IdEstadoVenta").HasColumnType("int").HasColumnName("ID_ESTADO_VENTA");
				b.Property<string>("IdUsuario").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("ID_USUARIO");
				b.Property<decimal>("SaldoPendiente").HasColumnType("numeric").HasColumnName("SALDO_PENDIENTE");
				b.Property<decimal>("MontoCompra").HasColumnType("decimal(18,2)").HasColumnName("TOTAL");
				b.HasKey("IdVenta");
				b.HasIndex("IdEntidad");
				b.HasIndex("IdEstadoVenta");
				b.HasIndex("IdUsuario");
				b.ToTable("VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.VentasDetalles", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdVenta").HasColumnType("int").HasColumnName("ID_VENTA");
				b.Property<string>("IdProducto").HasColumnType("varchar(50)").HasColumnName("ID_PRODUCTO");
				b.Property<decimal>("Cantidad").HasColumnType("decimal(18,2)").HasColumnName("CANTIDAD");
				b.Property<int?>("Entregados").HasColumnType("integer").HasColumnName("ENTREGADOS");
				b.Property<decimal>("Precio").HasColumnType("decimal(18,2)").HasColumnName("PRECIO");
				b.HasKey("IdVenta", "IdProducto");
				b.HasIndex("IdProducto");
				b.ToTable("VENTAS_DETALLES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ArchivosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosArchivosMovimientosStock", "ArchivosMovimientosStockNavigation").WithMany("ArchivosMovimientoStock").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Stock_Movimientos", "StockMovimiento").WithMany().HasForeignKey("IdMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_ARCHIVOS_STOCK_STOCK_MOVIMIENTOS_ID_MOVIMIENTO");
				b.Navigation("ArchivosMovimientosStockNavigation");
				b.Navigation("StockMovimiento");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComponentesDetalle", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosComponentesDetalles", "IdEstadoNavigation").WithMany("ComponentesDetalle").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdEstadoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Compras", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosCompras", "Estado").WithMany("compras").HasForeignKey("EstadoIdEstadoCompra")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Entidades", "IdProveedor").WithMany("compras").HasForeignKey("IdProveedor")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Usuarios", "Usuario").WithMany("Compras").HasForeignKey("IdUsuario")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired();
				b.Navigation("Estado");
				b.Navigation("IdProveedor");
				b.Navigation("Usuario");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComprasDetalles", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Compras", "CompraNavigation").WithMany("DetallesCompra").HasForeignKey("IdCompra")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.ComponentesDetalle", "DetallesInsumo").WithMany("ComprasNavigation").HasForeignKey("IdInsumo")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("CompraNavigation");
				b.Navigation("DetallesInsumo");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.CuotasVentas", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosCuotasVentas", "EstadoCuota").WithMany("IdEstadoCuotaNavigation").HasForeignKey("IdEstadoCuota")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Ventas", "Venta").WithMany("Cuotas").HasForeignKey("IdVenta")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("EstadoCuota");
				b.Navigation("Venta");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Entidades", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EntidadesCategorias", "CategoriaEntidad").WithMany("Entidades").HasForeignKey("IdCategoria")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.EntidadesTipos", "TipoEntidad").WithMany("Entidades").HasForeignKey("IdTipo")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Usuarios", "UsuarioRegistro").WithMany("IdUsuarioRegistroNavigation").HasForeignKey("IdUsuarioRegistro")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("CategoriaEntidad");
				b.Navigation("TipoEntidad");
				b.Navigation("UsuarioRegistro");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesTiposCategorias", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EntidadesCategorias", "CategoriaEntidad").WithMany("TiposCategoriasNavigation").HasForeignKey("IdCategoriaEntidad")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.EntidadesTipos", "TipoEntidad").WithMany("TiposCategoriasNavigation").HasForeignKey("idTipoEntidad")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("CategoriaEntidad");
				b.Navigation("TipoEntidad");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PagosCompras", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Compras", "CompraNavigation").WithMany("Pagos").HasForeignKey("IdCompra")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.MediosPago", "MedioPago").WithMany("PagosComprasNavigation").HasForeignKey("IdMedioPago")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("CompraNavigation");
				b.Navigation("MedioPago");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PagosVentas", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.MediosPago", "MedioPago").WithMany("PagosVentasNavigation").HasForeignKey("IdMedioPago")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Ventas", "Venta").WithMany("Pagos").HasForeignKey("IdVenta")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("MedioPago");
				b.Navigation("Venta");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Producto", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.ProductosDescripcion", "IdDescripcionNavigation").WithMany("StockProductos").HasForeignKey("IdDescripcion")
					.IsRequired()
					.HasConstraintName("FK_PRODUCTOS_PRODUCTOS_DESCRIPCION");
				b.HasOne("Aponus_Web_API.Modelos.EstadosProductos", "IdEstadoNavigation").WithMany("StockProductos").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.ProductosTipo", "IdTipoNavigation").WithMany("StockProductos").HasForeignKey("IdTipo")
					.IsRequired()
					.HasConstraintName("FK_PRODUCTOS_PRODUCTOS_TIPOS");
				b.Navigation("IdDescripcionNavigation");
				b.Navigation("IdEstadoNavigation");
				b.Navigation("IdTipoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosDescripcion", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosProductosDescripciones", "IdEstadoNavigation").WithMany("ProductosDescripcions").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdEstadoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosTipo", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosTiposProductos", "IdEstadoNavigation").WithMany("ProductosTipos").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdEstadoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Productos_Componentes", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosProductosComponentes", "IdEstadoNavigation").WithMany("ProductosComponentes").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdEstadoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Productos_Tipos_Descripcion", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.ProductosDescripcion", "IdDescripcionNavigation").WithMany("Producto_Tipo_Descripcione").HasForeignKey("IdDescripcion")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired()
					.HasConstraintName("FK_PRODUCTOS_TIPOS_DESCRIPCION_ID_DESCRIPCION");
				b.HasOne("Aponus_Web_API.Modelos.ProductosTipo", "IdTipoNavigation").WithMany("Producto_Tipo_Descripcione").HasForeignKey("IdTipo")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired()
					.HasConstraintName("FK_PRODUCTOS_TIPOS_DESCRIPCION_ID_TIPO");
				b.Navigation("IdDescripcionNavigation");
				b.Navigation("IdTipoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Stock_Movimientos", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosMovimientosStock", "estadoMovimiento").WithMany("movimientosStock").HasForeignKey("IdEstadoMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Entidades", "Proveeedor").WithMany("Movimientos").HasForeignKey("IdProveedor")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_STOCK_MOVIMIENTOS_ENTIDADES_ID_PROVEEDOR_DESTINO");
				b.HasOne("Aponus_Web_API.Modelos.Entidades", "ProveedorOrigen").WithMany("MovimientosOrigen").HasForeignKey("IdProveedorOrigen")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_STOCK_MOVIMIENTOS_ENTIDADES_ID_PROVEEDOR_ORIGEN");
				b.Navigation("Proveeedor");
				b.Navigation("ProveedorOrigen");
				b.Navigation("estadoMovimiento");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.SuministrosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosSuministrosMovimientosStock", "EstadosSuministrosMovimientosStockNavigation").WithMany("SuministrosMovimientoStock").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_SUMINISTROS_MOVIMIENTOS_STOCK_ESTADOS_SUMINISTROS_MOVIMIENTO");
				b.HasOne("Aponus_Web_API.Modelos.Stock_Movimientos", null).WithMany("Suministros").HasForeignKey("IdMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("EstadosSuministrosMovimientosStockNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Usuarios", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.PerfilesUsuarios", "Perfil").WithMany("UsuariosNavigation").HasForeignKey("IdPerfil")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_USUARIOS_PERFILES_USUARIOS_ID_PERFIL");
				b.Navigation("Perfil");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Ventas", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Entidades", "Cliente").WithMany("ventas").HasForeignKey("IdEntidad")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.EstadosVentas", "Estado").WithMany("ventas").HasForeignKey("IdEstadoVenta")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Usuarios", "Usuario").WithMany("Ventas").HasForeignKey("IdUsuario")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired();
				b.Navigation("Cliente");
				b.Navigation("Estado");
				b.Navigation("Usuario");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.VentasDetalles", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Producto", "IdProductoNavigation").WithMany("Ventas").HasForeignKey("IdProducto")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_VENTAS_DETALLES_PRODUCTOS_ID_PRODUCTO");
				b.HasOne("Aponus_Web_API.Modelos.Ventas", "Venta").WithMany("DetallesVenta").HasForeignKey("IdVenta")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdProductoNavigation");
				b.Navigation("Venta");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComponentesDetalle", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ComprasNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Compras", delegate(EntityTypeBuilder b)
			{
				b.Navigation("DetallesCompra");
				b.Navigation("Pagos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Entidades", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Movimientos");
				b.Navigation("MovimientosOrigen");
				b.Navigation("compras");
				b.Navigation("ventas");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesCategorias", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Entidades");
				b.Navigation("TiposCategoriasNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesTipos", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Entidades");
				b.Navigation("TiposCategoriasNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosArchivosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ArchivosMovimientoStock");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosComponentesDetalles", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ComponentesDetalle");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCompras", delegate(EntityTypeBuilder b)
			{
				b.Navigation("compras");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCuotasVentas", delegate(EntityTypeBuilder b)
			{
				b.Navigation("IdEstadoCuotaNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Navigation("movimientosStock");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductos", delegate(EntityTypeBuilder b)
			{
				b.Navigation("StockProductos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductosComponentes", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ProductosComponentes");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductosDescripciones", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ProductosDescripcions");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosSuministrosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Navigation("SuministrosMovimientoStock");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosTiposProductos", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ProductosTipos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosVentas", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ventas");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.MediosPago", delegate(EntityTypeBuilder b)
			{
				b.Navigation("PagosComprasNavigation");
				b.Navigation("PagosVentasNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PerfilesUsuarios", delegate(EntityTypeBuilder b)
			{
				b.Navigation("UsuariosNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Producto", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Ventas");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosDescripcion", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Producto_Tipo_Descripcione");
				b.Navigation("StockProductos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosTipo", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Producto_Tipo_Descripcione");
				b.Navigation("StockProductos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Stock_Movimientos", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Suministros");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Usuarios", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Compras");
				b.Navigation("IdUsuarioRegistroNavigation");
				b.Navigation("Ventas");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Ventas", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Cuotas");
				b.Navigation("DetallesVenta");
				b.Navigation("Pagos");
			});
		}
	}
	[DbContext(typeof(AponusContext))]
	[Migration("20241004070900_IdAlmacenamiento_Nullable")]
	public class IdAlmacenamientoNullable : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			Type typeFromHandle = typeof(string);
			migrationBuilder.AlterColumn<string>("ID_ALMACENAMIENTO", "COMPONENTES_DESCRIPCION", "varchar(50)", null, null, rowVersion: false, null, nullable: false, "", null, null, typeFromHandle, "varchar(50)", null, null, oldRowVersion: false, oldNullable: true);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			Type typeFromHandle = typeof(string);
			migrationBuilder.AlterColumn<string>("ID_ALMACENAMIENTO", "COMPONENTES_DESCRIPCION", "varchar(50)", null, null, rowVersion: false, null, nullable: true, null, null, null, typeFromHandle, "varchar(50)");
		}

		protected override void BuildTargetModel(ModelBuilder modelBuilder)
		{
			modelBuilder.UseCollation("Modern_Spanish_CI_AI").HasAnnotation("ProductVersion", "7.0.11").HasAnnotation("Proxies:ChangeTracking", false)
				.HasAnnotation("Proxies:CheckEquality", false)
				.HasAnnotation("Proxies:LazyLoading", true)
				.HasAnnotation("Relational:MaxIdentifierLength", 63);
			modelBuilder.UseIdentityByDefaultColumns();
			modelBuilder.Entity("Aponus_Web_API.Modelos.ArchivosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdMovimiento").HasColumnType("int").HasColumnName("ID_MOVIMIENTO");
				b.Property<string>("HashArchivo").HasColumnType("varchar(255)").HasColumnName("HASH_ARCHIVO");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("MimeType").HasColumnType("text").HasColumnName("MIME_TYPE");
				b.Property<string>("PathArchivo").IsRequired().HasColumnType("text")
					.HasColumnName("PATH");
				b.HasKey("IdMovimiento", "HashArchivo");
				b.HasIndex("IdEstado");
				b.ToTable("ARCHIVOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComponentesDescripcion", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdDescripcion").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_DESCRIPCION");
				b.Property<int>("IdDescripcion").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("DESCRIPCION");
				b.Property<string>("IdAlmacenamiento").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("ID_ALMACENAMIENTO");
				b.Property<string>("IdFraccionamiento").HasColumnType("varchar(50)").HasColumnName("ID_FRACCIONAMIENTO");
				b.HasKey("IdDescripcion");
				b.ToTable("COMPONENTES_DESCRIPCION", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComponentesDetalle", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdInsumo").HasColumnType("varchar(50)").HasColumnName("ID_INSUMO");
				b.Property<decimal?>("Altura").HasColumnType("decimal(18,2)").HasColumnName("ALTURA");
				b.Property<decimal?>("Diametro").HasColumnType("decimal(18,2)").HasColumnName("DIAMETRO");
				b.Property<int?>("DiametroNominal").HasColumnType("int").HasColumnName("DIAMETRO_NOMINAL");
				b.Property<decimal?>("Espesor").HasColumnType("decimal(18,2)").HasColumnName("ESPESOR");
				b.Property<string>("IdAlmacenamiento").HasColumnType("varchar(50)").HasColumnName("ID_ALMACENAMIENTO");
				b.Property<int>("IdDescripcion").HasColumnType("integer").HasColumnName("ID_DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("IdFraccionamiento").HasColumnType("varchar(50)").HasColumnName("ID_FRACCIONAMIENTO");
				b.Property<decimal?>("Longitud").HasColumnType("decimal(18,2)").HasColumnName("LONGITUD");
				b.Property<int?>("Perfil").HasColumnType("integer").HasColumnName("PERFIL");
				b.Property<decimal?>("Peso").HasColumnType("decimal(18,3)").HasColumnName("PESO");
				b.Property<string>("Tolerancia").HasColumnType("varchar(50)").HasColumnName("TOLERANCIA");
				b.HasKey("IdInsumo").HasName("PK_ID_INSUMO");
				b.HasIndex("IdEstado");
				b.ToTable("COMPONENTES_DETALLE", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Compras", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCompra").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_COMPRA");
				b.Property<int>("IdCompra").UseIdentityByDefaultColumn();
				b.Property<int>("EstadoIdEstadoCompra").HasColumnType("int");
				b.Property<DateTime>("FechaHora").HasColumnType("timestamp").HasColumnName("FECHA_HORA");
				b.Property<int>("IdEstadoCompra").HasColumnType("int").HasColumnName("ID_ESTADO_COMPRA");
				b.Property<int>("IdProveedor").HasColumnType("int").HasColumnName("ID_PROVEEDOR");
				b.Property<string>("IdUsuario").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("ID_USUARIO");
				b.Property<decimal?>("SaldoPendiente").HasColumnType("decimal(18,2)").HasColumnName("SALDO_CANCELADO");
				b.Property<decimal>("MontoTotal").HasColumnType("decimal(18,2)").HasColumnName("SALDO_TOTAL");
				b.HasKey("IdCompra");
				b.HasIndex("EstadoIdEstadoCompra");
				b.HasIndex("IdProveedor");
				b.HasIndex("IdUsuario");
				b.ToTable("COMPRAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComprasDetalles", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCompra").HasColumnType("int").HasColumnName("ID_COMPRA");
				b.Property<string>("IdInsumo").HasColumnType("varchar(50)").HasColumnName("ID_INSUMO");
				b.Property<decimal>("Cantidad").HasColumnType("decimal(18,2)").HasColumnName("CANTIDAD");
				b.HasKey("IdCompra", "IdInsumo");
				b.HasIndex("IdInsumo");
				b.ToTable("COMPRAS_DETALLE", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.CuotasVentas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCuota").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_CUOTA");
				b.Property<int>("IdCuota").UseIdentityByDefaultColumn();
				b.Property<DateTime?>("Fecha").HasColumnType("timestamp").HasColumnName("FECHA_PAGO");
				b.Property<DateTime>("FechaVencimiento").HasColumnType("timestamp").HasColumnName("FECHA_VENCIMIENTO");
				b.Property<int>("IdEstadoCuota").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_CUOTA")
					.HasDefaultValueSql("1");
				b.Property<int>("IdVenta").HasColumnType("int").HasColumnName("ID_VENTA");
				b.Property<decimal>("Monto").ValueGeneratedOnAdd().HasColumnType("decimal(18,2)")
					.HasColumnName("MONTO")
					.HasDefaultValueSql("0.00");
				b.Property<int>("NumeroCuota").HasColumnType("int").HasColumnName("NUMERO_CUOTA");
				b.HasKey("IdCuota");
				b.HasIndex("IdEstadoCuota");
				b.HasIndex("IdVenta");
				b.ToTable("CUOTAS_VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Entidades", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEntidad").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ENTIDAD");
				b.Property<int>("IdEntidad").UseIdentityByDefaultColumn();
				b.Property<string>("Altura").HasColumnType("text").HasColumnName("ALTURA");
				b.Property<string>("Apellido").HasColumnType("text").HasColumnName("APELLIDO");
				b.Property<string>("Barrio").HasColumnType("text").HasColumnName("BARRIO");
				b.Property<string>("Calle").HasColumnType("text").HasColumnName("CALLE");
				b.Property<string>("Ciudad").HasColumnType("text").HasColumnName("CIUDAD");
				b.Property<string>("CodigoPostal").HasColumnType("text").HasColumnName("CODIGO_POSTAL");
				b.Property<string>("Email").HasColumnType("text").HasColumnName("EMAIL");
				b.Property<DateTime>("FechaRegistro").HasColumnType("timestamp").HasColumnName("FECHA_REGISTRO");
				b.Property<int>("IdCategoria").HasColumnType("int").HasColumnName("ID_CATEGORIA");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("(1)");
				b.Property<string>("IdFiscal").IsRequired().HasColumnType("text")
					.HasColumnName("ID_FISCAL");
				b.Property<int>("IdTipo").HasColumnType("int").HasColumnName("ID_TIPO");
				b.Property<string>("IdUsuarioRegistro").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("ID_USUARIO_REGISTRO");
				b.Property<string>("Localidad").HasColumnType("text").HasColumnName("LOCALIDAD");
				b.Property<string>("Nombre").HasColumnType("text").HasColumnName("NOMBRE");
				b.Property<string>("NombreClave").HasColumnType("text").HasColumnName("NOMBRE_CLAVE");
				b.Property<string>("Pais").HasColumnType("text").HasColumnName("PAIS");
				b.Property<string>("Provincia").HasColumnType("text").HasColumnName("PROVINCIA");
				b.Property<string>("Telefono1").HasColumnType("text").HasColumnName("TELEFONO_1");
				b.Property<string>("Telefono2").HasColumnType("text").HasColumnName("TELEFONO_2");
				b.Property<string>("Telefono3").HasColumnType("text").HasColumnName("TELEFONO_3");
				b.HasKey("IdEntidad");
				b.HasIndex("IdCategoria");
				b.HasIndex("IdTipo");
				b.HasIndex("IdUsuarioRegistro");
				b.ToTable("ENTIDADES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesCategorias", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCategoria").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_CATEGORIA");
				b.Property<int>("IdCategoria").UseIdentityByDefaultColumn();
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("NombreCategoria").IsRequired().HasColumnType("text")
					.HasColumnName("NOMBRE_CATEGORIA");
				b.HasKey("IdCategoria");
				b.ToTable("ENTIDADES_CATEGORIAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesTipos", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdTipo").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_TIPO");
				b.Property<int>("IdTipo").UseIdentityByDefaultColumn();
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("NombreTipo").IsRequired().HasColumnType("text")
					.HasColumnName("NOMBRE");
				b.HasKey("IdTipo");
				b.ToTable("ENTIDADES_TIPOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesTiposCategorias", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("idTipoEntidad").HasColumnType("int").HasColumnName("ID_TIPO");
				b.Property<int>("IdCategoriaEntidad").HasColumnType("int").HasColumnName("ID_CATEGORIA");
				b.HasKey("idTipoEntidad", "IdCategoriaEntidad");
				b.HasIndex("IdCategoriaEntidad");
				b.ToTable("ENTIDADES_TIPOS_CATEGORIAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosArchivosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_ARCHIVOS_MOVIMIENTOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosComponentesDetalles", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_COMPONENTES_DETALLES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCompras", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoCompra").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_COMPRA")
					.HasAnnotation("SqlServer:Identity", "1, 1");
				b.Property<int>("IdEstadoCompra").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").HasColumnType("int").HasColumnName("ID_ESTADO");
				b.HasKey("IdEstadoCompra");
				b.ToTable("ESTADOS_COMPRAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCuotasVentas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoCuota").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_CUOTA");
				b.Property<int>("IdEstadoCuota").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.HasKey("IdEstadoCuota");
				b.ToTable("ESTADOS_CUOTAS_VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int?>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_MOVIMIENTO");
				b.Property<int?>("IdEstadoMovimiento").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.HasKey("IdEstadoMovimiento");
				b.ToTable("ESTADOS_MOVIMIENTOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductos", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_PRODUCTOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductosComponentes", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_PRODUCTOS_COMPONENTES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductosDescripciones", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_PRODUCTOS_DESCRIPCIONES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosSuministrosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_SUMINISTROS_MOVIMIENTOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosTiposProductos", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_PRODUCTOS_TIPOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosVentas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoVenta").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_VENTA");
				b.Property<int>("IdEstadoVenta").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("int")
					.HasDefaultValue(1)
					.HasColumnName("ID_ESTADO");
				b.HasKey("IdEstadoVenta");
				b.ToTable("ESTADOS_VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.MediosPago", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdMedioPago").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_MEDIO_PAGO");
				b.Property<int>("IdMedioPago").UseIdentityByDefaultColumn();
				b.Property<string>("CodigoMPago").HasColumnType("text").HasColumnName("CODIGO_MPAGO");
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("int")
					.HasDefaultValue(1)
					.HasColumnName("ID_ESTADO");
				b.HasKey("IdMedioPago");
				b.ToTable("MEDIOS_PAGO", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PagosCompras", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdPago").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_PAGO")
					.HasColumnOrder(2);
				b.Property<int>("IdPago").UseIdentityByDefaultColumn();
				b.Property<int?>("CantidadCuotas").HasColumnType("int").HasColumnName("CANTIDAD_CUOTAS");
				b.Property<int?>("CantidadCuotasCanceladas").HasColumnType("int").HasColumnName("CANTIDAD_CUOTAS_CANCELADAS");
				b.Property<int>("IdCompra").HasColumnType("int").HasColumnName("ID_COMPRA");
				b.Property<int>("IdMedioPago").HasColumnType("int").HasColumnName("ID_MEDIO_PAGO");
				b.Property<decimal>("Monto").HasColumnType("decimal(18,2)").HasColumnName("SUBTOTAL");
				b.Property<decimal?>("SaldoPendiente").HasColumnType("decimal(18,2)").HasColumnName("SUBTOTAL_CANCELADO");
				b.Property<decimal>("MontoCompra").HasColumnType("decimal(18,2)").HasColumnName("TOTAL");
				b.HasKey("IdPago");
				b.HasIndex("IdCompra");
				b.HasIndex("IdMedioPago");
				b.ToTable("PAGOS_COMPRAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PagosVentas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdPago").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_PAGO")
					.HasColumnOrder(2);
				b.Property<int>("IdPago").UseIdentityByDefaultColumn();
				b.Property<DateTime?>("Fecha").HasColumnType("timestamp").HasColumnName("FECHA");
				b.Property<int>("IdMedioPago").HasColumnType("int").HasColumnName("ID_MEDIO_PAGO");
				b.Property<int>("IdVenta").HasColumnType("int").HasColumnName("ID_VENTA");
				b.Property<decimal>("Monto").HasColumnType("decimal(18,2)").HasColumnName("MONTO");
				b.HasKey("IdPago");
				b.HasIndex("IdMedioPago");
				b.HasIndex("IdVenta");
				b.ToTable("PAGOS_VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PerfilesUsuarios", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdPerfil").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_PERFIL");
				b.Property<int>("IdPerfil").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("varcahr(100)")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").HasColumnType("integer").HasColumnName("ID_ESTADO");
				b.HasKey("IdPerfil");
				b.ToTable("USUARIOS_PERFILES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Producto", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdProducto").HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("ID_PRODUCTO");
				b.Property<int?>("Cantidad").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("CANTIDAD")
					.HasDefaultValueSql("((0))");
				b.Property<int?>("DiametroNominal").HasColumnType("integer").HasColumnName("DIAMETRO_NOMINAL");
				b.Property<int>("IdDescripcion").HasColumnType("integer").HasColumnName("ID_DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("IdTipo").IsRequired().HasMaxLength(50)
					.IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("ID_TIPO");
				b.Property<decimal?>("PorcentajeGanancia").HasColumnType("decimal(18,2)").HasColumnName("PORCENTAJE_GANANCIA");
				b.Property<decimal?>("PrecioFinal").HasColumnType("decimal(18,2)").HasColumnName("PRECIO_FINAL");
				b.Property<decimal?>("PrecioLista").ValueGeneratedOnAdd().HasColumnType("money")
					.HasColumnName("PRECIO_LISTA")
					.HasDefaultValueSql("((0))");
				b.Property<string>("Tolerancia").HasColumnType("text").HasColumnName("TOLERANCIA");
				b.HasKey("IdProducto");
				b.HasIndex("IdDescripcion");
				b.HasIndex("IdEstado");
				b.HasIndex("IdTipo");
				b.ToTable("PRODUCTOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosDescripcion", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdDescripcion").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_DESCRIPCION");
				b.Property<int>("IdDescripcion").UseIdentityByDefaultColumn();
				b.Property<string>("DescripcionProducto").HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.HasKey("IdDescripcion");
				b.HasIndex("IdEstado");
				b.ToTable("PRODUCTOS_DESCRIPCION", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosTipo", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdTipo").HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("ID_TIPO");
				b.Property<string>("DescripcionTipo").HasMaxLength(100).IsUnicode(unicode: false)
					.HasColumnType("character varying(100)")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.HasKey("IdTipo").HasName("PK_PRODUCTOS_TIPOS");
				b.HasIndex("IdEstado");
				b.ToTable("PRODUCTOS_TIPOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Productos_Componentes", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdProducto").HasColumnType("varchar(50)").HasColumnName("ID_PRODUCTO");
				b.Property<string>("IdComponente").HasColumnType("varchar(50)").HasColumnName("ID_COMPONENTE");
				b.Property<decimal?>("Cantidad").HasColumnType("decimal(18,2)").HasColumnName("CANTIDAD");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<decimal?>("Longitud").HasColumnType("decimal(18,2)").HasColumnName("LONGITUD");
				b.Property<decimal?>("Peso").HasColumnType("decimal(18,2)").HasColumnName("PESO");
				b.HasKey("IdProducto", "IdComponente").HasName("PK_PRODUCTOS_COMPONENTES");
				b.HasIndex("IdEstado");
				b.ToTable("PRODUCTOS_COMPONENTES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Productos_Tipos_Descripcion", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdTipo").HasColumnType("varchar(50)").HasColumnName("ID_TIPO");
				b.Property<int?>("IdDescripcion").HasColumnType("integer").HasColumnName("ID_DESCRIPCION");
				b.HasKey("IdTipo", "IdDescripcion");
				b.HasIndex("IdDescripcion");
				b.ToTable("PRODUCTOS_TIPOS_DESCRIPCION", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.StockInsumos", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdInsumo").HasColumnType("varchar(50)").HasColumnName("ID_INSUMO");
				b.Property<decimal?>("Granallado").HasColumnType("decimal").HasColumnName("GRANALLADO");
				b.Property<decimal?>("Moldeado").HasColumnType("decimal").HasColumnName("MOLDEADO");
				b.Property<decimal?>("Pendiente").HasColumnType("decimal(18,2)").HasColumnName("PENDIENTE");
				b.Property<decimal?>("Pintura").HasColumnType("decimal").HasColumnName("PINTURA");
				b.Property<decimal?>("Proceso").HasColumnType("decimal").HasColumnName("PROCESO");
				b.Property<decimal?>("Recibido").HasColumnType("decimal").HasColumnName("RECIBIDO");
				b.HasKey("IdInsumo").HasName("PK_STOCK_INSUMOS");
				b.ToTable("STOCK_INSUMOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Stock_Movimientos", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdMovimiento").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_MOVIMIENTO");
				b.Property<int>("IdMovimiento").UseIdentityByDefaultColumn();
				b.Property<string>("CreadoUsuario").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("USUARIO_CREADO");
				b.Property<string>("Destino").HasColumnType("varchar(50)").HasColumnName("DESTINO");
				b.Property<DateTime>("FechaHoraCreado").HasColumnType("timestamp").HasColumnName("FECHA_HORA_CREADO");
				b.Property<DateTime?>("FechaHoraUltimaModificacion").HasColumnType("timestamp").HasColumnName("FECHA_HORA_ULTIMA_MODIFICACION");
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_MOVIMIENTO")
					.HasDefaultValueSql("1");
				b.Property<int>("IdProveedor").HasColumnType("int").HasColumnName("ID_PROVEEDOR_DESTINO");
				b.Property<int>("IdProveedorOrigen").HasColumnType("int").HasColumnName("ID_PROVEEDOR_ORIGEN");
				b.Property<string>("ModificadoUsuario").HasColumnType("varchar(50)").HasColumnName("USUARIO_MODIFICA");
				b.Property<string>("Origen").HasColumnType("varchar(50)").HasColumnName("ORIGEN");
				b.Property<string>("Tipo").HasColumnType("varchar(15)").HasColumnName("TIPO");
				b.HasKey("IdMovimiento");
				b.HasIndex("IdEstadoMovimiento");
				b.HasIndex("IdProveedor");
				b.HasIndex("IdProveedorOrigen");
				b.ToTable("STOCK_MOVIMIENTOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.SuministrosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdMovimiento").HasColumnType("int").HasColumnName("ID_MOVIMIENTO");
				b.Property<string>("IdSuministro").HasColumnType("varchar(50)").HasColumnName("ID_SUMINISTRO");
				b.Property<decimal>("Cantidad").HasColumnType("decimal(18,2)").HasColumnName("CANTIDAD");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.HasKey("IdMovimiento", "IdSuministro");
				b.HasIndex("IdEstado");
				b.ToTable("SUMINISTROS_MOVIMIENTOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Usuarios", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("Usuario").HasColumnType("varchar(50)").HasColumnName("USUARIO");
				b.Property<string>("Contraseña").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("CONTRASEÑA");
				b.Property<int>("IdPerfil").HasColumnType("int").HasColumnName("ID_PERFIL");
				b.Property<string>("Correo").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("CORREO");
				b.HasKey("Usuario");
				b.HasIndex("IdPerfil");
				b.ToTable("USUARIOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Ventas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdVenta").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_VENTA");
				b.Property<int>("IdVenta").UseIdentityByDefaultColumn();
				b.Property<DateTime>("FechaHora").HasColumnType("timestamp").HasColumnName("FECHA_HORA");
				b.Property<int>("IdEntidad").HasColumnType("int").HasColumnName("ID_CLIENTE");
				b.Property<int>("IdEstadoVenta").HasColumnType("int").HasColumnName("ID_ESTADO_VENTA");
				b.Property<string>("IdUsuario").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("ID_USUARIO");
				b.Property<decimal>("SaldoPendiente").HasColumnType("numeric").HasColumnName("SALDO_PENDIENTE");
				b.Property<decimal>("MontoCompra").HasColumnType("decimal(18,2)").HasColumnName("TOTAL");
				b.HasKey("IdVenta");
				b.HasIndex("IdEntidad");
				b.HasIndex("IdEstadoVenta");
				b.HasIndex("IdUsuario");
				b.ToTable("VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.VentasDetalles", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdVenta").HasColumnType("int").HasColumnName("ID_VENTA");
				b.Property<string>("IdProducto").HasColumnType("varchar(50)").HasColumnName("ID_PRODUCTO");
				b.Property<decimal>("Cantidad").HasColumnType("decimal(18,2)").HasColumnName("CANTIDAD");
				b.Property<int?>("Entregados").HasColumnType("integer").HasColumnName("ENTREGADOS");
				b.Property<decimal>("Precio").HasColumnType("decimal(18,2)").HasColumnName("PRECIO");
				b.HasKey("IdVenta", "IdProducto");
				b.HasIndex("IdProducto");
				b.ToTable("VENTAS_DETALLES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ArchivosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosArchivosMovimientosStock", "ArchivosMovimientosStockNavigation").WithMany("ArchivosMovimientoStock").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Stock_Movimientos", "StockMovimiento").WithMany().HasForeignKey("IdMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_ARCHIVOS_STOCK_STOCK_MOVIMIENTOS_ID_MOVIMIENTO");
				b.Navigation("ArchivosMovimientosStockNavigation");
				b.Navigation("StockMovimiento");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComponentesDetalle", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosComponentesDetalles", "IdEstadoNavigation").WithMany("ComponentesDetalle").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdEstadoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Compras", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosCompras", "Estado").WithMany("compras").HasForeignKey("EstadoIdEstadoCompra")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Entidades", "IdProveedor").WithMany("compras").HasForeignKey("IdProveedor")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Usuarios", "Usuario").WithMany("Compras").HasForeignKey("IdUsuario")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired();
				b.Navigation("Estado");
				b.Navigation("IdProveedor");
				b.Navigation("Usuario");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComprasDetalles", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Compras", "CompraNavigation").WithMany("DetallesCompra").HasForeignKey("IdCompra")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.ComponentesDetalle", "DetallesInsumo").WithMany("ComprasNavigation").HasForeignKey("IdInsumo")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("CompraNavigation");
				b.Navigation("DetallesInsumo");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.CuotasVentas", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosCuotasVentas", "EstadoCuota").WithMany("IdEstadoCuotaNavigation").HasForeignKey("IdEstadoCuota")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Ventas", "Venta").WithMany("Cuotas").HasForeignKey("IdVenta")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("EstadoCuota");
				b.Navigation("Venta");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Entidades", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EntidadesCategorias", "CategoriaEntidad").WithMany("Entidades").HasForeignKey("IdCategoria")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.EntidadesTipos", "TipoEntidad").WithMany("Entidades").HasForeignKey("IdTipo")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Usuarios", "UsuarioRegistro").WithMany("IdUsuarioRegistroNavigation").HasForeignKey("IdUsuarioRegistro")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("CategoriaEntidad");
				b.Navigation("TipoEntidad");
				b.Navigation("UsuarioRegistro");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesTiposCategorias", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EntidadesCategorias", "CategoriaEntidad").WithMany("TiposCategoriasNavigation").HasForeignKey("IdCategoriaEntidad")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.EntidadesTipos", "TipoEntidad").WithMany("TiposCategoriasNavigation").HasForeignKey("idTipoEntidad")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("CategoriaEntidad");
				b.Navigation("TipoEntidad");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PagosCompras", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Compras", "CompraNavigation").WithMany("Pagos").HasForeignKey("IdCompra")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.MediosPago", "MedioPago").WithMany("PagosComprasNavigation").HasForeignKey("IdMedioPago")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("CompraNavigation");
				b.Navigation("MedioPago");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PagosVentas", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.MediosPago", "MedioPago").WithMany("PagosVentasNavigation").HasForeignKey("IdMedioPago")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Ventas", "Venta").WithMany("Pagos").HasForeignKey("IdVenta")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("MedioPago");
				b.Navigation("Venta");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Producto", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.ProductosDescripcion", "IdDescripcionNavigation").WithMany("StockProductos").HasForeignKey("IdDescripcion")
					.IsRequired()
					.HasConstraintName("FK_PRODUCTOS_PRODUCTOS_DESCRIPCION");
				b.HasOne("Aponus_Web_API.Modelos.EstadosProductos", "IdEstadoNavigation").WithMany("StockProductos").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.ProductosTipo", "IdTipoNavigation").WithMany("StockProductos").HasForeignKey("IdTipo")
					.IsRequired()
					.HasConstraintName("FK_PRODUCTOS_PRODUCTOS_TIPOS");
				b.Navigation("IdDescripcionNavigation");
				b.Navigation("IdEstadoNavigation");
				b.Navigation("IdTipoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosDescripcion", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosProductosDescripciones", "IdEstadoNavigation").WithMany("ProductosDescripcions").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdEstadoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosTipo", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosTiposProductos", "IdEstadoNavigation").WithMany("ProductosTipos").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdEstadoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Productos_Componentes", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosProductosComponentes", "IdEstadoNavigation").WithMany("ProductosComponentes").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdEstadoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Productos_Tipos_Descripcion", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.ProductosDescripcion", "IdDescripcionNavigation").WithMany("Producto_Tipo_Descripcione").HasForeignKey("IdDescripcion")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired()
					.HasConstraintName("FK_PRODUCTOS_TIPOS_DESCRIPCION_ID_DESCRIPCION");
				b.HasOne("Aponus_Web_API.Modelos.ProductosTipo", "IdTipoNavigation").WithMany("Producto_Tipo_Descripcione").HasForeignKey("IdTipo")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired()
					.HasConstraintName("FK_PRODUCTOS_TIPOS_DESCRIPCION_ID_TIPO");
				b.Navigation("IdDescripcionNavigation");
				b.Navigation("IdTipoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Stock_Movimientos", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosMovimientosStock", "estadoMovimiento").WithMany("movimientosStock").HasForeignKey("IdEstadoMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Entidades", "Proveeedor").WithMany("Movimientos").HasForeignKey("IdProveedor")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_STOCK_MOVIMIENTOS_ENTIDADES_ID_PROVEEDOR_DESTINO");
				b.HasOne("Aponus_Web_API.Modelos.Entidades", "ProveedorOrigen").WithMany("MovimientosOrigen").HasForeignKey("IdProveedorOrigen")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_STOCK_MOVIMIENTOS_ENTIDADES_ID_PROVEEDOR_ORIGEN");
				b.Navigation("Proveeedor");
				b.Navigation("ProveedorOrigen");
				b.Navigation("estadoMovimiento");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.SuministrosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosSuministrosMovimientosStock", "EstadosSuministrosMovimientosStockNavigation").WithMany("SuministrosMovimientoStock").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_SUMINISTROS_MOVIMIENTOS_STOCK_ESTADOS_SUMINISTROS_MOVIMIENTO");
				b.HasOne("Aponus_Web_API.Modelos.Stock_Movimientos", null).WithMany("Suministros").HasForeignKey("IdMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("EstadosSuministrosMovimientosStockNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Usuarios", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.PerfilesUsuarios", "Perfil").WithMany("UsuariosNavigation").HasForeignKey("IdPerfil")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_USUARIOS_PERFILES_USUARIOS_ID_PERFIL");
				b.Navigation("Perfil");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Ventas", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Entidades", "Cliente").WithMany("ventas").HasForeignKey("IdEntidad")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.EstadosVentas", "Estado").WithMany("ventas").HasForeignKey("IdEstadoVenta")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Usuarios", "Usuario").WithMany("Ventas").HasForeignKey("IdUsuario")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired();
				b.Navigation("Cliente");
				b.Navigation("Estado");
				b.Navigation("Usuario");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.VentasDetalles", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Producto", "IdProductoNavigation").WithMany("Ventas").HasForeignKey("IdProducto")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_VENTAS_DETALLES_PRODUCTOS_ID_PRODUCTO");
				b.HasOne("Aponus_Web_API.Modelos.Ventas", "Venta").WithMany("DetallesVenta").HasForeignKey("IdVenta")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdProductoNavigation");
				b.Navigation("Venta");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComponentesDetalle", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ComprasNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Compras", delegate(EntityTypeBuilder b)
			{
				b.Navigation("DetallesCompra");
				b.Navigation("Pagos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Entidades", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Movimientos");
				b.Navigation("MovimientosOrigen");
				b.Navigation("compras");
				b.Navigation("ventas");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesCategorias", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Entidades");
				b.Navigation("TiposCategoriasNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesTipos", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Entidades");
				b.Navigation("TiposCategoriasNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosArchivosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ArchivosMovimientoStock");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosComponentesDetalles", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ComponentesDetalle");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCompras", delegate(EntityTypeBuilder b)
			{
				b.Navigation("compras");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCuotasVentas", delegate(EntityTypeBuilder b)
			{
				b.Navigation("IdEstadoCuotaNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Navigation("movimientosStock");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductos", delegate(EntityTypeBuilder b)
			{
				b.Navigation("StockProductos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductosComponentes", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ProductosComponentes");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductosDescripciones", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ProductosDescripcions");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosSuministrosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Navigation("SuministrosMovimientoStock");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosTiposProductos", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ProductosTipos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosVentas", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ventas");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.MediosPago", delegate(EntityTypeBuilder b)
			{
				b.Navigation("PagosComprasNavigation");
				b.Navigation("PagosVentasNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PerfilesUsuarios", delegate(EntityTypeBuilder b)
			{
				b.Navigation("UsuariosNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Producto", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Ventas");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosDescripcion", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Producto_Tipo_Descripcione");
				b.Navigation("StockProductos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosTipo", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Producto_Tipo_Descripcione");
				b.Navigation("StockProductos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Stock_Movimientos", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Suministros");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Usuarios", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Compras");
				b.Navigation("IdUsuarioRegistroNavigation");
				b.Navigation("Ventas");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Ventas", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Cuotas");
				b.Navigation("DetallesVenta");
				b.Navigation("Pagos");
			});
		}
	}
	[DbContext(typeof(AponusContext))]
	[Migration("20241027110209_Compras")]
	public class Compras : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable("ESTADOS_COMPRAS", (ColumnsBuilder table) => new
			{
				IdEstadoCompra = table.Column<int>("int", null, null, rowVersion: false, "ID_ESTADO_COMPRA").Annotation("Npgsql: ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
				Descripcion = table.Column<string>("text", null, null, rowVersion: false, "DESCRIPCION"),
				IdEstado = table.Column<int>("integer", null, null, rowVersion: false, "ID_ESTADO", nullable: false, null, "1")
			}, null, table =>
			{
				table.PrimaryKey("PK_ESTADOS_COMPRAS", X => X.IdEstadoCompra);
			});
			migrationBuilder.CreateIndex("IX_ESTADOS_COMPRAS_ID_ESTADO_COMPRA", "ESTADOS_COMPRAS", "ID_ESTADO_COMPRA");
			migrationBuilder.CreateTable("ESTADOS_CUOTAS_COMPRAS", (ColumnsBuilder table) => new
			{
				IDESTADOCUOTA = table.Column<int>("integer", null, null, rowVersion: false, "ID_ESTADO_CUOTA").Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
				DESCRIPCION = table.Column<string>("text"),
				IDESTADO = table.Column<int>("integer", null, null, rowVersion: false, "ID_ESTADO", nullable: false, null, "1")
			}, null, table =>
			{
				table.PrimaryKey("PK_ESTADOS_CUOTAS_COMPRAS", x => x.IDESTADOCUOTA);
			});
			migrationBuilder.CreateTable("CUOTAS_COMPRAS", (ColumnsBuilder table) => new
			{
				IDCUOTA = table.Column<int>("integer", null, null, rowVersion: false, "ID_CUOTA").Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
				IdCompra = table.Column<int>("int", null, null, rowVersion: false, "ID_COMPRA"),
				NUMEROCUOTA = table.Column<int>("integer", null, null, rowVersion: false, "NUMERO_CUOTA"),
				MONTO = table.Column<decimal>("numeric(18,2)", null, null, rowVersion: false, "MONTO"),
				FECHAVENCIMIENTO = table.Column<DateTime>("timestamp", null, null, rowVersion: false, "FECHA_VENCIMIENTO"),
				IdEstadoCuota = table.Column<int>("integer", null, null, rowVersion: false, "ID_ESTADO_CUOTA"),
				FECHAPAGO = table.Column<DateTime>("timestamp", null, null, rowVersion: false, "FECHA_PAGO", nullable: true)
			}, null, table =>
			{
				table.PrimaryKey("PK_CUOTAS_COMPRAS", x => x.IDCUOTA);
				table.ForeignKey("FK_CUOTAS_COMPRAS_COMPRAS_ID_COMPRA", x => x.IdCompra, "COMPRAS", "ID_COMPRA", null, ReferentialAction.NoAction, ReferentialAction.Cascade);
				table.ForeignKey("FK_CUOTAS_COMPRAS_ESTADOS_CUOTAS_COMPRAS_ID_ESTADO_CUOTA", x => x.IdEstadoCuota, "ESTADOS_CUOTAS_COMPRAS", "ID_ESTADO_CUOTA", null, ReferentialAction.NoAction, ReferentialAction.Cascade);
			});
			migrationBuilder.CreateIndex("IX_CUOTAS_COMPRAS_ID_COMPRA", "CUOTAS_COMPRAS", "ID_COMPRA");
			migrationBuilder.CreateIndex("IX_CUOTAS_COMPRAS_ID_ESTADO_CUOTA", "CUOTAS_COMPRAS", "ID_ESTADO_CUOTA");
			migrationBuilder.AddForeignKey("FK_COMPRAS_ESTADOS_COMPRAS_ID_ESTADO_COMPRA", "COMPRAS", "ID_ESTADO_COMPRA", "ESTADOS_COMPRAS", null, null, "ID_ESTADO_COMPRA", ReferentialAction.NoAction, ReferentialAction.Cascade);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey("FK_COMPRAS_ESTADOS_COMPRAS_ID_ESTADO_COMPRA", "COMPRAS");
			migrationBuilder.DropForeignKey("FK_COMPRAS_USUARIOS_USAURIO", "COMPRAS");
			migrationBuilder.DropTable("CUOTAS_COMPRAS");
			migrationBuilder.DropTable("ESTADOS_CUOTAS_COMPRAS");
			migrationBuilder.DropIndex("IX_COMPRAS_ID_ESTADO_COMPRA", "COMPRAS");
			Type typeFromHandle = typeof(string);
			migrationBuilder.AlterColumn<string>("DESCRIPCION", "USUARIOS_PERFILES", "varcahr(100)", null, null, rowVersion: false, null, nullable: false, null, null, null, typeFromHandle, "varchar(100)");
			migrationBuilder.AddColumn<int>("EstadoIdEstadoCompra", "COMPRAS", "int", null, null, rowVersion: false, null, nullable: false, 0);
			migrationBuilder.CreateIndex("IX_COMPRAS_EstadoIdEstadoCompra", "COMPRAS", "EstadoIdEstadoCompra");
			migrationBuilder.AddForeignKey("FK_COMPRAS_ESTADOS_COMPRAS_EstadoIdEstadoCompra", "COMPRAS", "EstadoIdEstadoCompra", "ESTADOS_COMPRAS", null, null, "ID_ESTADO_COMPRA", ReferentialAction.NoAction, ReferentialAction.Cascade);
			migrationBuilder.AddForeignKey("FK_COMPRAS_USUARIOS_ID_USUARIO", "COMPRAS", "ID_USUARIO", "USUARIOS", null, null, "USUARIO");
		}

		protected override void BuildTargetModel(ModelBuilder modelBuilder)
		{
			modelBuilder.UseCollation("Modern_Spanish_CI_AI").HasAnnotation("ProductVersion", "7.0.11").HasAnnotation("Relational:MaxIdentifierLength", 63);
			modelBuilder.UseIdentityByDefaultColumns();
			modelBuilder.Entity("Aponus_Web_API.Modelos.ArchivosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdMovimiento").HasColumnType("int").HasColumnName("ID_MOVIMIENTO");
				b.Property<string>("HashArchivo").HasColumnType("varchar(255)").HasColumnName("HASH_ARCHIVO");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("MimeType").HasColumnType("text").HasColumnName("MIME_TYPE");
				b.Property<string>("PathArchivo").IsRequired().HasColumnType("text")
					.HasColumnName("PATH");
				b.HasKey("IdMovimiento", "HashArchivo");
				b.HasIndex("IdEstado");
				b.ToTable("ARCHIVOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComponentesDescripcion", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdDescripcion").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_DESCRIPCION");
				b.Property<int>("IdDescripcion").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("DESCRIPCION");
				b.Property<string>("IdAlmacenamiento").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("ID_ALMACENAMIENTO");
				b.Property<string>("IdFraccionamiento").HasColumnType("varchar(50)").HasColumnName("ID_FRACCIONAMIENTO");
				b.HasKey("IdDescripcion");
				b.ToTable("COMPONENTES_DESCRIPCION", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComponentesDetalle", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdInsumo").HasColumnType("varchar(50)").HasColumnName("ID_INSUMO");
				b.Property<decimal?>("Altura").HasColumnType("decimal(18,2)").HasColumnName("ALTURA");
				b.Property<decimal?>("Diametro").HasColumnType("decimal(18,2)").HasColumnName("DIAMETRO");
				b.Property<int?>("DiametroNominal").HasColumnType("int").HasColumnName("DIAMETRO_NOMINAL");
				b.Property<decimal?>("Espesor").HasColumnType("decimal(18,2)").HasColumnName("ESPESOR");
				b.Property<string>("IdAlmacenamiento").HasColumnType("varchar(50)").HasColumnName("ID_ALMACENAMIENTO");
				b.Property<int>("IdDescripcion").HasColumnType("integer").HasColumnName("ID_DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("IdFraccionamiento").HasColumnType("varchar(50)").HasColumnName("ID_FRACCIONAMIENTO");
				b.Property<decimal?>("Longitud").HasColumnType("decimal(18,2)").HasColumnName("LONGITUD");
				b.Property<int?>("Perfil").HasColumnType("integer").HasColumnName("PERFIL");
				b.Property<decimal?>("Peso").HasColumnType("decimal(18,3)").HasColumnName("PESO");
				b.Property<string>("Tolerancia").HasColumnType("varchar(50)").HasColumnName("TOLERANCIA");
				b.HasKey("IdInsumo").HasName("PK_ID_INSUMO");
				b.HasIndex("IdEstado");
				b.ToTable("COMPONENTES_DETALLE", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Compras", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCompra").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_COMPRA");
				b.Property<int>("IdCompra").UseIdentityByDefaultColumn();
				b.Property<DateTime>("FechaHora").HasColumnType("timestamp").HasColumnName("FECHA_HORA");
				b.Property<int>("IdEstadoCompra").HasColumnType("int").HasColumnName("ID_ESTADO_COMPRA");
				b.Property<int>("IdProveedor").HasColumnType("int").HasColumnName("ID_PROVEEDOR");
				b.Property<string>("IdUsuario").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("ID_USUARIO");
				b.Property<decimal?>("SaldoPendiente").HasColumnType("decimal(18,2)").HasColumnName("SALDO_CANCELADO");
				b.Property<decimal>("MontoTotal").HasColumnType("decimal(18,2)").HasColumnName("SALDO_TOTAL");
				b.HasKey("IdCompra");
				b.HasIndex("IdEstadoCompra");
				b.HasIndex("IdProveedor");
				b.HasIndex("IdUsuario");
				b.ToTable("COMPRAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComprasDetalles", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCompra").HasColumnType("int").HasColumnName("ID_COMPRA");
				b.Property<string>("IdInsumo").HasColumnType("varchar(50)").HasColumnName("ID_INSUMO");
				b.Property<decimal>("Cantidad").HasColumnType("decimal(18,2)").HasColumnName("CANTIDAD");
				b.HasKey("IdCompra", "IdInsumo");
				b.HasIndex("IdInsumo");
				b.ToTable("COMPRAS_DETALLE", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.CuotasCompras", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCuota").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_CUOTA");
				b.Property<int>("IdCuota").UseIdentityByDefaultColumn();
				b.Property<DateTime?>("Fecha").HasColumnType("timestamp").HasColumnName("FECHA_PAGO");
				b.Property<DateTime>("FechaVencimiento").HasColumnType("timestamp").HasColumnName("FECHA_VENCIMIENTO");
				b.Property<int>("IdCompra").HasColumnType("int");
				b.Property<int>("IdEstadoCuota").HasColumnType("integer");
				b.Property<decimal>("Monto").HasColumnType("decimal(18,2)").HasColumnName("MONTO");
				b.Property<int>("NumeroCuota").HasColumnType("integer").HasColumnName("NUMERO_CUOTA");
				b.HasKey("IdCuota");
				b.HasIndex("IdCompra");
				b.HasIndex("IdEstadoCuota");
				b.ToTable("CUOTAS_COMPRAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.CuotasVentas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCuota").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_CUOTA");
				b.Property<int>("IdCuota").UseIdentityByDefaultColumn();
				b.Property<DateTime?>("Fecha").HasColumnType("timestamp").HasColumnName("FECHA_PAGO");
				b.Property<DateTime>("FechaVencimiento").HasColumnType("timestamp").HasColumnName("FECHA_VENCIMIENTO");
				b.Property<int>("IdEstadoCuota").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_CUOTA")
					.HasDefaultValueSql("1");
				b.Property<int>("IdVenta").HasColumnType("int").HasColumnName("ID_VENTA");
				b.Property<decimal>("Monto").ValueGeneratedOnAdd().HasColumnType("decimal(18,2)")
					.HasColumnName("MONTO")
					.HasDefaultValueSql("0.00");
				b.Property<int>("NumeroCuota").HasColumnType("int").HasColumnName("NUMERO_CUOTA");
				b.HasKey("IdCuota");
				b.HasIndex("IdEstadoCuota");
				b.HasIndex("IdVenta");
				b.ToTable("CUOTAS_VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Entidades", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEntidad").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ENTIDAD");
				b.Property<int>("IdEntidad").UseIdentityByDefaultColumn();
				b.Property<string>("Altura").HasColumnType("text").HasColumnName("ALTURA");
				b.Property<string>("Apellido").HasColumnType("text").HasColumnName("APELLIDO");
				b.Property<string>("Barrio").HasColumnType("text").HasColumnName("BARRIO");
				b.Property<string>("Calle").HasColumnType("text").HasColumnName("CALLE");
				b.Property<string>("Ciudad").HasColumnType("text").HasColumnName("CIUDAD");
				b.Property<string>("CodigoPostal").HasColumnType("text").HasColumnName("CODIGO_POSTAL");
				b.Property<string>("Email").HasColumnType("text").HasColumnName("EMAIL");
				b.Property<DateTime>("FechaRegistro").HasColumnType("timestamp").HasColumnName("FECHA_REGISTRO");
				b.Property<int>("IdCategoria").HasColumnType("int").HasColumnName("ID_CATEGORIA");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("(1)");
				b.Property<string>("IdFiscal").IsRequired().HasColumnType("text")
					.HasColumnName("ID_FISCAL");
				b.Property<int>("IdTipo").HasColumnType("int").HasColumnName("ID_TIPO");
				b.Property<string>("IdUsuarioRegistro").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("ID_USUARIO_REGISTRO");
				b.Property<string>("Localidad").HasColumnType("text").HasColumnName("LOCALIDAD");
				b.Property<string>("Nombre").HasColumnType("text").HasColumnName("NOMBRE");
				b.Property<string>("NombreClave").HasColumnType("text").HasColumnName("NOMBRE_CLAVE");
				b.Property<string>("Pais").HasColumnType("text").HasColumnName("PAIS");
				b.Property<string>("Provincia").HasColumnType("text").HasColumnName("PROVINCIA");
				b.Property<string>("Telefono1").HasColumnType("text").HasColumnName("TELEFONO_1");
				b.Property<string>("Telefono2").HasColumnType("text").HasColumnName("TELEFONO_2");
				b.Property<string>("Telefono3").HasColumnType("text").HasColumnName("TELEFONO_3");
				b.HasKey("IdEntidad");
				b.HasIndex("IdCategoria");
				b.HasIndex("IdTipo");
				b.HasIndex("IdUsuarioRegistro");
				b.ToTable("ENTIDADES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesCategorias", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCategoria").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_CATEGORIA");
				b.Property<int>("IdCategoria").UseIdentityByDefaultColumn();
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("NombreCategoria").IsRequired().HasColumnType("text")
					.HasColumnName("NOMBRE_CATEGORIA");
				b.HasKey("IdCategoria");
				b.ToTable("ENTIDADES_CATEGORIAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesTipos", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdTipo").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_TIPO");
				b.Property<int>("IdTipo").UseIdentityByDefaultColumn();
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("NombreTipo").IsRequired().HasColumnType("text")
					.HasColumnName("NOMBRE");
				b.HasKey("IdTipo");
				b.ToTable("ENTIDADES_TIPOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesTiposCategorias", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("idTipoEntidad").HasColumnType("int").HasColumnName("ID_TIPO");
				b.Property<int>("IdCategoriaEntidad").HasColumnType("int").HasColumnName("ID_CATEGORIA");
				b.HasKey("idTipoEntidad", "IdCategoriaEntidad");
				b.HasIndex("IdCategoriaEntidad");
				b.ToTable("ENTIDADES_TIPOS_CATEGORIAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosArchivosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_ARCHIVOS_MOVIMIENTOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosComponentesDetalles", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_COMPONENTES_DETALLES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCompras", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoCompra").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_COMPRA")
					.HasAnnotation("SqlServer:Identity", "1, 1");
				b.Property<int>("IdEstadoCompra").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").HasColumnType("int").HasColumnName("ID_ESTADO");
				b.HasKey("IdEstadoCompra");
				b.ToTable("ESTADOS_COMPRAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCuotasCompras", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoCuota").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO_CUOTA");
				b.Property<int>("IdEstadoCuota").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.HasKey("IdEstadoCuota");
				b.ToTable("ESTADOS_CUOTAS_COMPRAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCuotasVentas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoCuota").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_CUOTA");
				b.Property<int>("IdEstadoCuota").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.HasKey("IdEstadoCuota");
				b.ToTable("ESTADOS_CUOTAS_VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int?>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_MOVIMIENTO");
				b.Property<int?>("IdEstadoMovimiento").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.HasKey("IdEstadoMovimiento");
				b.ToTable("ESTADOS_MOVIMIENTOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductos", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_PRODUCTOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductosComponentes", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_PRODUCTOS_COMPONENTES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductosDescripciones", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_PRODUCTOS_DESCRIPCIONES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosSuministrosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_SUMINISTROS_MOVIMIENTOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosTiposProductos", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_PRODUCTOS_TIPOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosVentas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoVenta").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_VENTA");
				b.Property<int>("IdEstadoVenta").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("int")
					.HasDefaultValue(1)
					.HasColumnName("ID_ESTADO");
				b.HasKey("IdEstadoVenta");
				b.ToTable("ESTADOS_VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.MediosPago", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdMedioPago").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_MEDIO_PAGO");
				b.Property<int>("IdMedioPago").UseIdentityByDefaultColumn();
				b.Property<string>("CodigoMPago").HasColumnType("text").HasColumnName("CODIGO_MPAGO");
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("int")
					.HasDefaultValue(1)
					.HasColumnName("ID_ESTADO");
				b.HasKey("IdMedioPago");
				b.ToTable("MEDIOS_PAGO", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PagosCompras", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdPago").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_PAGO")
					.HasColumnOrder(2);
				b.Property<int>("IdPago").UseIdentityByDefaultColumn();
				b.Property<int?>("CantidadCuotas").HasColumnType("int").HasColumnName("CANTIDAD_CUOTAS");
				b.Property<int?>("CantidadCuotasCanceladas").HasColumnType("int").HasColumnName("CANTIDAD_CUOTAS_CANCELADAS");
				b.Property<int>("IdCompra").HasColumnType("int").HasColumnName("ID_COMPRA");
				b.Property<int>("IdMedioPago").HasColumnType("int").HasColumnName("ID_MEDIO_PAGO");
				b.Property<decimal>("Monto").HasColumnType("decimal(18,2)").HasColumnName("SUBTOTAL");
				b.Property<decimal?>("SaldoPendiente").HasColumnType("decimal(18,2)").HasColumnName("SUBTOTAL_CANCELADO");
				b.Property<decimal>("MontoCompra").HasColumnType("decimal(18,2)").HasColumnName("TOTAL");
				b.HasKey("IdPago");
				b.HasIndex("IdCompra");
				b.HasIndex("IdMedioPago");
				b.ToTable("PAGOS_COMPRAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PagosVentas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdPago").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_PAGO")
					.HasColumnOrder(2);
				b.Property<int>("IdPago").UseIdentityByDefaultColumn();
				b.Property<DateTime?>("Fecha").HasColumnType("timestamp").HasColumnName("FECHA");
				b.Property<int>("IdMedioPago").HasColumnType("int").HasColumnName("ID_MEDIO_PAGO");
				b.Property<int>("IdVenta").HasColumnType("int").HasColumnName("ID_VENTA");
				b.Property<decimal>("Monto").HasColumnType("decimal(18,2)").HasColumnName("MONTO");
				b.HasKey("IdPago");
				b.HasIndex("IdMedioPago");
				b.HasIndex("IdVenta");
				b.ToTable("PAGOS_VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PerfilesUsuarios", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdPerfil").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_PERFIL");
				b.Property<int>("IdPerfil").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("varchar(100)")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").HasColumnType("integer").HasColumnName("ID_ESTADO");
				b.HasKey("IdPerfil");
				b.ToTable("USUARIOS_PERFILES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Producto", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdProducto").HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("ID_PRODUCTO");
				b.Property<int?>("Cantidad").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("CANTIDAD")
					.HasDefaultValueSql("((0))");
				b.Property<int?>("DiametroNominal").HasColumnType("integer").HasColumnName("DIAMETRO_NOMINAL");
				b.Property<int>("IdDescripcion").HasColumnType("integer").HasColumnName("ID_DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("IdTipo").IsRequired().HasMaxLength(50)
					.IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("ID_TIPO");
				b.Property<decimal?>("PorcentajeGanancia").HasColumnType("decimal(18,2)").HasColumnName("PORCENTAJE_GANANCIA");
				b.Property<decimal?>("PrecioFinal").HasColumnType("decimal(18,2)").HasColumnName("PRECIO_FINAL");
				b.Property<decimal?>("PrecioLista").ValueGeneratedOnAdd().HasColumnType("money")
					.HasColumnName("PRECIO_LISTA")
					.HasDefaultValueSql("((0))");
				b.Property<string>("Tolerancia").HasColumnType("text").HasColumnName("TOLERANCIA");
				b.HasKey("IdProducto");
				b.HasIndex("IdDescripcion");
				b.HasIndex("IdEstado");
				b.HasIndex("IdTipo");
				b.ToTable("PRODUCTOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosDescripcion", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdDescripcion").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_DESCRIPCION");
				b.Property<int>("IdDescripcion").UseIdentityByDefaultColumn();
				b.Property<string>("DescripcionProducto").HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.HasKey("IdDescripcion");
				b.HasIndex("IdEstado");
				b.ToTable("PRODUCTOS_DESCRIPCION", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosTipo", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdTipo").HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("ID_TIPO");
				b.Property<string>("DescripcionTipo").HasMaxLength(100).IsUnicode(unicode: false)
					.HasColumnType("character varying(100)")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.HasKey("IdTipo").HasName("PK_PRODUCTOS_TIPOS");
				b.HasIndex("IdEstado");
				b.ToTable("PRODUCTOS_TIPOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Productos_Componentes", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdProducto").HasColumnType("varchar(50)").HasColumnName("ID_PRODUCTO");
				b.Property<string>("IdComponente").HasColumnType("varchar(50)").HasColumnName("ID_COMPONENTE");
				b.Property<decimal?>("Cantidad").HasColumnType("decimal(18,2)").HasColumnName("CANTIDAD");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<decimal?>("Longitud").HasColumnType("decimal(18,2)").HasColumnName("LONGITUD");
				b.Property<decimal?>("Peso").HasColumnType("decimal(18,2)").HasColumnName("PESO");
				b.HasKey("IdProducto", "IdComponente").HasName("PK_PRODUCTOS_COMPONENTES");
				b.HasIndex("IdEstado");
				b.ToTable("PRODUCTOS_COMPONENTES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Productos_Tipos_Descripcion", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdTipo").HasColumnType("varchar(50)").HasColumnName("ID_TIPO");
				b.Property<int?>("IdDescripcion").HasColumnType("integer").HasColumnName("ID_DESCRIPCION");
				b.HasKey("IdTipo", "IdDescripcion");
				b.HasIndex("IdDescripcion");
				b.ToTable("PRODUCTOS_TIPOS_DESCRIPCION", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.StockInsumos", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdInsumo").HasColumnType("varchar(50)").HasColumnName("ID_INSUMO");
				b.Property<decimal?>("Granallado").HasColumnType("decimal").HasColumnName("GRANALLADO");
				b.Property<decimal?>("Moldeado").HasColumnType("decimal").HasColumnName("MOLDEADO");
				b.Property<decimal?>("Pendiente").HasColumnType("decimal(18,2)").HasColumnName("PENDIENTE");
				b.Property<decimal?>("Pintura").HasColumnType("decimal").HasColumnName("PINTURA");
				b.Property<decimal?>("Proceso").HasColumnType("decimal").HasColumnName("PROCESO");
				b.Property<decimal?>("Recibido").HasColumnType("decimal").HasColumnName("RECIBIDO");
				b.HasKey("IdInsumo").HasName("PK_STOCK_INSUMOS");
				b.ToTable("STOCK_INSUMOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Stock_Movimientos", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdMovimiento").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_MOVIMIENTO");
				b.Property<int>("IdMovimiento").UseIdentityByDefaultColumn();
				b.Property<string>("CreadoUsuario").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("USUARIO_CREADO");
				b.Property<string>("Destino").HasColumnType("varchar(50)").HasColumnName("DESTINO");
				b.Property<DateTime>("FechaHoraCreado").HasColumnType("timestamp").HasColumnName("FECHA_HORA_CREADO");
				b.Property<DateTime?>("FechaHoraUltimaModificacion").HasColumnType("timestamp").HasColumnName("FECHA_HORA_ULTIMA_MODIFICACION");
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_MOVIMIENTO")
					.HasDefaultValueSql("1");
				b.Property<int>("IdProveedor").HasColumnType("int").HasColumnName("ID_PROVEEDOR_DESTINO");
				b.Property<int>("IdProveedorOrigen").HasColumnType("int").HasColumnName("ID_PROVEEDOR_ORIGEN");
				b.Property<string>("ModificadoUsuario").HasColumnType("varchar(50)").HasColumnName("USUARIO_MODIFICA");
				b.Property<string>("Origen").HasColumnType("varchar(50)").HasColumnName("ORIGEN");
				b.Property<string>("Tipo").HasColumnType("varchar(15)").HasColumnName("TIPO");
				b.HasKey("IdMovimiento");
				b.HasIndex("IdEstadoMovimiento");
				b.HasIndex("IdProveedor");
				b.HasIndex("IdProveedorOrigen");
				b.ToTable("STOCK_MOVIMIENTOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.SuministrosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdMovimiento").HasColumnType("int").HasColumnName("ID_MOVIMIENTO");
				b.Property<string>("IdSuministro").HasColumnType("varchar(50)").HasColumnName("ID_SUMINISTRO");
				b.Property<decimal>("Cantidad").HasColumnType("decimal(18,2)").HasColumnName("CANTIDAD");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.HasKey("IdMovimiento", "IdSuministro");
				b.HasIndex("IdEstado");
				b.ToTable("SUMINISTROS_MOVIMIENTOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Usuarios", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("Usuario").HasColumnType("varchar(50)").HasColumnName("USUARIO");
				b.Property<string>("Contraseña").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("CONTRASEÑA");
				b.Property<string>("Correo").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("CORREO");
				b.Property<int>("IdPerfil").HasColumnType("int").HasColumnName("ID_PERFIL");
				b.HasKey("Usuario");
				b.HasIndex("IdPerfil");
				b.ToTable("USUARIOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Ventas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdVenta").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_VENTA");
				b.Property<int>("IdVenta").UseIdentityByDefaultColumn();
				b.Property<DateTime>("FechaHora").HasColumnType("timestamp").HasColumnName("FECHA_HORA");
				b.Property<int>("IdCliente").HasColumnType("int").HasColumnName("ID_CLIENTE");
				b.Property<int>("IdEstadoVenta").HasColumnType("int").HasColumnName("ID_ESTADO_VENTA");
				b.Property<string>("IdUsuario").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("ID_USUARIO");
				b.Property<decimal>("SaldoPendiente").HasColumnType("numeric").HasColumnName("SALDO_PENDIENTE");
				b.Property<decimal>("MontoCompra").HasColumnType("decimal(18,2)").HasColumnName("TOTAL");
				b.HasKey("IdVenta");
				b.HasIndex("IdCliente");
				b.HasIndex("IdEstadoVenta");
				b.HasIndex("IdUsuario");
				b.ToTable("VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.VentasDetalles", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdVenta").HasColumnType("int").HasColumnName("ID_VENTA");
				b.Property<string>("IdProducto").HasColumnType("varchar(50)").HasColumnName("ID_PRODUCTO");
				b.Property<decimal>("Cantidad").HasColumnType("decimal(18,2)").HasColumnName("CANTIDAD");
				b.Property<int?>("Entregados").HasColumnType("integer").HasColumnName("ENTREGADOS");
				b.Property<decimal>("Precio").HasColumnType("decimal(18,2)").HasColumnName("PRECIO");
				b.HasKey("IdVenta", "IdProducto");
				b.HasIndex("IdProducto");
				b.ToTable("VENTAS_DETALLES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ArchivosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosArchivosMovimientosStock", "ArchivosMovimientosStockNavigation").WithMany("ArchivosMovimientoStock").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Stock_Movimientos", "StockMovimiento").WithMany().HasForeignKey("IdMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_ARCHIVOS_STOCK_STOCK_MOVIMIENTOS_ID_MOVIMIENTO");
				b.Navigation("ArchivosMovimientosStockNavigation");
				b.Navigation("StockMovimiento");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComponentesDetalle", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosComponentesDetalles", "IdEstadoNavigation").WithMany("ComponentesDetalle").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdEstadoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Compras", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosCompras", "Estado").WithMany("compras").HasForeignKey("IdEstadoCompra")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_COMPRAS_ESTADOS_COMPRAS_ID_ESTADO_COMPRA");
				b.HasOne("Aponus_Web_API.Modelos.Entidades", "IdProveedor").WithMany("compras").HasForeignKey("IdProveedor")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Usuarios", "Usuario").WithMany("Compras").HasForeignKey("IdUsuario")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired()
					.HasConstraintName("FK_COMPRAS_USUARIOS_USAURIO");
				b.Navigation("Estado");
				b.Navigation("IdProveedor");
				b.Navigation("Usuario");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComprasDetalles", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Compras", "Compra").WithMany("DetallesCompra").HasForeignKey("IdCompra")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.ComponentesDetalle", "DetallesInsumo").WithMany("ComprasNavigation").HasForeignKey("IdInsumo")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("Compra");
				b.Navigation("DetallesInsumo");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.CuotasCompras", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Compras", "CompraNavigation").WithMany("CuotasCompra").HasForeignKey("IdCompra")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_CUOTAS_COMPRAS_COMPRAS_ID_COMPRA");
				b.HasOne("Aponus_Web_API.Modelos.EstadosCuotasCompras", "EstadoCuotaCompra").WithMany("IdEstadoCuotaNavigation").HasForeignKey("IdEstadoCuota")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_CUOTAS_COMPRAS_ESTADOS_CUOTAS_COMPRAS_ID_ESTADO_CUOTA");
				b.Navigation("CompraNavigation");
				b.Navigation("EstadoCuotaCompra");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.CuotasVentas", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosCuotasVentas", "EstadoCuota").WithMany("IdEstadoCuotaNavigation").HasForeignKey("IdEstadoCuota")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Ventas", "Venta").WithMany("Cuotas").HasForeignKey("IdVenta")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("EstadoCuota");
				b.Navigation("Venta");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Entidades", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EntidadesCategorias", "CategoriaEntidad").WithMany("Entidades").HasForeignKey("IdCategoria")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.EntidadesTipos", "TipoEntidad").WithMany("Entidades").HasForeignKey("IdTipo")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Usuarios", "UsuarioRegistro").WithMany("IdUsuarioRegistroNavigation").HasForeignKey("IdUsuarioRegistro")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("CategoriaEntidad");
				b.Navigation("TipoEntidad");
				b.Navigation("UsuarioRegistro");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesTiposCategorias", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EntidadesCategorias", "CategoriaEntidad").WithMany("TiposCategoriasNavigation").HasForeignKey("IdCategoriaEntidad")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.EntidadesTipos", "TipoEntidad").WithMany("TiposCategoriasNavigation").HasForeignKey("idTipoEntidad")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("CategoriaEntidad");
				b.Navigation("TipoEntidad");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PagosCompras", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Compras", "Compra").WithMany("Pagos").HasForeignKey("IdCompra")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.MediosPago", "MedioPago").WithMany("PagosComprasNavigation").HasForeignKey("IdMedioPago")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("Compra");
				b.Navigation("MedioPago");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PagosVentas", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.MediosPago", "MedioPago").WithMany("PagosVentasNavigation").HasForeignKey("IdMedioPago")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Ventas", "Venta").WithMany("Pagos").HasForeignKey("IdVenta")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("MedioPago");
				b.Navigation("Venta");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Producto", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.ProductosDescripcion", "IdDescripcionNavigation").WithMany("Productos").HasForeignKey("IdDescripcion")
					.IsRequired()
					.HasConstraintName("FK_PRODUCTOS_PRODUCTOS_DESCRIPCION");
				b.HasOne("Aponus_Web_API.Modelos.EstadosProductos", "IdEstadoNavigation").WithMany("Productos").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.ProductosTipo", "IdTipoNavigation").WithMany("Productos").HasForeignKey("IdTipo")
					.IsRequired()
					.HasConstraintName("FK_PRODUCTOS_PRODUCTOS_TIPOS");
				b.Navigation("IdDescripcionNavigation");
				b.Navigation("IdEstadoNavigation");
				b.Navigation("IdTipoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosDescripcion", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosProductosDescripciones", "IdEstadoNavigation").WithMany("ProductosDescripcions").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdEstadoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosTipo", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosTiposProductos", "IdEstadoNavigation").WithMany("ProductosTipos").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdEstadoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Productos_Componentes", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosProductosComponentes", "IdEstadoNavigation").WithMany("ProductosComponentes").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdEstadoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Productos_Tipos_Descripcion", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.ProductosDescripcion", "IdDescripcionNavigation").WithMany("Producto_Tipo_Descripcione").HasForeignKey("IdDescripcion")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired()
					.HasConstraintName("FK_PRODUCTOS_TIPOS_DESCRIPCION_ID_DESCRIPCION");
				b.HasOne("Aponus_Web_API.Modelos.ProductosTipo", "IdTipoNavigation").WithMany("Producto_Tipo_Descripcione").HasForeignKey("IdTipo")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired()
					.HasConstraintName("FK_PRODUCTOS_TIPOS_DESCRIPCION_ID_TIPO");
				b.Navigation("IdDescripcionNavigation");
				b.Navigation("IdTipoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Stock_Movimientos", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosMovimientosStock", "estadoMovimiento").WithMany("movimientosStock").HasForeignKey("IdEstadoMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Entidades", "Proveeedor").WithMany("Movimientos").HasForeignKey("IdProveedor")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_STOCK_MOVIMIENTOS_ENTIDADES_ID_PROVEEDOR_DESTINO");
				b.HasOne("Aponus_Web_API.Modelos.Entidades", "ProveedorOrigen").WithMany("MovimientosOrigen").HasForeignKey("IdProveedorOrigen")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_STOCK_MOVIMIENTOS_ENTIDADES_ID_PROVEEDOR_ORIGEN");
				b.Navigation("Proveeedor");
				b.Navigation("ProveedorOrigen");
				b.Navigation("estadoMovimiento");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.SuministrosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosSuministrosMovimientosStock", "EstadosSuministrosMovimientosStockNavigation").WithMany("SuministrosMovimientoStock").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_SUMINISTROS_MOVIMIENTOS_STOCK_ESTADOS_SUMINISTROS_MOVIMIENTO");
				b.HasOne("Aponus_Web_API.Modelos.Stock_Movimientos", null).WithMany("Suministros").HasForeignKey("IdMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("EstadosSuministrosMovimientosStockNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Usuarios", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.PerfilesUsuarios", "Perfil").WithMany("UsuariosNavigation").HasForeignKey("IdPerfil")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_USUARIOS_PERFILES_USUARIOS_ID_PERFIL");
				b.Navigation("Perfil");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Ventas", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Entidades", "Cliente").WithMany("ventas").HasForeignKey("IdCliente")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.EstadosVentas", "Estado").WithMany("ventas").HasForeignKey("IdEstadoVenta")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Usuarios", "Usuario").WithMany("Ventas").HasForeignKey("IdUsuario")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired();
				b.Navigation("Cliente");
				b.Navigation("Estado");
				b.Navigation("Usuario");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.VentasDetalles", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Producto", "IdProductoNavigation").WithMany("Ventas").HasForeignKey("IdProducto")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_VENTAS_DETALLES_PRODUCTOS_ID_PRODUCTO");
				b.HasOne("Aponus_Web_API.Modelos.Ventas", "Venta").WithMany("DetallesVenta").HasForeignKey("IdVenta")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdProductoNavigation");
				b.Navigation("Venta");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComponentesDetalle", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ComprasNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Compras", delegate(EntityTypeBuilder b)
			{
				b.Navigation("CuotasCompra");
				b.Navigation("DetallesCompra");
				b.Navigation("Pagos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Entidades", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Movimientos");
				b.Navigation("MovimientosOrigen");
				b.Navigation("compras");
				b.Navigation("ventas");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesCategorias", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Entidades");
				b.Navigation("TiposCategoriasNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesTipos", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Entidades");
				b.Navigation("TiposCategoriasNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosArchivosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ArchivosMovimientoStock");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosComponentesDetalles", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ComponentesDetalle");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCompras", delegate(EntityTypeBuilder b)
			{
				b.Navigation("compras");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCuotasCompras", delegate(EntityTypeBuilder b)
			{
				b.Navigation("IdEstadoCuotaNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCuotasVentas", delegate(EntityTypeBuilder b)
			{
				b.Navigation("IdEstadoCuotaNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Navigation("movimientosStock");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductos", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Productos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductosComponentes", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ProductosComponentes");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductosDescripciones", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ProductosDescripcions");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosSuministrosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Navigation("SuministrosMovimientoStock");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosTiposProductos", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ProductosTipos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosVentas", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ventas");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.MediosPago", delegate(EntityTypeBuilder b)
			{
				b.Navigation("PagosComprasNavigation");
				b.Navigation("PagosVentasNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PerfilesUsuarios", delegate(EntityTypeBuilder b)
			{
				b.Navigation("UsuariosNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Producto", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Ventas");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosDescripcion", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Producto_Tipo_Descripcione");
				b.Navigation("Productos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosTipo", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Producto_Tipo_Descripcione");
				b.Navigation("Productos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Stock_Movimientos", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Suministros");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Usuarios", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Compras");
				b.Navigation("IdUsuarioRegistroNavigation");
				b.Navigation("Ventas");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Ventas", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Cuotas");
				b.Navigation("DetallesVenta");
				b.Navigation("Pagos");
			});
		}
	}
	[DbContext(typeof(AponusContext))]
	[Migration("20241028022153_Correcciones en PagosCompras")]
	public class CorreccionesenPagosCompras : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn("CANTIDAD_CUOTAS", "PAGOS_COMPRAS");
			migrationBuilder.DropColumn("CANTIDAD_CUOTAS_CANCELADAS", "PAGOS_COMPRAS");
			migrationBuilder.DropColumn("SUBTOTAL_CANCELADO", "PAGOS_COMPRAS");
			migrationBuilder.DropColumn("TOTAL", "PAGOS_COMPRAS");
			migrationBuilder.AddColumn<DateTime>("FECHA", "PAGOS_COMPRAS", "timestamp", null, null, rowVersion: false, null, nullable: true);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey("FK_COMPRAS_USUARIOS_IDUSUARIO", "COMPRAS");
			migrationBuilder.DropColumn("FECHA", "PAGOS_COMPRAS");
			migrationBuilder.RenameColumn("ID_COMPRA", "CUOTAS_COMPRAS", "IdCompra");
			migrationBuilder.RenameIndex("IX_CUOTAS_COMPRAS_ID_COMPRA", "IX_CUOTAS_COMPRAS_IdCompra", "CUOTAS_COMPRAS");
			migrationBuilder.AddColumn<int>("CANTIDAD_CUOTAS", "PAGOS_COMPRAS", "int", null, null, rowVersion: false, null, nullable: true);
			migrationBuilder.AddColumn<int>("CANTIDAD_CUOTAS_CANCELADAS", "PAGOS_COMPRAS", "int", null, null, rowVersion: false, null, nullable: true);
			migrationBuilder.AddColumn<decimal>("SUBTOTAL_CANCELADO", "PAGOS_COMPRAS", "numeric(18,2)", null, null, rowVersion: false, null, nullable: true);
			migrationBuilder.AddColumn<decimal>("TOTAL", "PAGOS_COMPRAS", "numeric(18,2)", null, null, rowVersion: false, null, nullable: false, 0m);
			migrationBuilder.AddForeignKey("FK_COMPRAS_USUARIOS_USAURIO", "COMPRAS", "ID_USUARIO", "USUARIOS", null, null, "USUARIO");
		}

		protected override void BuildTargetModel(ModelBuilder modelBuilder)
		{
			modelBuilder.UseCollation("Modern_Spanish_CI_AI").HasAnnotation("ProductVersion", "7.0.11").HasAnnotation("Relational:MaxIdentifierLength", 63);
			modelBuilder.UseIdentityByDefaultColumns();
			modelBuilder.Entity("Aponus_Web_API.Modelos.ArchivosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdMovimiento").HasColumnType("int").HasColumnName("ID_MOVIMIENTO");
				b.Property<string>("HashArchivo").HasColumnType("varchar(255)").HasColumnName("HASH_ARCHIVO");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("MimeType").HasColumnType("text").HasColumnName("MIME_TYPE");
				b.Property<string>("PathArchivo").IsRequired().HasColumnType("text")
					.HasColumnName("PATH");
				b.HasKey("IdMovimiento", "HashArchivo");
				b.HasIndex("IdEstado");
				b.ToTable("ARCHIVOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComponentesDescripcion", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdDescripcion").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_DESCRIPCION");
				b.Property<int>("IdDescripcion").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("DESCRIPCION");
				b.Property<string>("IdAlmacenamiento").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("ID_ALMACENAMIENTO");
				b.Property<string>("IdFraccionamiento").HasColumnType("varchar(50)").HasColumnName("ID_FRACCIONAMIENTO");
				b.HasKey("IdDescripcion");
				b.ToTable("COMPONENTES_DESCRIPCION", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComponentesDetalle", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdInsumo").HasColumnType("varchar(50)").HasColumnName("ID_INSUMO");
				b.Property<decimal?>("Altura").HasColumnType("decimal(18,2)").HasColumnName("ALTURA");
				b.Property<decimal?>("Diametro").HasColumnType("decimal(18,2)").HasColumnName("DIAMETRO");
				b.Property<int?>("DiametroNominal").HasColumnType("int").HasColumnName("DIAMETRO_NOMINAL");
				b.Property<decimal?>("Espesor").HasColumnType("decimal(18,2)").HasColumnName("ESPESOR");
				b.Property<string>("IdAlmacenamiento").HasColumnType("varchar(50)").HasColumnName("ID_ALMACENAMIENTO");
				b.Property<int>("IdDescripcion").HasColumnType("integer").HasColumnName("ID_DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("IdFraccionamiento").HasColumnType("varchar(50)").HasColumnName("ID_FRACCIONAMIENTO");
				b.Property<decimal?>("Longitud").HasColumnType("decimal(18,2)").HasColumnName("LONGITUD");
				b.Property<int?>("Perfil").HasColumnType("integer").HasColumnName("PERFIL");
				b.Property<decimal?>("Peso").HasColumnType("decimal(18,3)").HasColumnName("PESO");
				b.Property<string>("Tolerancia").HasColumnType("varchar(50)").HasColumnName("TOLERANCIA");
				b.HasKey("IdInsumo").HasName("PK_ID_INSUMO");
				b.HasIndex("IdEstado");
				b.ToTable("COMPONENTES_DETALLE", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Compras", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCompra").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_COMPRA");
				b.Property<int>("IdCompra").UseIdentityByDefaultColumn();
				b.Property<DateTime>("FechaHora").HasColumnType("timestamp").HasColumnName("FECHA_HORA");
				b.Property<int>("IdEstadoCompra").HasColumnType("int").HasColumnName("ID_ESTADO_COMPRA");
				b.Property<int>("IdProveedor").HasColumnType("int").HasColumnName("ID_PROVEEDOR");
				b.Property<string>("IdUsuario").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("ID_USUARIO");
				b.Property<decimal?>("SaldoPendiente").HasColumnType("decimal(18,2)").HasColumnName("SALDO_CANCELADO");
				b.Property<decimal>("MontoTotal").HasColumnType("decimal(18,2)").HasColumnName("SALDO_TOTAL");
				b.HasKey("IdCompra");
				b.HasIndex("IdEstadoCompra");
				b.HasIndex("IdProveedor");
				b.HasIndex("IdUsuario");
				b.ToTable("COMPRAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComprasDetalles", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCompra").HasColumnType("int").HasColumnName("ID_COMPRA");
				b.Property<string>("IdInsumo").HasColumnType("varchar(50)").HasColumnName("ID_INSUMO");
				b.Property<decimal>("Cantidad").HasColumnType("decimal(18,2)").HasColumnName("CANTIDAD");
				b.HasKey("IdCompra", "IdInsumo");
				b.HasIndex("IdInsumo");
				b.ToTable("COMPRAS_DETALLE", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.CuotasCompras", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCuota").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_CUOTA");
				b.Property<int>("IdCuota").UseIdentityByDefaultColumn();
				b.Property<DateTime?>("Fecha").HasColumnType("timestamp").HasColumnName("FECHA_PAGO");
				b.Property<DateTime>("FechaVencimiento").HasColumnType("timestamp").HasColumnName("FECHA_VENCIMIENTO");
				b.Property<int>("IdCompra").HasColumnType("int").HasColumnName("ID_COMPRA");
				b.Property<int>("IdEstadoCuota").HasColumnType("integer");
				b.Property<decimal>("Monto").HasColumnType("decimal(18,2)").HasColumnName("MONTO");
				b.Property<int>("NumeroCuota").HasColumnType("integer").HasColumnName("NUMERO_CUOTA");
				b.HasKey("IdCuota");
				b.HasIndex("IdCompra");
				b.HasIndex("IdEstadoCuota");
				b.ToTable("CUOTAS_COMPRAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.CuotasVentas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCuota").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_CUOTA");
				b.Property<int>("IdCuota").UseIdentityByDefaultColumn();
				b.Property<DateTime?>("Fecha").HasColumnType("timestamp").HasColumnName("FECHA_PAGO");
				b.Property<DateTime>("FechaVencimiento").HasColumnType("timestamp").HasColumnName("FECHA_VENCIMIENTO");
				b.Property<int>("IdEstadoCuota").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_CUOTA")
					.HasDefaultValueSql("1");
				b.Property<int>("IdVenta").HasColumnType("int").HasColumnName("ID_VENTA");
				b.Property<decimal>("Monto").ValueGeneratedOnAdd().HasColumnType("decimal(18,2)")
					.HasColumnName("MONTO")
					.HasDefaultValueSql("0.00");
				b.Property<int>("NumeroCuota").HasColumnType("int").HasColumnName("NUMERO_CUOTA");
				b.HasKey("IdCuota");
				b.HasIndex("IdEstadoCuota");
				b.HasIndex("IdVenta");
				b.ToTable("CUOTAS_VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Entidades", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEntidad").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ENTIDAD");
				b.Property<int>("IdEntidad").UseIdentityByDefaultColumn();
				b.Property<string>("Altura").HasColumnType("text").HasColumnName("ALTURA");
				b.Property<string>("Apellido").HasColumnType("text").HasColumnName("APELLIDO");
				b.Property<string>("Barrio").HasColumnType("text").HasColumnName("BARRIO");
				b.Property<string>("Calle").HasColumnType("text").HasColumnName("CALLE");
				b.Property<string>("Ciudad").HasColumnType("text").HasColumnName("CIUDAD");
				b.Property<string>("CodigoPostal").HasColumnType("text").HasColumnName("CODIGO_POSTAL");
				b.Property<string>("Email").HasColumnType("text").HasColumnName("EMAIL");
				b.Property<DateTime>("FechaRegistro").HasColumnType("timestamp").HasColumnName("FECHA_REGISTRO");
				b.Property<int>("IdCategoria").HasColumnType("int").HasColumnName("ID_CATEGORIA");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("(1)");
				b.Property<string>("IdFiscal").IsRequired().HasColumnType("text")
					.HasColumnName("ID_FISCAL");
				b.Property<int>("IdTipo").HasColumnType("int").HasColumnName("ID_TIPO");
				b.Property<string>("IdUsuarioRegistro").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("ID_USUARIO_REGISTRO");
				b.Property<string>("Localidad").HasColumnType("text").HasColumnName("LOCALIDAD");
				b.Property<string>("Nombre").HasColumnType("text").HasColumnName("NOMBRE");
				b.Property<string>("NombreClave").HasColumnType("text").HasColumnName("NOMBRE_CLAVE");
				b.Property<string>("Pais").HasColumnType("text").HasColumnName("PAIS");
				b.Property<string>("Provincia").HasColumnType("text").HasColumnName("PROVINCIA");
				b.Property<string>("Telefono1").HasColumnType("text").HasColumnName("TELEFONO_1");
				b.Property<string>("Telefono2").HasColumnType("text").HasColumnName("TELEFONO_2");
				b.Property<string>("Telefono3").HasColumnType("text").HasColumnName("TELEFONO_3");
				b.HasKey("IdEntidad");
				b.HasIndex("IdCategoria");
				b.HasIndex("IdTipo");
				b.HasIndex("IdUsuarioRegistro");
				b.ToTable("ENTIDADES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesCategorias", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCategoria").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_CATEGORIA");
				b.Property<int>("IdCategoria").UseIdentityByDefaultColumn();
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("NombreCategoria").IsRequired().HasColumnType("text")
					.HasColumnName("NOMBRE_CATEGORIA");
				b.HasKey("IdCategoria");
				b.ToTable("ENTIDADES_CATEGORIAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesTipos", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdTipo").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_TIPO");
				b.Property<int>("IdTipo").UseIdentityByDefaultColumn();
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("NombreTipo").IsRequired().HasColumnType("text")
					.HasColumnName("NOMBRE");
				b.HasKey("IdTipo");
				b.ToTable("ENTIDADES_TIPOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesTiposCategorias", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("idTipoEntidad").HasColumnType("int").HasColumnName("ID_TIPO");
				b.Property<int>("IdCategoriaEntidad").HasColumnType("int").HasColumnName("ID_CATEGORIA");
				b.HasKey("idTipoEntidad", "IdCategoriaEntidad");
				b.HasIndex("IdCategoriaEntidad");
				b.ToTable("ENTIDADES_TIPOS_CATEGORIAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosArchivosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_ARCHIVOS_MOVIMIENTOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosComponentesDetalles", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_COMPONENTES_DETALLES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCompras", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoCompra").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_COMPRA")
					.HasAnnotation("SqlServer:Identity", "1, 1");
				b.Property<int>("IdEstadoCompra").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").HasColumnType("int").HasColumnName("ID_ESTADO");
				b.HasKey("IdEstadoCompra");
				b.ToTable("ESTADOS_COMPRAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCuotasCompras", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoCuota").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO_CUOTA");
				b.Property<int>("IdEstadoCuota").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.HasKey("IdEstadoCuota");
				b.ToTable("ESTADOS_CUOTAS_COMPRAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCuotasVentas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoCuota").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_CUOTA");
				b.Property<int>("IdEstadoCuota").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.HasKey("IdEstadoCuota");
				b.ToTable("ESTADOS_CUOTAS_VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int?>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_MOVIMIENTO");
				b.Property<int?>("IdEstadoMovimiento").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.HasKey("IdEstadoMovimiento");
				b.ToTable("ESTADOS_MOVIMIENTOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductos", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_PRODUCTOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductosComponentes", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_PRODUCTOS_COMPONENTES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductosDescripciones", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_PRODUCTOS_DESCRIPCIONES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosSuministrosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_SUMINISTROS_MOVIMIENTOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosTiposProductos", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_PRODUCTOS_TIPOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosVentas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoVenta").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_VENTA");
				b.Property<int>("IdEstadoVenta").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("int")
					.HasDefaultValue(1)
					.HasColumnName("ID_ESTADO");
				b.HasKey("IdEstadoVenta");
				b.ToTable("ESTADOS_VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.MediosPago", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdMedioPago").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_MEDIO_PAGO");
				b.Property<int>("IdMedioPago").UseIdentityByDefaultColumn();
				b.Property<string>("CodigoMPago").HasColumnType("text").HasColumnName("CODIGO_MPAGO");
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("int")
					.HasDefaultValue(1)
					.HasColumnName("ID_ESTADO");
				b.HasKey("IdMedioPago");
				b.ToTable("MEDIOS_PAGO", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PagosCompras", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdPago").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_PAGO")
					.HasColumnOrder(2);
				b.Property<int>("IdPago").UseIdentityByDefaultColumn();
				b.Property<DateTime?>("Fecha").HasColumnType("timestamp").HasColumnName("FECHA");
				b.Property<int>("IdCompra").HasColumnType("int").HasColumnName("ID_COMPRA");
				b.Property<int>("IdMedioPago").HasColumnType("int").HasColumnName("ID_MEDIO_PAGO");
				b.Property<decimal>("Monto").HasColumnType("decimal(18,2)").HasColumnName("SUBTOTAL");
				b.HasKey("IdPago");
				b.HasIndex("IdCompra");
				b.HasIndex("IdMedioPago");
				b.ToTable("PAGOS_COMPRAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PagosVentas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdPago").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_PAGO")
					.HasColumnOrder(2);
				b.Property<int>("IdPago").UseIdentityByDefaultColumn();
				b.Property<DateTime?>("Fecha").HasColumnType("timestamp").HasColumnName("FECHA");
				b.Property<int>("IdMedioPago").HasColumnType("int").HasColumnName("ID_MEDIO_PAGO");
				b.Property<int>("IdVenta").HasColumnType("int").HasColumnName("ID_VENTA");
				b.Property<decimal>("Monto").HasColumnType("decimal(18,2)").HasColumnName("MONTO");
				b.HasKey("IdPago");
				b.HasIndex("IdMedioPago");
				b.HasIndex("IdVenta");
				b.ToTable("PAGOS_VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PerfilesUsuarios", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdPerfil").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_PERFIL");
				b.Property<int>("IdPerfil").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("varchar(100)")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").HasColumnType("integer").HasColumnName("ID_ESTADO");
				b.HasKey("IdPerfil");
				b.ToTable("USUARIOS_PERFILES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Producto", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdProducto").HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("ID_PRODUCTO");
				b.Property<int?>("Cantidad").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("CANTIDAD")
					.HasDefaultValueSql("((0))");
				b.Property<int?>("DiametroNominal").HasColumnType("integer").HasColumnName("DIAMETRO_NOMINAL");
				b.Property<int>("IdDescripcion").HasColumnType("integer").HasColumnName("ID_DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("IdTipo").IsRequired().HasMaxLength(50)
					.IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("ID_TIPO");
				b.Property<decimal?>("PorcentajeGanancia").HasColumnType("decimal(18,2)").HasColumnName("PORCENTAJE_GANANCIA");
				b.Property<decimal?>("PrecioFinal").HasColumnType("decimal(18,2)").HasColumnName("PRECIO_FINAL");
				b.Property<decimal?>("PrecioLista").ValueGeneratedOnAdd().HasColumnType("money")
					.HasColumnName("PRECIO_LISTA")
					.HasDefaultValueSql("((0))");
				b.Property<string>("Tolerancia").HasColumnType("text").HasColumnName("TOLERANCIA");
				b.HasKey("IdProducto");
				b.HasIndex("IdDescripcion");
				b.HasIndex("IdEstado");
				b.HasIndex("IdTipo");
				b.ToTable("PRODUCTOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosDescripcion", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdDescripcion").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_DESCRIPCION");
				b.Property<int>("IdDescripcion").UseIdentityByDefaultColumn();
				b.Property<string>("DescripcionProducto").HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.HasKey("IdDescripcion");
				b.HasIndex("IdEstado");
				b.ToTable("PRODUCTOS_DESCRIPCION", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosTipo", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdTipo").HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("ID_TIPO");
				b.Property<string>("DescripcionTipo").HasMaxLength(100).IsUnicode(unicode: false)
					.HasColumnType("character varying(100)")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.HasKey("IdTipo").HasName("PK_PRODUCTOS_TIPOS");
				b.HasIndex("IdEstado");
				b.ToTable("PRODUCTOS_TIPOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Productos_Componentes", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdProducto").HasColumnType("varchar(50)").HasColumnName("ID_PRODUCTO");
				b.Property<string>("IdComponente").HasColumnType("varchar(50)").HasColumnName("ID_COMPONENTE");
				b.Property<decimal?>("Cantidad").HasColumnType("decimal(18,2)").HasColumnName("CANTIDAD");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<decimal?>("Longitud").HasColumnType("decimal(18,2)").HasColumnName("LONGITUD");
				b.Property<decimal?>("Peso").HasColumnType("decimal(18,2)").HasColumnName("PESO");
				b.HasKey("IdProducto", "IdComponente").HasName("PK_PRODUCTOS_COMPONENTES");
				b.HasIndex("IdEstado");
				b.ToTable("PRODUCTOS_COMPONENTES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Productos_Tipos_Descripcion", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdTipo").HasColumnType("varchar(50)").HasColumnName("ID_TIPO");
				b.Property<int?>("IdDescripcion").HasColumnType("integer").HasColumnName("ID_DESCRIPCION");
				b.HasKey("IdTipo", "IdDescripcion");
				b.HasIndex("IdDescripcion");
				b.ToTable("PRODUCTOS_TIPOS_DESCRIPCION", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.StockInsumos", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdInsumo").HasColumnType("varchar(50)").HasColumnName("ID_INSUMO");
				b.Property<decimal?>("Granallado").HasColumnType("decimal").HasColumnName("GRANALLADO");
				b.Property<decimal?>("Moldeado").HasColumnType("decimal").HasColumnName("MOLDEADO");
				b.Property<decimal?>("Pendiente").HasColumnType("decimal(18,2)").HasColumnName("PENDIENTE");
				b.Property<decimal?>("Pintura").HasColumnType("decimal").HasColumnName("PINTURA");
				b.Property<decimal?>("Proceso").HasColumnType("decimal").HasColumnName("PROCESO");
				b.Property<decimal?>("Recibido").HasColumnType("decimal").HasColumnName("RECIBIDO");
				b.HasKey("IdInsumo").HasName("PK_STOCK_INSUMOS");
				b.ToTable("STOCK_INSUMOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Stock_Movimientos", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdMovimiento").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_MOVIMIENTO");
				b.Property<int>("IdMovimiento").UseIdentityByDefaultColumn();
				b.Property<string>("CreadoUsuario").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("USUARIO_CREADO");
				b.Property<string>("Destino").HasColumnType("varchar(50)").HasColumnName("DESTINO");
				b.Property<DateTime>("FechaHoraCreado").HasColumnType("timestamp").HasColumnName("FECHA_HORA_CREADO");
				b.Property<DateTime?>("FechaHoraUltimaModificacion").HasColumnType("timestamp").HasColumnName("FECHA_HORA_ULTIMA_MODIFICACION");
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_MOVIMIENTO")
					.HasDefaultValueSql("1");
				b.Property<int>("IdProveedor").HasColumnType("int").HasColumnName("ID_PROVEEDOR_DESTINO");
				b.Property<int>("IdProveedorOrigen").HasColumnType("int").HasColumnName("ID_PROVEEDOR_ORIGEN");
				b.Property<string>("ModificadoUsuario").HasColumnType("varchar(50)").HasColumnName("USUARIO_MODIFICA");
				b.Property<string>("Origen").HasColumnType("varchar(50)").HasColumnName("ORIGEN");
				b.Property<string>("Tipo").HasColumnType("varchar(15)").HasColumnName("TIPO");
				b.HasKey("IdMovimiento");
				b.HasIndex("IdEstadoMovimiento");
				b.HasIndex("IdProveedor");
				b.HasIndex("IdProveedorOrigen");
				b.ToTable("STOCK_MOVIMIENTOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.SuministrosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdMovimiento").HasColumnType("int").HasColumnName("ID_MOVIMIENTO");
				b.Property<string>("IdSuministro").HasColumnType("varchar(50)").HasColumnName("ID_SUMINISTRO");
				b.Property<decimal>("Cantidad").HasColumnType("decimal(18,2)").HasColumnName("CANTIDAD");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.HasKey("IdMovimiento", "IdSuministro");
				b.HasIndex("IdEstado");
				b.ToTable("SUMINISTROS_MOVIMIENTOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Usuarios", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("Usuario").HasColumnType("varchar(50)").HasColumnName("USUARIO");
				b.Property<string>("Contraseña").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("CONTRASEÑA");
				b.Property<string>("Correo").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("CORREO");
				b.Property<int>("IdPerfil").HasColumnType("int").HasColumnName("ID_PERFIL");
				b.HasKey("Usuario");
				b.HasIndex("IdPerfil");
				b.ToTable("USUARIOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Ventas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdVenta").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_VENTA");
				b.Property<int>("IdVenta").UseIdentityByDefaultColumn();
				b.Property<DateTime>("FechaHora").HasColumnType("timestamp").HasColumnName("FECHA_HORA");
				b.Property<int>("IdCliente").HasColumnType("int").HasColumnName("ID_CLIENTE");
				b.Property<int>("IdEstadoVenta").HasColumnType("int").HasColumnName("ID_ESTADO_VENTA");
				b.Property<string>("IdUsuario").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("ID_USUARIO");
				b.Property<decimal>("SaldoPendiente").HasColumnType("numeric").HasColumnName("SALDO_PENDIENTE");
				b.Property<decimal>("MontoTotal").HasColumnType("decimal(18,2)").HasColumnName("TOTAL");
				b.HasKey("IdVenta");
				b.HasIndex("IdCliente");
				b.HasIndex("IdEstadoVenta");
				b.HasIndex("IdUsuario");
				b.ToTable("VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.VentasDetalles", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdVenta").HasColumnType("int").HasColumnName("ID_VENTA");
				b.Property<string>("IdProducto").HasColumnType("varchar(50)").HasColumnName("ID_PRODUCTO");
				b.Property<decimal>("Cantidad").HasColumnType("decimal(18,2)").HasColumnName("CANTIDAD");
				b.Property<int?>("Entregados").HasColumnType("integer").HasColumnName("ENTREGADOS");
				b.Property<decimal>("Precio").HasColumnType("decimal(18,2)").HasColumnName("PRECIO");
				b.HasKey("IdVenta", "IdProducto");
				b.HasIndex("IdProducto");
				b.ToTable("VENTAS_DETALLES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ArchivosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosArchivosMovimientosStock", "ArchivosMovimientosStockNavigation").WithMany("ArchivosMovimientoStock").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Stock_Movimientos", "StockMovimiento").WithMany().HasForeignKey("IdMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_ARCHIVOS_STOCK_STOCK_MOVIMIENTOS_ID_MOVIMIENTO");
				b.Navigation("ArchivosMovimientosStockNavigation");
				b.Navigation("StockMovimiento");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComponentesDetalle", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosComponentesDetalles", "IdEstadoNavigation").WithMany("ComponentesDetalle").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdEstadoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Compras", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosCompras", "Estado").WithMany("compras").HasForeignKey("IdEstadoCompra")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_COMPRAS_ESTADOS_COMPRAS_ID_ESTADO_COMPRA");
				b.HasOne("Aponus_Web_API.Modelos.Entidades", "IdProveedor").WithMany("compras").HasForeignKey("IdProveedor")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Usuarios", "Usuario").WithMany("Compras").HasForeignKey("IdUsuario")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired()
					.HasConstraintName("FK_COMPRAS_USUARIOS_IDUSUARIO");
				b.Navigation("Estado");
				b.Navigation("IdProveedor");
				b.Navigation("Usuario");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComprasDetalles", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Compras", "Compra").WithMany("DetallesCompra").HasForeignKey("IdCompra")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.ComponentesDetalle", "DetallesInsumo").WithMany("ComprasNavigation").HasForeignKey("IdInsumo")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("Compra");
				b.Navigation("DetallesInsumo");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.CuotasCompras", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Compras", "CompraNavigation").WithMany("CuotasCompra").HasForeignKey("IdCompra")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_CUOTAS_COMPRAS_COMPRAS_ID_COMPRA");
				b.HasOne("Aponus_Web_API.Modelos.EstadosCuotasCompras", "EstadoCuotaCompra").WithMany("IdEstadoCuotaNavigation").HasForeignKey("IdEstadoCuota")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_CUOTAS_COMPRAS_ESTADOS_CUOTAS_COMPRAS_ID_ESTADO_CUOTA");
				b.Navigation("CompraNavigation");
				b.Navigation("EstadoCuotaCompra");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.CuotasVentas", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosCuotasVentas", "EstadoCuota").WithMany("IdEstadoCuotaNavigation").HasForeignKey("IdEstadoCuota")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Ventas", "Venta").WithMany("Cuotas").HasForeignKey("IdVenta")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("EstadoCuota");
				b.Navigation("Venta");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Entidades", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EntidadesCategorias", "CategoriaEntidad").WithMany("Entidades").HasForeignKey("IdCategoria")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.EntidadesTipos", "TipoEntidad").WithMany("Entidades").HasForeignKey("IdTipo")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Usuarios", "UsuarioRegistro").WithMany("IdUsuarioRegistroNavigation").HasForeignKey("IdUsuarioRegistro")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("CategoriaEntidad");
				b.Navigation("TipoEntidad");
				b.Navigation("UsuarioRegistro");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesTiposCategorias", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EntidadesCategorias", "CategoriaEntidad").WithMany("TiposCategoriasNavigation").HasForeignKey("IdCategoriaEntidad")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.EntidadesTipos", "TipoEntidad").WithMany("TiposCategoriasNavigation").HasForeignKey("idTipoEntidad")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("CategoriaEntidad");
				b.Navigation("TipoEntidad");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PagosCompras", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Compras", "Compra").WithMany("Pagos").HasForeignKey("IdCompra")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.MediosPago", "MedioPago").WithMany("PagosComprasNavigation").HasForeignKey("IdMedioPago")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("Compra");
				b.Navigation("MedioPago");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PagosVentas", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.MediosPago", "MedioPago").WithMany("PagosVentasNavigation").HasForeignKey("IdMedioPago")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Ventas", "Venta").WithMany("Pagos").HasForeignKey("IdVenta")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("MedioPago");
				b.Navigation("Venta");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Producto", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.ProductosDescripcion", "IdDescripcionNavigation").WithMany("Productos").HasForeignKey("IdDescripcion")
					.IsRequired()
					.HasConstraintName("FK_PRODUCTOS_PRODUCTOS_DESCRIPCION");
				b.HasOne("Aponus_Web_API.Modelos.EstadosProductos", "IdEstadoNavigation").WithMany("Productos").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.ProductosTipo", "IdTipoNavigation").WithMany("Productos").HasForeignKey("IdTipo")
					.IsRequired()
					.HasConstraintName("FK_PRODUCTOS_PRODUCTOS_TIPOS");
				b.Navigation("IdDescripcionNavigation");
				b.Navigation("IdEstadoNavigation");
				b.Navigation("IdTipoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosDescripcion", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosProductosDescripciones", "IdEstadoNavigation").WithMany("ProductosDescripcions").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdEstadoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosTipo", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosTiposProductos", "IdEstadoNavigation").WithMany("ProductosTipos").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdEstadoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Productos_Componentes", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosProductosComponentes", "IdEstadoNavigation").WithMany("ProductosComponentes").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdEstadoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Productos_Tipos_Descripcion", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.ProductosDescripcion", "IdDescripcionNavigation").WithMany("Producto_Tipo_Descripcione").HasForeignKey("IdDescripcion")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired()
					.HasConstraintName("FK_PRODUCTOS_TIPOS_DESCRIPCION_ID_DESCRIPCION");
				b.HasOne("Aponus_Web_API.Modelos.ProductosTipo", "IdTipoNavigation").WithMany("Producto_Tipo_Descripcione").HasForeignKey("IdTipo")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired()
					.HasConstraintName("FK_PRODUCTOS_TIPOS_DESCRIPCION_ID_TIPO");
				b.Navigation("IdDescripcionNavigation");
				b.Navigation("IdTipoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Stock_Movimientos", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosMovimientosStock", "estadoMovimiento").WithMany("movimientosStock").HasForeignKey("IdEstadoMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Entidades", "Proveeedor").WithMany("Movimientos").HasForeignKey("IdProveedor")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_STOCK_MOVIMIENTOS_ENTIDADES_ID_PROVEEDOR_DESTINO");
				b.HasOne("Aponus_Web_API.Modelos.Entidades", "ProveedorOrigen").WithMany("MovimientosOrigen").HasForeignKey("IdProveedorOrigen")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_STOCK_MOVIMIENTOS_ENTIDADES_ID_PROVEEDOR_ORIGEN");
				b.Navigation("Proveeedor");
				b.Navigation("ProveedorOrigen");
				b.Navigation("estadoMovimiento");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.SuministrosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosSuministrosMovimientosStock", "EstadosSuministrosMovimientosStockNavigation").WithMany("SuministrosMovimientoStock").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_SUMINISTROS_MOVIMIENTOS_STOCK_ESTADOS_SUMINISTROS_MOVIMIENTO");
				b.HasOne("Aponus_Web_API.Modelos.Stock_Movimientos", null).WithMany("Suministros").HasForeignKey("IdMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("EstadosSuministrosMovimientosStockNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Usuarios", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.PerfilesUsuarios", "Perfil").WithMany("UsuariosNavigation").HasForeignKey("IdPerfil")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_USUARIOS_PERFILES_USUARIOS_ID_PERFIL");
				b.Navigation("Perfil");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Ventas", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Entidades", "Cliente").WithMany("ventas").HasForeignKey("IdCliente")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.EstadosVentas", "Estado").WithMany("ventas").HasForeignKey("IdEstadoVenta")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Usuarios", "Usuario").WithMany("Ventas").HasForeignKey("IdUsuario")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired();
				b.Navigation("Cliente");
				b.Navigation("Estado");
				b.Navigation("Usuario");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.VentasDetalles", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Producto", "IdProductoNavigation").WithMany("Ventas").HasForeignKey("IdProducto")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_VENTAS_DETALLES_PRODUCTOS_ID_PRODUCTO");
				b.HasOne("Aponus_Web_API.Modelos.Ventas", "Venta").WithMany("DetallesVenta").HasForeignKey("IdVenta")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdProductoNavigation");
				b.Navigation("Venta");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComponentesDetalle", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ComprasNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Compras", delegate(EntityTypeBuilder b)
			{
				b.Navigation("CuotasCompra");
				b.Navigation("DetallesCompra");
				b.Navigation("Pagos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Entidades", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Movimientos");
				b.Navigation("MovimientosOrigen");
				b.Navigation("compras");
				b.Navigation("ventas");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesCategorias", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Entidades");
				b.Navigation("TiposCategoriasNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesTipos", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Entidades");
				b.Navigation("TiposCategoriasNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosArchivosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ArchivosMovimientoStock");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosComponentesDetalles", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ComponentesDetalle");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCompras", delegate(EntityTypeBuilder b)
			{
				b.Navigation("compras");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCuotasCompras", delegate(EntityTypeBuilder b)
			{
				b.Navigation("IdEstadoCuotaNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCuotasVentas", delegate(EntityTypeBuilder b)
			{
				b.Navigation("IdEstadoCuotaNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Navigation("movimientosStock");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductos", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Productos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductosComponentes", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ProductosComponentes");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductosDescripciones", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ProductosDescripcions");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosSuministrosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Navigation("SuministrosMovimientoStock");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosTiposProductos", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ProductosTipos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosVentas", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ventas");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.MediosPago", delegate(EntityTypeBuilder b)
			{
				b.Navigation("PagosComprasNavigation");
				b.Navigation("PagosVentasNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PerfilesUsuarios", delegate(EntityTypeBuilder b)
			{
				b.Navigation("UsuariosNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Producto", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Ventas");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosDescripcion", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Producto_Tipo_Descripcione");
				b.Navigation("Productos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosTipo", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Producto_Tipo_Descripcione");
				b.Navigation("Productos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Stock_Movimientos", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Suministros");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Usuarios", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Compras");
				b.Navigation("IdUsuarioRegistroNavigation");
				b.Navigation("Ventas");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Ventas", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Cuotas");
				b.Navigation("DetallesVenta");
				b.Navigation("Pagos");
			});
		}
	}
	[DbContext(typeof(AponusContext))]
	[Migration("20241028045720_Correcciones en PagosCompras_2")]
	public class CorreccionesenPagosCompras2 : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.RenameColumn("TOTAL", "VENTAS", "MONTO_TOTAL");
			migrationBuilder.RenameColumn("SALDO_TOTAL", "COMPRAS", "MONTO_TOTAL");
			migrationBuilder.RenameColumn("SALDO_CANCELADO", "COMPRAS", "SALDO_PENDIENTE");
			Type typeFromHandle = typeof(decimal);
			migrationBuilder.AlterColumn<decimal>("SALDO_PENDIENTE", "VENTAS", "numeric", null, null, rowVersion: false, null, nullable: true, null, null, null, typeFromHandle, "numeric");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.RenameColumn("MONTO_TOTAL", "VENTAS", "TOTAL");
			migrationBuilder.RenameColumn("SALDO_PENDIENTE", "COMPRAS", "SALDO_CANCELADO");
			migrationBuilder.RenameColumn("MONTO_TOTAL", "COMPRAS", "SALDO_TOTAL");
			migrationBuilder.AlterColumn<decimal>("SALDO_PENDIENTE", "VENTAS", "numeric", oldClrType: typeof(decimal), unicode: null, maxLength: null, rowVersion: false, schema: null, nullable: false, defaultValue: 0m, defaultValueSql: null, computedColumnSql: null, oldType: "numeric", oldUnicode: null, oldMaxLength: null, oldRowVersion: false, oldNullable: true);
		}

		protected override void BuildTargetModel(ModelBuilder modelBuilder)
		{
			modelBuilder.UseCollation("Modern_Spanish_CI_AI").HasAnnotation("ProductVersion", "7.0.11").HasAnnotation("Relational:MaxIdentifierLength", 63);
			modelBuilder.UseIdentityByDefaultColumns();
			modelBuilder.Entity("Aponus_Web_API.Modelos.ArchivosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdMovimiento").HasColumnType("int").HasColumnName("ID_MOVIMIENTO");
				b.Property<string>("HashArchivo").HasColumnType("varchar(255)").HasColumnName("HASH_ARCHIVO");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("MimeType").HasColumnType("text").HasColumnName("MIME_TYPE");
				b.Property<string>("PathArchivo").IsRequired().HasColumnType("text")
					.HasColumnName("PATH");
				b.HasKey("IdMovimiento", "HashArchivo");
				b.HasIndex("IdEstado");
				b.ToTable("ARCHIVOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComponentesDescripcion", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdDescripcion").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_DESCRIPCION");
				b.Property<int>("IdDescripcion").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("DESCRIPCION");
				b.Property<string>("IdAlmacenamiento").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("ID_ALMACENAMIENTO");
				b.Property<string>("IdFraccionamiento").HasColumnType("varchar(50)").HasColumnName("ID_FRACCIONAMIENTO");
				b.HasKey("IdDescripcion");
				b.ToTable("COMPONENTES_DESCRIPCION", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComponentesDetalle", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdInsumo").HasColumnType("varchar(50)").HasColumnName("ID_INSUMO");
				b.Property<decimal?>("Altura").HasColumnType("decimal(18,2)").HasColumnName("ALTURA");
				b.Property<decimal?>("Diametro").HasColumnType("decimal(18,2)").HasColumnName("DIAMETRO");
				b.Property<int?>("DiametroNominal").HasColumnType("int").HasColumnName("DIAMETRO_NOMINAL");
				b.Property<decimal?>("Espesor").HasColumnType("decimal(18,2)").HasColumnName("ESPESOR");
				b.Property<string>("IdAlmacenamiento").HasColumnType("varchar(50)").HasColumnName("ID_ALMACENAMIENTO");
				b.Property<int>("IdDescripcion").HasColumnType("integer").HasColumnName("ID_DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("IdFraccionamiento").HasColumnType("varchar(50)").HasColumnName("ID_FRACCIONAMIENTO");
				b.Property<decimal?>("Longitud").HasColumnType("decimal(18,2)").HasColumnName("LONGITUD");
				b.Property<int?>("Perfil").HasColumnType("integer").HasColumnName("PERFIL");
				b.Property<decimal?>("Peso").HasColumnType("decimal(18,3)").HasColumnName("PESO");
				b.Property<string>("Tolerancia").HasColumnType("varchar(50)").HasColumnName("TOLERANCIA");
				b.HasKey("IdInsumo").HasName("PK_ID_INSUMO");
				b.HasIndex("IdEstado");
				b.ToTable("COMPONENTES_DETALLE", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Compras", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCompra").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_COMPRA");
				b.Property<int>("IdCompra").UseIdentityByDefaultColumn();
				b.Property<DateTime>("FechaHora").HasColumnType("timestamp").HasColumnName("FECHA_HORA");
				b.Property<int>("IdEstadoCompra").HasColumnType("int").HasColumnName("ID_ESTADO_COMPRA");
				b.Property<int>("IdProveedor").HasColumnType("int").HasColumnName("ID_PROVEEDOR");
				b.Property<string>("IdUsuario").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("ID_USUARIO");
				b.Property<decimal>("MontoTotal").HasColumnType("decimal(18,2)").HasColumnName("MONTO_TOTAL");
				b.Property<decimal?>("SaldoPendiente").HasColumnType("decimal(18,2)").HasColumnName("SALDO_PENDIENTE");
				b.HasKey("IdCompra");
				b.HasIndex("IdEstadoCompra");
				b.HasIndex("IdProveedor");
				b.HasIndex("IdUsuario");
				b.ToTable("COMPRAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComprasDetalles", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCompra").HasColumnType("int").HasColumnName("ID_COMPRA");
				b.Property<string>("IdInsumo").HasColumnType("varchar(50)").HasColumnName("ID_INSUMO");
				b.Property<decimal>("Cantidad").HasColumnType("decimal(18,2)").HasColumnName("CANTIDAD");
				b.HasKey("IdCompra", "IdInsumo");
				b.HasIndex("IdInsumo");
				b.ToTable("COMPRAS_DETALLE", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.CuotasCompras", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCuota").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_CUOTA");
				b.Property<int>("IdCuota").UseIdentityByDefaultColumn();
				b.Property<DateTime?>("Fecha").HasColumnType("timestamp").HasColumnName("FECHA_PAGO");
				b.Property<DateTime>("FechaVencimiento").HasColumnType("timestamp").HasColumnName("FECHA_VENCIMIENTO");
				b.Property<int>("IdCompra").HasColumnType("int").HasColumnName("ID_COMPRA");
				b.Property<int>("IdEstadoCuota").HasColumnType("integer");
				b.Property<decimal>("Monto").HasColumnType("decimal(18,2)").HasColumnName("MONTO");
				b.Property<int>("NumeroCuota").HasColumnType("integer").HasColumnName("NUMERO_CUOTA");
				b.HasKey("IdCuota");
				b.HasIndex("IdCompra");
				b.HasIndex("IdEstadoCuota");
				b.ToTable("CUOTAS_COMPRAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.CuotasVentas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCuota").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_CUOTA");
				b.Property<int>("IdCuota").UseIdentityByDefaultColumn();
				b.Property<DateTime?>("Fecha").HasColumnType("timestamp").HasColumnName("FECHA_PAGO");
				b.Property<DateTime>("FechaVencimiento").HasColumnType("timestamp").HasColumnName("FECHA_VENCIMIENTO");
				b.Property<int>("IdEstadoCuota").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_CUOTA")
					.HasDefaultValueSql("1");
				b.Property<int>("IdVenta").HasColumnType("int").HasColumnName("ID_VENTA");
				b.Property<decimal>("Monto").ValueGeneratedOnAdd().HasColumnType("decimal(18,2)")
					.HasColumnName("MONTO")
					.HasDefaultValueSql("0.00");
				b.Property<int>("NumeroCuota").HasColumnType("int").HasColumnName("NUMERO_CUOTA");
				b.HasKey("IdCuota");
				b.HasIndex("IdEstadoCuota");
				b.HasIndex("IdVenta");
				b.ToTable("CUOTAS_VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Entidades", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEntidad").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ENTIDAD");
				b.Property<int>("IdEntidad").UseIdentityByDefaultColumn();
				b.Property<string>("Altura").HasColumnType("text").HasColumnName("ALTURA");
				b.Property<string>("Apellido").HasColumnType("text").HasColumnName("APELLIDO");
				b.Property<string>("Barrio").HasColumnType("text").HasColumnName("BARRIO");
				b.Property<string>("Calle").HasColumnType("text").HasColumnName("CALLE");
				b.Property<string>("Ciudad").HasColumnType("text").HasColumnName("CIUDAD");
				b.Property<string>("CodigoPostal").HasColumnType("text").HasColumnName("CODIGO_POSTAL");
				b.Property<string>("Email").HasColumnType("text").HasColumnName("EMAIL");
				b.Property<DateTime>("FechaRegistro").HasColumnType("timestamp").HasColumnName("FECHA_REGISTRO");
				b.Property<int>("IdCategoria").HasColumnType("int").HasColumnName("ID_CATEGORIA");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("(1)");
				b.Property<string>("IdFiscal").IsRequired().HasColumnType("text")
					.HasColumnName("ID_FISCAL");
				b.Property<int>("IdTipo").HasColumnType("int").HasColumnName("ID_TIPO");
				b.Property<string>("IdUsuarioRegistro").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("ID_USUARIO_REGISTRO");
				b.Property<string>("Localidad").HasColumnType("text").HasColumnName("LOCALIDAD");
				b.Property<string>("Nombre").HasColumnType("text").HasColumnName("NOMBRE");
				b.Property<string>("NombreClave").HasColumnType("text").HasColumnName("NOMBRE_CLAVE");
				b.Property<string>("Pais").HasColumnType("text").HasColumnName("PAIS");
				b.Property<string>("Provincia").HasColumnType("text").HasColumnName("PROVINCIA");
				b.Property<string>("Telefono1").HasColumnType("text").HasColumnName("TELEFONO_1");
				b.Property<string>("Telefono2").HasColumnType("text").HasColumnName("TELEFONO_2");
				b.Property<string>("Telefono3").HasColumnType("text").HasColumnName("TELEFONO_3");
				b.HasKey("IdEntidad");
				b.HasIndex("IdCategoria");
				b.HasIndex("IdTipo");
				b.HasIndex("IdUsuarioRegistro");
				b.ToTable("ENTIDADES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesCategorias", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCategoria").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_CATEGORIA");
				b.Property<int>("IdCategoria").UseIdentityByDefaultColumn();
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("NombreCategoria").IsRequired().HasColumnType("text")
					.HasColumnName("NOMBRE_CATEGORIA");
				b.HasKey("IdCategoria");
				b.ToTable("ENTIDADES_CATEGORIAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesTipos", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdTipo").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_TIPO");
				b.Property<int>("IdTipo").UseIdentityByDefaultColumn();
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("NombreTipo").IsRequired().HasColumnType("text")
					.HasColumnName("NOMBRE");
				b.HasKey("IdTipo");
				b.ToTable("ENTIDADES_TIPOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesTiposCategorias", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("idTipoEntidad").HasColumnType("int").HasColumnName("ID_TIPO");
				b.Property<int>("IdCategoriaEntidad").HasColumnType("int").HasColumnName("ID_CATEGORIA");
				b.HasKey("idTipoEntidad", "IdCategoriaEntidad");
				b.HasIndex("IdCategoriaEntidad");
				b.ToTable("ENTIDADES_TIPOS_CATEGORIAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosArchivosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_ARCHIVOS_MOVIMIENTOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosComponentesDetalles", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_COMPONENTES_DETALLES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCompras", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoCompra").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_COMPRA")
					.HasAnnotation("SqlServer:Identity", "1, 1");
				b.Property<int>("IdEstadoCompra").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").HasColumnType("int").HasColumnName("ID_ESTADO");
				b.HasKey("IdEstadoCompra");
				b.ToTable("ESTADOS_COMPRAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCuotasCompras", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoCuota").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO_CUOTA");
				b.Property<int>("IdEstadoCuota").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.HasKey("IdEstadoCuota");
				b.ToTable("ESTADOS_CUOTAS_COMPRAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCuotasVentas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoCuota").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_CUOTA");
				b.Property<int>("IdEstadoCuota").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.HasKey("IdEstadoCuota");
				b.ToTable("ESTADOS_CUOTAS_VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int?>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_MOVIMIENTO");
				b.Property<int?>("IdEstadoMovimiento").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.HasKey("IdEstadoMovimiento");
				b.ToTable("ESTADOS_MOVIMIENTOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductos", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_PRODUCTOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductosComponentes", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_PRODUCTOS_COMPONENTES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductosDescripciones", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_PRODUCTOS_DESCRIPCIONES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosSuministrosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_SUMINISTROS_MOVIMIENTOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosTiposProductos", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_PRODUCTOS_TIPOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosVentas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoVenta").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_VENTA");
				b.Property<int>("IdEstadoVenta").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("int")
					.HasDefaultValue(1)
					.HasColumnName("ID_ESTADO");
				b.HasKey("IdEstadoVenta");
				b.ToTable("ESTADOS_VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.MediosPago", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdMedioPago").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_MEDIO_PAGO");
				b.Property<int>("IdMedioPago").UseIdentityByDefaultColumn();
				b.Property<string>("CodigoMPago").HasColumnType("text").HasColumnName("CODIGO_MPAGO");
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("int")
					.HasDefaultValue(1)
					.HasColumnName("ID_ESTADO");
				b.HasKey("IdMedioPago");
				b.ToTable("MEDIOS_PAGO", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PagosCompras", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdPago").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_PAGO")
					.HasColumnOrder(2);
				b.Property<int>("IdPago").UseIdentityByDefaultColumn();
				b.Property<DateTime?>("Fecha").HasColumnType("timestamp").HasColumnName("FECHA");
				b.Property<int>("IdCompra").HasColumnType("int").HasColumnName("ID_COMPRA");
				b.Property<int>("IdMedioPago").HasColumnType("int").HasColumnName("ID_MEDIO_PAGO");
				b.Property<decimal>("Monto").HasColumnType("decimal(18,2)").HasColumnName("SUBTOTAL");
				b.HasKey("IdPago");
				b.HasIndex("IdCompra");
				b.HasIndex("IdMedioPago");
				b.ToTable("PAGOS_COMPRAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PagosVentas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdPago").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_PAGO")
					.HasColumnOrder(2);
				b.Property<int>("IdPago").UseIdentityByDefaultColumn();
				b.Property<DateTime?>("Fecha").HasColumnType("timestamp").HasColumnName("FECHA");
				b.Property<int>("IdMedioPago").HasColumnType("int").HasColumnName("ID_MEDIO_PAGO");
				b.Property<int>("IdVenta").HasColumnType("int").HasColumnName("ID_VENTA");
				b.Property<decimal>("Monto").HasColumnType("decimal(18,2)").HasColumnName("MONTO");
				b.HasKey("IdPago");
				b.HasIndex("IdMedioPago");
				b.HasIndex("IdVenta");
				b.ToTable("PAGOS_VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PerfilesUsuarios", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdPerfil").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_PERFIL");
				b.Property<int>("IdPerfil").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("varchar(100)")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").HasColumnType("integer").HasColumnName("ID_ESTADO");
				b.HasKey("IdPerfil");
				b.ToTable("USUARIOS_PERFILES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Producto", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdProducto").HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("ID_PRODUCTO");
				b.Property<int?>("Cantidad").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("CANTIDAD")
					.HasDefaultValueSql("((0))");
				b.Property<int?>("DiametroNominal").HasColumnType("integer").HasColumnName("DIAMETRO_NOMINAL");
				b.Property<int>("IdDescripcion").HasColumnType("integer").HasColumnName("ID_DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("IdTipo").IsRequired().HasMaxLength(50)
					.IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("ID_TIPO");
				b.Property<decimal?>("PorcentajeGanancia").HasColumnType("decimal(18,2)").HasColumnName("PORCENTAJE_GANANCIA");
				b.Property<decimal?>("PrecioFinal").HasColumnType("decimal(18,2)").HasColumnName("PRECIO_FINAL");
				b.Property<decimal?>("PrecioLista").ValueGeneratedOnAdd().HasColumnType("money")
					.HasColumnName("PRECIO_LISTA")
					.HasDefaultValueSql("((0))");
				b.Property<string>("Tolerancia").HasColumnType("text").HasColumnName("TOLERANCIA");
				b.HasKey("IdProducto");
				b.HasIndex("IdDescripcion");
				b.HasIndex("IdEstado");
				b.HasIndex("IdTipo");
				b.ToTable("PRODUCTOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosDescripcion", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdDescripcion").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_DESCRIPCION");
				b.Property<int>("IdDescripcion").UseIdentityByDefaultColumn();
				b.Property<string>("DescripcionProducto").HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.HasKey("IdDescripcion");
				b.HasIndex("IdEstado");
				b.ToTable("PRODUCTOS_DESCRIPCION", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosTipo", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdTipo").HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("ID_TIPO");
				b.Property<string>("DescripcionTipo").HasMaxLength(100).IsUnicode(unicode: false)
					.HasColumnType("character varying(100)")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.HasKey("IdTipo").HasName("PK_PRODUCTOS_TIPOS");
				b.HasIndex("IdEstado");
				b.ToTable("PRODUCTOS_TIPOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Productos_Componentes", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdProducto").HasColumnType("varchar(50)").HasColumnName("ID_PRODUCTO");
				b.Property<string>("IdComponente").HasColumnType("varchar(50)").HasColumnName("ID_COMPONENTE");
				b.Property<decimal?>("Cantidad").HasColumnType("decimal(18,2)").HasColumnName("CANTIDAD");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<decimal?>("Longitud").HasColumnType("decimal(18,2)").HasColumnName("LONGITUD");
				b.Property<decimal?>("Peso").HasColumnType("decimal(18,2)").HasColumnName("PESO");
				b.HasKey("IdProducto", "IdComponente").HasName("PK_PRODUCTOS_COMPONENTES");
				b.HasIndex("IdEstado");
				b.ToTable("PRODUCTOS_COMPONENTES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Productos_Tipos_Descripcion", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdTipo").HasColumnType("varchar(50)").HasColumnName("ID_TIPO");
				b.Property<int?>("IdDescripcion").HasColumnType("integer").HasColumnName("ID_DESCRIPCION");
				b.HasKey("IdTipo", "IdDescripcion");
				b.HasIndex("IdDescripcion");
				b.ToTable("PRODUCTOS_TIPOS_DESCRIPCION", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.StockInsumos", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdInsumo").HasColumnType("varchar(50)").HasColumnName("ID_INSUMO");
				b.Property<decimal?>("Granallado").HasColumnType("decimal").HasColumnName("GRANALLADO");
				b.Property<decimal?>("Moldeado").HasColumnType("decimal").HasColumnName("MOLDEADO");
				b.Property<decimal?>("Pendiente").HasColumnType("decimal(18,2)").HasColumnName("PENDIENTE");
				b.Property<decimal?>("Pintura").HasColumnType("decimal").HasColumnName("PINTURA");
				b.Property<decimal?>("Proceso").HasColumnType("decimal").HasColumnName("PROCESO");
				b.Property<decimal?>("Recibido").HasColumnType("decimal").HasColumnName("RECIBIDO");
				b.HasKey("IdInsumo").HasName("PK_STOCK_INSUMOS");
				b.ToTable("STOCK_INSUMOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Stock_Movimientos", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdMovimiento").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_MOVIMIENTO");
				b.Property<int>("IdMovimiento").UseIdentityByDefaultColumn();
				b.Property<string>("CreadoUsuario").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("USUARIO_CREADO");
				b.Property<string>("Destino").HasColumnType("varchar(50)").HasColumnName("DESTINO");
				b.Property<DateTime>("FechaHoraCreado").HasColumnType("timestamp").HasColumnName("FECHA_HORA_CREADO");
				b.Property<DateTime?>("FechaHoraUltimaModificacion").HasColumnType("timestamp").HasColumnName("FECHA_HORA_ULTIMA_MODIFICACION");
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_MOVIMIENTO")
					.HasDefaultValueSql("1");
				b.Property<int>("IdProveedor").HasColumnType("int").HasColumnName("ID_PROVEEDOR_DESTINO");
				b.Property<int>("IdProveedorOrigen").HasColumnType("int").HasColumnName("ID_PROVEEDOR_ORIGEN");
				b.Property<string>("ModificadoUsuario").HasColumnType("varchar(50)").HasColumnName("USUARIO_MODIFICA");
				b.Property<string>("Origen").HasColumnType("varchar(50)").HasColumnName("ORIGEN");
				b.Property<string>("Tipo").HasColumnType("varchar(15)").HasColumnName("TIPO");
				b.HasKey("IdMovimiento");
				b.HasIndex("IdEstadoMovimiento");
				b.HasIndex("IdProveedor");
				b.HasIndex("IdProveedorOrigen");
				b.ToTable("STOCK_MOVIMIENTOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.SuministrosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdMovimiento").HasColumnType("int").HasColumnName("ID_MOVIMIENTO");
				b.Property<string>("IdSuministro").HasColumnType("varchar(50)").HasColumnName("ID_SUMINISTRO");
				b.Property<decimal>("Cantidad").HasColumnType("decimal(18,2)").HasColumnName("CANTIDAD");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.HasKey("IdMovimiento", "IdSuministro");
				b.HasIndex("IdEstado");
				b.ToTable("SUMINISTROS_MOVIMIENTOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Usuarios", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("Usuario").HasColumnType("varchar(50)").HasColumnName("USUARIO");
				b.Property<string>("Contraseña").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("CONTRASEÑA");
				b.Property<string>("Correo").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("CORREO");
				b.Property<int>("IdPerfil").HasColumnType("int").HasColumnName("ID_PERFIL");
				b.HasKey("Usuario");
				b.HasIndex("IdPerfil");
				b.ToTable("USUARIOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Ventas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdVenta").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_VENTA");
				b.Property<int>("IdVenta").UseIdentityByDefaultColumn();
				b.Property<DateTime>("FechaHora").HasColumnType("timestamp").HasColumnName("FECHA_HORA");
				b.Property<int>("IdCliente").HasColumnType("int").HasColumnName("ID_CLIENTE");
				b.Property<int>("IdEstadoVenta").HasColumnType("int").HasColumnName("ID_ESTADO_VENTA");
				b.Property<string>("IdUsuario").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("ID_USUARIO");
				b.Property<decimal>("MontoTotal").HasColumnType("decimal(18,2)").HasColumnName("MONTO_TOTAL");
				b.Property<decimal?>("SaldoPendiente").HasColumnType("numeric").HasColumnName("SALDO_PENDIENTE");
				b.HasKey("IdVenta");
				b.HasIndex("IdCliente");
				b.HasIndex("IdEstadoVenta");
				b.HasIndex("IdUsuario");
				b.ToTable("VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.VentasDetalles", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdVenta").HasColumnType("int").HasColumnName("ID_VENTA");
				b.Property<string>("IdProducto").HasColumnType("varchar(50)").HasColumnName("ID_PRODUCTO");
				b.Property<decimal>("Cantidad").HasColumnType("decimal(18,2)").HasColumnName("CANTIDAD");
				b.Property<int?>("Entregados").HasColumnType("integer").HasColumnName("ENTREGADOS");
				b.Property<decimal>("Precio").HasColumnType("decimal(18,2)").HasColumnName("PRECIO");
				b.HasKey("IdVenta", "IdProducto");
				b.HasIndex("IdProducto");
				b.ToTable("VENTAS_DETALLES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ArchivosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosArchivosMovimientosStock", "ArchivosMovimientosStockNavigation").WithMany("ArchivosMovimientoStock").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Stock_Movimientos", "StockMovimiento").WithMany().HasForeignKey("IdMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_ARCHIVOS_STOCK_STOCK_MOVIMIENTOS_ID_MOVIMIENTO");
				b.Navigation("ArchivosMovimientosStockNavigation");
				b.Navigation("StockMovimiento");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComponentesDetalle", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosComponentesDetalles", "IdEstadoNavigation").WithMany("ComponentesDetalle").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdEstadoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Compras", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosCompras", "Estado").WithMany("compras").HasForeignKey("IdEstadoCompra")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_COMPRAS_ESTADOS_COMPRAS_ID_ESTADO_COMPRA");
				b.HasOne("Aponus_Web_API.Modelos.Entidades", "IdProveedor").WithMany("compras").HasForeignKey("IdProveedor")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Usuarios", "Usuario").WithMany("Compras").HasForeignKey("IdUsuario")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired()
					.HasConstraintName("FK_COMPRAS_USUARIOS_IDUSUARIO");
				b.Navigation("Estado");
				b.Navigation("IdProveedor");
				b.Navigation("Usuario");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComprasDetalles", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Compras", "Compra").WithMany("DetallesCompra").HasForeignKey("IdCompra")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.ComponentesDetalle", "DetallesInsumo").WithMany("ComprasNavigation").HasForeignKey("IdInsumo")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("Compra");
				b.Navigation("DetallesInsumo");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.CuotasCompras", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Compras", "CompraNavigation").WithMany("CuotasCompra").HasForeignKey("IdCompra")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_CUOTAS_COMPRAS_COMPRAS_ID_COMPRA");
				b.HasOne("Aponus_Web_API.Modelos.EstadosCuotasCompras", "EstadoCuotaCompra").WithMany("IdEstadoCuotaNavigation").HasForeignKey("IdEstadoCuota")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_CUOTAS_COMPRAS_ESTADOS_CUOTAS_COMPRAS_ID_ESTADO_CUOTA");
				b.Navigation("CompraNavigation");
				b.Navigation("EstadoCuotaCompra");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.CuotasVentas", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosCuotasVentas", "EstadoCuota").WithMany("IdEstadoCuotaNavigation").HasForeignKey("IdEstadoCuota")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Ventas", "Venta").WithMany("Cuotas").HasForeignKey("IdVenta")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("EstadoCuota");
				b.Navigation("Venta");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Entidades", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EntidadesCategorias", "CategoriaEntidad").WithMany("Entidades").HasForeignKey("IdCategoria")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.EntidadesTipos", "TipoEntidad").WithMany("Entidades").HasForeignKey("IdTipo")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Usuarios", "UsuarioRegistro").WithMany("IdUsuarioRegistroNavigation").HasForeignKey("IdUsuarioRegistro")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("CategoriaEntidad");
				b.Navigation("TipoEntidad");
				b.Navigation("UsuarioRegistro");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesTiposCategorias", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EntidadesCategorias", "CategoriaEntidad").WithMany("TiposCategoriasNavigation").HasForeignKey("IdCategoriaEntidad")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.EntidadesTipos", "TipoEntidad").WithMany("TiposCategoriasNavigation").HasForeignKey("idTipoEntidad")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("CategoriaEntidad");
				b.Navigation("TipoEntidad");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PagosCompras", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Compras", "Compra").WithMany("Pagos").HasForeignKey("IdCompra")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.MediosPago", "MedioPago").WithMany("PagosComprasNavigation").HasForeignKey("IdMedioPago")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("Compra");
				b.Navigation("MedioPago");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PagosVentas", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.MediosPago", "MedioPago").WithMany("PagosVentasNavigation").HasForeignKey("IdMedioPago")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Ventas", "Venta").WithMany("Pagos").HasForeignKey("IdVenta")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("MedioPago");
				b.Navigation("Venta");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Producto", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.ProductosDescripcion", "IdDescripcionNavigation").WithMany("Productos").HasForeignKey("IdDescripcion")
					.IsRequired()
					.HasConstraintName("FK_PRODUCTOS_PRODUCTOS_DESCRIPCION");
				b.HasOne("Aponus_Web_API.Modelos.EstadosProductos", "IdEstadoNavigation").WithMany("Productos").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.ProductosTipo", "IdTipoNavigation").WithMany("Productos").HasForeignKey("IdTipo")
					.IsRequired()
					.HasConstraintName("FK_PRODUCTOS_PRODUCTOS_TIPOS");
				b.Navigation("IdDescripcionNavigation");
				b.Navigation("IdEstadoNavigation");
				b.Navigation("IdTipoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosDescripcion", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosProductosDescripciones", "IdEstadoNavigation").WithMany("ProductosDescripcions").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdEstadoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosTipo", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosTiposProductos", "IdEstadoNavigation").WithMany("ProductosTipos").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdEstadoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Productos_Componentes", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosProductosComponentes", "IdEstadoNavigation").WithMany("ProductosComponentes").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdEstadoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Productos_Tipos_Descripcion", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.ProductosDescripcion", "IdDescripcionNavigation").WithMany("Producto_Tipo_Descripcione").HasForeignKey("IdDescripcion")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired()
					.HasConstraintName("FK_PRODUCTOS_TIPOS_DESCRIPCION_ID_DESCRIPCION");
				b.HasOne("Aponus_Web_API.Modelos.ProductosTipo", "IdTipoNavigation").WithMany("Producto_Tipo_Descripcione").HasForeignKey("IdTipo")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired()
					.HasConstraintName("FK_PRODUCTOS_TIPOS_DESCRIPCION_ID_TIPO");
				b.Navigation("IdDescripcionNavigation");
				b.Navigation("IdTipoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Stock_Movimientos", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosMovimientosStock", "estadoMovimiento").WithMany("movimientosStock").HasForeignKey("IdEstadoMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Entidades", "Proveeedor").WithMany("Movimientos").HasForeignKey("IdProveedor")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_STOCK_MOVIMIENTOS_ENTIDADES_ID_PROVEEDOR_DESTINO");
				b.HasOne("Aponus_Web_API.Modelos.Entidades", "ProveedorOrigen").WithMany("MovimientosOrigen").HasForeignKey("IdProveedorOrigen")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_STOCK_MOVIMIENTOS_ENTIDADES_ID_PROVEEDOR_ORIGEN");
				b.Navigation("Proveeedor");
				b.Navigation("ProveedorOrigen");
				b.Navigation("estadoMovimiento");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.SuministrosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosSuministrosMovimientosStock", "EstadosSuministrosMovimientosStockNavigation").WithMany("SuministrosMovimientoStock").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_SUMINISTROS_MOVIMIENTOS_STOCK_ESTADOS_SUMINISTROS_MOVIMIENTO");
				b.HasOne("Aponus_Web_API.Modelos.Stock_Movimientos", null).WithMany("Suministros").HasForeignKey("IdMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("EstadosSuministrosMovimientosStockNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Usuarios", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.PerfilesUsuarios", "Perfil").WithMany("UsuariosNavigation").HasForeignKey("IdPerfil")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_USUARIOS_PERFILES_USUARIOS_ID_PERFIL");
				b.Navigation("Perfil");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Ventas", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Entidades", "Cliente").WithMany("ventas").HasForeignKey("IdCliente")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.EstadosVentas", "Estado").WithMany("ventas").HasForeignKey("IdEstadoVenta")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Usuarios", "Usuario").WithMany("Ventas").HasForeignKey("IdUsuario")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired();
				b.Navigation("Cliente");
				b.Navigation("Estado");
				b.Navigation("Usuario");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.VentasDetalles", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Producto", "IdProductoNavigation").WithMany("Ventas").HasForeignKey("IdProducto")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_VENTAS_DETALLES_PRODUCTOS_ID_PRODUCTO");
				b.HasOne("Aponus_Web_API.Modelos.Ventas", "Venta").WithMany("DetallesVenta").HasForeignKey("IdVenta")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdProductoNavigation");
				b.Navigation("Venta");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComponentesDetalle", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ComprasNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Compras", delegate(EntityTypeBuilder b)
			{
				b.Navigation("CuotasCompra");
				b.Navigation("DetallesCompra");
				b.Navigation("Pagos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Entidades", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Movimientos");
				b.Navigation("MovimientosOrigen");
				b.Navigation("compras");
				b.Navigation("ventas");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesCategorias", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Entidades");
				b.Navigation("TiposCategoriasNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesTipos", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Entidades");
				b.Navigation("TiposCategoriasNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosArchivosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ArchivosMovimientoStock");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosComponentesDetalles", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ComponentesDetalle");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCompras", delegate(EntityTypeBuilder b)
			{
				b.Navigation("compras");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCuotasCompras", delegate(EntityTypeBuilder b)
			{
				b.Navigation("IdEstadoCuotaNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCuotasVentas", delegate(EntityTypeBuilder b)
			{
				b.Navigation("IdEstadoCuotaNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Navigation("movimientosStock");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductos", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Productos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductosComponentes", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ProductosComponentes");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductosDescripciones", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ProductosDescripcions");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosSuministrosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Navigation("SuministrosMovimientoStock");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosTiposProductos", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ProductosTipos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosVentas", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ventas");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.MediosPago", delegate(EntityTypeBuilder b)
			{
				b.Navigation("PagosComprasNavigation");
				b.Navigation("PagosVentasNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PerfilesUsuarios", delegate(EntityTypeBuilder b)
			{
				b.Navigation("UsuariosNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Producto", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Ventas");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosDescripcion", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Producto_Tipo_Descripcione");
				b.Navigation("Productos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosTipo", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Producto_Tipo_Descripcione");
				b.Navigation("Productos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Stock_Movimientos", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Suministros");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Usuarios", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Compras");
				b.Navigation("IdUsuarioRegistroNavigation");
				b.Navigation("Ventas");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Ventas", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Cuotas");
				b.Navigation("DetallesVenta");
				b.Navigation("Pagos");
			});
		}
	}
	[DbContext(typeof(AponusContext))]
	[Migration("20241104215723_ProveedoresDestinoMovimientos")]
	public class ProveedoresDestinoMovimientos : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey("FK_STOCK_MOVIMIENTOS_ENTIDADES_ID_PROVEEDOR_ORIGEN", "STOCK_MOVIMIENTOS");
			migrationBuilder.DropColumn("ID_PROVEEDOR_ORIGEN", "STOCK_MOVIMIENTOS");
			migrationBuilder.RenameColumn("ID_PROVEEDOR_DESTINO", "STOCK_MOVIMIENTOS", "ID_PROVEEDOR");
			migrationBuilder.CreateIndex("IX_STOCK_MOVIMIENTOS_ID_PROVEEDOR", "STOCK_MOVIMIENTOS", "ID_PROVEEDOR");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.RenameColumn("ID_PROVEEDOR", "STOCK_MOVIMIENTOS", "ID_PROVEEDOR_DESTINO");
			migrationBuilder.RenameIndex("IX_STOCK_MOVIMIENTOS_ID_PROVEEDOR", "IX_STOCK_MOVIMIENTOS_ID_PROVEEDOR_DESTINO", "STOCK_MOVIMIENTOS");
			migrationBuilder.AddColumn<int>("ID_PROVEEDOR_ORIGEN", "STOCK_MOVIMIENTOS", "int", null, null, rowVersion: false, null, nullable: false, 0);
			migrationBuilder.CreateIndex("IX_STOCK_MOVIMIENTOS_ID_PROVEEDOR_ORIGEN", "STOCK_MOVIMIENTOS", "ID_PROVEEDOR_ORIGEN");
			migrationBuilder.AddForeignKey("FK_STOCK_MOVIMIENTOS_ENTIDADES_ID_PROVEEDOR_ORIGEN", "STOCK_MOVIMIENTOS", "ID_PROVEEDOR_ORIGEN", "ENTIDADES", null, null, "ID_ENTIDAD", ReferentialAction.NoAction, ReferentialAction.Cascade);
		}

		protected override void BuildTargetModel(ModelBuilder modelBuilder)
		{
			modelBuilder.UseCollation("Modern_Spanish_CI_AI").HasAnnotation("ProductVersion", "7.0.11").HasAnnotation("Relational:MaxIdentifierLength", 63);
			modelBuilder.UseIdentityByDefaultColumns();
			modelBuilder.Entity("Aponus_Web_API.Modelos.ArchivosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdMovimiento").HasColumnType("int").HasColumnName("ID_MOVIMIENTO");
				b.Property<string>("HashArchivo").HasColumnType("varchar(255)").HasColumnName("HASH_ARCHIVO");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("MimeType").HasColumnType("text").HasColumnName("MIME_TYPE");
				b.Property<string>("PathArchivo").IsRequired().HasColumnType("text")
					.HasColumnName("PATH");
				b.HasKey("IdMovimiento", "HashArchivo");
				b.HasIndex("IdEstado");
				b.ToTable("ARCHIVOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComponentesDescripcion", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdDescripcion").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_DESCRIPCION");
				b.Property<int>("IdDescripcion").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("DESCRIPCION");
				b.Property<string>("IdAlmacenamiento").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("ID_ALMACENAMIENTO");
				b.Property<string>("IdFraccionamiento").HasColumnType("varchar(50)").HasColumnName("ID_FRACCIONAMIENTO");
				b.HasKey("IdDescripcion");
				b.ToTable("COMPONENTES_DESCRIPCION", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComponentesDetalle", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdInsumo").HasColumnType("varchar(50)").HasColumnName("ID_INSUMO");
				b.Property<decimal?>("Altura").HasColumnType("decimal(18,2)").HasColumnName("ALTURA");
				b.Property<decimal?>("Diametro").HasColumnType("decimal(18,2)").HasColumnName("DIAMETRO");
				b.Property<int?>("DiametroNominal").HasColumnType("int").HasColumnName("DIAMETRO_NOMINAL");
				b.Property<decimal?>("Espesor").HasColumnType("decimal(18,2)").HasColumnName("ESPESOR");
				b.Property<string>("IdAlmacenamiento").HasColumnType("varchar(50)").HasColumnName("ID_ALMACENAMIENTO");
				b.Property<int>("IdDescripcion").HasColumnType("integer").HasColumnName("ID_DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("IdFraccionamiento").HasColumnType("varchar(50)").HasColumnName("ID_FRACCIONAMIENTO");
				b.Property<decimal?>("Longitud").HasColumnType("decimal(18,2)").HasColumnName("LONGITUD");
				b.Property<int?>("Perfil").HasColumnType("integer").HasColumnName("PERFIL");
				b.Property<decimal?>("Peso").HasColumnType("decimal(18,3)").HasColumnName("PESO");
				b.Property<string>("Tolerancia").HasColumnType("varchar(50)").HasColumnName("TOLERANCIA");
				b.HasKey("IdInsumo").HasName("PK_ID_INSUMO");
				b.HasIndex("IdEstado");
				b.ToTable("COMPONENTES_DETALLE", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Compras", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCompra").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_COMPRA");
				b.Property<int>("IdCompra").UseIdentityByDefaultColumn();
				b.Property<DateTime>("FechaHora").HasColumnType("timestamp").HasColumnName("FECHA_HORA");
				b.Property<int>("IdEstadoCompra").HasColumnType("int").HasColumnName("ID_ESTADO_COMPRA");
				b.Property<int>("IdProveedor").HasColumnType("int").HasColumnName("ID_PROVEEDOR");
				b.Property<string>("IdUsuario").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("ID_USUARIO");
				b.Property<decimal>("MontoTotal").HasColumnType("decimal(18,2)").HasColumnName("MONTO_TOTAL");
				b.Property<decimal?>("SaldoPendiente").HasColumnType("decimal(18,2)").HasColumnName("SALDO_PENDIENTE");
				b.HasKey("IdCompra");
				b.HasIndex("IdEstadoCompra");
				b.HasIndex("IdProveedor");
				b.HasIndex("IdUsuario");
				b.ToTable("COMPRAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComprasDetalles", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCompra").HasColumnType("int").HasColumnName("ID_COMPRA");
				b.Property<string>("IdInsumo").HasColumnType("varchar(50)").HasColumnName("ID_INSUMO");
				b.Property<decimal>("Cantidad").HasColumnType("decimal(18,2)").HasColumnName("CANTIDAD");
				b.HasKey("IdCompra", "IdInsumo");
				b.HasIndex("IdInsumo");
				b.ToTable("COMPRAS_DETALLE", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.CuotasCompras", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCuota").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_CUOTA");
				b.Property<int>("IdCuota").UseIdentityByDefaultColumn();
				b.Property<DateTime?>("FechaPago").HasColumnType("timestamp").HasColumnName("FECHA_PAGO");
				b.Property<DateTime>("FechaVencimiento").HasColumnType("timestamp").HasColumnName("FECHA_VENCIMIENTO");
				b.Property<int>("IdCompra").HasColumnType("int").HasColumnName("ID_COMPRA");
				b.Property<int>("IdEstadoCuota").HasColumnType("integer");
				b.Property<decimal>("Monto").HasColumnType("decimal(18,2)").HasColumnName("MONTO");
				b.Property<int>("NumeroCuota").HasColumnType("integer").HasColumnName("NUMERO_CUOTA");
				b.HasKey("IdCuota");
				b.HasIndex("IdCompra");
				b.HasIndex("IdEstadoCuota");
				b.ToTable("CUOTAS_COMPRAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.CuotasVentas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCuota").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_CUOTA");
				b.Property<int>("IdCuota").UseIdentityByDefaultColumn();
				b.Property<DateTime?>("FechaPago").HasColumnType("timestamp").HasColumnName("FECHA_PAGO");
				b.Property<DateTime>("FechaVencimiento").HasColumnType("timestamp").HasColumnName("FECHA_VENCIMIENTO");
				b.Property<int>("IdEstadoCuota").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_CUOTA")
					.HasDefaultValueSql("1");
				b.Property<int>("IdVenta").HasColumnType("int").HasColumnName("ID_VENTA");
				b.Property<decimal>("Monto").ValueGeneratedOnAdd().HasColumnType("decimal(18,2)")
					.HasColumnName("MONTO")
					.HasDefaultValueSql("0.00");
				b.Property<int>("NumeroCuota").HasColumnType("int").HasColumnName("NUMERO_CUOTA");
				b.HasKey("IdCuota");
				b.HasIndex("IdEstadoCuota");
				b.HasIndex("IdVenta");
				b.ToTable("CUOTAS_VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Entidades", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEntidad").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ENTIDAD");
				b.Property<int>("IdEntidad").UseIdentityByDefaultColumn();
				b.Property<string>("Altura").HasColumnType("text").HasColumnName("ALTURA");
				b.Property<string>("Apellido").HasColumnType("text").HasColumnName("APELLIDO");
				b.Property<string>("Barrio").HasColumnType("text").HasColumnName("BARRIO");
				b.Property<string>("Calle").HasColumnType("text").HasColumnName("CALLE");
				b.Property<string>("Ciudad").HasColumnType("text").HasColumnName("CIUDAD");
				b.Property<string>("CodigoPostal").HasColumnType("text").HasColumnName("CODIGO_POSTAL");
				b.Property<string>("Email").HasColumnType("text").HasColumnName("EMAIL");
				b.Property<DateTime>("FechaRegistro").HasColumnType("timestamp").HasColumnName("FECHA_REGISTRO");
				b.Property<int>("IdCategoria").HasColumnType("int").HasColumnName("ID_CATEGORIA");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("(1)");
				b.Property<string>("IdFiscal").IsRequired().HasColumnType("text")
					.HasColumnName("ID_FISCAL");
				b.Property<int>("IdTipo").HasColumnType("int").HasColumnName("ID_TIPO");
				b.Property<string>("IdUsuarioRegistro").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("ID_USUARIO_REGISTRO");
				b.Property<string>("Localidad").HasColumnType("text").HasColumnName("LOCALIDAD");
				b.Property<string>("Nombre").HasColumnType("text").HasColumnName("NOMBRE");
				b.Property<string>("NombreClave").HasColumnType("text").HasColumnName("NOMBRE_CLAVE");
				b.Property<string>("Pais").HasColumnType("text").HasColumnName("PAIS");
				b.Property<string>("Provincia").HasColumnType("text").HasColumnName("PROVINCIA");
				b.Property<string>("Telefono1").HasColumnType("text").HasColumnName("TELEFONO_1");
				b.Property<string>("Telefono2").HasColumnType("text").HasColumnName("TELEFONO_2");
				b.Property<string>("Telefono3").HasColumnType("text").HasColumnName("TELEFONO_3");
				b.HasKey("IdEntidad");
				b.HasIndex("IdCategoria");
				b.HasIndex("IdTipo");
				b.HasIndex("IdUsuarioRegistro");
				b.ToTable("ENTIDADES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesCategorias", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCategoria").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_CATEGORIA");
				b.Property<int>("IdCategoria").UseIdentityByDefaultColumn();
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("NombreCategoria").IsRequired().HasColumnType("text")
					.HasColumnName("NOMBRE_CATEGORIA");
				b.HasKey("IdCategoria");
				b.ToTable("ENTIDADES_CATEGORIAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesTipos", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdTipo").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_TIPO");
				b.Property<int>("IdTipo").UseIdentityByDefaultColumn();
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("NombreTipo").IsRequired().HasColumnType("text")
					.HasColumnName("NOMBRE");
				b.HasKey("IdTipo");
				b.ToTable("ENTIDADES_TIPOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesTiposCategorias", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("idTipoEntidad").HasColumnType("int").HasColumnName("ID_TIPO");
				b.Property<int>("IdCategoriaEntidad").HasColumnType("int").HasColumnName("ID_CATEGORIA");
				b.HasKey("idTipoEntidad", "IdCategoriaEntidad");
				b.HasIndex("IdCategoriaEntidad");
				b.ToTable("ENTIDADES_TIPOS_CATEGORIAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosArchivosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_ARCHIVOS_MOVIMIENTOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosComponentesDetalles", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_COMPONENTES_DETALLES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCompras", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoCompra").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_COMPRA")
					.HasAnnotation("SqlServer:Identity", "1, 1");
				b.Property<int>("IdEstadoCompra").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").HasColumnType("int").HasColumnName("ID_ESTADO");
				b.HasKey("IdEstadoCompra");
				b.ToTable("ESTADOS_COMPRAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCuotasCompras", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoCuota").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO_CUOTA");
				b.Property<int>("IdEstadoCuota").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.HasKey("IdEstadoCuota");
				b.ToTable("ESTADOS_CUOTAS_COMPRAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCuotasVentas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoCuota").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_CUOTA");
				b.Property<int>("IdEstadoCuota").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.HasKey("IdEstadoCuota");
				b.ToTable("ESTADOS_CUOTAS_VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int?>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_MOVIMIENTO");
				b.Property<int?>("IdEstadoMovimiento").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.HasKey("IdEstadoMovimiento");
				b.ToTable("ESTADOS_MOVIMIENTOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductos", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_PRODUCTOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductosComponentes", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_PRODUCTOS_COMPONENTES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductosDescripciones", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_PRODUCTOS_DESCRIPCIONES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosSuministrosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_SUMINISTROS_MOVIMIENTOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosTiposProductos", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_PRODUCTOS_TIPOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosVentas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoVenta").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_VENTA");
				b.Property<int>("IdEstadoVenta").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("int")
					.HasDefaultValue(1)
					.HasColumnName("ID_ESTADO");
				b.HasKey("IdEstadoVenta");
				b.ToTable("ESTADOS_VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.MediosPago", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdMedioPago").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_MEDIO_PAGO");
				b.Property<int>("IdMedioPago").UseIdentityByDefaultColumn();
				b.Property<string>("CodigoMPago").HasColumnType("text").HasColumnName("CODIGO_MPAGO");
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("int")
					.HasDefaultValue(1)
					.HasColumnName("ID_ESTADO");
				b.HasKey("IdMedioPago");
				b.ToTable("MEDIOS_PAGO", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PagosCompras", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdPago").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_PAGO")
					.HasColumnOrder(2);
				b.Property<int>("IdPago").UseIdentityByDefaultColumn();
				b.Property<DateTime?>("Fecha").HasColumnType("timestamp").HasColumnName("FECHA");
				b.Property<int>("IdCompra").HasColumnType("int").HasColumnName("ID_COMPRA");
				b.Property<int>("IdMedioPago").HasColumnType("int").HasColumnName("ID_MEDIO_PAGO");
				b.Property<decimal>("Monto").HasColumnType("decimal(18,2)").HasColumnName("SUBTOTAL");
				b.HasKey("IdPago");
				b.HasIndex("IdCompra");
				b.HasIndex("IdMedioPago");
				b.ToTable("PAGOS_COMPRAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PagosVentas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdPago").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_PAGO")
					.HasColumnOrder(2);
				b.Property<int>("IdPago").UseIdentityByDefaultColumn();
				b.Property<DateTime?>("Fecha").HasColumnType("timestamp").HasColumnName("FECHA");
				b.Property<int>("IdMedioPago").HasColumnType("int").HasColumnName("ID_MEDIO_PAGO");
				b.Property<int>("IdVenta").HasColumnType("int").HasColumnName("ID_VENTA");
				b.Property<decimal>("Monto").HasColumnType("decimal(18,2)").HasColumnName("MONTO");
				b.HasKey("IdPago");
				b.HasIndex("IdMedioPago");
				b.HasIndex("IdVenta");
				b.ToTable("PAGOS_VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PerfilesUsuarios", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdPerfil").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_PERFIL");
				b.Property<int>("IdPerfil").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("varchar(100)")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").HasColumnType("integer").HasColumnName("ID_ESTADO");
				b.HasKey("IdPerfil");
				b.ToTable("USUARIOS_PERFILES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Producto", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdProducto").HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("ID_PRODUCTO");
				b.Property<int?>("Cantidad").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("CANTIDAD")
					.HasDefaultValueSql("((0))");
				b.Property<int?>("DiametroNominal").HasColumnType("integer").HasColumnName("DIAMETRO_NOMINAL");
				b.Property<int>("IdDescripcion").HasColumnType("integer").HasColumnName("ID_DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("IdTipo").IsRequired().HasMaxLength(50)
					.IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("ID_TIPO");
				b.Property<decimal?>("PorcentajeGanancia").HasColumnType("decimal(18,2)").HasColumnName("PORCENTAJE_GANANCIA");
				b.Property<decimal?>("PrecioFinal").HasColumnType("decimal(18,2)").HasColumnName("PRECIO_FINAL");
				b.Property<decimal?>("PrecioLista").ValueGeneratedOnAdd().HasColumnType("money")
					.HasColumnName("PRECIO_LISTA")
					.HasDefaultValueSql("((0))");
				b.Property<string>("Tolerancia").HasColumnType("text").HasColumnName("TOLERANCIA");
				b.HasKey("IdProducto");
				b.HasIndex("IdDescripcion");
				b.HasIndex("IdEstado");
				b.HasIndex("IdTipo");
				b.ToTable("PRODUCTOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosDescripcion", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdDescripcion").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_DESCRIPCION");
				b.Property<int>("IdDescripcion").UseIdentityByDefaultColumn();
				b.Property<string>("DescripcionProducto").HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.HasKey("IdDescripcion");
				b.HasIndex("IdEstado");
				b.ToTable("PRODUCTOS_DESCRIPCION", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosTipo", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdTipo").HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("ID_TIPO");
				b.Property<string>("DescripcionTipo").HasMaxLength(100).IsUnicode(unicode: false)
					.HasColumnType("character varying(100)")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.HasKey("IdTipo").HasName("PK_PRODUCTOS_TIPOS");
				b.HasIndex("IdEstado");
				b.ToTable("PRODUCTOS_TIPOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Productos_Componentes", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdProducto").HasColumnType("varchar(50)").HasColumnName("ID_PRODUCTO");
				b.Property<string>("IdComponente").HasColumnType("varchar(50)").HasColumnName("ID_COMPONENTE");
				b.Property<decimal?>("Cantidad").HasColumnType("decimal(18,2)").HasColumnName("CANTIDAD");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<decimal?>("Longitud").HasColumnType("decimal(18,2)").HasColumnName("LONGITUD");
				b.Property<decimal?>("Peso").HasColumnType("decimal(18,2)").HasColumnName("PESO");
				b.HasKey("IdProducto", "IdComponente").HasName("PK_PRODUCTOS_COMPONENTES");
				b.HasIndex("IdEstado");
				b.ToTable("PRODUCTOS_COMPONENTES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Productos_Tipos_Descripcion", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdTipo").HasColumnType("varchar(50)").HasColumnName("ID_TIPO");
				b.Property<int?>("IdDescripcion").HasColumnType("integer").HasColumnName("ID_DESCRIPCION");
				b.HasKey("IdTipo", "IdDescripcion");
				b.HasIndex("IdDescripcion");
				b.ToTable("PRODUCTOS_TIPOS_DESCRIPCION", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.StockInsumos", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdInsumo").HasColumnType("varchar(50)").HasColumnName("ID_INSUMO");
				b.Property<decimal?>("Granallado").HasColumnType("decimal").HasColumnName("GRANALLADO");
				b.Property<decimal?>("Moldeado").HasColumnType("decimal").HasColumnName("MOLDEADO");
				b.Property<decimal?>("Pendiente").HasColumnType("decimal(18,2)").HasColumnName("PENDIENTE");
				b.Property<decimal?>("Pintura").HasColumnType("decimal").HasColumnName("PINTURA");
				b.Property<decimal?>("Proceso").HasColumnType("decimal").HasColumnName("PROCESO");
				b.Property<decimal?>("Recibido").HasColumnType("decimal").HasColumnName("RECIBIDO");
				b.HasKey("IdInsumo").HasName("PK_STOCK_INSUMOS");
				b.ToTable("STOCK_INSUMOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Stock_Movimientos", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdMovimiento").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_MOVIMIENTO");
				b.Property<int>("IdMovimiento").UseIdentityByDefaultColumn();
				b.Property<string>("CreadoUsuario").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("USUARIO_CREADO");
				b.Property<string>("Destino").HasColumnType("varchar(50)").HasColumnName("DESTINO");
				b.Property<DateTime>("FechaHoraCreado").HasColumnType("timestamp").HasColumnName("FECHA_HORA_CREADO");
				b.Property<DateTime?>("FechaHoraUltimaModificacion").HasColumnType("timestamp").HasColumnName("FECHA_HORA_ULTIMA_MODIFICACION");
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_MOVIMIENTO")
					.HasDefaultValueSql("1");
				b.Property<int>("IdProveedor").HasColumnType("int").HasColumnName("ID_PROVEEDOR");
				b.Property<string>("ModificadoUsuario").HasColumnType("varchar(50)").HasColumnName("USUARIO_MODIFICA");
				b.Property<string>("Origen").HasColumnType("varchar(50)").HasColumnName("ORIGEN");
				b.Property<string>("Tipo").HasColumnType("varchar(15)").HasColumnName("TIPO");
				b.HasKey("IdMovimiento");
				b.HasIndex("IdEstadoMovimiento");
				b.HasIndex("IdProveedor");
				b.ToTable("STOCK_MOVIMIENTOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.SuministrosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdMovimiento").HasColumnType("int").HasColumnName("ID_MOVIMIENTO");
				b.Property<string>("IdSuministro").HasColumnType("varchar(50)").HasColumnName("ID_SUMINISTRO");
				b.Property<decimal>("Cantidad").HasColumnType("decimal(18,2)").HasColumnName("CANTIDAD");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.HasKey("IdMovimiento", "IdSuministro");
				b.HasIndex("IdEstado");
				b.ToTable("SUMINISTROS_MOVIMIENTOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Usuarios", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("Usuario").HasColumnType("varchar(50)").HasColumnName("USUARIO");
				b.Property<string>("Contraseña").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("CONTRASEÑA");
				b.Property<string>("Correo").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("CORREO");
				b.Property<int>("IdPerfil").HasColumnType("int").HasColumnName("ID_PERFIL");
				b.HasKey("Usuario");
				b.HasIndex("IdPerfil");
				b.ToTable("USUARIOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Ventas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdVenta").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_VENTA");
				b.Property<int>("IdVenta").UseIdentityByDefaultColumn();
				b.Property<DateTime>("FechaHora").HasColumnType("timestamp").HasColumnName("FECHA_HORA");
				b.Property<int>("IdCliente").HasColumnType("int").HasColumnName("ID_CLIENTE");
				b.Property<int>("IdEstadoVenta").HasColumnType("int").HasColumnName("ID_ESTADO_VENTA");
				b.Property<string>("IdUsuario").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("ID_USUARIO");
				b.Property<decimal>("MontoTotal").HasColumnType("decimal(18,2)").HasColumnName("MONTO_TOTAL");
				b.Property<decimal?>("SaldoPendiente").HasColumnType("numeric").HasColumnName("SALDO_PENDIENTE");
				b.HasKey("IdVenta");
				b.HasIndex("IdCliente");
				b.HasIndex("IdEstadoVenta");
				b.HasIndex("IdUsuario");
				b.ToTable("VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.VentasDetalles", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdVenta").HasColumnType("int").HasColumnName("ID_VENTA");
				b.Property<string>("IdProducto").HasColumnType("varchar(50)").HasColumnName("ID_PRODUCTO");
				b.Property<decimal>("Cantidad").HasColumnType("decimal(18,2)").HasColumnName("CANTIDAD");
				b.Property<int?>("Entregados").HasColumnType("integer").HasColumnName("ENTREGADOS");
				b.Property<decimal>("Precio").HasColumnType("decimal(18,2)").HasColumnName("PRECIO");
				b.HasKey("IdVenta", "IdProducto");
				b.HasIndex("IdProducto");
				b.ToTable("VENTAS_DETALLES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ArchivosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosArchivosMovimientosStock", "ArchivosMovimientosStockNavigation").WithMany("ArchivosMovimientoStock").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Stock_Movimientos", "StockMovimiento").WithMany().HasForeignKey("IdMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_ARCHIVOS_STOCK_STOCK_MOVIMIENTOS_ID_MOVIMIENTO");
				b.Navigation("ArchivosMovimientosStockNavigation");
				b.Navigation("StockMovimiento");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComponentesDetalle", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosComponentesDetalles", "IdEstadoNavigation").WithMany("ComponentesDetalle").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdEstadoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Compras", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosCompras", "Estado").WithMany("compras").HasForeignKey("IdEstadoCompra")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_COMPRAS_ESTADOS_COMPRAS_ID_ESTADO_COMPRA");
				b.HasOne("Aponus_Web_API.Modelos.Entidades", "IdProveedorNavigation").WithMany("compras").HasForeignKey("IdProveedor")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Usuarios", "Usuario").WithMany("Compras").HasForeignKey("IdUsuario")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired()
					.HasConstraintName("FK_COMPRAS_USUARIOS_IDUSUARIO");
				b.Navigation("Estado");
				b.Navigation("IdProveedorNavigation");
				b.Navigation("Usuario");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComprasDetalles", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Compras", "Compra").WithMany("DetallesCompra").HasForeignKey("IdCompra")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.ComponentesDetalle", "DetallesInsumo").WithMany("ComprasNavigation").HasForeignKey("IdInsumo")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("Compra");
				b.Navigation("DetallesInsumo");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.CuotasCompras", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Compras", "CompraNavigation").WithMany("CuotasCompra").HasForeignKey("IdCompra")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_CUOTAS_COMPRAS_COMPRAS_ID_COMPRA");
				b.HasOne("Aponus_Web_API.Modelos.EstadosCuotasCompras", "EstadoCuotaCompra").WithMany("IdEstadoCuotaNavigation").HasForeignKey("IdEstadoCuota")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_CUOTAS_COMPRAS_ESTADOS_CUOTAS_COMPRAS_ID_ESTADO_CUOTA");
				b.Navigation("CompraNavigation");
				b.Navigation("EstadoCuotaCompra");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.CuotasVentas", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosCuotasVentas", "EstadoCuota").WithMany("IdEstadoCuotaNavigation").HasForeignKey("IdEstadoCuota")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Ventas", "Venta").WithMany("Cuotas").HasForeignKey("IdVenta")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("EstadoCuota");
				b.Navigation("Venta");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Entidades", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EntidadesCategorias", "CategoriaEntidad").WithMany("Entidades").HasForeignKey("IdCategoria")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.EntidadesTipos", "TipoEntidad").WithMany("Entidades").HasForeignKey("IdTipo")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Usuarios", "UsuarioRegistro").WithMany("IdUsuarioRegistroNavigation").HasForeignKey("IdUsuarioRegistro")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("CategoriaEntidad");
				b.Navigation("TipoEntidad");
				b.Navigation("UsuarioRegistro");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesTiposCategorias", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EntidadesCategorias", "CategoriaEntidad").WithMany("TiposCategoriasNavigation").HasForeignKey("IdCategoriaEntidad")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.EntidadesTipos", "TipoEntidad").WithMany("TiposCategoriasNavigation").HasForeignKey("idTipoEntidad")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("CategoriaEntidad");
				b.Navigation("TipoEntidad");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PagosCompras", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Compras", "Compra").WithMany("Pagos").HasForeignKey("IdCompra")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.MediosPago", "MedioPago").WithMany("PagosComprasNavigation").HasForeignKey("IdMedioPago")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("Compra");
				b.Navigation("MedioPago");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PagosVentas", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.MediosPago", "MedioPago").WithMany("PagosVentasNavigation").HasForeignKey("IdMedioPago")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Ventas", "Venta").WithMany("Pagos").HasForeignKey("IdVenta")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("MedioPago");
				b.Navigation("Venta");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Producto", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.ProductosDescripcion", "IdDescripcionNavigation").WithMany("Productos").HasForeignKey("IdDescripcion")
					.IsRequired()
					.HasConstraintName("FK_PRODUCTOS_PRODUCTOS_DESCRIPCION");
				b.HasOne("Aponus_Web_API.Modelos.EstadosProductos", "IdEstadoNavigation").WithMany("Productos").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.ProductosTipo", "IdTipoNavigation").WithMany("Productos").HasForeignKey("IdTipo")
					.IsRequired()
					.HasConstraintName("FK_PRODUCTOS_PRODUCTOS_TIPOS");
				b.Navigation("IdDescripcionNavigation");
				b.Navigation("IdEstadoNavigation");
				b.Navigation("IdTipoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosDescripcion", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosProductosDescripciones", "IdEstadoNavigation").WithMany("ProductosDescripcions").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdEstadoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosTipo", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosTiposProductos", "IdEstadoNavigation").WithMany("ProductosTipos").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdEstadoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Productos_Componentes", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosProductosComponentes", "IdEstadoNavigation").WithMany("ProductosComponentes").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdEstadoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Productos_Tipos_Descripcion", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.ProductosDescripcion", "IdDescripcionNavigation").WithMany("Producto_Tipo_Descripcione").HasForeignKey("IdDescripcion")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired()
					.HasConstraintName("FK_PRODUCTOS_TIPOS_DESCRIPCION_ID_DESCRIPCION");
				b.HasOne("Aponus_Web_API.Modelos.ProductosTipo", "IdTipoNavigation").WithMany("Producto_Tipo_Descripcione").HasForeignKey("IdTipo")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired()
					.HasConstraintName("FK_PRODUCTOS_TIPOS_DESCRIPCION_ID_TIPO");
				b.Navigation("IdDescripcionNavigation");
				b.Navigation("IdTipoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Stock_Movimientos", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosMovimientosStock", "estadoMovimiento").WithMany("movimientosStock").HasForeignKey("IdEstadoMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Entidades", "Proveeedor").WithMany("Movimientos").HasForeignKey("IdProveedor")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_STOCK_MOVIMIENTOS_ENTIDADES_ID_PROVEEDOR_DESTINO");
				b.Navigation("Proveeedor");
				b.Navigation("estadoMovimiento");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.SuministrosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosSuministrosMovimientosStock", "EstadosSuministrosMovimientosStockNavigation").WithMany("SuministrosMovimientoStock").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_SUMINISTROS_MOVIMIENTOS_STOCK_ESTADOS_SUMINISTROS_MOVIMIENTO");
				b.HasOne("Aponus_Web_API.Modelos.Stock_Movimientos", null).WithMany("Suministros").HasForeignKey("IdMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("EstadosSuministrosMovimientosStockNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Usuarios", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.PerfilesUsuarios", "Perfil").WithMany("UsuariosNavigation").HasForeignKey("IdPerfil")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_USUARIOS_PERFILES_USUARIOS_ID_PERFIL");
				b.Navigation("Perfil");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Ventas", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Entidades", "Cliente").WithMany("ventas").HasForeignKey("IdCliente")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.EstadosVentas", "Estado").WithMany("ventas").HasForeignKey("IdEstadoVenta")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Usuarios", "Usuario").WithMany("Ventas").HasForeignKey("IdUsuario")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired();
				b.Navigation("Cliente");
				b.Navigation("Estado");
				b.Navigation("Usuario");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.VentasDetalles", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Producto", "IdProductoNavigation").WithMany("Ventas").HasForeignKey("IdProducto")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_VENTAS_DETALLES_PRODUCTOS_ID_PRODUCTO");
				b.HasOne("Aponus_Web_API.Modelos.Ventas", "Venta").WithMany("DetallesVenta").HasForeignKey("IdVenta")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdProductoNavigation");
				b.Navigation("Venta");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComponentesDetalle", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ComprasNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Compras", delegate(EntityTypeBuilder b)
			{
				b.Navigation("CuotasCompra");
				b.Navigation("DetallesCompra");
				b.Navigation("Pagos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Entidades", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Movimientos");
				b.Navigation("compras");
				b.Navigation("ventas");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesCategorias", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Entidades");
				b.Navigation("TiposCategoriasNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesTipos", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Entidades");
				b.Navigation("TiposCategoriasNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosArchivosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ArchivosMovimientoStock");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosComponentesDetalles", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ComponentesDetalle");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCompras", delegate(EntityTypeBuilder b)
			{
				b.Navigation("compras");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCuotasCompras", delegate(EntityTypeBuilder b)
			{
				b.Navigation("IdEstadoCuotaNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCuotasVentas", delegate(EntityTypeBuilder b)
			{
				b.Navigation("IdEstadoCuotaNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Navigation("movimientosStock");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductos", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Productos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductosComponentes", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ProductosComponentes");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductosDescripciones", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ProductosDescripcions");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosSuministrosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Navigation("SuministrosMovimientoStock");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosTiposProductos", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ProductosTipos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosVentas", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ventas");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.MediosPago", delegate(EntityTypeBuilder b)
			{
				b.Navigation("PagosComprasNavigation");
				b.Navigation("PagosVentasNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PerfilesUsuarios", delegate(EntityTypeBuilder b)
			{
				b.Navigation("UsuariosNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Producto", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Ventas");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosDescripcion", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Producto_Tipo_Descripcione");
				b.Navigation("Productos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosTipo", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Producto_Tipo_Descripcione");
				b.Navigation("Productos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Stock_Movimientos", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Suministros");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Usuarios", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Compras");
				b.Navigation("IdUsuarioRegistroNavigation");
				b.Navigation("Ventas");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Ventas", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Cuotas");
				b.Navigation("DetallesVenta");
				b.Navigation("Pagos");
			});
		}
	}
	[DbContext(typeof(AponusContext))]
	internal class AponusContextModelSnapshot : ModelSnapshot
	{
		protected override void BuildModel(ModelBuilder modelBuilder)
		{
			modelBuilder.UseCollation("Modern_Spanish_CI_AI").HasAnnotation("ProductVersion", "7.0.11").HasAnnotation("Relational:MaxIdentifierLength", 63);
			modelBuilder.UseIdentityByDefaultColumns();
			modelBuilder.Entity("Aponus_Web_API.Modelos.ArchivosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdMovimiento").HasColumnType("int").HasColumnName("ID_MOVIMIENTO");
				b.Property<string>("HashArchivo").HasColumnType("varchar(255)").HasColumnName("HASH_ARCHIVO");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("MimeType").HasColumnType("text").HasColumnName("MIME_TYPE");
				b.Property<string>("PathArchivo").IsRequired().HasColumnType("text")
					.HasColumnName("PATH");
				b.HasKey("IdMovimiento", "HashArchivo");
				b.HasIndex("IdEstado");
				b.ToTable("ARCHIVOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComponentesDescripcion", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdDescripcion").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_DESCRIPCION");
				b.Property<int>("IdDescripcion").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("DESCRIPCION");
				b.Property<string>("IdAlmacenamiento").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("ID_ALMACENAMIENTO");
				b.Property<string>("IdFraccionamiento").HasColumnType("varchar(50)").HasColumnName("ID_FRACCIONAMIENTO");
				b.HasKey("IdDescripcion");
				b.ToTable("COMPONENTES_DESCRIPCION", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComponentesDetalle", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdInsumo").HasColumnType("varchar(50)").HasColumnName("ID_INSUMO");
				b.Property<decimal?>("Altura").HasColumnType("decimal(18,2)").HasColumnName("ALTURA");
				b.Property<decimal?>("Diametro").HasColumnType("decimal(18,2)").HasColumnName("DIAMETRO");
				b.Property<int?>("DiametroNominal").HasColumnType("int").HasColumnName("DIAMETRO_NOMINAL");
				b.Property<decimal?>("Espesor").HasColumnType("decimal(18,2)").HasColumnName("ESPESOR");
				b.Property<string>("IdAlmacenamiento").HasColumnType("varchar(50)").HasColumnName("ID_ALMACENAMIENTO");
				b.Property<int>("IdDescripcion").HasColumnType("integer").HasColumnName("ID_DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("IdFraccionamiento").HasColumnType("varchar(50)").HasColumnName("ID_FRACCIONAMIENTO");
				b.Property<decimal?>("Longitud").HasColumnType("decimal(18,2)").HasColumnName("LONGITUD");
				b.Property<int?>("Perfil").HasColumnType("integer").HasColumnName("PERFIL");
				b.Property<decimal?>("Peso").HasColumnType("decimal(18,3)").HasColumnName("PESO");
				b.Property<string>("Tolerancia").HasColumnType("varchar(50)").HasColumnName("TOLERANCIA");
				b.HasKey("IdInsumo").HasName("PK_ID_INSUMO");
				b.HasIndex("IdEstado");
				b.ToTable("COMPONENTES_DETALLE", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Compras", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCompra").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_COMPRA");
				b.Property<int>("IdCompra").UseIdentityByDefaultColumn();
				b.Property<DateTime>("FechaHora").HasColumnType("timestamp").HasColumnName("FECHA_HORA");
				b.Property<int>("IdEstadoCompra").HasColumnType("int").HasColumnName("ID_ESTADO_COMPRA");
				b.Property<int>("IdProveedor").HasColumnType("int").HasColumnName("ID_PROVEEDOR");
				b.Property<string>("IdUsuario").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("ID_USUARIO");
				b.Property<decimal>("MontoTotal").HasColumnType("decimal(18,2)").HasColumnName("MONTO_TOTAL");
				b.Property<decimal?>("SaldoPendiente").HasColumnType("decimal(18,2)").HasColumnName("SALDO_PENDIENTE");
				b.HasKey("IdCompra");
				b.HasIndex("IdEstadoCompra");
				b.HasIndex("IdProveedor");
				b.HasIndex("IdUsuario");
				b.ToTable("COMPRAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComprasDetalles", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCompra").HasColumnType("int").HasColumnName("ID_COMPRA");
				b.Property<string>("IdInsumo").HasColumnType("varchar(50)").HasColumnName("ID_INSUMO");
				b.Property<decimal>("Cantidad").HasColumnType("decimal(18,2)").HasColumnName("CANTIDAD");
				b.HasKey("IdCompra", "IdInsumo");
				b.HasIndex("IdInsumo");
				b.ToTable("COMPRAS_DETALLE", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.CuotasCompras", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCuota").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_CUOTA");
				b.Property<int>("IdCuota").UseIdentityByDefaultColumn();
				b.Property<DateTime?>("FechaPago").HasColumnType("timestamp").HasColumnName("FECHA_PAGO");
				b.Property<DateTime>("FechaVencimiento").HasColumnType("timestamp").HasColumnName("FECHA_VENCIMIENTO");
				b.Property<int>("IdCompra").HasColumnType("int").HasColumnName("ID_COMPRA");
				b.Property<int>("IdEstadoCuota").HasColumnType("integer");
				b.Property<decimal>("Monto").HasColumnType("decimal(18,2)").HasColumnName("MONTO");
				b.Property<int>("NumeroCuota").HasColumnType("integer").HasColumnName("NUMERO_CUOTA");
				b.HasKey("IdCuota");
				b.HasIndex("IdCompra");
				b.HasIndex("IdEstadoCuota");
				b.ToTable("CUOTAS_COMPRAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.CuotasVentas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCuota").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_CUOTA");
				b.Property<int>("IdCuota").UseIdentityByDefaultColumn();
				b.Property<DateTime?>("FechaPago").HasColumnType("timestamp").HasColumnName("FECHA_PAGO");
				b.Property<DateTime>("FechaVencimiento").HasColumnType("timestamp").HasColumnName("FECHA_VENCIMIENTO");
				b.Property<int>("IdEstadoCuota").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_CUOTA")
					.HasDefaultValueSql("1");
				b.Property<int>("IdVenta").HasColumnType("int").HasColumnName("ID_VENTA");
				b.Property<decimal>("Monto").ValueGeneratedOnAdd().HasColumnType("decimal(18,2)")
					.HasColumnName("MONTO")
					.HasDefaultValueSql("0.00");
				b.Property<int>("NumeroCuota").HasColumnType("int").HasColumnName("NUMERO_CUOTA");
				b.HasKey("IdCuota");
				b.HasIndex("IdEstadoCuota");
				b.HasIndex("IdVenta");
				b.ToTable("CUOTAS_VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Entidades", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEntidad").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ENTIDAD");
				b.Property<int>("IdEntidad").UseIdentityByDefaultColumn();
				b.Property<string>("Altura").HasColumnType("text").HasColumnName("ALTURA");
				b.Property<string>("Apellido").HasColumnType("text").HasColumnName("APELLIDO");
				b.Property<string>("Barrio").HasColumnType("text").HasColumnName("BARRIO");
				b.Property<string>("Calle").HasColumnType("text").HasColumnName("CALLE");
				b.Property<string>("Ciudad").HasColumnType("text").HasColumnName("CIUDAD");
				b.Property<string>("CodigoPostal").HasColumnType("text").HasColumnName("CODIGO_POSTAL");
				b.Property<string>("Email").HasColumnType("text").HasColumnName("EMAIL");
				b.Property<DateTime>("FechaRegistro").HasColumnType("timestamp").HasColumnName("FECHA_REGISTRO");
				b.Property<int>("IdCategoria").HasColumnType("int").HasColumnName("ID_CATEGORIA");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("(1)");
				b.Property<string>("IdFiscal").IsRequired().HasColumnType("text")
					.HasColumnName("ID_FISCAL");
				b.Property<int>("IdTipo").HasColumnType("int").HasColumnName("ID_TIPO");
				b.Property<string>("IdUsuarioRegistro").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("ID_USUARIO_REGISTRO");
				b.Property<string>("Localidad").HasColumnType("text").HasColumnName("LOCALIDAD");
				b.Property<string>("Nombre").HasColumnType("text").HasColumnName("NOMBRE");
				b.Property<string>("NombreClave").HasColumnType("text").HasColumnName("NOMBRE_CLAVE");
				b.Property<string>("Pais").HasColumnType("text").HasColumnName("PAIS");
				b.Property<string>("Provincia").HasColumnType("text").HasColumnName("PROVINCIA");
				b.Property<string>("Telefono1").HasColumnType("text").HasColumnName("TELEFONO_1");
				b.Property<string>("Telefono2").HasColumnType("text").HasColumnName("TELEFONO_2");
				b.Property<string>("Telefono3").HasColumnType("text").HasColumnName("TELEFONO_3");
				b.HasKey("IdEntidad");
				b.HasIndex("IdCategoria");
				b.HasIndex("IdTipo");
				b.HasIndex("IdUsuarioRegistro");
				b.ToTable("ENTIDADES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesCategorias", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdCategoria").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_CATEGORIA");
				b.Property<int>("IdCategoria").UseIdentityByDefaultColumn();
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("NombreCategoria").IsRequired().HasColumnType("text")
					.HasColumnName("NOMBRE_CATEGORIA");
				b.HasKey("IdCategoria");
				b.ToTable("ENTIDADES_CATEGORIAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesTipos", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdTipo").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_TIPO");
				b.Property<int>("IdTipo").UseIdentityByDefaultColumn();
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("NombreTipo").IsRequired().HasColumnType("text")
					.HasColumnName("NOMBRE");
				b.HasKey("IdTipo");
				b.ToTable("ENTIDADES_TIPOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesTiposCategorias", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("idTipoEntidad").HasColumnType("int").HasColumnName("ID_TIPO");
				b.Property<int>("IdCategoriaEntidad").HasColumnType("int").HasColumnName("ID_CATEGORIA");
				b.HasKey("idTipoEntidad", "IdCategoriaEntidad");
				b.HasIndex("IdCategoriaEntidad");
				b.ToTable("ENTIDADES_TIPOS_CATEGORIAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosArchivosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_ARCHIVOS_MOVIMIENTOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosComponentesDetalles", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_COMPONENTES_DETALLES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCompras", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoCompra").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_COMPRA")
					.HasAnnotation("SqlServer:Identity", "1, 1");
				b.Property<int>("IdEstadoCompra").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").HasColumnType("int").HasColumnName("ID_ESTADO");
				b.HasKey("IdEstadoCompra");
				b.ToTable("ESTADOS_COMPRAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCuotasCompras", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoCuota").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO_CUOTA");
				b.Property<int>("IdEstadoCuota").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.HasKey("IdEstadoCuota");
				b.ToTable("ESTADOS_CUOTAS_COMPRAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCuotasVentas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoCuota").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_CUOTA");
				b.Property<int>("IdEstadoCuota").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.HasKey("IdEstadoCuota");
				b.ToTable("ESTADOS_CUOTAS_VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int?>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_MOVIMIENTO");
				b.Property<int?>("IdEstadoMovimiento").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.HasKey("IdEstadoMovimiento");
				b.ToTable("ESTADOS_MOVIMIENTOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductos", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_PRODUCTOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductosComponentes", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_PRODUCTOS_COMPONENTES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductosDescripciones", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_PRODUCTOS_DESCRIPCIONES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosSuministrosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_SUMINISTROS_MOVIMIENTOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosTiposProductos", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.HasKey("IdEstado");
				b.ToTable("ESTADOS_PRODUCTOS_TIPOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosVentas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdEstadoVenta").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_VENTA");
				b.Property<int>("IdEstadoVenta").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("int")
					.HasDefaultValue(1)
					.HasColumnName("ID_ESTADO");
				b.HasKey("IdEstadoVenta");
				b.ToTable("ESTADOS_VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.MediosPago", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdMedioPago").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_MEDIO_PAGO");
				b.Property<int>("IdMedioPago").UseIdentityByDefaultColumn();
				b.Property<string>("CodigoMPago").HasColumnType("text").HasColumnName("CODIGO_MPAGO");
				b.Property<string>("Descripcion").IsRequired().HasColumnType("text")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("int")
					.HasDefaultValue(1)
					.HasColumnName("ID_ESTADO");
				b.HasKey("IdMedioPago");
				b.ToTable("MEDIOS_PAGO", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PagosCompras", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdPago").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_PAGO")
					.HasColumnOrder(2);
				b.Property<int>("IdPago").UseIdentityByDefaultColumn();
				b.Property<DateTime?>("Fecha").HasColumnType("timestamp").HasColumnName("FECHA");
				b.Property<int>("IdCompra").HasColumnType("int").HasColumnName("ID_COMPRA");
				b.Property<int>("IdMedioPago").HasColumnType("int").HasColumnName("ID_MEDIO_PAGO");
				b.Property<decimal>("Monto").HasColumnType("decimal(18,2)").HasColumnName("SUBTOTAL");
				b.HasKey("IdPago");
				b.HasIndex("IdCompra");
				b.HasIndex("IdMedioPago");
				b.ToTable("PAGOS_COMPRAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PagosVentas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdPago").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_PAGO")
					.HasColumnOrder(2);
				b.Property<int>("IdPago").UseIdentityByDefaultColumn();
				b.Property<DateTime?>("Fecha").HasColumnType("timestamp").HasColumnName("FECHA");
				b.Property<int>("IdMedioPago").HasColumnType("int").HasColumnName("ID_MEDIO_PAGO");
				b.Property<int>("IdVenta").HasColumnType("int").HasColumnName("ID_VENTA");
				b.Property<decimal>("Monto").HasColumnType("decimal(18,2)").HasColumnName("MONTO");
				b.HasKey("IdPago");
				b.HasIndex("IdMedioPago");
				b.HasIndex("IdVenta");
				b.ToTable("PAGOS_VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PerfilesUsuarios", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdPerfil").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_PERFIL");
				b.Property<int>("IdPerfil").UseIdentityByDefaultColumn();
				b.Property<string>("Descripcion").IsRequired().HasColumnType("varchar(100)")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").HasColumnType("integer").HasColumnName("ID_ESTADO");
				b.HasKey("IdPerfil");
				b.ToTable("USUARIOS_PERFILES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Producto", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdProducto").HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("ID_PRODUCTO");
				b.Property<int?>("Cantidad").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("CANTIDAD")
					.HasDefaultValueSql("((0))");
				b.Property<int?>("DiametroNominal").HasColumnType("integer").HasColumnName("DIAMETRO_NOMINAL");
				b.Property<int>("IdDescripcion").HasColumnType("integer").HasColumnName("ID_DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<string>("IdTipo").IsRequired().HasMaxLength(50)
					.IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("ID_TIPO");
				b.Property<decimal?>("PorcentajeGanancia").HasColumnType("decimal(18,2)").HasColumnName("PORCENTAJE_GANANCIA");
				b.Property<decimal?>("PrecioFinal").HasColumnType("decimal(18,2)").HasColumnName("PRECIO_FINAL");
				b.Property<decimal?>("PrecioLista").ValueGeneratedOnAdd().HasColumnType("money")
					.HasColumnName("PRECIO_LISTA")
					.HasDefaultValueSql("((0))");
				b.Property<string>("Tolerancia").HasColumnType("text").HasColumnName("TOLERANCIA");
				b.HasKey("IdProducto");
				b.HasIndex("IdDescripcion");
				b.HasIndex("IdEstado");
				b.HasIndex("IdTipo");
				b.ToTable("PRODUCTOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosDescripcion", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdDescripcion").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_DESCRIPCION");
				b.Property<int>("IdDescripcion").UseIdentityByDefaultColumn();
				b.Property<string>("DescripcionProducto").HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.HasKey("IdDescripcion");
				b.HasIndex("IdEstado");
				b.ToTable("PRODUCTOS_DESCRIPCION", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosTipo", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdTipo").HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnType("character varying(50)")
					.HasColumnName("ID_TIPO");
				b.Property<string>("DescripcionTipo").HasMaxLength(100).IsUnicode(unicode: false)
					.HasColumnType("character varying(100)")
					.HasColumnName("DESCRIPCION");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<int>("IdEstado").UseIdentityByDefaultColumn();
				b.HasKey("IdTipo").HasName("PK_PRODUCTOS_TIPOS");
				b.HasIndex("IdEstado");
				b.ToTable("PRODUCTOS_TIPOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Productos_Componentes", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdProducto").HasColumnType("varchar(50)").HasColumnName("ID_PRODUCTO");
				b.Property<string>("IdComponente").HasColumnType("varchar(50)").HasColumnName("ID_COMPONENTE");
				b.Property<decimal?>("Cantidad").HasColumnType("decimal(18,2)").HasColumnName("CANTIDAD");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.Property<decimal?>("Longitud").HasColumnType("decimal(18,2)").HasColumnName("LONGITUD");
				b.Property<decimal?>("Peso").HasColumnType("decimal(18,2)").HasColumnName("PESO");
				b.HasKey("IdProducto", "IdComponente").HasName("PK_PRODUCTOS_COMPONENTES");
				b.HasIndex("IdEstado");
				b.ToTable("PRODUCTOS_COMPONENTES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Productos_Tipos_Descripcion", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdTipo").HasColumnType("varchar(50)").HasColumnName("ID_TIPO");
				b.Property<int?>("IdDescripcion").HasColumnType("integer").HasColumnName("ID_DESCRIPCION");
				b.HasKey("IdTipo", "IdDescripcion");
				b.HasIndex("IdDescripcion");
				b.ToTable("PRODUCTOS_TIPOS_DESCRIPCION", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.StockInsumos", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("IdInsumo").HasColumnType("varchar(50)").HasColumnName("ID_INSUMO");
				b.Property<decimal?>("Granallado").HasColumnType("decimal").HasColumnName("GRANALLADO");
				b.Property<decimal?>("Moldeado").HasColumnType("decimal").HasColumnName("MOLDEADO");
				b.Property<decimal?>("Pendiente").HasColumnType("decimal(18,2)").HasColumnName("PENDIENTE");
				b.Property<decimal?>("Pintura").HasColumnType("decimal").HasColumnName("PINTURA");
				b.Property<decimal?>("Proceso").HasColumnType("decimal").HasColumnName("PROCESO");
				b.Property<decimal?>("Recibido").HasColumnType("decimal").HasColumnName("RECIBIDO");
				b.HasKey("IdInsumo").HasName("PK_STOCK_INSUMOS");
				b.ToTable("STOCK_INSUMOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Stock_Movimientos", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdMovimiento").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_MOVIMIENTO");
				b.Property<int>("IdMovimiento").UseIdentityByDefaultColumn();
				b.Property<string>("CreadoUsuario").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("USUARIO_CREADO");
				b.Property<string>("Destino").HasColumnType("varchar(50)").HasColumnName("DESTINO");
				b.Property<DateTime>("FechaHoraCreado").HasColumnType("timestamp").HasColumnName("FECHA_HORA_CREADO");
				b.Property<DateTime?>("FechaHoraUltimaModificacion").HasColumnType("timestamp").HasColumnName("FECHA_HORA_ULTIMA_MODIFICACION");
				b.Property<int>("IdEstadoMovimiento").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_ESTADO_MOVIMIENTO")
					.HasDefaultValueSql("1");
				b.Property<int>("IdProveedor").HasColumnType("int").HasColumnName("ID_PROVEEDOR");
				b.Property<string>("ModificadoUsuario").HasColumnType("varchar(50)").HasColumnName("USUARIO_MODIFICA");
				b.Property<string>("Origen").HasColumnType("varchar(50)").HasColumnName("ORIGEN");
				b.Property<string>("Tipo").HasColumnType("varchar(15)").HasColumnName("TIPO");
				b.HasKey("IdMovimiento");
				b.HasIndex("IdEstadoMovimiento");
				b.HasIndex("IdProveedor");
				b.ToTable("STOCK_MOVIMIENTOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.SuministrosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdMovimiento").HasColumnType("int").HasColumnName("ID_MOVIMIENTO");
				b.Property<string>("IdSuministro").HasColumnType("varchar(50)").HasColumnName("ID_SUMINISTRO");
				b.Property<decimal>("Cantidad").HasColumnType("decimal(18,2)").HasColumnName("CANTIDAD");
				b.Property<int>("IdEstado").ValueGeneratedOnAdd().HasColumnType("integer")
					.HasColumnName("ID_ESTADO")
					.HasDefaultValueSql("1");
				b.HasKey("IdMovimiento", "IdSuministro");
				b.HasIndex("IdEstado");
				b.ToTable("SUMINISTROS_MOVIMIENTOS_STOCK", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Usuarios", delegate(EntityTypeBuilder b)
			{
				b.Property<string>("Usuario").HasColumnType("varchar(50)").HasColumnName("USUARIO");
				b.Property<string>("Contraseña").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("CONTRASEÑA");
				b.Property<string>("Correo").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("CORREO");
				b.Property<int>("IdPerfil").HasColumnType("int").HasColumnName("ID_PERFIL");
				b.HasKey("Usuario");
				b.HasIndex("IdPerfil");
				b.ToTable("USUARIOS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Ventas", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdVenta").ValueGeneratedOnAdd().HasColumnType("int")
					.HasColumnName("ID_VENTA");
				b.Property<int>("IdVenta").UseIdentityByDefaultColumn();
				b.Property<DateTime>("FechaHora").HasColumnType("timestamp").HasColumnName("FECHA_HORA");
				b.Property<int>("IdCliente").HasColumnType("int").HasColumnName("ID_CLIENTE");
				b.Property<int>("IdEstadoVenta").HasColumnType("int").HasColumnName("ID_ESTADO_VENTA");
				b.Property<string>("IdUsuario").IsRequired().HasColumnType("varchar(50)")
					.HasColumnName("ID_USUARIO");
				b.Property<decimal>("MontoTotal").HasColumnType("decimal(18,2)").HasColumnName("MONTO_TOTAL");
				b.Property<decimal?>("SaldoPendiente").HasColumnType("numeric").HasColumnName("SALDO_PENDIENTE");
				b.HasKey("IdVenta");
				b.HasIndex("IdCliente");
				b.HasIndex("IdEstadoVenta");
				b.HasIndex("IdUsuario");
				b.ToTable("VENTAS", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.VentasDetalles", delegate(EntityTypeBuilder b)
			{
				b.Property<int>("IdVenta").HasColumnType("int").HasColumnName("ID_VENTA");
				b.Property<string>("IdProducto").HasColumnType("varchar(50)").HasColumnName("ID_PRODUCTO");
				b.Property<decimal>("Cantidad").HasColumnType("decimal(18,2)").HasColumnName("CANTIDAD");
				b.Property<int?>("Entregados").HasColumnType("integer").HasColumnName("ENTREGADOS");
				b.Property<decimal>("Precio").HasColumnType("decimal(18,2)").HasColumnName("PRECIO");
				b.HasKey("IdVenta", "IdProducto");
				b.HasIndex("IdProducto");
				b.ToTable("VENTAS_DETALLES", (string?)null);
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ArchivosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosArchivosMovimientosStock", "ArchivosMovimientosStockNavigation").WithMany("ArchivosMovimientoStock").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Stock_Movimientos", "StockMovimiento").WithMany().HasForeignKey("IdMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_ARCHIVOS_STOCK_STOCK_MOVIMIENTOS_ID_MOVIMIENTO");
				b.Navigation("ArchivosMovimientosStockNavigation");
				b.Navigation("StockMovimiento");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComponentesDetalle", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosComponentesDetalles", "IdEstadoNavigation").WithMany("ComponentesDetalle").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdEstadoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Compras", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosCompras", "Estado").WithMany("compras").HasForeignKey("IdEstadoCompra")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_COMPRAS_ESTADOS_COMPRAS_ID_ESTADO_COMPRA");
				b.HasOne("Aponus_Web_API.Modelos.Entidades", "IdProveedorNavigation").WithMany("compras").HasForeignKey("IdProveedor")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Usuarios", "Usuario").WithMany("Compras").HasForeignKey("IdUsuario")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired()
					.HasConstraintName("FK_COMPRAS_USUARIOS_IDUSUARIO");
				b.Navigation("Estado");
				b.Navigation("IdProveedorNavigation");
				b.Navigation("Usuario");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComprasDetalles", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Compras", "Compra").WithMany("DetallesCompra").HasForeignKey("IdCompra")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.ComponentesDetalle", "DetallesInsumo").WithMany("ComprasNavigation").HasForeignKey("IdInsumo")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("Compra");
				b.Navigation("DetallesInsumo");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.CuotasCompras", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Compras", "CompraNavigation").WithMany("CuotasCompra").HasForeignKey("IdCompra")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_CUOTAS_COMPRAS_COMPRAS_ID_COMPRA");
				b.HasOne("Aponus_Web_API.Modelos.EstadosCuotasCompras", "EstadoCuotaCompra").WithMany("IdEstadoCuotaNavigation").HasForeignKey("IdEstadoCuota")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_CUOTAS_COMPRAS_ESTADOS_CUOTAS_COMPRAS_ID_ESTADO_CUOTA");
				b.Navigation("CompraNavigation");
				b.Navigation("EstadoCuotaCompra");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.CuotasVentas", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosCuotasVentas", "EstadoCuota").WithMany("IdEstadoCuotaNavigation").HasForeignKey("IdEstadoCuota")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Ventas", "Venta").WithMany("Cuotas").HasForeignKey("IdVenta")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("EstadoCuota");
				b.Navigation("Venta");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Entidades", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EntidadesCategorias", "CategoriaEntidad").WithMany("Entidades").HasForeignKey("IdCategoria")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.EntidadesTipos", "TipoEntidad").WithMany("Entidades").HasForeignKey("IdTipo")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Usuarios", "UsuarioRegistro").WithMany("IdUsuarioRegistroNavigation").HasForeignKey("IdUsuarioRegistro")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("CategoriaEntidad");
				b.Navigation("TipoEntidad");
				b.Navigation("UsuarioRegistro");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesTiposCategorias", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EntidadesCategorias", "CategoriaEntidad").WithMany("TiposCategoriasNavigation").HasForeignKey("IdCategoriaEntidad")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.EntidadesTipos", "TipoEntidad").WithMany("TiposCategoriasNavigation").HasForeignKey("idTipoEntidad")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("CategoriaEntidad");
				b.Navigation("TipoEntidad");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PagosCompras", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Compras", "Compra").WithMany("Pagos").HasForeignKey("IdCompra")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.MediosPago", "MedioPago").WithMany("PagosComprasNavigation").HasForeignKey("IdMedioPago")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("Compra");
				b.Navigation("MedioPago");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PagosVentas", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.MediosPago", "MedioPago").WithMany("PagosVentasNavigation").HasForeignKey("IdMedioPago")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Ventas", "Venta").WithMany("Pagos").HasForeignKey("IdVenta")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("MedioPago");
				b.Navigation("Venta");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Producto", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.ProductosDescripcion", "IdDescripcionNavigation").WithMany("Productos").HasForeignKey("IdDescripcion")
					.IsRequired()
					.HasConstraintName("FK_PRODUCTOS_PRODUCTOS_DESCRIPCION");
				b.HasOne("Aponus_Web_API.Modelos.EstadosProductos", "IdEstadoNavigation").WithMany("Productos").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.ProductosTipo", "IdTipoNavigation").WithMany("Productos").HasForeignKey("IdTipo")
					.IsRequired()
					.HasConstraintName("FK_PRODUCTOS_PRODUCTOS_TIPOS");
				b.Navigation("IdDescripcionNavigation");
				b.Navigation("IdEstadoNavigation");
				b.Navigation("IdTipoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosDescripcion", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosProductosDescripciones", "IdEstadoNavigation").WithMany("ProductosDescripcions").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdEstadoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosTipo", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosTiposProductos", "IdEstadoNavigation").WithMany("ProductosTipos").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdEstadoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Productos_Componentes", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosProductosComponentes", "IdEstadoNavigation").WithMany("ProductosComponentes").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdEstadoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Productos_Tipos_Descripcion", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.ProductosDescripcion", "IdDescripcionNavigation").WithMany("Producto_Tipo_Descripcione").HasForeignKey("IdDescripcion")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired()
					.HasConstraintName("FK_PRODUCTOS_TIPOS_DESCRIPCION_ID_DESCRIPCION");
				b.HasOne("Aponus_Web_API.Modelos.ProductosTipo", "IdTipoNavigation").WithMany("Producto_Tipo_Descripcione").HasForeignKey("IdTipo")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired()
					.HasConstraintName("FK_PRODUCTOS_TIPOS_DESCRIPCION_ID_TIPO");
				b.Navigation("IdDescripcionNavigation");
				b.Navigation("IdTipoNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Stock_Movimientos", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosMovimientosStock", "estadoMovimiento").WithMany("movimientosStock").HasForeignKey("IdEstadoMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Entidades", "Proveeedor").WithMany("Movimientos").HasForeignKey("IdProveedor")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_STOCK_MOVIMIENTOS_ENTIDADES_ID_PROVEEDOR_DESTINO");
				b.Navigation("Proveeedor");
				b.Navigation("estadoMovimiento");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.SuministrosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.EstadosSuministrosMovimientosStock", "EstadosSuministrosMovimientosStockNavigation").WithMany("SuministrosMovimientoStock").HasForeignKey("IdEstado")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_SUMINISTROS_MOVIMIENTOS_STOCK_ESTADOS_SUMINISTROS_MOVIMIENTO");
				b.HasOne("Aponus_Web_API.Modelos.Stock_Movimientos", null).WithMany("Suministros").HasForeignKey("IdMovimiento")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("EstadosSuministrosMovimientosStockNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Usuarios", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.PerfilesUsuarios", "Perfil").WithMany("UsuariosNavigation").HasForeignKey("IdPerfil")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_USUARIOS_PERFILES_USUARIOS_ID_PERFIL");
				b.Navigation("Perfil");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Ventas", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Entidades", "Cliente").WithMany("ventas").HasForeignKey("IdCliente")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.EstadosVentas", "Estado").WithMany("ventas").HasForeignKey("IdEstadoVenta")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.HasOne("Aponus_Web_API.Modelos.Usuarios", "Usuario").WithMany("Ventas").HasForeignKey("IdUsuario")
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired();
				b.Navigation("Cliente");
				b.Navigation("Estado");
				b.Navigation("Usuario");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.VentasDetalles", delegate(EntityTypeBuilder b)
			{
				b.HasOne("Aponus_Web_API.Modelos.Producto", "IdProductoNavigation").WithMany("Ventas").HasForeignKey("IdProducto")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired()
					.HasConstraintName("FK_VENTAS_DETALLES_PRODUCTOS_ID_PRODUCTO");
				b.HasOne("Aponus_Web_API.Modelos.Ventas", "Venta").WithMany("DetallesVenta").HasForeignKey("IdVenta")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
				b.Navigation("IdProductoNavigation");
				b.Navigation("Venta");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ComponentesDetalle", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ComprasNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Compras", delegate(EntityTypeBuilder b)
			{
				b.Navigation("CuotasCompra");
				b.Navigation("DetallesCompra");
				b.Navigation("Pagos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Entidades", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Movimientos");
				b.Navigation("compras");
				b.Navigation("ventas");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesCategorias", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Entidades");
				b.Navigation("TiposCategoriasNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EntidadesTipos", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Entidades");
				b.Navigation("TiposCategoriasNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosArchivosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ArchivosMovimientoStock");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosComponentesDetalles", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ComponentesDetalle");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCompras", delegate(EntityTypeBuilder b)
			{
				b.Navigation("compras");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCuotasCompras", delegate(EntityTypeBuilder b)
			{
				b.Navigation("IdEstadoCuotaNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosCuotasVentas", delegate(EntityTypeBuilder b)
			{
				b.Navigation("IdEstadoCuotaNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Navigation("movimientosStock");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductos", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Productos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductosComponentes", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ProductosComponentes");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosProductosDescripciones", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ProductosDescripcions");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosSuministrosMovimientosStock", delegate(EntityTypeBuilder b)
			{
				b.Navigation("SuministrosMovimientoStock");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosTiposProductos", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ProductosTipos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.EstadosVentas", delegate(EntityTypeBuilder b)
			{
				b.Navigation("ventas");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.MediosPago", delegate(EntityTypeBuilder b)
			{
				b.Navigation("PagosComprasNavigation");
				b.Navigation("PagosVentasNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.PerfilesUsuarios", delegate(EntityTypeBuilder b)
			{
				b.Navigation("UsuariosNavigation");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Producto", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Ventas");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosDescripcion", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Producto_Tipo_Descripcione");
				b.Navigation("Productos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.ProductosTipo", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Producto_Tipo_Descripcione");
				b.Navigation("Productos");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Stock_Movimientos", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Suministros");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Usuarios", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Compras");
				b.Navigation("IdUsuarioRegistroNavigation");
				b.Navigation("Ventas");
			});
			modelBuilder.Entity("Aponus_Web_API.Modelos.Ventas", delegate(EntityTypeBuilder b)
			{
				b.Navigation("Cuotas");
				b.Navigation("DetallesVenta");
				b.Navigation("Pagos");
			});
		}
	}
}
namespace Aponus_Web_API.Controllers
{
	[Route("Aponus/[Controller]")]
	[ApiController]
	public class BINServicesController : Controller
	{
		[HttpGet]
		[Route("GetCardInfo/{BIN}")]
		public async Task<IActionResult> ObtenerInformacionTarjeta(string BIN)
		{
			if (BIN.Length < 6)
			{
				return new JsonResult("Faltan Datos");
			}
			return await new UTL_IdentificacionesBancarias().ObtenerDatosTarjeta(BIN);
		}
	}
	[Route("Aponus/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly BS_Categorias BsCategorias;

		public CategoriesController(BS_Categorias _BsCategorias)
		{
			BsCategorias = _BsCategorias;
		}

		[HttpGet]
		[Route("Products/Types/List")]
		public async Task<JsonResult> ListarTiposProductos()
		{
			return await BsCategorias.MapearTiposProductosDTO();
		}

		[HttpGet]
		[Route("Products/Descriptions/List/{idTipo}")]
		public async Task<IActionResult> ListarDescripcionesProductos(string IdTipo)
		{
			return await BsCategorias.MapearDescripcionesProductosDTO(IdTipo);
		}

		[HttpPost]
		[Route("Products/Types/New")]
		public JsonResult AgregarTipoProducto(DTOCategorias NuevaCategoria)
		{
			try
			{
				return BsCategorias.NormalizarNombreTipoProducto(NuevaCategoria);
			}
			catch (Exception ex)
			{
				return new JsonResult(ex.Message);
			}
		}

		[HttpPost]
		[Route("Products/Types/{TypeId}/Delete/")]
		public async Task<IActionResult> EliminarTipoProducto(string IdTipo)
		{
			try
			{
				return await BsCategorias.RegistrarCambioEstadoTipoProducto(IdTipo);
			}
			catch (Exception ex2)
			{
				Exception ex = ex2;
				return new JsonResult(ex.Message);
			}
		}

		[HttpPost]
		[Route("Products/Descriptions/New")]
		public async Task<IActionResult> NuevaDescripcionProducto(DTOCategorias NuevaCategoria)
		{
			try
			{
				return await BsCategorias.NormalizarDescripcionProducto(NuevaCategoria);
			}
			catch (Exception ex2)
			{
				Exception ex = ex2;
				return new ContentResult
				{
					Content = (ex.InnerException?.Message ?? ex.Message),
					ContentType = "application/json",
					StatusCode = 400
				};
			}
		}

		[HttpPost]
		[Route("Products/Descriptions/{IdDescription}/Delete/")]
		public async Task<IActionResult> EliminarDescripcionProducto(int IdDescription)
		{
			return await BsCategorias.RegistrarCambioEstadoDescripcionProducto(IdDescription);
		}

		[HttpPost]
		[Route("Products/Type-or-Description/Update")]
		public IActionResult Actualizar_Tipo_Descripcion_Producto(DTOActualizarCategorias ActualizarCategorias)
		{
			try
			{
				return BsCategorias.ValidarOperacionActualizacion(ActualizarCategorias);
			}
			catch (DbUpdateException ex)
			{
				string value = ex.InnerException?.Message ?? ex.Message;
				return new JsonResult(value);
			}
		}

		[HttpGet]
		[Route("Supplies/Descriptions/List")]
		public IActionResult ListarNombreComponentes()
		{
			return BsCategorias.MapearNombresComponentesDTO();
		}

		[HttpPost]
		[Route("Supplies/Descriptions/Save")]
		public async Task<IActionResult> GuardarDescripcionComponente(DTODescripcionComponentes Componente)
		{
			return await BsCategorias.MapeoComponenteBD(Componente);
		}
	}
	[Route("Aponus/[Controller]")]
	[ApiController]
	public class ComponentsController : Controller
	{
		private readonly BS_Componentes _BsComponents;

		public ComponentsController(BS_Componentes BsComponents)
		{
			_BsComponents = BsComponents;
		}

		[HttpGet]
		[Route("FetchUnities/{IdNombreComponente?}")]
		public async Task<IActionResult> ObtenerAlmacenamientoComponentes(int? IdNombreComponente)
		{
			return await _BsComponents.MapeoDetalleNombreComponenteDTO(IdNombreComponente);
		}

		[HttpGet]
		[Route("GetProperties")]
		public IActionResult ObtenerPropsComponentes()
		{
			try
			{
				return _BsComponents.ObtenerPropsComponentes();
			}
			catch (DbUpdateException ex)
			{
				string value = ex.InnerException?.Message ?? ex.Message;
				return new JsonResult(value);
			}
		}

		[HttpGet]
		[Route("List/{IdDescripcion?}")]
		public async Task<IActionResult> ObtenerListarComponentes(int? IdDescripcion)
		{
			return await _BsComponents.MapeoComponentesDetalleDTO(IdDescripcion);
		}
	}
	[ApiController]
	[Route("Aponus/[Controller]")]
	public class EndpointsController : ControllerBase
	{
		private readonly EndpointDataSource _endpointDataSource;

		public EndpointsController(EndpointDataSource endpointDataSource)
		{
			_endpointDataSource = endpointDataSource;
		}

		[HttpGet]
		[Route("Get")]
		public IEnumerable<object> Get()
		{
			IReadOnlyList<Endpoint> endpoints = _endpointDataSource.Endpoints;
			return from e in endpoints.Select(delegate(Endpoint endpoint)
				{
					if (endpoint is RouteEndpoint routeEndpoint)
					{
						IReadOnlyList<string> readOnlyList = routeEndpoint.Metadata.GetMetadata<HttpMethodMetadata>()?.HttpMethods;
						return new
						{
							Tipo = ((readOnlyList != null) ? string.Join(", ", readOnlyList) : "N/A"),
							URL = routeEndpoint.RoutePattern.RawText
						};
					}
					return (global::_003C_003Ef__AnonymousType18<string, string>)null;
				})
				where e != null
				select e;
		}
	}
	[Route("Aponus/[Controller]")]
	[ApiController]
	public class EntitiesController : ControllerBase
	{
		private readonly BS_Entidades BSEntidades;

		public EntitiesController(BS_Entidades bSEntidades)
		{
			BSEntidades = bSEntidades;
		}

		[HttpGet]
		[Route("Types/List")]
		public async Task<IActionResult> ListarTiposEntidades()
		{
			return await BSEntidades.TiposEntidades().MapeoTiposEntidadesDTO();
		}

		[HttpPost]
		[Route("Types/Save")]
		public async Task<IActionResult> Guardar(DTOEntidadesTipos TipoEntidad)
		{
			if (string.IsNullOrEmpty(TipoEntidad.Nombre))
			{
				return new ContentResult
				{
					Content = "El nombre no puede ser nulo",
					ContentType = "application/json",
					StatusCode = 400
				};
			}
			return await BSEntidades.TiposEntidades().MapeoDTOTipoEntidadDB(TipoEntidad);
		}

		[HttpGet]
		[Route("Categories/List/{IdTipo?}")]
		public async Task<IActionResult> ListarCategoriasEntidades(int? IdTipo)
		{
			return await BSEntidades.CategoriasEntidades().MapeoEntidadesCategoriasDTO(IdTipo);
		}

		[HttpPost]
		[Route("Categories/Save")]
		public async Task<IActionResult> GuardarCategoria(DTOEntidadesCategorias NuevaCategoria)
		{
			if (string.IsNullOrEmpty(NuevaCategoria.NombreCategoria))
			{
				return new ContentResult
				{
					Content = "El nombre no puede ser nulo",
					ContentType = "application/json",
					StatusCode = 400
				};
			}
			if (!NuevaCategoria.IdTipo.HasValue)
			{
				return new ContentResult
				{
					Content = "Se debe especificar el Tipo",
					ContentType = "application/json",
					StatusCode = 400
				};
			}
			return await BSEntidades.CategoriasEntidades().MapeoNuevaCategoriaDB(NuevaCategoria);
		}

		[HttpPost]
		[Route("Categories/Delete/{Id}")]
		public async Task<IActionResult> EliminarCategoria(int Id)
		{
			return await BSEntidades.CategoriasEntidades().ValidarCategoria(Id);
		}

		[HttpPost]
		[Route("Types/Delete/{Id}")]
		public async Task<IActionResult> EliminarTipo(int Id)
		{
			return await BSEntidades.TiposEntidades().ValidarTipoEntidad(Id);
		}

		[HttpPost]
		[Route("Save")]
		public IActionResult Nuevo(DTOEntidades Entidad)
		{
			return BSEntidades.ValidaryNormalizarDatos(Entidad);
		}

		[HttpGet]
		[Route("List/{typeId=0}/{CategoryId=0}/{EntityId=0}")]
		public IActionResult Listar(int TypeId, int CategoryId, int EntityId)
		{
			return BSEntidades.MapeoEntidadesDTO(TypeId, CategoryId, EntityId);
		}

		[HttpPost]
		[Route("Delete/{Id}")]
		public async Task<IActionResult> Eliminar(int Id)
		{
			return await BSEntidades.ValidarEntidad(Id);
		}
	}
	[Route("Aponus/[Controller]")]
	[ApiController]
	public class GeoNamesController : ControllerBase
	{
		[HttpGet]
		[Route("Countries")]
		public async Task<IActionResult> ListarPaises()
		{
			return await new NombresGeograficos().ListarPaises();
		}

		[HttpGet]
		[Route("Provinces_States/{geonameId}")]
		public async Task<IActionResult> ListarProvincias(int geonameId)
		{
			return await new NombresGeograficos().ListarProvincias(geonameId);
		}

		[HttpGet]
		[Route("Cities/{countryCode}/{adminCode1}")]
		public async Task<IActionResult> ListarProvincias(string countryCode, string adminCode1)
		{
			return await new NombresGeograficos().ListarCiudades(countryCode, adminCode1);
		}
	}
	[Route("Aponus/[Controller]")]
	[ApiController]
	public class MovmentsController : Controller
	{
		private readonly BS_Movimientos BsMovimientos;

		public MovmentsController(BS_Movimientos bsMovimientos)
		{
			BsMovimientos = bsMovimientos;
		}

		[HttpPost]
		[Route("New")]
		public IActionResult NuevoMovimiento([FromForm] DTOMovimientosStock Actualizacion)
		{
			try
			{
				return BsMovimientos.ProcesarDatosMovimiento(Actualizacion);
			}
			catch (Exception)
			{
				return new ContentResult
				{
					Content = "Error interno, no se aplicaron los cambios",
					ContentType = "Aplication/Json",
					StatusCode = 500
				};
			}
		}

		[HttpGet]
		[Route("List")]
		public async Task<IActionResult> Listar(UTL_FiltrosMovimientos? Filtros)
		{
			return await BsMovimientos.Listar(Filtros);
		}

		[HttpPost]
		[Route("{IdMovimiento}/Delete")]
		public IActionResult EliminarMovimiento(int IdMovimiento)
		{
			return BsMovimientos.Eliminar(IdMovimiento);
		}

		[HttpPost]
		[Route("Files/Delete")]
		public IActionResult EliminarArchivo(DTOMovimientosStock Archivos)
		{
			return BsMovimientos.ArchivosMovimientos().Eliminar(Archivos);
		}

		[HttpPost]
		[Route("Files/New")]
		public async Task<IActionResult> AgregarArchivo([FromForm] DTOMovimientosStock Archivos)
		{
			return await BsMovimientos.ArchivosMovimientos().Agregar(Archivos);
		}

		[HttpPut]
		[Route("Update")]
		public IActionResult ActualizarProveedor(DTOMovimientosStock Movimiento)
		{
			return BsMovimientos.Actualizar(Movimiento);
		}

		[HttpPost]
		[Route("Supplies/Update")]
		public IActionResult ActualizarInsumos(DTOMovimientosStock Movimiento)
		{
			if (!Movimiento.IdMovimiento.HasValue)
			{
				return new ContentResult
				{
					Content = "No se encontró el valor 'ID_MOVIMIENTO'\n No se aplicaron los cambios",
					ContentType = "Aplication/Json",
					StatusCode = 400
				};
			}
			return BsMovimientos.ActualizarSuministros(Movimiento);
		}

		[HttpGet]
		[Route("States/List")]
		public IActionResult ListarEstados()
		{
			return BsMovimientos.EstadosMovimientos().Listar();
		}

		[HttpPost]
		[Route("States/Save")]
		public async Task<IActionResult> NuevoEstado(DTOEstadosMovimientosStock Estado)
		{
			if (string.IsNullOrEmpty(Estado.Descripcion))
			{
				return new ContentResult
				{
					Content = "Ingresar el Estado",
					ContentType = "Aplication/Json",
					StatusCode = 400
				};
			}
			return await BsMovimientos.EstadosMovimientos().Guardar(Estado);
		}
	}
	[Route("Aponus/[Controller]")]
	[ApiController]
	public class ProductsController : Controller
	{
		private readonly BS_Productos BsProductos;

		public ProductsController(BS_Productos _BSProductos)
		{
			BsProductos = _BSProductos;
		}

		[HttpGet]
		[Route("List/{TypeId}/{IdDescription?}")]
		public JsonResult ListProducts(string TypeId, int? IdDescription)
		{
			try
			{
				return BsProductos.ListarProductos(TypeId, IdDescription);
			}
			catch (Exception)
			{
				throw;
			}
		}

		[HttpGet]
		[Route("ListProducts")]
		public JsonResult ListProducts()
		{
			try
			{
				return BsProductos.ListarProductos();
			}
			catch (Exception data)
			{
				return Json(data);
			}
		}

		[HttpPost]
		[Route("NewListComponents")]
		public JsonResult NewListComponents(DTOProducto Producto)
		{
			try
			{
				return BsProductos.NewListarComponentesProducto(Producto);
			}
			catch (Exception data)
			{
				return Json(data);
			}
		}

		[HttpGet]
		[Route("ListDN/{TypeId}")]
		public async Task<JsonResult> ListarDN(string? TypeId)
		{
			try
			{
				return await BsProductos.ListarDN(TypeId);
			}
			catch (Exception)
			{
				throw;
			}
		}

		[HttpGet]
		[Route("ListDN/{TypeId}/{IdDescription}")]
		public async Task<JsonResult> ListarDN(string? TypeId, int? IdDescription)
		{
			try
			{
				return await BsProductos.ListarDN(TypeId, IdDescription);
			}
			catch (Exception)
			{
				throw;
			}
		}

		[HttpPost]
		[Route("Save")]
		public IActionResult Guardar(DTOProducto Producto)
		{
			try
			{
				return BsProductos.ProcesarDatos(Producto);
			}
			catch (DbUpdateException ex)
			{
				string value = ex.InnerException?.Message ?? ex.Message;
				return new JsonResult(value);
			}
		}

		[HttpPost]
		[Route("Components/Save")]
		public IActionResult ActualizarComponentes(List<DTOComponentesProducto> Producto)
		{
			try
			{
				return BsProductos.ActualizarComponentes(Producto);
			}
			catch (DbUpdateException ex)
			{
				return new ContentResult
				{
					Content = (ex.InnerException?.Message ?? ex.Message),
					ContentType = "application/json",
					StatusCode = 400
				};
			}
		}
	}
	[Route("Aponus/[Controller]")]
	[ApiController]
	public class PurchaseController : Controller
	{
		private readonly BS_Compras BsCompras;

		public PurchaseController(BS_Compras bsCompras)
		{
			BsCompras = bsCompras;
		}

		[HttpPost]
		[Route("Save")]
		public async Task<IActionResult> NuevaCompra(DTOCompras Compras)
		{
			return await BsCompras.ProcesarDatosCompra(Compras);
		}

		[HttpGet]
		[Route("List")]
		public async Task<IActionResult> Listar(UTL_FiltrosComprasVentas? Filtros)
		{
			return await BsCompras.Listar(Filtros);
		}

		[HttpPost]
		[Route("Billings/New")]
		public async Task<IActionResult> RegistrarPago(DTOPagosCompras Pago)
		{
			return await BsCompras.RegistrarPago(Pago);
		}
	}
	[Route("Aponus/[Controller]")]
	[ApiController]
	public class SalesController : Controller
	{
		private readonly BS_Ventas BsVentas;

		public SalesController(BS_Ventas bsVentas)
		{
			BsVentas = bsVentas;
		}

		[HttpGet]
		[Route("List")]
		public IActionResult List(UTL_FiltrosComprasVentas? Filtros)
		{
			return BsVentas.Filtrar(Filtros);
		}

		[HttpGet]
		[Route("Quotation")]
		public IActionResult GenerarCuotas(UTL_ParametrosCuotas Parametros)
		{
			try
			{
				ICollection<DTOCuotasVentas> value = BS_Ventas.CalcularCuotas(Parametros);
				return new JsonResult(value);
			}
			catch (Exception ex)
			{
				return new ContentResult
				{
					Content = (ex.InnerException?.Message ?? ex.Message),
					ContentType = "application/json",
					StatusCode = 400
				};
			}
		}

		[HttpPost]
		[Route("States/Save")]
		public async Task<IActionResult> GuardarEstadoVenta(DTOEstadosVentas Estados)
		{
			return await BsVentas.EstadosVentas().ValidarDatos(Estados);
		}

		[HttpPost]
		[Route("States/{Id}/Delete")]
		public IActionResult EliminarEstadoVenta(int Id)
		{
			return BsVentas.EstadosVentas().Eliminar(Id);
		}

		[HttpPost]
		[Route("Save")]
		public async Task<IActionResult> Guardar(DTOVentas Venta)
		{
			if (Venta.MontoTotal.Equals(0m))
			{
				return new ContentResult
				{
					Content = "El valor de la venta no puede ser 0.00",
					ContentType = "Application/Json",
					StatusCode = 400
				};
			}
			try
			{
				return await BsVentas.ProcesarDatosVenta(Venta);
			}
			catch (Exception ex)
			{
				return new ContentResult
				{
					Content = (ex.InnerException?.Message ?? ex.Message),
					ContentType = "applcation/json",
					StatusCode = 400
				};
			}
		}
	}
	[Route("Aponus/[Controller]")]
	[ApiController]
	public class StocksController : Controller
	{
		private readonly BS_Stocks BsStocks;

		public StocksController(BS_Stocks bsStocks)
		{
			BsStocks = bsStocks;
		}

		[HttpGet]
		[Route("Supplies/List/{idDescription?}")]
		public IActionResult NewListar(int? idDescription)
		{
			return BsStocks.ObtenerDatosInsumos(idDescription);
		}

		[HttpGet]
		[Route("Products/List/{TypeId}/{IdDescription}")]
		public JsonResult ListProducts(string TypeId, int IdDescription)
		{
			try
			{
				return BsStocks.ListarProductos(TypeId, IdDescription);
			}
			catch (Exception)
			{
				throw;
			}
		}

		[HttpPost]
		[Route("Supplies/Update")]
		public async Task<IActionResult> Actualizar(DTOStock StockInsumo)
		{
			return await BsStocks.OperacionesStockInsumos().Actualizar(StockInsumo);
		}

		[HttpPost]
		[Route("Products/Update")]
		public async Task<IActionResult> Actualizar(DTOStockProductos StockProducto)
		{
			return await BsStocks.OperacionesStockProductos().Actualizar(StockProducto);
		}

		[HttpPost]
		[Route("Products/Increment")]
		public async Task<IActionResult> Incrementar(DTOProducto Producto)
		{
			return await BsStocks.OperacionesStockProductos().Incrementar(Producto);
		}
	}
	[Route("Aponus/[Controller]")]
	[ApiController]
	public class SuppliesController : Controller
	{
		private readonly BS_Suministros BsSupplies;

		private readonly BS_Componentes BsComponents;

		public SuppliesController(BS_Suministros bsSupplies, BS_Componentes bsComponents)
		{
			BsSupplies = bsSupplies;
			BsComponents = bsComponents;
		}

		[HttpGet]
		[Route("new-id/{sypplyName}/")]
		public JsonResult GenerarIdInsumo(string? sypplyName)
		{
			try
			{
				return BsSupplies.ObtenerNuevoIdComponente(sypplyName);
			}
			catch (Exception ex)
			{
				string value = ex.InnerException?.Message ?? ex.Message;
				return new JsonResult(value);
			}
		}

		[HttpGet]
		[Route("ListFormatted")]
		public IActionResult ListarInsumosFormateados()
		{
			return BsSupplies.ListarNombresFormateados();
		}

		[HttpPost]
		[Route("Create-or-Update")]
		public IActionResult ObtenerPropsComponentes(DTODetallesComponenteProducto InsumoProducto)
		{
			try
			{
				return BsSupplies.GuardarInsumoProducto(InsumoProducto);
			}
			catch (DbUpdateException ex)
			{
				string message = ex.InnerException.Message;
				return new JsonResult(message);
			}
		}

		[HttpPost]
		[Route("ListProp")]
		public JsonResult? Listar(DTODetallesComponenteProducto Especificaciones)
		{
			return BsComponents.DeterminarProp(Especificaciones);
		}

		[HttpGet]
		[Route("GetId")]
		public JsonResult? ObtenerId(DTODetallesComponenteProducto Especificaciones)
		{
			return BsComponents.ObtenerIdComponente(Especificaciones);
		}

		[HttpPost]
		[Route("SaveProductComponents")]
		public IActionResult? GuardarComponentesProducto(List<DTOComponentesProducto> ComponentesProd)
		{
			return BsComponents.GuardarComponentesProducto(ComponentesProd);
		}
	}
	[Route("Aponus/[Controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly SS_Usuarios _Usuarios;

		public UsersController(SS_Usuarios usuarios)
		{
			_Usuarios = usuarios;
		}

		[HttpPost]
		[Route("Validation")]
		public DTOUsuarios? ValiadarUsuario(DTOUsuarios Usuario)
		{
			return _Usuarios.ValidarUsuario(Usuario);
		}

		[HttpPost]
		[Route("New")]
		public async Task<IActionResult> Nuevo(DTOUsuarios Usuario)
		{
			if (string.IsNullOrEmpty(Usuario.Usuario) || string.IsNullOrEmpty(Usuario.Contraseña) || !Usuario.IdPerfil.HasValue)
			{
				return new ContentResult
				{
					Content = "Faltan Datos",
					ContentType = "application/json",
					StatusCode = 400
				};
			}
			return await _Usuarios.NuevoUsuario(Usuario);
		}
	}
}
namespace Aponus_Web_API.Acceso_a_Datos
{
	public class AD_Categorias
	{
		public class Productos
		{
			private readonly AponusContext AponusDBContext;

			public Productos(AponusContext aponusDBContext)
			{
				AponusDBContext = aponusDBContext;
			}

			internal async Task<List<ProductosTipo>?> ListarTiposProductos()
			{
				return await (from x in AponusDBContext.ProductosTipos
					orderby x.DescripcionTipo
					where x.IdEstado != 0
					select new ProductosTipo
					{
						IdTipo = x.IdTipo,
						DescripcionTipo = x.DescripcionTipo,
						IdEstado = x.IdEstado
					}).ToListAsync();
			}

			public async Task<(int? resultado, Exception? error)> DesactivarTipoProductoyRelaciones(ProductosTipo TipoProducto)
			{
				ProductosTipo TipoProducto2 = TipoProducto;
				IDbContextTransaction Transaccion = await AponusDBContext.Database.BeginTransactionAsync();
				try
				{
					AponusDBContext.ProductosTipos.Update(TipoProducto2);
					List<int?> IdDescripcionesEliminar = await (from x in AponusDBContext.Producto_Tipo_Descripcion
						where x.IdTipo.Equals(TipoProducto2.IdTipo)
						select x.IdDescripcion).ToListAsync();
					List<ProductosDescripcion> DescripcionProdEliminar = await AponusDBContext.ProductosDescripcions.Where((ProductosDescripcion x) => IdDescripcionesEliminar.Contains(x.IdDescripcion)).ToListAsync();
					if (DescripcionProdEliminar != null)
					{
						DescripcionProdEliminar?.ForEach(delegate(ProductosDescripcion x)
						{
							x.IdEstado = 0;
						});
						AponusDBContext.ProductosDescripcions.UpdateRange(DescripcionProdEliminar ?? Enumerable.Empty<ProductosDescripcion>());
						if (DescripcionProdEliminar != null)
						{
							List<(string IdTIpo, int IdDescripcion)> ListaCategoriasProductos = DescripcionProdEliminar.Select((ProductosDescripcion x) => (IdTipo: TipoProducto2.IdTipo, IdDescripcion: x.IdDescripcion)).ToList();
							List<Producto> Productos = await (from x in AponusDBContext.Productos
								where ListaCategoriasProductos.Any<(string, int)>(((string, int) Lista) => Lista.Item1 == x.IdTipo && Lista.Item2 == x.IdDescripcion)
								select x into P
								select new Producto
								{
									Cantidad = P.Cantidad,
									IdDescripcion = P.IdDescripcion,
									IdEstado = 0,
									IdTipo = P.IdTipo,
									DiametroNominal = P.DiametroNominal,
									IdProducto = P.IdProducto,
									PrecioFinal = P.PrecioFinal,
									Tolerancia = P.Tolerancia,
									PrecioLista = P.PrecioLista,
									PorcentajeGanancia = P.PorcentajeGanancia
								}).ToListAsync();
							AponusDBContext.Productos.UpdateRange(Productos);
							await AponusDBContext.SaveChangesAsync();
							return (resultado: 200, error: null);
						}
					}
					return (resultado: null, error: null);
				}
				catch (Exception error)
				{
					await Transaccion.RollbackAsync();
					return (resultado: null, error: error);
				}
			}

			internal async Task<(int? StatusCode, Exception? Error)> DesactivarDescripcionProductoyRelaciones(ProductosDescripcion Descripcion)
			{
				ProductosDescripcion Descripcion2 = Descripcion;
				using IDbContextTransaction Transaccion = await AponusDBContext.Database.BeginTransactionAsync();
				try
				{
					List<Producto> Productos = await (from x in AponusDBContext.Productos
						where x.IdDescripcion == Descripcion2.IdDescripcion
						select x into P
						select new Producto
						{
							Cantidad = P.Cantidad,
							IdDescripcion = P.IdDescripcion,
							IdEstado = 0,
							IdTipo = P.IdTipo,
							DiametroNominal = P.DiametroNominal,
							IdProducto = P.IdProducto,
							PrecioFinal = P.PrecioFinal,
							Tolerancia = P.Tolerancia,
							PrecioLista = P.PrecioLista,
							PorcentajeGanancia = P.PorcentajeGanancia
						}).ToListAsync();
					AponusDBContext.ProductosDescripcions.Update(Descripcion2);
					if (Productos.Any())
					{
						AponusDBContext.Productos.UpdateRange(Productos);
					}
					await AponusDBContext.SaveChangesAsync();
					await Transaccion.CommitAsync();
					return (StatusCode: 200, Error: null);
				}
				catch (Exception error)
				{
					await Transaccion.RollbackAsync();
					return (StatusCode: null, Error: error);
				}
			}
		}

		private readonly AponusContext AponusDBContext;

		public AD_Categorias(AponusContext _AponusContext)
		{
			AponusDBContext = _AponusContext;
		}

		public Productos MetodosProductos()
		{
			return new Productos(AponusDBContext);
		}

		internal async Task<(List<ProductosDescripcion>? Listado, Exception? Error)> ListarDescripcionesProductos(string? idTipo)
		{
			string idTipo2 = idTipo;
			try
			{
				return (Listado: await (from _Descripciones in AponusDBContext.ProductosDescripcions
					join _Tipo in AponusDBContext.Producto_Tipo_Descripcion on _Descripciones.IdDescripcion equals _Tipo.IdDescripcion
					select new
					{
						_idTipo = _Tipo.IdTipo,
						IdDescripcion = _Descripciones.IdDescripcion,
						DescripcionProducto = _Descripciones.DescripcionProducto
					} into Tipo
					where Tipo._idTipo == idTipo2 || string.IsNullOrEmpty(idTipo2)
					select Tipo into x
					select new ProductosDescripcion
					{
						IdDescripcion = x.IdDescripcion,
						DescripcionProducto = x.DescripcionProducto
					}).ToListAsync(), Error: null);
			}
			catch (Exception ex)
			{
				Exception error = ex;
				return (Listado: null, Error: error);
			}
		}

		internal async Task<(int? Resultado, Exception? Error)> AgregarDescripcionProducto(ProductosDescripcion Categoria, string IdTipo)
		{
			ProductosDescripcion Categoria2 = Categoria;
			using IDbContextTransaction transaccion = await AponusDBContext.Database.BeginTransactionAsync();
			try
			{
				Microsoft.EntityFrameworkCore.DbSet<ProductosDescripcion> productosDescripcions = AponusDBContext.ProductosDescripcions;
				ProductosDescripcion productosDescripcion = new ProductosDescripcion
				{
					DescripcionProducto = Categoria2.DescripcionProducto
				};
				ProductosDescripcion productosDescripcion2 = productosDescripcion;
				productosDescripcion2.IdEstadoNavigation = (await AponusDBContext.EstadosProductosDescripcione.FirstOrDefaultAsync((EstadosProductosDescripciones X) => X.IdEstado == 1)) ?? new EstadosProductosDescripciones();
				productosDescripcions.Add(productosDescripcion);
				await AponusDBContext.SaveChangesAsync();
				int? IdDescripcion = (from x in AponusDBContext.ProductosDescripcions
					where x.DescripcionProducto == Categoria2.DescripcionProducto
					select x.IdDescripcion).FirstOrDefault();
				if (IdDescripcion.HasValue && !string.IsNullOrEmpty(IdTipo))
				{
					AponusDBContext.Producto_Tipo_Descripcion.Add(new Productos_Tipos_Descripcion
					{
						IdDescripcion = IdDescripcion,
						IdTipo = IdTipo
					});
					AponusDBContext.SaveChanges();
					await transaccion.CommitAsync();
					return (Resultado: 200, Error: null);
				}
				await transaccion.RollbackAsync();
				return (Resultado: null, Error: new Exception("Error interno,no se aplicaron los cambios"));
			}
			catch (Exception error)
			{
				await transaccion.CommitAsync();
				return (Resultado: null, Error: error);
			}
		}

		internal void AgregarTipoProducto(DTOCategorias NuevaCategoria)
		{
			AponusDBContext.ProductosTipos.Add(new ProductosTipo
			{
				IdTipo = (NuevaCategoria.IdTipo ?? ""),
				DescripcionTipo = NuevaCategoria.DescripcionTipo
			});
			AponusDBContext.SaveChanges();
		}

		internal ProductosTipo? ObtenerTipo(string IdTipo)
		{
			string IdTipo2 = IdTipo;
			return (from T in AponusDBContext.ProductosTipos
				where T.IdTipo.Equals(IdTipo2)
				select T into x
				select new ProductosTipo
				{
					IdTipo = x.IdTipo,
					DescripcionTipo = x.DescripcionTipo
				}).FirstOrDefault();
		}

		internal void ActualizarTipoProd(DTOActualizarCategorias actualizarCategorias)
		{
			DTOActualizarCategorias actualizarCategorias2 = actualizarCategorias;
			if (actualizarCategorias2.Anterior != null)
			{
				ProductosTipo productosTipo = AponusDBContext.ProductosTipos.FirstOrDefault((ProductosTipo T) => T.IdTipo == actualizarCategorias2.Anterior.IdTipo);
				if (productosTipo != null)
				{
					productosTipo.DescripcionTipo = actualizarCategorias2.Nueva?.DescripcionTipo;
					productosTipo.IdTipo = actualizarCategorias2.Nueva?.IdTipo ?? "";
					AponusDBContext.SaveChanges();
				}
			}
		}

		internal void ActualizarDescripcionProd(DTOActualizarCategorias actualizarCategorias)
		{
			DTOActualizarCategorias actualizarCategorias2 = actualizarCategorias;
			if (actualizarCategorias2.Anterior != null)
			{
				ProductosDescripcion productosDescripcion = AponusDBContext.ProductosDescripcions.FirstOrDefault((ProductosDescripcion PD) => PD.IdDescripcion == actualizarCategorias2.Anterior.IdDescripcion);
				if (productosDescripcion != null)
				{
					productosDescripcion.DescripcionProducto = actualizarCategorias2.Nueva?.Descripcion;
					AponusDBContext.SaveChanges();
				}
			}
		}

		internal void ActualizarTipos_Descripciones(DTOActualizarCategorias actualizarCategorias)
		{
			DTOActualizarCategorias actualizarCategorias2 = actualizarCategorias;
			if (actualizarCategorias2.Anterior != null)
			{
				Productos_Tipos_Descripcion productos_Tipos_Descripcion = AponusDBContext.Producto_Tipo_Descripcion.FirstOrDefault((Productos_Tipos_Descripcion TD) => TD.IdTipo == actualizarCategorias2.Anterior.IdTipo && TD.IdDescripcion == (int?)actualizarCategorias2.Anterior.IdDescripcion);
				if (productos_Tipos_Descripcion != null && actualizarCategorias2.Nueva != null)
				{
					productos_Tipos_Descripcion.IdTipo = actualizarCategorias2.Nueva.IdTipo ?? "";
					AponusDBContext.SaveChanges();
				}
			}
		}

		internal async Task<(int?, Exception?)> AgregarDescripcionCompoente(ComponentesDescripcion Componente)
		{
			ComponentesDescripcion Componente2 = Componente;
			using IDbContextTransaction transaccion = await AponusDBContext.Database.BeginTransactionAsync();
			try
			{
				Task<ComponentesDescripcion> Exists = AponusDBContext.ComponentesDescripcions.FirstOrDefaultAsync((ComponentesDescripcion x) => x.Descripcion != null && x.Descripcion.Equals(Componente2.Descripcion));
				if (Exists == null)
				{
					await AponusDBContext.ComponentesDescripcions.AddAsync(Componente2);
					await AponusDBContext.SaveChangesAsync();
					await transaccion.CommitAsync();
					return (200, null);
				}
				return (null, new Exception("El nombre del componente ya existe"));
			}
			catch (Exception ex)
			{
				Exception error = ex;
				return (null, error);
			}
		}

		internal async Task<(int? StatusCode, Exception? Error)> ModificarDescripcionComponente(ComponentesDescripcion descripcion)
		{
			using IDbContextTransaction transaccion = await AponusDBContext.Database.BeginTransactionAsync();
			try
			{
				AponusDBContext.ComponentesDescripcions.Update(descripcion);
				await AponusDBContext.SaveChangesAsync();
				await transaccion.CommitAsync();
				return (StatusCode: 200, Error: null);
			}
			catch (Exception error)
			{
				await transaccion.RollbackAsync();
				return (StatusCode: null, Error: error);
			}
		}
	}
	public class AD_Componentes
	{
		private readonly AponusContext AponusDbContext;

		public AD_Componentes(AponusContext _AponusDbContext)
		{
			AponusDbContext = _AponusDbContext;
		}

		internal List<(string Id, int IdDescripcion, decimal? Longitud, decimal? Peso)> ListarIdDescripcionComponentesProducto(string[] Componentes)
		{
			string[] Componentes2 = Componentes;
			return (from x in (from x in AponusDbContext.ComponentesDetalles
					where Componentes2.ToList().Contains(x.IdInsumo)
					select new { x.IdInsumo, x.IdDescripcion, x.Longitud, x.Peso }).AsEnumerable()
				select (IdInsumo: x.IdInsumo, IdDescripcion: x.IdDescripcion, Longitud: x.Longitud, Peso: x.Peso)).ToList();
		}

		internal async Task<List<Productos_Componentes>> ObtenerComponentes(string IdProducto)
		{
			string IdProducto2 = IdProducto;
			return await AponusDbContext.Componentes_Productos.Where((Productos_Componentes x) => x.IdProducto == IdProducto2).ToListAsync();
		}

		internal List<ComponentesDescripcion>? ListarNombresComponentes()
		{
			return AponusDbContext.ComponentesDescripcions.Select((ComponentesDescripcion x) => new ComponentesDescripcion
			{
				IdDescripcion = x.IdDescripcion,
				Descripcion = (x.Descripcion ?? ""),
				IdAlmacenamiento = x.IdAlmacenamiento,
				IdFraccionamiento = x.IdFraccionamiento
			}).ToList();
		}

		internal void GuardarComponenteProd(Productos_Componentes componente)
		{
			Productos_Componentes componente2 = componente;
			Productos_Componentes productos_Componentes = AponusDbContext.Componentes_Productos.FirstOrDefault((Productos_Componentes c) => c.IdProducto == componente2.IdProducto && c.IdComponente == componente2.IdComponente);
			if (productos_Componentes != null)
			{
				productos_Componentes.Cantidad = componente2.Cantidad;
				productos_Componentes.Peso = componente2.Peso;
				productos_Componentes.Longitud = componente2.Longitud;
				AponusDbContext.SaveChanges();
			}
			else
			{
				AponusDbContext.Componentes_Productos.Add(componente2);
				AponusDbContext.SaveChanges();
			}
		}

		internal JsonResult ObtenerComponentesFormateados(DTOProducto Producto)
		{
			DTOProducto Producto2 = Producto;
			var list = (from x in AponusDbContext.Componentes_Productos
				where x.IdProducto == Producto2.IdProducto
				select x into _Componentes
				join _DetalleComponentes in AponusDbContext.ComponentesDetalles on _Componentes.IdComponente equals _DetalleComponentes.IdInsumo
				select new { _Componentes, _DetalleComponentes } into _DetComponentes
				join _NombreComponentes in AponusDbContext.ComponentesDescripcions on _DetComponentes._DetalleComponentes.IdDescripcion equals _NombreComponentes.IdDescripcion
				select new { _DetComponentes, _NombreComponentes } into _JoinResult
				join _StockComponentes in AponusDbContext.stockInsumos on _JoinResult._DetComponentes._DetalleComponentes.IdInsumo equals _StockComponentes.IdInsumo
				select new
				{
					_IdProducto = _JoinResult._DetComponentes._Componentes.IdProducto,
					_IdComponente = (_JoinResult._DetComponentes._Componentes.IdComponente ?? ""),
					_Descripcion = (_JoinResult._NombreComponentes.Descripcion ?? ""),
					_Diametro = (_JoinResult._DetComponentes._DetalleComponentes.Diametro ?? null),
					_Longitud = (_JoinResult._DetComponentes._DetalleComponentes.Longitud ?? null),
					_Altura = (_JoinResult._DetComponentes._DetalleComponentes.Altura ?? null),
					_Espesor = (_JoinResult._DetComponentes._DetalleComponentes.Espesor ?? null),
					_Perfil = (_JoinResult._DetComponentes._DetalleComponentes.Perfil ?? null),
					_Tolerancia = (_JoinResult._DetComponentes._DetalleComponentes.Tolerancia ?? ""),
					_DiametroNominal = (_JoinResult._DetComponentes._DetalleComponentes.DiametroNominal ?? null),
					_Largo = (_JoinResult._DetComponentes._Componentes.Longitud ?? null),
					StockComponente = new DTOStockFormateado
					{
						IdInsumo = _StockComponentes.IdInsumo,
						Recibido = ((_StockComponentes.Recibido != null) ? ((object)_StockComponentes.Recibido).ToString() : "Sin Stock"),
						Granallado = ((_StockComponentes.Granallado != null) ? ((object)_StockComponentes.Granallado).ToString() : "Sin Stock"),
						Pintura = ((_StockComponentes.Pintura != null) ? ((object)_StockComponentes.Pintura).ToString() : "Sin Stock"),
						Proceso = ((_StockComponentes.Proceso != null) ? ((object)_StockComponentes.Proceso).ToString() : "Sin Stock"),
						Moldeado = ((_StockComponentes.Moldeado != null) ? ((object)_StockComponentes.Moldeado).ToString() : "Sin Stock"),
						Total = ((_StockComponentes.Pintura ?? 0m) + (_StockComponentes.Moldeado ?? 0m) + (_StockComponentes.Recibido ?? 0m) + (_StockComponentes.Proceso ?? 0m) + (_StockComponentes.Granallado ?? 0m)).ToString(),
						Requerido = ((object)((decimal?)(_JoinResult._DetComponentes._Componentes.Cantidad ?? 0m) * (decimal?)Producto2.Cantidad)).ToString()
					}
				} into cp
				group cp by new
				{
					cp._IdComponente, cp._IdProducto, cp._Descripcion, cp._Longitud, cp._Perfil, cp._DiametroNominal, cp._Altura, cp._Espesor, cp._Largo, cp._Diametro,
					cp._Tolerancia
				} into @group
				select new
				{
					idProducto = @group.Key._IdProducto,
					IdComponente = @group.Key._IdComponente,
					Descripcion = @group.Key._Descripcion,
					Perfil = @group.Key._Perfil,
					Longitud = @group.Key._Longitud,
					DiametroNominal = @group.Key._DiametroNominal,
					Altura = @group.Key._Altura,
					Largo = @group.Key._Largo,
					Diametro = @group.Key._Diametro,
					Espesor = @group.Key._Espesor,
					Tolerancia = @group.Key._Tolerancia,
					StockComponente = @group.Select(cp => cp.StockComponente).ToList()
				}).ToList();
			List<string> AllComponentesIds = list.Select(cp => cp.IdComponente).ToList();
			List<DTODetallesComponenteProducto> source = (from x in AponusDbContext.ComponentesDetalles
				where AllComponentesIds.Contains(x.IdInsumo)
				select new DTODetallesComponenteProducto
				{
					idComponente = x.IdInsumo,
					idAlmacenamiento = x.IdAlmacenamiento,
					idFraccionamiento = x.IdFraccionamiento,
					Altura = x.Altura,
					Diametro = x.Diametro,
					Espesor = x.Espesor,
					Longitud = x.Longitud,
					Perfil = x.Perfil,
					Tolerancia = x.Tolerancia,
					DiametroNominal = x.DiametroNominal,
					Peso = x.Peso
				}).ToList();
			List<DTOProductoComponente> list2 = new List<DTOProductoComponente>();
			foreach (var item3 in list)
			{
				string text = item3.IdComponente ?? "";
				string text2 = item3.Descripcion ?? "";
				string text3 = (item3.Diametro.HasValue ? $"{item3.Diametro:####}" : null);
				string text4 = (item3.Longitud.HasValue ? $"{item3.Longitud:#,0}" : null);
				string text5 = (item3.Altura.HasValue ? $"{item3.Altura:####}" : null);
				string text6 = (item3.Espesor.HasValue ? $"{item3.Espesor:####}" : null);
				string text7 = (item3.Perfil.HasValue ? $"{item3.Perfil:####}" : null);
				string text8 = item3.Tolerancia ?? "";
				string text9 = item3.DiametroNominal.ToString() ?? "";
				string text10 = (item3.Largo.HasValue ? $"{item3.Largo:####}" : null);
				StringBuilder stringBuilder = new StringBuilder();
				StringBuilder stringBuilder2 = stringBuilder;
				StringBuilder stringBuilder3 = stringBuilder2;
				StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(0, 1, stringBuilder2);
				handler.AppendFormatted(text2);
				stringBuilder3.Append(ref handler);
				if (text3 != null)
				{
					stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder4 = stringBuilder2;
					handler = new StringBuilder.AppendInterpolatedStringHandler(13, 1, stringBuilder2);
					handler.AppendLiteral(", Diametro:");
					handler.AppendFormatted(text3);
					handler.AppendLiteral("mm");
					stringBuilder4.Append(ref handler);
				}
				if (text4 != null)
				{
					stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder5 = stringBuilder2;
					handler = new StringBuilder.AppendInterpolatedStringHandler(13, 1, stringBuilder2);
					handler.AppendLiteral(", Longitud:");
					handler.AppendFormatted(text4);
					handler.AppendLiteral("mm");
					stringBuilder5.Append(ref handler);
				}
				if (text5 != null)
				{
					stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder6 = stringBuilder2;
					handler = new StringBuilder.AppendInterpolatedStringHandler(11, 1, stringBuilder2);
					handler.AppendLiteral(", Altura:");
					handler.AppendFormatted(text5);
					handler.AppendLiteral("mm");
					stringBuilder6.Append(ref handler);
				}
				if (text6 != null)
				{
					stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder7 = stringBuilder2;
					handler = new StringBuilder.AppendInterpolatedStringHandler(12, 1, stringBuilder2);
					handler.AppendLiteral(", Espesor:");
					handler.AppendFormatted(text6);
					handler.AppendLiteral("mm");
					stringBuilder7.Append(ref handler);
				}
				if (text7 != null)
				{
					stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder8 = stringBuilder2;
					handler = new StringBuilder.AppendInterpolatedStringHandler(9, 1, stringBuilder2);
					handler.AppendLiteral(", Perfil:");
					handler.AppendFormatted(text7);
					stringBuilder8.Append(ref handler);
				}
				if (text8 != null && text8 != "")
				{
					stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder9 = stringBuilder2;
					handler = new StringBuilder.AppendInterpolatedStringHandler(13, 1, stringBuilder2);
					handler.AppendLiteral(", Tolerancia:");
					handler.AppendFormatted(text8);
					stringBuilder9.Append(ref handler);
				}
				if (text9 != null && text9 != "")
				{
					stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder10 = stringBuilder2;
					handler = new StringBuilder.AppendInterpolatedStringHandler(7, 1, stringBuilder2);
					handler.AppendLiteral(", DN:");
					handler.AppendFormatted(text9);
					handler.AppendLiteral("mm");
					stringBuilder10.Append(ref handler);
				}
				foreach (DTOStockFormateado item4 in item3.StockComponente)
				{
					item4.NombreInsumo = text2;
				}
				DTOProductoComponente item2 = new DTOProductoComponente
				{
					IdComponente = (item3.IdComponente ?? ""),
					Descripcion = stringBuilder.ToString(),
					Perfil = item3.Perfil,
					Longitud = item3.Longitud,
					DiametroNominal = item3.DiametroNominal,
					Altura = item3.Altura,
					Largo = item3.Largo,
					Diametro = item3.Diametro,
					Espesor = item3.Espesor,
					Tolerancia = (item3.Tolerancia ?? ""),
					StockFormateado = item3.StockComponente
				};
				list2.Add(item2);
			}
			foreach (DTOProductoComponente producto in list2)
			{
				producto.Perfil = null;
				producto.Longitud = null;
				producto.DiametroNominal = null;
				producto.Altura = null;
				producto.Largo = null;
				producto.Diametro = null;
				producto.Espesor = null;
				producto.Tolerancia = "";
				string text11 = (from x in source
					where x.idComponente != null && x.idComponente.Contains(producto.IdComponente)
					select x.idAlmacenamiento).FirstOrDefault();
				string text12 = (from x in source
					where x.idComponente != null && x.idComponente.Contains(producto.IdComponente)
					select x.idFraccionamiento).FirstOrDefault();
				IEnumerable<DTOStockFormateado> stockFormateado = producto.StockFormateado;
				foreach (DTOStockFormateado item in stockFormateado ?? Enumerable.Empty<DTOStockFormateado>())
				{
					Type type = item.GetType();
					PropertyInfo[] properties = type.GetProperties();
					PropertyInfo[] array = properties;
					foreach (PropertyInfo propertyInfo in array)
					{
						if (propertyInfo.GetValue(item) == null || propertyInfo.Name.Contains("IdInsumo") || propertyInfo.Name.Contains("NombreInsumo") || !(propertyInfo?.GetValue(item)?.ToString() != "Sin Stock"))
						{
							continue;
						}
						if (text12 != null)
						{
							if (propertyInfo != null && propertyInfo.Name.Contains("Requerido"))
							{
								DTODetallesComponenteProducto dTODetallesComponenteProducto = source.FirstOrDefault((DTODetallesComponenteProducto x) => x.idComponente == item.IdInsumo);
								string text13 = (string)item.GetType().GetProperty(propertyInfo.Name)?.GetValue(item);
								if (text13 == "")
								{
									text13 = "0";
								}
								if ((dTODetallesComponenteProducto == null || !dTODetallesComponenteProducto.Diametro.HasValue) && dTODetallesComponenteProducto != null && dTODetallesComponenteProducto.Perfil.HasValue && !dTODetallesComponenteProducto.Espesor.HasValue && !dTODetallesComponenteProducto.Altura.HasValue && !dTODetallesComponenteProducto.DiametroNominal.HasValue && !Regex.IsMatch(text13 ?? "", "[a-zA-Z]"))
								{
									decimal num = decimal.Parse(item.Total ?? "", CultureInfo.InvariantCulture);
									decimal? longitud = dTODetallesComponenteProducto.Longitud;
									decimal num2 = decimal.Parse(text13 ?? "", CultureInfo.InvariantCulture);
									decimal value = num2;
									decimal? num3 = Producto2.Cantidad;
									decimal valueOrDefault = ((decimal?)value * num3 / longitud).GetValueOrDefault(1m);
									Fraction fraction = (Fraction)valueOrDefault;
									PropertyInfo? property = item.GetType().GetProperty(propertyInfo.Name);
									if ((object)property != null)
									{
										DTOStockFormateado obj = item;
										string[] obj2 = new string[6]
										{
											(item.GetType().GetProperty(propertyInfo.Name)?.GetValue(item))?.ToString(),
											text12,
											" - ",
											null,
											null,
											null
										};
										Fraction fraction2 = fraction;
										obj2[3] = fraction2.ToString();
										obj2[4] = " ";
										obj2[5] = text11;
										property.SetValue(obj, string.Concat(obj2));
									}
								}
								else
								{
									if (Regex.IsMatch(text13 ?? "", "[a-zA-Z]"))
									{
										continue;
									}
									decimal? num4 = dTODetallesComponenteProducto?.Peso;
									if (!num4.HasValue)
									{
										num4 = default(decimal);
									}
									decimal value = decimal.Parse(text13 ?? "", CultureInfo.InvariantCulture);
									decimal? num5 = num4;
									decimal? num6 = (decimal?)value * num5 * (decimal?)Producto2.Cantidad;
									num6 = (num6.HasValue ? Math.Round(num6.Value, 1) : 0m);
									decimal? num7 = num6;
									if ((num7.GetValueOrDefault() > default(decimal)) & num7.HasValue)
									{
										PropertyInfo? property2 = item.GetType().GetProperty(propertyInfo.Name);
										if ((object)property2 != null)
										{
											DTOStockFormateado obj3 = item;
											string[] obj4 = new string[7]
											{
												(item.GetType().GetProperty(propertyInfo.Name)?.GetValue(item))?.ToString(),
												" ",
												text12,
												" - ",
												null,
												null,
												null
											};
											num7 = num6;
											obj4[4] = num7.ToString();
											obj4[5] = " ";
											obj4[6] = text11;
											property2.SetValue(obj3, string.Concat(obj4));
										}
									}
									else
									{
										item.GetType().GetProperty(propertyInfo.Name)?.SetValue(item, (item.GetType().GetProperty(propertyInfo.Name)?.GetValue(item))?.ToString() + " " + text12);
									}
								}
							}
							else if (propertyInfo != null)
							{
								item.GetType().GetProperty(propertyInfo.Name)?.SetValue(item, (item.GetType().GetProperty(propertyInfo.Name)?.GetValue(item))?.ToString() + " " + text11);
							}
						}
						else if (propertyInfo != null)
						{
							item.GetType().GetProperty(propertyInfo.Name)?.SetValue(item, (item.GetType().GetProperty(propertyInfo.Name)?.GetValue(item))?.ToString() + " " + text11);
						}
					}
				}
			}
			string idProducto = list.Select(x => x.idProducto).FirstOrDefault();
			var value2 = new
			{
				idProducto = idProducto,
				Componentes = list2
			};
			return new JsonResult(value2);
		}

		internal JsonResult? ListarProp(string[] propiedadesNulas, List<(string Nombre, string Valor)> propiedadesNoNulas)
		{
			string[] propiedadesNulas2 = propiedadesNulas;
			AponusContext aponusDbContext = AponusDbContext;
			IQueryable<ComponentesDetalle> source = GenerarWhereAND(propiedadesNoNulas);
			JsonResult jsonResult = null;
			int i = 0;
			while (true)
			{
				Type type = typeof(ComponentesDetalle).GetProperty(propiedadesNulas2[i])?.PropertyType;
				ParameterExpression parameterExpression = System.Linq.Expressions.Expression.Parameter(typeof(ComponentesDetalle), "x");
				MemberExpression left = System.Linq.Expressions.Expression.Property(parameterExpression, propiedadesNulas2[i]);
				Expression<Func<ComponentesDetalle, object>> expression = null;
				object value = ((type != null && type.IsValueType) ? Activator.CreateInstance(type) : null);
				if (type != null)
				{
					BinaryExpression expression2 = System.Linq.Expressions.Expression.Coalesce(left, System.Linq.Expressions.Expression.Constant(value, type));
					expression = System.Linq.Expressions.Expression.Lambda<Func<ComponentesDetalle, object>>(System.Linq.Expressions.Expression.Convert(expression2, typeof(object)), new ParameterExpression[1] { parameterExpression });
					object[] source2 = source.Select(expression).Distinct().ToArray();
					IEnumerable<object> enumerable = source2.Where((object x) => x != null && !string.IsNullOrEmpty(x.ToString()));
					if (enumerable.Any())
					{
						string columna = (from e in AponusDbContext.Set<ComponentesDetalle>()
							select typeof(ComponentesDetalle).GetProperty(propiedadesNulas2[i]))?.First()?.Name;
						var value2 = new
						{
							Valores = enumerable,
							Columna = columna
						};
						jsonResult = new JsonResult(value2);
					}
					i++;
					if (jsonResult != null || i >= propiedadesNulas2.Length)
					{
						break;
					}
					continue;
				}
				throw new ArgumentNullException("propertyType", "El tipo de la propiedad no puede ser nulo.");
			}
			if (jsonResult == null)
			{
				jsonResult = new JsonResult(null);
			}
			return jsonResult;
		}

		internal async Task<(List<ComponentesDetalle>? LstComponentes, Exception? Error)> ListarDetalleComponentes(int? IdDescripcion)
		{
			try
			{
				return (LstComponentes: await (from x in AponusDbContext.ComponentesDetalles
					where x.IdEstado != 0 && (IdDescripcion == null || (int?)x.IdDescripcion == IdDescripcion)
					select new ComponentesDetalle
					{
						IdInsumo = x.IdInsumo,
						Altura = x.Altura,
						Diametro = x.Diametro,
						DiametroNominal = x.DiametroNominal,
						Espesor = x.Espesor,
						IdDescripcion = x.IdDescripcion,
						IdEstado = x.IdEstado,
						Longitud = x.Longitud,
						Perfil = x.Perfil,
						Peso = x.Peso,
						Tolerancia = x.Tolerancia,
						IdAlmacenamiento = (from y in AponusDbContext.ComponentesDescripcions
							where y.IdDescripcion == x.IdDescripcion
							select y into X
							select X.IdAlmacenamiento).FirstOrDefault(),
						IdFraccionamiento = (from y in AponusDbContext.ComponentesDescripcions
							where y.IdDescripcion == x.IdDescripcion
							select y into X
							select X.IdFraccionamiento).FirstOrDefault()
					}).ToListAsync(), Error: null);
			}
			catch (Exception ex)
			{
				Exception Error = ex;
				return (LstComponentes: null, Error: Error);
			}
		}

		internal JsonResult? ObtenerId(List<(string Nombre, string Valor)> propiedadesNoNulas)
		{
			IQueryable<ComponentesDetalle> source = GenerarWhereAND(propiedadesNoNulas);
			List<string> list = source.Select((ComponentesDetalle x) => x.IdInsumo).ToList();
			JsonResult jsonResult = new JsonResult(null);
			if (list.Count() > 1)
			{
				return new JsonResult("Los valores no corresponden a un elemento unico");
			}
			return new JsonResult(new DTOComponentesProducto
			{
				IdComponente = list[0]
			});
		}

		private IQueryable<ComponentesDetalle> GenerarWhereAND(List<(string Nombre, string Valor)> propiedadesNoNulas)
		{
			AponusContext aponusDbContext = AponusDbContext;
			IQueryable<ComponentesDetalle> queryable = from x in aponusDbContext.ComponentesDetalles.AsQueryable()
				where true
				select x;
			foreach (var propiedadesNoNula in propiedadesNoNulas)
			{
				string item = propiedadesNoNula.Valor;
				if (item == null)
				{
					continue;
				}
				string item2 = propiedadesNoNula.Nombre;
				Type conversionType = typeof(ComponentesDetalle).GetProperty(item2)?.PropertyType;
				decimal result2;
				if (int.TryParse(item, out var result))
				{
					ParameterExpression parameterExpression = System.Linq.Expressions.Expression.Parameter(typeof(ComponentesDetalle), "x");
					MemberExpression left = System.Linq.Expressions.Expression.Property(parameterExpression, item2);
					try
					{
						ConstantExpression right = System.Linq.Expressions.Expression.Constant(result, typeof(int?));
						BinaryExpression body = System.Linq.Expressions.Expression.Equal(left, right);
						Expression<Func<ComponentesDetalle, bool>> predicate = System.Linq.Expressions.Expression.Lambda<Func<ComponentesDetalle, bool>>(body, new ParameterExpression[1] { parameterExpression });
						queryable = queryable.Where(predicate);
					}
					catch (InvalidOperationException)
					{
						ConstantExpression right2 = System.Linq.Expressions.Expression.Constant(result, typeof(int));
						BinaryExpression body2 = System.Linq.Expressions.Expression.Equal(left, right2);
						Expression<Func<ComponentesDetalle, bool>> predicate2 = System.Linq.Expressions.Expression.Lambda<Func<ComponentesDetalle, bool>>(body2, new ParameterExpression[1] { parameterExpression });
						queryable = queryable.Where(predicate2);
					}
				}
				else if (decimal.TryParse(item, out result2))
				{
					ParameterExpression parameterExpression2 = System.Linq.Expressions.Expression.Parameter(typeof(ComponentesDetalle), "x");
					MemberExpression left2 = System.Linq.Expressions.Expression.Property(parameterExpression2, item2);
					ConstantExpression right3 = System.Linq.Expressions.Expression.Constant(result2, typeof(decimal?));
					BinaryExpression body3 = System.Linq.Expressions.Expression.Equal(left2, right3);
					Expression<Func<ComponentesDetalle, bool>> predicate3 = System.Linq.Expressions.Expression.Lambda<Func<ComponentesDetalle, bool>>(body3, new ParameterExpression[1] { parameterExpression2 });
					queryable = queryable.Where(predicate3);
				}
				else
				{
					object value = Convert.ChangeType(item, conversionType);
					ParameterExpression parameterExpression3 = System.Linq.Expressions.Expression.Parameter(typeof(ComponentesDetalle), "x");
					MemberExpression memberExpression = System.Linq.Expressions.Expression.Property(parameterExpression3, item2);
					if (memberExpression != null)
					{
						ConstantExpression right4 = System.Linq.Expressions.Expression.Constant(value);
						BinaryExpression body4 = System.Linq.Expressions.Expression.Equal(memberExpression, right4);
						Expression<Func<ComponentesDetalle, bool>> predicate4 = System.Linq.Expressions.Expression.Lambda<Func<ComponentesDetalle, bool>>(body4, new ParameterExpression[1] { parameterExpression3 });
						queryable = queryable.Where(predicate4);
					}
				}
			}
			return queryable;
		}

		internal void GuardarComponente(ComponentesDetalle componentesDetalle)
		{
			ComponentesDetalle componentesDetalle2 = componentesDetalle;
			ComponentesDetalle componentesDetalle3 = AponusDbContext.ComponentesDetalles.FirstOrDefault((ComponentesDetalle x) => x.IdInsumo == componentesDetalle2.IdInsumo);
			if (componentesDetalle3 == null)
			{
				AponusDbContext.ComponentesDetalles.Add(componentesDetalle2);
			}
			else
			{
				AponusDbContext.Entry(componentesDetalle3).CurrentValues.SetValues(componentesDetalle2);
			}
			AponusDbContext.SaveChanges();
		}

		internal async Task<(List<ComponentesDescripcion>? Listado, Exception? Error)> ListarTiposAlacenamiento(int? IdDescripcionComponente)
		{
			try
			{
				return (Listado: await (from x in AponusDbContext.ComponentesDescripcions
					where (int?)x.IdDescripcion == IdDescripcionComponente || IdDescripcionComponente == null
					select new ComponentesDescripcion
					{
						IdDescripcion = x.IdDescripcion,
						Descripcion = x.Descripcion,
						IdFraccionamiento = x.IdFraccionamiento,
						IdAlmacenamiento = x.IdAlmacenamiento
					}).ToListAsync(), Error: null);
			}
			catch (Exception ex)
			{
				Exception Error = ex;
				return (Listado: null, Error: Error);
			}
		}

		internal JsonResult ObtenerNuevoId(string componentDescription)
		{
			string componentDescription2 = componentDescription;
			string text = "";
			List<string> list = (from x in AponusDbContext.ComponentesDetalles
				where x.IdInsumo.Contains(componentDescription2.Substring(0, 3).ToUpper())
				select x.IdInsumo.Substring(3)).ToList();
			if (list.Count > 0)
			{
				List<int> source = (from x in list
					select Regex.Match(x, "\\d+") into match
					where match.Success
					select int.Parse(match.Value)).ToList();
				int num = source.Max() + 1;
				text = componentDescription2.Substring(0, 3).ToUpper() + "_" + num;
			}
			else
			{
				text = componentDescription2.Substring(0, 3).ToUpper() + "_" + 1;
			}
			return new JsonResult(text);
		}
	}
	public class AD_Compras
	{
		private readonly AponusContext aponusContext;

		public AD_Compras(AponusContext _aponusContext)
		{
			aponusContext = _aponusContext;
		}

		internal async Task<Compras>? BuscarCompra(int IdCompra)
		{
			return await QueryableExtensions.Include(QueryableExtensions.Include(QueryableExtensions.Include(aponusContext.Compra, (Compras x) => x.DetallesCompra), (Compras x) => x.IdProveedorNavigation), (Compras x) => x.Pagos).FirstOrDefaultAsync((Compras x) => x.IdCompra == IdCompra);
		}

		internal async Task<bool> Guardar(Compras compra)
		{
			using IDbContextTransaction transaccion = aponusContext.Database.BeginTransaction();
			try
			{
				Compras CompraExistente = aponusContext.Compra.Find(compra.IdCompra);
				if (CompraExistente == null)
				{
					await aponusContext.Compra.AddAsync(compra);
				}
				else
				{
					aponusContext.Entry(CompraExistente).CurrentValues.SetValues(compra);
					aponusContext.Entry(CompraExistente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
				}
				await transaccion.CommitAsync();
				return true;
			}
			catch (Exception)
			{
				transaccion.Rollback();
				return false;
			}
		}

		internal (IQueryable<Compras>? QuyeryCompras, Exception? Error) ObtenerDatos(UTL_FiltrosComprasVentas? Filtros)
		{
			UTL_FiltrosComprasVentas Filtros2 = Filtros;
			try
			{
				IQueryable<Compras> queryable = QueryableExtensions.Include(QueryableExtensions.Include(QueryableExtensions.Include(aponusContext.Compra, (Compras x) => x.DetallesCompra), (Compras x) => x.Pagos), (Compras x) => x.IdProveedorNavigation).AsQueryable();
				if (Filtros2 != null)
				{
					if (Filtros2.Desde.HasValue)
					{
						queryable = queryable.Where((Compras x) => x.FechaHora >= Filtros2.Desde);
					}
					if (Filtros2.Hasta.HasValue)
					{
						queryable = queryable.Where((Compras x) => x.FechaHora <= Filtros2.Desde);
					}
					if (Filtros2.IdEntidad.HasValue)
					{
						queryable = queryable.Where((Compras x) => (int?)x.IdProveedor == Filtros2.IdEntidad);
					}
					if (Filtros2.IdCompraVenta.HasValue)
					{
						queryable = queryable.Where((Compras x) => (int?)x.IdCompra >= Filtros2.IdCompraVenta);
					}
				}
				return (QuyeryCompras: queryable, Error: null);
			}
			catch (Exception item)
			{
				return (QuyeryCompras: null, Error: item);
			}
		}

		internal async Task<(StatusCodeResult? ResultadoOk, Exception? Error)> RegistrarPago(PagosCompras pago)
		{
			using IDbContextTransaction transaccion = await aponusContext.Database.BeginTransactionAsync();
			try
			{
				await aponusContext.PagosCompra.AddAsync(pago);
				await aponusContext.SaveChangesAsync();
				await transaccion.CommitAsync();
				return (ResultadoOk: new StatusCodeResult(200), Error: null);
			}
			catch (Exception ex2)
			{
				Exception ex = ex2;
				return (ResultadoOk: null, Error: ex);
			}
		}
	}
	public class AD_Entidades
	{
		private readonly AponusContext AponusDBContext;

		public AD_Entidades(AponusContext _aponusDBContext)
		{
			AponusDBContext = _aponusDBContext;
		}

		public IActionResult GuardarEntidad(DTOEntidades Entidad)
		{
			DTOEntidades Entidad2 = Entidad;
			try
			{
				if (Entidad2.IdEntidad.HasValue)
				{
					Entidades entidades = AponusDBContext.Entidades.FirstOrDefault((Entidades x) => (int?)x.IdEntidad == Entidad2.IdEntidad && x.IdEstado != 0);
					if (entidades != null)
					{
						entidades.NombreClave = Entidad2.NombreClave ?? entidades.NombreClave;
						entidades.Pais = Entidad2.Pais ?? entidades.Pais;
						entidades.Localidad = Entidad2.Localidad ?? entidades.Localidad;
						entidades.Calle = Entidad2.Calle ?? entidades.Calle;
						entidades.Altura = Entidad2.Altura ?? entidades.Altura;
						entidades.CodigoPostal = Entidad2.CodigoPostal ?? entidades.CodigoPostal;
						entidades.Telefono1 = Entidad2.Telefono1 ?? entidades.Telefono1;
						entidades.Telefono2 = Entidad2.Telefono2 ?? entidades.Telefono2;
						entidades.Telefono3 = Entidad2.Telefono3 ?? entidades.Telefono3;
						entidades.Email = Entidad2.Email ?? entidades.Email;
						entidades.IdFiscal = Entidad2.IdFiscal ?? entidades.IdFiscal;
						entidades.Ciudad = Entidad2.Ciudad ?? entidades.Ciudad;
						entidades.Provincia = Entidad2.Provincia ?? entidades.Provincia;
						entidades.Apellido = Entidad2.Apellido ?? entidades.Apellido;
						entidades.Nombre = Entidad2.Nombre ?? entidades.Nombre;
						entidades.IdUsuarioRegistro = Entidad2.IdUsuarioRegistro ?? entidades.IdUsuarioRegistro;
						entidades.Barrio = Entidad2.Barrio ?? entidades.Barrio;
						entidades.IdCategoria = Entidad2.IdCategoria;
						entidades.IdTipo = Entidad2.IdTipo;
						AponusDBContext.Entidades.Update(entidades);
						AponusDBContext.SaveChanges();
					}
					return new StatusCodeResult(200);
				}
				Entidades entidades2 = new Entidades();
				entidades2.NombreClave = Entidad2.Nombre ?? "";
				entidades2.Nombre = ((!string.IsNullOrEmpty(Entidad2.Nombre)) ? Entidad2.Nombre.Trim().ToUpper().Replace(" ", "") : null);
				entidades2.Apellido = ((!string.IsNullOrEmpty(Entidad2.Apellido)) ? Entidad2.Apellido.Trim().ToUpper().Replace(" ", "") : null);
				entidades2.Pais = ((!string.IsNullOrEmpty(Entidad2.Pais)) ? Entidad2.Pais.Trim().ToUpper().Replace(" ", "") : null);
				entidades2.Ciudad = ((!string.IsNullOrEmpty(Entidad2.Ciudad)) ? Entidad2.Ciudad.Trim().ToUpper().Replace(" ", "") : null);
				entidades2.Provincia = ((!string.IsNullOrEmpty(Entidad2.Provincia)) ? Entidad2.Provincia.Trim().ToUpper().Replace(" ", "") : null);
				entidades2.Localidad = ((!string.IsNullOrEmpty(Entidad2.Localidad)) ? Entidad2.Localidad.Trim().ToUpper().Replace(" ", "") : null);
				entidades2.Calle = ((!string.IsNullOrEmpty(Entidad2.Calle)) ? Entidad2.Calle.Trim().ToUpper().Replace(" ", "") : null);
				entidades2.Altura = ((!string.IsNullOrEmpty(Entidad2.Altura)) ? Entidad2.Altura.Trim().ToUpper().Replace(" ", "") : null);
				entidades2.CodigoPostal = ((!string.IsNullOrEmpty(Entidad2.CodigoPostal)) ? Entidad2.CodigoPostal.Trim().ToUpper().Replace(" ", "") : null);
				entidades2.Telefono1 = ((!string.IsNullOrEmpty(Entidad2.Telefono1)) ? Entidad2.Telefono1.Trim().ToUpper().Replace(" ", "") : null);
				entidades2.Telefono2 = ((!string.IsNullOrEmpty(Entidad2.Telefono2)) ? Entidad2.Telefono2.Trim().ToUpper().Replace(" ", "") : null);
				entidades2.Telefono3 = ((!string.IsNullOrEmpty(Entidad2.Telefono3)) ? Entidad2.Telefono3.Trim().ToUpper().Replace(" ", "") : null);
				entidades2.Email = ((!string.IsNullOrEmpty(Entidad2.Email)) ? Entidad2.Email.Trim().ToUpper().Replace(" ", "") : null);
				entidades2.IdFiscal = Entidad2.IdFiscal.Trim().ToUpper().Replace(" ", "")
					.Replace("-", "")
					.Replace("_", "");
				entidades2.FechaRegistro = Entidad2.FechaRegistro ?? UTL_Fechas.ObtenerFechaHora();
				entidades2.IdUsuarioRegistro = Entidad2.IdUsuarioRegistro ?? "";
				entidades2.IdTipo = Entidad2.IdTipo;
				entidades2.IdCategoria = Entidad2.IdCategoria;
				entidades2.CategoriaEntidad = AponusDBContext.CategoriasEntidades.FirstOrDefault((EntidadesCategorias x) => x.IdCategoria == Entidad2.IdCategoria) ?? new EntidadesCategorias();
				entidades2.TipoEntidad = AponusDBContext.TiposEntidades.FirstOrDefault((EntidadesTipos x) => x.IdTipo == Entidad2.IdTipo) ?? new EntidadesTipos();
				entidades2.UsuarioRegistro = AponusDBContext.Usuarios.FirstOrDefault((Usuarios x) => x.Usuario == Entidad2.IdUsuarioRegistro) ?? new Usuarios();
				Entidades entity = entidades2;
				AponusDBContext.Entidades.Add(entity);
				AponusDBContext.SaveChanges();
				return new StatusCodeResult(200);
			}
			catch (Exception ex)
			{
				ContentResult contentResult = new ContentResult
				{
					ContentType = "application/json",
					StatusCode = 400
				};
				contentResult.Content = ((!string.IsNullOrEmpty(ex.InnerException?.Message)) ? ("Error:\n" + ex.InnerException.Message) : ("Error:\n" + ex.Message));
				return contentResult;
			}
		}

		internal async Task<(int? Resultado, Exception? Error)> DeshabilitarEntidad(Entidades Entidad)
		{
			using IDbContextTransaction transaccion = await AponusDBContext.Database.BeginTransactionAsync();
			try
			{
				AponusDBContext.Entidades.Update(Entidad);
				await AponusDBContext.SaveChangesAsync();
				await transaccion.CommitAsync();
				return (Resultado: 200, Error: null);
			}
			catch (Exception ex)
			{
				await transaccion.RollbackAsync();
				return (Resultado: null, Error: ex);
			}
		}

		internal IQueryable<Entidades> ListarEntidades()
		{
			return AponusDBContext.Entidades.Where((Entidades x) => x.IdEstado != 0);
		}

		internal async Task<(List<EntidadesTipos>? LstTiposEntidades, Exception? ex)> ListarTiposEntidades()
		{
			try
			{
				return (LstTiposEntidades: await EntityFrameworkQueryableExtensions.ToListAsync(AponusDBContext.TiposEntidades.Where((EntidadesTipos x) => x.IdEstado != 0)), ex: null);
			}
			catch (Exception ex2)
			{
				Exception ex = ex2;
				return (LstTiposEntidades: null, ex: ex);
			}
		}

		internal async Task<(int?, Exception? ex)> GuardarTipoEntidad(EntidadesTipos NuevoTipo)
		{
			EntidadesTipos NuevoTipo2 = NuevoTipo;
			using IDbContextTransaction transaccion = await AponusDBContext.Database.BeginTransactionAsync();
			try
			{
				EntidadesTipos ExisteId;
				int num2;
				if (NuevoTipo2.IdTipo != 0)
				{
					ExisteId = AponusDBContext.TiposEntidades.FirstOrDefault((EntidadesTipos x) => x.IdTipo == NuevoTipo2.IdTipo);
					int num;
					if (ExisteId == null)
					{
						num = 0;
					}
					else
					{
						_ = ExisteId.IdTipo;
						num = 1;
					}
					if (num != 0)
					{
						if (ExisteId == null || ExisteId.IdTipo != 0)
						{
							num2 = ((!string.IsNullOrEmpty(NuevoTipo2.NombreTipo)) ? 1 : 0);
							goto IL_0206;
						}
					}
					num2 = 0;
					goto IL_0206;
				}
				await AponusDBContext.TiposEntidades.AddAsync(NuevoTipo2);
				await AponusDBContext.SaveChangesAsync();
				await transaccion.CommitAsync();
				return (200, ex: null);
				IL_0206:
				if (num2 != 0)
				{
					ExisteId.NombreTipo = NuevoTipo2.NombreTipo;
					ExisteId.IdEstado = 1;
					AponusDBContext.TiposEntidades.Update(ExisteId);
					await AponusDBContext.SaveChangesAsync();
					await transaccion.CommitAsync();
					return (200, ex: null);
				}
				return (null, ex: new Exception("error al actualizar, no se encontro el Tipo"));
			}
			catch (Exception ex2)
			{
				Exception ex = ex2;
				return (null, ex: ex);
			}
		}

		internal async Task<(List<EntidadesCategorias>? LstCategoriasEntidades, Exception? Ex)> ListarCategorias(int? idTipo)
		{
			try
			{
				IQueryable<EntidadesCategorias> QueryCategorias = AponusDBContext.CategoriasEntidades.Where((EntidadesCategorias x) => x.IdEstado == 1);
				if (idTipo.HasValue)
				{
					List<int> IdCategorias = await EntityFrameworkQueryableExtensions.ToListAsync(from x in AponusDBContext.EntidadeTiposCategorias
						where (int?)x.idTipoEntidad == idTipo
						select x.IdCategoriaEntidad);
					QueryCategorias = QueryCategorias.Where((EntidadesCategorias x) => IdCategorias.ToList().Equals(x.IdCategoria));
				}
				return (LstCategoriasEntidades: await EntityFrameworkQueryableExtensions.ToListAsync(QueryCategorias), Ex: null);
			}
			catch (Exception ex2)
			{
				Exception ex = ex2;
				return (LstCategoriasEntidades: null, Ex: ex);
			}
		}

		internal async Task<(int? Resultado, Exception? Ex)> GuardarCategoria(EntidadesCategorias nuevaCategoria, int? IdTipo)
		{
			EntidadesCategorias nuevaCategoria2 = nuevaCategoria;
			using IDbContextTransaction transaccion = await AponusDBContext.Database.BeginTransactionAsync();
			try
			{
				if (await EntityFrameworkQueryableExtensions.FirstOrDefaultAsync(AponusDBContext.CategoriasEntidades, (EntidadesCategorias x) => x.NombreCategoria.Equals(nuevaCategoria2.NombreCategoria) && x.IdEstado != 0) == null)
				{
					await AponusDBContext.CategoriasEntidades.AddAsync(nuevaCategoria2);
					await AponusDBContext.SaveChangesAsync();
					EntidadesCategorias Cat = await EntityFrameworkQueryableExtensions.FirstOrDefaultAsync(AponusDBContext.CategoriasEntidades, (EntidadesCategorias x) => x.NombreCategoria == nuevaCategoria2.NombreCategoria && x.IdEstado != 0);
					EntidadesTipos Tipo = await EntityFrameworkQueryableExtensions.FirstOrDefaultAsync(AponusDBContext.TiposEntidades, (EntidadesTipos x) => (int?)x.IdTipo == IdTipo && x.IdEstado != 0);
					nuevaCategoria2.IdCategoria = Cat?.IdCategoria ?? 0;
					if (!(await VincularTiposCategorias(Tipo, Cat)))
					{
						await transaccion.CommitAsync();
						return (Resultado: 200, Ex: null);
					}
					await transaccion.RollbackAsync();
					return (Resultado: null, Ex: new Exception("No se aplicaron los cambios"));
				}
				if (nuevaCategoria2.IdCategoria != 0)
				{
					EntidadesCategorias CategoriaExistente = await EntityFrameworkQueryableExtensions.FirstOrDefaultAsync(AponusDBContext.CategoriasEntidades, (EntidadesCategorias x) => x.IdCategoria.Equals(nuevaCategoria2.IdCategoria) && x.IdEstado != 0);
					if (CategoriaExistente != null)
					{
						CategoriaExistente.NombreCategoria = nuevaCategoria2.NombreCategoria ?? "";
					}
					await AponusDBContext.SaveChangesAsync();
					await transaccion.CommitAsync();
				}
				return (Resultado: 200, Ex: null);
			}
			catch (Exception ex2)
			{
				Exception ex = ex2;
				return (Resultado: null, Ex: ex);
			}
		}

		internal async Task<bool> VincularTiposCategorias(EntidadesTipos? Tipo, EntidadesCategorias? Cat)
		{
			try
			{
				if (Tipo != null && Cat != null)
				{
					EntidadesTiposCategorias vinculo = new EntidadesTiposCategorias
					{
						idTipoEntidad = Tipo.IdTipo,
						IdCategoriaEntidad = Cat.IdCategoria,
						TipoEntidad = Tipo,
						CategoriaEntidad = Cat
					};
					await AponusDBContext.EntidadeTiposCategorias.AddAsync(vinculo);
					await AponusDBContext.SaveChangesAsync();
					return false;
				}
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		internal async Task<(int? Status, Exception? ex)> CambiarEstadoCategoria(EntidadesCategorias Categoria)
		{
			try
			{
				AponusDBContext.CategoriasEntidades.Update(Categoria);
				await AponusDBContext.SaveChangesAsync();
				return (Status: 200, ex: null);
			}
			catch (Exception ex2)
			{
				Exception ex = ex2;
				return (Status: null, ex: ex);
			}
		}

		internal async Task<(int? Resultado, Exception? ex)> DesactivarTipoyRelaciones(EntidadesTipos TipoEntidad)
		{
			EntidadesTipos TipoEntidad2 = TipoEntidad;
			using IDbContextTransaction transaccion = await AponusDBContext.Database.BeginTransactionAsync();
			try
			{
				List<Entidades> Entidades = (await EntityFrameworkQueryableExtensions.ToListAsync(AponusDBContext.Entidades.Where((Entidades x) => x.IdTipo == TipoEntidad2.IdTipo))) ?? new List<Entidades>();
				Entidades.ForEach(delegate(Entidades x)
				{
					x.IdEstado = 0;
				});
				AponusDBContext.Entidades.UpdateRange(Entidades);
				AponusDBContext.TiposEntidades.Update(TipoEntidad2);
				await AponusDBContext.SaveChangesAsync();
				await transaccion.CommitAsync();
				return (Resultado: 200, ex: null);
			}
			catch (Exception ex)
			{
				await transaccion.RollbackAsync();
				return (Resultado: null, ex: ex);
			}
		}
	}
	public class AD_Movimientos
	{
		public class Estados
		{
			private readonly AponusContext AponusDbContext;

			public Estados(AponusContext aponusDbContext)
			{
				AponusDbContext = aponusDbContext;
			}

			internal static List<EstadosMovimientosStock> Listar(AponusContext AponusDbContext)
			{
				return AponusDbContext.EstadoMovimientosStock.Where((EstadosMovimientosStock x) => x.IdEstado != 0 && !x.Descripcion.ToUpper().Contains("ELIMINADO")).ToList();
			}
		}

		public class ArchivosMovimientos
		{
			private readonly AponusContext AponusDBContext;

			public ArchivosMovimientos(AponusContext _AponusDBContext)
			{
				AponusDBContext = _AponusDBContext;
			}

			public bool Eliminar(AponusContext AponusDB, int IdMov, string Archivo)
			{
				string Archivo2 = Archivo;
				try
				{
					ArchivosMovimientosStock archivosMovimientosStock = AponusDB.ArchivosStock.Where((ArchivosMovimientosStock x) => x.IdMovimiento == IdMov && x.HashArchivo.Contains(Archivo2)).FirstOrDefault();
					if (archivosMovimientosStock != null)
					{
						archivosMovimientosStock.IdEstado = 0;
						AponusDB.ArchivosStock.Update(archivosMovimientosStock);
						return true;
					}
					return false;
				}
				catch (DbUpdateException)
				{
					return false;
				}
			}
		}

		private readonly AponusContext AponusDBContext;

		public AD_Movimientos(AponusContext _AponusDbContext)
		{
			AponusDBContext = _AponusDbContext;
		}

		public ArchivosMovimientos Archivos()
		{
			return new ArchivosMovimientos(AponusDBContext);
		}

		public Estados EstadosMovimientos()
		{
			return new Estados(AponusDBContext);
		}

		internal async Task<DTOMovimientosStock?> ObtenerDatosMovimiento(int idMovimiento)
		{
			UTL_Cloudinary cloudinary = new UTL_Cloudinary();
			DTOMovimientosStock Movimiento = (from x in AponusDBContext.Stock_Movimientos
				where x.IdMovimiento == idMovimiento
				select new DTOMovimientosStock
				{
					IdMovimiento = x.IdMovimiento,
					UsuarioCreacion = x.CreadoUsuario,
					FechaHoraCreado = x.FechaHoraCreado,
					FechaHoraUltimaModificacion = x.FechaHoraUltimaModificacion,
					IdProveedorDestino = x.IdProveedor,
					UsuarioModificacion = x.ModificadoUsuario,
					DatosArchivos = (from x in AponusDBContext.ArchivosStock
						where x.IdMovimiento == x.IdMovimiento && x.IdEstado == 1
						select new DTODatosArchivosMovimientosStock
						{
							IdMovimiento = x.IdMovimiento,
							NombreArchivo = x.HashArchivo,
							MimeType = x.MimeType,
							Path = x.PathArchivo,
							Extension = Path.GetExtension(x.PathArchivo)
						}).ToList()
				}).FirstOrDefault();
			IEnumerable<DTODatosArchivosMovimientosStock> enumerable = Movimiento?.DatosArchivos;
			foreach (DTODatosArchivosMovimientosStock Archivo in enumerable ?? Enumerable.Empty<DTODatosArchivosMovimientosStock>())
			{
				if (Archivo != null)
				{
					(byte[]? Archivo, string? error) tuple = await cloudinary.DescargarArchivo(Archivo?.Path ?? "");
					byte[] archivo = tuple.Archivo;
					string error = tuple.error;
					Archivo.DatosArchivo = archivo;
					Archivo.MensajeError = error;
				}
			}
			return Movimiento;
		}

		public async Task<List<DTOMovimientosStock>> Listar(UTL_FiltrosMovimientos? Filtros = null)
		{
			UTL_FiltrosMovimientos Filtros2 = Filtros;
			if (Filtros2 != null)
			{
				IQueryable<DTOMovimientosStock> IQMovimientos = from Mov_Prov_Sum_Det in AponusDBContext.Stock_Movimientos.Where((Stock_Movimientos movimiento) => (!Filtros2.Desde.HasValue || movimiento.FechaHoraCreado >= Filtros2.Desde.Value) && (!Filtros2.Hasta.HasValue || movimiento.FechaHoraCreado <= Filtros2.Hasta.Value) && (string.IsNullOrEmpty(Filtros2.Etapa) || (movimiento.Destino != null && movimiento.Destino.Contains(Filtros2.Etapa))) && (!Filtros2.IdProveedor.HasValue || (int?)movimiento.IdProveedor == Filtros2.IdProveedor)).Join(AponusDBContext.Entidades, (Stock_Movimientos movimientos) => movimientos.IdProveedor, (Entidades proveedorDestino) => proveedorDestino.IdEntidad, (Stock_Movimientos movimiento, Entidades proveedor) => new
					{
						Movimiento = movimiento,
						Proveedor = proveedor
					}).Join(AponusDBContext.SuministrosMovimientoStock, Movimiento_Provedor => Movimiento_Provedor.Movimiento.IdMovimiento, (SuministrosMovimientosStock SuministrosMovimientos) => SuministrosMovimientos.IdMovimiento, (Movimientos_Proveedor, SuministrosMovimientosStock SuministrosMovimientos) => new
					{
						movimiento_proveedor = Movimientos_Proveedor,
						suministrosMovimientos = SuministrosMovimientos
					})
						.Join(AponusDBContext.ComponentesDetalles, Movimientos_Proveedores_Suministros => Movimientos_Proveedores_Suministros.suministrosMovimientos.IdSuministro, (ComponentesDetalle SuministrosDetalle) => SuministrosDetalle.IdInsumo, (movimientos_Proveedores_Suministros, ComponentesDetalle suministrosDetalle) => new
						{
							Movimientos_Proveedores_Suministros = movimientos_Proveedores_Suministros,
							SuministrosDetalle = suministrosDetalle
						})
					join Estados in AponusDBContext.EstadoMovimientosStock on Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimiento_proveedor.Movimiento.IdEstadoMovimiento equals Estados.IdEstadoMovimiento
					select new { Mov_Prov_Sum_Det, Estados } into x
					where x.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimiento_proveedor.Movimiento.IdEstadoMovimiento != 0
					select x into result
					select new DTOMovimientosStock
					{
						IdMovimiento = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimiento_proveedor.Movimiento.IdMovimiento,
						FechaHoraCreado = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimiento_proveedor.Movimiento.FechaHoraCreado,
						UsuarioCreacion = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimiento_proveedor.Movimiento.CreadoUsuario,
						Origen = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimiento_proveedor.Movimiento.Origen,
						Destino = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimiento_proveedor.Movimiento.Destino,
						Estado = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(result.Estados.Descripcion.ToLower()),
						Suministros = (from s in AponusDBContext.SuministrosMovimientoStock
							where s.IdMovimiento == result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimiento_proveedor.Movimiento.IdMovimiento && s.IdEstado != 0
							select new DTOSuministrosMovimientosStock
							{
								IdMovimiento = s.IdMovimiento,
								IdSuministro = s.IdSuministro,
								Cantidad = ((!string.IsNullOrEmpty(s.Cantidad.ToString())) ? (s.Cantidad.ToString() + (result.Mov_Prov_Sum_Det.SuministrosDetalle.IdFraccionamiento ?? result.Mov_Prov_Sum_Det.SuministrosDetalle.IdAlmacenamiento)) : (0.0.ToString() + (result.Mov_Prov_Sum_Det.SuministrosDetalle.IdFraccionamiento ?? result.Mov_Prov_Sum_Det.SuministrosDetalle.IdAlmacenamiento)))
							}).ToList(),
						Proveedor = new DTOEntidades
						{
							IdEntidad = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimiento_proveedor.Proveedor.IdEntidad,
							Nombre = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimiento_proveedor.Proveedor.Nombre,
							Apellido = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimiento_proveedor.Proveedor.Apellido,
							NombreClave = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimiento_proveedor.Proveedor.NombreClave
						}
					};
				return await EntityFrameworkQueryableExtensions.ToListAsync(IQMovimientos);
			}
			IQueryable<DTOMovimientosStock> IQMovimientos2 = from Mov_Prov_Sum_Det in AponusDBContext.Stock_Movimientos.Join(AponusDBContext.Entidades, (Stock_Movimientos movimientos) => movimientos.IdProveedor, (Entidades proveedorDestino) => proveedorDestino.IdEntidad, (Stock_Movimientos movimiento, Entidades proveedor) => new
				{
					Movimiento = movimiento,
					Proveedor = proveedor
				}).Join(AponusDBContext.SuministrosMovimientoStock, Movimiento_Provedor => Movimiento_Provedor.Movimiento.IdMovimiento, (SuministrosMovimientosStock SuministrosMovimientos) => SuministrosMovimientos.IdMovimiento, (Movimientos_Proveedor, SuministrosMovimientosStock SuministrosMovimientos) => new
				{
					movimiento_proveedor = Movimientos_Proveedor,
					suministrosMovimientos = SuministrosMovimientos
				}).Join(AponusDBContext.ComponentesDetalles, Movimientos_Proveedores_Suministros => Movimientos_Proveedores_Suministros.suministrosMovimientos.IdSuministro, (ComponentesDetalle SuministrosDetalle) => SuministrosDetalle.IdInsumo, (movimientos_Proveedores_Suministros, ComponentesDetalle suministrosDetalle) => new
				{
					Movimientos_Proveedores_Suministros = movimientos_Proveedores_Suministros,
					SuministrosDetalle = suministrosDetalle
				})
				join Estados in AponusDBContext.EstadoMovimientosStock on Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimiento_proveedor.Movimiento.IdEstadoMovimiento equals Estados.IdEstadoMovimiento
				select new { Mov_Prov_Sum_Det, Estados } into x
				where x.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimiento_proveedor.Movimiento.IdEstadoMovimiento != 0
				select x into result
				select new DTOMovimientosStock
				{
					IdMovimiento = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimiento_proveedor.Movimiento.IdMovimiento,
					FechaHoraCreado = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimiento_proveedor.Movimiento.FechaHoraCreado,
					UsuarioCreacion = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimiento_proveedor.Movimiento.CreadoUsuario,
					Origen = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimiento_proveedor.Movimiento.Origen,
					Destino = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimiento_proveedor.Movimiento.Destino,
					Estado = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(result.Estados.Descripcion.ToLower()),
					Suministros = (from s in AponusDBContext.SuministrosMovimientoStock
						where s.IdMovimiento == result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimiento_proveedor.Movimiento.IdMovimiento && s.IdEstado != 0
						select new DTOSuministrosMovimientosStock
						{
							IdMovimiento = s.IdMovimiento,
							IdSuministro = s.IdSuministro,
							Cantidad = ((!string.IsNullOrEmpty(s.Cantidad.ToString())) ? (s.Cantidad.ToString() + (result.Mov_Prov_Sum_Det.SuministrosDetalle.IdFraccionamiento ?? result.Mov_Prov_Sum_Det.SuministrosDetalle.IdAlmacenamiento)) : (0.0.ToString() + (result.Mov_Prov_Sum_Det.SuministrosDetalle.IdFraccionamiento ?? result.Mov_Prov_Sum_Det.SuministrosDetalle.IdAlmacenamiento)))
						}).ToList(),
					Proveedor = new DTOEntidades
					{
						IdEntidad = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimiento_proveedor.Proveedor.IdEntidad,
						Nombre = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimiento_proveedor.Proveedor.Nombre,
						Apellido = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimiento_proveedor.Proveedor.Apellido,
						NombreClave = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimiento_proveedor.Proveedor.NombreClave
					}
				};
			return await EntityFrameworkQueryableExtensions.ToListAsync(IQMovimientos2);
		}

		internal async Task<List<DTODatosArchivosMovimientosStock>> InfoArchivos(List<int?> ListaMovimientos)
		{
			List<int?> ListaMovimientos2 = ListaMovimientos;
			try
			{
				return await EntityFrameworkQueryableExtensions.ToListAsync(from Id in AponusDBContext.ArchivosStock
					where ListaMovimientos2.Contains(Id.IdMovimiento)
					select Id into Reg
					select new DTODatosArchivosMovimientosStock
					{
						IdMovimiento = Reg.IdMovimiento,
						NombreArchivo = Reg.HashArchivo,
						Path = Reg.PathArchivo,
						Extension = Path.GetExtension(Reg.PathArchivo),
						MimeType = ObtenerMimeType(Reg.PathArchivo)
					});
			}
			catch (Exception)
			{
				return new List<DTODatosArchivosMovimientosStock>();
			}
		}

		private static async Task<byte[]> DescargarArchivoMovimiento_Local(string url)
		{
			HttpClient webClient = new HttpClient();
			return await webClient.GetByteArrayAsync(url);
		}

		public static string ObtenerMimeType(string pathArchivo)
		{
			string key = Path.GetExtension(pathArchivo).ToLower();
			Dictionary<string, string> dictionary = new Dictionary<string, string>
			{
				{ ".jpg", "image/jpg" },
				{ ".jpeg", "image/jpeg" },
				{ ".png", "image/png" },
				{ ".gif", "image/gif" },
				{ ".bmp", "image/bmp" },
				{ ".tif", "image/tiff" },
				{ ".tiff", "image/tiff" },
				{ ".pdf", "application/pdf" },
				{ ".doc", "application/msword" },
				{ ".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
				{ ".xls", "application/vnd.ms-excel" },
				{ ".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" },
				{ ".ppt", "application/vnd.ms-powerpoint" },
				{ ".pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation" },
				{ ".txt", "text/plain" },
				{ ".csv", "text/csv" }
			};
			return dictionary.ContainsKey(key) ? dictionary[key] : "application/octet-stream";
		}

		internal bool RegistrarModificacion(AponusContext AponusDbContext, DTOMovimientosStock Mov)
		{
			DTOMovimientosStock Mov2 = Mov;
			try
			{
				if (AponusDbContext == null)
				{
					AponusDbContext = AponusDBContext;
				}
				DateTime value = UTL_Fechas.ObtenerFechaHora();
				Stock_Movimientos stock_Movimientos = AponusDbContext.Stock_Movimientos.Where((Stock_Movimientos x) => (int?)x.IdMovimiento == Mov2.IdMovimiento).FirstOrDefault();
				if (stock_Movimientos != null)
				{
					stock_Movimientos.FechaHoraUltimaModificacion = value;
					stock_Movimientos.ModificadoUsuario = Mov2.UsuarioModificacion;
					AponusDbContext.Stock_Movimientos.Update(stock_Movimientos);
					return true;
				}
				return false;
			}
			catch (Exception ex)
			{
				string message = ex.Message;
				return false;
			}
		}

		internal bool Eliminar(AponusContext AponusDBContext, int idMovimiento)
		{
			try
			{
				Stock_Movimientos stock_Movimientos = AponusDBContext.Stock_Movimientos.FirstOrDefault((Stock_Movimientos x) => x.IdMovimiento == idMovimiento);
				if (stock_Movimientos != null)
				{
					stock_Movimientos.IdEstadoMovimiento = 0;
					AponusDBContext.Entry(stock_Movimientos).CurrentValues.SetValues(stock_Movimientos);
					return true;
				}
				return false;
			}
			catch (Exception)
			{
				return false;
			}
		}

		internal bool Actualizar(DTOMovimientosStock actualizacionMovimiento)
		{
			DTOMovimientosStock actualizacionMovimiento2 = actualizacionMovimiento;
			try
			{
				Stock_Movimientos stock_Movimientos = AponusDBContext.Stock_Movimientos.FirstOrDefault((Stock_Movimientos x) => (int?)x.IdMovimiento == actualizacionMovimiento2.IdMovimiento);
				if (stock_Movimientos != null)
				{
					stock_Movimientos.FechaHoraUltimaModificacion = UTL_Fechas.ObtenerFechaHora();
					stock_Movimientos.ModificadoUsuario = actualizacionMovimiento2.UsuarioModificacion ?? stock_Movimientos.ModificadoUsuario;
					stock_Movimientos.IdProveedor = actualizacionMovimiento2.IdProveedorDestino ?? stock_Movimientos.IdProveedor;
					stock_Movimientos.Origen = actualizacionMovimiento2.Origen ?? stock_Movimientos.Origen;
					stock_Movimientos.Destino = actualizacionMovimiento2.Destino ?? stock_Movimientos.Destino;
					stock_Movimientos.Tipo = actualizacionMovimiento2.Tipo ?? stock_Movimientos.Tipo;
					stock_Movimientos.IdEstadoMovimiento = actualizacionMovimiento2.IdEstado ?? stock_Movimientos.IdEstadoMovimiento;
					AponusDBContext.Entry(stock_Movimientos).CurrentValues.SetValues(stock_Movimientos);
					AponusDBContext.SaveChanges();
					return true;
				}
				return false;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
	public class AD_Productos
	{
		private readonly AponusContext AponusDBContext;

		private readonly AD_Componentes componentesProductos;

		public AD_Productos(AponusContext _aponusDbContext, AD_Componentes _componentesProductos)
		{
			AponusDBContext = _aponusDbContext;
			componentesProductos = _componentesProductos;
		}

		internal void GuardarProducto(DTOProducto producto)
		{
			AponusDBContext.Productos.Add(new Producto
			{
				IdProducto = (producto.IdProducto ?? ""),
				IdDescripcion = producto.IdDescripcion.GetValueOrDefault(),
				IdTipo = (producto.IdTipo ?? ""),
				DiametroNominal = producto.DiametroNominal,
				Cantidad = Convert.ToInt32(producto.Cantidad),
				PrecioLista = producto.PrecioLista,
				Tolerancia = producto.Tolerancia
			});
			AponusDBContext.SaveChanges();
		}

		public string GenerarIdProd(DTOProducto Producto)
		{
			string result;
			try
			{
				string text = Producto.Tolerancia ?? "".Replace("-", "_").Replace("/", "_");
				result = $"{Producto.IdProducto}_{Producto.IdDescripcion}_{Producto.DiametroNominal}_{Producto.Tolerancia}";
			}
			catch (Exception)
			{
				return "";
			}
			return result;
		}

		internal void GuardarComponentes(List<DTOComponentesProducto> Componentes)
		{
			if (!Componentes.All((DTOComponentesProducto x) => x.IdProducto != null))
			{
				return;
			}
			foreach (DTOComponentesProducto Componente in Componentes)
			{
				try
				{
					if (Componente.IdProducto == null || Componente.IdComponente != null)
					{
					}
					componentesProductos.GuardarComponenteProd(new Productos_Componentes
					{
						IdProducto = Componente.IdProducto,
						IdComponente = Componente.IdComponente,
						Cantidad = Componente.Cantidad,
						Longitud = Componente.Largo,
						Peso = Componente.Peso
					});
				}
				catch (Exception)
				{
				}
			}
			AponusDBContext.SaveChanges();
		}

		public Producto? BuscarProducto(string Id_Producto)
		{
			string Id_Producto2 = Id_Producto;
			return (from x in AponusDBContext.Productos
				where x.IdProducto == Id_Producto2
				select new Producto
				{
					IdProducto = x.IdProducto,
					IdDescripcion = x.IdDescripcion,
					IdTipo = x.IdTipo,
					DiametroNominal = x.DiametroNominal,
					Tolerancia = x.Tolerancia,
					Cantidad = x.Cantidad,
					PrecioFinal = x.PrecioFinal,
					PrecioLista = x.PrecioLista,
					PorcentajeGanancia = x.PorcentajeGanancia
				}).SingleOrDefault();
		}

		internal void ModifyProductDetails(Producto ProductUpdate)
		{
			AponusDBContext.Entry(ProductUpdate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			AponusDBContext.SaveChanges();
		}

		internal string? ObtenerValor(string prop, string IdProducto)
		{
			string IdProducto2 = IdProducto;
			string prop2 = prop;
			return (from x in AponusDBContext.Productos
				where x.IdProducto == IdProducto2
				select x.GetType().GetProperty(prop2).GetValue(x)).FirstOrDefault()?.ToString();
		}

		internal void DeleteAllProductComponents(string IdProducto)
		{
			string IdProducto2 = IdProducto;
			Productos_Componentes[] array = AponusDBContext.Componentes_Productos.Where((Productos_Componentes x) => x.IdProducto == IdProducto2).ToArray();
			if (array != null)
			{
				AponusDBContext.Componentes_Productos.RemoveRange(array);
				AponusDBContext.SaveChanges();
			}
		}

		internal void AgregarComponente(Productos_Componentes NewComponent)
		{
			AponusDBContext.Componentes_Productos.Add(NewComponent);
			AponusDBContext.SaveChanges();
		}

		internal void ModifyProductComponents(List<Productos_Componentes> ProducComponentsUpdate)
		{
			AponusDBContext.Componentes_Productos.UpdateRange(ProducComponentsUpdate);
			AponusDBContext.SaveChanges();
		}

		internal void ActualizarIdProd(string idAnterior, string nuevoId)
		{
			string idAnterior2 = idAnterior;
			string nuevoId2 = nuevoId;
			AponusDBContext.Productos.Where((Producto x) => x.IdProducto == idAnterior2).UpdateFromQuery((Producto x) => new Producto
			{
				IdProducto = nuevoId2
			});
			AponusDBContext.SaveChanges();
		}

		public JsonResult Listar()
		{
			IQueryable<ProductosDescripcion> value = AponusDBContext.ProductosDescripcions.Select((ProductosDescripcion x) => new ProductosDescripcion
			{
				IdDescripcion = x.IdDescripcion,
				DescripcionProducto = x.DescripcionProducto,
				Productos = x.Productos.Select((Producto P) => new Producto
				{
					Cantidad = P.Cantidad
				}).ToList()
			});
			return new JsonResult(value);
		}

		public JsonResult Listar(string? typeId)
		{
			string typeId2 = typeId;
			IEnumerable<ProductosDescripcion> value = from x in AponusDBContext.ProductosDescripcions.Select((ProductosDescripcion x) => new ProductosDescripcion
				{
					DescripcionProducto = x.DescripcionProducto,
					Productos = (ICollection<Producto>)(from x in x.Productos
						where x.IdTipo.Contains(typeId2 ?? "")
						orderby x.DiametroNominal
						select x)
				}).AsEnumerable()
				where x.Productos.Count > 0
				select x;
			return new JsonResult(value);
		}

		public JsonResult Listar(string? typeId, int? IdDescription)
		{
			string typeId2 = typeId;
			try
			{
				IEnumerable<ProductosDescripcion> value = from x in AponusDBContext.ProductosDescripcions.Select((ProductosDescripcion x) => new ProductosDescripcion
					{
						DescripcionProducto = x.DescripcionProducto,
						Productos = (ICollection<Producto>)(from x in x.Productos
							where x.IdTipo == typeId2 && (int?)x.IdDescripcion == IdDescription
							orderby x.DiametroNominal
							select x)
					}).AsEnumerable()
					where x.Productos.Count > 0
					select x;
				return new JsonResult(value);
			}
			catch (DbException ex)
			{
				return new JsonResult(ex.Message);
			}
		}

		public JsonResult Listar(string? typeId, int? IdDescription, int? Dn)
		{
			string typeId2 = typeId;
			try
			{
				IEnumerable<ProductosDescripcion> value = from x in AponusDBContext.ProductosDescripcions.Select((ProductosDescripcion x) => new ProductosDescripcion
					{
						DescripcionProducto = x.DescripcionProducto,
						Productos = (ICollection<Producto>)(from x in x.Productos
							where x.IdTipo == typeId2 && (int?)x.IdDescripcion == IdDescription && x.DiametroNominal == Dn
							orderby x.DiametroNominal
							select x)
					}).AsEnumerable()
					where x.Productos.Count > 0
					select x;
				return new JsonResult(value);
			}
			catch (DbException ex)
			{
				return new JsonResult(ex.Message);
			}
		}

		public async Task<JsonResult> ListarDN(string typeId)
		{
			string typeId2 = typeId;
			return new JsonResult(await EntityFrameworkQueryableExtensions.ToListAsync((from x in AponusDBContext.Productos
				where x.IdTipo == typeId2
				select x.DiametroNominal).Distinct()));
		}

		internal async Task<JsonResult> ListarDN(string? typeId, int? idDescription)
		{
			string typeId2 = typeId;
			return new JsonResult(await EntityFrameworkQueryableExtensions.ToListAsync((from x in AponusDBContext.Productos
				where x.IdTipo == typeId2 && (int?)x.IdDescripcion == idDescription
				select x.DiametroNominal).Distinct()));
		}
	}
	public class AD_Stocks
	{
		public class Productos
		{
			private readonly AponusContext AponusDBContext;

			public Productos(AponusContext _aponusContext)
			{
				AponusDBContext = _aponusContext;
			}

			public async Task<bool> Actualizar(Producto Producto)
			{
				using IDbContextTransaction transaccion = await AponusDBContext.Database.BeginTransactionAsync();
				try
				{
					Producto Existe = await AponusDBContext.Productos.FindAsync(Producto.IdProducto);
					if (Existe == null)
					{
						await AponusDBContext.Productos.AddAsync(Producto);
					}
					else
					{
						AponusDBContext.Entry(Existe).CurrentValues.SetValues(Producto);
					}
					await AponusDBContext.SaveChangesAsync();
					await transaccion.CommitAsync();
					return true;
				}
				catch (Exception)
				{
					return false;
				}
			}
		}

		public class Insumos
		{
			private readonly AponusContext AponusDBContext;

			public Insumos(AponusContext _aponusContext)
			{
				AponusDBContext = _aponusContext;
			}

			public async Task<bool> Actualizar(StockInsumos stockInsumo)
			{
				using IDbContextTransaction transaccion = await AponusDBContext.Database.BeginTransactionAsync();
				try
				{
					StockInsumos Existe = await AponusDBContext.stockInsumos.FindAsync(stockInsumo.IdInsumo);
					if (Existe == null)
					{
						await AponusDBContext.stockInsumos.AddAsync(stockInsumo);
					}
					else
					{
						AponusDBContext.Entry(Existe).CurrentValues.SetValues(stockInsumo);
					}
					await AponusDBContext.SaveChangesAsync();
					await transaccion.CommitAsync();
					return true;
				}
				catch (Exception)
				{
					return false;
				}
			}
		}

		private readonly AponusContext AponusDBContext;

		public AD_Stocks(AponusContext _aponusContext)
		{
			AponusDBContext = _aponusContext;
		}

		public Productos StockProductos()
		{
			return new Productos(AponusDBContext);
		}

		public Insumos StockInsumos()
		{
			return new Insumos(AponusDBContext);
		}

		internal bool IncrementarStockProducto(DTOStockUpdate Actualizacion)
		{
			DTOStockUpdate Actualizacion2 = Actualizacion;
			bool result = true;
			try
			{
				AponusDBContext.Productos.Where((Producto x) => x.IdProducto == Actualizacion2.IdExistencia).ExecuteUpdate((SetPropertyCalls<Producto> x) => x.SetProperty((Producto x) => x.Cantidad, (decimal?)(from x in AponusDBContext.Productos
					where x.IdProducto == Actualizacion2.IdExistencia
					select x.Cantidad).SingleOrDefault() + Actualizacion2.Cantidad));
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		internal bool DisminuirStockProducto(DTOStockUpdate Actualizacion, AponusContext? AponusDBContext = null)
		{
			DTOStockUpdate Actualizacion2 = Actualizacion;
			AponusContext AponusDBContext2 = AponusDBContext;
			if (AponusDBContext2 == null)
			{
				AponusDBContext2 = this.AponusDBContext;
			}
			bool result = true;
			try
			{
				AponusDBContext2.Productos.Where((Producto x) => x.IdProducto == Actualizacion2.IdExistencia).ExecuteUpdate((SetPropertyCalls<Producto> x) => x.SetProperty((Producto x) => x.Cantidad, (decimal?)(from x in AponusDBContext2.Productos
					where x.IdProducto == Actualizacion2.IdExistencia
					select x.Cantidad).SingleOrDefault() - Actualizacion2.Cantidad));
			}
			catch (Exception)
			{
				result = false;
			}
			finally
			{
			}
			return result;
		}

		internal IActionResult ListarInsumosProducto(int? IdDescripcion = null)
		{
			List<DTOTipoInsumos> tipoInsumosList = (from Detalles in AponusDBContext.ComponentesDetalles
				join Descripciones in AponusDBContext.ComponentesDescripcions on Detalles.IdDescripcion equals Descripciones.IdDescripcion
				select new { Detalles, Descripciones } into JoinResult
				join Stock in AponusDBContext.stockInsumos on JoinResult.Detalles.IdInsumo equals Stock.IdInsumo
				select new DTOTipoInsumos
				{
					IdDescripcion = JoinResult.Descripciones.IdDescripcion,
					Descripcion = JoinResult.Descripciones.Descripcion,
					especificacionesFormato = (new List<DTOComponenteFormateado>
					{
						new DTOComponenteFormateado
						{
							idComponente = JoinResult.Detalles.IdInsumo,
							Largo = ((JoinResult.Detalles.Longitud != null) ? $"{JoinResult.Detalles.Longitud}mm" : "-"),
							Espesor = ((JoinResult.Detalles.Espesor != null) ? $"{JoinResult.Detalles.Espesor}mm" : "-"),
							Perfil = ((JoinResult.Detalles.Perfil != null) ? ((object)JoinResult.Detalles.Perfil).ToString() : "-"),
							Diametro = ((JoinResult.Detalles.Diametro != null) ? $"{JoinResult.Detalles.Diametro}mm" : null),
							Peso = ((JoinResult.Detalles.Peso != null) ? $"{JoinResult.Detalles.Peso}g" : "-"),
							Altura = ((JoinResult.Detalles.Altura != null) ? $"{JoinResult.Detalles.Altura}mm" : "-"),
							Tolerancia = ((JoinResult.Detalles.Tolerancia != null) ? JoinResult.Detalles.Tolerancia : "-"),
							Recibido = ((Stock.Recibido != null) ? ((object)Stock.Recibido).ToString() : "-"),
							Granallado = ((Stock.Granallado != null) ? ((object)Stock.Granallado).ToString() : "-"),
							Pintura = ((Stock.Pintura != null) ? ((object)Stock.Pintura).ToString() : "-"),
							Proceso = ((Stock.Proceso != null) ? ((object)Stock.Proceso).ToString() : "-"),
							Moldeado = ((Stock.Moldeado != null) ? ((object)Stock.Moldeado).ToString() : "-"),
							DiametroNominal = ((JoinResult.Detalles.DiametroNominal != null) ? ((object)JoinResult.Detalles.DiametroNominal).ToString() : "-")
						}
					} ?? new List<DTOComponenteFormateado>())
				} into Result
				group Result by new { Result.IdDescripcion, Result.Descripcion } into Filtros
				where !((int?)IdDescripcion).HasValue || Filtros.Key.IdDescripcion == (int?)((int?)IdDescripcion).Value
				select Filtros into @group
				select new DTOTipoInsumos
				{
					IdDescripcion = @group.Key.IdDescripcion,
					Descripcion = @group.Key.Descripcion,
					especificacionesFormato = @group.Select((DTOTipoInsumos result) => result.especificacionesFormato.Single()).ToList()
				} into x
				orderby x.Descripcion
				select x).AsEnumerable().ToList();
			List<(string, string)> inner = ObtenerUnidadesAlmacenamiento(tipoInsumosList.SelectMany((DTOTipoInsumos x) => x.especificacionesFormato.Select((DTOComponenteFormateado y) => y.idComponente)).ToList());
			foreach (DTOTipoInsumos item in tipoInsumosList)
			{
				item.Columnas = new UTL_Productos().ObtenerColumnas(null, item.especificacionesFormato);
			}
			tipoInsumosList.SelectMany((DTOTipoInsumos x) => x.especificacionesFormato ?? new List<DTOComponenteFormateado>()).Join<DTOComponenteFormateado, (string, string), string, List<DTOTipoInsumos>>(inner, (DTOComponenteFormateado espec) => espec.idComponente, ((string IdSuministro, string Unidad) unidad) => unidad.IdSuministro, delegate(DTOComponenteFormateado espec, (string IdSuministro, string Unidad) unidad)
			{
				espec.Pintura = ((espec.Pintura != null && !espec.Pintura.Equals("-")) ? (espec.Pintura + unidad.Unidad) : espec.Pintura);
				espec.Granallado = ((espec.Granallado != null && !espec.Granallado.Equals("-")) ? (espec.Granallado + unidad.Unidad) : espec.Granallado);
				espec.Proceso = ((espec.Proceso != null && !espec.Proceso.Equals("-")) ? (espec.Proceso + unidad.Unidad) : espec.Proceso);
				espec.Moldeado = ((espec.Moldeado != null && !espec.Moldeado.Equals("-")) ? (espec.Moldeado + unidad.Unidad) : espec.Moldeado);
				espec.Recibido = ((espec.Recibido != null && !espec.Recibido.Equals("-")) ? (espec.Recibido + unidad.Unidad) : espec.Recibido);
				return tipoInsumosList;
			}).ToList();
			return new JsonResult(tipoInsumosList);
		}

		internal bool ActualizarStockInsumo(AponusContext AponusDBContext, DTOStockUpdate Actualizacion)
		{
			DTOStockUpdate Actualizacion2 = Actualizacion;
			string Origen = Actualizacion2.Origen?.ToUpper() ?? "";
			string Destino = Actualizacion2.Destino?.ToUpper() ?? "";
			decimal valueOrDefault = Actualizacion2.Cantidad.GetValueOrDefault();
			StockInsumos stockInsumos = AponusDBContext?.stockInsumos.FirstOrDefault((StockInsumos x) => x.IdInsumo.Equals(Actualizacion2.Id));
			if (stockInsumos != null)
			{
				PropertyInfo[] properties = stockInsumos.GetType().GetProperties();
				PropertyInfo propertyInfo = properties.FirstOrDefault((PropertyInfo x) => x.Name.ToUpper().Contains(Origen));
				PropertyInfo propertyInfo2 = properties.FirstOrDefault((PropertyInfo x) => x.Name.ToUpper().Contains(Destino));
				if (string.IsNullOrEmpty(Actualizacion2.Origen) && (Actualizacion2.Destino?.ToUpper() ?? "").Contains("PENDIENTE"))
				{
					return false;
				}
				if (string.IsNullOrEmpty(Actualizacion2.Origen) && (Actualizacion2.Destino?.ToUpper() ?? "").Contains("RECIBIDO"))
				{
					return false;
				}
				if (!string.IsNullOrEmpty(Actualizacion2.Origen) && !string.IsNullOrEmpty(Actualizacion2.Destino))
				{
					decimal num = (propertyInfo?.GetValue(stockInsumos) as decimal?).GetValueOrDefault() - valueOrDefault;
					if (num < 0m)
					{
						return false;
					}
					decimal num2 = (propertyInfo2?.GetValue(stockInsumos) as decimal?).GetValueOrDefault() + valueOrDefault;
					propertyInfo?.SetValue(stockInsumos, num);
					propertyInfo2?.SetValue(stockInsumos, num2);
					AponusDBContext.Entry(stockInsumos).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
					AponusDBContext.SaveChanges();
					return true;
				}
				if (!string.IsNullOrEmpty(Actualizacion2.Origen) && Destino.Equals("PROCESO"))
				{
					stockInsumos.Proceso = Actualizacion2.Cantidad;
					AponusDBContext.Entry(stockInsumos).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
					AponusDBContext?.SaveChanges();
					return true;
				}
				return false;
			}
			return false;
		}

		public StockInsumos? BuscarInsumo(string Insumo)
		{
			string Insumo2 = Insumo;
			return (from x in AponusDBContext.stockInsumos
				where x.IdInsumo == Insumo2
				select new StockInsumos
				{
					IdInsumo = x.IdInsumo,
					Granallado = x.Granallado,
					Moldeado = x.Moldeado,
					Pintura = x.Pintura,
					Proceso = x.Proceso,
					Recibido = x.Recibido
				}).SingleOrDefault();
		}

		private List<(string IdSuministro, string? Unidad)> ObtenerUnidadesAlmacenamiento(List<string> Suministros)
		{
			List<string> Suministros2 = Suministros;
			return (from x in AponusDBContext.ComponentesDetalles
				where Suministros2.Contains(x.IdInsumo)
				select (x.IdInsumo, x.IdAlmacenamiento)).ToList();
		}

		internal bool NewSetearStockInsumo(DTOStockUpdate Actualizacion)
		{
			DTOStockUpdate Actualizacion2 = Actualizacion;
			PropertyInfo propertyInfo = typeof(StockInsumos).GetProperties().FirstOrDefault((PropertyInfo p) => p.Name.Contains(Actualizacion2.Destino ?? ""));
			bool result = true;
			try
			{
				List<StockInsumos> list = AponusDBContext.stockInsumos.Where((StockInsumos x) => x.IdInsumo == Actualizacion2.Id).ToList();
				foreach (StockInsumos item in list)
				{
					if (propertyInfo != null)
					{
						propertyInfo.SetValue(item, Actualizacion2.Cantidad);
					}
				}
				AponusDBContext.SaveChanges();
				return result;
			}
			catch (Exception)
			{
				return false;
			}
		}

		internal string? CrearDirectorioMovimientos_Local(string Proveedor)
		{
			try
			{
				string text = Path.Combine(Path.GetPathRoot(Environment.SystemDirectory), "Aponus");
				string text2 = Path.Combine(text, "Movimientos_Documentos");
				Proveedor = Path.Combine(text2, Proveedor);
				string text3 = Path.Combine(Proveedor, UTL_Fechas.ObtenerFechaHora().ToString("dd-MM-yyyy"));
				if (!Directory.Exists(text))
				{
					Directory.CreateDirectory(text);
				}
				if (!Directory.Exists(text2))
				{
					Directory.CreateDirectory(text2);
				}
				if (!Directory.Exists(Proveedor))
				{
					Directory.CreateDirectory(Proveedor);
				}
				if (!Directory.Exists(text3))
				{
					Directory.CreateDirectory(text3);
				}
				return text3;
			}
			catch (Exception)
			{
				return null;
			}
		}

		internal List<ArchivosMovimientosStock> CopiarArchivosMovimientos_Local(List<IFormFile> Archivos, string Directorio)
		{
			List<ArchivosMovimientosStock> list = new List<ArchivosMovimientosStock>();
			string[] array = new string[Archivos.Count];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = Guid.NewGuid().ToString();
				list.Add(new ArchivosMovimientosStock
				{
					HashArchivo = array[i].ToString()
				});
			}
			int num = 0;
			foreach (IFormFile Archivo in Archivos)
			{
				string extension = Path.GetExtension(Archivo.FileName);
				string NombreArchivo = array[num];
				ArchivosMovimientosStock archivosMovimientosStock = list.FirstOrDefault((ArchivosMovimientosStock x) => x.HashArchivo.Equals(NombreArchivo));
				string text = Path.Combine(Directorio, Path.GetFileNameWithoutExtension(NombreArchivo) + extension);
				using (FileStream target = new FileStream(text, FileMode.Create))
				{
					Archivo.CopyTo(target);
				}
				if (archivosMovimientosStock != null)
				{
					archivosMovimientosStock.PathArchivo = text.ToString();
					archivosMovimientosStock.HashArchivo = NombreArchivo;
					archivosMovimientosStock.MimeType = AD_Movimientos.ObtenerMimeType(text.ToString());
				}
				num++;
			}
			return list;
		}

		internal bool GuardarDatosArchivosMovimiento(AponusContext AponusDBContext, List<ArchivosMovimientosStock> DatosArchivos)
		{
			try
			{
				AponusDBContext.ArchivosStock.AddRange(DatosArchivos);
				AponusDBContext.SaveChanges();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		internal int? GuardarDatosMovimiento(AponusContext AponusDBContext, Stock_Movimientos Movimiento)
		{
			string sql = "INSERT INTO \"STOCK_MOVIMIENTOS\" (\"USUARIO_CREADO\", \"FECHA_HORA_CREADO\",\"ORIGEN\",\"DESTINO\",\"ID_PROVEEDOR_ORIGEN\", \"ID_PROVEEDOR_DESTINO\", \"ID_ESTADO_MOVIMIENTO\") \r\n                                    VALUES (@USUARIO_CREADO, @FECHA_HORA_CREADO,@ORIGEN,@DESTINO,  @ID_PROVEEDOR_ORIGEN, @ID_PROVEEDOR_DESTINO, 1)";
			try
			{
				AponusDBContext.Database.ExecuteSqlRaw(sql, new NpgsqlParameter("@USUARIO_CREADO", Movimiento.CreadoUsuario)
				{
					NpgsqlDbType = NpgsqlDbType.Varchar
				}, new NpgsqlParameter("@FECHA_HORA_CREADO", Movimiento.FechaHoraCreado)
				{
					NpgsqlDbType = NpgsqlDbType.Timestamp
				}, new NpgsqlParameter("@ORIGEN", Movimiento.Origen)
				{
					NpgsqlDbType = NpgsqlDbType.Varchar
				}, new NpgsqlParameter("@DESTINO", Movimiento.Destino)
				{
					NpgsqlDbType = NpgsqlDbType.Varchar
				}, new NpgsqlParameter("@ID_PROVEEDOR_DESTINO", Movimiento.IdProveedor)
				{
					NpgsqlDbType = NpgsqlDbType.Integer
				});
				int? result = AponusDBContext.Stock_Movimientos.Select((Stock_Movimientos x) => x.IdMovimiento).Max();
				return result;
			}
			catch (DbUpdateException)
			{
				return null;
			}
		}

		internal bool GuardarSuministrosMovimiento(AponusContext AponusDBContext, List<SuministrosMovimientosStock> Suministros)
		{
			foreach (SuministrosMovimientosStock Suministro in Suministros)
			{
				Suministro.IdEstado = 1;
				Suministro.EstadosSuministrosMovimientosStockNavigation = AponusDBContext.EstadoSuministrosMovimientosStock.FirstOrDefault((EstadosSuministrosMovimientosStock x) => x.IdEstado == 1);
			}
			try
			{
				foreach (SuministrosMovimientosStock suministro in Suministros)
				{
					SuministrosMovimientosStock suministrosMovimientosStock = AponusDBContext.SuministrosMovimientoStock.Where((SuministrosMovimientosStock x) => x.IdMovimiento == suministro.IdMovimiento && x.IdSuministro == suministro.IdSuministro).FirstOrDefault();
					if (suministrosMovimientosStock != null)
					{
						AponusDBContext.Entry(suministrosMovimientosStock).CurrentValues.SetValues(suministro);
					}
					else
					{
						AponusDBContext.Add(suministro);
					}
				}
				AponusDBContext.SaveChanges();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		internal List<DTOTiposProductos> ListarProductos()
		{
			return (from x in (from aux in AponusDBContext.Producto_Tipo_Descripcion
					join ptd in AponusDBContext.ProductosTipos on aux.IdTipo equals ptd.IdTipo
					select new { aux, ptd } into auxPtd
					join pDesc in AponusDBContext.ProductosDescripcions on auxPtd.aux.IdDescripcion equals pDesc.IdDescripcion
					select new { auxPtd, pDesc }).AsQueryable()
				select new DTOTiposProductos
				{
					IdTipo = x.auxPtd.ptd.IdTipo,
					DescripcionTipo = (x.auxPtd.ptd.DescripcionTipo ?? ""),
					DescripcionProductos = (from pd in AponusDBContext.ProductosDescripcions
						where pd.IdDescripcion == x.pDesc.IdDescripcion
						select new DTODescripcionesProductos
						{
							IdDescripcion = pd.IdDescripcion,
							NombreDescripcion = (pd.DescripcionProducto ?? ""),
							Productos = (from prod in pd.Productos
								where prod.IdDescripcion == pd.IdDescripcion && prod.IdTipo == x.auxPtd.ptd.IdTipo && prod.IdEstado != 0
								select prod into x
								select new DTOStockProductos
								{
									IdProducto = x.IdProducto,
									IdTipo = x.IdTipo,
									Cantidad = ((x.Cantidad != null) ? (((object)x.Cantidad).ToString() + "Ud.") : "-"),
									DiametroNominal = ((x.DiametroNominal != null) ? (((object)x.DiametroNominal).ToString() + "mm") : "-"),
									PrecioLista = ((x.PrecioLista != null) ? ((object)x.PrecioLista).ToString() : "-"),
									PrecioFinal = ((x.PrecioFinal != null) ? ((object)x.PrecioFinal).ToString() : "-"),
									Tolerancia = ((!string.IsNullOrEmpty(x.Tolerancia)) ? x.Tolerancia : "-"),
									PorcentajeGanancia = ((x.PorcentajeGanancia != null) ? (((object)x.PorcentajeGanancia).ToString() + "%") : "-")
								} into prod
								orderby Convert.ToInt32(prod.DiametroNominal ?? "".Replace("mm", "").Replace("-", ""))
								select prod).ToList()
						} into x
						orderby x.NombreDescripcion
						select x).ToList()
				} into x
				orderby x.DescripcionTipo
				select x).ToList();
		}
	}
	public class AD_Suministros
	{
		private readonly AponusContext AponusDBContext;

		public AD_Suministros(AponusContext _aponusDBContext)
		{
			AponusDBContext = _aponusDBContext;
		}

		public List<(string, string, string?)> ObtenerDetalles(List<string> SuministrosId)
		{
			List<string> IdSuministrosTodos = SuministrosId.ToList();
			List<UTL_FormatoSuministros> first = (from ComponentesId in AponusDBContext.ComponentesDetalles.Join(AponusDBContext.ComponentesDescripcions, (ComponentesDetalle Detalles) => Detalles.IdDescripcion, (ComponentesDescripcion Descripciones) => Descripciones.IdDescripcion, (ComponentesDetalle _Detalles, ComponentesDescripcion _Descripciones) => new
				{
					detales = _Detalles,
					descripciones = _Descripciones
				})
				where IdSuministrosTodos.Contains(ComponentesId.detales.IdInsumo)
				select ComponentesId into reg
				select new UTL_FormatoSuministros
				{
					IdSuministro = reg.detales.IdInsumo,
					Descripcion = reg.descripciones.Descripcion,
					DiametroNominal = reg.detales.DiametroNominal,
					Diametro = reg.detales.Diametro,
					Tolerancia = reg.detales.Tolerancia,
					Espesor = reg.detales.Espesor,
					Longitud = reg.detales.Longitud,
					Altura = reg.detales.Altura,
					Perfil = reg.detales.Perfil,
					UnidadAlmacenamiento = reg.detales.IdAlmacenamiento,
					UnidadFraccionamiento = reg.detales.IdFraccionamiento
				}).ToList();
			List<UTL_FormatoSuministros> second = (from ProductosId in AponusDBContext.Productos.Join(AponusDBContext.ProductosDescripcions, (Producto Detalles) => Detalles.IdDescripcion, (ProductosDescripcion Descripciones) => Descripciones.IdDescripcion, (Producto _Detalles, ProductosDescripcion _Descripciones) => new
				{
					detales = _Detalles,
					descripciones = _Descripciones
				})
				where IdSuministrosTodos.Contains(ProductosId.detales.IdProducto)
				select ProductosId into reg
				select new UTL_FormatoSuministros
				{
					IdSuministro = reg.detales.IdProducto,
					Descripcion = reg.descripciones.DescripcionProducto,
					DiametroNominal = reg.detales.DiametroNominal,
					Tolerancia = reg.detales.Tolerancia,
					UnidadAlmacenamiento = "Ud"
				}).ToList();
			List<UTL_FormatoSuministros> list = first.Concat(second).ToList();
			return new UTL_NombresSuministros().formatearNombres(list);
		}
	}
	public class AD_Usuarios
	{
		private readonly AponusContext AponusDBContext;

		public AD_Usuarios(AponusContext _aponusContext)
		{
			AponusDBContext = _aponusContext;
		}

		internal DTOUsuarios? ValidarCredenciales(DTOUsuarios usuario)
		{
			DTOUsuarios usuario2 = usuario;
			List<DTOUsuarios> list = new List<DTOUsuarios>();
			DTOUsuarios dTOUsuarios = new DTOUsuarios();
			if (usuario2.Usuario != null && usuario2.Usuario.Contains("@"))
			{
				list = (from x in AponusDBContext.Usuarios
					where x.Correo == usuario2.Usuario && x.Contraseña == usuario2.Contraseña
					select new DTOUsuarios
					{
						Usuario = x.Usuario,
						IdPerfil = x.IdPerfil
					}).ToList();
				if (list.Count() != 0)
				{
					dTOUsuarios.Usuario = list[0].Usuario;
					dTOUsuarios.IdPerfil = list[0].IdPerfil;
				}
				return dTOUsuarios;
			}
			if (usuario2.Usuario != null && !usuario2.Usuario.Contains("@"))
			{
				list = (from x in AponusDBContext.Usuarios
					where x.Usuario == usuario2.Usuario && x.Contraseña == usuario2.Contraseña
					select new DTOUsuarios
					{
						Usuario = x.Usuario,
						Contraseña = x.Contraseña,
						IdPerfil = x.IdPerfil
					}).ToList();
				if (list.Count() != 0)
				{
					dTOUsuarios.Usuario = list[0].Usuario;
					dTOUsuarios.IdPerfil = list[0].IdPerfil;
				}
				return dTOUsuarios;
			}
			return null;
		}

		public async Task Nuevo(Usuarios Usuario)
		{
			Usuarios Usuario2 = Usuario;
			Usuario2.Perfil = AponusDBContext.perfilesUsuarios.FirstOrDefault((PerfilesUsuarios x) => x.IdPerfil == Usuario2.IdPerfil) ?? new PerfilesUsuarios();
			using IDbContextTransaction transaccion = await AponusDBContext.Database.BeginTransactionAsync();
			try
			{
				await AponusDBContext.Usuarios.AddAsync(Usuario2);
				await AponusDBContext.SaveChangesAsync();
				await transaccion.CommitAsync();
			}
			catch (Exception)
			{
				await transaccion.RollbackAsync();
			}
		}
	}
	public class AD_Ventas
	{
		private readonly AponusContext AponusDBContext;

		private readonly AD_Stocks stocks;

		public AD_Ventas(AponusContext _aponusContext, AD_Stocks _stocks)
		{
			AponusDBContext = _aponusContext;
			stocks = _stocks;
		}

		public async Task<bool> Guardar(Ventas Venta)
		{
			bool roolbackResult = false;
			using IDbContextTransaction transaccion = AponusDBContext.Database.BeginTransaction();
			Venta.Cliente = AponusDBContext.Entidades.Find(Venta.IdCliente) ?? new Entidades();
			Venta.Usuario = AponusDBContext.Usuarios.Find(Venta.IdUsuario) ?? new Usuarios();
			Venta.Estado = AponusDBContext.estadosVentas.Find(Venta.IdEstadoVenta) ?? new EstadosVentas();
			if (Venta.Pagos != null)
			{
				Venta.Pagos.ToList().ForEach(delegate(PagosVentas item)
				{
					item.MedioPago = AponusDBContext.MediosPagos.Find(item.IdMedioPago) ?? new MediosPago();
				});
			}
			if (Venta.DetallesVenta != null)
			{
				Venta.DetallesVenta.ToList().ForEach(delegate(VentasDetalles item)
				{
					item.IdProductoNavigation = AponusDBContext.Productos.Find(item.IdProducto) ?? new Producto();
				});
			}
			if (Venta.Cuotas != null)
			{
				Venta.Cuotas.ToList().ForEach(delegate(CuotasVentas item)
				{
					item.EstadoCuota = AponusDBContext.estadosCuotasVentas.Find(item.IdEstadoCuota) ?? new EstadosCuotasVentas();
				});
			}
			await AponusDBContext.ventas.AddAsync(Venta);
			IEnumerable<VentasDetalles> detallesVenta = Venta.DetallesVenta;
			foreach (VentasDetalles item2 in detallesVenta ?? Enumerable.Empty<VentasDetalles>())
			{
				roolbackResult = stocks.DisminuirStockProducto(new DTOStockUpdate
				{
					IdExistencia = item2.IdProducto,
					Cantidad = item2.Cantidad
				}, AponusDBContext);
			}
			if (roolbackResult)
			{
				await AponusDBContext.SaveChangesAsync();
				await transaccion.CommitAsync();
				await AponusDBContext.DisposeAsync();
				return true;
			}
			transaccion.Rollback();
			await AponusDBContext.DisposeAsync();
			return false;
		}

		public IQueryable<Ventas> ListarVentas()
		{
			return QueryableExtensions.Include(QueryableExtensions.Include(QueryableExtensions.Include(QueryableExtensions.Include(AponusDBContext.ventas.Where((Ventas Estado) => Estado.IdEstadoVenta != 0), (Ventas x) => x.DetallesVenta), (Ventas x) => x.Cuotas), (Ventas x) => x.Pagos), (Ventas Cli) => Cli.Cliente).AsQueryable();
		}

		internal void EliminarEstado(EstadosVentas EstadoVenta)
		{
			EstadosVentas estadosVentas = AponusDBContext.estadosVentas.Find(typeof(EstadosVentas), EstadoVenta.IdEstadoVenta);
			if (estadosVentas != null)
			{
				estadosVentas.IdEstado = 0;
				AponusDBContext.SaveChanges();
			}
		}

		internal async Task<IActionResult> GuardarEstado(DTOEstadosVentas NuevoEstado)
		{
			DTOEstadosVentas NuevoEstado2 = NuevoEstado;
			if (NuevoEstado2.IdEstadoVenta.HasValue)
			{
				EstadosVentas Estado = await AponusDBContext.estadosVentas.FirstOrDefaultAsync((EstadosVentas x) => (int?)x.IdEstadoVenta == NuevoEstado2.IdEstado && x.IdEstado != 0);
				if (Estado == null)
				{
					await AponusDBContext.estadosVentas.AddAsync(new EstadosVentas
					{
						Descripcion = (NuevoEstado2?.Descripcion ?? "")
					});
				}
				else
				{
					Estado.Descripcion = NuevoEstado2.Descripcion ?? Estado.Descripcion;
					Estado.IdEstado = NuevoEstado2.IdEstado ?? Estado.IdEstado;
					await AponusDBContext.SaveChangesAsync();
				}
				return new StatusCodeResult(200);
			}
			EstadosVentas Existe = AponusDBContext.estadosVentas.FirstOrDefault((EstadosVentas x) => x.Descripcion.Equals(NuevoEstado2.Descripcion) && x.IdEstado != 0);
			if (Existe != null)
			{
				return new ContentResult
				{
					Content = "Nombre de Estado Existente. No se aplicarion los cambios",
					ContentType = "application/json",
					StatusCode = 400
				};
			}
			await AponusDBContext.estadosVentas.AddAsync(new EstadosVentas
			{
				Descripcion = (NuevoEstado2?.Descripcion ?? "")
			});
			return new StatusCodeResult(200);
		}
	}
}
