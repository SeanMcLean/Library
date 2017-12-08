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
            DBEntities db = new DBEntities();
            //Create new instance of class that contains method to be tested
            MainWindow mainWin = new MainWindow();
            //This is the name of the assessor that will be extracted from the database.
            //This user currently exists in the database.
            string userName = "admin";
            string userPassword = "password";

            //Crete an assessor record that contains the data expected from the database
            Libary.User expected = new Libary.User()
            {
                UserId = "2",
                UserName = "admin",
                FirstName = "admin",
                LastName = "admin",
                Address = "admin",
                Email = "admin",
                TelephoneNo = "001",
                Password = "password",
                AccessLevel = 2
            };
            //act
            //This is the method under test
            Libary.User actual = mainWin.VerifyUserDetails(userName, userPassword);
            //assert
            //This test does not run as expected
            Assert.AreEqual(expected.AccessLevel, actual.AccessLevel, "Error when extracting Assessor from database");
        }
    }
}
