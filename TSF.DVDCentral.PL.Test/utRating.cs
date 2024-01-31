

namespace TSF.DVDCentral.PL.Test
{
    [TestClass]
    public class utRating : utBase<tblRating>
    {
        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(5, base.LoadTest().Count());
        }

        [TestMethod] 
        public void InsertTest() 
        { 
            int rowsAffected = base.InsertTest( new tblRating { Id = Guid.NewGuid(), 
                                                               Description = "XXXXX"});
            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblRating row = base.LoadTest().FirstOrDefault();

            if (row != null) 
            {
                row.Description = "YYYYY";
                int rowsAffected = base.UpdateTest(row);
                Assert.AreEqual(1, rowsAffected);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblRating row = base.LoadTest().FirstOrDefault(x => x.Description == "Other");

            if (row != null)
            {
                int rowsAffected = base.DeleteTest(row);
                Assert.IsTrue(rowsAffected == 1);
            }
        }
    }
}
