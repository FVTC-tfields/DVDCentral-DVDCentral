﻿namespace TSF.DVDCentral.BL.Test
{
    [TestClass]
    public class utUser : utBase
    {

        [TestInitialize]
        public void Initialize()
        {
            new UserManager(options).Seed();
        }


        [TestMethod]
        public void LoadTest()
        {
            List<User> users = new UserManager(options).Load();
            Assert.IsTrue(users.Count > 0);
        }

        [TestMethod]
        public void InsertTest()
        {
            User user = new User { FirstName = "Bill", LastName = "Smith", UserName = "bsmith", Password = "1234" };
            int result = new UserManager(options).Insert(user, true);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void LoginSuccess()
        {
            User user = new User { FirstName = "Tyler", LastName = "Fields", UserName = "tfields", Password = "larry" };
            bool result = new UserManager(options).Login(user);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void LoginFail()
        {
            try
            {
                User user = new User { FirstName = "Tyler", LastName = "Fields", UserName = "tfields", Password = "xxxxx" };
                new UserManager(options).Login(user);
                Assert.Fail();
            }
            catch (LoginFailureException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }



    }
}
