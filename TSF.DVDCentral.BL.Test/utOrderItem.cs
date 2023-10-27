using TSF.DVDCentral.BL.Models;

namespace TSF.DVDCentral.BL.Test
{
    [TestClass]
    public class utOrderItem
    {

        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(3, CustomerManager.Load().Count);
        }

        [TestMethod]
        public void InsertTest1()
        {
            int id = 0;
            int results = OrderItemManager.Insert(0, ref id, 0, 0, 0, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void InsertTest2()
        {
            int id = 0;
            OrderItem orderitem = new OrderItem
            {
                OrderId = 4,
                Quantity = 4,
                MovieId = 8,
                Cost = 40
            };

            int results = OrderItemManager.Insert(orderitem, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void UpdateTest()
        {
            OrderItem orderitem = OrderItemManager.LoadById(3);
            orderitem.OrderId = 4;
            orderitem.Quantity = 4;
            orderitem.MovieId = 8;
            orderitem.Cost = 40;
            int results = OrderItemManager.Update(orderitem, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void DeleteTest()
        {
            int results = OrderItemManager.Delete(3, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void LoadByOrderIdTest()
        {
            int orderId = OrderItemManager.Load().FirstOrDefault().OrderId;
            Assert.IsTrue(OrderItemManager.LoadByOrderId(orderId).Count > 0);
        }
    }
}