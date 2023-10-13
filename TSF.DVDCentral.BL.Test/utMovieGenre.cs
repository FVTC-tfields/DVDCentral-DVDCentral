using TSF.DVDCentral.BL.Models;

namespace TSF.DVDCentral.BL.Test
{
    [TestClass]
    public class utMovieGenre
    {

        [TestMethod]
        public void InsertTest1()
        {
            int id = 0;
            int results = MovieGenreManager.Insert(0, ref id, 0, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void InsertTest2()
        {
            int id = 0;
            MovieGenre moviegenre = new MovieGenre
            {
                Description = "Test"
            };

            int results = MovieGenreManager.Insert(moviegenre, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void UpdateTest()
        {
            MovieGenre moviegenre = MovieGenreManager.LoadById(3);
            moviegenre.Description = "Test";
            int results = MovieGenreManager.Update(moviegenre, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void DeleteTest()
        {
            int results = MovieGenreManager.Delete(3, true);
            Assert.AreEqual(1, results);
        }
    }
}