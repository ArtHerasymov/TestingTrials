using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTrials.PageObjects;

namespace TestTrials
{
    class BookingTest
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void SearchHomePage()
        {
            // Set search criteria and submit the form
            HomePage home = new HomePage(driver);
            home.SetFields("New York", "2018", "09", "01", "2018", "09", "30");
            home.InitiateSearch();

            // Traverse through results and get the locations of hotels
            ResultPage sr = new ResultPage(driver);
            List<string> cities = sr.GetCitiesList();

            // Checking that those hotels are in New York
            foreach (string city in cities)
            {
                Assert.IsTrue(city.Contains("New York"));
            }

            //Compose checkin/checkout date strings

            Assert.AreEqual("2018" , sr.GetCheckinYear());
            Assert.AreEqual("2018" , sr.GetCheckoutYear());
            Assert.AreEqual("9" , sr.GetCheckinMonth());
            Assert.AreEqual("9" , sr.GetCheckoutMonth());
            Assert.AreEqual("1" , sr.GetCheckinDay());
            Assert.AreEqual("30", sr.GetCheckoutDay());
        }
        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
        
    }
}
