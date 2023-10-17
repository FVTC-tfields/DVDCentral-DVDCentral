using System.Xml.Linq;
using TSF.DVDCentral.BL.Models;
using TSF.DVDCentral.PL;

namespace TSF.DVDCentral.BL.Test
{
    [TestClass]
    public class utCustomer
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
            int results = CustomerManager.Insert("Test", "Test", ref id, 0, "Test", "Test", "NO", "Test", "Test", true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void InsertTest2()
        {
            int id = 0;
            Customer customer = new Customer
            {
                FirstName = "Test",
                LastName = "Test",
                UserId = 33333,
                Address = "Test",
                City = "Test",
                State = "SI",
                ZIP = "Test",
                Phone = "Test"
            };

            int results = CustomerManager.Insert(customer, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Customer customer = CustomerManager.LoadById(3);
            customer.FirstName = "Test";
            customer.LastName = "Test";
            customer.UserId = 33333;
            customer.Address = "Test";
            customer.City = "Test";
            customer.State = "NO";
            customer.ZIP = "Test";
            customer.Phone = "1234567890";
            int results = CustomerManager.Update(customer, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void DeleteTest()
        {
            int results = CustomerManager.Delete(3, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void LoadByIdTest()
        {

            Customer customer = CustomerManager.LoadById(3);
            Assert.AreEqual(3, customer.Id);
        }
    }
}