using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Libary;

namespace LibraryTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void VerifyUserDetails_Test()
        {
            //arrange
            //Create new instance of database connection
            SeanDBEntities db = new SeanDBEntities();
            //Create new instance of class that contains method to be tested
            MainWindow mainWin = new MainWindow();
            //This is the name of the assessor that will be extracted from the database.
            //This user currently exists in the database.
            string userName = "admin";
            string userPassword = "password";

            //Create an assessor record that contains the data expected from the database
            User expected = new User()
            {
                UserId = "2",
                AccessLevel = 2,
                Password = "password",
                UserName = "admin"
            };
            //act
            //This is the method under test
            User actual = mainWin.VerifyUserDetails(userName, userPassword);
            //assert
            //This test does not run as expected
            Assert.AreEqual<User>(expected, actual, "Error when extracting Assessor from database");
        }
    }
}
