using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTrials.PageObjects
{
    class ResultPage
    {
        private IWebDriver driver;


        [FindsBy(How = How.CssSelector, Using = ".sr_item a.district_link")]
        IList<IWebElement> cities;

        [FindsBy(How = How.Name, Using = "checkin_year")]
        IWebElement checkinYear;

        [FindsBy(How = How.Name, Using = "checkin_month")]
        IWebElement checkinMonth;

        [FindsBy(How = How.Name, Using = "checkin_monthday")]
        IWebElement checkinDay;

        [FindsBy(How = How.Name, Using = "checkout_year")]
        IWebElement checkoutYear;

        [FindsBy(How = How.Name, Using = "checkout_month")]
        IWebElement checkoutMonth;

        [FindsBy(How = How.Name, Using = "checkout_monthday")]
        IWebElement checkoutDay;

        [FindsBy(How = How.XPath, Using = "//*[@id='frm']/div[5]/div[1]/div/label/input")]
        IWebElement checkBox;

        public ResultPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        /// <summary>
        /// Returns a list of cities that corresponds with each resulting hotel
        /// </summary>
        /// <returns></returns>
        public List<string> GetCitiesList()
        {
            List<string> cityNames = new List<string>();
            foreach(IWebElement city in cities)
            {
                string innerHtml = city.GetAttribute("innerHTML");
                cityNames.Add(innerHtml);
            }
            return cityNames;
        }

        /// <summary>
        /// Returns validated check-in year
        /// </summary>
        /// <returns></returns>
        public string GetCheckinYear()
        {
            return checkinYear.GetAttribute("value");
        }

        /// <summary>
        /// Returns validated check-in month
        /// </summary>
        /// <returns></returns>
        public string GetCheckinMonth()
        {
            return checkinMonth.GetAttribute("value");
        }

        /// <summary>
        /// Returns validated check-in monthday
        /// </summary>
        /// <returns></returns>
        public string GetCheckinDay()
        {
            return checkinDay.GetAttribute("value");
        }

        /// <summary>
        /// Returns validated check-out year
        /// </summary>
        /// <returns></returns>
        public string GetCheckoutYear()
        {
            return checkoutYear.GetAttribute("value");
        }

        /// <summary>
        /// Returns validated check-out year
        /// </summary>
        /// <returns></returns>
        public string GetCheckoutMonth()
        {
            return checkoutMonth.GetAttribute("value");
        }

        /// <summary>
        /// Returns validated check-out monthday
        /// </summary>
        /// <returns></returns>
        public string GetCheckoutDay()
        {
            return checkoutDay.GetAttribute("value");
        }

        /// <summary>
        /// Returns current css selector of the checkbox
        /// as it shows its status
        /// </summary>
        /// <returns></returns>
        public string GetCheckBoxStatus()
        {
            return checkBox.GetAttribute("name");
        }

    }
}
