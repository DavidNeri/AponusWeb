﻿using Newtonsoft.Json;

namespace Aponus_Web_API.Objetos_de_Transferencia_de_Datos
{
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

        [JsonProperty(Order = 19, PropertyName = "tipo", NullValueHandling = NullValueHandling.Ignore)]
        public DTOEntidadesTipos Tipo { get; set; } = new();

        [JsonProperty(Order = 19, PropertyName = "categoria", NullValueHandling = NullValueHandling.Ignore)]
        public DTOEntidadesCategorias Categoria { get; set; } = new();
    }
}
