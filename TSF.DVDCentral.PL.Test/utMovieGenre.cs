

namespace TSF.DVDCentral.PL.Test
{
    [TestClass]
    public class utMovieGenre : utBase<tblMovieGenre>
    {
        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(13, base.LoadTest().Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            tblMovieGenre newRow = new tblMovieGenre();

            newRow.Id = Guid.NewGuid();
            newRow.MovieId = base.LoadTest().FirstOrDefault().MovieId;
            newRow.GenreId = base.LoadTest().FirstOrDefault().GenreId;

            int rowsAffected = InsertTest(newRow);

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblMovieGenre row = dc.tblMovieGenres.FirstOrDefault();

            if (row != null)
            {
                row.MovieId = base.LoadTest().FirstOrDefault().MovieId;
                row.GenreId = base.LoadTest().FirstOrDefault().GenreId;
                int rowsAffected = UpdateTest(row);
                Assert.AreEqual(1, rowsAffected);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblMovieGenre row = dc.tblMovieGenres.FirstOrDefault();
            if (row != null)
            {
                int rowsAffected = DeleteTest(row);
                Assert.IsTrue(rowsAffected == 1);
            }
        }
    }
}
