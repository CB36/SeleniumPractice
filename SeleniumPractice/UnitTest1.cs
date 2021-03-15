using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

/******This test opens a practice website. It clicks on a button in a popup window, then on the main page it selects a dropdown, then an option, and fills out text in a form. There is an assert to make the actions actually happened and then the browser closes. ********/


namespace SeleniumPractice
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            

        }

        [Test] 
        public void Test1()
        {

            //open browser

            IWebDriver driver = new ChromeDriver();

            //navigate to url

            driver.Navigate().GoToUrl("https://www.seleniumeasy.com/test/");
            
            //maximize window

            driver.Manage().Window.Maximize();

            //identify the button to be clicked, wait and click

            IWebElement noThanksButton = driver.FindElement(By.LinkText("No, thanks!"));

            //I added the wait so you can visually see the click happens

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            noThanksButton.Click();

            //identify dropdown to be clicked and click

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            IWebElement inputFormsDropDown = driver.FindElement(By.XPath("//*[@id='navbar-brand-centered']/ul[1]/li[1]/a"));

            inputFormsDropDown.Click(); 

            IWebElement simpleFormsOption = driver.FindElement(By.LinkText("Simple Form Demo"));

            simpleFormsOption.Click();

            //identify text field to be filled out & enter a string

            IWebElement messageField = driver.FindElement(By.Id("user-message"));

            messageField.SendKeys("Hello World, this test works!");

            //identify a button to be clicked to submit text and click

            IWebElement showMessageButton = driver.FindElement(By.XPath("//*[@id='get-input']/button"));

            showMessageButton.Click();

            //assert

            //set expected result

            string expectedMessage = "Hello World, this test works!";

            //identify element on page that shows the entered text

            IWebElement messageShownOnPage = driver.FindElement(By.XPath("//*[@id='display']"));

            //get the text from the above element
            
            string message = messageShownOnPage.Text;

            //compare the expected result and the actual result to make sure text was entered 

            Assert.AreEqual(expectedMessage, message);

            //Logout and close browser

            driver.Quit();
        }
    }
}