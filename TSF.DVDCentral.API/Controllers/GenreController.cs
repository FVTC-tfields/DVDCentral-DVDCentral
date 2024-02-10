using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TSF.DVDCentral.BL;
using TSF.DVDCentral.BL.Models;
using TSF.DVDCentral.PL;

namespace TSF.DVDCentral.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly DbContextOptions<DVDCentralEntities> options;
        private readonly ILogger<GenreController> logger;

        public GenreController(ILogger<GenreController> logger,
                               DbContextOptions<DVDCentralEntities> options)
        {
            this.options = options;
            this.logger = logger;
        }


        [HttpGet]
        public IEnumerable<Genre> Get()
        {
            return new GenreManager(options).Load();
        }

        [HttpGet("{id}")]
        public BL.Models.Genre Get(Guid id)
        {
            return new GenreManager(options).LoadById(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Genre genre)
        {
            try
            {
                int results = new GenreManager(options).Insert(genre);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BL.Models.Genre genre)
        {
            try
            {
                int results = new GenreManager(options).Update(genre);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                int results = GenreManager.Delete(id);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
