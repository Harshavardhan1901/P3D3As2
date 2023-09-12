using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    [TestFixture]
    public class UserAuthenticatotTest
    {
        private UserAuthenticator userAuthenticator;

        [SetUp]
        public void Setup()
        {
            userAuthenticator = new UserAuthenticator();
        }

        [Test]
        public void TestUserRegistration()
        {
            userAuthenticator.RegisterUser("Harsha", "Sai");
            // Assert that the user is registered
            Assert.IsTrue(userAuthenticator.Login("Harsha", "Sai"));
        }

        [Test]
        public void TestUserLogin()
        {
            // Register a user first
            userAuthenticator.RegisterUser("Harsha", "Sai");

            // Test user login
            Assert.IsTrue(userAuthenticator.Login("Harsha", "Sai"));
            Assert.IsFalse(userAuthenticator.Login("Harsh", "Sai"));
            Assert.IsFalse(userAuthenticator.Login("harsha", "sai"));
        }

        [Test]
        public void TestPasswordReset()
        {
            // Register a user first
            userAuthenticator.RegisterUser("Harsha", "Sai");

            // Reset the password for user "Maximus" to "Maximus"
            userAuthenticator.ResetPassword("Harsha", "Sai@123");

            // Attempt login with the new password
            Assert.IsTrue(userAuthenticator.Login("Harsha", "Sai@123"));
        }
    }
}
