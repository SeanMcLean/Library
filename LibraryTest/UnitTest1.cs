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
        [TestMethod]
        public void VerifyAuthorDB_IDTest()
        {
            //arrange
            //Create new instance of database connection
            DBEntities db = new DBEntities();
            //Create new instance of class that contains method to be tested
            AuthorAdd mainWin = new AuthorAdd();

            //Crete an assessor record that contains the data expected from the database
            Libary.Author expected = new Libary.Author()
            {
                AuthorId = "bd468e18-4ab3-4c33-a4b8-3a85a60d033d",
                AuthorName = "op"
            };
            //act
            //This is the method under test
            Libary.Author actual = mainWin.VerifyAuthorDB();
            //assert
            //This test does not run as expected
            Assert.AreEqual(expected.AuthorId, actual.AuthorId, "Error when extracting Assessor from database");
        }
        [TestMethod]
        public void VerifyAuthorDB_NameTest()
        {
            //arrange
            //Create new instance of database connection
            DBEntities db = new DBEntities();
            //Create new instance of class that contains method to be tested
            AuthorAdd mainWin = new AuthorAdd();

            //Crete an assessor record that contains the data expected from the database
            Libary.Author expected = new Libary.Author()
            {
                AuthorId = "bd468e18-4ab3-4c33-a4b8-3a85a60d033d",
                AuthorName = "op"
            };
            //act
            //This is the method under test
            Libary.Author actual = mainWin.VerifyAuthorDB();
            //assert
            //This test does not run as expected
            Assert.AreEqual(expected.AuthorName, actual.AuthorName, "Error when extracting Assessor from database");
        }

        [TestMethod]
        public void VerifyEmployeeDB_IdTest()
        {
            //arrange
            //Create new instance of database connection
            DBEntities db = new DBEntities();
            //Create new instance of class that contains method to be tested
            EmployeeAdd mainWin = new EmployeeAdd();

            //Crete an assessor record that contains the data expected from the database
            Libary.Employee expected = new Libary.Employee()
            {
                EmployeeId = "ee0716e6-413d-4c64-baae-9807580bc3a6",
                FirstName = "Jason",
                LastName = "Miller",
                Address = "CA",
                TelephoneNo = 1231145,
                Email = "@email",
                Role = "Accountant",
                //HireDate = "11 / 11 / 2011",
               // Salary = 200001.00
            };
            //act
            //This is the method under test
            Libary.Employee actual = mainWin.VerifyEmployeeDB();
            //assert
            //This test does not run as expected
            Assert.AreEqual(expected.EmployeeId, actual.EmployeeId, "Error when extracting Assessor from database");
        }
        [TestMethod]
        public void VerifyEmployeeDB_FNameTest()
        {
            //arrange
            //Create new instance of database connection
            DBEntities db = new DBEntities();
            //Create new instance of class that contains method to be tested
            EmployeeAdd mainWin = new EmployeeAdd();

            //Crete an assessor record that contains the data expected from the database
            Libary.Employee expected = new Libary.Employee()
            {
                FirstName = "joe",
   
            };
            //act
            //This is the method under test
            Libary.Employee actual = mainWin.VerifyEmployeeDB();
            //assert
            //This test does not run as expected
            Assert.AreEqual(expected.FirstName, actual.FirstName, "Error when extracting Assessor from database");
        }
        [TestMethod]
        public void VerifyEmployeeDB_LNameTest()
        {
            //arrange
            //Create new instance of database connection
            DBEntities db = new DBEntities();
            //Create new instance of class that contains method to be tested
            EmployeeAdd mainWin = new EmployeeAdd();

            //Crete an assessor record that contains the data expected from the database
            Libary.Employee expected = new Libary.Employee()
            {
                LastName = "joe",
            };
            //act
            //This is the method under test
            Libary.Employee actual = mainWin.VerifyEmployeeDB();
            //assert
            //This test does not run as expected
            Assert.AreEqual(expected.LastName, actual.LastName, "Error when extracting Assessor from database");
        }
        [TestMethod]
        public void VerifyEmployeeDB_AddressTest()
        {
            //arrange
            //Create new instance of database connection
            DBEntities db = new DBEntities();
            //Create new instance of class that contains method to be tested
            EmployeeAdd mainWin = new EmployeeAdd();

            //Crete an assessor record that contains the data expected from the database
            Libary.Employee expected = new Libary.Employee()
            {
                Address = "home",

            };
            //act
            //This is the method under test
            Libary.Employee actual = mainWin.VerifyEmployeeDB();
            //assert
            //This test does not run as expected
            Assert.AreEqual(expected.Address, actual.Address, "Error when extracting Assessor from database");
        }
        [TestMethod]
        public void VerifyEmployeeDB_TelephoneNoTest()
        {
            //arrange
            //Create new instance of database connection
            DBEntities db = new DBEntities();
            //Create new instance of class that contains method to be tested
            EmployeeAdd mainWin = new EmployeeAdd();

            //Crete an assessor record that contains the data expected from the database
            Libary.Employee expected = new Libary.Employee()
            {
                TelephoneNo = 2,
 
            };
            //act
            //This is the method under test
            Libary.Employee actual = mainWin.VerifyEmployeeDB();
            //assert
            //This test does not run as expected
            Assert.AreEqual(expected.TelephoneNo, actual.TelephoneNo, "Error when extracting Assessor from database");
        }
        public void VerifyEmployeeDB_EmailTest()
        {
            //arrange
            //Create new instance of database connection
            DBEntities db = new DBEntities();
            //Create new instance of class that contains method to be tested
            EmployeeAdd mainWin = new EmployeeAdd();

            //Crete an assessor record that contains the data expected from the database
            Libary.Employee expected = new Libary.Employee()
            {

                Email = "email",
                Role = "Accountant",
                //HireDate = "11 / 11 / 2011",
                // Salary = 200001.00
            };
            //act
            //This is the method under test
            Libary.Employee actual = mainWin.VerifyEmployeeDB();
            //assert
            //This test does not run as expected
            Assert.AreEqual(expected.Email, actual.Email, "Error when extracting Assessor from database");
        }
        public void VerifyEmployeeDB_RoleTest()
        {
            //arrange
            //Create new instance of database connection
            DBEntities db = new DBEntities();
            //Create new instance of class that contains method to be tested
            EmployeeAdd mainWin = new EmployeeAdd();

            //Crete an assessor record that contains the data expected from the database
            Libary.Employee expected = new Libary.Employee()
            {

                Role = "Accountant",
                //HireDate = "11 / 11 / 2011",
                // Salary = 200001.00
            };
            //act
            //This is the method under test
            Libary.Employee actual = mainWin.VerifyEmployeeDB();
            //assert
            //This test does not run as expected
            Assert.AreEqual(expected.Role, actual.Role, "Error when extracting Assessor from database");
        }
        public void VerifyEmployeeDB_HireDateTest()
        {
            //arrange
            //Create new instance of database connection
            DBEntities db = new DBEntities();
            //Create new instance of class that contains method to be tested
            EmployeeAdd mainWin = new EmployeeAdd();

            //Crete an assessor record that contains the data expected from the database
            Libary.Employee expected = new Libary.Employee()
            {

                HireDate = 11 / 11 / 2011,
                // Salary = 200001.00
            };
            //act
            //This is the method under test
            Libary.Employee actual = mainWin.VerifyEmployeeDB();
            //assert
            //This test does not run as expected
            Assert.AreEqual(expected.HireDate, actual.HireDate, "Error when extracting Assessor from database");
        }
        public void VerifyEmployeeDB_SalaryTest()
        {
            //arrange
            //Create new instance of database connection
            DBEntities db = new DBEntities();
            //Create new instance of class that contains method to be tested
            EmployeeAdd mainWin = new EmployeeAdd();

            //Crete an assessor record that contains the data expected from the database
            Libary.Employee expected = new Libary.Employee()
            {

                Salary = 200001.00
            };
            //act
            //This is the method under test
            Libary.Employee actual = mainWin.VerifyEmployeeDB();
            //assert
            //This test does not run as expected
            Assert.AreEqual(expected.Salary, actual.Salary, "Error when extracting Assessor from database");
        }
    }
}

