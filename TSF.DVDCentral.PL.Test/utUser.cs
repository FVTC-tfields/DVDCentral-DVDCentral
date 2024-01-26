

namespace TSF.DVDCentral.PL.Test
{
    [TestClass]
    public class utUser : utBase
    {

        [TestMethod]
        public void LoadTest()
        {
            var users = dc.tblUsers;
            Assert.IsTrue(users.Count() > 0);
        }

        [TestMethod]
        public void InsertTest()
        {
            tblUser newRow = new tblUser();

            newRow.Id = Guid.NewGuid();
            newRow.FirstName = "Joe";
            newRow.LastName = "Billings";
            newRow.UserName = "XXXXXX";
            newRow.Password = "YYYYY";

            dc.tblUsers.Add(newRow);
            int rowsAffected = dc.SaveChanges();

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            InsertTest();
            tblUser row = dc.tblUsers.FirstOrDefault();

            if (row != null)
            {
                row.FirstName = "Sarah";
                row.LastName = "Vicchiollo";
                int rowsAffected = dc.SaveChanges();

                Assert.AreEqual(1, rowsAffected);
            }
        }


        [TestMethod]
        public void DeleteTest()
        {
            InsertTest();

            tblUser row = dc.tblUsers.FirstOrDefault();

            if (row != null)
            {
                dc.tblUsers.Remove(row);
                int rowsAffected = dc.SaveChanges();

                Assert.IsTrue(rowsAffected == 1);
            }

        }
    }
}
