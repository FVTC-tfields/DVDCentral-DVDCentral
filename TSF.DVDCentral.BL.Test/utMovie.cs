using System.Xml.Linq;
using TSF.DVDCentral.BL.Models;

namespace TSF.DVDCentral.BL.Test
{
    [TestClass]
    public class utMovie
    {
        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(3, MovieManager.Load().Count);
        }

        [TestMethod]
        public void InsertTest1()
        {
            int id = 0;
            int results = MovieManager.Insert("Test", "Test", ref id, 0, 0, 0, 0, 0, "Test",  true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void InsertTest2()
        {
            int id = 0;
            Movie movie = new Movie
            {
                Title = "Test",
                Description = "Test",
                FormatId = 144,
                DirectorId = 133,
                RatingId = 122,
                Cost = 1,
                InStkQty = 111,
                ImagePath = "Test"
            };

            int results = MovieManager.Insert(movie, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Movie movie = MovieManager.LoadById(3);
            movie.Title = "Test";
            movie.Description = "Test";
            movie.FormatId = 144;
            movie.DirectorId = 133;
            movie.RatingId = 122;
            movie.Cost = 1;
            movie.InStkQty = 111;
            movie.ImagePath = "Test";
            int results = MovieManager.Update(movie, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void DeleteTest()
        {
            int results = MovieManager.Delete(3, true);
            Assert.AreEqual(1, results);
        }
    }
}