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
    class EuropeTest
    {
        private IWebDriver driver;

        /// <summary>
        /// Initializes the driver and stretches Chrome Window
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        /// <summary>
        /// Passes if results on ResultPage correlate with the given data
        /// Destination : Bristol
        /// Check-in:  05.10.2018
        /// Check-out: 07.10.2018
        /// </summary>
        [Test]
        public void SearchHomePage()
        {
            // Set search criteria and submit the form
            HomePage home = new HomePage(driver);
            home.SetFields("Bristol", "2018", "10", "05", "2018", "10", "7");
            home.InitiateSearch();

            // Traverse through results and get the locations of hotels
            ResultPage sr = new ResultPage(driver);
            List<string> cities = sr.GetCitiesList();

            // Checking that those hotels are in New York
            foreach (string city in cities)
            {
                Assert.IsTrue(city.Contains("Bristol"));
            }

            //Compose checkin/checkout date strings

            Assert.AreEqual("2018", sr.GetCheckinYear());
            Assert.AreEqual("2018", sr.GetCheckoutYear());
            Assert.AreEqual("10", sr.GetCheckinMonth());
            Assert.AreEqual("10", sr.GetCheckoutMonth());
            Assert.AreEqual("5", sr.GetCheckinDay());
            Assert.AreEqual("7", sr.GetCheckoutDay());
        }

        /// <summary>
        /// Closes the window as the test finishes
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
