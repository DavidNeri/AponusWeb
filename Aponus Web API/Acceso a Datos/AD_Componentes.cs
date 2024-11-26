using Aponus_Web_API.Modelos;
using Aponus_Web_API.Objetos_de_Transferencia_de_Datos;
using Fractions;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Aponus_Web_API.Acceso_a_Datos
{
    public class AD_Componentes
    {
        private readonly AponusContext AponusDbContext;

        public AD_Componentes(AponusContext _AponusDbContext)
        {
            AponusDbContext = _AponusDbContext;
        }
        internal List<(string Id, int IdDescripcion, decimal? Longitud, decimal? Peso)> ListarIdDescripcionComponentesProducto(string[] Componentes)
        {
            List<(string, int, decimal?, decimal?)> ComponentesDetalle = AponusDbContext.ComponentesDetalles
                                                                                           .Where(x => Componentes.ToList().Contains(x.IdInsumo))
                                                                                           .Select(x => new { x.IdInsumo, x.IdDescripcion, x.Longitud, x.Peso })
                                                                                           .AsEnumerable()
                                                                                           .Select(x => (x.IdInsumo, x.IdDescripcion, x.Longitud, x.Peso))
                                                                                           .ToList();

            return ComponentesDetalle;
        }
        internal async Task<List<Productos_Componentes>> ObtenerComponentes(string IdProducto)
        {
            return await AponusDbContext.Componentes_Productos
                                     .Where(x => x.IdProducto == IdProducto)
                                     .ToListAsync();
        }
        internal List<ComponentesDescripcion>? ListarNombresComponentes()
        {
            List<ComponentesDescripcion>? DescripcionesComponentes = AponusDbContext.ComponentesDescripcions
                .Select(x => new ComponentesDescripcion()
                {
                    IdDescripcion = x.IdDescripcion,
                    Descripcion = x.Descripcion ?? "",
                    IdAlmacenamiento = x.IdAlmacenamiento,
                    IdFraccionamiento = x.IdFraccionamiento,
                    

                })
                .ToList();

            return DescripcionesComponentes;
        }
        internal void GuardarComponenteProd(Productos_Componentes componente)
        {

            var ValidarExistencia = AponusDbContext.Componentes_Productos
            .FirstOrDefault(c => c.IdProducto == componente.IdProducto &&
                                    c.IdComponente == componente.IdComponente);

            var Estado = AponusDbContext.EstadosProductosComponente.FirstOrDefault(x => x.IdEstado == 1);

            if (ValidarExistencia != null)
            {
                ValidarExistencia.Cantidad = componente.Cantidad;
                ValidarExistencia.Peso = componente.Peso;
                ValidarExistencia.Longitud = componente.Longitud;
                ValidarExistencia.IdEstado = Estado!.IdEstado;
                ValidarExistencia.IdEstadoNavigation = Estado!;

                AponusDbContext.SaveChanges();
            }
            else
            {
                componente.IdEstado = Estado!.IdEstado;
                componente.IdEstadoNavigation = Estado!;

                AponusDbContext.Componentes_Productos.Add(componente);
                AponusDbContext.SaveChanges();
            }


        }
        internal JsonResult ObtenerComponentesFormateados(DTOProducto Producto)
        {
            var ComponentesProducto = AponusDbContext.Componentes_Productos
                    .Where(x => x.IdProducto == Producto.IdProducto)
                    .Join(AponusDbContext.ComponentesDetalles,
                        _Componentes => _Componentes.IdComponente,
                        _DetalleComponentes => _DetalleComponentes.IdInsumo,
                        (_Componentes, _DetalleComponentes) => new
                        {
                            _Componentes,
                            _DetalleComponentes
                        })

                    .Join(AponusDbContext.ComponentesDescripcions,
                        _DetComponentes => _DetComponentes._DetalleComponentes.IdDescripcion,
                        _NombreComponentes => _NombreComponentes.IdDescripcion,
                        (_DetComponentes, _NombreComponentes) => new
                        {
                            _DetComponentes,
                            _NombreComponentes
                        })
                    .Join(AponusDbContext.stockInsumos,
                        _JoinResult => _JoinResult._DetComponentes._DetalleComponentes.IdInsumo,
                        _StockComponentes => _StockComponentes.IdInsumo,
                        (_JoinResult, _StockComponentes) => new
                        {
                            _IdProducto = _JoinResult._DetComponentes._Componentes.IdProducto,
                            _IdComponente = _JoinResult._DetComponentes._Componentes.IdComponente ?? "",
                            _Descripcion = _JoinResult._NombreComponentes.Descripcion ?? "",
                            _Diametro = _JoinResult._DetComponentes._DetalleComponentes.Diametro ?? null,
                            _Longitud = _JoinResult._DetComponentes._DetalleComponentes.Longitud ?? null,
                            _Altura = _JoinResult._DetComponentes._DetalleComponentes.Altura ?? null,
                            _Espesor = _JoinResult._DetComponentes._DetalleComponentes.Espesor ?? null,
                            _Perfil = _JoinResult._DetComponentes._DetalleComponentes.Perfil ?? null,
                            _Tolerancia = _JoinResult._DetComponentes._DetalleComponentes.Tolerancia ?? "",
                            _DiametroNominal = _JoinResult._DetComponentes._DetalleComponentes.DiametroNominal ?? null,
                            _Largo = _JoinResult._DetComponentes._Componentes.Longitud ?? null,

                            StockComponente = new DTOStockFormateado
                            {
                                IdInsumo = _StockComponentes.IdInsumo,
                                Recibido = _StockComponentes.Recibido != null ? _StockComponentes.Recibido.ToString() : "Sin Stock",
                                Granallado = _StockComponentes.Granallado != null ? _StockComponentes.Granallado.ToString() : "Sin Stock",
                                Pintura = _StockComponentes.Pintura != null ? _StockComponentes.Pintura.ToString() : "Sin Stock",
                                Proceso = _StockComponentes.Proceso != null ? _StockComponentes.Proceso.ToString() : "Sin Stock",
                                Moldeado = _StockComponentes.Moldeado != null ? _StockComponentes.Moldeado.ToString() : "Sin Stock",

                                Total = ((_StockComponentes.Pintura ?? 0) + (_StockComponentes.Moldeado ?? 0) + (_StockComponentes.Recibido ?? 0) + (_StockComponentes.Proceso ?? 0) + (_StockComponentes.Granallado ?? 0)).ToString(),
                                Requerido = ((_JoinResult._DetComponentes._Componentes.Cantidad ?? 0) * Producto.Cantidad).ToString(),
                            }
                        })
                    .GroupBy(cp => new
                    {
                        cp._IdComponente,
                        cp._IdProducto,                        
                        cp._Descripcion,
                        cp._Longitud,
                        cp._Perfil,
                        cp._DiametroNominal,
                        cp._Altura,
                        cp._Espesor,
                        cp._Largo,
                        cp._Diametro,
                        cp._Tolerancia
                    })

                    .Select(group => new
                    {
                        idProducto = group.Key._IdProducto,
                        IdComponente = group.Key._IdComponente,
                        Descripcion = group.Key._Descripcion,
                        Perfil = group.Key._Perfil,
                        Longitud = group.Key._Longitud,
                        DiametroNominal = group.Key._DiametroNominal,
                        Altura = group.Key._Altura,
                        Largo = group.Key._Largo,
                        Diametro = group.Key._Diametro,
                        Espesor = group.Key._Espesor,
                        Tolerancia = group.Key._Tolerancia,
                        StockComponente = group.Select(cp => cp.StockComponente).ToList(),

                    })
                    .ToList();



            List<string> AllComponentesIds = ComponentesProducto.Select(cp => cp.IdComponente).ToList();

            List<DTODetallesComponenteProducto> PropiedadesComponentes = AponusDbContext.ComponentesDetalles
                .Where(x => AllComponentesIds.Contains(x.IdInsumo))
                .Select(x => new DTODetallesComponenteProducto()
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
                    Peso = x.Peso,

                })
                .ToList();

            List<DTOProductoComponente> productos = new List<DTOProductoComponente>();

            foreach (var cp in ComponentesProducto)
            {
                string? IdComponente = cp.IdComponente ?? "";
                string? descripcion = cp.Descripcion ?? "";
                string? diametro = cp.Diametro != null ? string.Format("{0:####}", cp.Diametro) : null;
                string? longitud = cp.Longitud != null ? string.Format("{0:#,0}", cp.Longitud) : null;
                string? altura = cp.Altura != null ? string.Format("{0:####}", cp.Altura) : null;
                string? espesor = cp.Espesor != null ? string.Format("{0:####}", cp.Espesor) : null;
                string? perfil = cp.Perfil != null ? string.Format("{0:####}", cp.Perfil) : null;
                string? tolerancia = cp.Tolerancia ?? "";
                string? DiametroNominal = cp.DiametroNominal.ToString() ?? "";
                string? largo = cp.Largo != null ? string.Format("{0:####}", cp.Largo) : null;




                StringBuilder sb = new StringBuilder();
                sb.Append($"{descripcion}");
                if (diametro != null)
                    sb.Append($", Diametro:{diametro}mm");
                if (longitud != null)
                    sb.Append($", Longitud:{longitud}mm");
                if (altura != null)
                    sb.Append($", Altura:{altura}mm");
                if (espesor != null)
                    sb.Append($", Espesor:{espesor}mm");
                if (perfil != null)
                    sb.Append($", Perfil:{perfil}");
                if (tolerancia != null && tolerancia != "")
                    sb.Append($", Tolerancia:{tolerancia}");
                if (DiametroNominal != null && DiametroNominal != "")
                    sb.Append($", DN:{DiametroNominal}mm");

                foreach (var componente in cp.StockComponente)
                {
                    componente.NombreInsumo = descripcion;
                }


                DTOProductoComponente productoComponente = new DTOProductoComponente
                {
                    IdComponente = cp.IdComponente ?? "",
                    Descripcion = sb.ToString(),
                    Perfil = cp.Perfil,
                    Longitud = cp.Longitud,
                    DiametroNominal = cp.DiametroNominal,
                    Altura = cp.Altura,
                    Largo = cp.Largo,
                    Diametro = cp.Diametro,
                    Espesor = cp.Espesor,
                    Tolerancia = cp.Tolerancia ?? "",
                    StockFormateado = cp.StockComponente
                };

                productos.Add(productoComponente);
            }


            foreach (var producto in productos)
            {

                producto.Perfil = null;
                producto.Longitud = null;
                producto.DiametroNominal = null;
                producto.Altura = null;
                producto.Largo = null;
                producto.Diametro = null;
                producto.Espesor = null;
                producto.Tolerancia = "";

                string? SiglaAlmacenamiento = PropiedadesComponentes
                    .Where(x => x.idComponente != null && x.idComponente.Contains(producto.IdComponente))
                    .Select(x => x.idAlmacenamiento)
                    .FirstOrDefault();

                string? SiglaFraccionamiento = PropiedadesComponentes
                    .Where(x => x.idComponente != null && x.idComponente.Contains(producto.IdComponente))
                    .Select(x => x.idFraccionamiento)
                    .FirstOrDefault();

                foreach (var item in producto.StockFormateado ?? Enumerable.Empty<DTOStockFormateado>())
                {
                    var TipoPropiedadStock = item.GetType();
                    PropertyInfo[] PropiedadesStock = TipoPropiedadStock.GetProperties();

                    foreach (var propiedad in PropiedadesStock)
                    {


                        if (propiedad.GetValue(item) != null && !propiedad.Name.Contains("IdInsumo") && !propiedad.Name.Contains("NombreInsumo") && propiedad?.GetValue(item)?.ToString() != "Sin Stock")
                        {
                            if (SiglaFraccionamiento != null)
                            {
                                if (propiedad != null && propiedad.Name.Contains("Requerido"))
                                {
                                    DTODetallesComponenteProducto? Componente = PropiedadesComponentes.FirstOrDefault(x => x.idComponente == item.IdInsumo);

                                    string? CantidadRequerida = (string?)item.GetType().GetProperty(propiedad.Name)?.GetValue(item);

                                    if (CantidadRequerida == "") CantidadRequerida = "0";

                                    //Si el componente no tiene diametro, ni espesor, ni altura, ni DN, es decir si es una junta
                                    if (Componente?.Diametro == null && Componente?.Perfil != null && Componente.Espesor == null && Componente.Altura == null && Componente.DiametroNominal == null && !Regex.IsMatch(CantidadRequerida ?? "", "[a-zA-Z]"))
                                    {
                                        var TotalInsumosStock = Decimal.Parse(item.Total ?? "", CultureInfo.InvariantCulture);
                                        var LongitudInsumo = Componente.Longitud;
                                        var _CantidadRequerida = Decimal.Parse(CantidadRequerida ?? "", CultureInfo.InvariantCulture);
                                        var LongitudNecesaria = _CantidadRequerida * Producto.Cantidad;
                                        var InsumosNecesarios = LongitudNecesaria / LongitudInsumo ?? 1;
                                        var UnidadAlternativa = (Fraction)InsumosNecesarios;

                                        item.GetType()
                                            .GetProperty(propiedad.Name)?
                                            .SetValue(item, item
                                            .GetType()
                                            .GetProperty(propiedad.Name)?
                                            .GetValue(item) +
                                            SiglaFraccionamiento + " - " +
                                            UnidadAlternativa + " " +
                                            SiglaAlmacenamiento);

                                    }
                                    else if (!Regex.IsMatch(CantidadRequerida ?? "", "[a-zA-Z]"))
                                    {
                                        decimal? PesoComponente = Componente?.Peso;

                                        if (PesoComponente == null) PesoComponente = 0;

                                        var UnidadAlternativa = ((Decimal.Parse(CantidadRequerida ?? "", CultureInfo.InvariantCulture) * PesoComponente) * Producto.Cantidad);

                                        UnidadAlternativa = UnidadAlternativa != null ? Math.Round((decimal)UnidadAlternativa, 1) : 0;

                                        if (UnidadAlternativa > 0)
                                        {
                                            item.GetType().GetProperty(propiedad.Name)?
                                            .SetValue(item, item.GetType().GetProperty(propiedad.Name)?.GetValue(item)
                                            + " " + SiglaFraccionamiento + " - " + UnidadAlternativa + " " + SiglaAlmacenamiento);
                                        }
                                        else
                                        {
                                            item.GetType().GetProperty(propiedad.Name)?
                                            .SetValue(item, item.GetType().GetProperty(propiedad.Name)?.GetValue(item)
                                            + " " + SiglaFraccionamiento);
                                        }

                                    }
                                }
                                else
                                {
                                    if (propiedad != null)
                                    {
                                        item.GetType().GetProperty(propiedad.Name)?
                                            .SetValue(item, item.GetType().GetProperty(propiedad.Name)?.GetValue(item)
                                            + " " + SiglaAlmacenamiento);
                                    }

                                }
                            }
                            else
                            {
                                if (propiedad != null)
                                {
                                    item.GetType().GetProperty(propiedad.Name)?
                                        .SetValue(item, item.GetType().GetProperty(propiedad.Name)?.GetValue(item)
                                        + " " + SiglaAlmacenamiento);
                                }

                            }
                        }
                    }
                }
            }

            string? IdProd = ComponentesProducto.Select(x => x.idProducto).FirstOrDefault();

            var result = new
            {
                idProducto = IdProd,
                Componentes = productos
            };

            return new JsonResult(result);
        }
        internal JsonResult? ListarProp(string[] propiedadesNulas, List<(string Nombre, string Valor)> propiedadesNoNulas)
        {

            var dbContext = AponusDbContext;
            var query = GenerarWhereAND(propiedadesNoNulas);


            JsonResult? jsonResult = null;
            int i = 0;

            do
            {
                var propertyType = typeof(ComponentesDetalle).GetProperty(propiedadesNulas[i])?.PropertyType;

                // Crear la expresión lambda para la propiedad a seleccionar
                var parameter = Expression.Parameter(typeof(ComponentesDetalle), "x");
                var property = Expression.Property(parameter, propiedadesNulas[i]);
                Expression<Func<ComponentesDetalle, object>>? lambda = null;

                // Agregar comprobación para manejar valores nulos
                var defaultValue = propertyType != null && propertyType.IsValueType ? Activator.CreateInstance(propertyType) : null;

                if (propertyType != null)
                {
                    var propertyOrDefault = Expression.Coalesce(property, Expression.Constant(defaultValue, propertyType));
                    lambda = Expression.Lambda<Func<ComponentesDetalle, object>>(Expression.Convert(propertyOrDefault, typeof(object)), parameter);
                }
                else
                {
                    throw new ArgumentNullException(nameof(propertyType), "El tipo de la propiedad no puede ser nulo.");
                }

                var resultados = query.Select(lambda).Distinct().ToArray();
                var Valores = resultados.Where(x => x != null && !string.IsNullOrEmpty(x.ToString()));

                if (Valores.Any())
                {
                    var Columna = AponusDbContext.Set<ComponentesDetalle>()
                        .Select(e => typeof(ComponentesDetalle).GetProperty(propiedadesNulas[i]))?
                        .First()?
                        .Name;

                    var ResultadosTotales = new { Valores, Columna };
                    jsonResult = new JsonResult(ResultadosTotales);
                }
                i++;

            } while (jsonResult == null && i < propiedadesNulas.Length);


            jsonResult ??= new JsonResult(null);

            return jsonResult;

        }
        internal (List<ComponentesDetalle>? LstComponentes, Exception? Error) ListarDetalleComponentes(int? IdDescripcion)
        {
            try
            {
                List<ComponentesDetalle> LstComponentes = AponusDbContext.ComponentesDetalles
               .Where(x => x.IdEstado != 0 && (IdDescripcion == null || x.IdDescripcion == IdDescripcion))
               .Select(x => new ComponentesDetalle()
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
                   IdAlmacenamiento = AponusDbContext.ComponentesDescripcions
                                                        .Where(y => y.IdDescripcion == x.IdDescripcion)
                                                        .Select(X => X.IdAlmacenamiento)
                                                        .FirstOrDefault(),
                   IdFraccionamiento = AponusDbContext.ComponentesDescripcions
                                                        .Where(y => y.IdDescripcion == x.IdDescripcion)
                                                        .Select(X => X.IdFraccionamiento)
                                                        .FirstOrDefault(),
               })
               .ToList();

                return (LstComponentes, null);
            }
            catch (Exception Error)
            {
                return (null, Error);
            }

        }
        internal JsonResult? ObtenerId(List<(string Nombre, string Valor)> propiedadesNoNulas)
        {
            var query = GenerarWhereAND(propiedadesNoNulas);
            var Insumo = query.Select(x => x.IdInsumo).ToList();
            JsonResult jsonResult = new JsonResult(null);

            if (Insumo.Count() > 1)
            {
                jsonResult = new JsonResult("Los valores no corresponden a un elemento unico");
            }
            else
            {
                jsonResult = new JsonResult(new DTOComponentesProducto()
                {
                    IdComponente = Insumo[0],
                });
            }

            return jsonResult;
        }
        private IQueryable<ComponentesDetalle> GenerarWhereAND(List<(string Nombre, string Valor)> propiedadesNoNulas)
        {
            var dbContext = AponusDbContext;
            var query = dbContext.ComponentesDetalles.AsQueryable().Where(x => true);

            foreach ((string Nombre, string Valor) propiedad in propiedadesNoNulas)
            {
                // Obtener el valor de la propiedad
                var valor = propiedad.Valor;
                int valorNumeroEntero;
                decimal numeroDecimal;

                // Si la propiedad tiene un valor, agregarla al Where
                if (valor != null)
                {
                    var nombre = propiedad.Nombre;
                    var propertyType = typeof(ComponentesDetalle).GetProperty(nombre)?.PropertyType;

                    if (int.TryParse(valor, out valorNumeroEntero))
                    {
                        var parameter = Expression.Parameter(typeof(ComponentesDetalle), "x");
                        var property = Expression.Property(parameter, nombre);

                        try
                        {
                            var constant = Expression.Constant(valorNumeroEntero, typeof(int?));
                            var equals = Expression.Equal(property, constant);
                            var lambda = Expression.Lambda<Func<ComponentesDetalle, bool>>(equals, parameter);
                            query = query.Where(lambda);

                        }
                        catch (InvalidOperationException)
                        {
                            var constant = Expression.Constant(valorNumeroEntero, typeof(int));
                            var equals = Expression.Equal(property, constant);
                            var lambda = Expression.Lambda<Func<ComponentesDetalle, bool>>(equals, parameter);
                            query = query.Where(lambda);
                        }

                    }
                    else if (decimal.TryParse(valor, out numeroDecimal))
                    {
                        var parameter = Expression.Parameter(typeof(ComponentesDetalle), "x");
                        var property = Expression.Property(parameter, nombre);
                        var constant = Expression.Constant(numeroDecimal, typeof(decimal?));
                        var equals = Expression.Equal(property, constant);
                        var lambda = Expression.Lambda<Func<ComponentesDetalle, bool>>(equals, parameter);
                        query = query.Where(lambda);
                    }
                    else
                    {
                        var typedValue = Convert.ChangeType(valor, propertyType);
                        var parameter = Expression.Parameter(typeof(ComponentesDetalle), "x");
                        var property = Expression.Property(parameter, nombre);


                        // Agregar la condición al Where
                        if (property != null)
                        {
                            var value = Expression.Constant(typedValue);
                            var equals = Expression.Equal(property, value);
                            var lambda = Expression.Lambda<Func<ComponentesDetalle, bool>>(equals, parameter);

                            // Agregar la condición al Where
                            query = query.Where(lambda);
                        }
                    }


                }
            }
            return query;
        }
        internal (int?Resultado, Exception?ex) GuardarComponente(ComponentesDetalle componentesDetalle)
        {
            using var transaccion = AponusDbContext.Database.BeginTransaction();
            try
            {
                var ExisteDetalleComponente = AponusDbContext.ComponentesDetalles.FirstOrDefault(x => x.IdInsumo == componentesDetalle.IdInsumo);
                var ExisteStockComponente = AponusDbContext.stockInsumos.FirstOrDefault(x => x.IdInsumo == componentesDetalle.IdInsumo);
                componentesDetalle.IdEstadoNavigation = AponusDbContext.EstadosComponentesDetalle.FirstOrDefault(x => x.IdEstado == componentesDetalle.IdEstado);

                if (ExisteDetalleComponente == null)
                    AponusDbContext.ComponentesDetalles.Add(componentesDetalle);
                else
                    AponusDbContext.Entry(ExisteDetalleComponente).CurrentValues.SetValues(componentesDetalle);

                if (ExisteStockComponente == null)
                {
                    AponusDbContext.stockInsumos.Add(new StockInsumos()
                    {
                        Granallado = 0,
                        IdInsumo = componentesDetalle.IdInsumo,
                        Moldeado = 0,
                        Pendiente = 0,
                        Pintura = 0,
                        Proceso = 0,
                        Recibido = 0,
                    });
                }
                else
                {
                    ExisteStockComponente.Proceso = 0;
                    ExisteStockComponente.Granallado = 0;
                    ExisteStockComponente.Pintura = 0;
                    ExisteStockComponente.Pendiente = 0;
                    ExisteStockComponente.Recibido = 0;
                    ExisteStockComponente.Moldeado = 0;

                    AponusDbContext.Add(ExisteStockComponente);

                }

                 AponusDbContext.SaveChanges();
                 transaccion.Commit();

                return (StatusCodes.Status200OK, null);
            }
            catch (Exception ex ) 
            {
                 transaccion.Rollback();    
                return (null, ex);
            }
            
        }
        internal async Task<(List<ComponentesDescripcion>? Listado, Exception? Error)> ListarTiposAlacenamiento(int? IdDescripcionComponente)
        {
            try
            {
                List<ComponentesDescripcion>? Listado = await AponusDbContext.ComponentesDescripcions
                    .Where(x => x.IdDescripcion == IdDescripcionComponente || IdDescripcionComponente == null)
                    .Select(x => new ComponentesDescripcion()
                    {
                        IdDescripcion = x.IdDescripcion,
                        Descripcion = x.Descripcion,
                        IdFraccionamiento = x.IdFraccionamiento,
                        IdAlmacenamiento = x.IdAlmacenamiento,

                    }).ToListAsync();

                return (Listado, null);
            }
            catch (Exception Error)
            {
                return (null, Error);
            }

        }
        internal  JsonResult ObtenerNuevoId(string componentDescription)
        {
            string IdComponente = "";
            List<string> IdComponenteList =  AponusDbContext.ComponentesDetalles
                .Where(x => x.IdInsumo.Contains(componentDescription.Substring(0, 3).ToUpper()))
                .Select(x => x.IdInsumo.Substring(3))
                .ToList();            

            if (IdComponenteList.Count > 0)
            {
                List<int> numeros = IdComponenteList
                    .Select(x => Regex.Match(x, @"\d+")) // Extrae la parte numérica
                    .Where(match => match.Success) // Filtra los casos donde hay un número
                    .Select(match => int.Parse(match.Value)) // Convierte la parte numérica a int
                    .ToList();
                
                int valorMaximo = numeros.Max() + 1;
                IdComponente = componentDescription.Substring(0, 3).ToUpper() + "_" + valorMaximo;
            }
            else
            {
                IdComponente = componentDescription.Substring(0, 3).ToUpper() + "_" + 1;
            }


            return new JsonResult(IdComponente);

        }
    }
}
