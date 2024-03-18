using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TSF.DVDCentral.BL;
using TSF.DVDCentral.BL.Models;
using TSF.DVDCentral.PL2.Data;

namespace TSF.DVDCentral.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly ILogger<MovieController> logger;
        private readonly DbContextOptions<DVDCentralEntities> options;

        public MovieController(ILogger<MovieController> logger,
                                DbContextOptions<DVDCentralEntities> options)
        {
            this.options = options;
            this.logger = logger;
            logger.LogWarning("I was here");
        }

        /// <summary>
        /// Returns a list of movies.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return new MovieManager(options).Load();
        }

        /// <summary>
        /// Get a particular by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Movie Get(Guid id)
        {
            return new MovieManager(options).LoadById(id);
        }

        /// <summary>
        /// Insert a movie
        /// </summary>
        /// <param name="movie"></param>
        /// <param name="rollback"></param>
        /// <returns>New Guid</returns>
        [HttpPost("{rollback?}")]
        public int Post([FromBody] Movie movie, bool rollback = false)
        {
            try
            {
                return new MovieManager(options).Insert(movie, rollback);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Update a movie
        /// </summary>
        /// <param name="id"></param>
        /// <param name="movie"></param>
        /// <param name="rollback"></param>
        /// <returns></returns>
        [HttpPut("{id}/{rollback?}")]
        public int Put(Guid id, [FromBody] Movie movie, bool rollback = false)
        {
            try
            {
                return new MovieManager(options).Update(movie, rollback);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Delete a movie
        /// </summary>
        /// <param name="id">Movie Id</param>
        /// <param name="rollback">Should be rollback the transaction</param>
        /// <returns></returns>
        [HttpDelete("{id}/{rollback?}")]
        public int Delete(Guid id, bool rollback = false)
        {
            try
            {
                return new MovieManager(options).Delete(id, rollback);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
