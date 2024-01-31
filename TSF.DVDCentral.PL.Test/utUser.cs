

namespace TSF.DVDCentral.PL.Test
{
    [TestClass]
    public class utUser : utBase<tblUser>
    {

        [TestMethod]
        public void LoadTest()
        {
            Assert.IsTrue(base.LoadTest().Count() > 0);
        }

        [TestMethod]
        public void InsertTest()
        {
            tblUser newRow = new tblUser();

            newRow.Id = Guid.NewGuid();
            newRow.FirstName = "Tyler";
            newRow.LastName = "Fields";
            newRow.UserName = "XXXXXX";
            newRow.Password = "YYYYY";

            int rowsAffected = InsertTest(newRow);

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblUser row = dc.tblUsers.FirstOrDefault();

            if (row != null)
            {
                row.FirstName = "Tyler";
                row.LastName = "Fields";
                int rowsAffected = dc.SaveChanges();

                Assert.AreEqual(1, rowsAffected);
            }
        }


        [TestMethod]
        public void DeleteTest()
        {
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
