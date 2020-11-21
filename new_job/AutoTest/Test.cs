using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Chrome;
using System.Threading;
using AutoTest.pages;
using System;

namespace AutoTest
{
    [TestFixture]
    public class Test
    {
        //сценарии 
        //путь к браузеру
        public static string igWorkDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location); 
        public static IWebDriver driver;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            //выполняется перед запуском кейсов 
            ChromeOptions options = new ChromeOptions();
            driver = new ChromeDriver(igWorkDir, options);
            driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown] 
        public void OneTimeTearDown()
        {
            //выполняется после, выполнения всех кейсов
            driver.Quit();
        }

        [Test]
        public void W01_Google_Search()
        {
            //поиск сайта Википедия в Гугле и переход к нему
            driver.Navigate().GoToUrl("https://www.google.ua");
            GoogleSearch searchPage = new GoogleSearch();
            PageFactory.InitElements(driver, searchPage);
            searchPage.SearchField.Click();
            searchPage.SearchField.SendKeys("Вікіпедія");
            Thread.Sleep(2000);
            searchPage.Space.Click();
            Thread.Sleep(2000);
            searchPage.SearchButton.Click();
            Thread.Sleep(2000);
            driver.Navigate().GoToUrl(searchPage.WikiLink.GetAttribute("href"));
            Thread.Sleep(2000);
            Assert.AreEqual("Вікіпедія — Вікіпедія", driver.Title);
            Thread.Sleep(2000);
        }

        [Test]
        public void W02_Find_Article()
        {
            //поиск статьи внутри самой Википедии
            driver.Navigate().GoToUrl("https://uk.wikipedia.org");
            Thread.Sleep(2000);
            Wikipedia wikiPage = new Wikipedia();
            PageFactory.InitElements(driver, wikiPage);
            wikiPage.SearchField.SendKeys("Test case");
            Thread.Sleep(1000);
            wikiPage.SearchButton.Click();
            wikiPage.ArticleLink.Click();
            Thread.Sleep(2000);
            Assert.AreEqual("Тестовий випадок — Вікіпедія", driver.Title);
            Thread.Sleep(2000);
        }
    }
}
