using OpenQA.Selenium;

namespace TurnUpPortalAutomation.Pages
{
    public class EmployeePage
    {
        public void CreateEmployeeRecord(IWebDriver webDriver)
        {
            Console.WriteLine("Employee Record Created");
        }

        public void EditNewlyCreatedEmployeeRecord(IWebDriver webDriver)
        {
            Console.WriteLine("Employee Record Edited");
        }

        public void DeleteEmployeeRecord(IWebDriver webDriver)
        {
            Console.WriteLine("Employee Record Deleted");
        }
    }
}
