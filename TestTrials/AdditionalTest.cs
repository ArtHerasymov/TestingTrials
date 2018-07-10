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
    class AdditionalTest
    {
        private IWebDriver driver;

        /// <summary>
        /// Initializes the driver and stretches Chrome window
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        /// <summary>
        /// Passes if results on ResultPage correlate with the given data
        /// Destination: Bristol
        /// Check-in:  05.10.2018
        /// Check-out: 07.10.2018
        /// IsTravelForWork: True(Checked)
        /// </summary>
        [Test]
        public void SearchHomePage()
        {
            // Set search criteria and submit the form
            HomePage home = new HomePage(driver);
            home.SetFields("Bristol", "2018", "10", "05", "2018", "10", "7");
            home.IsTravelForForWork();
            home.InitiateSearch();

            ResultPage resultPage = new ResultPage(driver);
            Assert.AreEqual(resultPage.GetCheckBoxStatus(), "sb_travel_purpose");
        }

        /// <summary>
        /// Closes the windows as the test finishes
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
