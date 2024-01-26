

namespace TSF.DVDCentral.PL.Test
{
    [TestClass]
    public class utRating : utBase
    {
        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(5, dc.tblRatings.Count());
        }

        [TestMethod]
        public void InsertTest()
        {

            // Make an entity
            tblRating entity = new tblRating();
            entity.Id = Guid.NewGuid();
            entity.Description = "Taco";

            // Add the entity to the database
            dc.tblRatings.Add(entity);

            // Commit the changes
            int result = dc.SaveChanges();
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void UpdateTest()
        {
            // SELECT * FROM tblRatings - Use the first one.
            tblRating entity = dc.tblRatings.FirstOrDefault();

            // Change property values
            entity.Description = "New Description";

            int result = dc.SaveChanges();
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            // Select * from tblRatings where id = 3
            tblRating entity = dc.tblRatings.OrderBy(e => e.Id).LastOrDefault();

            dc.tblRatings.Remove(entity);
            int result = dc.SaveChanges(true);

            Assert.AreNotEqual(result, 0);
        }
    }
}
