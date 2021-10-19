using Microsoft.AspNetCore.Mvc;
using PQR_V1.Model;
using PQR_V1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PQR_V1.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PQRController : Controller
	{
		private readonly PQRService _pqrService;
		private PQR Pqr = new PQR();

		public PQRController(PQRService pqrService)
		{
			_pqrService = pqrService;
			foreach (var item in Pqr.Inicializador())
			{
				_pqrService.Create(item);
			}
		}

		[HttpGet]
		public ActionResult<List<PQR>> Get() =>
		_pqrService.Get();

		[HttpGet("{id:length(24)}", Name = "GetBook")]
		public ActionResult<PQR> Get(string id)
		{
			var pqr = _pqrService.Get(id);
			if (pqr == null)
			{
				return NotFound();
			}
			return pqr;
		}

		[HttpPost]
		public ActionResult<PQR> Create(PQR pqr)
		{
			_pqrService.Create(pqr);
			return CreatedAtRoute("GetPQR", new { id = pqr.RadicadoId.ToString() }, pqr);
		}

		[HttpPut("{id:length(24)}")]
		public IActionResult Update(string id, PQR pqrIn)
		{
			var pqr = _pqrService.Get(id);
			if (pqr == null)
			{
				return NotFound();
			}
			_pqrService.Update(id, pqrIn);
			return NoContent();
		}

		[HttpDelete("{id:length(24)}")]
		public IActionResult Delete(string id)
		{
			var pqr = _pqrService.Get(id);
			if (pqr == null)
			{
				return NotFound();
			}
			_pqrService.Remove(pqr.RadicadoId);
			return NoContent();
		}
	}
}
