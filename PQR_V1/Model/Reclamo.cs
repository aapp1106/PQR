using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PQR_V1.Model
{
	public class Reclamo
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
		public string RadicadoId { get; set; }
		public string Mensaje { get; set; }
		public DateTime Fecha { get; set; } = DateTime.Now;
	}
}
