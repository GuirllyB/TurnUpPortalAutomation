using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using TurnUpPortalAutomation.Pages;
using TurnUpPortalAutomation.Utilities;

namespace TurnUpPortalAutomation.Tests
{
    [Parallelizable]
    [TestFixture]
    public class TimeMaterialTests : CommonDriver
    {
        TimeMaterialPage tmPageObj = new TimeMaterialPage();

        [SetUp]
        public void SetUpTimeMaterial()
        {
            //Open Chrome Browser
            webDriver = new ChromeDriver();
            
            //Login page object initialisation and definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions(webDriver, "hari", "123123");

            //Homepage object initialisation and definition
            HomePage homePageObj = new HomePage();
            homePageObj.VerifyLoggedInUser(webDriver);
            homePageObj.NavigateToTimeMaterialPage(webDriver);
        }

        /*
         *This test is for testing the Time/Material record creation
         *These are the test data used for the test
         *Type = GBTime
         */

        [Test, Order(1), Description("This test creates a new Time/Material record with valid details")]
        public void TestCreateTimeMaterialRecord()
        {
            //TMPage object initiation and definition
            //TimeMaterialPage tmPageObj = new TimeMaterialPage();
            tmPageObj.CreateTimeRecord(webDriver);
            tmPageObj.VerifyRecordCreated(webDriver);
        }

        [Test, Order(2), Description("This test updates the new Time/Material record with valid details")]
        public void TestEditTimeMaterialRecord()
        {
            //TimeMaterialPage tmPageObj = new TimeMaterialPage();
            tmPageObj.EditNewlyCreatedTMRecord(webDriver);
        }

        [Test, Order(3), Description("This test deletes the last Time/Material record with valid details")]
        public void TestDeleteTimeMaterialRecord()
        {
            //TimeMaterialPage tmPageObj = new TimeMaterialPage();
            tmPageObj.DeleteTMRecord(webDriver);
        }

        [TearDown]
        public void CloseTestRun()
        { 
        webDriver.Quit();
        }


    }
}
