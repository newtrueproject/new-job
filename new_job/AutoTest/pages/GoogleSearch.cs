using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutoTest.pages
{
    class GoogleSearch
    {
        [FindsBy(How = How.TagName, Using = "title")]
        public IWebElement Title { get; set; }

        [FindsBy(How = How.Name, Using = "q")]
        public IWebElement SearchField { get; set; }

        [FindsBy(How = How.XPath, Using = "(.//*[normalize-space(text()) and normalize-space(.)='Видалити'])[1]/following::input[3]")]
        public IWebElement SearchButton { get; set; }

        [FindsBy(How = How.LinkText, Using = "Вікіпедія")]
        public IWebElement WikiLink { get; set; }

        [FindsBy(How = How.Id, Using = "lga")]
        public IWebElement Space { get; set; }
        
    }
}
