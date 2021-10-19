using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PQR_V1.Model
{
	public class PQR
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string RadicadoId { get; set; }
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public string Cedula { get; set; }
		public string Mensaje { get; set; }
		public DateTime Fecha { get; set; } = DateTime.Now;
		public bool Estado { get; set; } = false;
		public string Tipo { get; set; }
		public string Respuesta { get; set; }

		public List<PQR> Inicializador()
		{
			List<PQR> Pqr = new List<PQR>(){
				new PQR() { Nombre = "Alberto", Apellido = "Perez", Cedula = "10656458", Estado = false, Mensaje = "Mensaje de prueba", Tipo = "Peticion" } ,
				new PQR() { Nombre = "Sandy", Apellido = "Ortega", Cedula = "4353546", Estado = false, Mensaje = "Otro mensaje de prueba", Tipo = "Queja" }
			};
			return Pqr;
		}
	}

	
}
