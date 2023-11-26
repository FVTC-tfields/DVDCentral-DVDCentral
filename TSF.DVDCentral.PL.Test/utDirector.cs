using System.Xml;

namespace TSF.DVDCentral.PL.Test
{
    [TestClass]
    public class utDirector
    {
        protected DVDCentralEntities dc;
        protected IDbContextTransaction transaction;

        [TestInitialize]
        public void Initialize()
        {
            dc = new DVDCentralEntities();
            transaction = dc.Database.BeginTransaction();
        }

        [TestCleanup]
        public void Cleanup()
        {
            transaction.Rollback();
            transaction.Dispose();
            dc = null;
        }

        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(3, dc.tblDirectors.Count());
        }

        [TestMethod]
        public void InsertTest()
        {

            // Make an entity
            tblDirector entity = new tblDirector();
            entity.Id = -91;
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
            tblDirector entity = dc.tblDirectors.Where(e => e.Id == 3).FirstOrDefault();

            dc.tblDirectors.Remove(entity);
            int result = dc.SaveChanges(true);

            Assert.AreNotEqual(result, 0);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            // Select * from tblDirector where id = 4
            tblDirector entity = dc.tblDirectors.Where(e => e.Id == 3).FirstOrDefault();
            Assert.AreEqual(entity.Id, 3);
        }
    }
}
