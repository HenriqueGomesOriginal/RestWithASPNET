using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNET.Business;
using RestWithASPNET.Business.Implementation;
using RestWithASPNET.Models;

namespace RestWithASPNET.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("v{version:apiVersion}/api/[controller]")]

    public class BooksController : ControllerBase
    {
        private IBooksBusiness _booksRepository;

        private readonly ILogger<BooksController> _logger;
        public BooksController(ILogger<BooksController> logger, IBooksBusiness booksRepository)
        {
            _logger = logger;
            _booksRepository = booksRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_booksRepository.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var person = _booksRepository.FindById(id);
            if (person != null)
                return Ok(person);
            else
                return BadRequest("Id not found");
        }

        [HttpPost]
        public IActionResult Post([FromBody] Books books)
        {
            if (books != null)
                return Ok(_booksRepository.Create(books));
            else
                return BadRequest("Nullable object");
        }

        [HttpPut]
        public IActionResult Put([FromBody] Books books)
        {
            if (books != null)
                return Ok(_booksRepository.Update(books));
            else
                return BadRequest("Nullable object");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var person = _booksRepository.Delete(id);
            if (person != null)
                return NoContent();
            else
                return BadRequest("Id not found");
        }
    }
}
