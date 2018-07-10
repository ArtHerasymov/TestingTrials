using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTrials.PageObjects
{
    class HomePage
    {
        private const string V = "]/div[1]/div[2]/div/div[3]/div/div/div/div[1]";
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Name, Using = "ss")]
        private IWebElement cityInput;

        [FindsBy(How = How.Name, Using = "checkin_year")]
        private IWebElement checkinYear;

        [FindsBy(How = How.Name, Using = "checkin_month")]
        private IWebElement checkinMonth;

        [FindsBy(How = How.Name, Using = "checkin_monthday")]
        private IWebElement checkinDay;

        [FindsBy(How = How.Name, Using = "checkout_year")]
        private IWebElement checkoutYear;

        [FindsBy(How = How.Name, Using = "checkout_month")]
        private IWebElement checkoutMonth;

        [FindsBy(How = How.Name, Using = "checkout_monthday")]
        private IWebElement checkoutDay;

        [FindsBy(How = How.ClassName, Using = "c2-calendar-footer__inner-wrap")]
        private IWebElement date;

        [FindsBy(How = How.XPath, Using = V)]
        private IWebElement trigger;

        [FindsBy(How = How.ClassName, Using = "sb-searchbox__button")]
        private IWebElement submitButton;

        public void SetFields(string city, 
            string checkinYear,  string checkinMonth,  string checkinDay, 
            string checkoutYear, string checkoutMonth, string checkoutDay)
        {
            driver.Navigate().GoToUrl("https://www.booking.com/");
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.getElementsByClassName('xp__dates xp__group')[0].setAttribute('data-calendar-shown', '1')");
        
            // Setting up checkout date
            this.checkoutYear.SendKeys(checkoutYear);
            this.checkoutMonth.SendKeys(checkoutMonth);
            this.checkoutDay.SendKeys(checkoutDay);
            
            // Setting up checkin date
            this.checkinMonth.SendKeys(checkinMonth);
            this.checkinDay.SendKeys(checkinDay);
            this.checkinYear.SendKeys(checkinYear);

            this.cityInput.SendKeys(city);

        }

        public void InitiateSearch()
        {
            this.submitButton.Click();
        }
    }
}
