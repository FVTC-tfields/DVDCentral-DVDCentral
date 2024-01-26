

namespace TSF.DVDCentral.PL.Test
{
    [TestClass]
    public class utOrder : utBase
    {
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
            entity.Id = Guid.NewGuid();
            entity.CustomerId = dc.tblCustomers.FirstOrDefault().Id;
            entity.OrderDate = DateTime.Now;
            entity.ShipDate = DateTime.Now;
            entity.UserId = dc.tblUsers.FirstOrDefault().Id;

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
            entity.CustomerId = dc.tblCustomers.FirstOrDefault().Id;
            entity.UserId = dc.tblUsers.FirstOrDefault().Id;

            int result = dc.SaveChanges();
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            // Select * from tblOrders where id = 3
            tblOrder entity = dc.tblOrders.OrderBy(e => e.Id).LastOrDefault();

            dc.tblOrders.Remove(entity);
            int result = dc.SaveChanges(true);

            Assert.AreNotEqual(result, 0);
        }
    }
}
