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
    public class CategoriaController : ControllerBase
    {
        ICategoriaService _CategoriaServices;
        private readonly ILogger<CategoriaController> _logger;

        public CategoriaController(ILogger<CategoriaController> logger, ICategoriaService categoriaServices)
        {
            _logger = logger;
            _CategoriaServices = categoriaServices;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_CategoriaServices.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Categoria categoria)
        {
            _CategoriaServices.Save(categoria);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id,[FromBody] Categoria categoria)
        {
            _CategoriaServices.Update(id, categoria);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _CategoriaServices.Delete(id);
            return Ok();
        }

    }
}