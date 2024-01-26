

namespace TSF.DVDCentral.PL.Test
{
    [TestClass]
    public class utDirector : utBase
    {
        

        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(6, dc.tblDirectors.Count());
        }

        [TestMethod]
        public void InsertTest()
        {

            // Make an entity
            tblDirector entity = new tblDirector();
            entity.Id = Guid.NewGuid();
            entity.FirstName = "Taco";
            entity.LastName = "Bell";

            // Add the entity to the database
            dc.tblDirectors.Add(entity);

            // Commit the changes
            int result = dc.SaveChanges();
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void UpdateTest()
        {
            // SELECT * FROM tblDirectors - Use the first one.
            tblDirector entity = dc.tblDirectors.FirstOrDefault();

            // Change property values
            entity.FirstName = "New FirstName";
            entity.LastName = "New LastName";

            int result = dc.SaveChanges();
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            // Select * from tblDirectors where id = 345
            tblDirector entity = dc.tblDirectors.OrderBy(e => e.Id).LastOrDefault();

            dc.tblDirectors.Remove(entity);
            int result = dc.SaveChanges(true);

            Assert.AreNotEqual(result, 0);
        }
    }
}
