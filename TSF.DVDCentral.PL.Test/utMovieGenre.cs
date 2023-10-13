using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TSF.DVDCentral.PL.Test
{
    [TestClass]
    public class utMovieGenre
    {
        protected DVDCentralEntities dc;
        protected IDbContextTransaction transaction;

        [TestInitialize]
        public void Initialize()
        {
            dc = new DVDCentralEntities();
            transaction = dc.Database.BeginTransaction();
        }

        [TestCleanup]
        public void Cleanup()
        {
            transaction.Rollback();
            transaction.Dispose();
            dc = null;
        }

        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(3, dc.tblMovieGenres.Count());
        }

        [TestMethod]
        public void InsertTest()
        {

            // Make an entity
            tblMovieGenre entity = new tblMovieGenre();
            entity.Id = 4;
            entity.MovieId = 4;
            entity.GenreId = 4;

            // Add the entity to the database
            dc.tblMovieGenres.Add(entity);

            // Commit the changes
            int result = dc.SaveChanges();
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void UpdateTest()
        {
            // SELECT * FROM tblMovieGenres - Use the first one.
            tblMovieGenre entity = dc.tblMovieGenres.FirstOrDefault();

            // Change property values
            entity.MovieId = 4;
            entity.GenreId = 4;

            int result = dc.SaveChanges();
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            // Select * from tblMovieGenres where id = 3
            tblMovieGenre entity = dc.tblMovieGenres.Where(e => e.Id == 3).FirstOrDefault();

            dc.tblMovieGenres.Remove(entity);
            int result = dc.SaveChanges(true);

            Assert.AreNotEqual(result, 0);
        }
    }
}
