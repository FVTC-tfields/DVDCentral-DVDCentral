using TSF.DVDCentral.BL.Models;

namespace TSF.DVDCentral.BL.Test
{
    [TestClass]
    public class utOrder
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
            int results = OrderManager.Insert(0, 0, ref id, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void InsertTest2()
        {
            int id = 0;
            Order order = new Order
            {
                CustomerId = 4,
                UserId = 33333
            };

            int results = OrderManager.Insert(order, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Order order = OrderManager.LoadById(3);
            order.CustomerId = 4;
            order.UserId = 33333;
            int results = OrderManager.Update(order, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void DeleteTest()
        {
            int results = OrderManager.Delete(3, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void InsertOrderItemsTest()
        {
            Order order = new Order
            {
                CustomerId = 99,
                OrderDate = DateTime.Now,
                UserId = 99,
                ShipDate = DateTime.Now,
                OrderItems = new List<OrderItem>()
                {
                    new OrderItem
                    {
                        Id = 88,
                        MovieId = 1,
                        Cost = 9.99f,
                        Quantity = 9
                    },
                    new OrderItem
                    {
                        Id = 99,
                        MovieId = 2,
                        Cost = 8.88f,
                        Quantity = 2
                    }
                }
            };
            int result = OrderManager.Insert(order, true);
            Assert.AreEqual(order.OrderItems[1].OrderId, order.Id);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            int id = OrderManager.Load().LastOrDefault().Id;
            Order order = OrderManager.LoadById(id);
            Assert.AreEqual(order.Id, id);
            Assert.IsTrue(order.OrderItems.Count > 0);
        }

        [TestMethod]
        public void LoadByIdCustomerIdTest()
        {
            int customerId = OrderManager.Load().FirstOrDefault().CustomerId;
            Assert.AreEqual(OrderManager.LoadById(customerId).CustomerId, customerId);
        }
    }
}