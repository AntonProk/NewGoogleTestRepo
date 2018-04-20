﻿using System;
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
    class LoginErrorTest
    {

        [Test]
        public void LoginError()
        {
            PropertyCollection.driver = new ChromeDriver();
            PropertyCollection.driver.Navigate().GoToUrl("https://www.google.com/");

            GoogleInitialPage googlepage = new GoogleInitialPage();
            PageFactory.InitElements(PropertyCollection.driver, googlepage);

            googlepage.clickLoginBtn();

            GoogleLoginPage googleloginpage = new GoogleLoginPage();
            PageFactory.InitElements(PropertyCollection.driver, googleloginpage);

            googleloginpage.Login("antonpprok@gmail.com", "Down123123");
            WebDriverWait wait = new WebDriverWait(PropertyCollection.driver, TimeSpan.FromMinutes(1));
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("dEOOab")));

            Assert.That(googleloginpage.ErrorMessageIsDisplayed, Is.True);
        }
    }
}
