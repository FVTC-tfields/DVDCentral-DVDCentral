using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TSF.DVDCentral.BL;

namespace TSF.DVDCentral.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<BL.Models.Genre> Get()
        {
            return GenreManager.Load();
        }

        [HttpGet("{id}")]
        public BL.Models.Genre Get(int id)
        {
            return GenreManager.LoadById(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] BL.Models.Genre genre)
        {
            try
            {
                int results = GenreManager.Insert(genre);
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
                int results = GenreManager.Update(genre);
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
