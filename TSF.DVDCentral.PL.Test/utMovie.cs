using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TSF.DVDCentral.PL.Test
{
    [TestClass]
    public class utMovie
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
            Assert.AreEqual(3, dc.tblMovies.Count());
        }

        [TestMethod]
        public void InsertTest()
        {

            // Make an entity
            tblMovie entity = new tblMovie();
            entity.Id = -59;
            entity.Title = "New Title";
            entity.Description = "New Description";
            entity.FormatId = 444;
            entity.DirectorId = 333;
            entity.RatingId = 222;
            entity.Cost = 6;
            entity.InStkQty = 111;
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
            entity.FormatId = 444;
            entity.DirectorId = 333;
            entity.RatingId = 222;
            entity.Cost = 6;
            entity.InStkQty = 111;
            entity.ImagePath = "dtb";

            int result = dc.SaveChanges();
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            // Select * from tblMovies where id = 3
            tblMovie entity = dc.tblMovies.Where(e => e.Id == 3).FirstOrDefault();

            dc.tblMovies.Remove(entity);
            int result = dc.SaveChanges(true);

            Assert.AreNotEqual(result, 0);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            // Select * from tblMovie where id = 3
            tblMovie entity = dc.tblMovies.Where(e => e.Id == 3).FirstOrDefault();
            Assert.AreEqual(entity.Id, 3);
        }
    }
}
