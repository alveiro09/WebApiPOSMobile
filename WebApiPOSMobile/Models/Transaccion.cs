using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiPOSMobile.Models
{
    public class Transaccion
    {
        public ObjectId Id { get; set; }

        [BsonElement("IdUsuario")]
        public string IdUsuario { get; set; }

        [BsonElement("IdTransaccion")]
        public string IdTransaccion { get; set; }

        [BsonElement("TipoTransaccion")]
        public EnumTipoTransaccion Nombre { get; set; }

        [BsonElement("Neto")]
        public double Neto { get; set; }

        [BsonElement("Bruto")]
        public double Bruto { get; set; }

        [BsonElement("Descuento")]
        public double Descuento { get; set; }

        [BsonElement("Fecha")]
        public string Fecha { get; set; }

        [BsonElement("Detalles")]
        public List<Producto> Detalles { get; set; }

    }
    public enum EnumTipoTransaccion
    {
        Compra,
        Venta
    }
}
