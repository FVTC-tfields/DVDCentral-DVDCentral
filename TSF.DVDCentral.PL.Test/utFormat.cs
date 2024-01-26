

namespace TSF.DVDCentral.PL.Test
{
    [TestClass]
    public class utFormat : utBase
    {
        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(4, dc.tblFormats.Count());
        }

        [TestMethod]
        public void InsertTest()
        {

            // Make an entity
            tblFormat entity = new tblFormat();
            entity.Id = Guid.NewGuid();
            entity.Description = "Taco";

            // Add the entity to the database
            dc.tblFormats.Add(entity);

            // Commit the changes
            int result = dc.SaveChanges();
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void UpdateTest()
        {
            // SELECT * FROM tblFormats - Use the first one.
            tblFormat entity = dc.tblFormats.FirstOrDefault();

            // Change property values
            entity.Description = "New Description";

            int result = dc.SaveChanges();
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            // Select * from tblFormats where id = 345
            tblFormat entity = dc.tblFormats.OrderBy(e => e.Id).LastOrDefault();

            dc.tblFormats.Remove(entity);
            int result = dc.SaveChanges(true);

            Assert.AreNotEqual(result, 0);
        }
    }
}
