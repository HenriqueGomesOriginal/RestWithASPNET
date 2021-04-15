using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNET.Business;
using RestWithASPNET.Data.VO;
using RestWithASPNET.Hypermedia.Filters;

namespace RestWithASPNET.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Authorize("Bearer")]
    [Route("api/[controller]/v{version:apiVersion}")]

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
        [ProducesResponseType((200), Type = typeof(List<BooksVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_booksRepository.FindAll());
        }

        [HttpGet("FindWithPagedSearch/{sortDirection}/{pageSize}/{page}")]
        [ProducesResponseType((200), Type = typeof(List<BooksVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get([FromQuery] string title,
            string sortDirection,
            int pageSize,
            int page)
        {
            return Ok(_booksRepository.FindWithPagedSearch(title, sortDirection, pageSize, page));
        }


        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(BooksVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(string id)
        {
            var person = _booksRepository.FindById(id);
            if (person != null)
                return Ok(person);
            else
                return BadRequest("Id not found");
        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(BooksVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] BooksVO books)
        {
            if (books != null)
                return Ok(_booksRepository.Create(books));
            else
                return BadRequest("Nullable object");
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(BooksVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] BooksVO books)
        {
            if (books != null)
                return Ok(_booksRepository.Update(books));
            else
                return BadRequest("Nullable object");
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
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
