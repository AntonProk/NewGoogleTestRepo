using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;



namespace GoogleProjectTest
{
    public class GoogleLoginTest
    {
        [Test]
        public void GoogleLogin()
        {
            PropertyCollection.driver = new ChromeDriver();
            PropertyCollection.driver.Navigate().GoToUrl("https://www.google.com/");

            GoogleInitialPage googlepage = new GoogleInitialPage();
            PageFactory.InitElements(PropertyCollection.driver, googlepage);

            googlepage.clickLoginBtn();

            GoogleLoginPage googleloginpage = new GoogleLoginPage();
            PageFactory.InitElements(PropertyCollection.driver, googleloginpage);

            googleloginpage.Login("antonpprok@gmail.com", "Down123123Up");

            WebDriverWait wait = new WebDriverWait(PropertyCollection.driver, TimeSpan.FromMinutes(1));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".gb_db.gbii")));

            Assert.That(googlepage.AvatarIsPresent, Is.True);
        }
    }
}


