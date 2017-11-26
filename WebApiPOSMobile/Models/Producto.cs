using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiPOSMobile.Models
{
    public class Producto
    {
        public ObjectId Id { get; set; }

        [BsonElement("IdProductoo")]
        public string IdProductoo { get; set; }

        [BsonElement("Nombre")]
        public string Nombre { get; set; }

        [BsonElement("Descripcion")]
        public string Descripcion { get; set; }

        [BsonElement("CantidadDisponible")]
        public double CantidadDisponible { get; set; }

        [BsonElement("Precio")]
        public double Precio { get; set; }
    }
}
