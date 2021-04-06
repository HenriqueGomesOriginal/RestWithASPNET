using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CpfValidator : ControllerBase
    {
        private readonly ILogger<CpfValidator> _logger;

        public CpfValidator(ILogger<CpfValidator> logger)
        {
            _logger = logger;
        }

        [HttpGet("{cpf}")]
        public IActionResult Get(string cpf)
        {
            return BadRequest("Invalid string");
        }
    }
}
