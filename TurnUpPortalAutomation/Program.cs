using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

//Open Chrome Browser
IWebDriver webDriver = new ChromeDriver();
webDriver.Manage().Window.Maximize();

//Launch TurnUp Portal and navigate to login page
webDriver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login");

//Identify username textbox and enter valid username
IWebElement usernameTextbox = webDriver.FindElement(By.Id("UserName"));
usernameTextbox.SendKeys("hari");

//Identify password textbox and enter valid password
IWebElement passwordTextbox = webDriver.FindElement(By.Id("Password"));
passwordTextbox.SendKeys("123123");


//Identify login button and click on the button
IWebElement loginButton = webDriver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
loginButton.Click();

//Check if user has logged in successfully
IWebElement helloHariLink = webDriver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));
if (helloHariLink.Text == "Hello hari!")
{
    Console.WriteLine("User has logged in successfully");
}
else
{
    Console.WriteLine("User hasn't been logged in.");
}



//Create a new Time/Material record

//Navigate to Time and Material module (Click Administration button -> Select Time & Materials Option)
IWebElement administrationDropdown = webDriver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
administrationDropdown.Click();
IWebElement tmOption = webDriver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
tmOption.Click();

//Click on the Create New Button
IWebElement createNewButton = webDriver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
createNewButton.Click();

Thread.Sleep(2000);

//Select Time from dropdown
IWebElement typeCodeDropdown = webDriver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]"));
typeCodeDropdown.Click();
IWebElement timetypeCode = webDriver.FindElement(By.XPath("//ul[@id='TypeCode_listbox']/li[2]"));
timetypeCode.Click();

//Enter Code
IWebElement codeTextbox = webDriver.FindElement(By.Id("Code"));
codeTextbox.SendKeys("GBTime");

//Enter Description
IWebElement descriptionTextbox = webDriver.FindElement(By.Id("Description"));
descriptionTextbox.SendKeys("GBTime Description");

//Enter Price per unit
IWebElement priceTextbox = webDriver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
priceTextbox.SendKeys("2206.85");

//Click on Select file button and select a file

//Click on Save button
IWebElement saveButton = webDriver.FindElement(By.Id("SaveButton"));
saveButton.Click();

Thread.Sleep(2000);

//Check if new Time/Material record has been created successfully
IWebElement goToLastPageButton = webDriver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
goToLastPageButton.Click();

IWebElement newCode = webDriver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
if (newCode.Text == "GBTime")
{
    Console.WriteLine("New Time record has been created successfully");
}
else
{
    Console.WriteLine("New Time record hasn't been created.");
}

//Click on Edit button
IWebElement editButton = webDriver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
editButton.Click();

//Edit Code to "b"
IWebElement codeTextboxEdit = webDriver.FindElement(By.Id("Code"));
codeTextboxEdit.Clear();
codeTextboxEdit.SendKeys("GBTimeNew");

//Edit Description to "b"
IWebElement descriptionTextboxEdit = webDriver.FindElement(By.Id("Description"));
descriptionTextboxEdit.Clear();
descriptionTextboxEdit.SendKeys("GBTimeNew Description");

//Edit Price per unit
IWebElement priceTextboxEdit = webDriver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
priceTextboxEdit.Click();
Actions actions = new Actions(webDriver);
actions.KeyDown(Keys.Control);
actions.SendKeys("a");
actions.KeyUp(Keys.Control);
actions.SendKeys("5785.32");
actions.Build();
actions.Perform();

//Click on Save button
IWebElement saveButtonEdit = webDriver.FindElement(By.Id("SaveButton"));
saveButtonEdit.Click();

Thread.Sleep(2000);

//Check if new Time/Material record has been edited successfully
IWebElement goToLastPageButtonEdit = webDriver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
goToLastPageButtonEdit.Click();


//Click on Delete button
IWebElement deleteButton = webDriver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
deleteButton.Click();

Thread.Sleep(2000);

//Click on Ok on pop-up window to delete item
//IAlert alert = webDriver.SwitchTo().Alert();
//alert.Accept();

//Click on Cancel on pop-up window to delete item
IAlert alert = webDriver.SwitchTo().Alert();
alert.Dismiss();

Thread.Sleep(2000);

//Check if new Time/Material record has been deleted/cancelled deletion
IWebElement goToLastPageButtonDelete = webDriver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
goToLastPageButtonDelete.Click();

