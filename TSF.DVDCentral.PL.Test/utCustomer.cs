

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

            int result = InsertTest(entity);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void UpdateTest()
        {
            // SELECT * FROM tblCustomers - Use the first one.
            tblCustomer entity = base.LoadTest().FirstOrDefault();

            // Change property values
            entity.FirstName = "Tyler";
            entity.LastName = "Fields";
            int result = UpdateTest(entity);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblCustomer entity = base.LoadTest().FirstOrDefault();
            if (entity != null)
            {
                int rowsAffected = DeleteTest(entity);
                Assert.IsTrue(rowsAffected == 1);
            }
        }
    }
}
