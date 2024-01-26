

namespace TSF.DVDCentral.PL.Test
{
    [TestClass]
    public class utMovie : utBase
    {
        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(7, dc.tblMovies.Count());
        }

        [TestMethod]
        public void InsertTest()
        {

            // Make an entity
            tblMovie entity = new tblMovie();
            entity.Id = Guid.NewGuid();
            entity.Title = "New Title";
            entity.Description = "New Description";
            entity.FormatId = dc.tblFormats.FirstOrDefault().Id;
            entity.DirectorId = dc.tblDirectors.FirstOrDefault().Id;
            entity.RatingId =dc.tblRatings.FirstOrDefault().Id;
            entity.Cost = 6;
            entity.Quantity = 111;
            entity.ImagePath = "dtb";

            // Add the entity to the database
            dc.tblMovies.Add(entity);

            // Commit the changes
            int result = dc.SaveChanges();
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void UpdateTest()
        {
            // SELECT * FROM tblMovies - Use the first one.
            tblMovie entity = dc.tblMovies.FirstOrDefault();

            // Change property values
            entity.Title = "New Title";
            entity.Description = "New Description";
            entity.FormatId = dc.tblFormats.FirstOrDefault().Id;
            entity.DirectorId = dc.tblDirectors.FirstOrDefault().Id;
            entity.RatingId = dc.tblRatings.FirstOrDefault().Id;
            entity.Cost = 6;
            entity.Quantity = 111;
            entity.ImagePath = "dtb";

            int result = dc.SaveChanges();
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            // Select * from tblMovies where id = 3
            tblMovie entity = dc.tblMovies.OrderBy(e => e.Id).LastOrDefault();

            dc.tblMovies.Remove(entity);
            int result = dc.SaveChanges(true);

            Assert.AreNotEqual(result, 0);
        }
    }
}
