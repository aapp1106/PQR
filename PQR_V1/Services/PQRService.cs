using MongoDB.Driver;
using PQR_V1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PQR_V1.Services
{
	public class PQRService
	{
            private readonly IMongoCollection<PQR> _pqr;

            public PQRService(IPQRstoreDatabaseSettings settings)
            {
                  var client = new MongoClient(settings.ConnectionString);
                  var database = client.GetDatabase(settings.DatabaseName);

                  _pqr = database.GetCollection<PQR>(settings.PqrCollectionName);
            }

            public List<PQR> Get() =>
                _pqr.Find(book => true).ToList();

            public PQR Get(string id) =>
                _pqr.Find<PQR>(pqr => pqr.RadicadoId == id).FirstOrDefault();

            public PQR GetCedula(string ced) =>
                _pqr.Find<PQR>(pqr => pqr.Cedula == ced).FirstOrDefault();

            public PQR Create(PQR pqr)
            {
                  if (GetCedula(pqr.Cedula) == null  )
                        _pqr.InsertOne(pqr);
                  return pqr;
            }

            public void Update(string id, PQR pqrIn) =>
                _pqr.ReplaceOne(pqr => pqr.RadicadoId == id, pqrIn);

            public void Remove(PQR pqrIn) =>
                _pqr.DeleteOne(pqr => pqr.RadicadoId == pqrIn.RadicadoId);

            public void Remove(string id) =>
                _pqr.DeleteOne(pqr => pqr.RadicadoId == id);
      }
}
