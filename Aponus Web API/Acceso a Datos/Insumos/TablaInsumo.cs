using Aponus_Web_API.Data_Transfer_objects;
using Aponus_Web_API.Models;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;

namespace Aponus_Web_API.Acceso_a_Datos.Insumos
{
    public class TablaInsumo
    {
        private readonly AponusContext AponusDBContext;
        public TablaInsumo() { AponusDBContext = new AponusContext(); }


        public int? ObtenerTabla(Data_Transfer_objects.Insumos Insumo)
        {
            int? IdTabla = null;
            string? _Componente;

            _Componente = AponusDBContext.StockPesables
                .Where(x=>x.IdComponente==Insumo.Nombre)
                .Select(x=>x.IdComponente)
                .FirstOrDefault();

            if (_Componente != null)
            {
                IdTabla = 0;

            }else
            {
                 _Componente = AponusDBContext.StockCuantitativos
                .Where(x => x.IdComponente == Insumo.Nombre)
                .Select(x => x.IdComponente)
                .FirstOrDefault();

                if (_Componente != null) { IdTabla= 1; }
            }
            if (_Componente == null)
            {
                _Componente = AponusDBContext.StockMensurables
               .Where(x => x.IdComponente == Insumo.Nombre)
               .Select(x => x.IdComponente)
               .FirstOrDefault();

                if (_Componente != null) { IdTabla= 2; }
            }



            
            return IdTabla;

        }
    }

}
