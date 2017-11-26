using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Collections.Generic;

namespace WebApiPOSMobile.Models
    {
        public class DataAccessTransaccion
        {
            MongoClient _client;
            MongoServer _server;
            MongoDatabase _db;

            public DataAccessTransaccion()
            {
                _client = new MongoClient("mongodb://localhost:27017");
                _server = _client.GetServer();
                _db = _server.GetDatabase("POSDB");
            }

            public IEnumerable<Transaccion> GetTransaccions()
            {
                return _db.GetCollection<Transaccion>("Transaccion").FindAll();
            }


            public Transaccion GetTransaccion(ObjectId id)
            {
                var res = Query<Transaccion>.EQ(p => p.Id, id);
                return _db.GetCollection<Transaccion>("Transaccion").FindOne(res);
            }

            public Transaccion Create(Transaccion p)
            {
                _db.GetCollection<Transaccion>("Transaccion").Save(p);
                return p;
            }

            public void Update(ObjectId id, Transaccion p)
            {
                p.Id = id;
                var res = Query<Transaccion>.EQ(pd => pd.Id, id);
                var operation = Update<Transaccion>.Replace(p);
                _db.GetCollection<Transaccion>("Transaccion").Update(res, operation);
            }
            public void Remove(ObjectId id)
            {
                var res = Query<Transaccion>.EQ(e => e.Id, id);
                var operation = _db.GetCollection<Transaccion>("Transaccion").Remove(res);
            }
        }
    }
