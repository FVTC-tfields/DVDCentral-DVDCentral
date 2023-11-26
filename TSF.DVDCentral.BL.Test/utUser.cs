using TSF.DVDCentral.BL.Models;
using TSF.DVDCentral.BL;

namespace TSF.ProgDec.BL.Test
{
    [TestClass]
    public class utUser
    {
        [TestMethod]
        public void LoginSuccessfulTest()
        {
            Seed();
            Assert.IsTrue(UserManager.Login(new User { UserId = "tfields", Password = "larry" }));
            Assert.IsTrue(UserManager.Login(new User { UserId = "bfoote", Password = "maple" }));
        }

        public void Seed()
        {
            UserManager.Seed();
        }

        [TestMethod]
        public void InsertTest()
        {

        }

        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(2, UserManager.Load().Count);
        }

        [TestMethod]
        public void LoginFailureNoUserId()
        {
            try
            {
                Seed();
                Assert.IsFalse(UserManager.Login(new User { UserId = "", Password = "larry" }));
            }
            catch (LoginFailureException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void LoginFailureBadPassword()
        {
            try
            {
                Seed();
                Assert.IsFalse(UserManager.Login(new User { UserId = "tfields", Password = "taco" }));
            }
            catch (LoginFailureException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        public void LoginFailureBadUserId()
        {
            try
            {
                Seed();
                Assert.IsFalse(UserManager.Login(new User { UserId = "tfelds", Password = "larry" }));
            }
            catch (LoginFailureException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        public void LoginFailureNoPassword()
        {
            try
            {
                Seed();
                Assert.IsFalse(UserManager.Login(new User { UserId = "tfields", Password = "" }));
            }
            catch (LoginFailureException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
