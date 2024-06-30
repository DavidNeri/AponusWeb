using Aponus_Web_API.Acceso_a_Datos.Stocks;
using Aponus_Web_API.Data_Transfer_objects;
using Aponus_Web_API.Support;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Aponus_Web_API.Acceso_a_Datos.Productos;
using System.Linq.Expressions;
using Aponus_Web_API.Models;
using Aponus_Web_API.Data_Transfer_Objects;
using System.Collections.Generic;
using System.Collections;

namespace Aponus_Web_API.Business
{
    public class BS_Stocks
    {
        internal  async Task<List<TipoInsumos>>Listar()
        {
            return   await new ObtenerStocks().Listar();
        }

        internal async Task<List<TipoInsumos>> Listar(int? idDescripcion, int? dn)
        {
            return await new ObtenerStocks().Listar(idDescripcion,dn);
        }

        internal async Task<List<TipoInsumos>> Listar(int? idDescripcion)
        {
            return await new ObtenerStocks().Listar(idDescripcion);
        }

        internal async Task<JsonResult> ListarDiametros(int? idDescripcion)
        {
            return await new ObtenerStocks().ListarDiametros(idDescripcion);
        }

        

        internal IActionResult ActualizarStock(ActualizacionStock Actualizacion)
        {
            try
            {
                switch (Actualizacion.IdTipoExistencia)
                {
                    case 0:
                        switch (Actualizacion.Operador)
                        {
                            case "+":
                                new ModificacionesStocks().ActualizarInsumo_Aumentar(Actualizacion);
                                break;                                
                            case "-":
                                new ModificacionesStocks().ActualizarInsumo_Descontar(Actualizacion);
                                break;
                            case "=":
                                new ModificacionesStocks().ActualizarInsumo_NuevoValor(Actualizacion);
                                break;
                           
                        }
                        break;

                    case 1:

                        switch (Actualizacion.Operador)
                        {
                            case "+":
                                new ModificacionesStocks().ActualizarProducto_Agregar(Actualizacion);
                                break;
                            case "-":
                                new ModificacionesStocks().ActualizarProducto_Descontar(Actualizacion);
                                break;
                            case "=":
                                new ModificacionesStocks().ActualizarProducto_NuevoValor(Actualizacion);
                                break;
                        }
                        break;

                    
                }
                return new JsonResult(new StatusCodeResult(200));

            }
            catch (Exception)
            {
                return new JsonResult(new StatusCodeResult(400));

            }
        }

       


        internal Task<List<Insumos>> ListarBulones()
        {
            return new Stocks().ListarBulones();
        }

        internal Task<List<Insumos>> LIstarPerfilesJuntas()
        {
            return new Stocks().ListarPerfilesJuntas();

        }

        internal IActionResult NewListar(int? IdDescripcion)
        {
            return new Stocks().Listar(IdDescripcion);
           
        }

        internal JsonResult ListarProductos(string? typeId, int? idDescription)
        {
            List<DTOTiposProductos> ListadoProductos = new Stocks().ListarProductos();


            if (typeId != null && idDescription != null)
            {
                List<DTOTiposProductos> Lista = ListadoProductos
                    .Where(x => x.IdTipo == typeId && x.DescripcionProductos
                    .Any(d => d.IdDescripcion == idDescription))
                    .ToList();

                Lista.ForEach(tpd => tpd.DescripcionProductos.ForEach(dpp =>
                {
                    dpp.Columnas = new ColumnasJson().ObtenerColumnas(dpp.Productos);
                }));
                

                return new JsonResult(Lista);
            }
            else if (typeId != null)
            {
                List<DTOTiposProductos> Lista = ListadoProductos
                    .Where(x => x.IdTipo == typeId)
                    .ToList();

                Lista.ForEach(tpd => tpd.DescripcionProductos.ForEach(dpp =>
                {
                    dpp.Columnas = new ColumnasJson().ObtenerColumnas(dpp.Productos);
                }));

                return new JsonResult(Lista);
            }
            else if (idDescription != null)
            {                

                List<DTOTiposProductos> Lista = ListadoProductos
                    .Where(x => x.DescripcionProductos
                    .Any(x => x.IdDescripcion == idDescription))
                    .ToList();

                Lista.ForEach(tpd => tpd.DescripcionProductos.ForEach(dpp =>
                {
                    dpp.Columnas = new ColumnasJson().ObtenerColumnas(dpp.Productos);
                }));
                return new JsonResult(Lista);
            }
            else
            {
                ListadoProductos.ForEach(tpd => tpd.DescripcionProductos.ForEach(dpp =>
                {
                    dpp.Columnas = new ColumnasJson().ObtenerColumnas(dpp.Productos);
                }));

                return new JsonResult(ListadoProductos);
            }
            
            

        }
    }
}
