using MongoDB.Driver;
using PQR_V1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PQR_V1.Services
{
	public class ReclamoService
	{
            private readonly IMongoCollection<Reclamo> _reclamo;

            public ReclamoService(IPQRstoreDatabaseSettings settings)
            {
                  var client = new MongoClient(settings.ConnectionString);
                  var database = client.GetDatabase(settings.DatabaseName);

                  _reclamo = database.GetCollection<Reclamo>(settings.ReclamosPQRCollectionName);
            }

            public List<Reclamo> Get() =>
                _reclamo.Find(book => true).ToList();

            public Reclamo Get(string id) =>
                _reclamo.Find<Reclamo>(pqr => pqr.Id == id).FirstOrDefault();

            public Reclamo GetRadicado(string Rad) =>
                _reclamo.Find<Reclamo>(pqr => pqr.RadicadoId == Rad).FirstOrDefault();

            public Reclamo Create(Reclamo reclamo)
            {
                  _reclamo.InsertOne(reclamo);
                  return reclamo;
            }

            public void Update(string id, Reclamo reclamoIn) =>
                _reclamo.ReplaceOne(pqr => pqr.RadicadoId == id, reclamoIn);

            public void Remove(PQR pqrIn) =>
                _reclamo.DeleteOne(pqr => pqr.RadicadoId == pqrIn.RadicadoId);

            public void Remove(string id) =>
                _reclamo.DeleteOne(pqr => pqr.RadicadoId == id);
      }
}
