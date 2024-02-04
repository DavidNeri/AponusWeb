using Aponus_Web_API.Data_Transfer_objects;
using Aponus_Web_API.Data_Transfer_Objects;
using Microsoft.CodeAnalysis.CSharp.Syntax;
//using System.Text.Json;
//using System.Text.Json.Serialization;
using Newtonsoft.Json;



namespace Aponus_Web_API.Services
{
    public class miDTOComponenteFormateadoConverter : JsonConverter<DTOComponenteFormateado>
    {
        public override DTOComponenteFormateado? ReadJson(JsonReader reader, Type objectType, DTOComponenteFormateado existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return existingValue;
        }

        public override void WriteJson(JsonWriter writer, DTOComponenteFormateado value, JsonSerializer options)
        {
            writer.WriteStartObject();

            // Aquí puedes agregar el resto de las propiedades según el orden deseado


             if (value.IdDescripcion != null)WriteProperty(writer,"IdDescripcion", value.IdDescripcion.Value);


             if (value.idComponente != null)WriteProperty(writer,"idComponente", value.idComponente);
             if (value.Largo != null)WriteProperty(writer,"largo", value.Largo);
             if (value.Ancho != null)WriteProperty(writer,"ancho", value.Ancho);
             if (value.Longitud!= null)WriteProperty(writer,"longitud ", value.Longitud);
             if (value.Espesor != null)WriteProperty(writer,"espesor", value.Espesor);
             if (value.Altura != null)WriteProperty(writer,"altura", value.Altura);
             if (value.Diametro != null)WriteProperty(writer,"diametro", value.Diametro);
             if (value.DiametroNominal != null)WriteProperty(writer,"diametroNominal", value.DiametroNominal.Value);
             if (value.Tolerancia != null)WriteProperty(writer,"tolerancia", value.Tolerancia);
             if (value.Peso != null)WriteProperty(writer,"peso", value.Peso);
             if (value.Perfil!= null) WriteProperty(writer,"perfil", value.Perfil.Value);
             if (value.idFraccionamiento!= null) WriteProperty(writer,"idFraccionamiento", value.idFraccionamiento);
             if (value.idAlmacenamiento!= null) WriteProperty(writer,"idAlmacenamiento", value.idAlmacenamiento);
             if (value.IdInsumo!= null) WriteProperty(writer,"idInsumo", value.IdInsumo);
             if (value.NombreInsumo!= null) WriteProperty(writer,"nombreInsumo", value.NombreInsumo);
             if (value.Recibido!= null) WriteProperty(writer,"recibido", value.Recibido);
             if (value.Granallado != null) WriteProperty(writer,"granallado", value.Granallado);
             if (value.Pintura != null) WriteProperty(writer,"pintura", value.Pintura);
             if (value.Proceso != null) WriteProperty(writer,"proceso", value.Proceso);
             if (value.Moldeado != null) WriteProperty(writer,"moldeado", value.Moldeado);
             if (value.Requerido != null) WriteProperty(writer,"requerido", value.Requerido);
             if (value.Disponibles != null) WriteProperty(writer,"disponibles", value.Disponibles);
             if (value.Faltantes != null) WriteProperty(writer,"faltantes", value.Faltantes);
             if (value.Total != null) WriteProperty(writer,"total", value.Total);

            writer.WriteEndObject();
        }

        private static void WriteProperty(JsonWriter writer, string Propertyname, object value)
        {
            writer.WritePropertyName(Propertyname);
            writer.WriteValue(value);

        }

       
    }
}
