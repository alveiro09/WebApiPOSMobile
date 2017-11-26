using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Collections.Generic;

namespace WebApiPOSMobile.Models
    {
        public class DataAccessProducto
        {
            MongoClient _client;
            MongoServer _server;
            MongoDatabase _db;

            public DataAccessProducto()
            {
                _client = new MongoClient("mongodb://localhost:27017");
                _server = _client.GetServer();
                _db = _server.GetDatabase("POSDB");
            }

            public IEnumerable<Producto> GetProductos()
            {
                return _db.GetCollection<Producto>("Producto").FindAll();
            }


            public Producto GetProducto(ObjectId id)
            {
                var res = Query<Producto>.EQ(p => p.Id, id);
                return _db.GetCollection<Producto>("Producto").FindOne(res);
            }

            public Producto Create(Producto p)
            {
                _db.GetCollection<Producto>("Producto").Save(p);
                return p;
            }

            public void Update(ObjectId id, Producto p)
            {
                p.Id = id;
                var res = Query<Producto>.EQ(pd => pd.Id, id);
                var operation = Update<Producto>.Replace(p);
                _db.GetCollection<Producto>("Producto").Update(res, operation);
            }
            public void Remove(ObjectId id)
            {
                var res = Query<Producto>.EQ(e => e.Id, id);
                var operation = _db.GetCollection<Producto>("Producto").Remove(res);
            }
        }
    }
