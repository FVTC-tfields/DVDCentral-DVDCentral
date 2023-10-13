using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TSF.DVDCentral.PL.Test
{
    [TestClass]
    public class utOrderItem
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
            Assert.AreEqual(3, dc.tblOrderItems.Count());
        }

        [TestMethod]
        public void InsertTest()
        {

            // Make an entity
            tblOrderItem entity = new tblOrderItem();
            entity.Id = 4;
            entity.OrderId = 4;
            entity.Quantity = 8;
            entity.MovieId = 4;
            entity.Cost = 40;

            // Add the entity to the database
            dc.tblOrderItems.Add(entity);

            // Commit the changes
            int result = dc.SaveChanges();
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void UpdateTest()
        {
            // SELECT * FROM tblOrderItems - Use the first one.
            tblOrderItem entity = dc.tblOrderItems.FirstOrDefault();

            // Change property values
            entity.OrderId = 4;
            entity.Quantity = 8;
            entity.MovieId = 4;
            entity.Cost = 40;

            int result = dc.SaveChanges();
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            // Select * from tblOrderItems where id = 3
            tblOrderItem entity = dc.tblOrderItems.Where(e => e.Id == 3).FirstOrDefault();

            dc.tblOrderItems.Remove(entity);
            int result = dc.SaveChanges(true);

            Assert.AreNotEqual(result, 0);
        }
    }
}
