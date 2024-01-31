

namespace TSF.DVDCentral.PL.Test
{
    [TestClass]
    public class utCustomer : utBase<tblCustomer>
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
            tblCustomer entity = new tblCustomer();
            entity.Id = Guid.NewGuid();
            entity.FirstName = "Tyler";
            entity.LastName = "Fields";
            entity.UserId = dc.tblUsers.FirstOrDefault().Id;
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
            entity.UserId = dc.tblUsers.FirstOrDefault().Id;
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
            tblCustomer entity = dc.tblCustomers.OrderBy(e => e.Id).LastOrDefault();

            dc.tblCustomers.Remove(entity);
            int result = dc.SaveChanges(true);

            Assert.AreNotEqual(result, 0);
        }
    }
}
