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
            return new Stocks().ListarInsumosProducto(IdDescripcion);
           
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
