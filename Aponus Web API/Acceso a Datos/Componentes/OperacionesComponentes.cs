﻿using Aponus_Web_API.Data_Transfer_objects;
using Aponus_Web_API.Data_Transfer_Objects;
using Aponus_Web_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aponus_Web_API.Acceso_a_Datos.Componentes
{
    public class OperacionesComponentes
    {
        private readonly AponusContext AponusDbContex;

        public OperacionesComponentes(){ AponusDbContex = new AponusContext(); }

        internal void GuardarComponente(ComponentesDetalle componentesDetalle)
        {
            var Existe = AponusDbContex.ComponentesDetalles.FirstOrDefault(x => x.IdInsumo == componentesDetalle.IdInsumo);

            if (Existe==null)
            {
                AponusDbContex.ComponentesDetalles.Add(componentesDetalle);
            }
            else
            {
                AponusDbContex.Entry(Existe).CurrentValues.SetValues(componentesDetalle);
            }
          
            AponusDbContex.SaveChanges();
        }

        internal async Task<JsonResult> ListarNombres()
        {
            List<DTODescripcionComponentes> DescripcionesComponentes = await AponusDbContex.ComponentesDescripcions
                .Select(x=> new DTODescripcionComponentes()
                {
                    IdDescripcion= x.IdDescripcion,
                    Descripcion = x.Descripcion
                })
                .ToListAsync();

            return new JsonResult(DescripcionesComponentes) ;
        }

        internal Task<IActionResult> ListarProps()
        {
            throw new NotImplementedException();
        }

        internal async Task<IActionResult> ListarTiposAlacenamiento()
        {
            List <DTOComponente> Unidades= await  AponusDbContex.ComponentesDetalles
                .Select(x=>new DTOComponente()
                {
                    IdInsumo=x.IdInsumo,
                    idFraccionamiento=(x.IdFraccionamiento.ToLower()=="ud" || x.IdFraccionamiento.ToLower().Contains("unidad")) ? "Unidades" 
                                       : (x.IdFraccionamiento.ToLower() == "kg" || x.IdFraccionamiento.ToLower().Contains("kilo")) ? "Kgs"
                                       :  x.IdFraccionamiento,

                    idAlmacenamiento= (x.IdAlmacenamiento.ToLower() == "kg" || x.IdAlmacenamiento.ToLower().Contains("kilo")) ? "Kgs"
                                        : (x.IdAlmacenamiento.ToLower() == "ud" || x.IdAlmacenamiento.ToLower().Contains("unidad")) ? "Unidades" 
                                        : x.IdAlmacenamiento,


                }).ToListAsync();

            return new JsonResult(Unidades);
        }

        internal async Task<JsonResult> ObtenerNuevoId(string componentDescription)
        {
            string IdComponente="";
            List<string> IdComponenteList = await AponusDbContex.ComponentesDetalles
                .Where(x=>x.IdInsumo.Contains(componentDescription.Substring(0,3)))
                .Select(x=>x.IdInsumo.Substring(3)) 
                .ToListAsync();

            if (IdComponenteList.Count>0)
            {
                List<int> numeros = IdComponenteList.Select(int.Parse).ToList();
                int valorMaximo = numeros.Max() + 1;
                IdComponente = componentDescription.Substring(0, 3) + valorMaximo;
            }
            else
            {
                IdComponente = componentDescription.Substring(0, 3) + 1;
            }

           
            return new JsonResult(IdComponente);

        }
    }
}