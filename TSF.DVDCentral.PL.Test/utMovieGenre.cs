

namespace TSF.DVDCentral.PL.Test
{
    [TestClass]
    public class utMovieGenre : utBase
    {
        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(13, dc.tblMovieGenres.Count());
        }

        [TestMethod]
        public void InsertTest()
        {

            // Make an entity
            tblMovieGenre entity = new tblMovieGenre();
            entity.Id = Guid.NewGuid();
            entity.MovieId = dc.tblMovies.FirstOrDefault().Id;
            entity.GenreId = dc.tblGenres.FirstOrDefault().Id;

            // Add the entity to the database
            dc.tblMovieGenres.Add(entity);

            // Commit the changes
            int result = dc.SaveChanges();
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void UpdateTest()
        {
            // SELECT * FROM tblMovieGenres - Use the first one.
            tblMovieGenre entity = dc.tblMovieGenres.FirstOrDefault();

            // Change property values
            entity.MovieId = dc.tblMovies.FirstOrDefault().Id;
            entity.GenreId = dc.tblGenres.FirstOrDefault().Id;

            int result = dc.SaveChanges();
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            // Select * from tblMovieGenres where id = 3
            tblMovieGenre entity = dc.tblMovieGenres.OrderBy(e => e.Id).LastOrDefault();

            dc.tblMovieGenres.Remove(entity);
            int result = dc.SaveChanges(true);

            Assert.AreNotEqual(result, 0);
        }
    }
}
