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


        public ResultPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public List<string> GetCitiesList()
        {
            string path = @"e:\MyTest.txt";

            List<string> cityNames = new List<string>();
            foreach(IWebElement city in cities)
            {
                string innerHtml = city.GetAttribute("innerHTML");
                cityNames.Add(innerHtml);
                Console.WriteLine(innerHtml);
            }
            return cityNames;
        }

        public string GetCheckinYear()
        {
            return checkinYear.GetAttribute("value");
        }

        public string GetCheckinMonth()
        {
            return checkinMonth.GetAttribute("value");
        }

        public string GetCheckinDay()
        {
            return checkinDay.GetAttribute("value");
        }

        public string GetCheckoutYear()
        {
            return checkoutYear.GetAttribute("value");
        }

        public string GetCheckoutMonth()
        {
            return checkoutMonth.GetAttribute("value");
        }

        public string GetCheckoutDay()
        {
            return checkoutDay.GetAttribute("value");
        }

    }
}
