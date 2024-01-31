

namespace TSF.DVDCentral.PL.Test
{
    [TestClass]
    public class utMovie : utBase<tblMovie>
    {
        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(7, base.LoadTest().Count());
        }

        [TestMethod]
        public void InsertTest()
        {

            // Make an entity
            tblMovie entity = new tblMovie();
            entity.Id = Guid.NewGuid();
            entity.Title = "New Title";
            entity.Description = "New Description";
            entity.FormatId = base.LoadTest().FirstOrDefault().FormatId;
            entity.DirectorId = base.LoadTest().FirstOrDefault().DirectorId;
            entity.RatingId =base.LoadTest().FirstOrDefault().RatingId;
            entity.Cost = 6;
            entity.Quantity = 111;
            entity.ImagePath = "dtb";

            // Commit the changes
            int result = base.InsertTest(entity);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblMovie row = base.LoadTest().FirstOrDefault();

            if (row != null)
            {
                row.Description = "YYYYY";
                int rowsAffected = UpdateTest(row);
                Assert.AreEqual(1, rowsAffected);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblMovie row = base.LoadTest().FirstOrDefault(x => x.Description == "Other");

            if (row != null)
            {
                int rowsAffected = DeleteTest(row);

                Assert.IsTrue(rowsAffected == 1);
            }
        }
    }
}
