using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TSF.DVDCentral.PL.Test
{
    [TestClass]
    public class utCustomer
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
            Assert.AreEqual(3, dc.tblCustomers.Count());
        }

        [TestMethod]
        public void InsertTest()
        {

            // Make an entity
            tblCustomer entity = new tblCustomer();
            entity.Id = 4;
            entity.FirstName = "Tyler";
            entity.LastName = "Fields";
            entity.UserId = 33333;
            entity.Address = "123 Taco Drive";
            entity.City = "Milwaukee";
            entity.State = "WI";
            entity.ZIP = "11111";
            entity.Phone = "1234567891";

            // Add the entity to the database
            dc.tblCustomers.Add(entity);

            // Commit the changes
            int result = dc.SaveChanges();
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void UpdateTest()
        {
            // SELECT * FROM tblCustomers - Use the first one.
            tblCustomer entity = dc.tblCustomers.FirstOrDefault();

            // Change property values
            entity.FirstName = "Tyler";
            entity.LastName = "Fields";
            entity.UserId = 33333;
            entity.Address = "123 Taco Drive";
            entity.City = "Milwaukee";
            entity.State = "WI";
            entity.ZIP = "11111";
            entity.Phone = "1234567891";

            int result = dc.SaveChanges();
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            // Select * from tblCustomers where id = 3
            tblCustomer entity = dc.tblCustomers.Where(e => e.Id == 3).FirstOrDefault();

            dc.tblCustomers.Remove(entity);
            int result = dc.SaveChanges(true);

            Assert.AreNotEqual(result, 0);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            // Select * from tblDirector where id = 4
            tblCustomer entity = dc.tblCustomers.Where(e => e.Id == 3).FirstOrDefault();
            Assert.AreEqual(entity.Id, 3);
        }
    }
}
