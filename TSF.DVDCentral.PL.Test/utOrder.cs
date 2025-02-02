﻿

namespace TSF.DVDCentral.PL.Test
{
    [TestClass]
    public class utOrder : utBase<tblOrder>
    {
        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(3, base.LoadTest().Count());
        }

        [TestMethod]
        public void InsertTest()
        {

            tblOrder newRow = new tblOrder();

            newRow.Id = Guid.NewGuid();
            newRow.CustomerId = dc.tblCustomers.FirstOrDefault().Id;
            newRow.OrderDate = DateTime.Now;
            newRow.UserId = dc.tblUsers.FirstOrDefault().Id;
            newRow.ShipDate = DateTime.Now;

            dc.tblOrders.Add(newRow);
            int rowsAffected = dc.SaveChanges();

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblOrder row = dc.tblOrders.FirstOrDefault();

            if (row != null)
            {
                row.CustomerId = dc.tblCustomers.FirstOrDefault().Id;
                int rowsAffected = dc.SaveChanges();

                Assert.AreEqual(1, rowsAffected);
            }
        }
    }
}
