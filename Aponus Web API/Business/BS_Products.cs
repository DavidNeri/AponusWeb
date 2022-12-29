using Aponus_Web_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using Microsoft.Build.Framework;
using Aponus_Web_API.Mapping;
using Aponus_Web_API.Services;

namespace Aponus_Web_API.Business
{
    public class BS_Products 
    {
        public JsonResult ListarInsumos(string? ProductId)
        {
            
            try
            {
                List<InsumosPesables> InusmoPesables = new ObtenerInsumos().ObtenterPesables(ProductId);
                InsumosProducto _InsumosProducto = new InsumosProducto()
                {
                    Pesables = InusmoPesables
                };

                return new JsonResult(_InsumosProducto);
            }
            catch (Exception e)
            {

                return new JsonResult(e);
            }


        }

        internal JsonResult ListarProductos(string? TypeId) {

            return new ObtenerProductos().Listar(TypeId);

        }

        internal JsonResult ListarProductos()
        {
            return new ObtenerProductos().Listar();
        }

    }   
}
