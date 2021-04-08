﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNET.Business;
using RestWithASPNET.Models;

namespace RestWithASPNET.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("v{version:apiVersion}/api/[controller]")]

    public class PersonController : ControllerBase
    {
        private IPersonBusiness _personRepository;

        private readonly ILogger<PersonController> _logger;
        public PersonController(ILogger<PersonController> logger, IPersonBusiness personRepository)
        {
            _logger = logger;
            _personRepository = personRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personRepository.FindAll());
        }

        [HttpGet ("{id}")]
        public IActionResult Get(string id)
        {
            var person = _personRepository.FindById(id);
            if (person != null)
                return Ok(person);
            else
                return BadRequest("Id not found");
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person != null)
                return Ok(_personRepository.Create(person));
            else
                return BadRequest("Nullable object");
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person != null)
                return Ok(_personRepository.Update(person));
            else
                return BadRequest("Nullable object");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var person = _personRepository.Delete(id);
            if (person != null)
                return NoContent();
            else
                return BadRequest("Id not found");
        }
    }
}
