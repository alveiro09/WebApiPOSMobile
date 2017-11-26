using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiPOSMobile.Models
{
    public class Usuario
    {
        public ObjectId Id { get; set; }

        [BsonElement("NumeroDocumento")]
        public string NumeroDocumento { get; set; }

        [BsonElement("PrimerNombre")]
        public string PrimerNombre { get; set; }

        [BsonElement("SegundoNombre")]
        public string SegundoNombre { get; set; }

        [BsonElement("PrimerApellido")]
        public string PrimerApellido { get; set; }

        [BsonElement("SegundoApellido")]
        public string SegundoApellido { get; set; }

        [BsonElement("Contrasena")]
        public string Contrasena { get; set; }

        [BsonElement("NombreUsuario")]
        public string NombreUsuario { get; set; }
    }
}
