

namespace TSF.DVDCentral.PL.Test
{
    [TestClass]
    public class utOrderItem : utBase<tblOrderItem>
    {
        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(3, base.LoadTest().Count());
        }

        [TestMethod]
        public void InsertTest()
        {

            // Make an entity
            tblOrderItem entity = new tblOrderItem();
            entity.Id = Guid.NewGuid();
            entity.OrderId = dc.tblOrders.FirstOrDefault().Id;
            entity.Quantity = 8;
            entity.MovieId = dc.tblMovies.FirstOrDefault().Id;
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
            entity.OrderId = dc.tblOrders.FirstOrDefault().Id;
            entity.Quantity = 8;
            entity.MovieId = dc.tblMovies.FirstOrDefault().Id;
            entity.Cost = 40;

            int result = dc.SaveChanges();
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            // Select * from tblOrderItems where id = 3
            tblOrderItem entity = dc.tblOrderItems.OrderBy(e => e.Id).LastOrDefault();

            dc.tblOrderItems.Remove(entity);
            int result = dc.SaveChanges(true);

            Assert.AreNotEqual(result, 0);
        }
    }
}
