﻿using System.Xml.Linq;
using TSF.DVDCentral.BL.Models;

namespace TSF.DVDCentral.BL.Test
{
    [TestClass]
    public class utRating
    {
        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(3, RatingManager.Load().Count);
        }

        [TestMethod]
        public void InsertTest1()
        {
            int id = 0;
            int results = RatingManager.Insert("Test", ref id, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void InsertTest2()
        {
            int id = 0;
            Rating rating = new Rating
            {
                Description = "Test"
            };

            int results = RatingManager.Insert(rating, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Rating rating = RatingManager.LoadById(345);
            rating.Description = "Test";
            int results = RatingManager.Update(rating, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void DeleteTest()
        {
            int results = RatingManager.Delete(345, true);
            Assert.AreEqual(1, results);
        }
    }
}