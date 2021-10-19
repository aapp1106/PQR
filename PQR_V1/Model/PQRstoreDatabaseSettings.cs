using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PQR_V1.Model
{
	public class PQRstoreDatabaseSettings : IPQRstoreDatabaseSettings
	{
		public string PqrCollectionName { get; set; }
		public string ReclamosPQRCollectionName { get; set; }
		public string ConnectionString { get; set; }
		public string DatabaseName { get; set; }
	}
	public interface IPQRstoreDatabaseSettings
	{
		string PqrCollectionName { get; set; }
		public string ReclamosPQRCollectionName { get; set; }
		string ConnectionString { get; set; }
		string DatabaseName { get; set; }
	}
}
