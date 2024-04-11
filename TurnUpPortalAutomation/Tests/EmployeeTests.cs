using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using TurnUpPortalAutomation.Pages;
using TurnUpPortalAutomation.Utilities;

namespace TurnUpPortalAutomation.Tests
{
    //[Parallelizable]
    [TestFixture]
    public class EmployeeTests : CommonDriver
    {
        EmployeePage employeePageObj = new EmployeePage();

        [SetUp]
        public void SetUpEmployee()
        {
            //Open Chrome Browser
            webDriver = new ChromeDriver();

            //Login page object initialisation and definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions(webDriver, "hari", "123123");

            //Homepage object initialisation and definition
            HomePage homePageObj = new HomePage();
            homePageObj.VerifyLoggedInUser(webDriver);
            homePageObj.NavigateToEmployeePage(webDriver);
        }

        [Test, Order(1), Description("This test creates a new Time/Material record with valid details")]
        public void TestCreateEmployeeRecord()
        {
            //EmployeePage object initiation and definition
            employeePageObj.CreateEmployeeRecord(webDriver);
            //employeePageObj.VerifyRecordCreated(webDriver);
        }

        [Test, Order(2), Description("This test updates the new Time/Material record with valid details")]
        public void TestEditTimeMaterialRecord()
        {
            employeePageObj.EditNewlyCreatedEmployeeRecord(webDriver);
        }

        [Test, Order(3), Description("This test deletes the last Time/Material record with valid details")]
        public void TestDeleteTimeMaterialRecord()
        {
            employeePageObj.DeleteEmployeeRecord(webDriver);
        }

        [TearDown]
        public void CloseTestRun()
        {
            webDriver.Quit();
        }
    }
}
