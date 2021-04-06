using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNET.Models;
using RestWithASPNET.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("v{version:apiVersion}/api/[controller]")]

    public class PersonController : ControllerBase
    {
        private IPersonService _personService;

        private readonly ILogger<PersonController> _logger;
        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }

        [HttpGet ("{id}")]
        public IActionResult Get(string id)
        {
            var person = _personService.FindById(id);
            if (person != null)
                return Ok(person);
            else
                return BadRequest("Id not found");
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person != null)
                return Ok(_personService.Create(person));
            else
                return BadRequest("Nullable object");
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person != null)
                return Ok(_personService.Update(person));
            else
                return BadRequest("Nullable object");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var person = _personService.Delete(id);
            if (person != null)
                return NoContent();
            else
                return BadRequest("Id not found");
        }
    }
}
