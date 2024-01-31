

namespace TSF.DVDCentral.PL.Test
{
    [TestClass]
    public class utFormat : utBase<tblFormat>
    {
        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(4, base.LoadTest().Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            int rowsAffected = base.InsertTest(new tblFormat
            {
                Id = Guid.NewGuid(),
                Description = "XXXXX"
            });
            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            // SELECT * FROM tblFormats - Use the first one.
            tblFormat row = base.LoadTest().FirstOrDefault(x => x.Description == "Other");

            if (row != null)
            {
                row.Description = "YYYY";
                int rowsAffected = dc.SaveChanges();

                Assert.AreEqual(1, rowsAffected);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblFormat row = base.LoadTest().FirstOrDefault(x => x.Description == "Other");

            if (row != null)
            {
                dc.tblFormats.Remove(row);
                int rowsAffected = dc.SaveChanges();

                Assert.IsTrue(rowsAffected == 1);
            }
        }
    }
}
