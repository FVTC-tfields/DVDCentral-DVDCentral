

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

            tblOrderItem newRow = new tblOrderItem();

            newRow.Id = Guid.NewGuid();
            newRow.MovieId = dc.tblMovies.FirstOrDefault().Id;
            newRow.OrderId = dc.tblOrders.FirstOrDefault().Id;
            newRow.Quantity = 99;
            newRow.Cost = 9.99;

            dc.tblOrderItems.Add(newRow);
            int rowsAffected = dc.SaveChanges();

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblOrderItem row = base.LoadTest().FirstOrDefault();

            if (row != null)
            {
                row.MovieId = dc.tblMovies.FirstOrDefault().Id;
                row.Quantity = 100;
                row.Cost = 10.99;
                int rowsAffected = UpdateTest(row);

                Assert.AreEqual(1, rowsAffected);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblOrderItem row = base.LoadTest().FirstOrDefault();

            if (row != null)
            {
                int rowsAffected = DeleteTest(row);
                Assert.IsTrue(rowsAffected == 1);
            }
        }
    }
}
