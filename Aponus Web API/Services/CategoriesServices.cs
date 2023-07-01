using Aponus_Web_API.Acceso_a_Datos.Sistema;
using Aponus_Web_API.Data_Transfer_Objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Aponus_Web_API.Services
{
    public class CategoriesServices
    {
        

        internal IActionResult AgregarDescripcion(DTOCategorias NuevaCategoria)
        {
            NuevaCategoria.Descripcion = NuevaCategoria.Descripcion.ToUpper();
            try
            {
                Categorias categorias = new Categorias();

                //Inserta la Descripcion y obtiene el id
                NuevaCategoria.IdDescripcion= categorias.NuevaDescripcion(NuevaCategoria);


                categorias.VincularCatgorias(NuevaCategoria);
                return new StatusCodeResult(StatusCodes.Status200OK);

            }
            catch (DbUpdateException e )
            {

                string Mensaje = e.InnerException.Message;
                return new JsonResult(Mensaje);
            }
          

        }

        internal string? AgregarTipo(DTOCategorias NuevaCategoria)
        {
            try
            {
                NuevaCategoria.IdTipo = GenerarIdTipo(NuevaCategoria.DescripcionTipo);                
                NuevaCategoria.DescripcionTipo = NuevaCategoria.DescripcionTipo.ToUpper();

                new Categorias().NuevoTipo(NuevaCategoria);


                return NuevaCategoria.IdTipo;

            }
            catch 
            {                
                return null;

            }
            
        }
        internal List<DTODescripciones> ListarDescripciones(string IdTipo)
        {
            return new Categorias().ListarDescripciones(IdTipo);
        }

        private string GenerarIdTipo(string tipo)
        {
            try
            {
                string[] Preposiciones = new string[19] {"a", "ante", "bajo", "cabe", "con", "contra",
                "de", "desde", "en", "entre", "hasta", "hacia",
                "para", "por", "según", "sin", "so", "sobre",
                "tras"
            };

                string[] palabras = tipo.Split(' ');
                string NuevaCadena = "";

                foreach (string palabra in palabras)
                {
                    if (!Preposiciones.Contains(palabra.ToLower()))
                    {
                        NuevaCadena += palabra + " ";
                    }
                }

                NuevaCadena = NuevaCadena.TrimEnd();
                string[] IdTipoArray = NuevaCadena.Split(" ");
                string Id_Tipo = "";

                for (int i = 0; i < IdTipoArray.Length; i++)
                {
                    if ((i == IdTipoArray.Length - 1) && IdTipoArray[i].Length >= 3)
                    {
                        Id_Tipo = Id_Tipo + IdTipoArray[i].Substring(0, 3).ToUpper();
                    }
                    else if (IdTipoArray[i].Length >= 3)
                    {
                        Id_Tipo = Id_Tipo + IdTipoArray[i].Substring(0, 3).ToUpper() + "_";
                    }

                }

                Id_Tipo = Id_Tipo.ToUpper();

                return Id_Tipo;
            }
            catch (Exception)
            {

                return "";
            }
           

        }
    }
}
