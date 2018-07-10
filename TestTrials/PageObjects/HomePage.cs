using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestTrials.PageObjects
{
    class HomePage
    {
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

        [FindsBy(How = How.ClassName, Using = "sb-searchbox__button")]
        private IWebElement submitButton;

        [FindsBy(How = How.ClassName, Using = "bui-checkbox")]
        private IList<IWebElement> checkBox;

        [FindsBy(How = How.ClassName, Using = "xp__dates")]
        private IList<IWebElement> calendarTree;

        /// <summary>
        /// Fills out the form with test data
        /// </summary>
        /// <param name="city"></param>
        /// <param name="checkinYear"></param>
        /// <param name="checkinMonth"></param>
        /// <param name="checkinDay"></param>
        /// <param name="checkoutYear"></param>
        /// <param name="checkoutMonth"></param>
        /// <param name="checkoutDay"></param>
        public void SetFields(string city, 
            string checkinYear,  string checkinMonth,  string checkinDay, 
            string checkoutYear, string checkoutMonth, string checkoutDay)
        {
            driver.Navigate().GoToUrl("https://www.booking.com/");
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            //Making sure that calendar is not hidden
            calendarTree[0].Click();

            // Setting up checkout date
            this.checkoutYear.SendKeys(checkoutYear);
            this.checkoutMonth.SendKeys(checkoutMonth);
            this.checkoutDay.SendKeys(checkoutDay);
            
            // Setting up checkin date
            this.checkinMonth.SendKeys(checkinMonth);
            this.checkinDay.SendKeys(checkinDay);
            this.checkinYear.SendKeys(checkinYear);

            //Setting up the destination(no need for auto-completion)
            this.cityInput.SendKeys(city);
        }

        /// <summary>
        /// Verifies whether check box for traveling for work has been checked
        /// </summary>
        public void IsTravelForForWork()
        {
            this.checkBox[0].Click();
        }

        /// <summary>
        /// Presses the button that navigates to the results page
        /// </summary>
        public void InitiateSearch()
        {
            this.submitButton.Click();
        }
    }
}
