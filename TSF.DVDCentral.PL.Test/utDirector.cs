

namespace TSF.DVDCentral.PL.Test
{
    [TestClass]
    public class utDirector : utBase<tblDirector>
    {
        

        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(6, base.LoadTest().Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            int rowsAffected = base.InsertTest(new tblDirector
            {
                Id = Guid.NewGuid(),
                FirstName = "Taco",
                LastName = "Bell"
            });
            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblDirector row = base.LoadTest().FirstOrDefault();

            if (row != null)
            {
                row.FirstName = "New FirstName";
                row.LastName = "New LastName";
                int rowsAffected = base.UpdateTest(row);
                Assert.AreEqual(1, rowsAffected);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblDirector row = base.LoadTest().FirstOrDefault(x => x.LastName == "Other");

            if (row != null)
            {
                int rowsAffected = base.DeleteTest(row);
                Assert.IsTrue(rowsAffected == 1);
            }
        }
    }
}
