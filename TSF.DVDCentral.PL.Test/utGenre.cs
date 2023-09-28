using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TSF.DVDCentral.PL.Test
{
    [TestClass]
    public class utGenre
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
            Assert.AreEqual(3, dc.tblGenres.Count());
        }

        [TestMethod]
        public void InsertTest()
        {

            // Make an entity
            tblGenre entity = new tblGenre();
            entity.Id = -51;
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
            tblGenre entity = dc.tblGenres.Where(e => e.Id == 3).FirstOrDefault();

            dc.tblGenres.Remove(entity);
            int result = dc.SaveChanges(true);

            Assert.AreNotEqual(result, 0);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            // Select * from tblGenre where id = 3
            tblGenre entity = dc.tblGenres.Where(e => e.Id == 3).FirstOrDefault();
            Assert.AreEqual(entity.Id, 3);
        }
    }
}
