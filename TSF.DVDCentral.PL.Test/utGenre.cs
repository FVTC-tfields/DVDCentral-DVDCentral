

namespace TSF.DVDCentral.PL.Test
{
    [TestClass]
    public class utGenre : utBase
    {
        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(10, dc.tblGenres.Count());
        }

        [TestMethod]
        public void InsertTest()
        {

            // Make an entity
            tblGenre entity = new tblGenre();
            entity.Id = Guid.NewGuid();
            entity.Description = "Taco";

            // Add the entity to the database
            dc.tblGenres.Add(entity);

            // Commit the changes
            int result = dc.SaveChanges();
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void UpdateTest()
        {
            // SELECT * FROM tblGenres - Use the first one.
            tblGenre entity = dc.tblGenres.FirstOrDefault();

            // Change property values
            entity.Description = "New Description";

            int result = dc.SaveChanges();
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            // Select * from tblGenres where id = 3
            tblGenre entity = dc.tblGenres.OrderBy(e => e.Id).LastOrDefault();

            dc.tblGenres.Remove(entity);
            int result = dc.SaveChanges(true);

            Assert.AreNotEqual(result, 0);
        }
    }
}
