using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using TurnUpPortalAutomation.Pages;

public class Program
{
    private static void Main(string[] args)
    {
        //Open Chrome Browser
        IWebDriver webDriver = new ChromeDriver();

        //Login page object initialisation and definition
        LoginPage loginPageObj = new LoginPage();
        loginPageObj.LoginActions(webDriver, "hari", "123123");

        //Homepage object initialisation and definition
        HomePage homePageObj = new HomePage();
        homePageObj.VerifyLoggedInUser(webDriver);
        homePageObj.NavigateToTimeMaterialPage(webDriver);

        //TMPage object initiation and definition
        TimeMaterialPage tmPageObj = new TimeMaterialPage();
        tmPageObj.CreateTimeRecord(webDriver);
        tmPageObj.VerifyRecordCreated(webDriver);
        tmPageObj.EditNewlyCreatedTMRecord(webDriver);
        tmPageObj.DeleteTMRecord(webDriver);
    }        
}