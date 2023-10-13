using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TSF.DVDCentral.PL.Test
{
    [TestClass]
    public class utOrder
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
            Assert.AreEqual(3, dc.tblOrders.Count());
        }

        [TestMethod]
        public void InsertTest()
        {

            // Make an entity
            tblOrder entity = new tblOrder();
            entity.Id = 4;
            entity.CustomerId = 4;
            entity.OrderDate = DateTime.Now;
            entity.ShipDate = DateTime.Now;
            entity.UserId = 33333;

            // Add the entity to the database
            dc.tblOrders.Add(entity);

            // Commit the changes
            int result = dc.SaveChanges();
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void UpdateTest()
        {
            // SELECT * FROM tblOrders - Use the first one.
            tblOrder entity = dc.tblOrders.FirstOrDefault();

            // Change property values
            entity.CustomerId = 4;
            entity.UserId = 33333;

            int result = dc.SaveChanges();
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            // Select * from tblOrders where id = 3
            tblOrder entity = dc.tblOrders.Where(e => e.Id == 3).FirstOrDefault();

            dc.tblOrders.Remove(entity);
            int result = dc.SaveChanges(true);

            Assert.AreNotEqual(result, 0);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            // Select * from tblDirector where id = 4
            tblOrder entity = dc.tblOrders.Where(e => e.Id == 3).FirstOrDefault();
            Assert.AreEqual(entity.Id, 3);
        }
    }
}
