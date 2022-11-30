using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRest.Services;
using Microsoft.AspNetCore.Mvc;



namespace ApiRest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]


    public class HelloWorldController : ControllerBase
    {
        IHelloWorldService _ihelloWorldService;
        private readonly ILogger<HelloWorldService> _logger;

        public HelloWorldController(IHelloWorldService helloWorldService,ILogger<HelloWorldService> logger)
        {
            _ihelloWorldService = helloWorldService;
             _logger = logger;
        }

        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {
             _logger.LogCritical("Probando el critical en Helloworld");
            return Ok(_ihelloWorldService.GetHelloworld());
        }
    }
}