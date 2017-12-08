using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Libary;

namespace LibraryTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void VerifyUserDetails_AccessLevelTest()
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

        [TestMethod]
        public void VerifyUserDetails_UserNameTest()
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
            Assert.AreEqual(expected.UserName, actual.UserName, "Error when extracting Assessor from database");
        }

        [TestMethod]
        public void VerifyUserDetails_UserIdTest()
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
            Assert.AreEqual(expected.UserId, actual.UserId, "Error when extracting Assessor from database");
        }

        [TestMethod]
        public void VerifyUserDetails_FirstNameTest()
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
            Assert.AreEqual(expected.FirstName, actual.FirstName, "Error when extracting Assessor from database");
        }


        [TestMethod]
        public void VerifyUserDetails_LastNameTest()
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
            Assert.AreEqual(expected.LastName, actual.LastName, "Error when extracting Assessor from database");
        }

        [TestMethod]
        public void VerifyUserDetails_AddressTest()
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
            Assert.AreEqual(expected.Address, actual.Address, "Error when extracting Assessor from database");
        }
        [TestMethod]
        public void VerifyUserDetails_EmailTest()
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
            Assert.AreEqual(expected.Email, actual.Email, "Error when extracting Assessor from database");
        }
        [TestMethod]
        public void VerifyUserDetails_TelephoneNoTest()
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
            Assert.AreEqual(expected.TelephoneNo, actual.TelephoneNo, "Error when extracting Assessor from database");
        }
        [TestMethod]
        public void VerifyUserDetails_PasswordTest()
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
            Assert.AreEqual(expected.Password, actual.Password, "Error when extracting Assessor from database");
        }
    }
}

