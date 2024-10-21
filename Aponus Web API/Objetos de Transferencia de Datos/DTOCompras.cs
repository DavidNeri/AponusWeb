using Aponus_Web_API.Modelos;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Objetos_de_Transferencia_de_Datos
{
    public class DTOCompras
    {
        [JsonProperty(PropertyName = "IdCompra", NullValueHandling = NullValueHandling.Ignore)]
        public int IdCompra { get; set; }

        [JsonProperty(PropertyName = "IdProveedor", NullValueHandling = NullValueHandling.Ignore)]
        public int IdProveedor { get; set; }

        [JsonProperty(PropertyName = "FechaHora", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime FechaHora { get; set; }

        [JsonProperty(PropertyName = "IdUsuario", NullValueHandling = NullValueHandling.Ignore)]
        public string IdUsuario { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "IdEstadoCompra", NullValueHandling = NullValueHandling.Ignore)]
        public int IdEstadoCompra { get; set; }

        [JsonProperty(PropertyName = "SaldoTotal", NullValueHandling = NullValueHandling.Ignore)]
        public decimal SaldoTotal { get; set; }

        [JsonProperty(PropertyName = "SaldoCancelado", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? SaldoCancelado { get; set; }

        [JsonProperty(PropertyName = "SaldoPendiente", NullValueHandling = NullValueHandling.Ignore)]
        public decimal SaldoPendiente => SaldoTotal - (SaldoCancelado ?? 0);
        
        [JsonProperty(PropertyName = "Usuario", NullValueHandling = NullValueHandling.Ignore)]
        public virtual Usuarios Usuario { get; set; } = new(); 

        [JsonProperty(PropertyName = "Estado", NullValueHandling = NullValueHandling.Ignore)]
        public virtual EstadosCompras Estado { get; set; } = new(); 

        [JsonProperty(PropertyName = "Proveedor", NullValueHandling = NullValueHandling.Ignore)]
        public virtual Entidades Proveedor { get; set; } = new(); 

        [JsonProperty(PropertyName = "DetallesCompra", NullValueHandling = NullValueHandling.Ignore)]
        public virtual ICollection<ComprasDetalles> DetallesCompra { get; set; } = new HashSet<ComprasDetalles>(); 

        [JsonProperty(PropertyName = "Pagos", NullValueHandling = NullValueHandling.Ignore)]
        public virtual ICollection<PagosCompras> Pagos { get; set; } = new HashSet<PagosCompras>(); 
        


    }
}
