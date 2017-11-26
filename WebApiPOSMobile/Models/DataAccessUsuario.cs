using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Collections.Generic;

namespace WebApiPOSMobile.Models
    {
        public class DataAccessUsuario
        {
            MongoClient _client;
            MongoServer _server;
            MongoDatabase _db;

            public DataAccessUsuario()
            {
                _client = new MongoClient("mongodb://localhost:27017");
                _server = _client.GetServer();
                _db = _server.GetDatabase("POSDB");
            }

            public IEnumerable<Usuario> GetUsuarios()
            {
                return _db.GetCollection<Usuario>("Usuarios").FindAll();
            }


            public Usuario GetUsuario(ObjectId id)
            {
                var res = Query<Usuario>.EQ(p => p.Id, id);
                return _db.GetCollection<Usuario>("Usuarios").FindOne(res);
            }

            public Usuario Create(Usuario p)
            {
                _db.GetCollection<Usuario>("Usuarios").Save(p);
                return p;
            }

            public void Update(ObjectId id, Usuario p)
            {
                p.Id = id;
                var res = Query<Usuario>.EQ(pd => pd.Id, id);
                var operation = Update<Usuario>.Replace(p);
                _db.GetCollection<Usuario>("Usuarios").Update(res, operation);
            }
            public void Remove(ObjectId id)
            {
                var res = Query<Usuario>.EQ(e => e.Id, id);
                var operation = _db.GetCollection<Usuario>("Usuarios").Remove(res);
            }
        }
    }
