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
	public class ReclamoController : Controller
	{
		private readonly ReclamoService _reclamoService;

		public ReclamoController(ReclamoService reclamoService)
		{
			_reclamoService = reclamoService;
		}

		[HttpGet]
		public ActionResult<List<Reclamo>> Get() =>
		_reclamoService.Get();

		[HttpGet("{id:length(24)}", Name = "GetReclamo")]
		public ActionResult<Reclamo> Get(string id)
		{
			var pqr = _reclamoService.Get(id);
			if (pqr == null)
			{
				return NotFound();
			}
			return pqr;
		}

		[HttpPost]
		public ActionResult<Reclamo> Create(Reclamo reclamo)
		{
			_reclamoService.Create(reclamo);
			return CreatedAtRoute("GetReclamo", new { id = reclamo.Id.ToString() }, reclamo);
		}

		[HttpPut("{id:length(24)}")]
		public IActionResult Update(string id, Reclamo reclamoIn)
		{
			var reclamo = _reclamoService.Get(id);
			if (reclamo == null)
			{
				return NotFound();
			}
			_reclamoService.Update(id, reclamoIn);
			return NoContent();
		}

		[HttpDelete("{id:length(24)}")]
		public IActionResult Delete(string id)
		{
			var pqr = _reclamoService.Get(id);
			if (pqr == null)
			{
				return NotFound();
			}
			_reclamoService.Remove(pqr.RadicadoId);
			return NoContent();
		}
	}
}
