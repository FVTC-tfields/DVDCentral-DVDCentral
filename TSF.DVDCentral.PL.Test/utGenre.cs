

namespace TSF.DVDCentral.PL.Test
{
    [TestClass]
    public class utGenre : utBase<tblGenre>
    {
        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(10, base.LoadTest().Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            int rowsAffected = base.InsertTest(new tblGenre
            {
                Id = Guid.NewGuid(),
                Description = "XXXXX"
            });
            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            // SELECT * FROM tblGenres - Use the first one.
            tblGenre entity = dc.tblGenres.FirstOrDefault();

            // Change property values
            entity.Description = "New Description";

            int result = dc.SaveChanges();
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            // Select * from tblGenres where id = 3
            tblGenre entity = dc.tblGenres.FirstOrDefault(x => x.Description == "Other");

            dc.tblGenres.Remove(entity);
            int result = dc.SaveChanges(true);

            Assert.AreNotEqual(result, 0);
        }
    }
}
