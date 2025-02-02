﻿namespace TSF.DVDCentral.BL.Test
{
    [TestClass]
    public class utRating : utBase
    {
        [TestMethod]
        public void LoadTest()
        {
            List<Rating> ratings = new RatingManager(options).Load();
            int expected = 5;

            Assert.AreEqual(expected, ratings.Count);
        }

        [TestMethod]
        public void InsertTest()
        {
            Rating rating = new Rating
            {
                Description = "XXXXX"
            };

            int result = new RatingManager(options).Insert(rating, true);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Rating rating = new RatingManager(options).Load().FirstOrDefault();
            rating.Description = "test";

            Assert.IsTrue(new RatingManager(options).Update(rating, true) > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Rating rating = new RatingManager(options).Load().FirstOrDefault(x => x.Description == "Other");

            Assert.IsTrue(new RatingManager(options).Delete(rating.Id, true) > 0);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            Rating rating = new RatingManager(options).Load().FirstOrDefault();
            Assert.AreEqual(new RatingManager(options).LoadById(rating.Id).Id, rating.Id);
        }


    }
}
