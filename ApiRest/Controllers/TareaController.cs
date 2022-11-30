using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ApiRest.Models;
using ApiRest.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiRest.Controllers
{
    [Route("[controller]")]
    public class TareaController : Controller
    {
        ITareasService _TareasService;
        private readonly ILogger<TareaController> _logger;

        public TareaController(ILogger<TareaController> logger, ITareasService tareasService)
        {
            _logger = logger;
            _TareasService = tareasService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_TareasService.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Tarea tarea)
        {
            _TareasService.Save(tarea);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Tarea tarea)
        {
            _TareasService.Update(id, tarea);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _TareasService.Delete(id);
            return Ok();
        }
    }
}