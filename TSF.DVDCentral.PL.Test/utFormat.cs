using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TSF.DVDCentral.PL.Test
{
    [TestClass]
    public class utFormat
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
            Assert.AreEqual(3, dc.tblFormats.Count());
        }

        [TestMethod]
        public void InsertTest()
        {

            // Make an entity
            tblFormat entity = new tblFormat();
            entity.Id = -59;
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
            tblFormat entity = dc.tblFormats.Where(e => e.Id == 345).FirstOrDefault();

            dc.tblFormats.Remove(entity);
            int result = dc.SaveChanges(true);

            Assert.AreNotEqual(result, 0);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            // Select * from tblFormat where id = 345
            tblFormat entity = dc.tblFormats.Where(e => e.Id == 345).FirstOrDefault();
            Assert.AreEqual(entity.Id, 345);
        }
    }
}
