using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSF.DVDCentral.PL.Test
{
    [TestClass]
    public class utRating
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
            Assert.AreEqual(3, dc.tblRatings.Count());
        }

        [TestMethod]
        public void InsertTest()
        {

            // Make an entity
            tblRating entity = new tblRating();
            entity.Id = -52;
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
            // Select * from tblRatings where id = 345
            tblRating entity = dc.tblRatings.Where(e => e.Id == 345).FirstOrDefault();

            dc.tblRatings.Remove(entity);
            int result = dc.SaveChanges(true);

            Assert.AreNotEqual(result, 0);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            // Select * from tblRating where id = 345
            tblRating entity = dc.tblRatings.Where(e => e.Id == 345).FirstOrDefault();
            Assert.AreEqual(entity.Id, 345);
        }
    }
}
